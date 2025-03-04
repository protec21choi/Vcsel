using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.ExternalDevice.Wcf;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Functional;

using Define.DefineEnumProject.Map;
using Define.DefineEnumProject.Socket;
using Define.DefineEnumProject.Mail;

namespace FrameOfSystem3.ExternalDevice
{
	public class TransportWIR
	{
		#region singleton
        private TransportWIR()
		{
			_recipe = Recipe.Recipe.GetInstance();
			_postOffice = PostOffice.GetInstance();

			_wcfManager.RegisterReceive(_myIndex, ReceiveMessage);
		}
        private static TransportWIR _instance = null;
        public static TransportWIR GetInstance()
        {
            if (_instance == null)
                _instance = new TransportWIR();

            return _instance;
        }
		#endregion /singleton

		#region field
        bool m_bInit = false;
		WcfManager _wcfManager = WcfManager.Instance;
		Recipe.Recipe _recipe = null;
		PostOffice _postOffice = null;

		TickCounter_.TickCounter _executeInterval = new TickCounter_.TickCounter();
		TickCounter_.TickCounter _connectionCheckInterval = new TickCounter_.TickCounter();

		const EN_WCF_INDEX _myIndex = EN_WCF_INDEX.PRE_EQUIPMENT;
		#endregion /field

		public void Execute()
		{
            if (m_bInit == false)
                return;

			if (false == _executeInterval.IsTickOver(true))
				return;

			_executeInterval.SetTickCount(1000);	// 1sec마다 use option 확인

            _wcfManager.SetUse(_myIndex, _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_WCF_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false));
			if (_wcfManager.IsUse(_myIndex) == false)
				return;

			if (false == _connectionCheckInterval.IsTickOver(true))
				return;

			_connectionCheckInterval.SetTickCount(60000); // 1min마다 connection 확인

