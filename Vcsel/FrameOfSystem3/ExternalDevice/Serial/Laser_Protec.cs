using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TickCounter_;
//using FrameOfSystem3.ExternalDevice.Heater;

namespace FrameOfSystem3.ExternalDevice.Serial
{
    class ProtecLaserController
    {
        public enum EN_RESULT
        {
            WORKING,
            DONE,
            FAIL
        }

        public enum EN_CONTROL_ALARM
        {
            NONE,
            SHORT_CHECK_ERROR,
            CURRENT_ERROR,
            TIME_OUT,
            TIME_SET_ERROR,
            NOT_READY,
            MONITOR_ERROR,
            EMO,
            VOLTAGE_ERROR,
        }

        public enum EN_MONITOR_ALARM
        {
            NONE,
            HUMIDITY_ERROR,
            SAFETY_ERROR,
            EMO,
            CONTROL_1_ERROR,
            FAN_ERROR,
            LEAK_ERROR,
            LEAK_SENSOR_BURN,
            NOT_CLEAR_ALARM,
            CONTROL_2_ERROR,
            CONTROL_3_ERROR,
        }

         #region SingleTone
        private ProtecLaserController() { }
        private static ProtecLaserController _Instance = null;
        public static ProtecLaserController GetInstance() 
        {
            if (_Instance == null)
            {
                _Instance = new ProtecLaserController();
            }
            return _Instance; 
        }
        #endregion

        private class LaserControllerPort
        {
            private int m_nSerialPortIndex = 0;
            private string m_strReceiveData = string.Empty;
            private int m_nSeq = 0;

            public LaserControllerPort(int nPortIndex)
            {
                m_nSerialPortIndex = nPortIndex;
            }

            #region Properties
            public int SerialPortIndex { get { return m_nSerialPortIndex; } }
            public string SerialPortReceive { get { return m_strReceiveData; } set { m_strReceiveData = value; } }
            public int Seq { get { return m_nSeq; } set { m_nSeq = value; } }
            #endregion /Properties
        }

        #region Constant

        #region Common
        private readonly string AlarmClearCommand = "A"; // Clear Alarm
        private readonly string GetAlarmCodeCommand = "Z"; // Get Alarm Code

        private readonly string FirmwareCheckCommand = "Y"; // Check Firmware
        #endregion /Common

        #region Control Board
        private readonly string SetInitCommand = "S"; // SET INIT
        private readonly string GetInitCommand = "E"; // GET INIT

        private readonly string SetStepVoltCommand = "N"; // SET STEP VOLT
        private readonly string GetStepVoltCommand = "F"; // GET STEP VOLT

        private readonly string SetStepTimeCommand = "T"; // SET STEP TIME
        private readonly string GetStepTimeCommand = "G"; // GET STEP TIME

        private readonly string ModeSelectCommand = "M"; // MODE SELECT

        private readonly string ManualShotCommand = "V"; // MANUAL SHOT

        private readonly string SetTImeLimitCommand = "H"; // SET IO TIMEOUT
        private readonly string GetTimeLimitCommand = "J"; // GET IO TIMEOUT

        private readonly string SetCurrnetLimitCommand = "Q"; // SET CURRENT LIMIT
        private readonly string GetCurrnetLimitCommand = "W"; // GET CURRENT LIMIT

        private readonly string GetCurrentVoltCommand = "U"; // Get Current Voltage

        private readonly string ShortCheckCommand = "C"; // Check Short

        private readonly string SetSerialCommand = "I"; // Set Serial
        private readonly string GetSerialCommand = "D"; // Get Serial

        private readonly string SetPowerTableCommand = "B"; // Set PowerTable
        private readonly string GetPowerTableCommand = "K"; // Get PowerTable

        private readonly string ResetEEPROMCommand = "L"; // Serial 및  PowerTable 초기화
        #endregion /Control Board

        #region Monitor Board
        private readonly string SetHumRangeCommand = "Q"; // Set Hum Range
        private readonly string GetHumRangeCommand = "X"; // Get Hum Range

        private readonly string GetCurrentHumCommand = "W"; // Get Current Hum

        private readonly string StartHumMonitorCommand = "O"; // Start Hum Monitor

        private readonly string StopHumMonitorCommand = "P"; // End Hum Monitor
        #endregion /Monitor Board

