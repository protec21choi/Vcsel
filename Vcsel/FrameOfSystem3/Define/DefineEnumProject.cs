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
                    LD_POWER_1 = 0,
                    LD_POWER_2 = 1,
                    LD_POWER_3 = 2,
                    LD_POWER_4 = 3,
                    LD_POWER_5 = 4,
                    LD_POWER_6 = 5,

                    LD_POWER_7 = 6,
                    LD_POWER_8 = 7,
                    LD_POWER_9 = 8,
                    LD_POWER_10 = 9,
                    LD_POWER_11 = 10,
                    LD_POWER_12 = 11,

                    LD_POWER_13 = 12,
                    LD_POWER_14 = 13,
                    LD_POWER_15 = 14,
                    LD_POWER_16 = 15,
                    LD_POWER_17 = 16,
                    LD_POWER_18 = 17,

                    LD_2_POWER_1 = 18,
                    LD_2_POWER_2 = 19,
                    LD_2_POWER_3 = 20,
                    LD_2_POWER_4 = 21,
                    LD_2_POWER_5 = 22,
                    LD_2_POWER_6 = 23,

                    LD_2_POWER_7 = 24,
                    LD_2_POWER_8 = 25,
                    LD_2_POWER_9 = 26,
                    LD_2_POWER_10 = 27,
                    LD_2_POWER_11 = 28,
                    LD_2_POWER_12 = 29,

                    LD_2_POWER_13 = 30,
                    LD_2_POWER_14 = 31,
                    LD_2_POWER_15 = 32,
                    LD_2_POWER_16 = 33,
                    LD_2_POWER_17 = 34,
                    LD_2_POWER_18 = 35,

                    IR_SENSOR_1 = 40,
                    IR_SENSOR_2 = 41,
                    IR_SENSOR_3 = 42,
                    IR_SENSOR_4 = 43,

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
                    LD_READY_PORT_1 = 16,
                    LD_ALARM_PORT_1 = 17,
                    LD_ON_PORT_1 = 18,

                    LD_READY_PORT_2 = 21,
                    LD_ALARM_PORT_2 = 22,
                    LD_ON_PORT_2 = 23,

                    LD_READY_PORT_3 = 26,
                    LD_ALARM_PORT_3 = 27,
                    LD_ON_PORT_3 = 28,

                    #region Laser #2
                    LD_2_READY_PORT_1 = 36,
                    LD_2_ALARM_PORT_1 = 37,
                    LD_2_ON_PORT_1 = 38,
                    
                    LD_2_READY_PORT_2 = 41,
                    LD_2_ALARM_PORT_2 = 42,
                    LD_2_ON_PORT_2 = 43,

                    LD_2_READY_PORT_3 = 46,
                    LD_2_ALARM_PORT_3 = 47,
                    LD_2_ON_PORT_3 = 48,
                    #endregion
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


                    #region Laser #2
                    LD_2_ON_PORT_1 = 15,
                    LD_2_READY_PORT_1 = 16,
                    LD_2_ALARM_CLEAR_PORT_1 = 17,
                    LD_2_EMO_PORT_1 = 18,

                    LD_2_ON_PORT_2 = 19,
                    LD_2_READY_PORT_2 = 20,
                    LD_2_ALARM_CLEAR_PORT_2 = 21,
                    LD_2_EMO_PORT_2 = 22,

                    LD_2_ON_PORT_3 = 23,
                    LD_2_READY_PORT_3 = 24,
                    LD_2_ALARM_CLEAR_PORT_3 = 25,
                    LD_2_EMO_PORT_3 = 26,

                    LD_2_MONITOR_EMO = 27,
                    LD_2_MONITOR_ALARM_CLEAR = 28,
                    
                    #endregion
                }
                #endregion

                #region Cylinder
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Cylinder list of the task.
                /// </summary>
                public enum EN_CYLINDER_LIST
                {
                    NONE = -1,
                }
                #endregion

                #region Axis
                /// <summary>
                /// 2020.09.10 by ssh [ADD] Enumerate the Axis list of the task.
                /// </summary>
                public enum EN_AXIS_LIST
                {
                    NONE = -1,
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
                    LASER_WORK_2,

                    #endregion

                    #region MANUAL
                    CALIBRATION_CHANNEL_POWER,
                    CALIBRATION_POWER_LOSS_RATE,
                    MEASURE_POWER,
                    MEASURE_VOLT,

                    SHORT_TEST,

                    CALIBRATION_CHANNEL_POWER_2,
                    CALIBRATION_POWER_LOSS_RATE_2,
                    MEASURE_POWER_2,
                    MEASURE_VOLT_2,

                    SHORT_TEST_2,

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
                    LD1_LASER_EMISSION_ALARM = 1,
                    LD1_COMMNUNICATION_TIMEOUT = 2,
                    LD1_LASER_SETTING_FAIL = 3,
                    LD1_SHORT_CHECK_FAIL = 4,

                    LD2_LASER_EMISSION_ALARM = 11,
                    LD2_COMMNUNICATION_TIMEOUT = 12,
                    LD2_LASER_SETTING_FAIL = 13,
                    LD2_SHORT_CHECK_FAIL = 14,
                }
                public enum EN_TASK_ALARM_MESSAGE_EN
                {

                }
                public enum EN_TASK_ALARM_MESSAGE_KR
                {

                }

                #endregion
            }

            //namespace WorkZone
            //{
            //    #region Analog Input
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Analog Input list of the task.
            //    /// </summary>
            //    public enum EN_ANALOG_INPUT_LIST
            //    {
            //        BLOCK_MATERIAL_VAC = 1,
            //        PLATE_BLOCK_VAC,
            //        LIFT_MATERIAL_VAC,
            //    }
            //    #endregion

            //    #region Analog Output
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Analog Output list of the task.
            //    /// </summary>
            //    public enum EN_ANALOG_OUTPUT_LIST
            //    {
                 
            //    }
            //    #endregion

            //    #region Digital Input
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Digital Input list of the task.
            //    /// </summary>
            //    public enum EN_DIGITAL_INPUT_LIST
            //    {
            //        WARPAGE_PUSHER_DETECT = 1,
            //    }
            //    #endregion

            //    #region Digital Output
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Digital Output list of the task.
            //    /// </summary>
            //    public enum EN_DIGITAL_OUTPUT_LIST
            //    {
            //        BLOCK_MATERIAL_VAC_1 = 1,
            //        BLOCK_MATERIAL_VAC_2,
            //        BLOCK_MATERIAL_BLOW,
            //        PLATE_BLOCK_VAC,
            //        LIFT_MATERIAL_VAC,
            //    }
            //    #endregion

            //    #region Cylinder
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Cylinder list of the task.
            //    /// </summary>
            //    public enum EN_CYLINDER_LIST
            //    {
            //        WARPAGE_PUSHER = 1,
            //    }
            //    #endregion

            //    #region Axis
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Axis list of the task.
            //    /// </summary>
            //    public enum EN_AXIS_LIST
            //    {
            //        BLOCK_Z = 1,
            //        BLOCK_X,
            //        HEAD_Y,
            //        LIFT_Z,
            //    }
            //    #endregion

            //    #region Parameter
            //    /// <summary>
            //    /// 2020.06.02 by yjlee [ADD] Define the parameters in process of this task.
            //    /// </summary>
            //    public enum PARAM_PROCESS
            //    {
            //        BLOCK_TRANSFER_POSITION_Z,

            //        BLOCK_READY_POSITION_Z,
            //        BLOCK_WORK_POSITION_Z,

            //        BLOCK_TRANSFER_POSITION_X,
            //        BLOCK_WARPAGE_PRESS_POSITION_X,
            //        HEAD_WARPAGE_PRESS_POSITION_Y,

            //        LIFT_TRANSFER_POSITION_Z,
            //        LIFT_READY_POSITION_Z,

            //        BLOCK_MATERIAL_VAC_THRESHOLD,
            //        BLOCK_MATERIAL_VAC_TIMELAG_DELAY,
            //        BLOCK_MATERIAL_VAC_ON_DELAY,
            //        BLOCK_MATERIAL_VAC_OFF_DELAY,

            //        LIFT_MATERIAL_VAC_THRESHOLD,
            //        LIFT_MATERIAL_VAC_ON_DELAY,
            //        LIFT_MATERIAL_VAC_OFF_DELAY,

            //        HEATER_TARGET_TEMP,
            //        HEATER_OFFSET_TEMP,

            //        WARPAGE_PRESS_USED,
            //        WARPAGE_PRESS_TIME,
            //    }
            //    #endregion

            //    #region Action
            //    public enum EN_TASK_ACTION
            //    {
            //        STOP = 0,

            //        #region AUTO

            //        LOADING,
            //        UNLOADING,

            //        #endregion

            //        #region Manual
            //        MANUAL_LOADING,
            //        MATERIAL_RELEASE,
            //        #endregion

            //    }

           
            //    public enum EN_PORT_LIST
            //    {
            //        WORK_PORT,
            //    }
            //    #endregion

            //    #region Alarm
            //    public enum EN_TASK_ALARM
            //    {
            //        MAETRIAL_NOT_EXIST = 1,
            //        STATUS_MISMATCH = 2,
            //        INTERLOCK_TIMEOUT = 3,
            //        VAC_CHECK_FAIL = 4,
            //        MOVE_FALE = 5,
            //    }
            //    public enum EN_TASK_ALARM_MESSAGE_EN
            //    {

            //    }
            //    public enum EN_TASK_ALARM_MESSAGE_KR
            //    {

            //    }

            //    #endregion
            //}

            ////우선 하나로 하자 추후 필요시 IN,OUT 분리
            //namespace Transfer
            //{
            //    #region Analog Input
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Analog Input list of the task.
            //    /// </summary>
            //    public enum EN_ANALOG_INPUT_LIST
            //    {
            //        HANDLER_MATERIAL_VAC = 1,
            //        LIFT_MATERIAL_VAC,
            //        BLOCK_MATERIAL_VAC,
            //    }
            //    #endregion

            //    #region Analog Output
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Analog Output list of the task.
            //    /// </summary>
            //    public enum EN_ANALOG_OUTPUT_LIST
            //    {

            //    }
            //    #endregion

            //    #region Digital Input
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Digital Input list of the task.
            //    /// </summary>
            //    public enum EN_DIGITAL_INPUT_LIST
            //    {
            //        PRE_SMEMA_PORT1 = 1,
            //        PRE_SMEMA_PORT2,
            //        POST_SMEMA_PORT1,
            //        POST_SMEMA_PORT2,
            //        PRE_SMEMA_SUB_PORT1,
            //        PRE_SMEMA_SUB_PORT2,
            //    }
            //    #endregion

            //    #region Digital Output
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Digital Output list of the task.
            //    /// </summary>
            //    public enum EN_DIGITAL_OUTPUT_LIST
            //    {
            //        HANDLER_MATERIAL_VAC = 1,
            //        HANDLER_MATERIAL_BLOW,
            //        LIFT_MATERIAL_VAC,
            //        PRE_SMEMA_PORT_1,
            //        PRE_SMEMA_PORT_2,
            //        POST_SMEMA_PORT_1,
            //        POST_SMEMA_PORT_2,
            //        PRE_SMEMA_SUB_PORT_1,
            //        PRE_SMEMA_SUB_PORT_2,
            //        BLOCK_MATERIAL_VAC_1,
            //        BLOCK_MATERIAL_VAC_2,
            //        BLOCK_MATERIAL_BLOW,
            //    }
            //    #endregion

            //    #region Cylinder
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Cylinder list of the task.
            //    /// </summary>
            //    public enum EN_CYLINDER_LIST
            //    {
            //        WARPAGE_PUSHER = 1,
            //    }
            //    #endregion

            //    #region Axis
            //    /// <summary>
            //    /// 2020.09.10 by ssh [ADD] Enumerate the Axis list of the task.
            //    /// </summary>
            //    public enum EN_AXIS_LIST
            //    {
            //        HANDLER_X = 1,
            //        HANDLER_Y,
            //        HANDLER_Z,
            //        HANDLER_R,
            //        BLOCK_X,
            //        BLOCK_Z,
            //        LIFT_Z,
            //    }
            //    #endregion

            //    #region Parameter
            //    /// <summary>
            //    /// 2020.06.02 by yjlee [ADD] Define the parameters in process of this task.
            //    /// </summary>
            //    public enum PARAM_PROCESS
            //    {
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2,
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_X_2,
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2,
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_UP_POSITION_Z_2,
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_CONTACT_POSITION_Z_2,
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_DOWN_POSITION_Z_2,
            //        HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_R,

            //        HANDLER_WORKBLOCK_TRANSFER_POSITION_X,
            //        HANDLER_WORKBLOCK_TRANSFER_POSITION_Y,
            //        HANDLER_WORKBLOCK_TRANSFER_UP_POSITION_Z,
            //        HANDLER_WORKBLOCK_TRANSFER_CONTACT_POSITION_Z,
            //        HANDLER_WORKBLOCK_TRANSFER_DOWN_POSITION_Z,
            //        HANDLER_WORKBLOCK_TRANSFER_POSITION_R,

            //        HANDLER_MATERIAL_VAC_THRESHOLD,
            //        HANDLER_MATERIAL_VAC_ON_DELAY,
            //        HANDLER_MATERIAL_VAC_OFF_DELAY,
            //        HANDLER_MATERIAL_BLOW_USED,

            
            //    }
            //    #endregion

            //    #region Action
            //    public enum EN_TASK_ACTION
            //    {
            //        STOP = 0,

            //        #region AUTO
            //        EQUIPMENT_LOADING,
            //        BLOCK_LOADING,

            //        BLOCK_UNLOADING,
            //        EQUIPMENT_UNLOADING,
            //        #endregion

            //        #region MANUAL
            //        MOVE_AVOID,
            //        #endregion
            //    }

            //    public enum EN_PORT_LIST
            //    {
            //        WORK_PORT,
            //    }
            //    #endregion

            //    #region Alarm
            //    public enum EN_TASK_ALARM
            //    {
            //        MAETRIAL_NOT_EXIST = 1,
            //        MAETRIAL_EXIST = 2,
            //        MOVE_FAIL = 3,
            //        STATUS_MISMATCH = 4,
            //        INTERLOCK_TIMEOUT = 5,
            //        VAC_CHECK_FAIL = 6,
            //        RECOVERY_STATUS_ALARM = 7,
            //        COMMUNICATION_TIMEOUT = 8,
            //        COMMUNICATION_ALARM = 9,
            //    }
            //    public enum EN_TASK_ALARM_MESSAGE_EN
            //    {

            //    }
            //    public enum EN_TASK_ALARM_MESSAGE_KR
            //    {

            //    }
            //    public enum EN_SYSTEM_ALARM
            //    {
            //        HOST_CONNECTION_ALARM
            //    }
            //    #endregion
            //    }
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
                LD_CONTROL_1 = 0,
                LD_CONTROL_2 = 1,
                LD_CONTROL_3 = 2,
                LD_MONITOR = 3,
                LD_2_CONTROL_1 = 4,
                LD_2_CONTROL_2 = 5,
                LD_2_CONTROL_3 = 6,
                LD_2_MONITOR = 7,
                POWERMETER = 8,
            }
		}

		namespace DigitalIO
		{
			public enum EN_DIGITAL_IN
			{
				EMS_RACK = 0,					// > X00

                DC_FAN_1 = 2,
                DC_FAN_2,
                DC_FAN_3,
                DC_FAN_4,
                DC_FAN_5,
                DC_FAN_6,

                FROM_PLC_IN_1 = 8,
                FROM_PLC_IN_2 = 9,

                LD_1_READY = 16,
                LD_1_ALARM = 17,
                LD_1_ON = 18,

                LD_2_READY = 21,
                LD_2_ALARM = 22,
                LD_2_ON = 23,

                LD_3_READY = 26,
                LD_3_ALARM = 27,
                LD_3_ON = 28,

                MONITOR_ALARM = 32,

                // 2025.3.11 by ecchoi [ADD] Laser No.2
                LD_1_READY_2 = 36,
                LD_1_ALARM_2 = 37,
                LD_1_ON_2 = 38,

                LD_2_READY_2 = 41,
                LD_2_ALARM_2 = 42,
                LD_2_ON_2 = 43,

                LD_3_READY_2 = 46,
                LD_3_ALARM_2 = 47,
                LD_3_ON_2 = 48,

                MONITOR_ALARM_2 = 52,
            }

			public enum EN_DIGITAL_OUT
			{
				SAFETY_RESET = 0,

                TO_PLC_OUT_1 = 8,
                TO_PLC_OUT_2 = 9,

                LD_1_ALARM_CLEAR = 16,
                LD_1_EMO = 17,
                LD_1_ON = 18,
                LD_1_READY = 19,

                LD_2_ALARM_CLEAR = 21,
                LD_2_EMO = 22,
                LD_2_ON = 23,
                LD_2_READY = 24,

                LD_3_ALARM_CLEAR = 26,
                LD_3_EMO = 27,
                LD_3_ON = 28,
                LD_3_READY = 29,

                MONITOR_ALARM_CLEAR = 31,
                MONITOR_EMO = 32,

                // 2025.3.11 by ecchoi [ADD] Laser No.2
                LD_1_ALARM_CLEAR_2 = 36,
                LD_1_EMO_2 = 37,
                LD_1_ON_2 = 38,
                LD_1_READY_2 = 39,

                LD_2_ALARM_CLEAR_2 = 41,
                LD_2_EMO_2 = 42,
                LD_2_ON_2 = 43,
                LD_2_READY_2 = 44,

                LD_3_ALARM_CLEAR_2 = 46,
                LD_3_EMO_2 = 47,
                LD_3_ON_2 = 48,
                LD_3_READY_2 = 49,

                MONITOR_ALARM_CLEAR_2 = 51,
                MONITOR_EMO_2 = 52,
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

                POWER_2_CH_1 = 18,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_2 = 19,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_3 = 20,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_4 = 21,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_5 = 22,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_6 = 23,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_7 = 24,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_8 = 25,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_9 = 26,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_10 = 27,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_11 = 28,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_12 = 29,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_13 = 30,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_14 = 31,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_15 = 32,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_16 = 33,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_17 = 34,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v
                POWER_2_CH_18 = 35,		// 0V ~ +5V				// SCALE RANGE (16bit) -10V ~ +10v

                IR_SENSOR_1 = 40,     //4mA ~ 20mA
                IR_SENSOR_2 = 41,     //4mA ~ 20mA
                IR_SENSOR_3 = 42,     //4mA ~ 20mA
                IR_SENSOR_4 = 43,     //4mA ~ 20mA
            }
			public enum EN_ANALOG_OUT
			{
				NONE = -1,		// 0V ~ 5V				// SCALE RANGE (16bit) -10V ~ +10V
			}
		}

		namespace Cylinder
		{
			public enum EN_CYLINDER
			{
				NONE = -1,
            }
		}

		namespace Motion
		{
			public enum EN_AXIS
			{
				NONE = -1,

                //GANTRY_Y = 0,
                //BLOCK_X = 1,
                //BLOCK_Z = 2,
                //LIFT_Z = 3,
                //HANDLER_Y = 4,
                //HANDLER_X = 5,
                //HANDLER_Z = 6,
                //HANDLER_R = 7,
                //POWERMETER_X = 8,
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