			if (false == _wcfManager.IsOpen(_myIndex))
			{
				_wcfManager.Open(_myIndex
					, _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_HOST_IP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "127.0.0.1")
                    , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_HOST_PORT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "4000"));
			}

			if(false == _wcfManager.IsConnect(_myIndex))
			{
				_wcfManager.Connect(_myIndex
                       , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_TARGET_IP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "127.0.0.1")
                       , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_TARGET_PORT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "4001"));
			}
		}

		#region interface
        public bool Init()
        {
            m_bInit = true;

            return m_bInit;
        }
        public bool SendWorkResult(int nPort, Work.EN_WORK_STATUS enStatus)
        {
            string strLane = nPort == 1 ? "FRONT" : "REAR";

            string WorkResult = enStatus == Work.EN_WORK_STATUS.DONE ? "Good" : "Ng";
            return _wcfManager.DoSend(_myIndex, EN_TITLE.NotifyProcessResult.ToString(),
                new Dictionary<string, string>()
            	{
            		{ EN_DATA.ProcessResult.ToString(), WorkResult } 
            		,{ EN_DATA.Lane.ToString(), strLane } 
            	},
                (title, data, result, discription) =>
                {
                    _postOffice.SendMail(EN_SUBSCRIBER.PRE_EQUIPMENT_WCF, EN_SUBSCRIBER.TASK_TRANSFER, EN_MAIL.WCF_RESOPONE, result);
                });
        }
        public bool Open()
        {
            if (false == _wcfManager.IsOpen(_myIndex))
            {
                return _wcfManager.Open(_myIndex
                    , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_HOST_IP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "127.0.0.1")
                    , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_HOST_PORT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "4000"));
            }
            return true;
        }
       
        public bool Close()
        {
            if (_wcfManager.IsOpen(_myIndex))
            {
                return _wcfManager.Close(_myIndex);
            }
            return true;
        }
      

        public string GetHostState()
        {
            return _wcfManager.GetHostStatus(_myIndex);
        }

        public bool Connect()
        {
            if (false == _wcfManager.IsConnect(_myIndex))
            {
                _wcfManager.Connect(_myIndex
                       , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_TARGET_IP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "127.0.0.1")
                       , _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.PREEQUIPMENT_TARGET_PORT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "4001"));
            }
            return true;
        }
        public bool Disconnect()
        {
            if (_wcfManager.IsConnect(_myIndex))
            {
                return _wcfManager.Disconnect(_myIndex);
            }
            return true;
        }
        public string GetConnectState()
        {
            return _wcfManager.GetServerStatus(_myIndex);
        }

        #endregion /interface

        #region method
        void ReceiveMessage(string title, Dictionary<string, string> dataList, out string result, out string description)
		{
			EN_TITLE enTitle;
            if (false == Enum.TryParse(title, out enTitle))
            {
                result = "Ng";
                description = "Unknown title";
                return;
            }

     
			switch (enTitle)
			{
                case EN_TITLE.NotifySubjectId:
                    {
                        string[] WaferData = new string[13];
                        // dataList 순서 확인 필요
                        if (false == dataList.ContainsKey(EN_DATA.SubjectId.ToString()))
                        {
                            result = "Ng";
                            description = "Data list is wrong";
                            return;
                        }
//                         int nIndex = 0;
//                         foreach (var kpv in dataList)
//                         {
//                             WaferData[nIndex] = kpv.Value;
//                             nIndex++;
//                         }

                        WaferData[(int)EN_DATA.SubjectId] = dataList[EN_DATA.SubjectId.ToString()];
                        WaferData[(int)EN_DATA.Lane] = dataList[EN_DATA.Lane.ToString()];
                        WaferData[(int)EN_DATA.WAFER_ID] = dataList[EN_DATA.WAFER_ID.ToString()];
                        WaferData[(int)EN_DATA.LOT_ID] = dataList[EN_DATA.LOT_ID.ToString()];
                        WaferData[(int)EN_DATA.PART_NAME] = dataList[EN_DATA.PART_NAME.ToString()];
                        WaferData[(int)EN_DATA.LOT_TYPE] = dataList[EN_DATA.LOT_TYPE.ToString()];
                        WaferData[(int)EN_DATA.STEP_SEQ] = dataList[EN_DATA.STEP_SEQ.ToString()];
                        WaferData[(int)EN_DATA.WAFER_COL] = dataList[EN_DATA.WAFER_COL.ToString()];
                        WaferData[(int)EN_DATA.WAFER_ROW] = dataList[EN_DATA.WAFER_ROW.ToString()];
                        WaferData[(int)EN_DATA.ANGLE] = dataList[EN_DATA.ANGLE.ToString()];
                        WaferData[(int)EN_DATA.WAFER_MAP] = dataList[EN_DATA.WAFER_MAP.ToString()];
                        WaferData[(int)EN_DATA.COUNT_CHIPS] = dataList[EN_DATA.COUNT_CHIPS.ToString()];
                        WaferData[(int)EN_DATA.SLOT_NO] = dataList[EN_DATA.SLOT_NO.ToString()];

                        description = dataList[EN_DATA.SubjectId.ToString()];

                        EN_SUBSCRIBER subscriber = EN_SUBSCRIBER.TASK_TRANSFER;

                        result = "Good";
                        _postOffice.SendMail(EN_SUBSCRIBER.PRE_EQUIPMENT_WCF, subscriber, EN_MAIL.WCF_RECEIVE, WaferData);
                    }
                    break;
                case EN_TITLE.NotifyProcessResult:
					#region 
					{
						if (false == dataList.ContainsKey(EN_DATA.Lane.ToString()) || false == dataList.ContainsKey(EN_DATA.ProcessResult.ToString()))
						{
							result = "Ng";
							description = "Data list is wrong";
							return;
						}


						EN_SUBSCRIBER subscriber = EN_SUBSCRIBER.TASK_TRANSFER;


						result = "Good";
						description = "";
                        _postOffice.SendMail(EN_SUBSCRIBER.PRE_EQUIPMENT_WCF, subscriber, EN_MAIL.WCF_RESOPONE, dataList[EN_DATA.ProcessResult.ToString()]);
						return;
					}
					#endregion

				default:
					result = "Ng";
					description = "Wrong message receive";
					return;
			}
		}
		#endregion /method

		#region enum
		public enum EN_TITLE
		{
			// send
			NotifySubjectId,

			// receive
			NotifyProcessResult,
		}
		public enum EN_DATA
		{
			SubjectId = 0,
			Lane,
            WAFER_ID,
            LOT_ID,
            PART_NAME,
            LOT_TYPE,
            STEP_SEQ,
            WAFER_COL,
            WAFER_ROW,
            ANGLE,
            WAFER_MAP,
            COUNT_CHIPS,
            SLOT_NO,
			ProcessResult,
		}
		#endregion /enum
	}
}
