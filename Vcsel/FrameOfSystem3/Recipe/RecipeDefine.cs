﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameOfSystem3.Recipe
{
    /// <summary>
    /// 2020.06.29 by yjlee [ADD] Enumerate the common parameters.
    /// </summary>
    public enum PARAM_COMMON
    {
        PROCESS_FILE_PATH,
        PROCESS_FILE_NAME,
    }

    /// <summary>
    /// 2020.06.29 by yjlee [ADD] Enumerate the equipment parameters.
    /// </summary>
    public enum PARAM_EQUIPMENT
    {
        MachineName,
        UnlockParameterChange,

        MONITORING_IR_SENSOR_1_VISIBLE,
        MONITORING_IR_SENSOR_1_COLOR,

        MONITORING_IR_SENSOR_2_VISIBLE,
        MONITORING_IR_SENSOR_2_COLOR,
        
        MONITORING_IR_SENSOR_3_VISIBLE,
        MONITORING_IR_SENSOR_3_COLOR,
        
        MONITORING_IR_SENSOR_4_VISIBLE,
        MONITORING_IR_SENSOR_4_COLOR,

        //#region GRAPH SCALE
        //GRAPH_SCALE_TEMP_MAX,
        //GRAPH_SCALE_TEMP_MIN,
        //#endregion

        //#region Laser
        //LASER_SETTING_DELAY,
        //#endregion

        //#region Bond Head Calibration
        //#endregion

        ////#region AVOID POSITION
        ////HEAD_READY_POSITION_X,
        ////HEAD_READY_POSITION_Y,
        ////#endregion /AVOID POSITION

        ////#region HEATER PARAMETER
        ////WORK_BLOCK_TOLERANCE_MIN,
        ////WORK_BLOCK_TOLERANCE_MAX,

        ////WORK_BLOCK_CH_OFFSET_8,
        ////#endregion /HEATER PARAMETER

        //#region CALIBRATION
        //POWER_CALIBRATION_MAX_VOLT,
        //POWER_CALIBRATION_MIN_VOLT,

        //POWER_CALIBRATION_STEP_COUNT,

        //// 2025.3.11 by ecchoi [ADD] Laser 2
        //POWER_CALIBRATION_2_MAX_VOLT,
        //POWER_CALIBRATION_2_MIN_VOLT,

        //POWER_CALIBRATION_2_STEP_COUNT,
        //#endregion

        //#region POWER MEASURE
        //POWER_MEASURE_SELLECTED_CHANNEL, //측정할 때 측정 위치 결정 

        ////POWER_MEASURE_BLOCK_AVOID_POSITION_X,
        ////POWER_MEASURE_HEAD_AVOID_POSITION_Y,

        ////POWERMETER_READY_POSITION_X,
        ////POWERMETER_READY_POSITION_Y,

        ////POWER_MEASURE_POSITION_X_18,
        ////POWER_MEASURE_POSITION_Y_18,

        //POWER_MEASURE_CHANNEL_ENABLE_18,

        //POWER_MEASURE_WATT,
        //POWER_MEASURE_VOLT,

        //POWER_MEASURE_SHOT_TIME,
        //POWER_MEASURE_WAIT_TIME,

        //POWER_MEASURE_REPEAT_COUNT,
        //POWER_MEASURE_REST_TIME,

        //// 2025.3.11 by ecchoi [ADD] Laser 2
        //POWER_MEASURE_2_SELLECTED_CHANNEL, //측정할 때 측정 위치 결정 

        //POWER_MEASURE_2_CHANNEL_ENABLE_18,

        //POWER_MEASURE_2_WATT,
        //POWER_MEASURE_2_VOLT,

        //POWER_MEASURE_2_SHOT_TIME,
        //POWER_MEASURE_2_WAIT_TIME,

        //POWER_MEASURE_2_REPEAT_COUNT,
        //POWER_MEASURE_2_REST_TIME,
        //#endregion

        //#region HeadFlow
        //HEAD_FLOW_THRESHOLD,
        //#endregion

        //        #region MonitorVeiw
        //        MONOTORING_POWER_CH_1_VISIBLE,
        //        MONOTORING_POWER_CH_1_COLOR,
        //        MONOTORING_POWER_CH_2_VISIBLE,
        //        MONOTORING_POWER_CH_2_COLOR,
        //        MONOTORING_POWER_CH_3_VISIBLE,
        //        MONOTORING_POWER_CH_3_COLOR,
        //        MONOTORING_POWER_CH_4_VISIBLE,
        //        MONOTORING_POWER_CH_4_COLOR,
        //        MONOTORING_POWER_CH_5_VISIBLE,
        //        MONOTORING_POWER_CH_5_COLOR,
        //        MONOTORING_POWER_CH_6_VISIBLE,
        //        MONOTORING_POWER_CH_6_COLOR,
        //        MONOTORING_POWER_CH_7_VISIBLE,
        //        MONOTORING_POWER_CH_7_COLOR,
        //        MONOTORING_POWER_CH_8_VISIBLE,
        //        MONOTORING_POWER_CH_8_COLOR,
        //        MONOTORING_POWER_CH_9_VISIBLE,
        //        MONOTORING_POWER_CH_9_COLOR,
        //        MONOTORING_POWER_CH_10_VISIBLE,
        //        MONOTORING_POWER_CH_10_COLOR,
        //        MONOTORING_POWER_CH_11_VISIBLE,
        //        MONOTORING_POWER_CH_11_COLOR,
        //        MONOTORING_POWER_CH_12_VISIBLE,
        //        MONOTORING_POWER_CH_12_COLOR,
        //        MONOTORING_POWER_CH_13_VISIBLE,
        //        MONOTORING_POWER_CH_13_COLOR,
        //        MONOTORING_POWER_CH_14_VISIBLE,
        //        MONOTORING_POWER_CH_14_COLOR,
        //        MONOTORING_POWER_CH_15_VISIBLE,
        //        MONOTORING_POWER_CH_15_COLOR,
        //        MONOTORING_POWER_CH_16_VISIBLE,
        //        MONOTORING_POWER_CH_16_COLOR,
        //        MONOTORING_POWER_CH_17_VISIBLE,
        //        MONOTORING_POWER_CH_17_COLOR,
        //        MONOTORING_POWER_CH_18_VISIBLE,
        //        MONOTORING_POWER_CH_18_COLOR,
        //        MONOTORING_POWER_TOTAL_VISIBLE,
        //        MONOTORING_POWER_TOTAL_COLOR,
        //// 
        ////         MONOTORING_TEMP_1_VISIBLE,
        ////         MONOTORING_TEMP_1_COLOR,
        ////         MONOTORING_TEMP_2_VISIBLE,
        ////         MONOTORING_TEMP_2_COLOR,
        ////         MONOTORING_TEMP_3_VISIBLE,
        ////         MONOTORING_TEMP_3_COLOR,
        ////         MONOTORING_TEMP_4_VISIBLE,
        ////         MONOTORING_TEMP_4_COLOR,
        ////         MONOTORING_TEMP_5_VISIBLE,
        ////         MONOTORING_TEMP_5_COLOR,

        //        MONOTORING_BLOCK_VAC_VISIBLE,
        //        MONOTORING_BLOCK_VAC_COLOR,

        //        MONOTORING_HEAD_FLOW_VISIBLE,
        //        MONOTORING_HEAD_FLOW_COLOR,
        //        #endregion

        //LASER_USED,
        //IR_USED,
        //PYROMETER_USED,
        //POWERCHECK_USED,
        //POWERCHECK_TOLERANCE,

        //INPUT_SMEMA_USED,

        //LASER_ON_VOLT_THRESHOLD,

        //#region Transfer
        //HANDLER_READY_X,
        //HANDLER_WORK_BLOCK_AVOID_POSITION_X,
        //HANDLER_WORK_BLOCK_AVOID_POSITION_R,
        //HANDLER_WORK_BLOCK_AVOID_POSITION_Z,

        //HANDLER_Z_MATERIAL_CONTACT_SPEED,
        //HANDLER_Z_MATERIAL_HANDLE_SPEED,
        //HANDLER_X_MATERIAL_HANDLE_SPEED,
        //HANDLER_Y_MATERIAL_HANDLE_SPEED,
        //HANDLER_R_MATERIAL_HANDLE_SPEED,
        //#endregion

        //#region FFU
        //FFU_USE,
        //FFU_CONTROLLER_COUNT,
        //FFU_UNIT_COUNT,
        //FFU_TARGET_SPEED_4,
        //FFU_FULL_SPEED,
        //FFU_ALARM_CODE,
        //#endregion

        //#region Chiller
        //CHILLER_ALARM_CODE,
        //#endregion

        //#region WCF
        //PREEQUIPMENT_WCF_USED,
        //PREEQUIPMENT_HOST_IP,
        //PREEQUIPMENT_HOST_PORT,
        //PREEQUIPMENT_TARGET_IP,
        //PREEQUIPMENT_TARGET_PORT,

        //EFEM_USE,
        //EFEM_FDC_LOGGING,
        //EFEM_UPDATE_ECID,
        //EFEM_TARGET_IP,
        //EFEM_TARGET_PORT,
        //EFEM_HOST_IP,
        //EFEM_HOST_PORT,
        //EFEM_FDC_INTERVAL,
        //#endregion /WCF

        //#region WorkStausColor
        //WAIT_COLOR,
        //DONE_COLOR,
        //LOW_TEMP_COLOR,
        //TEMP_GROW_FAIL_COLOR,
        //TEMP_DEVOVER_COLOR,
        //HIGH_TEMP_COLOR,
        //MAX_HIGH_TEMP_COLOR,
        //EMG_LOW_TEMP_COLOR,
        //EMG_HIGH_TEMP_COLOR,
        //POWER_FAULT_COLOR,
        //SOURCE_ALARM_COLOR,
        //RESULT_GETFAIL_COLOR,
        //#endregion

        //RUN_RATIO,

        //IONIZER_CHECK_DELAY,
        //IONIZER_INTERLUPT_ENABLE,

        //TRANSFER_TEST,

        //RAM_METRICS_EXPORT_PATH,
    }
}
