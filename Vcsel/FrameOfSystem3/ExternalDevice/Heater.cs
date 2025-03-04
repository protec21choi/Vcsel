using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.Heater;
using Define.DefineEnumProject.Serial;
using FrameOfSystem3.ExternalDevice.Heater;
using Serial_;

using Define.DefineEnumProject.Task;

using FrameOfSystem3.Recipe;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;

namespace FrameOfSystem3.ExternalDevice.Heater
{
    public enum EN_HEATER_COMMAND
    {
        RUN,
        STOP,
        SET_TEMP,
        SET_OFFSET,
        GET_TEMP,
        GET_SETTING_TEMP,
        GET_OFFSET,
        GET_RUN_STATUS,


        //CERAMIC HEATER PROFILE
        #region 
        RUN_PROFILE,
        SET_PROFILE_USE_COUNT,
        SET_PROFILE_TEMP_STEP_1,
        SET_PROFILE_TEMP_STEP_2,
        SET_PROFILE_TEMP_STEP_3,
        SET_PROFILE_TEMP_STEP_4,
        SET_PROFILE_TEMP_STEP_5,

        SET_PROFILE_TIME_STEP_1,
        SET_PROFILE_TIME_STEP_2,
        SET_PROFILE_TIME_STEP_3,
        SET_PROFILE_TIME_STEP_4,
        SET_PROFILE_TIME_STEP_5,
        #endregion
    }

    public class Heater
    {
        #region 변수
        //Key : HeaterZone Index
        private Dictionary<int, HeaterZone> m_dicofHeaterZone = new Dictionary<int, HeaterZone>();
        private Dictionary<int, int> m_dicofSerialIndex = new Dictionary<int, int>();
        private Dictionary<int, int> m_dicofSocketIndex = new Dictionary<int, int>();

        //Key : Serial Index
        private Dictionary<int, ConcurrentQueue<EN_HEATER_COMMAND>> m_dicofSerialCommand = new Dictionary<int, ConcurrentQueue<EN_HEATER_COMMAND>>();
        //Key : Socket Index
        private Dictionary<int, ConcurrentQueue<EN_HEATER_COMMAND>> m_dicofSocketCommand = new Dictionary<int, ConcurrentQueue<EN_HEATER_COMMAND>>();
        #endregion

