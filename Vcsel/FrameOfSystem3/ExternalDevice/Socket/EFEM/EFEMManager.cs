using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WCFforEFEM_;
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

            //PLR 5000번대
            PLR_WAFER_ID                        = 2050,

            PLR_BLOCK_TEMP                      = 5001,
            PLR_FFU                             = 5002,

            PLR_WAFER_SLOT_NO                   = 2055,
            PLR_WAFER_PORT_ID                   = 2056,

		}
		public enum EN_CEID
		{
			
            //PLR 300
            PLR_START                                   = 190,
            BOND_START                                  = 192,
            BOND_END                                    = 193,
            PLR_END                                     = 191,
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

        public enum EN_ECID
        {
            PLR_PROCESS_FILE_PATH = 40000,
            PLR_PROCESS_FILE_NAME,
            PLR_LASER_SETTING_DELAY,
            PLR_HEAD_READY_POSITION_X,
            PLR_HEAD_READY_POSITION_Y,
            PLR_WORK_BLOCK_TOLERANCE_MIN,
            PLR_WORK_BLOCK_TOLERANCE_MAX,
            PLR_WORK_BLOCK_CH_OFFSET_1,
            PLR_WORK_BLOCK_CH_OFFSET_2,
            PLR_WORK_BLOCK_CH_OFFSET_3,
            PLR_WORK_BLOCK_CH_OFFSET_4,
            PLR_WORK_BLOCK_CH_OFFSET_5,
            PLR_WORK_BLOCK_CH_OFFSET_6,
            PLR_WORK_BLOCK_CH_OFFSET_7,
            PLR_WORK_BLOCK_CH_OFFSET_8,
            PLR_POWER_CALIBRATION_MAX_VOLT,
            PLR_POWER_CALIBRATION_MIN_VOLT,
            PLR_POWER_CALIBRATION_STEP_COUNT,
            PLR_POWER_MEASURE_SELLECTED_CHANNEL,
            PLR_POWER_MEASURE_BLOCK_AVOID_POSITION_X,
            PLR_POWER_MEASURE_POSITION_X_1,
            PLR_POWER_MEASURE_POSITION_X_2,
            PLR_POWER_MEASURE_POSITION_X_3,
            PLR_POWER_MEASURE_POSITION_X_4,
            PLR_POWER_MEASURE_POSITION_X_5,
            PLR_POWER_MEASURE_POSITION_X_6,
            PLR_POWER_MEASURE_POSITION_X_7,
            PLR_POWER_MEASURE_POSITION_X_8,
            PLR_POWER_MEASURE_POSITION_X_9,
            PLR_POWER_MEASURE_POSITION_X_10,
            PLR_POWER_MEASURE_POSITION_X_11,
            PLR_POWER_MEASURE_POSITION_X_12,
            PLR_POWER_MEASURE_POSITION_X_13,
            PLR_POWER_MEASURE_POSITION_X_14,
            PLR_POWER_MEASURE_POSITION_X_15,
            PLR_POWER_MEASURE_POSITION_X_16,
            PLR_POWER_MEASURE_POSITION_X_17,
            PLR_POWER_MEASURE_POSITION_X_18,
            PLR_POWER_MEASURE_POSITION_Y_1,
            PLR_POWER_MEASURE_POSITION_Y_2,
            PLR_POWER_MEASURE_POSITION_Y_3,
            PLR_POWER_MEASURE_POSITION_Y_4,
            PLR_POWER_MEASURE_POSITION_Y_5,
            PLR_POWER_MEASURE_POSITION_Y_6,
            PLR_POWER_MEASURE_POSITION_Y_7,
            PLR_POWER_MEASURE_POSITION_Y_8,
            PLR_POWER_MEASURE_POSITION_Y_9,
            PLR_POWER_MEASURE_POSITION_Y_10,
            PLR_POWER_MEASURE_POSITION_Y_11,
            PLR_POWER_MEASURE_POSITION_Y_12,
            PLR_POWER_MEASURE_POSITION_Y_13,
            PLR_POWER_MEASURE_POSITION_Y_14,
            PLR_POWER_MEASURE_POSITION_Y_15,
            PLR_POWER_MEASURE_POSITION_Y_16,
            PLR_POWER_MEASURE_POSITION_Y_17,
            PLR_POWER_MEASURE_POSITION_Y_18,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_1,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_2,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_3,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_4,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_5,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_6,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_7,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_8,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_9,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_10,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_11,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_12,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_13,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_14,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_15,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_16,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_17,
            PLR_POWER_MEASURE_CHANNEL_ENABLE_18,
            PLR_POWER_MEASURE_WATT,
            PLR_POWER_MEASURE_VOLT,
            PLR_POWER_MEASURE_SHOT_TIME,
            PLR_POWER_MEASURE_WAIT_TIME,
            PLR_POWER_MEASURE_REPEAT_COUNT,
            PLR_POWER_MEASURE_REST_TIME,
            PLR_HEAD_FLOW_THRESHOLD,
            PLR_MONOTORING_POWER_CH_1_VISIBLE,
            PLR_MONOTORING_POWER_CH_1_COLOR,
            PLR_MONOTORING_POWER_CH_2_VISIBLE,
            PLR_MONOTORING_POWER_CH_2_COLOR,
            PLR_MONOTORING_POWER_CH_3_VISIBLE,
            PLR_MONOTORING_POWER_CH_3_COLOR,
            PLR_MONOTORING_POWER_CH_4_VISIBLE,
            PLR_MONOTORING_POWER_CH_4_COLOR,
            PLR_MONOTORING_POWER_CH_5_VISIBLE,
            PLR_MONOTORING_POWER_CH_5_COLOR,
            PLR_MONOTORING_POWER_CH_6_VISIBLE,
            PLR_MONOTORING_POWER_CH_6_COLOR,
            PLR_MONOTORING_POWER_CH_7_VISIBLE,
            PLR_MONOTORING_POWER_CH_7_COLOR,
            PLR_MONOTORING_POWER_CH_8_VISIBLE,
            PLR_MONOTORING_POWER_CH_8_COLOR,
            PLR_MONOTORING_POWER_CH_9_VISIBLE,
            PLR_MONOTORING_POWER_CH_9_COLOR,
            PLR_MONOTORING_POWER_CH_10_VISIBLE,
            PLR_MONOTORING_POWER_CH_10_COLOR,
            PLR_MONOTORING_POWER_CH_11_VISIBLE,
            PLR_MONOTORING_POWER_CH_11_COLOR,
            PLR_MONOTORING_POWER_CH_12_VISIBLE,
            PLR_MONOTORING_POWER_CH_12_COLOR,
            PLR_MONOTORING_POWER_CH_13_VISIBLE,
            PLR_MONOTORING_POWER_CH_13_COLOR,
            PLR_MONOTORING_POWER_CH_14_VISIBLE,
            PLR_MONOTORING_POWER_CH_14_COLOR,
            PLR_MONOTORING_POWER_CH_15_VISIBLE,
            PLR_MONOTORING_POWER_CH_15_COLOR,
            PLR_MONOTORING_POWER_CH_16_VISIBLE,
            PLR_MONOTORING_POWER_CH_16_COLOR,
            PLR_MONOTORING_POWER_CH_17_VISIBLE,
            PLR_MONOTORING_POWER_CH_17_COLOR,
            PLR_MONOTORING_POWER_CH_18_VISIBLE,
            PLR_MONOTORING_POWER_CH_18_COLOR,
            PLR_MONOTORING_POWER_TOTAL_VISIBLE,
            PLR_MONOTORING_POWER_TOTAL_COLOR,
            PLR_MONOTORING_BLOCK_VAC_VISIBLE,
            PLR_MONOTORING_BLOCK_VAC_COLOR,
            PLR_MONOTORING_HEAD_FLOW_VISIBLE,
            PLR_MONOTORING_HEAD_FLOW_COLOR,
            PLR_LASER_USED,
            PLR_IR_USED,
            PLR_PYROMETER_USED,
            PLR_POWERCHECK_USED,
            PLR_POWERCHECK_TOLERANCE,
            PLR_INPUT_SMEMA_USED,
            PLR_LASER_ON_VOLT_THRESHOLD,
            PLR_HANDLER_READY_X,
            PLR_HANDLER_WORK_BLOCK_AVOID_POSITION_X,
            PLR_HANDLER_WORK_BLOCK_AVOID_POSITION_R,
            PLR_HANDLER_WORK_BLOCK_AVOID_POSITION_Z,
            PLR_HANDLER_Z_MATERIAL_CONTACT_SPEED,
            PLR_HANDLER_Z_MATERIAL_HANDLE_SPEED,
            PLR_HANDLER_X_MATERIAL_HANDLE_SPEED,
            PLR_HANDLER_Y_MATERIAL_HANDLE_SPEED,
            PLR_HANDLER_R_MATERIAL_HANDLE_SPEED,
            PLR_FFU_USE,
            PLR_FFU_CONTROLLER_COUNT,
            PLR_FFU_UNIT_COUNT,
            PLR_FFU_TARGET_SPEED_1,
            PLR_FFU_TARGET_SPEED_2,
            PLR_FFU_TARGET_SPEED_3,
            PLR_FFU_TARGET_SPEED_4,
            PLR_FFU_FULL_SPEED,
            PLR_FFU_ALARM_CODE,
            PLR_CHILLER_ALARM_CODE,
            PLR_PREEQUIPMENT_WCF_USED,
            PLR_PREEQUIPMENT_HOST_IP,
            PLR_PREEQUIPMENT_HOST_PORT,
            PLR_PREEQUIPMENT_TARGET_IP,
            PLR_PREEQUIPMENT_TARGET_PORT,
            PLR_WAIT_COLOR,
            PLR_DONE_COLOR,
            PLR_LOW_TEMP_COLOR,
            PLR_TEMP_GROW_FAIL_COLOR,
            PLR_TEMP_DEVOVER_COLOR,
            PLR_HIGH_TEMP_COLOR,
            PLR_MAX_HIGH_TEMP_COLOR,
            PLR_EMG_LOW_TEMP_COLOR,
            PLR_EMG_HIGH_TEMP_COLOR,
            PLR_POWER_FAULT_COLOR,
            PLR_SOURCE_ALARM_COLOR,
            PLR_RESULT_GETFAIL_COLOR,
            PLR_RUN_RATIO,
            PLR_IONIZER_CHECK_DELAY,
            PLR_IONIZER_INTERLUPT_ENABLE,
            PLR_TRANSFER_TEST,
            PLR_POWER_MEASURE_HEAD_AVOID_POSITION_Y,
            PLR_POWERMETER_READY_POSITION_X,
            PLR_POWERMETER_READY_POSITION_Y,
            PLR_EFEM_USE,
            PLR_EFEM_TARGET_IP,
            PLR_EFEM_TARGET_PORT,
            PLR_EFEM_HOST_IP,
            PLR_EFEM_HOST_PORT,
            PLR_EFEM_FDC_INTERVAL,
            PLR_EFEM_FDC_LOGGING,
            PLR_EFEM_UPDATE_ECID,
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
            _wcf = new WCFforEFEM();
            _log = LogManager.GetInstance();

            foreach (EN_ECID ECID in Enum.GetValues(typeof(EN_ECID)))
            {
                _ecidList.Add(ECID.ToString(), ((int)ECID).ToString());		
            }

//             foreach (PARAM_COMMON common in Enum.GetValues(typeof(PARAM_COMMON)))
//             {
//                 _ecidList.Add(common.ToString(), "PLR_" + ((int)common + 30000).ToString());		//구분을 위해 앞에 PLR_ 붙힘// COMMON ITEM은 30000을 더해준다.
//             }
// 
//             foreach (PARAM_EQUIPMENT equipment in Enum.GetValues(typeof(PARAM_EQUIPMENT)))
//             {
//                 if (_ecidList.ContainsKey(equipment.ToString())) continue;
//                 _ecidList.Add(equipment.ToString(), "PLR_" + ((int)equipment + 31000).ToString());		//구분을 위해 앞에 PLR_ 붙힘 // EQUIPMENT ITEM은 31000을 더해준다.
//             }
        }
		#endregion </CONSTRUCTOR>

		#region <FIELD>
		bool _initialize = false;
		bool _use = false;

		bool _open = false;
		bool _connect = false;

		Recipe.Recipe _recipe = null;
        TickCounter_.TickCounter _timeCheckForConnect = new TickCounter_.TickCounter();

		string _efemIP = string.Empty;
		string _efemPort = string.Empty;
		string _myIP = string.Empty;
		string _myPort = string.Empty;

		WCFforEFEM _wcf = null;

		TickCounter_.TickCounter _timeUpdateFDC = new TickCounter_.TickCounter();

		LogManager _log = null;

		Dictionary<string, string> _ecidList = new Dictionary<string, string>();
		#endregion </FIELD>

		#region <PROPERTY>
		public bool Use { get { return _use; } }
		#endregion </PROPERTY>

		public void Execute()
		{
			if (false == _initialize)
				return;

			_use = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_USE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, false);
			if (false == _use)
				return;

            if (_timeCheckForConnect.IsTickOver(false))
            {
                if (false == IsOpen())
                    Open();

                if (false == IsConnect())
                    Connect();

                _timeCheckForConnect.SetTickCount(60000);	// 60sec에 한번씩 확인
            }

            if (IsOpen() && IsConnect())
            {
                SecsGem_UpdateFDC();
                Secsgem_SendCeid();
            }
		}

		#region <INTERFACE>
		public bool Init()
		{
			_initialize = true;
			_use = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_USE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, false);

			//if(Work.AppConfigManager.Instance.HaveEfemModule)
			{
				Recipe.Recipe.ParameterChangedNotify += WhenRecipeChanged;
			}
            _timeCheckForConnect.SetTickCount(100);	// 60sec에 한번씩 확인

			return true;
		}

		public bool Open()
		{
			if (_open) return true;

            string ip = "127.0.0.1";
            string port = "1000";

            _myIP = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_HOST_IP.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, ip);
			_myPort = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_HOST_PORT.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, port);

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

			_efemIP = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_TARGET_IP.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, "127.0.0.1");
			_efemPort = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_TARGET_PORT.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, "4001");

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

				UpdateECID_ALL();
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
		public string GetHostStatus()
		{
			if(false == _use)
				return "Closed";

			return _wcf.GetHostStatus();
		}
        public string GetServerStatus()
        {
            if (false == _use)
                return "Closed";

            return _wcf.GetServerStatus();
        }
		public bool DoRequest(EN_EFEM_MESSAGE efemMessage)
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

		#region SecsGem Parameter

		public bool UpdateVID(Dictionary<EN_VID, string> updateList, bool isLogging = true)
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			int vidCount = 0;
			Dictionary<string, string> sendMessage = new Dictionary<string,string>();
			foreach(KeyValuePair<EN_VID, string> kvp in updateList)
			{
				sendMessage.Add(((int)kvp.Key).ToString(), kvp.Value);
				++vidCount;
			}

			bool result = _wcf.DoSecsGemParameter(EN_SECSGEM_PARAMETER_TYPE.VID.ToString(), sendMessage, CallBackSecsGemParameterAck);

			#region write log
			if (isLogging)
			{
				WriteLog(true, string.Format("UPDATE VID\tCount : {0}, Result : {1}"
					, vidCount.ToString(), result.ToString()));
			}
			#endregion

			return result;
		}
		public bool UpdateECID(EN_RECIPE_TYPE type, string key, string value)
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			if (false == _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_UPDATE_ECID.ToString(), true))
				return true;

			if (false == _ecidList.ContainsKey(key))
				return true;	// 쓰지 않는 key면 걍 true 반환
			
			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
			sendMessage.Add(_ecidList[key], value);

			bool result = _wcf.DoSecsGemParameter(EN_SECSGEM_PARAMETER_TYPE.ECID.ToString(), sendMessage, CallBackSecsGemParameterAck);

			#region write log
			WriteLog(true, string.Format("UPDATE ECID\tCount : {0}, Result : {1}"
				, sendMessage.Count.ToString(), result.ToString()));
			#endregion

			return result;
		}
		public bool UpdateECID_ALL()
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			if (false == _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_UPDATE_ECID.ToString(), true))
				return true;

			int ecidCount = 0;
			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
			foreach(PARAM_COMMON common in Enum.GetValues(typeof(PARAM_COMMON)))
			{
				string itemName = "PLR_" + common.ToString(); //구분을 위해 앞에 "PLR_"붙힘
                string ParamterName = common.ToString();
				if (false == _ecidList.ContainsKey(itemName))
					continue;

				if (sendMessage.ContainsKey(_ecidList[itemName]))
					continue;

				string value = _recipe.GetValue(EN_RECIPE_TYPE.COMMON, ParamterName, 0, EN_RECIPE_PARAM_TYPE.VALUE, "");
				sendMessage.Add(_ecidList[itemName], value);
				++ecidCount;
			}

			foreach (PARAM_EQUIPMENT equipment in Enum.GetValues(typeof(PARAM_EQUIPMENT)))
			{
                string itemName = "PLR_" + equipment.ToString(); //구분을 위해 앞에 "PLR_"붙힘
                string ParamterName = equipment.ToString();
            

                string[] arItemSplit = itemName.Split('_');
                int nParaCount = 0;
                if (int.TryParse(arItemSplit[arItemSplit.Length - 1], out nParaCount))
                {
                    for(int nParaIndex = 0; nParaIndex < nParaCount; nParaIndex++)
                    {
                        arItemSplit[arItemSplit.Length - 1] = (nParaIndex + 1).ToString();
                        itemName = string.Join("_", arItemSplit);
                        if (false == _ecidList.ContainsKey(itemName))
                            continue;

                        if (sendMessage.ContainsKey(_ecidList[itemName]))
                            continue;

                        string value = _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, ParamterName, nParaIndex, EN_RECIPE_PARAM_TYPE.VALUE, "");
                        sendMessage.Add(_ecidList[itemName], value);
                        ++ecidCount;
                    }
                }
                else
                {
                    if (false == _ecidList.ContainsKey(itemName))
                        continue;

                    if (sendMessage.ContainsKey(_ecidList[itemName]))
                        continue;

                    string value = _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, ParamterName, 0, EN_RECIPE_PARAM_TYPE.VALUE, "");
                    sendMessage.Add(_ecidList[itemName], value);
                    ++ecidCount;
                }
			}

			bool result = _wcf.DoSecsGemParameter(EN_SECSGEM_PARAMETER_TYPE.ECID.ToString(), sendMessage, CallBackSecsGemParameterAck);

			#region write log
			WriteLog(true, string.Format("UPDATE ECID\tCount : {0}, Result : {1}"
				, ecidCount.ToString(), result.ToString()));
			#endregion

			return result;
		}

        //WIR에서 받음 
