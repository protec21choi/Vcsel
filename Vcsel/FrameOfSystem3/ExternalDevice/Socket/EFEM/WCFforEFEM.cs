using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WCFforEFEM_Common;
using WCF_Contract_;
using WCFforEFEM_Service;

using System.ServiceModel.Description;
using System.ServiceModel;

namespace WCFforEFEM_
{
	class WCFforEFEM
	{
		#region <FIELD>
		private ServiceHost _host = null;
		private ServiceEquipment _serviceEquipment = null;
		private ProxyFactory<IServiceEquipment> _addProxy = null;
		private IServiceEquipment _iService = null;

		private string _hostIp = string.Empty;
		private string _hostPort = string.Empty;
		private string _connectIp = string.Empty;
		private string _connectPort = string.Empty;

		private RequestAck _callBackAck = null;
		private SecsGemParameterAck _secsGemParameterAck = null;
		private SecsGemEventAck _secsGemEventAck = null;

		private ReceiveRequest _callBackRequest = null;
		private ReceiveResponse _callBackResponse = null;
		private ReceiveSecsGemParameter _callBackSecsGemParameter = null;
		private ReceiveSecsGemEvent _callBackSecsGemEvent = null;

		#region Constants
		private const int TIMEOUT_OPEN = 1000;
		private const int TIMEOUT_CLOSE = 1000;
		private const int TIMEOUT_INACTIVITY = 1800000;	// 2min -> 30min으로 변경
		#endregion

		#endregion </FIELD>

		#region <PROPERTY>
		public string HostIp { get { return _hostIp; } set { _hostIp = value; } }
		public string HostPort { get { return _hostPort; } set { _hostPort = value; } }
		public string ConnectIp { get { return _connectIp; } set { _connectIp = value; } }
		public string ConnectPort { get { return _connectPort; } set { _connectPort = value; } }
		#endregion </PROPERTY>

		#region OPEN / CONNECT
		public bool Open()
		{
			#region Address
			if (_hostIp.Equals(string.Empty) || _hostPort.Equals(string.Empty))
				return false;

			Uri tcpUri = new Uri(string.Format("net.tcp://{0}:{1}/", _hostIp, _hostPort));
			#endregion

			#region Binding
			// Binding : TCP 사용
			NetTcpBinding binding = new NetTcpBinding();
			binding.MaxBufferSize = 2147483647;
			binding.MaxReceivedMessageSize = 2147483647;

			// 보안모드
			binding.Security.Mode = SecurityMode.None;

			binding.OpenTimeout = TimeSpan.FromMilliseconds(TIMEOUT_OPEN);
			binding.CloseTimeout = TimeSpan.FromMilliseconds(TIMEOUT_CLOSE);
			binding.ReceiveTimeout = TimeSpan.MaxValue;			// 2023.06.13 by junho [ADD] 장시간 통신이 없을 때 Host 닫아버리는 현상 개선

			// 설정하면 지정 시간 동안 통신이 없으면 이후 Faulted 이벤트 발생
			binding.ReliableSession.Enabled = false;
			binding.ReliableSession.InactivityTimeout = TimeSpan.FromMilliseconds(TIMEOUT_INACTIVITY);
			#endregion

			try
			{
				// Service Host 만들기
				//m_pHost = new ServiceHost(ServiceEquipment.GetInstance(), tcpUri);
				_serviceEquipment = new ServiceEquipment(
					CallbackReceiveRequest
					, CallbackReceiveResponse
					, CallbackReceiveSecsGemParameter
					, CallbackReceiveSecsGemEvent
					);

				_host = new ServiceHost(_serviceEquipment, tcpUri);

				// End Point 추가
				_host.AddServiceEndpoint(typeof(IServiceEquipment), binding, "");

				// Service Host 시작
				_host.Open();

				foreach (ServiceEndpoint endPnt in _host.Description.Endpoints)
				{
				}
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF OPEN SUCCESS");
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF OPEN EXCEPTION : " + ex.Message);
				return false;
			}

			return true;
		}
		public bool Open(string hostIp, string hostPort)
		{
			_hostIp = hostIp;
			_hostPort = hostPort;
			return Open();
		}
		public bool IsOpen()
		{
			if (_host == null)
				return false;

			return _host.State.Equals(CommunicationState.Opened);
		}
		public bool Close()
		{
			try
			{
				_host.Close();
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF CLOSE SUCCESS");
				return true;
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF CLOSE EXCEPTION : " + ex.Message);
				return false;
			}
		}
		public bool Connect()
		{
			if (_connectIp.Equals(string.Empty) || _connectPort.Equals(string.Empty))
				return false;

			try
			{
				NetTcpBinding binding = new NetTcpBinding();

				binding.Security.Mode = SecurityMode.None;

				binding.MaxBufferSize = 2147483647;
				binding.MaxReceivedMessageSize = 2147483647;

				// 시간 설정 (비정상 종료 확정시간) 미설정 연결상태가 바뀌면 이벤트가 발생하도록 조치함
				//binding.ReliableSession.Enabled = false;
				//binding.ReliableSession.InactivityTimeout = TimeSpan.FromSeconds(10);

				string address = string.Format("net.tcp://{0}:{1}/", _connectIp, _connectPort);

				EndpointAddress addr = new EndpointAddress(address);

				_addProxy = new ProxyFactory<IServiceEquipment>(binding, addr);

				_addProxy.Open();

				_iService = _addProxy.CreateProxy();

				// 통신 상태 체크 이벤트
				((ICommunicationObject)_iService).Closing += Closing_Event;
				((ICommunicationObject)_iService).Closed += Close_Event;
				((ICommunicationObject)_iService).Faulted += Faulted_Event;

				_iService.RegisteredClient();

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF CONNECT SUCCESS");
				return true;
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF CONNECT EXCEPTION : " + ex.Message);
				return false;
			}
		}
		public bool Connect(string connectIp, string connectPort)
		{
			_connectIp = connectIp;
			_connectPort = connectPort;
			return Connect();
		}
		public bool Disconnect()
		{
			try
			{
				if (_addProxy == null)
					return true;

				_addProxy.CloseProxy();
				_addProxy.Close();
				_iService = null;

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF DISCONNECT SUCCESS");
				return true;
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF DISCONNECT EXCEPTION : " + ex.Message);
				return false;
			}
		}
		public bool IsConnect()
		{
			return GetServerStatus().Equals(CommunicationState.Opened.ToString());
		}
		#endregion