        #region 싱글톤
        private Heater() 
        {
        }
        private static Heater _Instance = null;
        public static Heater GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Heater();
            }
            return _Instance;
        }
        #endregion

        #region 외부 인터페이스
        #region 초기화 및 종료
        public bool AddSerialHeaterZone(int nHeaterZoneIndex, int nSerialIndex, int nStartChanelIdex, int arChannelCount) //ArrayCount = HeaterZoneCount, Value = HeaterChenelCount
        {
            if (!m_dicofSerialCommand.ContainsKey(nSerialIndex))
                m_dicofSerialCommand.Add(nSerialIndex, new ConcurrentQueue<EN_HEATER_COMMAND>());
            m_dicofHeaterZone.Add(nHeaterZoneIndex, new HeaterZone(nStartChanelIdex, arChannelCount));
            m_dicofSerialIndex.Add(nHeaterZoneIndex, nSerialIndex);
            SetCommand(nHeaterZoneIndex, EN_HEATER_COMMAND.GET_RUN_STATUS);
            return true;
        }

        public bool AddSocketHeaterZone(int nHeaterZoneIndex, int nSocketIndex, int nStartChanelIdex, int arChannelCount) //ArrayCount = HeaterZoneCount, Value = HeaterChenelCount
        {
            if (!m_dicofSocketCommand.ContainsKey(nSocketIndex))
                m_dicofSocketCommand.Add(nSocketIndex, new ConcurrentQueue<EN_HEATER_COMMAND>());
            m_dicofHeaterZone.Add(nHeaterZoneIndex, new HeaterZone(nStartChanelIdex, arChannelCount));
            m_dicofSocketIndex.Add(nHeaterZoneIndex, nSocketIndex);
            SetCommand(nHeaterZoneIndex, EN_HEATER_COMMAND.GET_RUN_STATUS);
            return true;
        }
        #endregion

        #region 아이템 값 갱신
        public void SetRunStatus(int nZoneIndex, bool bValue, bool bSendCommand = true)
        {
            if (m_dicofHeaterZone.Count == 0 ||
                !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            if (bSendCommand)
            {
                if (bValue)
                {
                    SetCommand(nZoneIndex, EN_HEATER_COMMAND.RUN);
                    m_dicofHeaterZone[nZoneIndex].bInTarget = false;
                }
                else
                    SetCommand(nZoneIndex, EN_HEATER_COMMAND.STOP);

                SetCommand(nZoneIndex, EN_HEATER_COMMAND.GET_RUN_STATUS);
            }
        }

        public void SetRunStatus(int nZoneIndex, int nChIndex, bool bValue, bool bSendCommand = true)
        {
            if (m_dicofHeaterZone.Count == 0 ||
                !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            if (bSendCommand)
            {
                if (bValue)
                {
                    SetCommand(nZoneIndex, nChIndex, EN_HEATER_COMMAND.RUN);
                    m_dicofHeaterZone[nZoneIndex].bInTarget = false;
                }
                else
                    SetCommand(nZoneIndex, nChIndex, EN_HEATER_COMMAND.STOP);

                
                SetCommand(nZoneIndex, nChIndex, EN_HEATER_COMMAND.GET_RUN_STATUS);
            }
        }
        public void SetTargetTemp(int nZoneIndex, double dValue, bool bSendCommand = true)
        {
            if (m_dicofHeaterZone.Count == 0 ||
                !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetTargetTemp(dValue);

            if (bSendCommand)
            {
                SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_TEMP);
                m_dicofHeaterZone[nZoneIndex].bInTarget = false;
            }
        }

        public void SetTempOffset(int nZoneIndex, double dValue, bool bSendCommand = true)
        {
            if (m_dicofHeaterZone.Count == 0 ||
                 !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetTempOffset(dValue);

            if (bSendCommand)
                SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_OFFSET);

        }
        public void SetChannelTempOffset(int nZoneIndex, int nChannelIndex, double dValue, bool bSendCommand = true)
        {
            if (m_dicofHeaterZone.Count == 0
                || !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;


            m_dicofHeaterZone[nZoneIndex].SetChannelTempOffset(nChannelIndex, dValue);

            if (bSendCommand)
                SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_OFFSET);
        }

        public void SetTempMinusTolerance(int nZoneIndex, double dValue)
        {
            if (m_dicofHeaterZone.Count == 0
                || !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetTempMinusTolerance(dValue);
        }

        public void SetTempPlusTolerance(int nZoneIndex, double dValue)
        {
            if (m_dicofHeaterZone.Count == 0
                || !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetTempPlusTolerance(dValue);
        }

        #region Profile
        public void RunProfile(int nZoneIndex)
        {
            if (m_dicofHeaterZone.Count == 0 ||
                !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            SetCommand(nZoneIndex, EN_HEATER_COMMAND.RUN_PROFILE);
        }
        public void SetPorofileCount(int nZoneIndex, int nValue, bool bSendCommand = true)
        {
            if (m_dicofHeaterZone.Count == 0
                || !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetProfileCount(nValue);

            if (bSendCommand)
                SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_USE_COUNT);
        }

        public void SetPorofileTemp(int nZoneIndex, int nStep, double Value, bool bSendCommand = true)    //step은 0번 부터
        {
            if (m_dicofHeaterZone.Count == 0
                || !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetProfileTemp(nStep, Value);

            if (bSendCommand)
            {
                switch (nStep)
                {
                    case 0:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_1);
                        break;
                    case 1:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_2);
                        break;
                    case 2:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_3);
                        break;
                    case 3:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_4);
                        break;
                    case 4:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_5);
                        break;
                }
            }
        }

        public void SetPorofileTime(int nZoneIndex, int nStep, double Value, bool bSendCommand = true)    //step은 0번 부터
        {
            if (m_dicofHeaterZone.Count == 0
                || !m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return;

            m_dicofHeaterZone[nZoneIndex].SetProfileTime(nStep, Value);

            if (bSendCommand)
            {
                SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_USE_COUNT);
            }

            if (bSendCommand)
            {
                switch (nStep)
                {
                    case 0:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_1);
                        break;
                    case 1:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_2);
                        break;
                    case 2:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_3);
                        break;
                    case 3:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_4);
                        break;
                    case 4:
                        SetCommand(nZoneIndex, EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_5);
                        break;
                }
            }
        }
        #endregion /Profile
        #endregion

        #region 아이템 값 반환
        /// <summary> Error 면 true </summary>
        public bool IsError(int nZoneIndex)
        {
            return m_dicofHeaterZone[nZoneIndex].IsError();
        }
        public bool GetRunStatus(int nZoneIndex, int nChannel)
        {
            if (m_dicofHeaterZone.Count == 0)
                return false;

            return m_dicofHeaterZone[nZoneIndex].HeaterDatas[nChannel].bRunStatus;
        }
        public double GetMeanValue(int nZoneIndex)
        {
            if (m_dicofHeaterZone.ContainsKey(nZoneIndex))
                return m_dicofHeaterZone[nZoneIndex].dMeanValue;
            else return 0;
        }
        public double GetMeasuredValue(int nZoneIndex, int nChannel)
        {
            if (m_dicofHeaterZone.Count == 0)
                return 0;

            return m_dicofHeaterZone[nZoneIndex].HeaterDatas[nChannel].dMeasured;
        }
        #endregion
        #endregion

        #region Controller Interface
        #region Serial
        public EN_HEATER_COMMAND GetSerialCommand(int nSerialIndex)
        {
            EN_HEATER_COMMAND enCommand = EN_HEATER_COMMAND.GET_TEMP;
            if (m_dicofSerialCommand.ContainsKey(nSerialIndex))
            {
                if(!m_dicofSerialCommand[nSerialIndex].TryDequeue(out enCommand))
                    enCommand = EN_HEATER_COMMAND.GET_TEMP;
            }

            //Serial Command 호출 되면 Channel Command 사용 안 됨
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    foreach (var Channel in m_dicofHeaterZone[kpv.Key].HeaterDatas)
                    {
                        Channel.Value.ClearCommand();
                    }
                }
            }
            return enCommand;
        }
        public EN_HEATER_COMMAND GetSerialCommand(int nSerialIndex, int nChannelIndx)
        {
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    return m_dicofHeaterZone[kpv.Key].GetHeaterCommand(nChannelIndx);
                }
            }

            //Channel Command 호출 되면 Serial Command 사용 안 됨.
            EN_HEATER_COMMAND enClearCommand;
            while (m_dicofSerialCommand[nSerialIndex].TryDequeue(out enClearCommand))
            {

            }
            return EN_HEATER_COMMAND.GET_TEMP;
        }

        public void SetSerialCommand(int nSerialIndex, EN_HEATER_COMMAND enCommand)
        {
            if (m_dicofSerialCommand.ContainsKey(nSerialIndex))
            {
                m_dicofSerialCommand[nSerialIndex].Enqueue(enCommand);
            }
        }

        public void SetSerialCommand(int nSerialIndex, int nChannelIndx, EN_HEATER_COMMAND enCommand)
        {
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    m_dicofHeaterZone[kpv.Key].SetHeaterCommand(nChannelIndx, enCommand);
                }
            }
        }

        public double GetSerialTargetTemp(int nSerialIndex, int nChannelIndx)
        {
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                    {
                        return m_dicofHeaterZone[kpv.Key].dSettingValue;
                    }
                }
            }
            return 0;
        }
        public double GetSerialOffsetTemp(int nSerialIndex, int nChannelIndx)
        {
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                    {
                        return m_dicofHeaterZone[kpv.Key].dOffsetValue
                                + m_dicofHeaterZone[kpv.Key].HeaterDatas[nChannelIndx].dOffset;
                    }
                }
            }
            return 0;
        }
        public void SetSerialTempMeasurdValue(int nSerialIndex, int nChannelIndx, double dTemp)
        {
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    m_dicofHeaterZone[kpv.Key].SetMeasuredValue(nChannelIndx, dTemp);
                }
            }
        }
        public void SetSerialRunStatus(int nSerialIndex, int nChannelIndx, bool bRunStatus)
        {
            foreach (var kpv in m_dicofSerialIndex)
            {
                if (kpv.Value == nSerialIndex)
                {
                    if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                    {
                        m_dicofHeaterZone[kpv.Key].HeaterDatas[nChannelIndx].bRunStatus = bRunStatus;
                    }
                }
            }
        }
        #endregion Serial

        #region Socket
        public EN_HEATER_COMMAND GetSocketCommand(int nSocketIndex)
        {
            EN_HEATER_COMMAND enCommand = EN_HEATER_COMMAND.GET_TEMP;
            if (m_dicofSocketCommand.ContainsKey(nSocketIndex))
            {
                m_dicofSocketCommand[nSocketIndex].TryDequeue(out enCommand);
            }

            //Socket Command 호출 되면 Channel Command 사용 안 됨
            foreach (var kpv in m_dicofSocketIndex)
            {
                if (kpv.Value == nSocketIndex)
                {
                    foreach (var Channel in m_dicofHeaterZone[kpv.Key].HeaterDatas)
                    {
                        Channel.Value.ClearCommand();
                    }
                }
            }
            return enCommand;
        }
        public EN_HEATER_COMMAND GetSocketCommand(int nSocketIndex, int nChannelIndx)
        {
            foreach (var kpv in m_dicofSocketIndex)
            {
                if (kpv.Value == nSocketIndex)
                {
                    return m_dicofHeaterZone[kpv.Key].GetHeaterCommand(nChannelIndx);
                }
            }

            //Channel Command 호출 되면 Socket Command 사용 안 됨.
            EN_HEATER_COMMAND enClearCommand;
            while (m_dicofSocketCommand[nSocketIndex].TryDequeue(out enClearCommand))
            {

            }
            return EN_HEATER_COMMAND.GET_TEMP;
        }


        public void SetSocketCommand(int nSocketIndex, EN_HEATER_COMMAND enCommand)
        {
            if (m_dicofSocketCommand.ContainsKey(nSocketIndex))
            {
                m_dicofSocketCommand[nSocketIndex].Enqueue(enCommand);
            }
        }

        public void SetSocketCommand(int nSocketIndex, int nChannelIndx, EN_HEATER_COMMAND enCommand)
        {
            foreach (var kpv in m_dicofSocketIndex)
            {
                if (kpv.Value == nSocketIndex)
                {
                    m_dicofHeaterZone[kpv.Key].SetHeaterCommand(nChannelIndx, enCommand);
                }
            }
        }

        public double GetSocketTargetTemp(int nSocketIndex, int nChannelIndx)
        {
            foreach (var kpv in m_dicofSocketIndex)
            {
                if (kpv.Value == nSocketIndex)
                {
                    if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                    {
                        return m_dicofHeaterZone[kpv.Key].dSettingValue;
                    }
                }
            }
            return 0;
        }
        public double GetSocketOffsetTemp(int nSocketIndex, int nChannelIndx)
        {
            foreach (var kpv in m_dicofSocketIndex)
            {
                if (kpv.Value == nSocketIndex)
                {
                    if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                    {
                        return m_dicofHeaterZone[kpv.Key].dOffsetValue
                                + m_dicofHeaterZone[kpv.Key].HeaterDatas[nChannelIndx].dOffset;
                    }
                }
            }
            return 0;
        }
         public void SetSocketTempMeasurdValue(int nSocketIndex, int nChannelIndx, double dTemp)
        {
            foreach (var kpv in m_dicofSocketIndex)
            {
                if (kpv.Value == nSocketIndex)
                {
                    m_dicofHeaterZone[kpv.Key].SetMeasuredValue(nChannelIndx, dTemp);
                }
            }
        }

         public void SetSocketRunStatus(int nSocketIndex, int nChannelIndx, bool bRunStatus)
         {
             foreach (var kpv in m_dicofSocketIndex)
             {
                 if (kpv.Value == nSocketIndex)
                 {
                     if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                     {
                         m_dicofHeaterZone[kpv.Key].HeaterDatas[nChannelIndx].bRunStatus = bRunStatus;
                     }
                 }
             }
         }

         public int GetSocketProfileCount(int nSocketIndex, int nChannelIndx)
         {
             foreach (var kpv in m_dicofSocketIndex)
             {
                 if (kpv.Value == nSocketIndex)
                 {
                     if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx))
                     {
                         return m_dicofHeaterZone[kpv.Key].nProfileUseCount;
                     }
                 }
             }
             return 0;
         }

         public double GetSocketProfileTemp(int nSocketIndex, int nChannelIndx, int nStep)
         {
             foreach (var kpv in m_dicofSocketIndex)
             {
                 if (kpv.Value == nSocketIndex)
                 {
                     if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx)
                         && m_dicofHeaterZone[kpv.Key].arProfileTemp.Length > nStep)
                     {
                         return m_dicofHeaterZone[kpv.Key].arProfileTemp[nStep];
                     }
                 }
             }
             return 0;
         }

         public double GetSocketProfileTime(int nSocketIndex, int nChannelIndx, int nStep)
         {
             foreach (var kpv in m_dicofSocketIndex)
             {
                 if (kpv.Value == nSocketIndex)
                 {
                     if (m_dicofHeaterZone[kpv.Key].HeaterDatas.ContainsKey(nChannelIndx)
                         && m_dicofHeaterZone[kpv.Key].arProfileTemp.Length > nStep)
                     {
                         return m_dicofHeaterZone[kpv.Key].arProfileTime[nStep];
                     }
                 }
             }
             return 0;
         }
        #endregion Socket

        #endregion

        #region Internal Interface
         private void SetCommand(int nZoneIndex, EN_HEATER_COMMAND enCommand)
         {
             if (m_dicofSerialIndex.ContainsKey(nZoneIndex))
             {
                 int nSerialIndex = m_dicofSerialIndex[nZoneIndex];
                 if (m_dicofSerialCommand.ContainsKey(nSerialIndex))
                 {
                     m_dicofSerialCommand[nSerialIndex].Enqueue(enCommand);
                 }
             }
             if (m_dicofSocketIndex.ContainsKey(nZoneIndex))
             {
                 int nSocketIndex = m_dicofSocketIndex[nZoneIndex];
                 if (m_dicofSocketCommand.ContainsKey(nSocketIndex))
                 {
                     m_dicofSocketCommand[nSocketIndex].Enqueue(enCommand);
                 }
             }
             m_dicofHeaterZone[nZoneIndex].SetHeaterCommand(enCommand);

         }

         private void SetCommand(int nZoneIndex, int nChIndex, EN_HEATER_COMMAND enCommand)
         {
             m_dicofHeaterZone[nZoneIndex].SetHeaterCommand(nChIndex, enCommand);
         }
        #endregion


    }

    public class HeaterZone
    {
        #region 변수
        private bool m_bInTarget = false;
        private double m_dSettingValue;
        private double m_dOffsetValue;
        private double m_dMeanValue;
        private double m_dMinusTolerance;
        private double m_dPlusTolerance;

        //23.02.25 by wdw [add] Profile data(우선 5개 하자)
        private int m_nProfileUseCount;
        private double[] m_arProfileTemp = new double[5];
        private double[] m_arProfileTime = new double[5];

        private ConcurrentDictionary<int, HeaterChannel> dicofHeater = new ConcurrentDictionary<int, HeaterChannel>();
        #endregion

        #region 생성자
        public HeaterZone(int nStartChannelIndex, int nChannlCount)
        {
            for (int i = nStartChannelIndex; i < nStartChannelIndex + nChannlCount; i++)
            {
                dicofHeater.TryAdd(i, new HeaterChannel(i));
            }
        }
        #endregion

        #region 속성
        public bool bInTarget { set { m_bInTarget = value; } get { return m_bInTarget; } }
        public ConcurrentDictionary<int, HeaterChannel> HeaterDatas { get { return dicofHeater; } }
        public double dSettingValue { get { return m_dSettingValue; } }
        public double dOffsetValue { get { return m_dOffsetValue; } }
        public double dMeanValue { get { return m_dMeanValue; } }
        
        //23.02.25 by wdw [add] Profile data
        public int nProfileUseCount { get { return m_nProfileUseCount; } }
        public double[] arProfileTemp { get { return m_arProfileTemp; } }
        public double[] arProfileTime { get { return m_arProfileTime; } }
        #endregion

        #region 외부 인터페이스
        public void SetTargetTemp(double dValue)
        {
            m_dSettingValue = dValue;
        }
        public void SetTempOffset(double dValue)
        {
            m_dOffsetValue = dValue;
        }
        public void SetTempPlusTolerance(double dValue)
        {
            m_dPlusTolerance = dValue;
        }
        public void SetTempMinusTolerance(double dValue)
        {
            m_dMinusTolerance = dValue;
        }
        public void SetChannelTempOffset(int nChannelIndex, double dValue)
        {
            if (dicofHeater.ContainsKey(nChannelIndex))
            {
                dicofHeater[nChannelIndex].dOffset = dValue;
            }
        }
    
        //23.02.25 by wdw [add] Profile Pattern data

        public void SetProfileCount(int nValue)
        {
            m_nProfileUseCount = nValue;
        }

        public void SetProfileTemp(int nStep, double dValue)    //step은 0번 부터
        {
            if (nStep >= m_arProfileTemp.Length)
                return;
            m_arProfileTemp[nStep] = dValue;
        }

        public void SetProfileTime(int nStep, double dValue)    //step은 0번 부터
        {
            if (nStep >= m_arProfileTemp.Length)
                return;
            m_arProfileTime[nStep] = dValue;
        }

        public EN_HEATER_COMMAND GetHeaterCommand(int nChannelIndex)
        {
            EN_HEATER_COMMAND enCommand = EN_HEATER_COMMAND.GET_TEMP;
            if (dicofHeater.ContainsKey(nChannelIndex))
            {
                enCommand = dicofHeater[nChannelIndex].GetCommand();
            }

           return enCommand;
        }

        public void SetHeaterCommand(EN_HEATER_COMMAND enCommand)
        {
            foreach (var kvp in dicofHeater)
            {
                kvp.Value.SetCommand(enCommand);
            }
        }

        public void SetHeaterCommand(int nChannelIndex, EN_HEATER_COMMAND enCommand)
        {
            if (dicofHeater.ContainsKey(nChannelIndex))
            {
                dicofHeater[nChannelIndex].SetCommand(enCommand);
            }
        }

        #region 아이템 값 갱신

        public void SetMeasuredValue(int nChannel, double dValue)
        {
            if (dicofHeater.ContainsKey(nChannel))
            {
                dicofHeater[nChannel].dMeasured = dValue;
            }
            Calculate_MeanData();
        }
        public void SetErrorStatus(int nChannel, int nIndex)
        {
            dicofHeater[nChannel].nErrorStatus = nIndex;
        }
        public void Calculate_MeanData()
        {
            double dSum = 0;
            foreach (KeyValuePair<int, HeaterChannel> tData in dicofHeater)
            {
                dSum += tData.Value.dMeasured;
            }

            m_dMeanValue = dSum / dicofHeater.Count;

            if (m_dMeanValue > m_dSettingValue && m_dMeanValue - m_dSettingValue < m_dPlusTolerance) bInTarget = true;
            if (m_dMeanValue < m_dSettingValue && m_dMeanValue - m_dSettingValue > m_dMinusTolerance) bInTarget = true;
        }
        #endregion

        #region 아이템 값 반환
        public bool IsError()
        {
            if (bInTarget)
            {
                if(m_dMeanValue - m_dSettingValue == 0)
                    return false;
                if (m_dMeanValue > m_dSettingValue && m_dMeanValue - m_dSettingValue < m_dPlusTolerance)
                    return false;
                if (m_dMeanValue < m_dSettingValue && m_dSettingValue - m_dMeanValue < m_dMinusTolerance)
                    return false;

                return true;
            }
            else
            {
                //Target온도 도달 못 했을 시 처리 고민
                if (m_dMeanValue - m_dSettingValue == 0)
                    return false;
                if (m_dMeanValue > m_dSettingValue && m_dMeanValue - m_dSettingValue < m_dPlusTolerance)
                    return false;
                if (m_dMeanValue < m_dSettingValue && m_dSettingValue - m_dMeanValue < m_dMinusTolerance)
                    return false;

                return true;
            }
        }
        #endregion
        #endregion
    }

    public class HeaterChannel
    {
        #region 변수
        private int m_nChannelNo;
        private bool m_bRunStatus;
        private double m_dMeasured;
        private double m_dOffset;
        private int m_nErrorStatus;
        ConcurrentQueue<EN_HEATER_COMMAND> m_QueueCommand;
        private EN_HEATER_COMMAND m_enCommand = EN_HEATER_COMMAND.GET_TEMP;
        #endregion

        #region 생성자
        public HeaterChannel(int nIndex)
        {
            m_nChannelNo = nIndex;
            m_QueueCommand = new ConcurrentQueue<EN_HEATER_COMMAND>();
        }
        #endregion

        #region 속성
        public bool bRunStatus { set { m_bRunStatus = value; } get { return m_bRunStatus; } }
        public double dOffset { set { m_dOffset = value; } get { return m_dOffset; } }
        public double dMeasured { set { m_dMeasured = value; } get { return m_dMeasured; } }
        public int nErrorStatus { set { m_nErrorStatus = value; } get { return m_nErrorStatus; } }

        #endregion

        public void SetCommand(EN_HEATER_COMMAND enCommand)
        {
            m_QueueCommand.Enqueue(enCommand);
        }

        public EN_HEATER_COMMAND GetCommand()
        {
            EN_HEATER_COMMAND enCommand = EN_HEATER_COMMAND.GET_TEMP;
           if(! m_QueueCommand.TryDequeue(out enCommand))
               enCommand = EN_HEATER_COMMAND.GET_TEMP;
            return enCommand;
        }

        public void ClearCommand()
        {
            EN_HEATER_COMMAND enCommand = EN_HEATER_COMMAND.GET_TEMP;
            while(m_QueueCommand.TryDequeue(out enCommand))
            {

            }
        }
    }
}
