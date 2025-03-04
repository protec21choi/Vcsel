using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.WCF_;
using FrameOfSystem3.Functional;

using Define.DefineEnumProject.Map;
using Define.DefineEnumBase.Log;
using Define.DefineEnumProject.Mail;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.Log;

namespace FrameOfSystem3.ExternalDevice
{
	class EFEMManager
	{
		#region <ENUM>
		public enum EN_EFEM_MESSAGE
		{
			APPROACH_LOADING,
			APPROACH_UNLOADING_GOOD,
			APPROACH_UNLOADING_NG,

			ACTION_LOADING,
			ACTION_UNLOADING_GOOD,
			ACTION_UNLOADING_NG,

			CONFIRM_LOADING,
			CONFIRM_UNLOADING_GOOD,
			CONFIRM_UNLOADING_NG,

			CONFIRM_FAILED,
		}
		public enum EN_EFEM_ACK
		{
			BUSY = 0,
			NACK = 1,
			ACK = 2,
		}

		public enum EN_SECSGEM_PARAMETER_TYPE
		{
			VID,
			ECID,
			WAFER_INFO_IR_F,
			WAFER_INFO_IR_R,
		}
		public enum EN_SECSGEM_EVENT_TYPE
		{
			CEID,
			ALARM,
			RCMD,
			RMS,
		}

		public enum EN_VID
		{
			LOTID								= 1000,
			PARTID								= 1001,
			STEPSEQ								= 1002,
			LOTTYPE								= 1003,
			RECIPEID							= 1004,

			IR_F_WAFER_ID = 2030,
			IR_F_CHIP_QTY = 2031,
			IR_F_GOOD_QTY = 2032,
			IR_F_WAFER_ROW = 2033,
			IR_F_WAFER_COL = 2034,

			IR_R_WAFER_ID = 2040,
			IR_R_CHIP_QTY = 2041,
			IR_R_GOOD_QTY = 2042,
			IR_R_WAFER_ROW = 2043,
			IR_R_WAFER_COL = 2044,

			FLUX_ID_SBA							= 3000,
			BALL_ID_SBA							= 3001,
			FLUX_MASK_ID_SBA					= 3002,
			BALL_MASK_ID_SBA					= 3003,
			FLUX_ID_IR_LEFT						= 3004,
			FLUX_ID_IR_RIGHT					= 3005,
			BALL_ID_IR_LEFT						= 3006,
			BALL_ID_IR_RIGHT					= 3007,

			REPAIR_TOOL_ID_LEFT					= 3010,
			REPAIR_TOOL_ID_RIGHT				= 3011,
			STAMP_TOOL_ID_LEFT					= 3012,
			STAMP_TOOL_ID_RIGHT					= 3013,
			REMOVE_TOOL_ID_LEFT					= 3014,
			REMOVE_TOOL_ID_RIGHT				= 3015,

			MATERIAL_CHANGE_TYPE				= 3020,

			FLUX_MASK_USAGE_COUNT				= 3100,
			BALL_MASK_USAGE_COUNT				= 3101,
			REPAIR_TOOL_USAGE_COUNT_LEFT		= 3102,
			REPAIR_TOOL_USAGE_COUNT_RIGHT		= 3103,
			STAMP_TOOL_USAGE_COUNT_LEFT			= 3104,
			STAMP_TOOL_USAGE_COUNT_RIGHT		= 3105,
			REMOVE_TOOL_USAGE_COUNT_LEFT		= 3106,
			REMOVE_TOOL_USAGE_COUNT_RIGHT		= 3107,