		#region <INTERFACE>
        public string GetHostStatus()
        {
            ///	Created = 0,
            /// Opening = 1,
            /// Opened = 2,
            /// Closing = 3,
            /// Closed = 4,
            /// Faulted = 5,

            if (_host == null)
                return CommunicationState.Closed.ToString();

            return _host.State.ToString();
        }
		public string GetServerStatus()
		{	
			///	Created = 0,
			/// Opening = 1,
			/// Opened = 2,
			/// Closing = 3,
			/// Closed = 4,
			/// Faulted = 5,

			if (_iService == null)
				return CommunicationState.Closed.ToString();

			return ((ICommunicationObject)_iService).State.ToString();
		}
		public bool DoRequest(string portName, string requestSubject, RequestAck callBackAck)
		{
			if (_iService == null)
				return false;

			try
			{
				_callBackAck = callBackAck;
				IAsyncResult res = _iService.BeginRequest(portName, requestSubject, new AsyncCallback(CallBackRequestAck), _iService);
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WCF DO REQUEST (Port : {0}, Request : {1})"
                    , portName, requestSubject));
				return true;
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF DO REQUEST EXCEPTION : " + ex.Message);
                Disconnect();
				return false;
			}
		}
		public bool DoSecsGemParameter(string type, Dictionary<string,string> dataList, SecsGemParameterAck callBackAck)
		{
			if (_iService == null)
				return false;

			try
			{
				_secsGemParameterAck = callBackAck;
				IAsyncResult res = _iService.BeginSecsGemParameter(type, dataList, new AsyncCallback(CallBackSecsGemParameterAck), _iService);
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("DoUpdate SecsGem Parameter (Type : {0})", type));
				return true;
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF SecsGem Parameter EXCEPTION : " + ex.Message);
				Disconnect();
				return false;
			}
		}
		public bool DoSecsGemSendEvent(string type, string sFunction, Dictionary<string, string> dataList, SecsGemEventAck callBackAck)
		{
			if (_iService == null)
				return false;

			try
			{
				_secsGemEventAck = callBackAck;
				IAsyncResult res = _iService.BeginSecsGemEvent(type, sFunction, dataList, new AsyncCallback(CallBackSecsGemEventAck), _iService);
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("DoUpdate SecsGem Event (Type : {0}, Function : {1})"
					, type, sFunction));
				return true;
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("WCF SecsGem Event EXCEPTION : " + ex.Message);
				Disconnect();
				return false;
			}
		}

		public void RegisterReceiveRequest(ReceiveRequest callBack)
		{
			_callBackRequest = callBack;
		}
		public void RegisterReceiveResponse(ReceiveResponse callBack)
		{
			_callBackResponse = callBack;
		}
		public void RegisterReceiveSecsGemParameter(ReceiveSecsGemParameter callBack)
		{
			_callBackSecsGemParameter = callBack;
		} 
		public void RegisterReceiveSecsGemEvent(ReceiveSecsGemEvent callBack)
		{
			_callBackSecsGemEvent = callBack;
		}
		#endregion </INTERFACE>

		#region <METHOD>
		private void Faulted_Event(object sender, EventArgs e)
		{
			// Host Close(또는 강제 Disconnect) 된 상황
            Disconnect();
			FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WCF FAULTED EVENT"));
		}
		private void Close_Event(object sender, EventArgs e)
		{
			// Host Close(또는 강제 Disconnect) 된 상황
            Disconnect();
			FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WFC CLOSE EVENT"));
		}
		private void Closing_Event(object sender, EventArgs e)
		{
			// Host Close(또는 강제 Disconnect) 된 상황
			Disconnect();
			FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WFC CLOSING EVENT"));
		}
		#endregion </METHOD>

		#region <CALLBACK>
		private void CallBackRequestAck(IAsyncResult ar)
		{
			try
			{
				IServiceEquipment res = ar.AsyncState as IServiceEquipment;
				if (res != null)
				{
					ReceiveResult e = res.EndRequest(ar);

					FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("REQUEST ACK (Port : {0}, Request : {1}, Result : {2}, Description : {3})"
						, e.PortName, e.Function, e.Result, e.Description));

					if (_callBackAck != null)
					{
						_callBackAck(e.PortName, e.Function, e.Result, e.Description);
					}
				}
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM CALL BACK EXCEPTION : " + ex.Message);
			}
		}
		private void CallBackSecsGemParameterAck(IAsyncResult ar)
		{
			try
			{
				IServiceEquipment res = ar.AsyncState as IServiceEquipment;
				if (res != null)
				{
					SecsGemParameter e = res.EndSecsGemParameter(ar);

					FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SecsGem Parameter ACK (Type : {0}, Result : {1}, Description : {2})"
						, DateTime.Now.ToString(), e.Type, e.Result, e.Description));

					if (_secsGemParameterAck != null)
					{
						_secsGemParameterAck(e.Type, e.DataList, e.Result, e.Description);
					}
				}
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM CALL BACK EXCEPTION : " + ex.Message);
			}
		}
		private void CallBackSecsGemEventAck(IAsyncResult ar)
		{
			try
			{
				IServiceEquipment res = ar.AsyncState as IServiceEquipment;
				if (res != null)
				{
					SecsGemEvent e = res.EndSecsGemEvent(ar);

					FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SecsGem Parameter ACK (Type : {0}, Result : {1}, Description : {2})"
						, DateTime.Now.ToString(), e.Type, e.Result, e.Description));

					if (_secsGemEventAck != null)
					{
						_secsGemEventAck(e.Type, e.Function, e.DataList, e.Result, e.Description);
					}
				}
				
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM CALL BACK EXCEPTION : " + ex.Message);
			}
		}

		private void CallbackReceiveRequest(object state)
		{
			ReceiveAsyncResult asyncResult = null;

			try
			{
				asyncResult = state as ReceiveAsyncResult;

				string result;
				string description;
				if (_callBackRequest != null)
				{
					_callBackRequest(asyncResult.ResultData.PortName, asyncResult.ResultData.Function, out result, out description);
					asyncResult.ResultData.Result = result;
					asyncResult.ResultData.Description = description;
				}
				else
				{
					asyncResult.ResultData.Result = "ACK";
					asyncResult.ResultData.Description = "No_Problem";
				}

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SEND->RESPONSE ACK (Port : {0}, Function : {1}, Result : {2}, Description : {3})"
                    , asyncResult.ResultData.PortName, asyncResult.ResultData.Function, asyncResult.ResultData.Result, asyncResult.ResultData.Description));
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE CallbackReceive EXCEPTION : " + ex.Message);
			}
			finally
			{
				if (asyncResult != null) asyncResult.Complete();
			}
		}
		private void CallbackReceiveResponse(object state)
		{
			ReceiveAsyncResult asyncResult = null;

			try
			{
				asyncResult = state as ReceiveAsyncResult;

				string result;
				string description;
				if(_callBackResponse != null)
				{
					_callBackResponse(asyncResult.ResultData.PortName, asyncResult.ResultData.Function, out result, out description);
					asyncResult.ResultData.Result = result;
					asyncResult.ResultData.Description = description;
				}
				else
				{
					asyncResult.ResultData.Result = "ACK";
					asyncResult.ResultData.Description = "No_Problem";
				}

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SEND->RESPONSE ACK (Port : {0}, Function : {1}, Result : {2}, Description : {3})"
                    ,asyncResult.ResultData.PortName, asyncResult.ResultData.Function, asyncResult.ResultData.Result, asyncResult.ResultData.Description));
			}
			catch (Exception ex)
			{
				Console.WriteLine("EFEM SERVICE CallbackReceive EXCEPTION : " + ex.Message);
			}
			finally
			{
				if (asyncResult != null) asyncResult.Complete();
			}
		}
		private void CallbackReceiveSecsGemParameter(object state)
		{
			SecsGemParameterAsyncResult asyncResult = null;

			try
			{
				asyncResult = state as SecsGemParameterAsyncResult;

				string result;
				string description;
				if (_callBackSecsGemParameter != null)
				{
					_callBackSecsGemParameter(asyncResult.ResultData.Type, asyncResult.ResultData.DataList, out result, out description);
					asyncResult.ResultData.Result = result;
					asyncResult.ResultData.Description = description;
				}
				else
				{
					asyncResult.ResultData.Result = "NACK";
					asyncResult.ResultData.Description = "Not_Ready";
				}

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SEND->RESPONSE ACK (Port : {0}, DataCount : {1}, Result : {2}, Description : {3})"
					, asyncResult.ResultData.Type, asyncResult.ResultData.DataList.Count, asyncResult.ResultData.Result, asyncResult.ResultData.Description));
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE CallbackReceive EXCEPTION : " + ex.Message);
			}
			finally
			{
				if (asyncResult != null) asyncResult.Complete();
			}
		}
		private void CallbackReceiveSecsGemEvent(object state)
		{
			SecsGemEventAsyncResult asyncResult = null;

			try
			{
				asyncResult = state as SecsGemEventAsyncResult;

				string result;
				string description;
				if (_callBackSecsGemEvent != null)
				{
					_callBackSecsGemEvent(asyncResult.ResultData.Type, asyncResult.ResultData.Function, asyncResult.ResultData.DataList, out result, out description);
					asyncResult.ResultData.Result = result;
					asyncResult.ResultData.Description = description;
				}
				else
				{
					asyncResult.ResultData.Result = "NACK";
					asyncResult.ResultData.Description = "Not_Ready";
				}

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SEND->RESPONSE ACK (Port : {0}, Function : {1}, DataCount : {2}, Result : {3}, Description : {4})"
					, asyncResult.ResultData.Type, asyncResult.ResultData.Function, asyncResult.ResultData.DataList.Count, asyncResult.ResultData.Result, asyncResult.ResultData.Description));
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE CallbackReceive EXCEPTION : " + ex.Message);
			}
			finally
			{
				if (asyncResult != null) asyncResult.Complete();
			}
		}
		#endregion </CALLBACK>

	}

	public delegate void RequestAck(string portName, string requestSubject, string result, string description);
	public delegate void SecsGemParameterAck(string type, Dictionary<string, string> dataList, string result, string description);
	public delegate void SecsGemEventAck(string type, string sFucntion, Dictionary<string,string> dataList, string result, string description);

	public delegate void ReceiveRequest(string portName, string requestSubject, out string result, out string description);
	public delegate void ReceiveResponse(string portName, string requestSubject, out string result, out string description);
	public delegate void ReceiveSecsGemParameter(string type,  Dictionary<string, string> dataList, out string result, out string description);
	public delegate void ReceiveSecsGemEvent(string type, string sFunction, Dictionary<string, string> dataList, out string result, out string description);
}
