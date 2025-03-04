using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Define.DefineEnumProject.Serial;
using Serial_;

namespace FrameOfSystem3.ExternalDevice.Serial
{
    public enum EN_POWERMETER_DEVICETYPE
    {
        POWERMAX = 0,
        LABMAX = 1,
        LABMAX_TO = 2,
    }
    public enum EN_POWERMETER_COMMAND
    {
        DEFAULT,
        START,
        STOP,
        RESET,
        ZEROSET,
        READ,
        HANDCHECKING_OFF,
        ERROR_CLEAR,
        RECIEVE_LAST,
        RECIEVE_STREAM,
        RECIEVE_ONLY_POWER,
        SPEEDUP
    }

    class Powermeter
    {
        #region 변수
        private int m_nSerialIndex = 0;
        private Config.ConfigSerial m_Serial = Config.ConfigSerial.GetInstance();
        private ConcurrentQueue<EN_POWERMETER_COMMAND> m_enCommand;
        private EN_POWERMETER_COMMAND m_enLastCommand = EN_POWERMETER_COMMAND.DEFAULT;
        private List<double>                                                                    m_listofMeasuring = new List<double>(); //현재 측정 중인 값
        private List<double>                                                                    m_listofTime = new List<double>();
        private double                                                                          m_Measure_Min = 0;
        private double                                                                          m_Measure_Max = 0;
        private double                                                                          m_Measure_Avg = 0;
        private double                                                                          m_Measure_Cur = 0;
        private int                                                                             m_nWait_Time = 0;

        private double m_Measure_Repeat_Avg = 0;

        private List<double>                                                                    m_lstMeasuredValue = new List<double>(); //Repeat 측정 평균 구하기 위해.

        private EN_POWERMETER_DEVICETYPE                                                        m_DeviceType = EN_POWERMETER_DEVICETYPE.LABMAX_TO;

        byte[] CR = new byte[1];
        byte[] LF = new byte[1];

        private int m_nObjectCode;

        private string m_strRecieveDate = "";
        private bool m_bRecieveDone = true;

        private TickCounter_.TickCounter m_tickForTimeOut = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickForRecieveTime = new TickCounter_.TickCounter();
        #endregion