			EFEM_MAIN_CDA_PRESSURE				= 4000,
			EFEM_MAIN_VACUUM_PRESSURE			= 4001,
			EFEM_ROBOT_VACUUM_PRESSURE			= 4002,
			EFEM_IONIZER_PRESSURE				= 4003,
			EFEM_IONIZER_FLOW_METER				= 4004,
			EFEM_FFU_SPEED_1					= 4005,
			EFEM_FFU_SPEED_2					= 4006,
			EFEM_FFU_SPEED_3					= 4007,
			EFEM_FFU_SPEED_4					= 4008,
			REWORK_EFEM_MAIN_CDA_PRESSURE		= 4010,
			REWORK_EFEM_MAIN_VACUUM_PRESSURE	= 4011,
			REWORK_EFEM_ROBOT_VACUUM_PRESSURE	= 4012,
			REWORK_IONIZER_PRESSURE				= 4013,
			REWORK_IONIZER_FLOW_METER			= 4014,
			REWORK_EFEM_FFU_SPEED_1				= 4015,
			REWORK_EFEM_FFU_SPEED_2				= 4016,
			REWORK_EFEM_FFU_SPEED_3				= 4017,
			REWORK_EFEM_FFU_SPEED_4				= 4018,
			SBA_FFU_1							= 4100,
			SBA_FFU_2							= 4101,
			SBA_FFU_3							= 4102,
			SQUEEGEE_PRESSURE					= 4103,
			ELECTRIC_PRESS_MODULE				= 4104,
			SBA_TEMP_METER						= 4105,
			SBA_HUMIDITY_METER					= 4106,
			SBA_TRANS_TEMP_METER				= 4107,
			SBA_N2_FLOW							= 4108,
			SBA_BALL_HEAD_GAP					= 4109,
			IR_IONIZER_FRONT_LOAD						= 4200,
			IR_IONIZER_REAR_LOAD						= 4201,
			IR_IONIZER_FRONT_UNLOAD						= 4202,
			IR_IONIZER_REAR_UNLOAD						= 4203,
			IR_STAGE_VACUUM_FRONT				= 4204,
			IR_STAGE_VACUUM_REAR				= 4205,
			IR_FFU								= 4206,
			IR_IONIZER_FRONT_REWORK = 4207,
			IR_IONIZER_REAR_REWORK = 4208,	
			PRINT_WORK_SQUEEGEE_SPEED			= 4300,
			PRINT_WORK_SQUEEGEE_HEIGHT			= 4301,
			PRINT_WORK_SQUEEGEE_PRESSURE		= 4302,
			BALLATTACH_WORK_HEAD_SPEED			= 4303,
			BALLATTACH_WORK_HEAD_GAP			= 4304,
			BALLATTACH_WORK_HEAD_N2DLOW			= 4305,
			BALLATTACH_WORK_HEAD_INSIDEFLOW		= 4306,
			IR_FLOW_LEFT_ATTACH					= 4350,
			IR_FLOW_LEFT_REMOVE					= 4351,
			IR_FLOW_RIGHT_ATTACH				= 4352,
			IR_FLOW_RIGHT_REMOVE				= 4353,
			IR_EMPTY_FLOW_LEFT_ATTACH			= 4354,
			IR_EMPTY_FLOW_LEFT_REMOVE			= 4355,
			IR_EMPTY_FLOW_RIGHT_ATTACH			= 4356,
			IR_EMPTY_FLOW_RIGHT_REMOVE			= 4357,
			IR_REWORK_COUNT_TOTAL				= 4358,
			IR_REWORK_COUNT_GOOD				= 4359,
			IR_REWORK_COUNT_FAIL				= 4360,
		}
		public enum EN_CEID
		{
			START										= 102,
			STOP										= 103,
			PORT_STATUS_LOAD							= 110,
			PORT_STATUS_UNLOAD							= 111,
			RFID_READ									= 120,
			LOT_INFO_REQ								= 130,
			SLOT_MAP_INFO_REQ							= 131,
			SLOT_MAP_UPLOAD								= 132,
			RECIPE_DOWNLOAD								= 140,
			RECIPE_FILE_CHECK							= 141,
			RECIPE_UPLOAD								= 142,
			TRACK_IN									= 150,
			TRACK_OUT									= 151,
			PROCESS_START								= 153,
			PROCESS_END									= 154,
			WORK_START									= 155,
			WORK_END									= 156,
			ALIGN_START									= 157,
			ALIGN_END									= 158,
			SBA_START									= 160,
			SBA_END										= 161,
			FLUX_START									= 162,
			FLUX_END									= 163,
			ATTACH_START								= 164,
			ATTACH_END									= 165,
			FRONT_IR_START								= 170,
			FRONT_IR_END								= 171,
			FRONT_INSPECTION_START						= 172,
			FRONT_INSPECTION_END						= 173,
			FRONT_REPAIR_START							= 174,
			FRONT_REPAIR_END							= 175,
			REAR_IR_START								= 180,
			REAR_IR_END									= 181,
			REAR_INSPECTION_START						= 182,
			REAR_INSPECTION_END							= 183,
			REAR_REPAIR_START							= 184,
			REAR_REPAIR_END								= 185,
			SPLIT										= 190,
			SCRAP										= 191,
			MATERIAL_CHANGE_FLUX_SBA					= 200,
			MATERIAL_CHANGE_BALL_SBA					= 201,
			MATERIAL_CHANGE_FLUX_MASK_SBA				= 202,
			MATERIAL_CHANGE_BALL_MASK_SBA				= 203,
			LIFECYCLE_CHECK_FLUX_SBA					= 210,
			LIFECYCLE_CHECK_BALL_SBA					= 211,
			LIFECYCLE_CHECK_FLUX_MASK_SBA				= 212,
			LIFECYCLE_CHECK_BALL_MASK_SBA				= 213,
			MATERIAL_CHANGE_FLUX_IR_LEFT				= 220,
			MATERIAL_CHANGE_FLUX_IR_RIGHT				= 221,
			MATERIAL_CHANGE_BALL_IR_LEFT				= 222,
			MATERIAL_CHANGE_BALL_IR_RIGHT				= 223,
			MATERIAL_CHANGE_REPAIR_TOOL_IR_LEFT			= 224,
			MATERIAL_CHANGE_REPAIR_TOOL_IR_RIGHT		= 225,
			MATERIAL_CHANGE_STAMP_TOOL_IR_LEFT			= 226,
			MATERIAL_CHANGE_STAMP_TOOL_IR_RIGHT			= 227,
			MATERIAL_CHANGE_REMOVE_TOOL_IR_LEFT			= 228,
			MATERIAL_CHANGE_REMOVE_TOOL_IR_RIGHT		= 229,
			LIFECYCLE_CHECK_FLUX_IR_LEFT				= 230,
			LIFECYCLE_CHECK_FLUX_IR_RIGHT				= 231,
			LIFECYCLE_CHECK_BALL_IR_LEFT				= 232,
			LIFECYCLE_CHECK_BALL_IR_RIGHT				= 233,
			LIFECYCLE_CHECK_REPAIR_TOOL_IR_LEFT			= 234,
			LIFECYCLE_CHECK_REPAIR_TOOL_IR_RIGHT		= 235,
			LIFECYCLE_CHECK_STAMP_TOOL_IR_LEFT			= 236,
			LIFECYCLE_CHECK_STAMP_TOOL_IR_RIGHT			= 237,
			LIFECYCLE_CHECK_REMOVE_TOOL_IR_LEFT			= 238,
			LIFECYCLE_CHECK_REMOVE_TOOL_IR_RIGHT		= 239,
			REWORK_ALIGN_START							= 250,
			REWORK_ALIGN_END							= 251,
		}
		public enum EN_RCMD
		{
			STOP,	// Product Stop (-> Finish)
			RETURN,	// 즉시 Unloading (당장 할 필요는 없음)
		}
		public enum EN_RMS
		{
			DOWNLOAD_RECIPE,
			SELECT_RECIPE,
			UPLOAD_RECIPE,		// 2022.05.31 by junho [ADD] Recipe upload 요청
		}
		#endregion </ENUM>

		#region <CONSTANTS>
		private const string PORT_FRONT = "IR_F";
		private const string PORT_REAR = "IR_R";
		#endregion </CONSTANTS>

		#region <CONSTRUCTOR>
		private static EFEMManager _instance = null;
        public static EFEMManager GetInstance()
        {
			if (_instance == null)
            {
				_instance = new EFEMManager();
            }
			return _instance;
        }
		private EFEMManager()
        {
			_recipe = Recipe.Recipe.GetInstance();
			_wcf = new WCF();
			_log = LogManager.GetInstance();

// 			foreach(EN_HEAD_SIDE side in Enum.GetValues(typeof(EN_HEAD_SIDE)))
// 			{
// 				foreach (Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE nozzle in Enum.GetValues(typeof(Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE)))
// 				{
// 					if (nozzle == Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE.FLUX)
// 						continue;
// 
// 					_nozzleEmptyFlow.Add(new SideAndNozzle(side, nozzle), 0.0);
// 				}
// 			}
        }
		#endregion </CONSTRUCTOR>

		#region <FIELD>
		private bool _initialize = false;
		private bool _use = false;

		private bool _open = false;
		private bool _connect = false;

		private Recipe.Recipe _recipe = null;
		private TickCounter_.TickCounter _timeCheck = new TickCounter_.TickCounter();

		private string _efemIP = string.Empty;
		private string _efemPort = string.Empty;
		private string _myIP = string.Empty;
		private string _myPort = string.Empty;

		private WCF _wcf = null;

		private TickCounter_.TickCounter _timeUpdateFDC = new TickCounter_.TickCounter();

		private LogManager _log = null;

		//Dictionary<SideAndNozzle, double> _nozzleEmptyFlow = new Dictionary<SideAndNozzle, double>();
		#endregion </FIELD>

