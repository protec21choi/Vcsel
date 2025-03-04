using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;
using Define.DefineEnumProject.SubSequence.Laser;

using FrameOfSystem3.Laser;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    #region <VALUE CLASS>
    /// <summary>
    /// Sequence 에서 사용하는 Parameter 이며 Client 로 부터 전달 받음
    /// </summary>
    public class SubSeqLaserWorkParam : SubSequenceParam
    {
        public bool LaserUsed = false;
        public int CurrentParamIndex = 0;

        public bool KeepLastValuePower = false;
        public bool KeepLastValueSizeX = false;
        public bool KeepLastValueSizeY = false;

        // TOTAL 5 PARAMETER
        public bool[] ParamUsed = new bool[5];
        public bool[] LaserSizeStepUsed = new bool[5];

        // [STEP, PARAMETER]
        public double[,] LaserPower = new double[5, 5];
        public double[,] LaserSizeX = new double[5, 5];
        public double[,] LaserSizeY = new double[5, 5];
        public int[,] LaserTime = new int[5, 5];
        public string[,] LaserPowerMode = new string[5, 5];
        public string[,] LaserSizeMode = new string[5, 5];
        
        

    }
    public class SubSeqLaserModulationParam : SubSequenceParam
    {
        public bool ModulationUsed = false;
        // MODULATION
        public int ModulationDelay = 0;
        public int[] ModulationDuty = new int[5];
        public double[] ModulationFrequency = new double[5];
        public int[] ModulationTime = new int[5];
    }
    public class SubSeqLaserMonitorParam : SubSequenceParam
    {
        public bool MonitorUsed = false;
        public bool TempCheckUsed = false;
        // MONITOR
        public int MonitorPreDelay = 0;
        public int MonitorPostDelay = 0;
        public double EMGTemp = 0;
        public bool AbortUsed = false;
        public double AbortTemp = 0;
        public bool PowerCheckUsed = false;
        public double PowerCheckTolerance = 0;
        public int MonitorWorkParameterIndex = 0;

        public int[] SectionTime = new int[5];
        public double[] SectionLowTemp = new double[5];
        public double[] SectionHighTemp = new double[5];
    }

    public class SubSeqLaserMotionParam : SubSequenceParam
    {
        public bool MotionUsed = false;

        public double[] Level = new double[5];
        public double[] Velocity = new double[5];
        public double[] Time = new double[5];
       
    }

    public class SubSeqLaserHeaterParam : SubSequenceParam
    {
        public int HeaterIndex = 0;

        public bool HeaterOffCooling = true;
    }
    #endregion </VALUE CLASS>


    public enum EN_MONITOR_RESULT
    {
        NORMAL,
        ABORT,
        EMG,
        LOW_TEMP,
        HIGH_TEMP,
        POWER_TOLERANCE_OVER,
    }

    public class SubSeqLaserWork : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_LASER_WORK_STEP
        {
            READY = 0,

            INITIALIZE  = 100,

            READY_LASER_WORK = 200,
            WORKING_LASER = 300,
            END_LASER_WORK = 400,
            FINISH_LASER = 500,

            FINISH = 1000,
        }

        public enum EN_MONITOR_RESULT
        {
            NORMAL,
            ABORT,
            EMG,
            LOW_TEMP,
            HIGH_TEMP,
            POWER_TOLERANCE_OVER,
        }
        #endregion </ENUMERATION>

        #region <CONSTANT>
        private const int TOP = 0;
        private const int BOTTOM = 1;
        private const int POWER = 0;
        private const int SIZEX = 1;
        private const int SIZEY = 2;
        #endregion </CONSTANT>

        #region <FIELD>
        private IDeviceControl[] m_SubControlDevice = null;
        private IOutputProfile[,] m_SubControlOutputProfile = null;
        private IModulationControl[] m_SubControlModulation = null;
        private IMonitoringControl[] m_SubControlMonitor = null;
        private ILaserMotionControl[] m_SubControlMotion = null;
        private ILaserHeaterControl[] m_SubControlHeater = null;

        private SubSeqLaserWorkParam[] m_SubSeqParam = null;
        private SubSeqLaserModulationParam[] m_SubSeqModulationParam = null;
        private SubSeqLaserMonitorParam[] m_SubSeqMonitorParam = null;
        private SubSeqLaserMotionParam[] m_SubSeqMotionParam = null;
        private SubSeqLaserHeaterParam[] m_SubSeqHeaterParam = null;

        private EN_SEQUENCE_BRANCH m_enSubSeqBranch = EN_SEQUENCE_BRANCH.LASER_SHOT;

		// Not Use (LB-1000)
        //private ExternalDevice.Socket.IR m_IR = ExternalDevice.Socket.IR.GetInstance();
        private TickCounter m_TimeDelay = new TickCounter();
        private TickCounter m_TimeOut = new TickCounter();
        //private LaserMonitor m_InstanceLaserMonitor = LaserMonitor.GetInstance();
        
        private bool m_bProcessTimeOut = false;
        private EN_MONITOR_RESULT m_enMonitorResult = EN_MONITOR_RESULT.NORMAL;

        private int[] arMonitoringStep = new int[1];//monitor control 갯수
        private int[] arMonitoringStepTime = new int[1];//monitor control 갯수
        private bool[] arMonitoringStepInTarget = new bool[1];//monitor control 갯수
        #endregion </FIELD>

        #region <CONSTRUCTOR>

        public SubSeqLaserWork(ASubControl[] DeviceControls, ASubControl[,] OutputProfiles)
        {
            m_SubControlDevice = new IDeviceControl[DeviceControls.Length];

            for (int i = 0; i < DeviceControls.Length; ++i)
            {
                m_SubControlDevice[i] = DeviceControls[i] as IDeviceControl;
            }

            m_SubControlOutputProfile = new IOutputProfile[OutputProfiles.GetLength(0), OutputProfiles.GetLength(1)];

            for (int i = 0; i < OutputProfiles.GetLength(0); ++i)
            {
                for (int j = 0; j < OutputProfiles.GetLength(1); ++j)
                {
                    m_SubControlOutputProfile[i, j] = OutputProfiles[i, j] as IOutputProfile;
                }
            }
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqLaserWorkParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqLaserWorkParam;
            }
        }
        public override void SetSubSeqBranch(int nBranch)
        {
            m_enSubSeqBranch = (EN_SEQUENCE_BRANCH)nBranch;
        }
        public override EN_SUBSEQUENCE_RESULT SubSequenceProcedure()
        {
            if (Activate.Equals(false))
                return EN_SUBSEQUENCE_RESULT.OK;

            switch (m_nStepNo)
            {
                #region <READY>
                case (int)EN_LASER_WORK_STEP.READY:
                    EntryDeviceControl();
                    EntryPowerMonitor();
                    if (!EntryModulationControl())
                        break;
                    m_strSeqResultInfo = string.Empty;
                    m_enMonitorResult = EN_MONITOR_RESULT.NORMAL;
                    ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.READY + 1:
                    switch (m_enSubSeqBranch)
                    {
                        case EN_SEQUENCE_BRANCH.MANUAL_END_DEVICE:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.END_LASER_WORK;
                            break;
                        case EN_SEQUENCE_BRANCH.INITIALIZE:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.INITIALIZE;
                            break;
                        default:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.READY_LASER_WORK;
                            m_TimeOut.SetTickCount(5000);
                            break;
                    }
                    break;
                #endregion </READY>

                #region <READY_LASER_WORK>
                case (int)EN_LASER_WORK_STEP.READY_LASER_WORK:
                    if (m_TimeOut.IsTickOver(false))
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_READY;
                    }
                    if (CheckLaserSize())
                    {
                        ++m_nStepNo;
                    }
                    break;
                case (int)EN_LASER_WORK_STEP.READY_LASER_WORK + 1:
                    if (ReadyOutputProfile())
                    {
                        m_TimeOut.SetTickCount(10000);   // 10 sec
                        ++m_nStepNo;
                    }
                    break;
                case (int)EN_LASER_WORK_STEP.READY_LASER_WORK + 2:
                    if (m_TimeOut.IsTickOver(false))
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_READY;
                    }

                    if (ReadyDeviceSetting())
                        ++m_nStepNo;

                    break;
                case (int)EN_LASER_WORK_STEP.READY_LASER_WORK + 3:
                    if (ReadyMudulationSetting())
                        ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.READY_LASER_WORK + 4:
                    if (ReadyHeater())
                        ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.READY_LASER_WORK + 5:
                    switch (m_enSubSeqBranch)
                    {
                        case EN_SEQUENCE_BRANCH.MANUAL_READY_DEVICE:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.FINISH;
                            break;
                        default:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.WORKING_LASER;
                            break;
                    }
                    break;
                #endregion </READY_LASER_WORK>

                #region <WORKING_LASER>
                case (int)EN_LASER_WORK_STEP.WORKING_LASER:
                    ++m_nStepNo;
                    break;
                
                case (int)EN_LASER_WORK_STEP.WORKING_LASER + 1:
                    if (StartWorkToDevice())
                        ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.WORKING_LASER + 2:
                    if (StartMonitor())
                    {
                        if (m_SubControlMonitor != null)
                            m_TimeDelay.SetTickCount((uint)m_SubSeqMonitorParam[0].MonitorPreDelay);
                        ++m_nStepNo;
                    }
                    break;
                case (int)EN_LASER_WORK_STEP.WORKING_LASER + 3:
                    if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;

                    double[] arTotalTime = new double[] { 0.0, 0.0, 0.0 };

                    if (StartOutputProfile(ref arTotalTime))
                    {
                        double dWaitWorkTime = arTotalTime[0] > arTotalTime[1] ? arTotalTime[0] : arTotalTime[1];

                        dWaitWorkTime *= 1.2;

                        m_bProcessTimeOut = false;

                        m_TimeOut.SetTickCount((uint)dWaitWorkTime);
                        if (m_SubSeqModulationParam != null)
                        	m_TimeDelay.SetTickCount((uint)m_SubSeqModulationParam[0].ModulationDelay);
                        MoveMotion();
                        StartHeaterTempProfile();
                        ++m_nStepNo;
                    }

                    break;
                case (int)EN_LASER_WORK_STEP.WORKING_LASER + 4:
                    if (m_TimeOut.IsTickOver(false))
                    {
                        m_bProcessTimeOut = true;

                        ++m_nStepNo;
                        break;
                    }
                    if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;
                    if(StartModulation())
                        ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.WORKING_LASER + 5:
                        
                    if (m_TimeOut.IsTickOver(false))
                    {
                        m_bProcessTimeOut = true;

                        ++m_nStepNo;
                        break;
                    }
                    WorkingModulation();
                    int nElapsedTime = 0;
                    int[,] arElapsedTime = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                    if (WorkingOutputProfile(ref arElapsedTime))
                    {
                        ++m_nStepNo;
                        break;
                    }
                    else
                    {
                            
                        foreach(int nTime in arElapsedTime)
                        {
                            nElapsedTime = nTime > nElapsedTime ? nTime : nElapsedTime;
                        }
                    }
                    EN_MONITOR_RESULT enMonitorResult = MonitorDuringLaser(nElapsedTime);
                   // m_enMonitorResult = MonitorDuringLaser(nElapsedTime);
                    switch (enMonitorResult)
                    {
                        case EN_MONITOR_RESULT.NORMAL:
                            break;
                        case EN_MONITOR_RESULT.HIGH_TEMP:
                        case EN_MONITOR_RESULT.LOW_TEMP:
                            m_enMonitorResult = enMonitorResult;
                            //작업은 완료한다.
                            break;
                        case EN_MONITOR_RESULT.EMG:
                        case EN_MONITOR_RESULT.ABORT:
                        case EN_MONITOR_RESULT.POWER_TOLERANCE_OVER:
                            m_enMonitorResult = enMonitorResult;
                            ++m_nStepNo;
                            break;
                    }
                    break;
                case (int)EN_LASER_WORK_STEP.WORKING_LASER + 6:
                    m_nStepNo = (int)EN_LASER_WORK_STEP.END_LASER_WORK;
                    break;
                #endregion </WORKING_LASER>

                #region <END_LASER_WORK>
                case (int)EN_LASER_WORK_STEP.END_LASER_WORK:
                    if (StopOutputProfile())
                        ++m_nStepNo;

                    break;
                case (int)EN_LASER_WORK_STEP.END_LASER_WORK + 1:
                    if (StopWorkToDevice()
                        && StartHeaterCooling())
                    {
                        ++m_nStepNo;
                    }
                    break;
                case (int)EN_LASER_WORK_STEP.END_LASER_WORK + 2:
                    if (StopModulation())
                    {
                        ++m_nStepNo;
                    }
                    break;
                case (int)EN_LASER_WORK_STEP.END_LASER_WORK + 3:
                    if (CheckMotionDone())
                    {
                        m_TimeDelay.SetTickCount((uint)m_SubSeqMonitorParam[0].MonitorPostDelay);
                        ++m_nStepNo;
                    }
                    break;

                case (int)EN_LASER_WORK_STEP.END_LASER_WORK + 4:
                    
                     if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;
                    if (StopMonitor())
                    {
                        ++m_nStepNo;
                    }
                    break;

                case (int)EN_LASER_WORK_STEP.END_LASER_WORK + 5:
                    if(m_bProcessTimeOut)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_TIMEOUT;
                    }
                    if(m_enMonitorResult == EN_MONITOR_RESULT.EMG)
                    {
                        m_strSeqResultInfo = "DETECT EMG TEMP";
                        return EN_SUBSEQUENCE_RESULT.ERROR;
                    }
                    if (m_enMonitorResult == EN_MONITOR_RESULT.POWER_TOLERANCE_OVER
                        || CheckPowerIntarget() == EN_MONITOR_RESULT.POWER_TOLERANCE_OVER)
                    {
                        m_strSeqResultInfo = "DETECT POWER TOLERANCE OVER";
                        return EN_SUBSEQUENCE_RESULT.ERROR;
                    }
                    if (m_enMonitorResult == EN_MONITOR_RESULT.HIGH_TEMP)
                    {
                        m_strSeqResultInfo = "DETECT TEMP HIGH";
                    }
                    if (m_enMonitorResult == EN_MONITOR_RESULT.LOW_TEMP)
                    {
                        m_strSeqResultInfo = "DETECT TEMP LOW";
                    }
                    switch (m_enSubSeqBranch)
                    {
                        case EN_SEQUENCE_BRANCH.LASER_SHOT_KEEP_DEVICE_READY:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.FINISH;
                            break;
                        default:
                            m_nStepNo = (int)EN_LASER_WORK_STEP.FINISH_LASER;
                            break;
                    }
                    break;
                #endregion </END_LASER_WORK>

                #region <FINISH_LASER>
                case (int)EN_LASER_WORK_STEP.FINISH_LASER:
                    if(FinishModulation())
                        ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.FINISH_LASER + 1:
                    if (FinishDevice())
                        m_nStepNo = (int)EN_LASER_WORK_STEP.FINISH;

                    break;
                #endregion </FINISH_LASER>

                #region <INITIALIZE_LASER>
                case (int)EN_LASER_WORK_STEP.INITIALIZE:
                    ++m_nStepNo;
                    break;
                case (int)EN_LASER_WORK_STEP.INITIALIZE + 1:
                    if (InitializeDevice())
                        m_nStepNo = (int)EN_LASER_WORK_STEP.FINISH;

                    break;
                #endregion </FINISH_LASER>

                #region <FINISH>
                case (int)EN_LASER_WORK_STEP.FINISH:
                    Activate = false;

                    return EN_SUBSEQUENCE_RESULT.OK;
                #endregion </FINISH>
            }

            return EN_SUBSEQUENCE_RESULT.WORKING;
        }
        #endregion </OVERRIDE>

        #region <METHOD>
        public void AddMonitorControl(ASubControl[] MonitoringControl)
        {
            if (MonitoringControl != null)
            {
                m_SubControlMonitor = new IMonitoringControl[MonitoringControl.Length];
                arMonitoringStep = new int[MonitoringControl.Length];
                arMonitoringStepTime = new int[MonitoringControl.Length];
                arMonitoringStepInTarget = new bool[MonitoringControl.Length];

                for (int i = 0; i < MonitoringControl.Length; ++i)
                {
                    m_SubControlMonitor[i] = MonitoringControl[i] as IMonitoringControl;
                }
            }
        }
        public void AddModulationControl(ASubControl[] ModulationCotrols)
        {
            if (ModulationCotrols != null)
            {
                m_SubControlModulation = new IModulationControl[ModulationCotrols.Length];

                for (int i = 0; i < ModulationCotrols.Length; ++i)
                {
                    m_SubControlModulation[i] = ModulationCotrols[i] as IModulationControl;
                }
            }
        }
        public void AddMotionControl(ASubControl[] MotionControls)
        {
            if (MotionControls != null)
            {
                m_SubControlMotion = new ILaserMotionControl[MotionControls.Length];

                for (int i = 0; i < MotionControls.Length; ++i)
                {
                    m_SubControlMotion[i] = MotionControls[i] as ILaserMotionControl;
                }
            }
        }
        public void AddHeaterControl(ASubControl[] HeaterControls)
        {
            if (HeaterControls != null)
            {
                m_SubControlHeater = new ILaserHeaterControl[HeaterControls.Length];

                for (int i = 0; i < HeaterControls.Length; ++i)
                {
                    m_SubControlHeater[i] = HeaterControls[i] as ILaserHeaterControl;
                }
            }
        }

        public void AddMonitorParameter<T>(params T[] param)
        {
            m_SubSeqMonitorParam = new SubSeqLaserMonitorParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqMonitorParam[i] = param[i] as SubSeqLaserMonitorParam;
            }
        }
        public void AddModulationParameter<T>(params T[] param)
        {
            m_SubSeqModulationParam = new SubSeqLaserModulationParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqModulationParam[i] = param[i] as SubSeqLaserModulationParam;
            }
        }
        public void AddMotionParameter<T>(params T[] param)
        {
            m_SubSeqMotionParam = new SubSeqLaserMotionParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqMotionParam[i] = param[i] as SubSeqLaserMotionParam;
            }
        }
        public void AddHeaterParameter<T>(params T[] param)
        {
            m_SubSeqHeaterParam = new SubSeqLaserHeaterParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqHeaterParam[i] = param[i] as SubSeqLaserHeaterParam;
            }
        }

        public EN_MONITOR_RESULT GetMonitorResult()
        {
            return m_enMonitorResult;
        }
        private bool CheckLaserParameterUsed(int nLaser, int nParamIndex)
        {
            return (m_SubSeqParam[nLaser].LaserUsed && m_SubSeqParam[nLaser].ParamUsed[nParamIndex]);
        }
        private bool CheckLaserSize()
        {
            bool bReturn = true;
            // i : Laser Index
            if(m_SubControlOutputProfile.GetLength(1) < 2)
            {
                return bReturn;
            }
            for (int i = 0; i < m_SubControlOutputProfile.GetLength(0); i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;
                double dLaserSizeX = m_SubSeqParam[i].LaserSizeX[0, nParamIndex];
                double dLaserSizeY = m_SubSeqParam[i].LaserSizeY[0, nParamIndex];

                // (POWER = 0, SIZEX = 1, SIZEY = 2)
                bReturn &= m_SubControlOutputProfile[i, 1].CheckOutputCurrent(dLaserSizeX);
                bReturn &= m_SubControlOutputProfile[i, 2].CheckOutputCurrent(dLaserSizeY);
            }
            return bReturn;
        }
        private bool ReadyOutputProfile()
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlOutputProfile.GetLength(0); i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                int nTotalStep = m_SubSeqParam[i].LaserPower.GetLength(0);

                double[] arLaserPower = new double[nTotalStep];
                double[] arLaserSizeX = new double[nTotalStep];
                double[] arLaserSizeY = new double[nTotalStep];
                int[] arTime = new int[nTotalStep];
                string[] arPowerMode = new string[nTotalStep];
                string[] arSizeMode = new string[nTotalStep];

                for (int j = 0; j < nTotalStep; j++)
                {
                    arLaserPower[j] = m_SubSeqParam[i].LaserPower[j, nParamIndex];
                    arLaserSizeX[j] = m_SubSeqParam[i].LaserSizeX[j, nParamIndex];
                    arLaserSizeY[j] = m_SubSeqParam[i].LaserSizeY[j, nParamIndex];
                    arTime[j] = m_SubSeqParam[i].LaserTime[j, nParamIndex];
                    arPowerMode[j] = m_SubSeqParam[i].LaserPowerMode[j, nParamIndex];
                    arSizeMode[j] = m_SubSeqParam[i].LaserSizeMode[j, nParamIndex];
                }

                List<double[]> lstProcess = new List<double[]>();
                List<string[]> lstMode = new List<string[]>();

                lstProcess.Add(arLaserPower);
                lstProcess.Add(arLaserSizeX);
                lstProcess.Add(arLaserSizeY);

                lstMode.Add(arPowerMode);
                lstMode.Add(arSizeMode);
                lstMode.Add(arSizeMode);

                // (POWER = 0, SIZEX = 1, SIZEY = 2)
                for (int k = 0; k < m_SubControlOutputProfile.GetLength(1); k++)
                {
                    bool bOutputKeepMode = false;
                    switch(k)
                    {
                        case 0:
                            bOutputKeepMode = m_SubSeqParam[i].KeepLastValuePower;
                            break;
                        case 1:
                            bOutputKeepMode = m_SubSeqParam[i].KeepLastValueSizeX;
                            break;
                        case 2:
                            bOutputKeepMode = m_SubSeqParam[i].KeepLastValueSizeY;
                            break;
                    }
                    bReturn &= m_SubControlOutputProfile[i, k].ReadyOutputProfile(lstProcess[k]
                                                                                 , arTime
                                                                                 , lstMode[k]
                                                                                 , bOutputKeepMode);
                }
            }

            return bReturn;
        }
        private void EntryDeviceControl()
        {
            // i : Laser Index
            for (int i = 0; i < m_SubControlDevice.Length; i++)
            {
               m_SubControlDevice[i].EntryDeviceControl();
            }
        }

        private bool EntryModulationControl()
        {
            bool bReturn = true;
            if (m_SubControlModulation != null)
            {
                for (int i = 0; i < m_SubControlModulation.Length; i++)
                {

                    if (m_SubSeqModulationParam != null
                        && m_SubSeqModulationParam.Length > i 
                        && m_SubSeqModulationParam[i].ModulationUsed)
                       bReturn &= m_SubControlModulation[i].EntryModulationControl();
                }
            }
            return bReturn;
        }
        private bool ReadyDeviceSetting()
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlDevice.Length; i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                bReturn &= m_SubControlDevice[i].ReadyDeviceSetting();
            }

            return bReturn;
        }

        private bool ReadyMudulationSetting()
        {
            bool bReturn = true;
            if (m_SubControlModulation != null)
            {
                for (int i = 0; i < m_SubControlModulation.Length; i++)
                {
                    if (m_SubSeqModulationParam[i].ModulationUsed)
                        bReturn &= m_SubControlModulation[i].ReadyMudulationSetting(m_SubSeqModulationParam[i].ModulationTime, m_SubSeqModulationParam[i].ModulationFrequency, m_SubSeqModulationParam[i].ModulationDuty);
                }
            }
            return bReturn;
        }
        private bool StartWorkToDevice()
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlDevice.Length; i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                bReturn &= m_SubControlDevice[i].StartWorkToDevice();
            }

            return bReturn;
        }
        private bool StartOutputProfile(ref double[] arTotalTime)
        {
            bool bReturn = true;

             // imax * jmax
             int nDeviceCount = m_SubControlOutputProfile.GetLength(0) * m_SubControlOutputProfile.GetLength(1);
             // i : Laser Index
            for (int i = 0; i < m_SubControlOutputProfile.GetLength(0); i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                // (POWER = 0, SIZEX = 1, SIZEY = 2)
                for (int j = 0; j < m_SubControlOutputProfile.GetLength(1); j++)
                {
                    // imax * jmax = 2 * 3 = 6
                    bReturn &= m_SubControlOutputProfile[i, j].StartOutputProfile(true, nDeviceCount);
                }

                for (int k = 0; k < m_SubSeqParam[i].LaserTime.GetLength(0); k++)
                {
                    arTotalTime[i] += m_SubSeqParam[i].LaserTime[k, nParamIndex];
                }
            }

            return bReturn;
        }
        private bool StartMonitor()
        {
            bool bReturn = true;
            if (m_SubControlMonitor != null)
            {
                for (int i = 0; i < m_SubControlMonitor.Length; i++)
                {
                    bool bUsed = m_SubSeqMonitorParam[i].MonitorUsed;

                    if ((bUsed && m_SubSeqMonitorParam[i].PowerCheckUsed) == false)
                        arMonitoringStepInTarget[i] = true;

                    bReturn &= m_SubControlMonitor[i].StartMonitor(bUsed);
                }
            }
            return bReturn;
        }
        
        private bool MoveMotion()
        {
            bool bReturn = true;
            if (m_SubControlMotion != null)
            {
                for (int i = 0; i < m_SubControlMotion.Length; i++)
                {
                        bReturn &= m_SubControlMotion[i].MoveDuringLaser(m_SubSeqMotionParam[i].MotionUsed
                                                                        , m_SubSeqMotionParam[i].Level
                                                                      , m_SubSeqMotionParam[i].Velocity
                                                                      , m_SubSeqMotionParam[i].Time)
                                  == Motion_.MOTION_RESULT.OK; 
                }
            }
            return bReturn;
        }

        private bool CheckMotionDone()
        {
            bool bReturn = true;
            if (m_SubControlMotion != null)
            {
                for (int i = 0; i < m_SubControlMotion.Length; i++)
                {
                    bReturn &= m_SubControlMotion[i].CheckMotionDone();
                }
            }
            return bReturn;
        }
        private bool StartModulation()
        {
            bool bReturn = true;
            if (m_SubControlModulation != null)
            {
                for (int i = 0; i < m_SubControlModulation.Length; i++)
                {
                    if (m_SubSeqModulationParam[i].ModulationUsed)
                        bReturn &= m_SubControlModulation[i].StartModulation();
                }
            }
            return bReturn;
        }
        private bool WorkingOutputProfile(ref int[,] arElapsedTime)
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlOutputProfile.GetLength(0); i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                // (POWER = 0, SIZEX = 1, SIZEY = 2)
                for (int j = 0; j < m_SubControlOutputProfile.GetLength(1); j++)
                {
                    bReturn &= m_SubControlOutputProfile[i, j].WorkingOutputProfile(ref arElapsedTime[i, j]);
                }
            }

            return bReturn;
        }

        private void WorkingModulation()
        {
            bool bReturn = true;
            if (m_SubControlModulation != null)
            {
                for (int i = 0; i < m_SubControlModulation.Length; i++)
                {
                    if (m_SubSeqModulationParam[i].ModulationUsed)
                        bReturn &= m_SubControlModulation[i].WorkingModulation();
                }
            }

        }

        private void EntryPowerMonitor()
        {
            if (m_SubControlMonitor != null)
            {
                for (int i = 0; i < m_SubControlMonitor.Length; i++)
                {
                    arMonitoringStep[i] = 0;
                    arMonitoringStepTime[i] = 0;
                    arMonitoringStepInTarget[i] = false;
                }
            }
        }
        private EN_MONITOR_RESULT MonitorDuringLaser(int nTime)
        {
            if (m_SubControlMonitor != null)
            {
                for (int i = 0; i < m_SubControlMonitor.Length; i++)
                {
                    #region Temp
                    bool bUsed = m_SubSeqMonitorParam[i].MonitorUsed;
                    bool bTempCheckUsed = m_SubSeqMonitorParam[i].TempCheckUsed && bUsed;
                    double dEMGTarget = m_SubSeqMonitorParam[i].AbortTemp;
                    if (m_SubControlMonitor[i].CheckEMG(bTempCheckUsed, dEMGTarget))
                        return EN_MONITOR_RESULT.EMG;

                    if (bTempCheckUsed)
                    {
                        int nTotalSectionTime = 0;
                        for (int nSectionIndex = 0; nSectionIndex < 5; nSectionIndex++)
                        {
                            if (m_SubSeqMonitorParam[i].SectionTime[nSectionIndex] == 0)
                                break;

                            if (nTotalSectionTime < nTime
                                && nTotalSectionTime + m_SubSeqMonitorParam[i].SectionTime[nSectionIndex] > nTime)
                            {
                                if (m_SubControlMonitor[i].GetTemp() > m_SubSeqMonitorParam[i].SectionHighTemp[nSectionIndex])
                                    return EN_MONITOR_RESULT.HIGH_TEMP;

                                if (m_SubControlMonitor[i].GetTemp() < m_SubSeqMonitorParam[i].SectionLowTemp[nSectionIndex])
                                    return EN_MONITOR_RESULT.LOW_TEMP;
                            }
                            nTotalSectionTime += m_SubSeqMonitorParam[i].SectionTime[nSectionIndex];
                        }
                    }

                    bool bAbortUsed = m_SubSeqMonitorParam[i].AbortUsed && bTempCheckUsed;
                    double dAbortTarget = m_SubSeqMonitorParam[i].AbortTemp;

                    if (m_SubControlMonitor[i].CheckAbort(bAbortUsed, dAbortTarget))
                        return EN_MONITOR_RESULT.ABORT;
                    #endregion Temp

                    #region Power
                    bool bPowerCheckUsed = m_SubSeqMonitorParam[i].PowerCheckUsed && bUsed;
                    if (bPowerCheckUsed)
                    {
                        double dPowerTolerance = m_SubSeqMonitorParam[i].PowerCheckTolerance;
                        int nParamIndex = m_SubSeqParam[m_SubSeqMonitorParam[i].MonitorWorkParameterIndex].CurrentParamIndex - 1;

                        if (nTime > arMonitoringStepTime[i])
                        {
                            if (arMonitoringStepTime[i] != 0)
                            {
                                arMonitoringStep[i]++;
                                if (arMonitoringStepInTarget[i] == false)
                                    return EN_MONITOR_RESULT.POWER_TOLERANCE_OVER;
                                //Console.WriteLine("Next Step");
                            }

                            arMonitoringStepTime[i] += m_SubSeqParam[m_SubSeqMonitorParam[i].MonitorWorkParameterIndex].LaserTime[arMonitoringStep[i], nParamIndex];

                            arMonitoringStepInTarget[i] = false;
                        }
                        double dLaserPower = m_SubSeqParam[m_SubSeqMonitorParam[i].MonitorWorkParameterIndex].LaserPower[arMonitoringStep[i], nParamIndex];

                        if (m_SubControlMonitor[i].CheckPower(bPowerCheckUsed, dLaserPower, dPowerTolerance))
                        {
                            arMonitoringStepInTarget[i] = true;
                        }
                        else
                        {
                            if (arMonitoringStepInTarget[i])
                            {
                                return EN_MONITOR_RESULT.POWER_TOLERANCE_OVER;
                            }
                        }
                    }
                    #endregion Power
                }
            }
            return EN_MONITOR_RESULT.NORMAL;
        }
        private EN_MONITOR_RESULT CheckPowerIntarget()
        {
            if (m_SubControlMonitor != null)
            {
                for (int i = 0; i < m_SubControlMonitor.Length; i++)
                {
                    if (arMonitoringStepInTarget[i] == false)
                        return EN_MONITOR_RESULT.POWER_TOLERANCE_OVER;
                }
            }
            return EN_MONITOR_RESULT.NORMAL;
        }

        private bool StopOutputProfile()
        {
            bool bReturn = true;

            // imax * jmax
            int nDeviceCount = m_SubControlOutputProfile.GetLength(0) * m_SubControlOutputProfile.GetLength(1);
            // i : Laser Index
            for (int i = 0; i < m_SubControlOutputProfile.GetLength(0); i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                // (POWER = 0, SIZEX = 1, SIZEY = 2)
                for (int j = 0; j < m_SubControlOutputProfile.GetLength(1); j++)
                {
                    // imax * jmax = 2 * 3 = 6
                    bool bOutputKeepMode = false;
                    switch (j)
                    {
                        case 0:
                            bOutputKeepMode = m_SubSeqParam[i].KeepLastValuePower;
                            break;
                        case 1:
                            bOutputKeepMode = m_SubSeqParam[i].KeepLastValueSizeX;
                            break;
                        case 2:
                            bOutputKeepMode = m_SubSeqParam[i].KeepLastValueSizeY;
                            break;
                    }
                    bReturn &= m_SubControlOutputProfile[i, j].StopOutputProfile(bOutputKeepMode, false, nDeviceCount);
                }
            }

            return bReturn;
        }
        private bool StopWorkToDevice()
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlDevice.Length; i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                bReturn &= m_SubControlDevice[i].StopWorkToDevice();
            }

            return bReturn;
        }
        private bool StopMonitor()
        {
            bool bReturn = true;
            if (m_SubControlMonitor != null)
            {
                for (int i = 0; i < m_SubControlMonitor.Length; i++)
                {
                    bool bUsed = m_SubSeqMonitorParam[i].MonitorUsed;

                    bReturn &= m_SubControlMonitor[i].StopMonitor(bUsed);
                }
            }
            return bReturn;
        }
        private bool StopModulation()
        {
            bool bReturn = true;
            if (m_SubControlModulation != null)
            {
                for (int i = 0; i < m_SubControlModulation.Length; i++)
                {
                    if (m_SubSeqModulationParam[i].ModulationUsed)
                        bReturn &= m_SubControlModulation[i].StopModulation();
                }
            }
            return bReturn;
        }
        private bool FinishDevice()
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlDevice.Length; i++)
            {
                int nParamIndex = m_SubSeqParam[i].CurrentParamIndex - 1;

                if (CheckLaserParameterUsed(i, nParamIndex).Equals(false))
                    continue;

                bReturn &= m_SubControlDevice[i].FinishDevice();
            }

            return bReturn;
        }
        private bool FinishModulation()
        {
            bool bReturn = true;
            if (m_SubControlModulation != null)
            {
                for (int i = 0; i < m_SubControlModulation.Length; i++)
                {
                    if (m_SubSeqModulationParam[i].ModulationUsed)
                        bReturn &= m_SubControlModulation[i].FinishModulation();
                }
            }
            return bReturn;
        }
        private bool InitializeDevice()
        {
            bool bReturn = true;

            // i : Laser Index
            for (int i = 0; i < m_SubControlDevice.Length; i++)
            {
                bReturn &= m_SubControlDevice[i].InitializeDevice();
            }

            return bReturn;
        }

        #region Heater
        private bool ReadyHeater()
        {
            bool bReturn = true;
            if (m_SubControlHeater != null)
            {
                for (int i = 0; i < m_SubControlHeater.Length; i++)
                {
                    bReturn &= m_SubControlHeater[i].ReadyHeater(m_SubSeqHeaterParam[i].HeaterIndex);
                }
            }
            return bReturn;
        }

        private bool StartHeaterTempProfile()
        {
            bool bReturn = true;
            if (m_SubControlHeater != null)
            {
                for (int i = 0; i < m_SubControlHeater.Length; i++)
                {
                    bReturn &= m_SubControlHeater[i].StartTempProfile(m_SubSeqHeaterParam[i].HeaterIndex);
                }
            }
            return bReturn;
        }

        private bool StartHeaterCooling()
        {
            bool bReturn = true;
            if (m_SubControlHeater != null)
            {
                for (int i = 0; i < m_SubControlHeater.Length; i++)
                {
                    bReturn &= m_SubControlHeater[i].StartCooling(m_SubSeqHeaterParam[i].HeaterIndex, m_SubSeqHeaterParam[i].HeaterOffCooling);
                }
            }
            return bReturn;
        }
        #endregion </Heater>
        #endregion </METHOD>
    }
    
}
