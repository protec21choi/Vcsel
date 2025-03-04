using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WCF_;
using FrameOfSystem3.Log;
using Define.DefineEnumProject.Socket;

namespace FrameOfSystem3.ExternalDevice.Wcf
{
	class WcfManager
	{
		#region singleton
		private static WcfManager _instance = null;
        public static WcfManager Instance
        {
			get
			{
				if (_instance == null)
				{
					_instance = new WcfManager();
				}
				return _instance;
			}
        }
		private WcfManager()
        {
			_log = LogManager.GetInstance();

			foreach (EN_WCF_INDEX en in Enum.GetValues(typeof(EN_WCF_INDEX)))
			{
				_wcfList.Add(en, new WCF((int)en, WriteLogFromWcf));
			}
        }
		#endregion /singleton

		#region field
		Dictionary<EN_WCF_INDEX, WCF> _wcfList = new Dictionary<EN_WCF_INDEX, WCF>();

		LogManager _log = null;

		const string def_DefaultIp = "127.0.0.1";
		const string def_DefaultHostPort = "1000";
		const string def_DefaultConnectPort = "1001";
		#endregion /field

		#region interface

		#region init, connection
		public void SetUse(EN_WCF_INDEX index, bool isUse)
		{
			_wcfList[index].Use = isUse;
		}
		public bool IsUse(EN_WCF_INDEX index)
		{
			return _wcfList[index].Use;
		}

		public bool Open(EN_WCF_INDEX index, string hostIp, string hostPort)
		{
			var target = _wcfList[index];
			if (target.Opened)
				return true;

			if (hostIp.Equals(string.Empty)) hostIp = def_DefaultIp;
			if (hostPort.Equals(string.Empty)) hostPort = def_DefaultHostPort;

			target.HostIp = hostIp;
			target.HostPort = hostPort;

			if (false == target.Use)
				return true;

			target.Opened = target.Open();
			WriteLog(true, string.Format("WCF OPEN (Ip : {0}, Port : {1}, Result : {2})"
				, hostIp, hostPort, target.Opened.ToString()));

			return target.Opened;
		}
		public bool IsOpen(EN_WCF_INDEX index)
		{
			if (false == _wcfList[index].Use)
				return true;

			_wcfList[index].Opened = _wcfList[index].IsOpen();

			return _wcfList[index].Opened;
		}
		public bool Close(EN_WCF_INDEX index)
		{
			if (false == _wcfList[index].Use)
				return true;

			bool result = _wcfList[index].Close();
			_wcfList[index].Opened = false;

			WriteLog(true, string.Format("WCF CLOSE (Result : {0})", result.ToString()));

			return result;
		}
        public string GetHostStatus(EN_WCF_INDEX index)
        {
            if (false == _wcfList[index].Use)
                return "Closed";

            return _wcfList[index].GetHostStatus();
        }
		public bool Connect(EN_WCF_INDEX index, string connectIp, string connectPort)
		{
			var target = _wcfList[index];
			if (target.Connected)
				return true;

			if (connectIp.Equals(string.Empty)) connectIp = def_DefaultIp;
			if (connectPort.Equals(string.Empty)) connectPort = def_DefaultConnectPort;

			target.ConnectIp = connectIp;
			target.ConnectPort = connectPort;

			if (false == target.Use)
				return true;

			bool result = false;
			if (target.Connect())
			{
				target.Connected = true;
				result = true;
			}
			else
			{
				target.Connected = false;
				result = false;
			}

			WriteLog(true, string.Format("WCF CONNECT (Ip : {0}, Port : {1}, Result : {2})"
				, connectIp, connectPort, result.ToString()));

			return result;
		}
		public bool IsConnect(EN_WCF_INDEX index)
		{
			if (false == _wcfList[index].Use)
				return true;

			_wcfList[index].Connected = _wcfList[index].IsConnect();
			return _wcfList[index].Connected;
		}
		public bool Disconnect(EN_WCF_INDEX index)
		{
			if (false == _wcfList[index].Use)
				return true;

			bool result = _wcfList[index].Disconnect();
			_wcfList[index].Connected = false;

			WriteLog(true, string.Format("WCF DISCONNECT (Result : {0})", result.ToString()));

			return result;
		}
		public string GetServerStatus(EN_WCF_INDEX index)
		{
			if (false == _wcfList[index].Use)
				return "Closed";

			return _wcfList[index].GetServerStatus();
		}
		/// <summary>
		/// 메시지를 받을 때 발생시킬 callback 등록
		/// </summary>
		public bool RegisterReceive(EN_WCF_INDEX index, DeleReceive dele)
		{
// 			if (false == _wcfList[index].Connected)
// 				return false;

			_wcfList[index].RegisterReceive(dele);
			return true;
		}
		#endregion /init, connection

		public bool DoSend(EN_WCF_INDEX index, string title, Dictionary<string, string> dataList, DeleAck callBackAck)
		{
			if (false == _wcfList[index].Use)
				return true;

			if (false == _wcfList[index].Connected)
				return false;

			bool result = _wcfList[index].DoSend(title, dataList, callBackAck);
			return result;
		}
		#endregion /interface

		#region method
		public void WriteLog(bool isSend, string message)
		{
			_log.WriteWcfLog("WCF", isSend, message);
			WcfLogEvent.WriteLog(message);
		}
		void WriteLogFromWcf(int index, string message)
		{
			string s = string.Format("{0}:{1}", index, message);
			WcfLogEvent.WriteLog(s);
		}
		#endregion /method
	}
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