		#region <PROPERTY>
		public bool Use { get { return _use; } }
		#endregion </PROPERTY>

		public void Execute()
		{
			if (false == _initialize)
				return;

		//	_use = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_USE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, false);
			if (false == _use)
				return;

			if (false == _timeCheck.IsTickOver(true))
				return;

			if (false == IsOpen())
				Open();

			if(false == IsConnect())
				Connect();

			_timeCheck.SetTickCount(60000);	// 60sec에 한번씩 확인
		}

		#region <INTERFACE>
		public bool Init()
		{
			_initialize = true;
		//	_use = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_USE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, false);

			return true;
		}

		public bool Open()
		{
			if (_open) return true;

            string ip = "127.0.0.1";
            string port = "1000";

//             _myIP = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_HOST_IP.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, ip);
// 			_myPort = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_HOST_PORT.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, port);

            if (_myIP.Equals(string.Empty)) _myIP = ip;
            if (_myPort.Equals(string.Empty)) _myPort = port;

			if (false == _use)
				return true;

			_open = _wcf.Open(_myIP, _myPort);

			WriteLog(true, string.Format("WCF OPEN (Ip : {0}, Port : {1}, Result : {2})", _myIP, _myPort, _open.ToString()));

			return _open;
		}
		public bool IsOpen()
		{
			if (false == _use)
				return true;

			_open = _wcf.IsOpen();

			return _open;
		}
		public bool Close()
		{
			if (false == _use)
				return true;

			bool result = _wcf.Close();
			_open = false;

			WriteLog(true, string.Format("WCF CLOSE (Result : {0})", result.ToString()));

			return result;
		}
		public bool Connect()
		{
			if (_connect)
				return true;

			string ip = "127.0.0.1";
			string port = "1000";

// 			_efemIP = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_TARGET_IP.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, "127.0.0.1");
// 			_efemPort = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_TARGET_PORT.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, "4001");

			if (_efemIP.Equals(string.Empty)) _efemIP = ip;
			if (_efemPort.Equals(string.Empty)) _efemPort = port;

			if (false == _use)
				return true;

			bool result = false;
			if(_wcf.Connect(_efemIP, _efemPort))
			{
				_wcf.RegisterReceiveRequest(CallBackReceiveRequest);
				_wcf.RegisterReceiveResponse(CallBackReceiveResponse);
				_wcf.RegisterReceiveSecsGemParameter(CallBackReceiveSecsGemParameter);
				_wcf.RegisterReceiveSecsGemEvent(CallBackReceiveSecsGemEvent);
				_connect = true;

				//UpdateECID_ALL();
				result = true;
			}
			else
			{
				_connect = false;
				result = false;
			}

			WriteLog(true, string.Format("WCF CONNECT (Ip : {0}, Port : {1}, Result : {2})", _efemIP, _efemPort, result.ToString()));

			return result;
		}
		public bool IsConnect()
		{
			if (false == _use)
				return true;

			_connect = _wcf.IsConnect();
			return _connect;
		}
		public bool Disconnect()
		{
			if (false == _use)
				return true;

			bool result = _wcf.Disconnect();
			_connect = false;

			WriteLog(true, string.Format("WCF DISCONNECT (Result : {0})", result.ToString()));

			return result;
		}
		public string GetServerStatus()
		{
			if(false == _use)
				return "Closed";

			return _wcf.GetServerStatus();
		}
		public bool DoRequest(/*EN_WORK_ZONE zone,*/ EN_EFEM_MESSAGE efemMessage)
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			string portName = string.Empty;
// 			switch (zone)
// 			{
// 				case EN_WORK_ZONE.FRONT: portName = PORT_FRONT; break;
// 				case EN_WORK_ZONE.REAR: portName = PORT_REAR; break;
// 				default: return false;
// 			}

			bool result = _wcf.DoRequest(portName, efemMessage.ToString(), CallBackRequestAck);

			// 2022.06.21 by junho [ADD] Approach 관련 Message는 Logging 하지 않도록 변경
            bool isLogging = true;
            switch(efemMessage)
            {
                case EN_EFEM_MESSAGE.APPROACH_LOADING:
                case EN_EFEM_MESSAGE.APPROACH_UNLOADING_GOOD:
                case EN_EFEM_MESSAGE.APPROACH_UNLOADING_NG:
                    isLogging = false;
                    break;
            }

            if (isLogging)
            {
                WriteLog(true, string.Format("DO REQUEST (PortName : {0}, Message : {1}, Result : {2})"
                    , portName, efemMessage.ToString(), result.ToString()));
            }

			return result;
		}

        //[FROM HERE]gem 추후에 다시 보기
		#region SecsGem Parameter

// 		public bool UpdateVID(Dictionary<EN_VID, string> updateList, bool isLogging = true)
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
// 			int vidCount = 0;
// 			Dictionary<string, string> sendMessage = new Dictionary<string,string>();
// 			foreach(KeyValuePair<EN_VID, string> kvp in updateList)
// 			{
// 				sendMessage.Add(((int)kvp.Key).ToString(), kvp.Value);
// 				++vidCount;
// 			}
// 
// 			bool result = _wcf.DoSecsGemParameter(EN_SECSGEM_PARAMETER_TYPE.VID.ToString(), sendMessage, CallBackSecsGemParameterAck);
// 
// 			#region write log
// 			if (isLogging)
// 			{
// 				WriteLog(true, string.Format("UPDATE VID\tCount : {0}, Result : {1}"
// 					, vidCount.ToString(), result.ToString()));
// 			}
// 			#endregion
// 
// 			return result;
// 		}
// 
// 		public bool UpdateECID(EN_RECIPE_TYPE type, string key, string value)
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
// 			int ecidNo;
// 			if (false == int.TryParse(key, out ecidNo))
// 				return false;
// 
// 			switch(type)
// 			{
// 				case EN_RECIPE_TYPE.COMMON: break;
// 				case EN_RECIPE_TYPE.EQUIPMENT:
// 					ecidNo += 1000;
// 					break;
// 				default: return false;
// 			}
// 
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 			sendMessage.Add(ecidNo.ToString(), value);
// 
// 			bool result = _wcf.DoSecsGemParameter(EN_SECSGEM_PARAMETER_TYPE.ECID.ToString(), sendMessage, CallBackSecsGemParameterAck);
// 
// 			#region write log
// 			WriteLog(true, string.Format("UPDATE ECID\tCount : {0}, Result : {1}"
// 				, sendMessage.Count.ToString(), result.ToString()));
// 			#endregion
// 
// 			return result;
// 		}
// 		public bool UpdateECID_ALL()
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
// 			int ecidCount = 0;
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 			foreach(PARAM_COMMON common in Enum.GetValues(typeof(PARAM_COMMON)))
// 			{
// 				string value = _recipe.GetValue(EN_RECIPE_TYPE.COMMON, common.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "");
// 				sendMessage.Add(((int)common).ToString(), value);
// 				++ecidCount;
// 			}
// 
// 			foreach (PARAM_EQUIPMENT equipment in Enum.GetValues(typeof(PARAM_EQUIPMENT)))
// 			{
// 				string value = _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, equipment.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "");
// 				sendMessage.Add(((int)equipment + 1000).ToString(), value);		// EQUIPMENT ITEM은 1000을 더해준다.
// 				++ecidCount;
// 			}
// 
// 			bool result = _wcf.DoSecsGemParameter(EN_SECSGEM_PARAMETER_TYPE.ECID.ToString(), sendMessage, CallBackSecsGemParameterAck);
// 
// 			#region write log
// 			WriteLog(true, string.Format("UPDATE ECID\tCount : {0}, Result : {1}"
// 				, ecidCount.ToString(), result.ToString()));
// 			#endregion
// 
// 			return result;
// 		}
// 
// 		public bool DoRequestWaferInfo(EN_WORK_ZONE zone)
// 		{
// 			EN_SECSGEM_PARAMETER_TYPE type;
// 			switch(zone)
// 			{
// 				case EN_WORK_ZONE.FRONT: type = EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO_IR_F; break;
// 				case EN_WORK_ZONE.REAR: type = EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO_IR_R; break;
// 				default: return false;
// 			}
// 
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 			foreach (EN_WAFER_INFO en in Enum.GetValues(typeof(EN_WAFER_INFO)))
// 			{
// 				sendMessage.Add(en.ToString(), "");
// 			}
// 
// 			bool result = _wcf.DoSecsGemParameter(type.ToString(), sendMessage, CallBackSecsGemParameterAck);
// 
// 			#region write log
// 			WriteLog(true, string.Format("REQUEST_WAFER_INFO"));
// 			#endregion
// 
// 			return true;
// 		}
		#endregion

