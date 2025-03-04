using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Config;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.AjinAnalogOutputProfile;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace AjinAnalogOutputProfile
    {
        public enum EN_ANALOG_OUTPUT
        {
            OUTPUT = 0,
        }
    }

    //2021.05.26 [ADD] by wdw Ajin List 출력 
    //Analog 직접 제어 함으로 Init Deivice 등록 시 TargetIndex 등록
    class SubCtrlOutputProfileAjinAnalog : ASubControl, IOutputProfile
    {
        #region <ENUMERATION>
        private enum EN_OUTPUT_MODE
        {
            STEP,
            LINEAR
        }
        #endregion </ENUMERATION>

        #region <CONSTANT>
        private const int DEFAULT_VALUE_INDEX = 0;
        private const int DEFAULT_TIME_INDEX = 1;
        private const int DEFAULT_MODE_INDEX = 2;

        private const int MAX_STEP = 5;
        private const int MAX_TABLE = 8196;
        #endregion </CONSTANT>

        #region <FIELD>
        // 복수의 Output Profile 을 동시에 출력하기 위한 Analog Device Index 모음 
        private static List<int> m_lstDeviceTargetKeys = new List<int>();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlOutputProfileAjinAnalog(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
			m_InstanceDevice	= Config.ConfigDevice.GetInstance();
			m_InstanceAnalog	= AnalogIO_.AnalogIO.GetInstance();
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public bool CheckOutputCurrent(double dOutput)
        {
            int nTargetKey = 0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                            , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                            , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                            , ref nTargetKey);

            double dCurrntValue = m_InstanceAnalog.ReadInputValue(nTargetKey);
            //Analog 제어 기준, Tolerance 하드코딩 나중에 파라미터로 적용
            if (Math.Abs(dCurrntValue - dOutput) > 0.2)
            {
                m_InstanceAnalog.WriteOutputValue(nTargetKey, dOutput);
                return false;
            }

            return true;
        }
        
        public bool ReadyOutputProfile(double[] dOutput, int[] nTime, string[] sMode, bool bKeepLastValue)
        {
            int StepCounts = dOutput.Length;

            dOutput = ConvertValueToVolt(dOutput);

            // RESET LIST TABLE
            ResetAnalogListTable();

            // INTERVAL
            int nTotalTime = 0;
            for (int i = 0; i < StepCounts; ++i)
            {
                nTotalTime += nTime[i];
            }

            int nInterval = (nTotalTime / MAX_TABLE) + 1;

            SetAnalogListTableInterval(nInterval);

            // MAKE LIST TABLE
            int nListCount = 0;
            double[] arListTable = new double[MAX_TABLE];

            for (int i = 0; i < StepCounts; ++i)
            {
                MakeProcessListTable(nTime[i], dOutput[i], sMode[i], nInterval, ref nListCount, ref arListTable);
            }

            if (bKeepLastValue.Equals(false))
                nListCount += 1;

            SetValueToListTable(nListCount, ref arListTable);

            return true;
        }
        /// <summary>
        /// bTimeSyncOutputs = true 인 경우, nTimeSyncCounts 의 수량만큼 TargetKey 를 수집하고, 수량이 일치할 때 동시출력한다.
        /// </summary>
        public bool StartOutputProfile(bool bTimeSyncOutputs = false, int nTimeSyncCounts = 1)
        {
            int nTargetKey = 0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                                    , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                                    , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                                    , ref nTargetKey);

            if (bTimeSyncOutputs)
            {
                m_lstDeviceTargetKeys.Add(nTargetKey);

                if (m_lstDeviceTargetKeys.Count.Equals(nTimeSyncCounts))
                {
                    int[] arIndex = m_lstDeviceTargetKeys.ToArray();

                    m_InstanceAnalog.StartOutputListTable(ref arIndex, arIndex.Length);

                    m_lstDeviceTargetKeys.Clear();
                }
            }
            else
            {
                int[] arIndex = new int[] { nTargetKey };

                m_InstanceAnalog.StartOutputListTable(ref arIndex, arIndex.Length);
            }

            return true;
        }
        public bool WorkingOutputProfile(ref int nElapsedTime)
        {
            int nTargetKey = 0;
            int nPatternIndex = 0;
            int nCountOfLoop = 0;
            uint nBusy = 0;
            double dInterval = 0.0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                                    , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                                    , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                                    , ref nTargetKey);

            m_InstanceAnalog.GetOutputListTableStatus(nTargetKey, ref nPatternIndex, ref nCountOfLoop, ref nBusy);

            m_InstanceAnalog.GetOutputListTableInterval(nTargetKey, ref dInterval);

            nElapsedTime = nPatternIndex * (int)dInterval;

            return nBusy == 0;
        }
        public bool StopOutputProfile(bool bKeepLastValue, bool bTimeSyncOutputs = false, int nTimeSyncCounts = 1)
        {
            if (bKeepLastValue.Equals(false))
            {
                int nTargetKey = 0;

                m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                                    , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                                    , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                                    , ref nTargetKey);

                if (bTimeSyncOutputs)
                {
                    m_lstDeviceTargetKeys.Add(nTargetKey);

                    if (m_lstDeviceTargetKeys.Count.Equals(nTimeSyncCounts))
                    {
                        int[] arIndex = m_lstDeviceTargetKeys.ToArray();

                        m_InstanceAnalog.StopOutputListTable(ref arIndex, arIndex.Length);

                        m_lstDeviceTargetKeys.Clear();
                    }
                }
                else
                {
                    int[] arIndex = new int[] { nTargetKey };

                    m_InstanceAnalog.StopOutputListTable(ref arIndex, arIndex.Length);
                }
            }
            
            return true;
        }
        #endregion </INTERFACE>

        #region <METHOD>
        private double[] ConvertValueToVolt(double[] dValue)
        {
            int nTargetKey = 0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                                    , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                                    , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                                    , ref nTargetKey);

            double[] dVolt = new double[dValue.Length];

            for (int i = 0; i < dValue.Length; ++i)
            {
                dVolt[i] = m_InstanceAnalog.GetConvertedVoltFromTable(false, nTargetKey, dValue[i]);
            }

            return dVolt;
        }
        private void ResetAnalogListTable()
        {
            int nTargetKey = 0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                            , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                            , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                            , ref nTargetKey);

            m_InstanceAnalog.ResetOutputListTable(nTargetKey);
        }
        private void SetAnalogListTableInterval(double dInterval)
        {
            int nTargetKey = 0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                                    , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                                    , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                                    , ref nTargetKey);

            m_InstanceAnalog.SetOutputListTableInterval(nTargetKey, dInterval);
        }
        private void MakeProcessListTable(int nStepTime, double dOutput, string sMode, int nInterval, ref int nListCount, ref double[] arListTable)
        {
            EN_OUTPUT_MODE enOutputMode = EN_OUTPUT_MODE.STEP;
            Enum.TryParse(sMode, out enOutputMode);

            int nStepCount = nStepTime / nInterval;

            switch (enOutputMode)
            {
                case EN_OUTPUT_MODE.STEP:
                    for (int i = nListCount; i < nListCount + nStepCount; i++)
                    {
                        arListTable[i] = dOutput;
                    }

                    nListCount += nStepCount;
                    break;
                case EN_OUTPUT_MODE.LINEAR:
                    double dLastProcess = 0;

                    if (nListCount > 0)
                        dLastProcess = arListTable[nListCount - 1];

                    double dIncreaseProcess = (dOutput - dLastProcess) / nStepCount;
                    double dCurrentProcess = dLastProcess;

                    // repeat : 기존 TotalTime 이후, repeat < repeat + StepTime + 1 : 다음 Step Time 값 + 기존 Total Time 값 합친 범위
                    for (int i = nListCount; i < nListCount + nStepCount; i++)
                    {
                        dCurrentProcess += dIncreaseProcess;
                        arListTable[i] = dCurrentProcess;
                    }

                    nListCount += nStepCount;
                    break;
            }
        }
        private void SetValueToListTable(int nSizeOfPattern, ref double[] arPattern)
        {
            int nTargetKey = 0;

            m_InstanceDevice.GetDeviceTargetIndex(m_InstanceTask.GetTaskName()
                                                    , ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT
                                                    , p_dicOfAnalogOutput[(int)EN_ANALOG_OUTPUT.OUTPUT]
                                                    , ref nTargetKey);

            m_InstanceAnalog.SetOutputListTable(nTargetKey, 1, nSizeOfPattern, ref arPattern);
        }
        #endregion </METHOD>
    }
}