// 		public bool DoRequestWaferInfo()
// 		{
// 			if (false == _use)
// 				return true;
// 
// 			if (false == _connect)
// 				return false;
// 
//             EN_SECSGEM_PARAMETER_TYPE type = EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO;
// // 			switch(zone)
// // 			{
// // 				case EN_WORK_ZONE.FRONT: type = EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO_IR_F; break;
// // 				case EN_WORK_ZONE.REAR: type = EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO_IR_R; break;
// // 				default: return false;
// // 			}
// 
// 			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
// 			foreach (EN_SUBJECT_INFO en in Enum.GetValues(typeof(EN_SUBJECT_INFO)))
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
		public bool SecsGemSendEventEx(EN_CEID ceid, Dictionary<EN_VID, string> vidList)
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			Dictionary<string, string> sendMessage = new Dictionary<string, string>();

			int vidCount = 0;
			if (vidList != null)
			{
				foreach (KeyValuePair<EN_VID, string> kvp in vidList)
				{
					sendMessage.Add(((int)kvp.Key).ToString(), kvp.Value);
					++vidCount;
				}
			}

			int ceidNo = (int)ceid;

			bool result = _wcf.DoSecsGemSendEvent(EN_SECSGEM_EVENT_TYPE.CEID.ToString(), ceidNo.ToString(), sendMessage, CallBackSecsGemEventAck);
			WriteLog(true, string.Format("SEND EVENT\tCEID : {0}, Count : {1}, Result : {2}"
				, ceidNo.ToString(), vidCount.ToString(), result.ToString()));

			return result;
		}
		public bool UpdateALID(int alarmCode, EN_ALM_TYPE type)
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
			switch(type)
			{
				case EN_ALM_TYPE.OCCURRED:
					sendMessage.Add("STATUS", "1");
					break;
				case EN_ALM_TYPE.RELEASED:
					sendMessage.Add("STATUS", "0");
					break;
			}

			int alid = alarmCode + 4000000;

			bool result = _wcf.DoSecsGemSendEvent(EN_SECSGEM_EVENT_TYPE.ALARM.ToString(), alid.ToString(), sendMessage, CallBackSecsGemEventAck);

			return result;
		}
		#endregion
		#endregion </INTERFACE>

		#region <SECSGEM EVENT>
		private bool SecsGem_UpdateFDC()
		{
			if (false == _use)
				return true;

			if (false == _connect)
				return false;

			if (false ==_timeUpdateFDC.IsTickOver(true))
				return true;

            uint interval = (uint)_recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.EFEM_FDC_INTERVAL.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 5000);
            if (interval < 100) interval = 100;
            _timeUpdateFDC.SetTickCount(interval);

			Dictionary<EN_VID, string> vidList = new Dictionary<EN_VID, string>();
			string valueString = "0";
			double valueDouble = 0.0;
			int valueInt = 0;