		#region SecsGem Event

// 		public bool SecsGemSendEventEx(EN_CEID ceid, Dictionary<EN_VID, string> vidList)
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 
// 			int vidCount = 0;
// 			if (vidList != null)
// 			{
// 				foreach (KeyValuePair<EN_VID, string> kvp in vidList)
// 				{
// 					sendMessage.Add(kvp.Key.ToString(), kvp.Value);
// 					++vidCount;
// 				}
// 			}
// 
// 			int ceidNo = (int)ceid;
// 
// 			bool result = _wcf.DoSecsGemSendEvent(EN_SECSGEM_EVENT_TYPE.CEID.ToString(), ceidNo.ToString(), sendMessage, CallBackSecsGemEventAck);
// 			WriteLog(true, string.Format("SEND EVENT\tCEID : {0}, Count : {1}, Result : {2}"
// 				, ceidNo.ToString(), vidCount.ToString(), result.ToString()));
// 
// 			return result;
// 		}
// 		public bool UpdateALID(int alarmCode, EN_ALM_TYPE type)
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 			switch(type)
// 			{
// 				case EN_ALM_TYPE.OCCURRED:
// 					sendMessage.Add("STATUS", "1");
// 					break;
// 				case EN_ALM_TYPE.RELEASED:
// 					sendMessage.Add("STATUS", "0");
// 					break;
// 			}
// 
// 			int alid = alarmCode + 3000000;
// 
// 			bool result = _wcf.DoSecsGemSendEvent(EN_SECSGEM_EVENT_TYPE.ALARM.ToString(), alid.ToString(), sendMessage, CallBackSecsGemEventAck);
// 
// 			return result;
// 		}
		#endregion

// 		public void UpdateNozzleEmptyFlow(EN_HEAD_SIDE side, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE nozzle, double flow)
// 		{
// 			var key = new SideAndNozzle(side, nozzle);
// 			if(_nozzleEmptyFlow.ContainsKey(key))
// 				_nozzleEmptyFlow[key] = flow;
// 			else
// 				_nozzleEmptyFlow.Add(key, flow);
// 		}
		#endregion </INTERFACE>