        #region Serial Default Command
        private readonly byte[] STX = { 0x02 };
        private readonly byte[] ETX = { 0x13 };
        #endregion /Serial Default Command

        #region ForParsing
        private const int CHANNEL_COUNT_PER_PORT = 6; // Port 당 Channel 갯수
        #endregion / ForParsing

        private readonly uint TimeOut = 1000;

        #endregion /Constant

        #region Variables
        // EnumKey + LaserPortParam => 0, 1, 2... + LaserPortParam
        // LaserPortParam.Index = SerialPort
        private Dictionary<int, LaserControllerPort> m_dicLaserPort = new Dictionary<int, LaserControllerPort>();
        private LaserControllerPort m_LaserMonitorPort; //monitor는 항상 한개 일 것

        private bool m_bInit = false;

        private Dictionary<int, TickCounter> m_dicTickTimeoverForLaserPort = new Dictionary<int, TickCounter>();
        private TickCounter m_tickTimeoverForMonitorPort = new TickCounter();

        //통신테스트 확인용
        private Dictionary<int, string> m_dicLaserPortForCommDebug = new Dictionary<int, string>();
        private string m_LaserMonitorForCommDebug; //monitor는 항상 한개 일 것

        #endregion /Variables

        #region Properties
        private Config.ConfigSerial m_InstanceSerial = Config.ConfigSerial.GetInstance();
        #endregion /Properies

        #region External

        public bool Initialize(int[] arControlSerialIndex, int nMonitorIndex)
        {
            bool bOpen = true;

            #region Control
            for (int nIndex = 0; nIndex < arControlSerialIndex.Length; nIndex++)
            {
                m_dicLaserPort.Add(nIndex, new LaserControllerPort(arControlSerialIndex[nIndex]));
                m_dicLaserPortForCommDebug.Add(nIndex, "");

                m_dicTickTimeoverForLaserPort.Add(nIndex, new TickCounter());
                m_dicTickTimeoverForLaserPort[nIndex].SetTickCount(TimeOut);

                m_InstanceSerial.Open(arControlSerialIndex[nIndex]);

                if (false == m_InstanceSerial.IsOpen(arControlSerialIndex[nIndex]))
                    bOpen &= false;
            }
            #endregion /Control

            #region Monitor
            m_LaserMonitorPort = new LaserControllerPort(nMonitorIndex);
            m_tickTimeoverForMonitorPort = new TickCounter();
            m_tickTimeoverForMonitorPort.SetTickCount(TimeOut);

            m_InstanceSerial.Open(m_LaserMonitorPort.SerialPortIndex);

            if (false == m_InstanceSerial.IsOpen(m_LaserMonitorPort.SerialPortIndex))
                bOpen &= false;
            #endregion /Monitor

            m_bInit = true;

            return m_bInit;
        }

        public bool Open()
        {
            bool bOpen = true;
            foreach (LaserControllerPort cPortParam in m_dicLaserPort.Values)
            {
                m_InstanceSerial.Open(cPortParam.SerialPortIndex);

                if (false == m_InstanceSerial.IsOpen(cPortParam.SerialPortIndex))
                    bOpen &= false;
            }

            m_InstanceSerial.Open(m_LaserMonitorPort.SerialPortIndex);

            if (false == m_InstanceSerial.IsOpen(m_LaserMonitorPort.SerialPortIndex))
                bOpen &= false;

            return bOpen;
        }

        public bool IsOpen()
        {
            bool bOpen = true;

            foreach (var cPortParm in m_dicLaserPort.Values)
                bOpen &= m_InstanceSerial.IsOpen(cPortParm.SerialPortIndex);

            bOpen &= m_InstanceSerial.IsOpen(m_LaserMonitorPort.SerialPortIndex);

            return bOpen;
        }

        public void Close()
        {
            foreach (var cPortParm in m_dicLaserPort.Values)
                m_InstanceSerial.Close(cPortParm.SerialPortIndex);

            m_InstanceSerial.Close(m_LaserMonitorPort.SerialPortIndex);
        }

