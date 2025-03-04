using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WCF_.Common;
using WCF_.Contract;
using WCF_.Service;

using System.ServiceModel.Description;
using System.ServiceModel;

namespace WCF_
{
	class WCF
	{
		#region constructor
		public WCF(int index, DeleWriteLog deleWriteLog)
		{
			_index = index;
			_writeLog = deleWriteLog;
			WcfLogEvent.onWriteLog += new WcfLogEvent.EventWriteLog(WriteLog);
		}
		#endregion /constructor

		#region field
		int _index;
		bool _use = false;
		bool _opened = false;
		bool _connected = false;

		ServiceHost _host = null;
		ServiceEquipment _serviceEquipment = null;
		ProxyFactory<IService> _addProxy = null;
		IService _iService = null;

		string _hostIp = string.Empty;
		string _hostPort = string.Empty;
		string _connectIp = string.Empty;
		string _connectPort = string.Empty;

		DeleAck _callBackAck = null;
		DeleReceive _callBackReceive = null;
		DeleWriteLog _writeLog = null;

		#region constants
		const int TIMEOUT_OPEN = 1000;
		const int TIMEOUT_CLOSE = 1000;
		const int TIMEOUT_INACTIVITY = 1800000;	// 2min -> 30min으로 변경
		#endregion /constants

		#endregion /field

		#region property
		public int Index { get { return _index; } }
		public bool Use { get { return _use; } set { _use = value; } }
		public bool Opened { get { return _opened; } set { _opened = value; } }
		public bool Connected { get { return _connected; } set { _connected = value; } }

		public string HostIp { get { return _hostIp; } set { _hostIp = value; } }
		public string HostPort { get { return _hostPort; } set { _hostPort = value; } }
		public string ConnectIp { get { return _connectIp; } set { _connectIp = value; } }
		public string ConnectPort { get { return _connectPort; } set { _connectPort = value; } }
		#endregion /property

		#region interface

		#region communication
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
					CallbackReceive
					);

				_host = new ServiceHost(_serviceEquipment, tcpUri);

				// End Point 추가
				_host.AddServiceEndpoint(typeof(IService), binding, "");

				// Service Host 시작
				_host.Open();

				foreach (ServiceEndpoint endPnt in _host.Description.Endpoints)
				{
				}
				WriteLog("WCF OPEN SUCCESS");
			}
			catch (Exception ex)
			{
				WriteLog("WCF OPEN EXCEPTION : " + ex.Message);
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
				WriteLog("WCF CLOSE SUCCESS");
				return true;
			}
			catch (Exception ex)
			{
				WriteLog("WCF CLOSE EXCEPTION : " + ex.Message);
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

				_addProxy = new ProxyFactory<IService>(binding, addr);

				_addProxy.Open();

				_iService = _addProxy.CreateProxy();

				// 통신 상태 체크 이벤트
				((ICommunicationObject)_iService).Closing += Closing_Event;
				((ICommunicationObject)_iService).Closed += Close_Event;
				((ICommunicationObject)_iService).Faulted += Faulted_Event;

				_iService.RegisteredClient();

				WriteLog("WCF CONNECT SUCCESS");
				return true;
			}
			catch (Exception ex)
			{
				WriteLog("WCF CONNECT EXCEPTION : " + ex.Message);
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

				WriteLog("WCF DISCONNECT SUCCESS");
				return true;
			}
			catch (Exception ex)
			{
				WriteLog("WCF DISCONNECT EXCEPTION : " + ex.Message);
				return false;
			}
		}
		public bool IsConnect()
		{
			return GetServerStatus().Equals(CommunicationState.Opened.ToString());
		}
		#endregion /communication

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
		public bool DoSend(string title, Dictionary<string, string> dataList, DeleAck callBackAck)
		{
			if (_iService == null)
				return false;

			try
			{
				_callBackAck = callBackAck;
				IAsyncResult res = _iService.BeginReceive(title, dataList, new AsyncCallback(CallBackAck), _iService);
				WriteLog(string.Format("SEND (Title : {0})", title));
				return true;
			}
			catch (Exception ex)
			{
				WriteLog("SEND EXCEPTION : " + ex.Message);
                Disconnect();
				return false;
			}
		}
		public void RegisterReceive(DeleReceive callBack)
		{
			_callBackReceive = callBack;
		}
		#endregion /interface

		#region method
		void Faulted_Event(object sender, EventArgs e)
		{
			// Host Close(또는 강제 Disconnect) 된 상황
            Disconnect();
			WriteLog(string.Format("WCF FAULTED EVENT"));
		}
		void Close_Event(object sender, EventArgs e)
		{
			// Host Close(또는 강제 Disconnect) 된 상황
            Disconnect();
			WriteLog(string.Format("WFC CLOSE EVENT"));
		}
		void Closing_Event(object sender, EventArgs e)
		{
			// Host Close(또는 강제 Disconnect) 된 상황
			Disconnect();
			WriteLog(string.Format("WFC CLOSING EVENT"));
		}

		void WriteLog(string message)
		{
			_writeLog(_index, message);
		}
		#endregion /method

		#region callback
		void CallBackAck(IAsyncResult ar)
		{
			try
			{
				IService res = ar.AsyncState as IService;
				if (res != null)
				{
					DataResult e = res.EndReceive(ar);

					WriteLog(string.Format("ACK (Title : {0}, Result : {1}, Description : {2})"
						, e.Title, e.Result, e.Description));

					if (_callBackAck != null)
					{
						_callBackAck(e.Title, e.DataList, e.Result, e.Description);
					}
				}
			}
			catch (Exception ex)
			{
				WriteLog("EFEM CALL BACK EXCEPTION : " + ex.Message);
			}
		}
		void CallbackReceive(object state)
		{
			ReceiveAsyncResult asyncResult = null;

			try
			{
				asyncResult = state as ReceiveAsyncResult;

				string result;
				string description;
				if (_callBackReceive != null)
				{
					_callBackReceive(asyncResult.ResultData.Title, asyncResult.ResultData.DataList, out result, out description);
					asyncResult.ResultData.Result = result;
					asyncResult.ResultData.Description = description;
				}
				else
				{
					asyncResult.ResultData.Result = "ACK";
					asyncResult.ResultData.Description = "No_Problem";
				}

				WriteLog(string.Format("RECEIVE (Title : {0}, Result : {1}, Description : {2})"
                    , asyncResult.ResultData.Title, asyncResult.ResultData.Result, asyncResult.ResultData.Description));
			}
			catch (Exception ex)
			{
				WriteLog("EFEM SERVICE CallbackReceive EXCEPTION : " + ex.Message);
			}
			finally
			{
				if (asyncResult != null) asyncResult.Complete();
			}
		}
		#endregion /callback
	}

	public delegate void DeleAck(string title, Dictionary<string, string> dataList, string result, string description);
	public delegate void DeleReceive(string title, Dictionary<string, string> dataList, out string result, out string description);

	public delegate void DeleWriteLog(int index, string message);

	public class WcfLogEvent
	{
		public delegate void EventWriteLog(string message);
		public static event EventWriteLog onWriteLog;
		public static void WriteLog(string message)
		{
			if (onWriteLog != null)
			{
				onWriteLog(message);
			}
		}
	}
}