		#region <SECSGEM EVENT>
// 		public bool SecsGem_UpdateFDC()
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
// 			if (false ==_timeUpdateFDC.IsTickOver(true))
// 				return true;
// 
//             uint interval = (uint)_recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.EFEM_FDC_INTERVAL.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 5000);
//             if (interval < 100) interval = 100;
//             _timeUpdateFDC.SetTickCount(interval);
// 
// 			Dictionary<EN_VID, string> vidList = new Dictionary<EN_VID, string>();
// 			string valueString = "0";
// 			double valueDouble = 0.0;
// 			int valueInt = 0;
// 
// 			Tool.WorkTool workTool = Tool.WorkTool.GetInstance();
// 			AnalogIO_.AnalogIO analogIo = AnalogIO_.AnalogIO.GetInstance();
// 
// 			#region Tool 사용 횟수
// 			workTool.GetMonitoringData((int)Define.DefineEnumProject.Tool.EN_WORK_TOOL.LEFT_ATTACH_NOZZLE, Tool.EN_TOOL_MONITORING.USED_COUNT, ref valueString);
// 			vidList.Add(EN_VID.REPAIR_TOOL_USAGE_COUNT_LEFT, valueString);
// 			valueString = "0";
// 
// 			workTool.GetMonitoringData((int)Define.DefineEnumProject.Tool.EN_WORK_TOOL.RIGHT_ATTACH_NOZZLE, Tool.EN_TOOL_MONITORING.USED_COUNT, ref valueString);
// 			vidList.Add(EN_VID.REPAIR_TOOL_USAGE_COUNT_RIGHT, valueString);
// 			valueString = "0";
// 
// 			workTool.GetMonitoringData((int)Define.DefineEnumProject.Tool.EN_WORK_TOOL.LEFT_FLUX_NOZZLE, Tool.EN_TOOL_MONITORING.USED_COUNT, ref valueString);
// 			vidList.Add(EN_VID.STAMP_TOOL_USAGE_COUNT_LEFT, valueString);
// 			valueString = "0";
// 
// 			workTool.GetMonitoringData((int)Define.DefineEnumProject.Tool.EN_WORK_TOOL.RIGHT_FLUX_NOZZLE, Tool.EN_TOOL_MONITORING.USED_COUNT, ref valueString);
// 			vidList.Add(EN_VID.STAMP_TOOL_USAGE_COUNT_RIGHT, valueString);
// 			valueString = "0";
// 
// 			workTool.GetMonitoringData((int)Define.DefineEnumProject.Tool.EN_WORK_TOOL.LEFT_REMOVE_NOZZLE, Tool.EN_TOOL_MONITORING.USED_COUNT, ref valueString);
// 			vidList.Add(EN_VID.REMOVE_TOOL_USAGE_COUNT_LEFT, valueString);
// 			valueString = "0";
// 
// 			workTool.GetMonitoringData((int)Define.DefineEnumProject.Tool.EN_WORK_TOOL.RIGHT_REMOVE_NOZZLE, Tool.EN_TOOL_MONITORING.USED_COUNT, ref valueString);
// 			vidList.Add(EN_VID.REMOVE_TOOL_USAGE_COUNT_RIGHT, valueString);
// 			valueString = "0";
// 			#endregion
// 
// 			#region 이오나이저
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.IONIZER_AIR_FLOW_1);
// 			vidList.Add(EN_VID.IR_IONIZER_FRONT_LOAD, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.IONIZER_AIR_FLOW_2);
// 			vidList.Add(EN_VID.IR_IONIZER_REAR_LOAD, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.IONIZER_AIR_FLOW_3);
// 			vidList.Add(EN_VID.IR_IONIZER_FRONT_UNLOAD, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.IONIZER_AIR_FLOW_4);
// 			vidList.Add(EN_VID.IR_IONIZER_REAR_UNLOAD, valueDouble.ToString());
// 
// 			// 2023.05.12 by junho [ADD] ionizer FDC update 누락분 추가
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.IONIZER_AIR_FLOW_5);
// 			vidList.Add(EN_VID.IR_IONIZER_FRONT_REWORK, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.IONIZER_AIR_FLOW_6);
// 			vidList.Add(EN_VID.IR_IONIZER_REAR_REWORK, valueDouble.ToString());
// 			#endregion
// 
// 			#region Stage vacuum
// 			// 2023.08.11 by junho [MOD] FDC 항목 변경 : Stage main > area
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.F_TABLE_AREA_VACUUM_PRESSURE);
// 			vidList.Add(EN_VID.IR_STAGE_VACUUM_FRONT, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.R_TABLE_AREA_VACUUM_PRESSURE);
// 			vidList.Add(EN_VID.IR_STAGE_VACUUM_REAR, valueDouble.ToString());
// 			#endregion
// 
// 			#region FFU
// 			valueString = _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.FFU_1_TARGET_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "0");
// 			vidList.Add(EN_VID.IR_FFU, valueString);
// 			#endregion
// 
// 			#region Head Air Flow
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.L_REWORK_AIR_FLOW);
// 			vidList.Add(EN_VID.IR_FLOW_LEFT_ATTACH, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.L_REMOVE_AIR_FLOW);
// 			vidList.Add(EN_VID.IR_FLOW_LEFT_REMOVE, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.R_REWORK_AIR_FLOW);
// 			vidList.Add(EN_VID.IR_FLOW_RIGHT_ATTACH, valueDouble.ToString());
// 
// 			valueDouble = analogIo.ReadInputValue((int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.R_REMOVE_AIR_FLOW);
// 			vidList.Add(EN_VID.IR_FLOW_RIGHT_REMOVE, valueDouble.ToString());
// 
// 			valueDouble = _nozzleEmptyFlow[new SideAndNozzle(EN_HEAD_SIDE.LEFT, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE.ATTACH)];
// 			vidList.Add(EN_VID.IR_EMPTY_FLOW_LEFT_ATTACH, valueDouble.ToString());
// 			valueDouble = _nozzleEmptyFlow[new SideAndNozzle(EN_HEAD_SIDE.LEFT, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE.REMOVE)];
// 			vidList.Add(EN_VID.IR_EMPTY_FLOW_LEFT_REMOVE, valueDouble.ToString());
// 			valueDouble = _nozzleEmptyFlow[new SideAndNozzle(EN_HEAD_SIDE.RIGHT, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE.ATTACH)];
// 			vidList.Add(EN_VID.IR_EMPTY_FLOW_RIGHT_ATTACH, valueDouble.ToString());
// 			valueDouble = _nozzleEmptyFlow[new SideAndNozzle(EN_HEAD_SIDE.RIGHT, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE.REMOVE)];
// 			vidList.Add(EN_VID.IR_EMPTY_FLOW_RIGHT_REMOVE, valueDouble.ToString());
// 			#endregion
// 			
// 			var workInfo = Work.WorkInformation.GetInstance();
// 			#region wafer info
// 			var waferInfo = workInfo.GetWaferInfo(EN_WORK_ZONE.FRONT);
// 			Func<EN_WAFER_INFO, int> GetWaferInfoIntager = (info) =>
// 			#region 
// 			{
// 				int result;
// 				string str = waferInfo.ContainsKey(info) ? waferInfo[info] : "0";
// 				if(false == int.TryParse(str, out result)) result = 0;
// 				return result;
// 			};
// 			#endregion
// 
// 			valueString = waferInfo.ContainsKey(EN_WAFER_INFO.WAFER_ID) ? waferInfo[EN_WAFER_INFO.WAFER_ID] : "";
// 			vidList.Add(EN_VID.IR_F_WAFER_ID, valueString != "" ? valueString : workInfo.GetSubjectId(EN_WORK_ZONE.FRONT));
// 
// 			valueInt = GetWaferInfoIntager(EN_WAFER_INFO.COUNT_CHIPS);
// 			vidList.Add(EN_VID.IR_F_CHIP_QTY, valueInt.ToString());
// 
// 			valueInt = workInfo.Summary_GetReworkCount_Ok(EN_WORK_ZONE.FRONT);
// 			vidList.Add(EN_VID.IR_F_GOOD_QTY, valueInt.ToString());
// 
// 			valueInt = GetWaferInfoIntager(EN_WAFER_INFO.WAFER_ROW);
// 			vidList.Add(EN_VID.IR_F_WAFER_ROW, valueInt.ToString());
// 
// 			valueInt = GetWaferInfoIntager(EN_WAFER_INFO.WAFER_COL);
// 			vidList.Add(EN_VID.IR_F_WAFER_COL, valueInt.ToString());
// 
// 			waferInfo = workInfo.GetWaferInfo(EN_WORK_ZONE.REAR);
// 			valueString = waferInfo.ContainsKey(EN_WAFER_INFO.WAFER_ID) ? waferInfo[EN_WAFER_INFO.WAFER_ID] : "";
// 			vidList.Add(EN_VID.IR_R_WAFER_ID, valueString != "" ? valueString : workInfo.GetSubjectId(EN_WORK_ZONE.REAR));
// 
// 			valueInt = GetWaferInfoIntager(EN_WAFER_INFO.COUNT_CHIPS);
// 			vidList.Add(EN_VID.IR_R_CHIP_QTY, valueInt.ToString());
// 
// 			valueInt = workInfo.Summary_GetReworkCount_Ok(EN_WORK_ZONE.FRONT);
// 			vidList.Add(EN_VID.IR_R_GOOD_QTY, valueInt.ToString());
// 
// 			valueInt = GetWaferInfoIntager(EN_WAFER_INFO.WAFER_ROW);
// 			vidList.Add(EN_VID.IR_R_WAFER_ROW, valueInt.ToString());
// 
// 			valueInt = GetWaferInfoIntager(EN_WAFER_INFO.WAFER_COL);
// 			vidList.Add(EN_VID.IR_R_WAFER_COL, valueInt.ToString());
// 			#endregion wafer info
// 			
// 			#region Work count
// 			valueInt = workInfo.Summary_GetReworkCount_Total();
// 			vidList.Add(EN_VID.IR_REWORK_COUNT_TOTAL, valueInt.ToString());
// 
// 			valueInt = workInfo.Summary_GetReworkCount_Ok();
// 			vidList.Add(EN_VID.IR_REWORK_COUNT_GOOD, valueInt.ToString());
// 
// 			valueInt = workInfo.Summary_GetReworkCount_Ng();
// 			vidList.Add(EN_VID.IR_REWORK_COUNT_FAIL, valueInt.ToString());
// 			#endregion
// 
// 			bool isFdcLogging = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_FDC_LOGGING.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
// 			if (isFdcLogging) WriteLog(true, string.Format("UPDATE FDC VID"));
// 
// 			return UpdateVID(vidList, isFdcLogging);
// 		}

		#region <미구현 Event>
		public bool SecsGem_MATERIAL_CHANGE_FLUX_IR_LEFT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_FLUX_IR_RIGHT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_BALL_IR_LEFT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_BALL_IR_RIGHT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_REPAIR_TOOL_IR_LEFT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_REPAIR_TOOL_IR_RIGHT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_STAMP_TOOL_IR_LEFT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_STAMP_TOOL_IR_RIGHT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_REMOVE_TOOL_IR_LEFT() { return true; }
		public bool SecsGem_MATERIAL_CHANGE_REMOVE_TOOL_IR_RIGHT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_FLUX_IR_LEFT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_FLUX_IR_RIGHT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_BALL_IR_LEFT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_BALL_IR_RIGHT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_REPAIR_TOOL_IR_LEFT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_REPAIR_TOOL_IR_RIGHT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_STAMP_TOOL_IR_LEFT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_STAMP_TOOL_IR_RIGHT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_REMOVE_TOOL_IR_LEFT() { return true; }
		public bool SecsGem_LIFECYCLE_CHECK_REMOVE_TOOL_IR_RIGHT() { return true; }
		#endregion </미구현 Event>

		#endregion </SECSGEM EVENT>

		#region <RECEIVE METHOD>