// 		
// 			#region BLOCK TEMP
// 			valueDouble = ExternalDevice.Heater.Heater.GetInstance().GetMeanValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK);
// 			vidList.Add(EN_VID.PLR_BLOCK_TEMP, valueDouble.ToString());
// 
// 			#endregion
// 
// 			#region FFU
// 			valueString = _recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.FFU_TARGET_SPEED_4.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "0");
// 			vidList.Add(EN_VID.PLR_FFU, valueString);
// 			#endregion

 			bool isFdcLogging = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.EFEM_FDC_LOGGING.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
 			if (isFdcLogging) WriteLog(true, string.Format("UPDATE FDC VID"));

			return UpdateVID(vidList, isFdcLogging);
		}

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
		private void ReceiveRCMD(string sFunction, Dictionary<string, string> dataList, out string result, out string description)
		{
			result = "ACK";
			description = "No_Problem";

			EN_RCMD rcmd;
			if (false == Enum.TryParse(sFunction, out rcmd))
			{
				result = "NACK";
				description = "Can_not_parse_sFunction";
				return;
			}

			switch(rcmd)
			{
				case EN_RCMD.STOP:
					Task.TaskOperator.GetInstance().SetOperation(RunningMain_.OPERATION_EQUIPMENT.STOP);
					break;
			}
		}
		public void ReceiveRMS(string sFunction, Dictionary<string, string> dataList, out string result, out string description)
		{
			result = "ACK";
			description = "No_Problem";

			EN_RMS rms;
			if (false == Enum.TryParse(sFunction, out rms))
			{
				result = "NACK";
				description = "Can_not_parse_sFunction";
				return;
			}

			switch (rms)
			{
				case EN_RMS.DOWNLOAD_RECIPE:
					if(false == dataList.ContainsKey("PATH") || false == dataList.ContainsKey("NAME"))
					{
						result = "NACK";
						description = "Can_not_find_data_of_<PATH>or<NAME>";
						return;
					}

					if (false == Rms_DownloadRecipe(dataList["PATH"], dataList["NAME"], ref result, ref description))
					{
						result = "NACK";
						description = "Recipe Download failed";
						return;
					}

					if (false == Rms_SelectRecipe(RMS_PATH, dataList["NAME"], ref result, ref description))
					{
						result = "NACK";
						description = "Downloaded Recipe load failed";
						return;
					}

					break;
				case EN_RMS.SELECT_RECIPE:
					if (false == dataList.ContainsKey("NAME"))
					{
						result = "NACK";
						description = "Can_not_find_data_of_<NAME>";
						return;
					}

					if (false == Rms_SelectRecipe(RMS_PATH, dataList["NAME"], ref result, ref description))
						return;

					break;
			}
		}
		// 2022.05.31 by junho [ADD] Recipe upload 요청
		public void ReceiveAckRMS(string sFunction, Dictionary<string, string> dataList, bool isSuccess)
		{
			EN_RMS functionRms;
			if (false == Enum.TryParse(sFunction, out functionRms))
				return;

			switch(functionRms)
			{
				case EN_RMS.UPLOAD_RECIPE:
					_recipe.RetractParameterChangeBlock("RecipeUpload");
					break;
			}
		}
		#endregion </RECEIVE METHOD>

		#region <RMS>
		private static string RMS_PATH = "\\\\127.0.0.1\\PLR300\\RMS";
		private bool Rms_DownloadRecipe(string path, string name, ref string result, ref string description)
		{
			/// 1. EFEM에서 특정 foulder에 recipe 넣어줌
			/// 2. 설비 가동 확인 후 (Execute 상태여도 가능해야함)
			/// 3. File copy

			if (false == FrameOfSystem3.Task.TaskOperator.GetInstance().IsMachineWait())
			{
				result = "NACK";
				description = "Machine_is_running";
				return false;
			}

			string targetName = System.IO.Path.GetFileNameWithoutExtension(name) + Define.DefineConstant.FileFormat.FILEFORMAT_RECIPE;

			if(FunctionsETC.FolderExistCheck(RMS_PATH))
			{
				DateTime date = DateTime.Now;
				string backupPath = RMS_PATH.Replace("\\RMS", "\\rms_backup");

				if(false == FunctionsETC.FolderExistCheck(backupPath))
				{
					FunctionsETC.FolderCreate(backupPath);
				}
				backupPath += string.Format("\\{0}", date.ToString("yyMMdd_HHmmss"));

				for (int i = 0; i < 10; ++i )
				{
					if(false == FunctionsETC.FolderExistCheck(backupPath))
						break;

					backupPath = backupPath + "_" + i.ToString();
				}

				if (false == FunctionsETC.FolderNameChange(RMS_PATH, backupPath))
				{
					result = "NACK";
					description = "File_backup_failed";
					return false;
				}
			}

			if (false == FunctionsETC.FileMove(path, targetName, RMS_PATH, targetName))
			{
				result = "NACK";
				description = "File_move_failed";
				return false;
			}

			return true;
		}
		private bool Rms_SelectRecipe(string path, string name, ref string result, ref string description)
		{
			if (false == FrameOfSystem3.Task.TaskOperator.GetInstance().IsMachineWait())
			{
				result = "NACK";
				description = "Machine_is_running";
				return false;
			}

			string targetName = System.IO.Path.GetFileNameWithoutExtension(name) + Define.DefineConstant.FileFormat.FILEFORMAT_RECIPE;

			if (false == FunctionsETC.FileExistCheck(path, targetName))
			{
				result = "NACK";
				description = string.Format("Can_not_find_recipe_file<NAME:{0}>", name);
				return false;
			}

			string strErrorMsg = string.Empty;
			if (false == _recipe.LoadProcessRecipe(ref path, ref targetName, ref strErrorMsg))
			{
				result = "NACK";
				description = "Recipe_load_failed";
				return false;
			}

			return true;
		}
		// 2022.05.31 by junho [ADD] Recipe upload 요청
		public bool RequestRecipeUpload()
		{
			string currentPath = Define.DefineConstant.FilePath.FILEPATH_RECIPE;
			string name = "";

			// 현재 recipe 정보 읽어와서
			if (false == _recipe.GetProcessFileInformation(ref currentPath, ref name))
			{
				WriteLog(false, "ERROR!!! Get process file information failed (Request Recipe Upload)");
				return false;
			}

			// 확장자 붙이고
			name = System.IO.Path.GetFileNameWithoutExtension(name) + Define.DefineConstant.FileFormat.FILEFORMAT_RECIPE;

			// File 유무 확인 후
			if (false == FunctionsETC.FileExistCheck(currentPath, name))
			{
				WriteLog(false, string.Format("ERROR!!! Exist not recipe file. path : {0}, name : {1} (Request Recipe Upload)"
					, currentPath, name));
				return false;
			}

			string path = string.Format("\\\\127.0.0.1\\BP5000WIR");

			// EFEM으로 보낼 data 작성
			// type : "RMS"
			// function : "UPLOAD_RECIPE"
			// message
			//	[0] key : "Path", value : <file path>
			//	[1] key : "Name", value : <Recipe name> (확장자 포함)
			Dictionary<string, string> sendMessage = new Dictionary<string, string>();
			sendMessage.Add("Path", path);
			sendMessage.Add("Name", name);

			#region <Write Log>
			WriteLog(true, string.Format("Request Recipe Upload (Path : {0}, Name : {1})", path, name));
			#endregion

			bool result = _wcf.DoSecsGemSendEvent(EN_SECSGEM_EVENT_TYPE.RMS.ToString(), EN_RMS.UPLOAD_RECIPE.ToString(), sendMessage, CallBackSecsGemEventAck);
			return result;
		}

		void WhenRecipeChanged(bool result, List<Recipe.Recipe.ParameterItem> changeList)
		{
			if (false == result || false == _initialize || false == _use || false == _connect)
				return;

			if (false == RequestRecipeUpload())
				return;

			_recipe.RequestParameterChangeBlock("RecipeUpload");
		}
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

			#region write log
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
			#endregion /write log
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

