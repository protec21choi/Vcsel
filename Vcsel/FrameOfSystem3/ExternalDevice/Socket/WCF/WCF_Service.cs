using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using WCF_.Contract;
using WCF_.Common;

using System.ServiceModel;

namespace WCF_.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceEquipment : IService
	{
		#region constructor
		//private static ServiceEquipment _Instance = null;
		//public static ServiceEquipment GetInstance()
		//{
		//	if (_Instance == null)
		//	{
		//		_Instance = new ServiceEquipment();
		//	}

		//	return _Instance;
		//}
		public ServiceEquipment(CallBackReceive callBackReceive)
		{
			_callBackReceive = callBackReceive;
		}
		#endregion /constructor

		#region field
		CallBackReceive _callBackReceive = null;
		#endregion /field

		#region interface
		public void RegisteredClient()
		{
			// 연결을 요청한 클라이언트의 ID를 구분하여 저장
			string str = OperationContext.Current.SessionId;

			// 클라이언트 단선 감지
			OperationContext.Current.Channel.Faulted	+= Channel_Faulted;
			OperationContext.Current.Channel.Closed		+= Channel_Closed;

			string strID = OperationContext.Current.SessionId;
			WcfLogEvent.WriteLog(string.Format("WCF SERVICE CLIENT CONNECTED (Session ID : {0}", strID));
        }
		#endregion /interface

		/// <summary>
		/// 2021.08.13 by twkang [ADD] 클라이언트 통신 연결 상태가 Faulted(비정상종료) 상태가 되면 진입
		/// </summary>
		private void Channel_Faulted(object sender, EventArgs e)
		{
			// EFEM에서 Disconnect 했을 경우.
			WcfLogEvent.WriteLog(string.Format("WCF SERVICE FAULTED EVENT"));
		}

		/// <summary>
		/// 2021.08.13 by twkang [ADD] 클라이언트 통신 연결 상태가 Close(정상종료) 상태가 되면 진입
		/// </summary>
		private void Channel_Closed(object sender, EventArgs e)
		{
			// EFEM에서 Disconnect 했을 경우.
			WcfLogEvent.WriteLog(string.Format("WCF SERVICE CLOSE EVENT"));
		}

		public IAsyncResult BeginReceive(string title, Dictionary<string, string> dataList, AsyncCallback callback, object state)
		{
			ReceiveAsyncResult asycResult = null;

			try
			{
				DataResult pData = new DataResult();

				WcfLogEvent.WriteLog(string.Format("RECEIVE REQUEST (Title : {0})"
					, title));

				pData.Title = title;
				pData.DataList = dataList;

				asycResult = new ReceiveAsyncResult(pData, callback, state);

				ThreadPool.QueueUserWorkItem(new WaitCallback(_callBackReceive), asycResult);
				WcfLogEvent.WriteLog(string.Format("EFEM SERVICE BeginRequest SUCCESS"));
			}
			catch (Exception ex)
			{
				WcfLogEvent.WriteLog("EFEM SERVICE BeginRequest EXCEPTION : " + ex.Message);
			}

			return asycResult;
		}
		public DataResult EndReceive(IAsyncResult ar)
		{
			DataResult result = null;

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
				WcfLogEvent.WriteLog("EFEM SERVICE EndRequest EXCEPTION : " + ex.Message);
			}
			return result;
		}

		public delegate void CallBackReceive(object state);

	}
}