// 		private void ReceiveRCMD(string sFunction, Dictionary<string, string> dataList, out string result, out string description)
// 		{
// 			result = "ACK";
// 			description = "No_Problem";
// 
// 			EN_RCMD rcmd;
// 			if (false == Enum.TryParse(sFunction, out rcmd))
// 			{
// 				result = "NACK";
// 				description = "Can_not_parse_sFunction";
// 				return;
// 			}
// 
// 			switch(rcmd)
// 			{
// 				case EN_RCMD.STOP:
// 					Task.TaskOperator.GetInstance().SetOperation(RunningMain_.OPERATION_EQUIPMENT.STOP);
// 					break;
// 			}
// 		}
// 		private void ReceiveWaferInfo(EN_WORK_ZONE zone, Dictionary<string, string> dataList, bool isSuccess)
// 		{
// 			Work.UIComunicationEvent.Inform_ToTask(
// 				Work.UIComunicationEvent.EN_REQUEST_FROM_UI.SECSGEM_RECEIVE_WAFER_INFO
// 				, Define.DefineEnumProject.Task.EN_TASK_LIST.Global.ToString()
// 				, new object[] { zone, dataList, isSuccess }
// 				);
// 		}
// 		public void ReceiveRMS(string sFunction, Dictionary<string, string> dataList, out string result, out string description)
// 		{
// 			result = "ACK";
// 			description = "No_Problem";
// 
// 			EN_RMS rms;
// 			if (false == Enum.TryParse(sFunction, out rms))
// 			{
// 				result = "NACK";
// 				description = "Can_not_parse_sFunction";
// 				return;
// 			}
// 
// 			switch (rms)
// 			{
// 				case EN_RMS.DOWNLOAD_RECIPE:
// 					if(false == dataList.ContainsKey("PATH") || false == dataList.ContainsKey("NAME"))
// 					{
// 						result = "NACK";
// 						description = "Can_not_find_data_of_<PATH>or<NAME>";
// 						return;
// 					}
// 
// 					if (false == Rms_DownloadRecipe(dataList["PATH"], dataList["NAME"], ref result, ref description))
// 					{
// 						result = "NACK";
// 						description = "Recipe Download failed";
// 						return;
// 					}
// 
// 					if (false == Rms_SelectRecipe(RMS_PATH, dataList["NAME"], ref result, ref description))
// 					{
// 						result = "NACK";
// 						description = "Downloaded Recipe load failed";
// 						return;
// 					}
// 
// 					break;
// 				case EN_RMS.SELECT_RECIPE:
// 					if (false == dataList.ContainsKey("NAME"))
// 					{
// 						result = "NACK";
// 						description = "Can_not_find_data_of_<NAME>";
// 						return;
// 					}
// 
// 					if (false == Rms_SelectRecipe(RMS_PATH, dataList["NAME"], ref result, ref description))
// 						return;
// 
// 					break;
// 			}
// 		}
// 		// 2022.05.31 by junho [ADD] Recipe upload 요청
// 		public void ReceiveAckRMS(string sFunction, Dictionary<string, string> dataList, bool isSuccess)
// 		{
// 			EN_RMS functionRms;
// 			if (false == Enum.TryParse(sFunction, out functionRms))
// 				return;
// 
// 			switch(functionRms)
// 			{
// 				case EN_RMS.UPLOAD_RECIPE:
// 					FrameOfSystem3.Views.FunctionsUi.GetInstance().ActivateSaveButton = true;
// 					break;
// 			}
// 		}
		#endregion </RECEIVE METHOD>

		#region <RMS>