// 			switch (parameterType)
// 			{
//                 case EN_SECSGEM_PARAMETER_TYPE.WAFER_INFO:
// 					ReceiveWaferInfo(dataList, isSuccess);
// 					break;
// 				default: return;
// 			}
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
					ReceiveAckRMS(sFunction, dataList, isSuccess);
					break;
				default: return;
			}
		}
		#endregion </ACK>

		#region <RECEIVE REQUEST>
		private void CallBackReceiveRequest(string portName, string requestSubject, out string result, out string description)
		{
			string taskName = string.Empty;

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
					ReceiveRCMD(sFunction, dataList, out result, out description);
					break;
				case EN_SECSGEM_EVENT_TYPE.RMS:
					ReceiveRMS(sFunction, dataList, out result, out description);
					break;
				default: return;
			}
		}
		#endregion </RECEIVE REQUEST>

		#endregion </CALLBACK>

		public void WriteLog(bool isSend, string message)
		{
			_log.WriteWcfLog("EFEM", isSend, message);
			EfemLogMessageEvent.WriteLog(message);
		}

        Queue<EFEMManager.EN_CEID> _queueCeidList = new Queue<EFEMManager.EN_CEID>();
        TickCounter_.TickCounter _timeForCeidSend = new TickCounter_.TickCounter();
        private void Secsgem_SendCeid()
        {
            if (false == _timeForCeidSend.IsTickOver(true))
                return;

//             if (_efemManager == null)
//             {
//                 _timeForCeidSend.SetTickCount(1000 * 60 * 60 * 24);		// 1day
//                 return;
//             }

            if (_queueCeidList.Count <= 0)
                return;

            EFEMManager.EN_CEID ceid = _queueCeidList.Dequeue();
            var vidData = new Dictionary<EFEMManager.EN_VID, string>();
            switch (ceid)
            {
                case EFEMManager.EN_CEID.PLR_START:
                case EFEMManager.EN_CEID.BOND_START:
                case EFEMManager.EN_CEID.BOND_END:
                case EFEMManager.EN_CEID.PLR_END:
                    vidData.Add(EFEMManager.EN_VID.PLR_WAFER_ID, Work.WorkMap.GetInstance().GetID());
                    vidData.Add(EFEMManager.EN_VID.PLR_WAFER_SLOT_NO, Work.WorkMap.GetInstance().GetValue(Work.EN_WAFER_ITEM.SLOT_NO));
                    //vidData.Add(EFEMManager.EN_VID.PLR_WAFER_PORT_ID, Work.WorkMap.GetInstance().GetValue(Work.EN_WAFER_ITEM.PART_NAME));
                    break;
                default: return;
            }

           
            SecsGemSendEventEx(ceid, vidData);
            _timeForCeidSend.SetTickCount(100);	// 최소 인터벌 100ms
        }

        public void AddQueCeid(EN_CEID enCEID)
        {
            _queueCeidList.Enqueue(enCEID);
        }
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