        public void ClearAllPortData()
        {
            string ReceveData = "";
            for (int nIndex = 0; nIndex < m_dicLaserPort.Count; nIndex++)
            {
                while (m_InstanceSerial.Read(m_dicLaserPort[nIndex].SerialPortIndex, ref ReceveData)) { }

                m_dicLaserPort[nIndex].Seq = 0;
                m_dicLaserPort[nIndex].SerialPortReceive = "";
                m_dicLaserPortForCommDebug[nIndex] = "";
            }

            while (m_InstanceSerial.Read(m_LaserMonitorPort.SerialPortIndex, ref ReceveData)) { }

            m_LaserMonitorPort.Seq = 0;
            m_LaserMonitorPort.SerialPortReceive = "";
            m_LaserMonitorForCommDebug = "";
        }

        public void ClearPortData(int nPortIndex)
        {
            string ReceveData = "";

            while (m_InstanceSerial.Read(m_dicLaserPort[nPortIndex].SerialPortIndex, ref ReceveData)) { }

            m_dicLaserPort[nPortIndex].Seq = 0;
            m_dicLaserPort[nPortIndex].SerialPortReceive = "";
            m_dicLaserPortForCommDebug[nPortIndex] = "";
        }

        public void ClearMonitorPortData()
        {
            string ReceveData = "";

            while (m_InstanceSerial.Read(m_LaserMonitorPort.SerialPortIndex, ref ReceveData)) { }

            m_LaserMonitorPort.Seq = 0;
            m_LaserMonitorPort.SerialPortReceive = "";
            m_LaserMonitorForCommDebug = "";
        }

        public int GetPortIndexFromSerialIndex(int nSerialIndex)
        {
            foreach (var kpv in m_dicLaserPort)
            {
                if (kpv.Value.SerialPortIndex == nSerialIndex)
                    return kpv.Key;
            }
            return -1;
        }

        #region ControlBoard
        #region Send Value To Controller

        public EN_RESULT SetInitVoltageIOMode(int nPortIndex, bool[] arEnable, double[] arValue)
        {
            if (arEnable.Length != 6
                || arValue.Length != 6)
                return EN_RESULT.FAIL;

            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }

            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);
                    strMessage += SetInitCommand;

                    strMessage += "00"; //Don't care Data

                    for (int nChannel = 0; nChannel < 6; ++nChannel)
                    {
                        int nEnable = arEnable[nChannel] ? 1 : 2;
                        strMessage += string.Format(",{0}{1:00000}", nEnable, (int)(arValue[nChannel] * 10));
                    }

