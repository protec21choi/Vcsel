using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Define.DefineEnumProject.Laser;
//using Define.DefineEnumProject.Task;
using FrameOfSystem3.ExternalDevice.Serial;
namespace FrameOfSystem3.Laser
{
    class ProtecLaserMananger
    {
        #region Enum
        public enum EN_SET_RESULT
        {
            OK,
            WORKING,
            FAIL,
            POWER_OVER_MAX,
            POWER_UNDER_MIN,
            CH_POWER_OVER,
        }
        #endregion

        #region Variables
        private bool m_bInit = false;
        private int m_nPortCount = 1;
        private int m_nChannelCount = 1;

        // ChannelIndex + Channel Parameter
        private Dictionary<int, LaserChannelParameter> m_dicLaserParam = new Dictionary<int, LaserChannelParameter>();

        private TickCounter_.TickCounter m_TickForTimeOut = new TickCounter_.TickCounter();

        private ProtecLaserController m_ProtecLaser = ProtecLaserController.GetInstance();

        private ProtecLaserChannelCalibration m_LaserCal = ProtecLaserChannelCalibration.GetInstance();
        #region ForSettingSequence 
        private int m_nSeq = 0;
        private int m_nSettingChannel = 0;
        private bool[] arPortSettingDone = new bool[] { };

        #endregion //ForSettingSequence
        private int m_nStepMaxTime = 60000;
        #endregion

        #region 상수
        private readonly int m_nChannelCountInPort = 6;
        #endregion

        #region 속성
        public int ChannelCount { get { return m_nChannelCount; } }
        #endregion

        #region SingleTone
        private ProtecLaserMananger() { }
        private static ProtecLaserMananger _Instance = null;
        public static ProtecLaserMananger GetInstance() 
        {
            if (_Instance == null)
            {
                _Instance = new ProtecLaserMananger();
            }
            return _Instance; 
        }
        #endregion

        #region External Interface
        public bool Init(int nChannelCount)
        {
            m_nChannelCount = nChannelCount;
            m_nPortCount = nChannelCount / m_nChannelCountInPort;

            if (nChannelCount % m_nChannelCountInPort != 0)
                m_nPortCount++;

            arPortSettingDone = new bool[m_nPortCount];

            for (int nIndex = 0; nIndex < nChannelCount; ++nIndex)
            {
                if (false == m_dicLaserParam.ContainsKey(nIndex))
                {
                    int PortIndex = nIndex / m_nChannelCountInPort;
                    int ChannelIndexInPort = nIndex % m_nChannelCountInPort;

                    m_dicLaserParam.Add(nIndex, new LaserChannelParameter(PortIndex, ChannelIndexInPort));
                }
            }

            m_bInit = true;
            return true;
        }

        public void ResetSeqNum()
        {
            m_nSeq = 0;
        }
        public EN_SET_RESULT SetParameter(bool[] bEnable, double[] arPower, int[] arTime, double dSidePowerPercent, int[] nSideChIndex)
        {
            switch (m_nSeq)
            {
                case 0:
                    for (int nStep = 0; nStep < 5; nStep++)
                    {
                        if (arTime[nStep] != 0
                            && m_LaserCal.GetMinPower(bEnable) > arPower[nStep])
                        {
                            return EN_SET_RESULT.POWER_UNDER_MIN;
                        }
                        if (m_LaserCal.GetMaxPower(bEnable) < arPower[nStep])
                        {
                            return EN_SET_RESULT.POWER_OVER_MAX;
                        }
                    }
                    m_nSeq++;
                    break;
                case 1:
                    m_ProtecLaser.ClearAllPortData();
                    double nUsedChannelCount = 0;
                   // int nSideChCount = 0;
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        m_dicLaserParam[nIndex].Enable = bEnable[nIndex];
                        if (bEnable[nIndex])
                        {
                            nUsedChannelCount++;
//                               if (nSideChIndex.Contains(nIndex))
//                               {
//                                   nSideChCount++;
//                               }
                        }
                    }
                    //240719 [ADD] by wdw side Power

                    //nUsedChannelCount += (dSidePowerPercent / 100 * nSideChCount);

                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        for (int nStep = 0; nStep < 5; nStep++)
                        {
                            m_dicLaserParam[nIndex].StepPower[nStep] = arPower[nStep] / nUsedChannelCount;
                            if (nSideChIndex.Contains(nIndex) && bEnable[nIndex])
                            {
                                m_dicLaserParam[nIndex].StepPower[nStep] *= (1 + (dSidePowerPercent / 100));
                                if (m_LaserCal.GetMaxPower(nIndex) < m_dicLaserParam[nIndex].StepPower[nStep])
                                {
                                    return EN_SET_RESULT.CH_POWER_OVER;
                                }
                            }
                            m_dicLaserParam[nIndex].StepVoltage[nStep]
                                = m_LaserCal.GetProcessCalibrationChannelData(nIndex, EN_CALIBRATION_PROCESS_LIST.POWER_WATT_VOLT, m_dicLaserParam[nIndex].StepPower[nStep]);

                            m_dicLaserParam[nIndex].StepTime[nStep] = arTime[nStep];
                            if (m_dicLaserParam[nIndex].StepTime[nStep] > m_nStepMaxTime)
                                m_dicLaserParam[nIndex].StepTime[nStep] = m_nStepMaxTime;
                        }
                    }

