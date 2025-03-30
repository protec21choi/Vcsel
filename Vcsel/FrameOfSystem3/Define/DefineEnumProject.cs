using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define
{
	namespace DefineEnumProject
	{
		namespace Task
		{
			/// <summary>
			/// 2020.07.26 by yjlee [ADD] Enumerate the status fo the task.
			/// </summary>
			public enum EN_TASK_STATUS
			{
				DISABLED = 0,        // 사용 안함
				UNABLED,             // 사용 불가
				EMPTY,               // 자재 없음
				EXIST,               // 자재 있음
				EXIST_FULL,          // 자재 가득 참
				WORKING,             // 작업 진행 중
				FINISH,              // 작업 완료
			}

			/// <summary>
			/// 2020.07.29 by yjlee [ADD] Enumerate the devices of the task.
			/// </summary>
			public enum EN_TASK_DEVICE
			{
				MOTION = 0,
				CYLINDER,
				ANALOG_INPUT,
				ANALOG_OUPUT,
				DIGITAL_INPUT,
				DIGITAL_OUTPUT,
			}

			public enum EN_TASK_LIST
			{
                BOND_HEAD,
                TRANSFER,
                WORK_ZONE,
			}

			public enum EN_MOTION_ALARM_TYPE
			{
				CATEGORY,
				INTERLOCK,
			}
			public enum EN_SOFT_STEP_TYPE
			{
				PRE,	// 첫 움직임이 slow
				POST,	// 마지막 움직임이 slow
				DUAL,	// 앞, 뒤로 모두 slow
			}

            namespace BondHead
            {
                #region Analog Input
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Analog Input list of the task.
                /// </summary>
                public enum EN_ANALOG_INPUT_LIST
                {
                    LD_POWER_1 = 1,
                    LD_POWER_2 = 2,
                    LD_POWER_3 = 3,
                    LD_POWER_4 = 4,
                    LD_POWER_5 = 5,
                    LD_POWER_6 = 6,

                    LD_POWER_7 = 7,
                    LD_POWER_8 = 8,
                    LD_POWER_9 = 9,
                    LD_POWER_10 = 10,
                    LD_POWER_11 = 11,
                    LD_POWER_12 = 12,

                    LD_POWER_13 = 13,
                    LD_POWER_14 = 14,
                    LD_POWER_15 = 15,
                    LD_POWER_16 = 16,
                    LD_POWER_17 = 17,
                    LD_POWER_18 = 18,

                    TEMP_SENSOR_1 = 19,
                    TEMP_SENSOR_2 = 20,
                    TEMP_SENSOR_3 = 21,
                    TEMP_SENSOR_4 = 22,
                    TEMP_SENSOR_5 = 23,

                    BLOCK_VAC = 24,
                    HEAD_TOTAL_FLOW = 25,
                    HEAD_LEFT_FLOW = 26,
                    HEAD_RIGHT_FLOW = 27,

                }
                #endregion

                #region Analog Output
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Analog Output list of the task.
                /// </summary>
                public enum EN_ANALOG_OUTPUT_LIST
                {
                }
                #endregion

                #region Digital Input
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Digital Input list of the task.
                /// </summary>
                public enum EN_DIGITAL_INPUT_LIST
                {
                    LD_READY_PORT_1 = 1,
                    LD_ON_PORT_1 = 2,
                    LD_ALARM_PORT_1 = 3,

                    LD_READY_PORT_2 = 4,
                    LD_ON_PORT_2 = 5,
                    LD_ALARM_PORT_2 = 6,

                    LD_READY_PORT_3 = 7,
                    LD_ON_PORT_3 = 8,
                    LD_ALARM_PORT_3 = 9,
                }
                #endregion

                #region Digital Output
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Digital Output list of the task.
                /// </summary>
                public enum EN_DIGITAL_OUTPUT_LIST
                {
                    LD_ON_PORT_1 = 1,
                    LD_READY_PORT_1 = 2,
                    LD_ALARM_CLEAR_PORT_1 = 3,
                    LD_EMO_PORT_1 = 4,

                    LD_ON_PORT_2 = 5,
                    LD_READY_PORT_2 = 6,
                    LD_ALARM_CLEAR_PORT_2 = 7,
                    LD_EMO_PORT_2 = 8,

                    LD_ON_PORT_3 = 9,
                    LD_READY_PORT_3 = 10,
                    LD_ALARM_CLEAR_PORT_3 = 11,
                    LD_EMO_PORT_3 = 12,

                    LD_MONITOR_EMO = 13,
                    LD_MONITOR_ALARM_CLEAR = 14,
                }
                #endregion

                #region Cylinder
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Cylinder list of the task.
                /// </summary>
                public enum EN_CYLINDER_LIST
                {
                    POWERMETER = 1,
                }
                #endregion

                #region Axis
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Axis list of the task.
                /// </summary>
                public enum EN_AXIS_LIST
                {
                    HEAD_X = 1,
                    HEAD_Y = 2,
                    BLOCK_Z = 3,
                    POWERMETER_X = 4,
                }
                #endregion

                #region Parameter
                /// <summary>
                /// 2020.06.02 by yjlee [ADD] Define the parameters in process of this task.
                /// </summary>
                public enum PARAM_PROCESS
                {
                    #region LASER PARAMETER

                    SHOT_PARAMETER_ENABLE_18,

                    SHOT_PARAMETER_STEP_TIME_5,
                    SHOT_PARAMETER_STEP_POWER_5,

                    SHOT_PARAMETER_TOTAL_POWER,

                    // 2025.3.11 by ecchoi [ADD] Laser 2
                    SHOT_PARAMETER_2_ENABLE_18,

                    SHOT_PARAMETER_2_STEP_TIME_5,
                    SHOT_PARAMETER_2_STEP_POWER_5,

                    SHOT_PARAMETER_2_TOTAL_POWER,
                    #endregion


                    // 2025.3.12 by ecchoi [ADD] Parameter 이동 (Equipment -> Process)
                    #region Laser
                    LASER_SETTING_DELAY,
                    #endregion

                    #region Bond Head Calibration
                    #endregion

                    //#region AVOID POSITION
                    //HEAD_READY_POSITION_X,
                    //HEAD_READY_POSITION_Y,
                    //#endregion /AVOID POSITION

                    //#region HEATER PARAMETER
                    //WORK_BLOCK_TOLERANCE_MIN,
                    //WORK_BLOCK_TOLERANCE_MAX,

                    //WORK_BLOCK_CH_OFFSET_8,
                    //#endregion /HEATER PARAMETER

                    #region CALIBRATION
                    POWER_CALIBRATION_MAX_VOLT,
                    POWER_CALIBRATION_MIN_VOLT,

                    POWER_CALIBRATION_STEP_COUNT,

                    // 2025.3.11 by ecchoi [ADD] Laser 2
                    POWER_CALIBRATION_2_MAX_VOLT,
                    POWER_CALIBRATION_2_MIN_VOLT,

                    POWER_CALIBRATION_2_STEP_COUNT,
                    #endregion

                    #region POWER MEASURE
                    POWER_MEASURE_SELLECTED_CHANNEL, //측정할 때 측정 위치 결정 

                    //POWER_MEASURE_BLOCK_AVOID_POSITION_X,
                    //POWER_MEASURE_HEAD_AVOID_POSITION_Y,

                    //POWERMETER_READY_POSITION_X,
                    //POWERMETER_READY_POSITION_Y,

                    //POWER_MEASURE_POSITION_X_18,
                    //POWER_MEASURE_POSITION_Y_18,

                    POWER_MEASURE_CHANNEL_ENABLE_18,

                    POWER_MEASURE_WATT,
                    POWER_MEASURE_VOLT,

                    POWER_MEASURE_SHOT_TIME,
                    POWER_MEASURE_WAIT_TIME,

                    POWER_MEASURE_REPEAT_COUNT,
                    POWER_MEASURE_REST_TIME,

                    // 2025.3.11 by ecchoi [ADD] Laser 2
                    POWER_MEASURE_2_SELLECTED_CHANNEL, //측정할 때 측정 위치 결정 

                    POWER_MEASURE_2_CHANNEL_ENABLE_18,

                    POWER_MEASURE_2_WATT,
                    POWER_MEASURE_2_VOLT,

                    POWER_MEASURE_2_SHOT_TIME,
                    POWER_MEASURE_2_WAIT_TIME,

                    POWER_MEASURE_2_REPEAT_COUNT,
                    POWER_MEASURE_2_REST_TIME,
                    #endregion

                }
                #endregion

                #region Action
                public enum EN_TASK_ACTION
                {
                    STOP = 0,

                    #region AUTO

                    LASER_WORK,

                    #endregion

                    #region MANUAL
                    CALIBRATION_CHANNEL_POWER,
                    CALIBRATION_POWER_LOSS_RATE,
                    MEASURE_POWER,
                    MEASURE_VOLT,

                    SHORT_TEST,

                    MOVE_READY,
                    #endregion
                }

                public enum EN_PORT_LIST
                {
                    WORK_PORT,             
                }
                #endregion

                #region Alarm
                public enum EN_TASK_ALARM
                {
                    LASER_EMISSION_ALARM = 1,
                    INTERLOCK_TIMEOUT = 2,
                    LD_COMMNUNICATION_TIMEOUT = 3,
                    MATERIAL_NOT_EXIST = 4,
                    LASER_SETTING_FAIL = 5,
                    IR_COMMNUNICATION_ALARM = 6,
                    WORK_RESULT_FAIL = 7,
                    HEAD_FLOW_LOW = 8,
                    HEATER_TEMP_TOL_OVER = 9,
                    SHORT_CHECK_FAIL = 10,
                    IR_ALARM = 11,
                    CHILLER_ALARM = 12,
                    MOVE_FAIL = 13
                }
                public enum EN_TASK_ALARM_MESSAGE_EN
                {

                }
                public enum EN_TASK_ALARM_MESSAGE_KR
                {

                }

                #endregion
            }

            namespace WorkZone
            {
                #region Analog Input
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Analog Input list of the task.
                /// </summary>
                public enum EN_ANALOG_INPUT_LIST
                {
                    BLOCK_MATERIAL_VAC = 1,
                    PLATE_BLOCK_VAC,
                    LIFT_MATERIAL_VAC,
                }
                #endregion

                #region Analog Output
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Analog Output list of the task.
                /// </summary>
                public enum EN_ANALOG_OUTPUT_LIST
                {
                 
                }
                #endregion

                #region Digital Input
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Digital Input list of the task.
                /// </summary>
                public enum EN_DIGITAL_INPUT_LIST
                {
                    WARPAGE_PUSHER_DETECT = 1,
                }
                #endregion

                #region Digital Output
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Digital Output list of the task.
                /// </summary>
                public enum EN_DIGITAL_OUTPUT_LIST
                {
                    BLOCK_MATERIAL_VAC_1 = 1,
                    BLOCK_MATERIAL_VAC_2,
                    BLOCK_MATERIAL_BLOW,
                    PLATE_BLOCK_VAC,
                    LIFT_MATERIAL_VAC,
                }
                #endregion

                #region Cylinder
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Cylinder list of the task.
                /// </summary>
                public enum EN_CYLINDER_LIST
                {
                    WARPAGE_PUSHER = 1,
                }
                #endregion

                #region Axis
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Axis list of the task.
                /// </summary>
                public enum EN_AXIS_LIST
                {
                    BLOCK_Z = 1,
                    BLOCK_X,
                    HEAD_Y,
                    LIFT_Z,
                }
                #endregion

                #region Parameter
                /// <summary>
                /// 2020.06.02 by yjlee [ADD] Define the parameters in process of this task.
                /// </summary>
                public enum PARAM_PROCESS
                {
                    BLOCK_TRANSFER_POSITION_Z,

                    BLOCK_READY_POSITION_Z,
                    BLOCK_WORK_POSITION_Z,

                    BLOCK_TRANSFER_POSITION_X,
                    BLOCK_WARPAGE_PRESS_POSITION_X,
                    HEAD_WARPAGE_PRESS_POSITION_Y,

                    LIFT_TRANSFER_POSITION_Z,
                    LIFT_READY_POSITION_Z,

                    BLOCK_MATERIAL_VAC_THRESHOLD,
                    BLOCK_MATERIAL_VAC_TIMELAG_DELAY,
                    BLOCK_MATERIAL_VAC_ON_DELAY,
                    BLOCK_MATERIAL_VAC_OFF_DELAY,

                    LIFT_MATERIAL_VAC_THRESHOLD,
                    LIFT_MATERIAL_VAC_ON_DELAY,
                    LIFT_MATERIAL_VAC_OFF_DELAY,

                    HEATER_TARGET_TEMP,
                    HEATER_OFFSET_TEMP,

                    WARPAGE_PRESS_USED,
                    WARPAGE_PRESS_TIME,
                }
                #endregion

                #region Action
                public enum EN_TASK_ACTION
                {
                    STOP = 0,

                    #region AUTO

                    LOADING,
                    UNLOADING,

                    #endregion

                    #region Manual
                    MANUAL_LOADING,
                    MATERIAL_RELEASE,
                    #endregion

                }

           
                public enum EN_PORT_LIST
                {
                    WORK_PORT,
                }
                #endregion

                #region Alarm
                public enum EN_TASK_ALARM
                {
                    MAETRIAL_NOT_EXIST = 1,
                    STATUS_MISMATCH = 2,
                    INTERLOCK_TIMEOUT = 3,
                    VAC_CHECK_FAIL = 4,
                    MOVE_FALE = 5,
                }
                public enum EN_TASK_ALARM_MESSAGE_EN
                {

                }
                public enum EN_TASK_ALARM_MESSAGE_KR
                {

                }

                #endregion
            }

            //우선 하나로 하자 추후 필요시 IN,OUT 분리
            namespace Transfer
            {
                #region Analog Input
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Analog Input list of the task.
                /// </summary>
                public enum EN_ANALOG_INPUT_LIST
                {
                    HANDLER_MATERIAL_VAC = 1,
                    LIFT_MATERIAL_VAC,
                    BLOCK_MATERIAL_VAC,
                }
                #endregion

                #region Analog Output
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Analog Output list of the task.
                /// </summary>
                public enum EN_ANALOG_OUTPUT_LIST
                {

                }
                #endregion

                #region Digital Input
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Digital Input list of the task.
                /// </summary>
                public enum EN_DIGITAL_INPUT_LIST
                {
                    PRE_SMEMA_PORT1 = 1,
                    PRE_SMEMA_PORT2,
                    POST_SMEMA_PORT1,
                    POST_SMEMA_PORT2,
                    PRE_SMEMA_SUB_PORT1,
                    PRE_SMEMA_SUB_PORT2,
                }
                #endregion

                #region Digital Output
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Digital Output list of the task.
                /// </summary>
                public enum EN_DIGITAL_OUTPUT_LIST
                {
                    HANDLER_MATERIAL_VAC = 1,
                    HANDLER_MATERIAL_BLOW,
                    LIFT_MATERIAL_VAC,
                    PRE_SMEMA_PORT_1,
                    PRE_SMEMA_PORT_2,
                    POST_SMEMA_PORT_1,
                    POST_SMEMA_PORT_2,
                    PRE_SMEMA_SUB_PORT_1,
                    PRE_SMEMA_SUB_PORT_2,
                    BLOCK_MATERIAL_VAC_1,
                    BLOCK_MATERIAL_VAC_2,
                    BLOCK_MATERIAL_BLOW,
                }
                #endregion

                #region Cylinder
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Cylinder list of the task.
                /// </summary>
                public enum EN_CYLINDER_LIST
                {
                    WARPAGE_PUSHER = 1,
                }
                #endregion

                #region Axis
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Axis list of the task.
                /// </summary>
                public enum EN_AXIS_LIST
                {
                    HANDLER_X = 1,
                    HANDLER_Y,
                    HANDLER_Z,
                    HANDLER_R,
                    BLOCK_X,
                    BLOCK_Z,
                    LIFT_Z,
                }
                #endregion

                #region Parameter
                /// <summary>
                /// 2020.06.02 by yjlee [ADD] Define the parameters in process of this task.
                /// </summary>
                public enum PARAM_PROCESS
                {
                    HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2,
                    HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_X_2,
                    HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2,
                    HANDLER_PRE_EQUIPMENT_TRANSFER_UP_POSITION_Z_2,
                    HANDLER_PRE_EQUIPMENT_TRANSFER_CONTACT_POSITION_Z_2,
                    HANDLER_PRE_EQUIPMENT_TRANSFER_DOWN_POSITION_Z_2,
                    HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_R,

                    HANDLER_WORKBLOCK_TRANSFER_POSITION_X,
                    HANDLER_WORKBLOCK_TRANSFER_POSITION_Y,
                    HANDLER_WORKBLOCK_TRANSFER_UP_POSITION_Z,
                    HANDLER_WORKBLOCK_TRANSFER_CONTACT_POSITION_Z,
                    HANDLER_WORKBLOCK_TRANSFER_DOWN_POSITION_Z,
                    HANDLER_WORKBLOCK_TRANSFER_POSITION_R,

                    HANDLER_MATERIAL_VAC_THRESHOLD,
                    HANDLER_MATERIAL_VAC_ON_DELAY,
                    HANDLER_MATERIAL_VAC_OFF_DELAY,
                    HANDLER_MATERIAL_BLOW_USED,

            
                }
                #endregion

                #region Action
                public enum EN_TASK_ACTION
                {
                    STOP = 0,

                    #region AUTO
                    EQUIPMENT_LOADING,
                    BLOCK_LOADING,

                    BLOCK_UNLOADING,
                    EQUIPMENT_UNLOADING,
                    #endregion

                    #region MANUAL
                    MOVE_AVOID,
                    #endregion
                }

                public enum EN_PORT_LIST
                {
                    WORK_PORT,
                }
                #endregion

                #region Alarm
                public enum EN_TASK_ALARM
                {
                    MAETRIAL_NOT_EXIST = 1,
                    MAETRIAL_EXIST = 2,
                    MOVE_FAIL = 3,
                    STATUS_MISMATCH = 4,
                    INTERLOCK_TIMEOUT = 5,
                    VAC_CHECK_FAIL = 6,
                    RECOVERY_STATUS_ALARM = 7,
                    COMMUNICATION_TIMEOUT = 8,
                    COMMUNICATION_ALARM = 9,
                }
                public enum EN_TASK_ALARM_MESSAGE_EN
                {

                }
                public enum EN_TASK_ALARM_MESSAGE_KR
                {

                }
                public enum EN_SYSTEM_ALARM
                {
                    HOST_CONNECTION_ALARM
                }
                #endregion
                }
		}

		namespace Map
		{
            public enum EN_REFERANCE_MAP_LIST
            {
                MATERIAL_BOND,
                PROCESS_BONDING_LASER,
            }

            public enum EN_WORK_MAP_LIST
            {
                INPUT,
                WORK,
                OUTPUT,
            }

			public enum EN_MAP_TYPE
			{
				SAMPLE,
			}
			public enum EN_UNIT_STATUS
			{
				NONE,           // Map 생성 시 사용하지 않는 영역
				EMPTY,
				REFERENCE,
				SKIP,
				WAIT,           // 작업 가능
				IDCODE,
				ALIGN,
				INSP,
				REJECT,         // 비전 인식 불량
				STACK,
				DONE,           // 작업 완료
				FAIL            // 작업 실패
			}
			public enum EN_WORK_START_POINT
			{
				LEFT_TOP,
				LEFT_BOTTOM,
				RIGHT_TOP,
				RIGHT_BOTTOM,
			}
			public enum EN_WORK_DIRECTION
			{
				HORIZONTAL_ONEWAY,
				HORIZONTAL_ZIGZAG,
				VERTICAL_ONEWAY,
				VERTICAL_ZIGZAG,
			}

            public enum EN_SUBJECT_INFO
            {
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
            }
		}

		// 2021.07.13. by shkim. [ADD] 비전관련Enum
		namespace Vision
		{
			public enum EN_CAMERA_LIST
			{
				CAM1 = 0,
			}
			public enum EN_VISION_ALGORITHM
			{
				NONE = -1,
				SAMPLE = 0,
			}
			public enum EN_TARGET_LAYER
			{
				ALIGN = 0,
			}
			public enum EN_VISION_CALIBRATION_SCENE
			{
				RESOLUTION_FRONT = 0,
				DISTORTION_FRONT,
				RESOLUTION_REAR,
				DISTORTION_REAR,
			}
			public enum EN_VISION_CALIBRATION_MODE
			{
				RESOLUTION = 0,
				DISTORTION = 2,
			}
			public enum EN_VISION_RESULT_TYPE
			{
				XYT = 0,
				BARCODE,
			}
		}

		namespace ButtonEvent
		{
			/// <summary>
			/// 2020.02.05 by yjlee [ADD] Enumerate the names of the sub menus.
			/// A button will be added to the view if you add a name to the enum.
			/// </summary>
			public enum EN_BUTTONEVENT_SUBMENU
			{
				OPERATION_MAIN,
                OPERATION_IR_MONITOR,
                OPERATION_CAL_MONITOR,
                //OPERATION_MANUAL,
                OPERATION_STATE_MONITOR,
                //OPERATION_RAM_METRICS,

                RECIPE_MAIN,
				//RECIPE_OPTIONS,

				HISTORY_MAIN_LOG,

                SETUP_WORK,
                //SETUP_TRANSFER,
                //SETUP_EQUIPMENT,
                //SETUP_MONITOR,
                //SETUP_JOG,

				CONFIG_MOTION,
				CONFIG_ANALOG,
				CONFIG_DIGITAL,
				CONFIG_CYLINDER,
				CONFIG_ALARM,
				CONFIG_INTERRUPT,
				CONFIG_LANGUAGE,
				CONFIG_TRIGGER,

				CONFIG_COMMUNICATION,
				CONFIG_ACTION,
				CONFIG_INTERLOCK,
				CONFIG_TOOL,     
				CONFIG_JOG,
				CONFIG_DEVICE,
				CONFIG_PARAMETERS,
			}
		}

		namespace SelectionList
		{
			/// <summary>
			/// 2020.06.05 by twkang [ADD] Selection List 에 사용하는 열거형이다.
			/// </summary>
			public enum EN_SELECTIONLIST
			{
				NONE = 0,
				#region base
				ENABLE_DISABLE,

				TRUE_FALSE,

				LOG_TYPE,
				USER_AUTHORITY,

				DEVICE_TYPE,

				EQUIPMENT_STATE,
				OPERATION_EQUIPMENT,

				CYLINDER_MONITORING_MODE,

				SOCKET_PROTOCOL_TYPE,
				SOCKET_LOG_TYPE,

				SERIAL_DATA_BIT,
				SERIAL_BAUDRATE,
				SERIAL_STOPBIT,
				SERIAL_PARITY,
				SERIAL_LOG_TYPE,

				INTERRUPT_ACTION,

				ALARM_STATE,

				MOTION_MOTOR_TYPE,
				MOTION_MOTION_TYPE,
				MOTION_MOTOR_DIRECTION,
				MOTION_LIMIT_STOP_MODE,
				MOTION_LOGIC,
				MOTION_HOME_MODE,
				MOTION_HOME_DIRECTION,
				MOTION_SPEED_PATTERN,

				MOTION_INMODE,
				MOTION_OUTMODE,

				ACTION_LOGIC,
				ACTION_COMPARE_STATE,

				PORT_STATUS,
				RECIPE_TYPE,

				VISION_CAMERA_LIST,    // 2021.07.13. by shkim [ADD] 비전 카메라 리스트
				ALIGN_CAMERA_SCENE,

				INTERLOCK_COMPARE_DEVICE,
				MOTION_COMPARE_DIRECTION,
				CYLINDER_COMPARE_DIRECTION,
				MOTION_MOVING_DIRECTION,
				LANGUAGE,
				VISION_CALIBRATION_MODE,
				VISION_CALIBRATION_SCENE,
				FORWARD_BACKWARD,
				TASK_LIST,
				ANALOG_DATA_TYPE,   // 2022.11.04. by shkim. [ADD] Raw data type에 따른 계산과정 추가
				MATRIX,
				#endregion /base

				// PROJECT ONLY
				#region project only
				WORK_DIRECTION,
				WORK_START_POINT,
				WARPAGE_TYPE,
				WORK_STATUS,
				SUBJECT_ANGLE,

				FLUX_CLEANING_TYPE,
				FLUX_CLEANING_DIRECTION,
				ALIGN_POINT_TYPE,
				#endregion project only
			}
		}

		namespace Socket
		{
			/// <summary>
			/// 2020.11.14 by yjlee [ADD] Enumerate the index of the socket.
			/// </summary>
			public enum EN_SOCKET_INDEX
			{
				LOG = 0,
				IR = 1,
                VISION = 2,
			}

            public enum EN_WCF_INDEX
			{
				PRE_EQUIPMENT = 0,
			}
		}

		namespace Serial
		{
			public enum EN_SERIAL_INDEX
			{
                HEATER = 0,
                LD_CONTROL_1 = 1,
                LD_CONTROL_2 = 2,
                LD_CONTROL_3 = 3,
                LD_MONITOR = 4,
                POWERMETER = 5,
                MODBUS_CHILLER = 6,
                FFU = 7,
                // 2025.3.11 by ecchoi [ADD] Laser 2
                LD_2_CONTROL_1 = 8,
                LD_2_CONTROL_2 = 9,
                LD_2_CONTROL_3 = 10,
                LD_2_MONITOR = 11,

            }
		}

		namespace DigitalIO
		{
			public enum EN_DIGITAL_IN
			{
				NONE = 0,					// > X00

                DOOR_LOCK_1 = 8,
                DOOR_LOCK_2 = 9,

                PRE_SMEMA_SUB_PORT1 = 14,
                PRE_SMEMA_SUB_PORT2 = 15,
                
                WAFER_DETECT = 18,

                COVER_1 = 26,
                COVER_2 = 27,

                PRE_SMEMA_PORT1 = 40,
                POST_SMEMA_PORT1 = 41,
                PRE_SMEMA_PORT2 = 42,
                POST_SMEMA_PORT2 = 43,

                LD_1_READY = 44,
                LD_1_ALARM = 45,
                LD_1_ON = 46,

                LD_2_READY = 49,
                LD_2_ALARM = 50,
                LD_2_ON = 51,

                LD_3_READY = 54,
                LD_3_ALARM = 55,
                LD_3_ON = 56,

                MONITOR_ALARM = 60,

                // 2025.3.11 by ecchoi [ADD] Laser No.2
                LD_1_READY_2 = 144,
                LD_1_ALARM_2 = 145,
                LD_1_ON_2 = 146,

                LD_2_READY_2 = 149,
                LD_2_ALARM_2 = 150,
                LD_2_ON_2 = 151,

                LD_3_READY_2 = 154,
                LD_3_ALARM_2 = 155,
                LD_3_ON_2 = 156,

                MONITOR_ALARM_2 = 160
            }

			public enum EN_DIGITAL_OUT
			{
				NONE = 0,

                BUZZER = 3,

                DOOR_MAGNETIC_1 = 4,

                DOOR_LOCK_1 = 8,
                DOOR_LOCK_2 = 9,

                LASER_GUIDE = 12,

                DOOR_MAGNETIC_2 = 13,

                PRE_SMEMA_SUB_PORT1 = 14,
                PRE_SMEMA_SUB_PORT2 = 15,

                BLOCK_MATERIAL_BLOW = 22,
                LIFT_MATERIAL_VAC = 23,

                BLOCK_MATERIAL_VAC_1 = 24,
                BLOCK_MATERIAL_VAC_2 = 25,

                PLATE_BLOCK_VAC = 26,

                HANDLER_MATERIAL_BLOW = 32,
                HANDLER_MATERIAL_VAC = 33,

                PRE_SMEMA_PORT1 = 40,
                POST_SMEMA_PORT1 = 41,
                PRE_SMEMA_PORT2 = 42,
                POST_SMEMA_PORT2 = 43,

                LD_1_ALARM_CLEAR = 44,
                LD_1_EMO = 45,
                LD_1_ON = 46,
                LD_1_READY = 47,

                LD_2_ALARM_CLEAR = 49,
                LD_2_EMO = 50,
                LD_2_ON = 51,
                LD_2_READY = 52,

                LD_3_ALARM_CLEAR = 54,
                LD_3_EMO = 55,
                LD_3_ON = 56,
                LD_3_READY = 57,

                MONITOR_ALARM_CLEAR = 59,
                MONITOR_EMO = 60,

                // 2025.3.11 by ecchoi [ADD] Laser No.2
                LD_1_ALARM_CLEAR_2 = 144,
                LD_1_EMO_2 = 145,
                LD_1_ON_2 = 146,
                LD_1_READY_2 = 147,

                LD_2_ALARM_CLEAR_2 = 149,
                LD_2_EMO_2 = 150,
                LD_2_ON_2 = 151,
                LD_2_READY_2 = 152,

                LD_3_ALARM_CLEAR_2 = 154,
                LD_3_EMO_2 = 155,
                LD_3_ON_2 = 156,
                LD_3_READY_2 = 157,

                MONITOR_ALARM_CLEAR_2 = 159,
                MONITOR_EMO_2 = 160,
            }
		}

		namespace AnalogIO
		{
			public enum EN_ANALOG_IN
			{
                POWER_CH_1 = 0,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_2 = 1,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_3 = 2,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_4 = 3,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_5 = 4,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_6 = 5,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_7 = 6,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_8 = 7,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_9 = 8,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_10 = 9,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_11 = 10,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_12 = 11,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_13 = 12,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_14 = 13,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_15 = 14,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_16 = 15,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_17 = 16,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_CH_18 = 17,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v

                POWER_2_CH_1 = 40,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_2 = 41,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_3 = 42,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_4 = 43,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_5 = 44,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_6 = 45,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_7 = 46,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_8 = 47,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_9 = 48,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_10 = 49,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_11 = 50,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_12 = 51,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_13 = 52,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_14 = 53,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_15 = 54,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_16 = 55,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_17 = 56,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_18 = 57,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v

                MAIN_AIR = 24,
                MAIN_VAC = 25,
                BLOCK_MATERIAL_VAC = 26,
                PLATE_BLOCK_VAC = 27,
                LIFT_MATERIAL_VAC = 28,
                HANDLER_MATERIAL_VAC = 29,

                TEMP_CH_1 = 32,
                TEMP_CH_2 = 33,
                TEMP_CH_3 = 34,
                TEMP_CH_4 = 35,
                TEMP_CH_5 = 36,

                HEAD_TOTAL_FLOW = 37,
                HEAD_LEFT_FLOW = 38,
                HEAD_RIGHT_FLOW = 39,

                IR_SENSOR_1 = 40,
                IR_SENSOR_2 = 41,
                IR_SENSOR_3 = 42,
                IR_SENSOR_4 = 43,
            }
			public enum EN_ANALOG_OUT
			{
				NONE = 0,		// 0V ~ 5V				// SCALE RANGE (16bit) -10V ~ +10V
			}
		}

		namespace Cylinder
		{
			public enum EN_CYLINDER
			{
				NONE = -1,

                WARPAGE_PRESS = 0,
                POWERMETER = 1,
			}
		}

		namespace Motion
		{
			public enum EN_AXIS
			{
				NONE = -1,

                GANTRY_Y = 0,
                BLOCK_X = 1,
                BLOCK_Z = 2,
                LIFT_Z = 3,
                HANDLER_Y = 4,
                HANDLER_X = 5,
                HANDLER_Z = 6,
                HANDLER_R = 7,
                POWERMETER_X = 8,
			}
		}

		namespace Tool
		{
			public enum EN_WORK_TOOL
			{
                LD_EMITTER_CH_1 = 0,		
                LD_EMITTER_CH_2 = 1,		
                LD_EMITTER_CH_3 = 2,		
                LD_EMITTER_CH_4 = 3,		
                LD_EMITTER_CH_5 = 4,		
                LD_EMITTER_CH_6 = 5,		
                LD_EMITTER_CH_7 = 6,		
                LD_EMITTER_CH_8 = 7,		
                LD_EMITTER_CH_9 = 8,		
                LD_EMITTER_CH_10 = 9,		
                LD_EMITTER_CH_11 = 10,		
                LD_EMITTER_CH_12 = 11,		
                LD_EMITTER_CH_13 = 12,		
                LD_EMITTER_CH_14 = 13,		
                LD_EMITTER_CH_15 = 14,		
                LD_EMITTER_CH_16 = 15,		
                LD_EMITTER_CH_17 = 16,		
                LD_EMITTER_CH_18 = 17,		
                LD_GLASS = 18,		        
			}
		}

        namespace SubSequence
        {
            public enum EN_MOTION_CONTROL_TYPE
            {
                ABSOLUTELY,
                RELEATIVELY,
                SPEED,
                OVERRIDE,
            }
            public enum EN_SUBSEQUENCE_RESULT
            {
                OK,
                WORKING,

                // Error 목록
                ERROR,
                ERROR_READY,
                ERROR_COMMAND,
                ERROR_VISION,
                ERROR_MOTION,
                ERROR_TIMEOUT,
                ERROR_PARAMETER,

            }

            namespace Laser
            {
                public enum EN_SEQUENCE_BRANCH
                {
                    INITIALIZE,

                    LASER_SHOT,

                    LASER_SHOT_KEEP_DEVICE_READY,

                    MANUAL_READY_DEVICE,
                    MANUAL_END_DEVICE,

                }
                public enum EN_OUTPUT_TYPE
                {
                    AJIN_ANALOG,
                    MEI_ANALOG,
                    MEI_PROFILE,
                    PROTEC_SERIAL,
                }
                public enum EN_DEVICE_TYPE
                {
                    LASER_LINE,
                    IPG,
                    PROTEC_LD,
                }
            }

            namespace Vision
            {
                public enum EN_SEQUENCE_BRANCH
                {
                    // 네이밍 다시 해야함
                    NORMAL_ACTION,

                    // 드라이런에서 그랩만 요청하고 끝내는경우
                    END_AFTER_GRAB,

                    //
                    CALCULATE_REFERENCE_ANGLE,
                }

            }

            namespace PickPlace
            {
                public enum EN_PLACE_DOWN_SUB_SEQ_BRANCH
                {
                    NORMAL_ACTION,

                    PLACE_DOWN,
                    RELEASE_UP,

                    MOTION_DOWN,
                    MOTION_UP,
                }
            }
        }

		namespace Mail
		{
			public enum EN_SUBSCRIBER
			{
				Unknown,

				OPERATION_MAIN,
				OPERATION_PROCESS,
				OPERATION_IOMONITOR,
                SETUP_EQUP_LASER,

                PRE_EQUIPMENT_WCF,

                TASK_TRANSFER,
                TASK_BONDHEAD,

                EFEM_MANAGER
			}
			public enum EN_MAIL
			{
				INIT_MAIL,
				CHECK_MAIL,
				UI_ShowMessageBox,

                UPDATE_UI,

                WCF_ACK,
                WCF_RESOPONE,
                WCF_RECEIVE,

                SendScenario,
                SendSecsGemCEID,

                POWERMETEER_HOME_DONE,
			}
		}

        namespace Laser
        {
            public enum EN_OUTPUT_MODE
            {
                STEP,
                LINEAR
            }

            namespace Power
            {
                /// <summary>
                /// 2020.08.27 by ssh [ADD] Enumerate the power mode for laser operation.
                /// </summary>

                public enum EN_MONITORING_TYPE
                {
                    INPUT_KEY,
                    INPUT_VALUE,
                    OUTPUT_KEY,
                    OUTPUT_VALUE,
                    FEEDBACK_KEY,
                    FEEDBACK_VALUE,
                }
            }

            /// <summary>
            /// 2020.09.02 by ssh [ADD] Enumerate the laser digital input index.
            /// </summary>
            public enum EN_LASER_DIGITAL_INPUT
            {
                SAFETY = 0,
                WARNING = 1,
                SLEEP = 2,
                SHUTTER_ON = 3,
                SHUTTER_OFF = 4,
                READY = 5,
                ACTIVE = 6,

                COLLECTIVE_ERROR = 7,
            }

            public enum EN_LASER_ACTION_RESULT
            {
                OK,
                WORKING,
                NEXT_WORK_READY,

                // Error 목록
                ERROR,
            }
        }

        namespace Transfer
        {
            namespace Conveyor
            {
                public enum EN_STOP_MODE
                {
                    DETECT_SENSOR,
                    DELAY_TIME,
                }
            }
        }

        namespace Modbus
        {
            public enum EN_MODEBUSRTU_DEVICE
            {
                CHILLER_DOTECH_CX9230 = 1,
            }
        }

        namespace Heater
        {
            public enum EN_HEATER_ZONE_LIST
            {
                BLCOK = 1,
            }
        }
	}
}