                    //strMessage += ",000000"; // 2025.3.29 by ecchoi [ADD] "S" 커맨드는 이부분 삭제

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL; // 2025.3.29 by ecchoi [ADD] Test후 복구
                    AddCommLog(nPortIndex, strMessage);
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;
            }
            return EN_RESULT.WORKING;
        }

        public EN_RESULT SetStepVoltage(int nPortIndex, int nChannelIndex, bool bEnable, double[] arValue)
        {
            if (arValue.Length != 5)
                return EN_RESULT.FAIL;

            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }
           
            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);
                    strMessage += SetStepVoltCommand;
                    strMessage += nChannelIndex.ToString();//ch

                    //strMessage += "0"; //Don't care Data

                    //? 문서와 다름 확인 필요
                    int nEnable = bEnable == true ? 1 : 0;
                    strMessage += nEnable.ToString();// SSR

                    for (int nStep = 0; nStep < 5; ++nStep)
                    {
                        double dblRecipeValue = arValue[nStep];
                        strMessage += string.Format(",{0:000000}", (int)(dblRecipeValue * 10));
                    }

                    strMessage += ",000000"; // For Match Data Length

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    AddCommLog(nPortIndex, strMessage);
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;

            }
            return EN_RESULT.WORKING;
        }

        public EN_RESULT SetStepTime(int nPortIndex, int[] arTime)
        {
            if (arTime.Length != 5)
                return EN_RESULT.FAIL;

            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }
           
            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);
                    strMessage += SetStepTimeCommand;
                    strMessage += "00";//Don't care Data

                    for (int nStep = 0; nStep < 5; ++nStep)
                    {
                        int dblRecipeValue = arTime[nStep];
                        strMessage += string.Format(",{0:000000}", (int)(arTime[nStep] / 100)); // ms to Count 1count = 100ms
                    }

                    strMessage += ",000000"; // For Match Data Length

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    AddCommLog(nPortIndex, strMessage);
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;

            }
            return EN_RESULT.WORKING;
        }

        public EN_RESULT SetTimeMode(int nPortIndex)
        {
            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }
         
            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);

                    strMessage += "M00,000000,000000,000000,000000,000000,000000";

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    AddCommLog(nPortIndex, strMessage);
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        return EN_RESULT.DONE;
                    }
                    break;

            }
            return EN_RESULT.WORKING;
           
        }

        public EN_RESULT SetIOMode(int nPortIndex)
        {
            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }

            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);

                    strMessage += "M10,000000,000000,000000,000000,000000,000000";

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;

            }
            return EN_RESULT.WORKING;
        }
        public EN_RESULT SetIOModeTimeLimit(int nLimitSec)
        {
            int nPortIndex = 0; // 포트는 사용하지 않기 때문에 0으로 고정한다

            if (nLimitSec < 0 || nLimitSec > 300)
                return EN_RESULT.FAIL;

            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }

            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);
                    strMessage += "H00";

                    strMessage += string.Format(",{0:000000}", nLimitSec);
                    for (int i = 0; i < 5; ++i)
                        strMessage += ",000000";

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;

                    AddCommLog(nPortIndex, strMessage);
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        return EN_RESULT.DONE;
                    }
                    break;
            }

            return EN_RESULT.WORKING;
        }
        public EN_RESULT ShortCheckStart(int nPortIndex)
        {
//             if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
//             {
//                 m_dicLaserPort[nPortIndex].Seq = 0;
//                 m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(60000);//short check 소요시간
//             }

            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    m_dicLaserPort[nPortIndex].SerialPortReceive = "";

                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);

                    strMessage += "C00,000000,000000,000000,000000,000000,000000";

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;
                        m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;

            }
            return EN_RESULT.WORKING;
        }


        public EN_RESULT GetAlarmCode(int nPortIndex, ref EN_CONTROL_ALARM enAlarm)
        {
            if (m_dicTickTimeoverForLaserPort[nPortIndex].IsTickOver(false))
            {
                m_dicLaserPort[nPortIndex].Seq = 0;
                m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
            }


            switch (m_dicLaserPort[nPortIndex].Seq)
            {
                case 0:
                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);

                    strMessage += "Z00,000000,000000,000000,000000,000000,000000";

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_dicLaserPort[nPortIndex].SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    AddCommLog(nPortIndex, strMessage);
                    m_dicLaserPort[nPortIndex].Seq++;
                    break;

                case 1:
                    if (CheckControlReciveDone(nPortIndex))
                    {
                        m_dicLaserPort[nPortIndex].Seq = 0;

                        if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C01"))
                            enAlarm = EN_CONTROL_ALARM.SHORT_CHECK_ERROR;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C02"))
                            enAlarm = EN_CONTROL_ALARM.CURRENT_ERROR;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C03"))
                            enAlarm = EN_CONTROL_ALARM.TIME_OUT;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C04"))
                            enAlarm = EN_CONTROL_ALARM.TIME_SET_ERROR;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C05"))
                            enAlarm = EN_CONTROL_ALARM.NOT_READY;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C06"))
                            enAlarm = EN_CONTROL_ALARM.MONITOR_ERROR;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C07"))
                            enAlarm = EN_CONTROL_ALARM.EMO;
                        else if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("C08"))
                            enAlarm = EN_CONTROL_ALARM.VOLTAGE_ERROR;
                        else
                            enAlarm = EN_CONTROL_ALARM.NONE;

                        m_dicTickTimeoverForLaserPort[nPortIndex].SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;
            }
            return EN_RESULT.WORKING;
        }

        public bool ReadMessage(int nPortIndex)
        {
            string strMessage = "";
            if (m_InstanceSerial.Read(m_dicLaserPort[nPortIndex].SerialPortIndex, ref strMessage))
            {
                m_dicLaserPortForCommDebug[nPortIndex] += strMessage;

                return true;
            }
            return false;
        }

        #endregion /Send Value To Controller
        #endregion /ControlBoard

        #region Monitor
        public EN_RESULT GetAlarmCode(ref EN_MONITOR_ALARM enAlarm)
        {
            if (m_tickTimeoverForMonitorPort.IsTickOver(false))
            {
                m_LaserMonitorPort.Seq = 0;
                m_tickTimeoverForMonitorPort.SetTickCount(TimeOut);
            }

            switch (m_LaserMonitorPort.Seq)
            {
                case 0:
                    string strMessage = System.Text.Encoding.ASCII.GetString(STX);

                    strMessage += "Z00,000000,000000,000000,000000,000000,000000";

                    strMessage += CheckSum(strMessage);
                    strMessage += System.Text.Encoding.ASCII.GetString(ETX);

                    if (m_InstanceSerial.Write(m_LaserMonitorPort.SerialPortIndex, strMessage) == false)
                        return EN_RESULT.FAIL;
                    AddMonitorCommLog(strMessage);
                    m_LaserMonitorPort.Seq++;
                    break;

                case 1:
                    if (CheckMonitorReciveDone())
                    {
                        m_LaserMonitorPort.Seq = 0;

                        if (m_LaserMonitorPort.SerialPortReceive.Contains("M01"))
                            enAlarm = EN_MONITOR_ALARM.HUMIDITY_ERROR;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M02"))
                            enAlarm = EN_MONITOR_ALARM.SAFETY_ERROR;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M03"))
                            enAlarm = EN_MONITOR_ALARM.EMO;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M04"))
                            enAlarm = EN_MONITOR_ALARM.CONTROL_1_ERROR;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M05"))
                            enAlarm = EN_MONITOR_ALARM.FAN_ERROR;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M06"))
                            enAlarm = EN_MONITOR_ALARM.LEAK_ERROR;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M07"))
                            enAlarm = EN_MONITOR_ALARM.LEAK_SENSOR_BURN;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M08"))
                            enAlarm = EN_MONITOR_ALARM.NOT_CLEAR_ALARM;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M09"))
                            enAlarm = EN_MONITOR_ALARM.CONTROL_2_ERROR;
                        else if (m_LaserMonitorPort.SerialPortReceive.Contains("M10"))
                            enAlarm = EN_MONITOR_ALARM.CONTROL_3_ERROR;
                        else
                            enAlarm = EN_MONITOR_ALARM.NONE;

                        m_tickTimeoverForMonitorPort.SetTickCount(TimeOut);
                        return EN_RESULT.DONE;
                    }
                    break;
            }
            return EN_RESULT.WORKING;
        }
        #endregion /Monitor
        #endregion /External


        #region Internal
        private string CheckSum(string strMassege)
        {
            byte[] arMessage = Encoding.ASCII.GetBytes(strMassege);
            byte[] arCheckSum = { arMessage[1] };

            foreach (byte byData in arMessage.Skip(2).Take(arMessage.Length - 2))
                arCheckSum[0] ^= byData;

            return System.Text.Encoding.ASCII.GetString(arCheckSum);
        }

        private bool CheckControlReciveDone(int nPortIndex)
        {
            string strMessage = "";
            if (m_InstanceSerial.Read(m_dicLaserPort[nPortIndex].SerialPortIndex, ref strMessage))
            {
                m_dicLaserPortForCommDebug[nPortIndex] += strMessage;
                m_dicLaserPort[nPortIndex].SerialPortReceive += strMessage;

                if (m_dicLaserPort[nPortIndex].SerialPortReceive.Contains("OK"))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckMonitorReciveDone()
        {
            string strMessage = "";
            if (m_InstanceSerial.Read(m_LaserMonitorPort.SerialPortIndex, ref strMessage))
            {
                m_LaserMonitorForCommDebug += strMessage;
                m_LaserMonitorPort.SerialPortReceive += strMessage;

                if (m_LaserMonitorPort.SerialPortReceive.Contains("OK"))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddCommLog(int nPort, string SendMessage)
        {
            m_dicLaserPortForCommDebug[nPort] += "\n";
            m_dicLaserPortForCommDebug[nPort] += "[Send]";
            m_dicLaserPortForCommDebug[nPort] += SendMessage;
            m_dicLaserPortForCommDebug[nPort] += "\n";
            m_dicLaserPortForCommDebug[nPort] += "[Recieve]";
        }

        private void AddMonitorCommLog(string SendMessage)
        {
            m_LaserMonitorForCommDebug += "\n";
            m_LaserMonitorForCommDebug += "[Send]";
            m_LaserMonitorForCommDebug += SendMessage;
            m_LaserMonitorForCommDebug += "\n";
            m_LaserMonitorForCommDebug += "[Recieve]";
        }
        #endregion
    }
}