                    m_nSeq++;
                    break;

                case 2:
                    // Init Volt 설정 
                    // 필요하면 구현
                    InitPortSettingDone();
                    m_nSettingChannel = 0;
                    m_nSeq++;
                    break;

                case 3: //step volt
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        if (m_dicLaserParam[nIndex].ChannelIndex == m_nSettingChannel)
                        {
                            if (arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] == false)
                                if (m_ProtecLaser.SetStepVoltage(m_dicLaserParam[nIndex].PortIndex, m_dicLaserParam[nIndex].ChannelIndex
                                                                , m_dicLaserParam[nIndex].Enable, m_dicLaserParam[nIndex].StepVoltage)
                                     == ProtecLaserController.EN_RESULT.DONE)
                                {
                                    arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
                                }
                        }
                    }
                    SetDisablePortSettingDone();
                    SetNoneExistChannelSettingDone(m_nSettingChannel);

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSettingChannel++;
                    }

                    if (m_nSettingChannel >= m_nChannelCountInPort)
                        m_nSeq++;
                    break;


                case 4: //step Time
                    //                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    //                     {
                    //                         if (arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] == false)
                    //                             if (m_ProtecLaser.SetStepTime(m_dicLaserParam[nIndex].PortIndex, m_dicLaserParam[nIndex].StepTime)
                    //                                                              == ProtecLaserController.EN_RESULT.DONE)
                    //                             {
                    //                                 arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
                    //                             }
                    //                     }
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (arPortSettingDone[nIndex] == false)
                            if (m_ProtecLaser.SetStepTime(nIndex, m_dicLaserParam[0].StepTime) //시간은 전 채널 동일 하게 설정
                                                             == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[nIndex] = true;
                            }
                    }
                    SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;

                case 5:
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (arPortSettingDone[nIndex] == false)
                            if (m_ProtecLaser.SetTimeMode(nIndex) //시간은 전 채널 동일 하게 설정
                                                             == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[nIndex] = true;
                            }
                    }
                    SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;

                case 6:
                    m_nSeq = 0;
                    return EN_SET_RESULT.OK;
            }

            return EN_SET_RESULT.WORKING;
        }

        public EN_SET_RESULT SetParameter(bool[] bEnable, double dPower, int nTime)
        {
            switch (m_nSeq)
            {
                case 0:
                    if(m_LaserCal.GetMinPower(bEnable) > dPower)
                    {
                        return EN_SET_RESULT.POWER_UNDER_MIN;
                    }
                    if (m_LaserCal.GetMaxPower(bEnable) < dPower)
                    {
                        return EN_SET_RESULT.POWER_OVER_MAX;
                    }
                    m_nSeq++;
                    break;

                case 1:
                    m_ProtecLaser.ClearAllPortData();
                    int nUsedStep = nTime / m_nStepMaxTime;//스텝 당 1분이 최대
                    int nLastStepTime = nTime % m_nStepMaxTime;
//                     if (nLastStepTime == 0)
//                         nLastStepTime = m_nStepMaxTime;
                 
                    int nUsedChannelCount = 0;
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        m_dicLaserParam[nIndex].Enable = bEnable[nIndex];
                        if (bEnable[nIndex])
                        {
                            nUsedChannelCount++;
                        }
                    }
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        for (int nStep = 0; nStep < 5; nStep++)
                        {
                            m_dicLaserParam[nIndex].StepPower[nStep] = dPower / nUsedChannelCount;
                            m_dicLaserParam[nIndex].StepVoltage[nStep]
                                = m_LaserCal.GetProcessCalibrationChannelData(nIndex, EN_CALIBRATION_PROCESS_LIST.POWER_WATT_VOLT, m_dicLaserParam[nIndex].StepPower[nStep]); 
                            if (nStep < nUsedStep)
                                m_dicLaserParam[nIndex].StepTime[nStep] = m_nStepMaxTime;
                            else if (nStep == nUsedStep)
                                m_dicLaserParam[nIndex].StepTime[nStep] = nLastStepTime;
                            else
                                m_dicLaserParam[nIndex].StepTime[nStep] = 0;
                        }
                    }
                    m_nSeq++;
                    break;

                case 2:
                    // Init Volt 설정 
                    // 필요하면 구현
                    InitPortSettingDone();
                    m_nSettingChannel = 0;
                    m_nSeq++;
                    break;

                case 3: //step volt
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        if (m_dicLaserParam[nIndex].ChannelIndex == m_nSettingChannel)
                        {
                            if (arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] == false)
                                if (m_ProtecLaser.SetStepVoltage(m_dicLaserParam[nIndex].PortIndex, m_dicLaserParam[nIndex].ChannelIndex
                                                                , m_dicLaserParam[nIndex].Enable, m_dicLaserParam[nIndex].StepVoltage)
                                     == ProtecLaserController.EN_RESULT.DONE)
                                {
                                    arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
                                }
                        }
                    }
                    SetDisablePortSettingDone();
                    SetNoneExistChannelSettingDone(m_nSettingChannel);

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSettingChannel++;
                    }

                    if (m_nSettingChannel >= m_nChannelCountInPort)
                        m_nSeq++;
                    break;

                case 4: //step Time
