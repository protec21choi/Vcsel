using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Define.DefineEnumProject.AnalogIO;
using Define.DefineEnumProject.DigitalIO;

namespace FrameOfSystem3.Log
{
    class WorkLog
    {
        public enum EN_SAVE_STATUS
        {
            WAIT,
            GET_DATA,
            SAVE,
        }

        public enum EN_LOG_ITEM
        {
            //POWER_1,
            //POWER_2,
            //POWER_3,
            //POWER_4,
            //POWER_5,
            //POWER_6,
            //POWER_7,
            //POWER_8,
            //POWER_9,
            //POWER_10,
            //POWER_11,
            //POWER_12,
            //POWER_13,
            //POWER_14,
            //POWER_15,
            //POWER_16,
            //POWER_17,
            //POWER_18,

            //POWER_TOTAL,

            //PYRO_TEMP_1,
            //PYRO_TEMP_2,
            //PYRO_TEMP_3,
            //PYRO_TEMP_4,
            //PYRO_TEMP_5,

            //BLOCK_VAC,
            //HEAD_FLOW,

            IR_SENSOR_1,
            IR_SENSOR_2,
            IR_SENSOR_3,
            IR_SENSOR_4,

            POWER_ON,
            MAX_COUNT,

        }

        #region SingleTone
        private WorkLog() { }
        private static WorkLog _Instance = null;
        public static WorkLog GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new WorkLog();
            }
            return _Instance;
        }
        #endregion

        #region field
        private Dictionary<int, Dictionary<EN_LOG_ITEM, double>> m_dicWorkLog = new Dictionary<int, Dictionary<EN_LOG_ITEM, double>>(); //key : 시간 , value: 측정값들
        private Dictionary<int,Dictionary<EN_LOG_ITEM, double>> m_dicLoadedLog = new Dictionary<int, Dictionary<EN_LOG_ITEM, double>>(); //key : 시간 , value: 측정값들

        private AnalogIO_.AnalogIO m_Analog = AnalogIO_.AnalogIO.GetInstance();
        private DigitalIO_.DigitalIO m_Digital = DigitalIO_.DigitalIO.GetInstance();
        private Motion_.Motion m_Motion = Motion_.Motion.GetInstance();
        private string m_strSaveFileName = string.Empty;
        private string m_strSaveFilePath = string.Empty;

        EN_SAVE_STATUS m_enStatus = EN_SAVE_STATUS.WAIT;

        private TickCounter_.TickCounter m_tickCounter = new TickCounter_.TickCounter();
        #endregion

        #region property
        public Dictionary<int, Dictionary<EN_LOG_ITEM, double>> dicWorkLog { get { return new Dictionary<int, Dictionary<EN_LOG_ITEM, double>>(m_dicWorkLog); } }
        public Dictionary<int, Dictionary<EN_LOG_ITEM, double>> dicLoadedLog { get { return new Dictionary<int, Dictionary<EN_LOG_ITEM, double>>(m_dicLoadedLog); } }
        public EN_SAVE_STATUS enStatus { get { return m_enStatus; } }

        public int nLaserStartTime 
        {
            get
            {
                foreach (var kpv in m_dicLoadedLog)
                {
                    if (kpv.Value.ContainsKey(EN_LOG_ITEM.POWER_ON))
                    {

                        if (kpv.Value[EN_LOG_ITEM.POWER_ON] == 1)
                            return kpv.Key;

                    }
                }
                return -1;
            }
        }
        #endregion

        #region Method
        #region public
        public bool SaveStart()
        {
            if (m_enStatus != EN_SAVE_STATUS.WAIT)
                return false;
            ClearDataList();
            m_tickCounter.SetTickCount(1);
            m_enStatus = EN_SAVE_STATUS.GET_DATA;
            return true;
        }
        public bool SaveStop(bool bSave = true, string strSaveFileName = "NONEID", string strSaveFilePath = "")
        {
            if (m_enStatus != EN_SAVE_STATUS.GET_DATA)
                return false;
            m_strSaveFileName = strSaveFileName;
            m_strSaveFilePath = strSaveFilePath;
            if (bSave)
                m_enStatus = EN_SAVE_STATUS.SAVE;
            else
                m_enStatus = EN_SAVE_STATUS.WAIT;
            return true;
        }
        public void Execute()
        {
            if (m_enStatus == EN_SAVE_STATUS.GET_DATA)
            {
                int nTime = (int)m_tickCounter.GetTickCount();
                AddData(nTime);
            }
            else if (m_enStatus == EN_SAVE_STATUS.SAVE)
            {
                string strID = m_strSaveFileName;
                strID += String.Format("_{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}{6:000}",
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    DateTime.Now.Hour,
                    DateTime.Now.Minute,
                    DateTime.Now.Second,
                    DateTime.Now.Millisecond);
                SaveData(strID, m_strSaveFilePath);
                m_enStatus = EN_SAVE_STATUS.WAIT;
            }
        }

        public bool ReadLog(string strFilePath)
        {
            m_dicLoadedLog.Clear();

            using (FileStream fstream = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sReader = new StreamReader(fstream, Encoding.UTF8))
                {

                    string[] arReadLines = sReader.ReadToEnd().Split('\n');

                    Dictionary<int, EN_LOG_ITEM> dicColumnIndex = new Dictionary<int, EN_LOG_ITEM>();

                    for (int nMeasureIndex = 0, nMeasureIndexEnd = arReadLines.Length; nMeasureIndex < nMeasureIndexEnd; ++nMeasureIndex)
                    {
                        string[] arDatas;
                        if (nMeasureIndex == 0)
                        {
                            arDatas = arReadLines[nMeasureIndex].Split(',');
                            for (int nIndex = 1, nEnd = arDatas.Count(); nIndex < nEnd; ++nIndex)
                            {
                                EN_LOG_ITEM enItem = EN_LOG_ITEM.MAX_COUNT;
                                if(Enum.TryParse(arDatas[nIndex], out enItem))
                                {
                                    dicColumnIndex.Add(nIndex, enItem);
                                }
                            }
                        }
                        if( arReadLines[nMeasureIndex] == string.Empty)
                           continue; // Column Head Text
                        arDatas = arReadLines[nMeasureIndex].Split(',');

                        Dictionary<EN_LOG_ITEM, double> dicValue = new Dictionary<EN_LOG_ITEM, double>();

                          int nTime = 0;
                          if (int.TryParse(arDatas[0], out nTime))
                          {
                              for (int nIndex = 1, nEnd = arDatas.Count(); nIndex < nEnd; ++nIndex)
                              {
                                  double dValue = 0;
                                  if (double.TryParse(arDatas[nIndex], out dValue))
                                  {
                                      dicValue.Add(dicColumnIndex[nIndex], dValue);
                                  }
                              }
                              m_dicLoadedLog.Add(nTime, dicValue);
                          }
                    }
                    sReader.Close();
                }
                fstream.Close();
            }
            return true;
        }


        #endregion

        #region private
        private void ClearDataList()
        {
            m_dicWorkLog.Clear();
        }
        /// <summary>
        /// 2022.05.06 [ADD] HEAD AXIS POSITION
        /// </summary>
        /// 
        private void AddData(int nTime)
        {

            Dictionary<EN_LOG_ITEM, double> dicMonitoringValue = new Dictionary<EN_LOG_ITEM, double>();

            dicMonitoringValue.Add(EN_LOG_ITEM.IR_SENSOR_1, m_Analog.ReadInputValue((int)EN_ANALOG_IN.HEAD_TEMP_IR_SENSOR_1));
            dicMonitoringValue.Add(EN_LOG_ITEM.IR_SENSOR_2, m_Analog.ReadInputValue((int)EN_ANALOG_IN.HEAD_TEMP_IR_SENSOR_2));
            dicMonitoringValue.Add(EN_LOG_ITEM.IR_SENSOR_3, m_Analog.ReadInputValue((int)EN_ANALOG_IN.HEAD_TEMP_IR_SENSOR_3));
            dicMonitoringValue.Add(EN_LOG_ITEM.IR_SENSOR_4, m_Analog.ReadInputValue((int)EN_ANALOG_IN.HEAD_TEMP_IR_SENSOR_4));

            bool bPowerON =m_Digital.ReadInput((int)EN_DIGITAL_IN.LD_1_ON)
                            ||m_Digital.ReadInput((int)EN_DIGITAL_IN.LD_2_ON)
                            ||m_Digital.ReadInput((int)EN_DIGITAL_IN.LD_3_ON)
                            ||m_Digital.ReadInput((int)EN_DIGITAL_IN.LD_1_ON_2)
                            ||m_Digital.ReadInput((int)EN_DIGITAL_IN.LD_2_ON_2)
                            ||m_Digital.ReadInput((int)EN_DIGITAL_IN.LD_3_ON_2);

            dicMonitoringValue.Add(EN_LOG_ITEM.POWER_ON, bPowerON ? 1 : 0);

            // 2025.3.18 by ecchoi [ADD] Graph Test Value
            double baseValue = 50; // 기본 값
            double fluctuation = 30 * Math.Sin(DateTime.Now.Second / 5.0 * Math.PI);
            dicMonitoringValue[EN_LOG_ITEM.IR_SENSOR_1] = baseValue + fluctuation;
            dicMonitoringValue[EN_LOG_ITEM.IR_SENSOR_2] = baseValue - fluctuation;
            dicMonitoringValue[EN_LOG_ITEM.IR_SENSOR_3] = baseValue + fluctuation / 2;
            dicMonitoringValue[EN_LOG_ITEM.IR_SENSOR_4] = baseValue - fluctuation / 2; // 2025.3.18 by ecchoi [ADD] 여기까지 Test

            if (!m_dicWorkLog.ContainsKey(nTime))
                m_dicWorkLog.Add(nTime, dicMonitoringValue);

        }

        /// <summary>
        /// 2022.05.06 [ADD] HEAD AXIS POSITION
        /// </summary>
        private void SaveData(string strFileName, string strFIlePath = "")
        {
            string strFolderName;
            string strFolderPath;
            
            string strFilePath;
            if (strFIlePath == "")
            {
                strFolderName = string.Format("{0}-{1}-{2}", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
                strFolderPath = string.Format("{0}\\{1}", Define.DefineConstant.FilePath.FILEPATH_LASER_WORK_LOG, strFolderName);

                strFilePath = string.Format("{0}\\{1}\\{2}{3}", Define.DefineConstant.FilePath.FILEPATH_LASER_WORK_LOG, strFolderName, strFileName, Define.DefineConstant.FileFormat.FILEFORMAT_CSV);
            }
            else
            {
                strFolderName = strFIlePath;
                strFolderPath = string.Format("{0}\\{1}", Define.DefineConstant.FilePath.FILEPATH_TEST_LOG, strFolderName);

                strFilePath = string.Format("{0}\\{1}\\{2}{3}", Define.DefineConstant.FilePath.FILEPATH_TEST_LOG, strFolderName, strFileName, Define.DefineConstant.FileFormat.FILEFORMAT_CSV);

                if (false == File.Exists(Define.DefineConstant.FilePath.FILEPATH_TEST_LOG))
                {
                    Directory.CreateDirectory(Define.DefineConstant.FilePath.FILEPATH_TEST_LOG);
                }
            }

            if (false == File.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }

            string strDescription;
            List<string> Temps = new List<string>();


            using (FileStream fstream = new FileStream(strFilePath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter swriter = new StreamWriter(fstream, Encoding.UTF8))
                {
                    string strData = "TIME";
                 
                    foreach (EN_LOG_ITEM en in Enum.GetValues(typeof(EN_LOG_ITEM)))
                    {
                        if (en == EN_LOG_ITEM.MAX_COUNT)
                            break;

                        strData += ",";
                        strData += en.ToString();
                    }

                    swriter.WriteLine(strData);

                    foreach (var kpv in m_dicWorkLog)
                    {
                        Temps.Clear();
                        Temps.Add(kpv.Key.ToString());

                        foreach (EN_LOG_ITEM en in Enum.GetValues(typeof(EN_LOG_ITEM)))
                        {
                            if (en == EN_LOG_ITEM.MAX_COUNT)
                                break;

                            if (kpv.Value.ContainsKey(en))
                                Temps.Add(kpv.Value[en].ToString());
                            else
                                Temps.Add("");
                        }

                        strDescription = string.Join(",", Temps.ToArray());

                        //str Description으로 수정
                        //swriter.WriteLine(strData);
                        swriter.WriteLine(strDescription);
                    }

                    swriter.Close();
                }
                fstream.Close();
            }
        }
    
        #endregion
        #endregion
    }
}