// 		private static string RMS_PATH = "\\\\127.0.0.1\\BP5000WIR\\RMS";
// 		private bool Rms_DownloadRecipe(string path, string name, ref string result, ref string description)
// 		{
// 			/// 1. EFEM에서 특정 foulder에 recipe 넣어줌
// 			/// 2. 설비 가동 확인 후 (Execute 상태여도 가능해야함)
// 			/// 3. File copy
// 
// 			if (false == FrameOfSystem3.Task.TaskOperator.GetInstance().IsMachineWait())
// 			{
// 				result = "NACK";
// 				description = "Machine_is_running";
// 				return false;
// 			}
// 
// 			string targetName = System.IO.Path.GetFileNameWithoutExtension(name) + Define.DefineConstant.FileFormat.FILEFORMAT_RECIPE;
// 
// 			if(FunctionsETC.FolderExistCheck(RMS_PATH))
// 			{
// 				DateTime date = DateTime.Now;
// 				string backupPath = RMS_PATH.Replace("\\RMS", "\\rms_backup");
// 
// 				if(false == FunctionsETC.FolderExistCheck(backupPath))
// 				{
// 					FunctionsETC.FolderCreate(backupPath);
// 				}
// 				backupPath += string.Format("\\{0}", date.ToString("yyMMdd_HHmmss"));
// 
// 				for (int i = 0; i < 10; ++i )
// 				{
// 					if(false == FunctionsETC.FolderExistCheck(backupPath))
// 						break;
// 
// 					backupPath = backupPath + "_" + i.ToString();
// 				}
// 
// 				if (false == FunctionsETC.FolderNameChange(RMS_PATH, backupPath))
// 				{
// 					result = "NACK";
// 					description = "File_backup_failed";
// 					return false;
// 				}
// 			}
// 
// 			if (false == FunctionsETC.FileMove(path, targetName, RMS_PATH, targetName))
// 			{
// 				result = "NACK";
// 				description = "File_move_failed";
// 				return false;
// 			}
// 
// 			return true;
// 		}
// 		private bool Rms_SelectRecipe(string path, string name, ref string result, ref string description)
// 		{
// 			if (false == FrameOfSystem3.Task.TaskOperator.GetInstance().IsMachineWait())
// 			{
// 				result = "NACK";
// 				description = "Machine_is_running";
// 				return false;
// 			}
// 
// 			string targetName = System.IO.Path.GetFileNameWithoutExtension(name) + Define.DefineConstant.FileFormat.FILEFORMAT_RECIPE;
// 
// 			if (false == FunctionsETC.FileExistCheck(path, targetName))
// 			{
// 				result = "NACK";
// 				description = string.Format("Can_not_find_recipe_file<NAME:{0}>", name);
// 				return false;
// 			}
// 
// 			string strErrorMsg = string.Empty;
// 			if (false == _recipe.LoadProcessRecipe(ref path, ref targetName, ref strErrorMsg))
// 			{
// 				result = "NACK";
// 				description = "Recipe_load_failed";
// 				return false;
// 			}
// 
// 			return true;
// 		}
// 		// 2022.05.31 by junho [ADD] Recipe upload 요청
// 		public bool RequestRecipeUpload()
// 		{
// 			string currentPath = Define.DefineConstant.FilePath.FILEPATH_RECIPE;
// 			string name = "";
// 
// 			// 현재 recipe 정보 읽어와서
// 			if (false == _recipe.GetProcessFileInformation(ref currentPath, ref name))
// 			{
// 				WriteLog(false, "ERROR!!! Get process file information failed (Request Recipe Upload)");
// 				return false;
// 			}
// 
// 			// 확장자 붙이고
// 			name = System.IO.Path.GetFileNameWithoutExtension(name) + Define.DefineConstant.FileFormat.FILEFORMAT_RECIPE;
// 
// 			// File 유무 확인 후
// 			if (false == FunctionsETC.FileExistCheck(currentPath, name))
// 			{
// 				WriteLog(false, string.Format("ERROR!!! Exist not recipe file. path : {0}, name : {1} (Request Recipe Upload)"
// 					, currentPath, name));
// 				return false;
// 			}
// 
// 			string path = string.Format("\\\\127.0.0.1\\BP5000WIR");
// 
// 			// EFEM으로 보낼 data 작성
// 			// type : "RMS"
// 			// function : "UPLOAD_RECIPE"
// 			// message
// 			//	[0] key : "Path", value : <file path>
// 			//	[1] key : "Name", value : <Recipe name> (확장자 포함)
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 			sendMessage.Add("Path", path);
// 			sendMessage.Add("Name", name);
// 
// 			#region <Write Log>
// 			WriteLog(true, string.Format("Request Recipe Upload (Path : {0}, Name : {1})", path, name));
// 			#endregion
// 
// 			bool result = _wcf.DoSecsGemSendEvent(EN_SECSGEM_EVENT_TYPE.RMS.ToString(), EN_RMS.UPLOAD_RECIPE.ToString(), sendMessage, CallBackSecsGemEventAck);
// 			return result;
// 		}
		#endregion </RMS>

		#region <CALLBACK>

		#region <ACK>
		private void CallBackRequestAck(string portName, string requestSubject, string result, string description)
		{
			string taskName = string.Empty;
// 			if (portName.Equals(PORT_FRONT)) taskName = Define.DefineEnumProject.Task.EN_TASK_LIST.FrontStage.ToString();
// 			if (portName.Equals(PORT_REAR)) taskName = Define.DefineEnumProject.Task.EN_TASK_LIST.RearStage.ToString();
			if (taskName.Equals(string.Empty)) return;

// 			Work.UIComunicationEvent.Inform_ToTask(Work.UIComunicationEvent.EN_REQUEST_FROM_UI.EFEM_ACK
// 				, taskName, new object[] { requestSubject, result, description });

			// 2022.06.21 by junho [ADD] Approach 관련 Message는 Logging 하지 않도록 변경
            EN_EFEM_MESSAGE enSubject;
            bool isLogging = true;
            if(Enum.TryParse(requestSubject, out enSubject))
            {
                switch(enSubject)
                {
                    case EN_EFEM_MESSAGE.APPROACH_LOADING:
                    case EN_EFEM_MESSAGE.APPROACH_UNLOADING_GOOD:
                    case EN_EFEM_MESSAGE.APPROACH_UNLOADING_NG:
                        if(result != EN_EFEM_ACK.ACK.ToString())
                        {
                            isLogging = false;
                        }
                        break;
                }
            }

            if (isLogging)
            {
                WriteLog(false, string.Format("REQUEST ACK (PortName : {0}, Subject : {1}, result : {2}, description : {3})"
                    , portName, requestSubject, result, description));
            }
		}
		private void CallBackSecsGemParameterAck(string type, Dictionary<string, string> dataList, string result, string description)
		{
			#region write log
			int dataCount = 0;
			if (dataList != null)
				dataCount = dataList.Count;

			WriteLog(false, string.Format("SECSGEM PARAMETER ACK\t(Type : {0}, Count : {1}, result : {2}, description : {3})"
			   , type, dataCount, result, description));
			#endregion

			EN_SECSGEM_PARAMETER_TYPE parameterType;
			if (false == Enum.TryParse(type, out parameterType))
			{
				result = "NACK";
				description = "Can_not_parse_type";
			}

			bool isSuccess = result.Equals(EN_EFEM_ACK.ACK.ToString());

			switch (parameterType)
			{
				case EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO_IR_F:
					//ReceiveWaferInfo(EN_WORK_ZONE.FRONT, dataList, isSuccess);
					break;
				case EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO_IR_R:
					//ReceiveWaferInfo(EN_WORK_ZONE.REAR, dataList, isSuccess);
					break;
				default: return;
			}
		}
		private void CallBackSecsGemEventAck(string type, string sFunction, Dictionary<string, string>dataList, string result, string description)
		{
			#region write log
			int dataCount = 0;
			if (dataList != null)
				dataCount = dataList.Count;

			WriteLog(false, string.Format("SECSGEM EVENT ACK\t(Type : {0}, Count : {1}, result : {2}, description : {3})"
				, type, dataCount, result, description));
			#endregion

			// 2022.05.31 by junho [ADD] Recipe upload 요청
			EN_SECSGEM_EVENT_TYPE eventType;
			if (false == Enum.TryParse(type, out eventType))
			{
				result = "NACK";
				description = "Can_not_parse_type";
			}

			bool isSuccess = result.Equals(EN_EFEM_ACK.ACK.ToString());

			switch (eventType)
			{
				case EN_SECSGEM_EVENT_TYPE.RMS:
					//ReceiveAckRMS(sFunction, dataList, isSuccess);
					break;
				default: return;
			}
		}
		#endregion </ACK>

		#region <RECEIVE REQUEST>
		private void CallBackReceiveRequest(string portName, string requestSubject, out string result, out string description)
		{
			string taskName = string.Empty;
// 			if (portName.Equals(PORT_FRONT)) taskName = Define.DefineEnumProject.Task.EN_TASK_LIST.FrontStage.ToString();
// 			if (portName.Equals(PORT_REAR)) taskName = Define.DefineEnumProject.Task.EN_TASK_LIST.RearStage.ToString();

			if (taskName.Equals(string.Empty))
			{
				result = EN_EFEM_ACK.NACK.ToString();
				description = "Invalidate_of_PortName";
			}
			else if (EquipmentState_.EquipmentState.GetInstance().GetState() != EquipmentState_.EQUIPMENT_STATE.IDLE)
			{
				result = EN_EFEM_ACK.NACK.ToString();
				description = "Equipment_state_is_not_IDLE";
			}
			else
			{
				result = EN_EFEM_ACK.ACK.ToString();
				description = "No_Problem";
			}
// 
// 			Work.UIComunicationEvent.Inform_ToTask(Work.UIComunicationEvent.EN_REQUEST_FROM_UI.EFEM_REQUEST
// 				, taskName, new object[] { requestSubject, result, description });

			WriteLog(false, string.Format("RECEIVE REQUEST (PortName : {0}, Subject : {1}, result : {2}, description : {3})"
				, portName, requestSubject, result, description));
		}
		private void CallBackReceiveResponse(string portName, string requestSubject, out string result, out string description)
		{
			string taskName = string.Empty;
// 			if (portName.Equals(PORT_FRONT)) taskName = Define.DefineEnumProject.Task.EN_TASK_LIST.FrontStage.ToString();
// 			if (portName.Equals(PORT_REAR)) taskName = Define.DefineEnumProject.Task.EN_TASK_LIST.RearStage.ToString();
			if (taskName.Equals(string.Empty))
			{
				result = "NACK";
				description = "Invalidate_of_PortName";
			}
			else
			{
				result = "ACK";
				description = "No_Problem";
			}

// 			Work.UIComunicationEvent.Inform_ToTask(Work.UIComunicationEvent.EN_REQUEST_FROM_UI.EFEM_RESPONSE
// 				, taskName, new object[] { requestSubject, result, description });

			WriteLog(false, string.Format("RECEIVE RESPONSE (PortName : {0}, Subject : {1}, result : {2}, description : {3})"
				, portName, requestSubject, result, description));
		}
		private void CallBackReceiveSecsGemParameter(string type, Dictionary<string, string> dataList, out string result, out string description)
		{
			result = "ACK";
			description = "No_Problem";

			EN_SECSGEM_PARAMETER_TYPE parameterType;
			if(false == Enum.TryParse(type, out parameterType))
			{
				result = "NACK";
				description = "Can_not_parse_type";
			}

			#region write log
			int dataCount = 0;
			if (dataList != null)
				dataCount = dataList.Count;

			WriteLog(false, string.Format("RECEIVE SECSGEM PARAMETER\t(Type : {0}, Count : {1}, result : {2}, description : {3})"
				, type, dataCount, result, description));
			#endregion
		}
		private void CallBackReceiveSecsGemEvent(string type, string sFunction, Dictionary<string, string> dataList, out string result, out string description)
		{
			result = "ACK";
			description = "No_Problem";

			EN_SECSGEM_EVENT_TYPE eventType;
			if (false == Enum.TryParse(type, out eventType))
			{
				result = "NACK";
				description = "Can_not_parse_type";
			}

			#region write log
			int dataCount = 0;
			if (dataList != null)
				dataCount = dataList.Count;

			WriteLog(false, string.Format("RECEIVE SECSGEM EVENT\t(Type : {0}, Count : {1}, result : {2}, description : {3})"
				, type, dataCount, result, description));
			#endregion

			switch (eventType)
			{
				case EN_SECSGEM_EVENT_TYPE.RCMD:
					//ReceiveRCMD(sFunction, dataList, out result, out description);
					break;
				case EN_SECSGEM_EVENT_TYPE.RMS:
					//ReceiveRMS(sFunction, dataList, out result, out description);
					break;
				default: return;
			}
		}
		#endregion </RECEIVE REQUEST>

		#endregion </CALLBACK>

		public void WriteLog(bool isSend, string message)
		{
			//_log.WriteWcfLog("EFEM", isSend, message);
			EfemLogMessageEvent.WriteLog(message);
		}

// 		sealed class SideAndNozzle : Tuple<EN_HEAD_SIDE, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE>
// 		{
// 			public SideAndNozzle(EN_HEAD_SIDE side, Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE nozzle) : base(side, nozzle) { }
// 
// 			public EN_HEAD_SIDE Side { get { return Item1; } }
// 			public Define.DefineEnumProject.Task.WorkHead.EN_NOZZLE Nozzle { get { return Item2; } }
// 		}
	}
	public class EfemLogMessageEvent
	{
		public delegate void WriteLogEvent(string message);
		public static event WriteLogEvent onWriteLog;
		public static void WriteLog(string message)
		{
			
			if (onWriteLog != null)
			{
				onWriteLog(message);
			}
		}
	}
}