        #region 싱글톤
        private Powermeter() { }
        private static Powermeter _Instance = null;
        public static Powermeter GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Powermeter();
            }
            return _Instance;
        }
        #endregion

        #region 속성
        public List<double> Measure_List { get { return m_listofMeasuring; } }
        public List<double> Time_List { get { return m_listofTime; } }
        public double Measure_Min { get { return m_Measure_Min; } }
        public double Measure_Max { get { return m_Measure_Max; } }
        public double Measure_Repeat_Avg { get { return m_Measure_Repeat_Avg; } }
        public double Measure_Avg { get { return m_Measure_Avg; } }
        public double Measure_Cur { get { return m_Measure_Cur; } }
        public bool RecieveDone { get { return m_bRecieveDone; } }
        public int nObjectCode { get { return m_nObjectCode; } set { m_nObjectCode = value; } }
        public int nWait_Time { get { return m_nWait_Time; } set { m_nWait_Time = value; } }
        #endregion

        #region 외부 인터페이스
        #region 초기화 및 종료
        public bool Init(int nSerialIndex)
        {
            CR[0] = 0x0D;
            LF[0] = 0x0A;

            m_nSerialIndex = nSerialIndex;


            m_enCommand = new ConcurrentQueue<EN_POWERMETER_COMMAND>();
            m_nObjectCode = nSerialIndex * 100;

            if (m_Serial.Open(m_nSerialIndex) == false)
                return false;


            return true;
        }
        public void Open()
        {
            m_Serial.Open(m_nSerialIndex);
        }
        #endregion

        #region 주기 호출 함수
        public void Execute()
        {
            if (m_Serial.IsOpen(m_nSerialIndex) == false)
                return;

            EN_POWERMETER_COMMAND eCommand = EN_POWERMETER_COMMAND.DEFAULT;

            if(m_enCommand.TryDequeue(out eCommand))
            {
                ActionCommand(eCommand);
                m_enLastCommand = eCommand;
            }

            string strMessage = "";

            if (m_Serial.Read(m_nSerialIndex, ref strMessage))
            {
                m_strRecieveDate += strMessage;

                //단일 데이터만 확인
                //음수면 length 13 확인 X
                // 현재 LabMaxTO_Parsing
                // 추후 다른모델도 확인 필요

                if (m_DeviceType == EN_POWERMETER_DEVICETYPE.LABMAX_TO)
                {
                    if (m_strRecieveDate.Length == 12
                        && m_strRecieveDate.Remove(0, m_strRecieveDate.Length - 1).Equals("\n"))
                    {
                        //enq 제거 필요한지 한번 더 확인
                        byte[] enq = new byte[] { 0x05 };
                        m_strRecieveDate = m_strRecieveDate.Replace(System.Text.Encoding.Default.GetString(enq), "");

                        double val;
                        if (double.TryParse(m_strRecieveDate, out val))
                        {

                            m_listofMeasuring.Add(val);
                            m_listofTime.Add((double)m_tickForRecieveTime.GetTickCount() / 1000);
                            m_Measure_Cur = Math.Round(m_listofMeasuring[m_listofMeasuring.Count - 1], 2);
                            CalculateAVG();

                            m_strRecieveDate = "";
                            m_bRecieveDone = true;
                            m_enLastCommand = EN_POWERMETER_COMMAND.DEFAULT;
                        }
                    }
                }
                else
                {
                    if (m_strRecieveDate.Remove(0, m_strRecieveDate.Length - 1).Equals("\n"))
                    {
                        //enq 제거 필요한지 한번 더 확인
                        byte[] enq = new byte[] { 0x05 };
                        m_strRecieveDate = m_strRecieveDate.Replace(System.Text.Encoding.Default.GetString(enq), "");

                        double val;
                        if (double.TryParse(m_strRecieveDate, out val))
                        {

                            m_listofMeasuring.Add(val);
                            m_listofTime.Add((double)m_tickForRecieveTime.GetTickCount() / 1000);
                            m_Measure_Cur = Math.Round(m_listofMeasuring[m_listofMeasuring.Count - 1], 2);
                            CalculateAVG();

                            m_strRecieveDate = "";
                            m_bRecieveDone = true;
                            m_enLastCommand = EN_POWERMETER_COMMAND.DEFAULT;
                        }
                    }
                }
            }

            if (m_enLastCommand == EN_POWERMETER_COMMAND.READ)
            {
                //Parsing 길이를 넘거나 TimeOut된다면 재시도
                if (m_tickForTimeOut.IsTickOver(true)
                    || m_strRecieveDate.Length > 12)
                {
                    ActionCommand(m_enLastCommand);
                }
            }
              
        }
        #endregion

        #region 명령 함수
        public void SetCommand(EN_POWERMETER_COMMAND enCommand)
        {
            m_enCommand.Enqueue(enCommand);
        }

        public void ClearRepeatData()
        {
            m_lstMeasuredValue.Clear();
        }
        #endregion

        #region 아이템 값 갱신
        public void SetDeviceType(EN_POWERMETER_DEVICETYPE eType)
        {
            m_DeviceType = eType;
        }
   
        #endregion
        #endregion

        #region 내부인터페이스
        #region 명령 수행 함수
        private bool ActionCommand(EN_POWERMETER_COMMAND eCommand)
        {
            string strMessage = "";

            switch (eCommand)
            {
                case EN_POWERMETER_COMMAND.START:
                    m_listofMeasuring.Clear();
                    m_listofTime.Clear();

                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                            strMessage = "STARt";
                            break;
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                            strMessage = "INIT";
                            break;
                    }
                    m_tickForRecieveTime.SetTickCount(600000); //최대 10분
                    break;
                case EN_POWERMETER_COMMAND.STOP:
                    CalculateRepeatAVG();
                    WriteLogPowermeterResult();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                            strMessage = "STOP";
                            break;
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                            strMessage = "ABOR";
                            break;
                    }
                    break;
                case EN_POWERMETER_COMMAND.READ:
                     while (m_Serial.Read(m_nSerialIndex, ref strMessage))
                    { }
                    m_strRecieveDate = "";
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                            strMessage = "READ?";
                            break;
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "FETC:ALL?";
                            break;
                    }
          
                    m_tickForTimeOut.SetTickCount(300);
                    break;
                case EN_POWERMETER_COMMAND.RESET:
                    m_listofTime.Clear();
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                            strMessage = "*RST";
                            break;
                    }
                    break;
                case EN_POWERMETER_COMMAND.ZEROSET:
                    m_listofTime.Clear();
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "CONFigure:ZERO";
                            break;
                    }
                    break;
                case EN_POWERMETER_COMMAND.SPEEDUP:
                    m_listofTime.Clear();
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                            strMessage = "CONFigure:SPEedup ON";
                            break;
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                            strMessage = "CONFigure:SPEedup";
                            break;
                    }
                    break;
                case EN_POWERMETER_COMMAND.HANDCHECKING_OFF:
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "SYSTem:COMMunicate:HANDshaking OFF";
                            break;
                    }

                    break;
                case EN_POWERMETER_COMMAND.ERROR_CLEAR:
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "SYST:ERR:CLE";
                            break;
                    }

                    break;
                case EN_POWERMETER_COMMAND.RECIEVE_ONLY_POWER:
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "CONF:READ:SEND PRI";
                            break;
                    }

                    break;
                case EN_POWERMETER_COMMAND.RECIEVE_LAST:
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "CONF:READ:CONT LAST";
                            break;
                    }

                    break;
                case EN_POWERMETER_COMMAND.RECIEVE_STREAM:
                    m_listofMeasuring.Clear();
                    switch (m_DeviceType)
                    {
                        case EN_POWERMETER_DEVICETYPE.LABMAX:
                        case EN_POWERMETER_DEVICETYPE.POWERMAX:
                        case EN_POWERMETER_DEVICETYPE.LABMAX_TO:
                            strMessage = "CONF:READ:CONT STRE";
                            break;
                    }


                    break;
            }
            

            strMessage += System.Text.Encoding.Default.GetString(CR);
            strMessage += System.Text.Encoding.Default.GetString(LF);

            return m_Serial.Write(m_nSerialIndex, strMessage);
        }
        #endregion

        private void CalculateAVG()
        {
            List<double> lstMeasure = new List<double>();
            for (int i = 0; i < m_listofTime.Count; i++)
            {
                if (m_listofTime[i] > m_nWait_Time / 1000
                    && m_listofTime[i] < (m_listofTime.Max()))
                {
                    lstMeasure.Add(m_listofMeasuring[i]);
                }
            }
            if (lstMeasure.Count > 0)
            {
                m_Measure_Avg = lstMeasure.Average();
                m_Measure_Max = lstMeasure.Max();
                m_Measure_Min = lstMeasure.Min();
            }
        }

        private void CalculateRepeatAVG()
        {
            List<double> lstMeasure = new List<double>();
            for (int i = 0; i < m_listofTime.Count; i++)
            {
                if (m_listofTime[i] > m_nWait_Time / 1000
                    && m_listofTime[i] < (m_listofTime.Max()))
                {
                    lstMeasure.Add(m_listofMeasuring[i]);
                }
            }
            m_lstMeasuredValue.AddRange(lstMeasure);
            if (m_lstMeasuredValue.Count > 0)
            {
                m_Measure_Repeat_Avg = m_lstMeasuredValue.Average();
            }
        }
        #endregion

        public void WriteLogPowermeterResult()
        {
            DateTime nowDate = DateTime.Now;
            string FilePath = Define.DefineConstant.FilePath.FILEPATH_LOG + "\\Powermeter";
            
            if (Directory.Exists(FilePath) == false)
                Directory.CreateDirectory(FilePath);

            string FileName = String.Format("{0:0000}.{1:00}.{2:00} {3:00}.{4:00}.log", nowDate.Year, nowDate.Month, nowDate.Day, nowDate.Hour, nowDate.Minute);

            string FileInfor = FilePath + "\\" + FileName;

            string LogData = "";

            for (int i = 0; i < m_listofMeasuring.Count; i++ )
            {
                LogData = String.Format("{0}    {1}", m_listofTime[i], m_listofMeasuring[i]);
                using (StreamWriter outputFile = new StreamWriter(FileInfor, true))
                {
                    outputFile.WriteLine(LogData);
                }
            }
            LogData = String.Format("MIN    {0}", m_Measure_Min);
            using (StreamWriter outputFile = new StreamWriter(FileInfor, true))
            {
                outputFile.WriteLine(LogData);
            }
            LogData = String.Format("MAX    {0}", m_Measure_Max);
            using (StreamWriter outputFile = new StreamWriter(FileInfor, true))
            {
                outputFile.WriteLine(LogData);
            }
            LogData = String.Format("AVG    {0}", m_Measure_Avg);
            using (StreamWriter outputFile = new StreamWriter(FileInfor, true))
            {
                outputFile.WriteLine(LogData);
            }
        }
    }
}
