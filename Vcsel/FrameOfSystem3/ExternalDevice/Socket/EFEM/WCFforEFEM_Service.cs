using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using WCF_Contract_;
using WCFforEFEM_Common;

using System.ServiceModel;

namespace WCFforEFEM_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceEquipment : IServiceEquipment
	{
		#region <CONSTRUCTOR>
		//private static ServiceEquipment _Instance = null;
		//public static ServiceEquipment GetInstance()
		//{
		//	if (_Instance == null)
		//	{
		//		_Instance = new ServiceEquipment();
		//	}

		//	return _Instance;
		//}
		public ServiceEquipment(CallBackReceive callBackReq, CallBackReceive callBackRes, CallBackReceive callBackSecsGemParameter, CallBackReceive callBackSecsGemEvent)
		{
			_callBackRequest = callBackReq;
			_callBackResponse = callBackRes;
			_callBackSecsGemParameter = callBackSecsGemParameter;
			_callBackSecsGemEvent = callBackSecsGemEvent;
		}
		#endregion </CONSTRUCTOR>

		#region <FIELD>
		CallBackReceive _callBackRequest = null;
		CallBackReceive _callBackResponse = null;
		CallBackReceive _callBackSecsGemParameter = null;
		CallBackReceive _callBackSecsGemEvent = null;
		#endregion </FIELD>

		#region <INTERFACE>
		public void RegisteredClient()
		{
			// 연결을 요청한 클라이언트의 ID를 구분하여 저장
			string str = OperationContext.Current.SessionId;

			// 클라이언트 단선 감지
			OperationContext.Current.Channel.Faulted	+= Channel_Faulted;
			OperationContext.Current.Channel.Closed		+= Channel_Closed;

			string strID = OperationContext.Current.SessionId;
			FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WCF SERVICE CLIENT CONNECTED (Session ID : {0}", strID));
        }
		#endregion </INTERFACE>

		/// <summary>
		/// 2021.08.13 by twkang [ADD] 클라이언트 통신 연결 상태가 Faulted(비정상종료) 상태가 되면 진입
		/// </summary>
		private void Channel_Faulted(object sender, EventArgs e)
		{
			// EFEM에서 Disconnect 했을 경우.
			FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WCF SERVICE FAULTED EVENT"));
		}

		/// <summary>
		/// 2021.08.13 by twkang [ADD] 클라이언트 통신 연결 상태가 Close(정상종료) 상태가 되면 진입
		/// </summary>
		private void Channel_Closed(object sender, EventArgs e)
		{
			// EFEM에서 Disconnect 했을 경우.
			FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("WCF SERVICE CLOSE EVENT"));
		}

		#region <RECEIVE>
		public IAsyncResult BeginRequest(string sPortName, string sFunction, AsyncCallback callback, object state)
		{
			ReceiveAsyncResult asycResult = null;

			try
			{
				ReceiveResult pData = new ReceiveResult();

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("RECEIVE REQUEST (Port : {0}, Function : {1})"
                    , sPortName, sFunction));

                pData.PortName = sPortName;
                pData.Function = sFunction;

				asycResult = new ReceiveAsyncResult(pData, callback, state);

				ThreadPool.QueueUserWorkItem(new WaitCallback(_callBackRequest), asycResult);
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("EFEM SERVICE BeginRequest SUCCESS"));
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE BeginRequest EXCEPTION : " + ex.Message);
			}

			return asycResult;
		}
		public ReceiveResult EndRequest(IAsyncResult ar)
		{
			ReceiveResult result = null;

			try
			{
				if(ar != null)
				{
					using (ReceiveAsyncResult asyncResult = ar as ReceiveAsyncResult)
					{
						if (asyncResult == null)
							throw new ArgumentNullException("IAsyncResult parameter is null.");

						if (asyncResult.Exception != null)
							throw asyncResult.Exception;

						asyncResult.AsyncWait.WaitOne();

						result = asyncResult.ResultData;
					}
				}
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE EndRequest EXCEPTION : " + ex.Message);
			}
			return result;
		}

		public IAsyncResult BeginResponse(ResponseResult sResult, AsyncCallback callback, object state)
        {
            ReceiveAsyncResult asycResult = null;

            try
            {
				ReceiveResult pData = new ReceiveResult();

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("RECEIVE RESPONSE (Port : {0}, Function : {1})"
                    , sResult.PortName, sResult.Function));

				pData.PortName = sResult.PortName;
                pData.Function = sResult.Function;

				asycResult = new ReceiveAsyncResult(pData, callback, state);

				ThreadPool.QueueUserWorkItem(new WaitCallback(_callBackResponse), asycResult);
            }
            catch (Exception ex)
            {
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE BeginResponse EXCEPTION : " + ex.Message);
            }

            return asycResult;
        }
        public ReceiveResult EndResponse(IAsyncResult ar)
        {
            ReceiveResult result = null;

            try
            {
                if (ar != null)
                {
                    using (ReceiveAsyncResult asyncResult = ar as ReceiveAsyncResult)
                    {
                        if (asyncResult == null)
                            throw new ArgumentNullException("IAsyncResult parameter is null.");

                        if (asyncResult.Exception != null)
                            throw asyncResult.Exception;

                        asyncResult.AsyncWait.WaitOne();

                        result = asyncResult.ResultData;
					}
                }
            }
            catch (Exception ex)
            {
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE EndResponse EXCEPTION : " + ex.Message);
            }

            return result;
        }

		public IAsyncResult BeginSecsGemParameter(string type, Dictionary<string, string> dataList, AsyncCallback callback, object state)
		{
			SecsGemParameterAsyncResult asycResult = null;

			try
			{
				SecsGemParameter pData = new SecsGemParameter();

				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SecsGem Parameter (Type : {0}, Count : {1})"
					, type, dataList.Count));

				pData.Type = type;
				pData.DataList = dataList;

				asycResult = new SecsGemParameterAsyncResult(pData, callback, state);

				ThreadPool.QueueUserWorkItem(new WaitCallback(_callBackSecsGemParameter), asycResult);
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE BeginSecsGemParameter SUCCESS");
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE BeginSecsGemParameter EXCEPTION : " + ex.Message);
			}

			return asycResult;
		}
		public SecsGemParameter EndSecsGemParameter(IAsyncResult ar)
		{
			SecsGemParameter result = null;

			try
			{
				if (ar != null)
				{
					using (SecsGemParameterAsyncResult asyncResult = ar as SecsGemParameterAsyncResult)
					{
						if (asyncResult == null)
							throw new ArgumentNullException("IAsyncResult parameter is null.");

						if (asyncResult.Exception != null)
							throw asyncResult.Exception;

						asyncResult.AsyncWait.WaitOne();

						result = asyncResult.ResultData;
					}
				}
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE EndRequest EXCEPTION : " + ex.Message);
			}
			return result;
		}

		public IAsyncResult BeginSecsGemEvent(string type, string sFunction, Dictionary<string, string> dataList, AsyncCallback callback, object state)
		{
			SecsGemEventAsyncResult asycResult = null;

			try
			{
				SecsGemEvent pData = new SecsGemEvent();

				int dataListCount = 0;
				if (dataList != null) dataListCount = dataList.Count;
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog(string.Format("SecsGem Parameter (Type : {0}, Count : {1})"
					, type, dataListCount));

				pData.Type = type;
				pData.Function = sFunction;
				pData.DataList = dataList;

				asycResult = new SecsGemEventAsyncResult(pData, callback, state);

				ThreadPool.QueueUserWorkItem(new WaitCallback(_callBackSecsGemEvent), asycResult);
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE BeginSecsGemEvent SUCCESS");
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE BeginSecsGemEvent EXCEPTION : " + ex.Message);
			}

			return asycResult;
		}
		public SecsGemEvent EndSecsGemEvent(IAsyncResult ar)
		{
			SecsGemEvent result = null;

			try
			{
				if (ar != null)
				{
					using (SecsGemEventAsyncResult asyncResult = ar as SecsGemEventAsyncResult)
					{
						if (asyncResult == null)
							throw new ArgumentNullException("IAsyncResult parameter is null.");

						if (asyncResult.Exception != null)
							throw asyncResult.Exception;

						asyncResult.AsyncWait.WaitOne();

						result = asyncResult.ResultData;
					}
				}
			}
			catch (Exception ex)
			{
				FrameOfSystem3.ExternalDevice.EfemLogMessageEvent.WriteLog("EFEM SERVICE EndRequest EXCEPTION : " + ex.Message);
			}
			return result;
		}
		#endregion </RECEIVE>

		public delegate void CallBackReceive(object state);

	}
}