//                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
//                     {
//                         if (arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] == false)
//                             if (m_ProtecLaser.SetStepTime(m_dicLaserParam[nIndex].PortIndex, m_dicLaserParam[nIndex].StepTime)
//                                                              == ProtecLaserController.EN_RESULT.DONE)
//                             {
//                                 arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
//                             }
//                     }
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (arPortSettingDone[nIndex] == false)
                            if (m_ProtecLaser.SetStepTime(nIndex, m_dicLaserParam[0].StepTime) //시간은 전 채널 동일 하게 설정
                                                             == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[nIndex] = true;
                            }
                    }

                    SetDisablePortSettingDone();
                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;

                case 5:
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (arPortSettingDone[nIndex] == false)
                            if (m_ProtecLaser.SetTimeMode(nIndex) //시간은 전 채널 동일 하게 설정
                                                             == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[nIndex] = true;
                            }
                    }

                    SetDisablePortSettingDone();
                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;

                case 6:
                    m_nSeq = 0;
                    return EN_SET_RESULT.OK;
            }

            return EN_SET_RESULT.WORKING;
        }

        public EN_SET_RESULT SetParameterIOMode(bool[] bEnable, double dTotalPower)
        {
            switch (m_nSeq)
            {
                case 0:
                    // 2025.3.31 by ecchoi [ADD] Test 후 복구
                    //if (m_LaserCal.GetMinPower(bEnable) > dTotalPower)
                    //{
                    //    return EN_SET_RESULT.POWER_UNDER_MIN;
                    //}
                    //if (m_LaserCal.GetMaxPower(bEnable) < dTotalPower)
                    //{
                    //    return EN_SET_RESULT.POWER_OVER_MAX;
                    //}
                    m_nSeq++;
                    break;

                case 1:
                    m_ProtecLaser.ClearAllPortData();
                    int nUsedChannelCount = 0;

                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        m_dicLaserParam[nIndex].Enable = bEnable[nIndex];
                        if (bEnable[nIndex])
                        {
                            nUsedChannelCount++;
                        }
                    }

                    double IOModePower = dTotalPower / nUsedChannelCount;

                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        if (m_dicLaserParam[nIndex].Enable)
                        {
                            m_dicLaserParam[nIndex].PowerIOMode = IOModePower;
                            m_dicLaserParam[nIndex].VoltageIOMode = m_LaserCal.GetProcessCalibrationChannelData(nIndex, EN_CALIBRATION_PROCESS_LIST.POWER_WATT_VOLT, IOModePower);
                        }
                    }
                    m_nSeq++;
                    break;

                case 2:
                    InitPortSettingDone();
                    m_nSettingChannel = 0;
                    m_nSeq++;
                    break;

                case 3:
                    for (int nPort = 0; nPort < m_nPortCount; nPort++)
                    {
                        bool[] arEnable = new bool[6];
                        double[] arVoltage = new double[6];

                        for (int nChannel = 0; nChannel < m_nChannelCount; nChannel++)
                        {
                            if (m_dicLaserParam[nChannel].PortIndex == nPort)
                            {
                                int channelInPort = m_dicLaserParam[nChannel].ChannelIndex % 6;
                                if (channelInPort >= 0 && channelInPort < 6)
                                {
                                    arEnable[channelInPort] = m_dicLaserParam[nChannel].Enable;
                                    arVoltage[channelInPort] = m_dicLaserParam[nChannel].VoltageIOMode;
                                }
                            }
                        }

                        if (!arPortSettingDone[m_dicLaserParam[nPort].PortIndex])
                        {
                            var result = m_ProtecLaser.SetInitVoltageIOMode(nPort, arEnable, arVoltage);

                            if (result == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[m_dicLaserParam[nPort].PortIndex] = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    
                    SetDisablePortSettingDone(); // Disable Port 포트를 확인해서 DONE처리 

                    if (IsPortSettingDone()) //arPortSettingDone Check
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;

                case 4:
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        var resultMode = m_ProtecLaser.SetIOMode(nIndex);
                        if (resultMode == ProtecLaserController.EN_RESULT.DONE)
                        {
                            arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
                        }
                    }
                    SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;

                case 5:
                    m_nSeq = 0;
                    return EN_SET_RESULT.OK;
            }

            return EN_SET_RESULT.WORKING;
        }
        public EN_SET_RESULT SetParameterVolt(bool[] bEnable, double dVolt, int nTime)
        {
            switch (m_nSeq)
            {
                case 0:
                    m_ProtecLaser.ClearAllPortData();
                    int nUsedStep = nTime / m_nStepMaxTime;//스텝 당 1분이 최대
                    int nLastStepTime = nTime % m_nStepMaxTime;
//                     if(nLastStepTime == 0)
//                         nLastStepTime = m_nStepMaxTime;
//                    

                    int nUsedChannelCount = 0;
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        m_dicLaserParam[nIndex].Enable = bEnable[nIndex];
                        if (bEnable[nIndex])
                        {
                            nUsedChannelCount++;
                        }
                    }
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        for (int nStep = 0; nStep < 5; nStep++)
                        {
                            m_dicLaserParam[nIndex].StepVoltage[nStep] = dVolt;
                            if(nStep < nUsedStep)
                                m_dicLaserParam[nIndex].StepTime[nStep] = m_nStepMaxTime;
                            else if(nStep == nUsedStep)
                                m_dicLaserParam[nIndex].StepTime[nStep] = nLastStepTime;
                            else 
                                m_dicLaserParam[nIndex].StepTime[nStep] = 0;
                        }
                    }
                    m_nSeq++;
                    break;

                case 1:
                    // Init Volt 설정 
                    // 필요하면 구현
                    InitPortSettingDone();
                    m_nSettingChannel = 0;
                    m_nSeq++;
                    break;

                case 2: //step volt
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        if (m_dicLaserParam[nIndex].ChannelIndex == m_nSettingChannel)
                        {
                            if (arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] == false)
                                if (m_ProtecLaser.SetStepVoltage(m_dicLaserParam[nIndex].PortIndex, m_dicLaserParam[nIndex].ChannelIndex
                                                                , m_dicLaserParam[nIndex].Enable, m_dicLaserParam[nIndex].StepVoltage)
                                     == ProtecLaserController.EN_RESULT.DONE)
                                {
                                    arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
                                }
                        }
                    }
                    SetNoneExistChannelSettingDone(m_nSettingChannel);
                    SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSettingChannel++;
                    }

                    if (m_nSettingChannel >= m_nChannelCountInPort)
                        m_nSeq++;
                    break;

                case 3: //step Time
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (arPortSettingDone[nIndex] == false)
                            if (m_ProtecLaser.SetStepTime(nIndex, m_dicLaserParam[0].StepTime) //시간은 전 채널 동일 하게 설정
                                                             == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[nIndex] = true;
                            }
                    }

                    SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;
                case 4:
                     for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (arPortSettingDone[nIndex] == false)
                            if (m_ProtecLaser.SetTimeMode(nIndex) //시간은 전 채널 동일 하게 설정
                                                             == ProtecLaserController.EN_RESULT.DONE)
                            {
                                arPortSettingDone[nIndex] = true;
                            }
                    }

                     SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;
                case 5:
                    m_nSeq = 0;
                    return EN_SET_RESULT.OK;
            }

            return EN_SET_RESULT.WORKING;
        }
        
        public EN_SET_RESULT CheckShort(bool[] bEnable)
        {
            switch (m_nSeq)
            {
                case 0:
                    m_ProtecLaser.ClearAllPortData();
                  
                    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                    {
                        m_dicLaserParam[nIndex].Enable = bEnable[nIndex];
                        for (int nStep = 0; nStep < 5; nStep++)
                        {
                            m_dicLaserParam[nIndex].StepVoltage[nStep] = 0;
                            m_dicLaserParam[nIndex].StepTime[nStep] = 0;
                        }
                    }
                    m_nSeq++;
                    break;

                case 1:
                    // Init Volt 설정 
                    // 필요하면 구현
                    InitPortSettingDone();
                    m_nSettingChannel = 0;
                    m_nSeq++;
                    break;

                //case 2: //step volt
                //    for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
                //    {
                //        if (m_dicLaserParam[nIndex].ChannelIndex == m_nSettingChannel)
                //        {
                //            if (arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] == false)
                //                if (m_ProtecLaser.SetStepVoltage(m_dicLaserParam[nIndex].PortIndex, m_dicLaserParam[nIndex].ChannelIndex
                //                                                , m_dicLaserParam[nIndex].Enable, m_dicLaserParam[nIndex].StepVoltage)
                //                     == ProtecLaserController.EN_RESULT.DONE)
                //                {
                //                    arPortSettingDone[m_dicLaserParam[nIndex].PortIndex] = true;
                //                }
                //        }
                //    }
                //    SetNoneExistChannelSettingDone(m_nSettingChannel);

                //    SetDisablePortSettingDone();

                //    if (IsPortSettingDone())
                //    {
                //        InitPortSettingDone();
                //        m_ProtecLaser.ClearAllPortData();
                //        m_nSettingChannel++;
                //    }

                //    if (m_nSettingChannel >= m_nChannelCountInPort)
                //        m_nSeq++;
                //    break;

                case 2: //step Time
                    for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                    {
                        if (GetEnablePort(nIndex))
                        {
                            if (arPortSettingDone[nIndex] == false)
                            {
                                if (m_ProtecLaser.ShortCheckStart(nIndex) //시간은 전 채널 동일 하게 설정
                                                                 == ProtecLaserController.EN_RESULT.DONE)
                                {
                                    arPortSettingDone[nIndex] = true;
                                }
                            }
                        }
                        else
                        {
                            arPortSettingDone[nIndex] = true;
                        }
                    }
                    SetDisablePortSettingDone();

                    if (IsPortSettingDone())
                    {
                        InitPortSettingDone();
                        m_ProtecLaser.ClearAllPortData();
                        m_nSeq++;
                    }
                    break;
                case 4:
                    m_nSeq = 0;
                    return EN_SET_RESULT.OK;
            }

            return EN_SET_RESULT.WORKING;
        }

        public bool GetEnablePort(int nPortIndex)
        {
            bool bReturn = false;
            for (int nIndex = 0; nIndex < m_nChannelCount; nIndex++)
            {
                if (m_dicLaserParam[nIndex].PortIndex == nPortIndex)
                {
                    if (m_dicLaserParam[nIndex].Enable)
                    {
                        bReturn = true;
                    }
                }
            }
            return bReturn;
        }

        public double GetChannelPower(int nStep)
         {
             //StepPower는 모든 채널 똑같다.
             return m_dicLaserParam[0].StepPower[nStep];
         }

        public bool ReadMessage()
         {
             for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
             {
                 if (m_ProtecLaser.ReadMessage(nIndex))
                 {

                 }
             }
             return true;
         }
        #endregion

        #region Internal

        #region SettingDoneFlag
        private void InitPortSettingDone()
        {
            for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
            {
                arPortSettingDone[nIndex] = false;
            }
        }

        private bool IsPortSettingDone()
        {
            bool bReturn = true;

            for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
                bReturn &= arPortSettingDone[nIndex];

            return bReturn;
        }

        private int GetLastPortChannelCount()
        {
            int nLastPortChannelCount = m_nChannelCount % m_nChannelCountInPort;
            if (nLastPortChannelCount == 0)
                nLastPortChannelCount = 6;
            return nLastPortChannelCount;
        }

        //마지막 포트에 사용되지 않는 Channel을 Done으로 setting
        private void SetNoneExistChannelSettingDone(int nChannelIndex)
        {
            int nLastPortChannelCount = GetLastPortChannelCount();

            if (nChannelIndex > nLastPortChannelCount - 1)
                arPortSettingDone[m_nPortCount - 1] = true;
        }

        private void SetDisablePortSettingDone() 
        {
            for (int nIndex = 0; nIndex < m_nPortCount; nIndex++)
            {
                if(!GetEnablePort(nIndex))
                    arPortSettingDone[nIndex] = true;
            }
        }
        #endregion

        private class LaserChannelParameter
        {
            public LaserChannelParameter(int PortIndex, int nChannelIndex)
            {
                m_nPortIndex = PortIndex;
                m_nChannelIndex = nChannelIndex;
            }

            private bool m_bEnable = false;
            private int m_nPortIndex = 0;
            private int m_nChannelIndex = 0;
            private double[] m_arPower = new double[5]; // Unit [W]
            private double[] m_arStepVoltage = new double[5]; // Unit [V]

            private double m_arPowerIOMode = 0.0; //WATT 
            private double m_arVoltageIOMode = 0.0; //VOLT 
            
            private int[] m_arTime = new int[5]; // Unit [ms]

            #region Properties
            public bool Enable { get { return m_bEnable; } set { m_bEnable = value; } }
            public int PortIndex { get { return m_nPortIndex; } }
            public int ChannelIndex { get { return m_nChannelIndex; } }
            public double[] StepPower { get { return m_arPower; } set { m_arPower = value; } }
            
            public double[] StepVoltage { get { return m_arStepVoltage; } set { m_arStepVoltage = value; } }
            public int[] StepTime { get { return m_arTime; } set { m_arTime = value; } }

            public double PowerIOMode { get { return m_arPowerIOMode; } set { m_arPowerIOMode = value; } }
            public double VoltageIOMode { get { return m_arVoltageIOMode; } set { m_arVoltageIOMode = value; } }
            #endregion /Properties
        }
        #endregion
    }
}
