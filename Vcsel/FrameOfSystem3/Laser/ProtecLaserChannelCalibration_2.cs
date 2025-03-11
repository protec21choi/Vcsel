using FrameOfSystem3.Recipe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileComposite_;
using FrameOfSystem3.ExternalDevice.Serial;
using RecipeManager_;
using System.Reflection;
using FrameOfSystem3.Functional;
using TickCounter_;
using DesignPattern_.Observer_;

namespace FrameOfSystem3.Laser
{
    #region Enumerable
    public enum EN_CALIBRATION_PROCESS_LIST_2
    {
        POWER_INPUT_VOLT_WATT,
        POWER_VOLT_WATT,
        POWER_WATT_VOLT,

        SIZE_X_VOLT_VALUE,
        SIZE_X_VALUE_VOLT,
        SIZE_X_COUNT_VALUE,

        SIZE_Y_VOLT_VALUE,
        SIZE_Y_VALUE_VOLT,
        SIZE_Y_COUNT_VALUE,
    }
    public enum EN_CALIBRATION_INDEX_2
    {
        INDEX = 0,
        TARGET_VOLT = 1,
        POWER_OUTPUT_WATT = 2,
        POWER_INPUT_VOLT = 3,
    }
    #endregion

    public class ProtecLaserChannelCalibration_2
    {
        #region Singleton
        static private ProtecLaserChannelCalibration_2 _Instance = new ProtecLaserChannelCalibration_2();
        static public ProtecLaserChannelCalibration_2 GetInstance()
        {
            return _Instance;
        }
        #endregion

        #region Variables

        #region Instance
        private Recipe.Recipe m_instanceRecipe = Recipe.Recipe.GetInstance();
        #endregion
     
        #region Calibration
        private string m_strCalibrationFileName = "CalibrationData_2";

        private Dictionary<int, ProtecLaserChannelData_2> m_dicTotalChannelCalibration =
            new Dictionary<int, ProtecLaserChannelData_2>(); // Channel , Channel Cal Data

        #endregion

        private int m_nChannelCount = 16;
        #endregion

        #region Property

        public Dictionary<int, ProtecLaserCalibrationData_2> CalibrationDatas(int nIndex) { return m_dicTotalChannelCalibration[nIndex].CalibrationData; }
        public string CalibrationChannelFileName(int nIndex) { return m_dicTotalChannelCalibration[nIndex].FileName; }
        #endregion

        #region External Interface

        #region Init
        public void Init(int nChannelCount)
        {
            m_nChannelCount = nChannelCount;
            m_dicTotalChannelCalibration.Clear();


            for (int nChannelIndex = 0; nChannelIndex < m_nChannelCount; ++nChannelIndex)
                m_dicTotalChannelCalibration.Add(nChannelIndex, new ProtecLaserChannelData_2(nChannelIndex));

            Load();
        }
        #endregion /Init
        
        #region Calibration Information

        #region Update Data
        public void UpdateCalibrationInformation(int nChannelIndex, int nIndex, int nUpdateIndex, double dblTargetData)
        {
            string strFileName = Define.DefineConstant.FilePath.FILEPATH_LOG + "\\PowerCalChangedLog.csv";
            string strData = string.Format("TIME, {0}, TYPE, {1}, CH, {2}, INDEX, {3}, VALUE, {4}", DateTime.Now.ToShortDateString(), (EN_CALIBRATION_INDEX_2)nUpdateIndex, nChannelIndex, nIndex, dblTargetData);
            switch (nUpdateIndex)
            {
                case (int)EN_CALIBRATION_INDEX_2.TARGET_VOLT:
                    strData += string.Format(", PRE VALUE, {0}", m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].TargetVolt_2);
                    m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].TargetVolt_2 = dblTargetData;
                    break;
                case (int)EN_CALIBRATION_INDEX_2.POWER_OUTPUT_WATT:
                    strData += string.Format(", PRE VALUE, {0}", m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerOutputWatt_2);
                    m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerOutputWatt_2 = dblTargetData;
                    break;
                case (int)EN_CALIBRATION_INDEX_2.POWER_INPUT_VOLT:
                    strData += string.Format(", PRE VALUE, {0}", m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerInputVolt_2);
                    m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerInputVolt_2 = dblTargetData;
                    break;
            }
            Save();
            Log.LogWriter.GetInstance().RequestCutomLog(strFileName, strData);
        }
        #endregion

        #region File Load
        public bool LoadFile(string strFileName)
        {
            m_strCalibrationFileName = strFileName;

            Load();

            return true;
        }
        public bool LoadFile()
        {
            return Load();
        }
        #endregion

        #region File Change

        #region Load File
        
        #endregion /LoadFile

        #region Calibration File
        // Channel의 불러올 Calibration File을 수정
        public void ModifyChannelCalibrationFile(int nChannelIndex, string strFilePath, string strFileName)
        {
            if (m_dicTotalChannelCalibration.ContainsKey(nChannelIndex))
                m_dicTotalChannelCalibration.Remove(nChannelIndex);

            m_dicTotalChannelCalibration.Add(nChannelIndex, new ProtecLaserChannelData_2(nChannelIndex));
            m_dicTotalChannelCalibration[nChannelIndex].FileLocation = strFilePath;
            m_dicTotalChannelCalibration[nChannelIndex].FileName = strFileName;

            SaveCalibrationLoadFile();
            Load();
        }

        //새로운 Channel의 Calibration Data File을 생성한다.
        public void NewChannelCalibrationFile(int nChannelIndex, string strFileName = "")
        {
            int nAnalogIndex = m_dicTotalChannelCalibration[nChannelIndex].AnalogIndex;
            if (m_dicTotalChannelCalibration.ContainsKey(nChannelIndex))
                m_dicTotalChannelCalibration.Remove(nChannelIndex);

            m_dicTotalChannelCalibration.Add(nChannelIndex, new ProtecLaserChannelData_2(nChannelIndex));
            m_dicTotalChannelCalibration[nChannelIndex].AnalogIndex = nAnalogIndex; 

            if (strFileName == string.Empty)
                m_dicTotalChannelCalibration[nChannelIndex].FileName = string.Format("Channel_{0}", nChannelIndex);

            else
                m_dicTotalChannelCalibration[nChannelIndex].FileName = strFileName;

            SaveCalibrationLoadFile();
            Save();
        }
        #endregion /Calibration File

        #endregion

        #region Process Calibration Data

        public double GetProcessCalibrationChannelData(int nChannel, EN_CALIBRATION_PROCESS_LIST_2 enList, double dblOrigin)
        {
            double dblLeftKey = 0.0;
            double dblLeftValue = 0.0;
            double dblRightKey = 0.0;
            double dblRightValue = 0.0;

            double dblTargetMinValue = 0;
            double dblTargetMaxValue = 0;
            double dblCompareMinValue = 0;
            double dblCompareMaxValue = 0;

            foreach (var kvp in m_dicTotalChannelCalibration[nChannel].CalibrationData)
            {
                if (m_dicTotalChannelCalibration[nChannel].CalibrationData.ContainsKey(kvp.Key + 1) == false)
                    continue;

                switch (enList)
                {
                    case EN_CALIBRATION_PROCESS_LIST_2.POWER_VOLT_WATT:
                        dblTargetMinValue = kvp.Value.TargetVolt_2;
                        dblTargetMaxValue = m_dicTotalChannelCalibration[nChannel].CalibrationData[kvp.Key + 1].TargetVolt_2;
                        dblCompareMinValue = kvp.Value.PowerOutputWatt_2;
                        dblCompareMaxValue = m_dicTotalChannelCalibration[nChannel].CalibrationData[kvp.Key + 1].PowerOutputWatt_2;
                        break;
                    case EN_CALIBRATION_PROCESS_LIST_2.POWER_INPUT_VOLT_WATT:
                        dblTargetMinValue = kvp.Value.PowerInputVolt_2;
                        dblTargetMaxValue = m_dicTotalChannelCalibration[nChannel].CalibrationData[kvp.Key + 1].PowerInputVolt_2;
                        dblCompareMinValue = kvp.Value.PowerOutputWatt_2;
                        dblCompareMaxValue = m_dicTotalChannelCalibration[nChannel].CalibrationData[kvp.Key + 1].PowerOutputWatt_2;
                        break;
                    case EN_CALIBRATION_PROCESS_LIST_2.POWER_WATT_VOLT:
                        dblTargetMinValue = kvp.Value.PowerOutputWatt_2;
                        dblTargetMaxValue = m_dicTotalChannelCalibration[nChannel].CalibrationData[kvp.Key + 1].PowerOutputWatt_2;
                        dblCompareMinValue = kvp.Value.TargetVolt_2;
                        dblCompareMaxValue = m_dicTotalChannelCalibration[nChannel].CalibrationData[kvp.Key + 1].TargetVolt_2;
                        break;
                }

                if (dblTargetMinValue <= dblOrigin && dblOrigin <= dblTargetMaxValue)
                {
                    dblLeftKey = dblTargetMinValue;
                    dblLeftValue = dblCompareMinValue;
                    dblRightKey = dblTargetMaxValue;
                    dblRightValue = dblCompareMaxValue;
                    
                    break;
                }
            }

            double dblReturn = CalcResultByTwoPair(dblLeftKey, dblLeftValue, dblRightKey, dblRightValue, dblOrigin);

            if (true == Double.IsNaN(dblReturn))
                dblReturn = 0;

            return dblReturn;
        }
        #endregion

        #region Set Analog Index
        public bool LinkLaserChannel(int nChannelIndex, int nAnalogIndex)
        {
            m_dicTotalChannelCalibration[nChannelIndex].AnalogIndex = nAnalogIndex;


            foreach (var CalibrationData in m_dicTotalChannelCalibration[nChannelIndex].CalibrationData.Values)
            {
                if (-1 == CalibrationData.PowerOutputWatt_2
                    || -1 == CalibrationData.PowerInputVolt_2)
                    continue;

                AnalogIO_.AnalogIO.GetInstance().SetDataToTable(true
                                                                , m_dicTotalChannelCalibration[nChannelIndex].AnalogIndex
                                                                , CalibrationData.Index_2
                                                                , CalibrationData.PowerInputVolt_2
                                                                , CalibrationData.PowerOutputWatt_2);
            }
            return true;
        }
        #endregion /Set Analog Index

        public double GetMaxPower(bool[] bEnable)
        {
            if (bEnable.Length != m_nChannelCount)
                return -1;
            List<double> lstMaxPower = new List<double>();
            for(int nCh = 0; nCh < m_nChannelCount; nCh++)
            {
                if (bEnable[nCh])
                {
                    double nMaxPower = 0;
                    foreach (var kvp in m_dicTotalChannelCalibration[nCh].CalibrationData)
                    {
                        if (nMaxPower < kvp.Value.PowerOutputWatt_2)
                            nMaxPower = kvp.Value.PowerOutputWatt_2;
                    }
                    lstMaxPower.Add(nMaxPower);
                }
            }
            if (lstMaxPower.Count > 0)
            {
                return lstMaxPower.Min() * lstMaxPower.Count;
            }
            else
                return -1;
        }

        public double GetMaxPower(int nCh)
        {
            double nMaxPower = 0;
            foreach (var kvp in m_dicTotalChannelCalibration[nCh].CalibrationData)
            {
                if (nMaxPower < kvp.Value.PowerOutputWatt_2)
                    nMaxPower = kvp.Value.PowerOutputWatt_2;
            }
            return nMaxPower;
        }

        public double GetMinPower(bool[] bEnable)
        {
            if (bEnable.Length != m_nChannelCount)
                return -1;
            List<double> lstMinPower = new List<double>();
            for (int nCh = 0; nCh < m_nChannelCount; nCh++)
            {
                if (bEnable[nCh])
                {
                    double nMinPower = 100000;
                    foreach (var kvp in m_dicTotalChannelCalibration[nCh].CalibrationData)
                    {
                        if (nMinPower > kvp.Value.PowerOutputWatt_2
                            && kvp.Value.PowerOutputWatt_2 > 0)
                            nMinPower = kvp.Value.PowerOutputWatt_2;
                    }
                    lstMinPower.Add(nMinPower);
                }
            }
            if (lstMinPower.Count > 0)
            {
                return lstMinPower.Max() * lstMinPower.Count;
            }
            else
                return -1;
        }

        #endregion /Calibration Information

        #endregion /External Interface

        #region Internal Interface

        #region Calibration

        private bool Load()
        {
            string strFilePath = String.Format("{0}\\{1}{2}"
                , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                , m_strCalibrationFileName
                , Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

            string strDescription = string.Empty;
            string[] arDescription = null;

            if (File.Exists(strFilePath) == false)
                return false;
            
            using (StreamReader readFile = new StreamReader(strFilePath))
            {
                while (!readFile.EndOfStream)
                {
                    strDescription = readFile.ReadLine();

                    arDescription = strDescription.Split(',');

                    #region
                    int nChannelIndex = 0;

                    if (false == Int32.TryParse(arDescription[0], out nChannelIndex))
                        continue;

                    if (false == m_dicTotalChannelCalibration.ContainsKey(nChannelIndex))
                        return false;

                    m_dicTotalChannelCalibration[nChannelIndex].FileLocation = arDescription[1];
                    m_dicTotalChannelCalibration[nChannelIndex].FileName = arDescription[2];
                    // 2023 05 11 수정됨
                    string strChannelFilePath = String.Format("{0}\\{1}{2}"
                    , arDescription[1]
                    , arDescription[2]
                    , Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

                    if (File.Exists(strChannelFilePath) == false)
                        return false;

                    using (StreamReader readChannelFile = new StreamReader(strChannelFilePath))
                    {
                        string strChannelDescription = string.Empty;
                        string[] arChannelDescription = null;
                        while (!readChannelFile.EndOfStream)
                        {
                            strChannelDescription = readChannelFile.ReadLine();

                            arChannelDescription = strChannelDescription.Split(',');

                            int nIndex = 0;
                            if (false == Int32.TryParse(arChannelDescription[(int)EN_CALIBRATION_INDEX_2.INDEX], out nIndex))
                                continue;

                            if (false == m_dicTotalChannelCalibration[nChannelIndex].CalibrationData.ContainsKey(nIndex))
                                continue;

                            m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].TargetVolt_2 = double.Parse(arChannelDescription[(int)EN_CALIBRATION_INDEX_2.TARGET_VOLT]);
                            m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerOutputWatt_2 = double.Parse(arChannelDescription[(int)EN_CALIBRATION_INDEX_2.POWER_OUTPUT_WATT]);
                            m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerInputVolt_2 = double.Parse(arChannelDescription[(int)EN_CALIBRATION_INDEX_2.POWER_INPUT_VOLT]);

                            // Output Power가 없을경우 건너뛰기
                            if (-1 == m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerOutputWatt_2
                                || -1 == m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerInputVolt_2
                                || -1 == m_dicTotalChannelCalibration[nChannelIndex].AnalogIndex)
                                continue;

                            AnalogIO_.AnalogIO.GetInstance().SetDataToTable(true
                                                                            , m_dicTotalChannelCalibration[nChannelIndex].AnalogIndex
                                                                            , nIndex
                                                                            , m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerInputVolt_2
                                                                            , m_dicTotalChannelCalibration[nChannelIndex].CalibrationData[nIndex].PowerOutputWatt_2);

                        }
                    }

                    #endregion
                }
            }

            return true;
        }

        // Channel의 Calibration File을 변경 시 사용
        private bool SaveCalibrationLoadFile()
        {
            string strFilePath = String.Format("{0}\\{1}{2}"
                                , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                                , m_strCalibrationFileName
                                , Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

            string strDescription = string.Empty;

            if (false == Directory.Exists(Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER))
                Directory.CreateDirectory(Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER);

            using (StreamWriter writeFile = new StreamWriter(strFilePath))
            {

                for (int nChannelIndex = 0; nChannelIndex < m_nChannelCount; ++nChannelIndex)
                {
                    strDescription = string.Empty;

                    string strChannelFileLocation = string.Empty;
                    string strFileName = string.Empty;

                    if (string.Empty == m_dicTotalChannelCalibration[nChannelIndex].FileLocation)
                    {
                        strChannelFileLocation = String.Format("{0}\\{1}"
                                , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                                , m_strCalibrationFileName);

                        strFileName = String.Format("{0}"
                                , string.Format("Channel_{0}", nChannelIndex));
                    }

                    else
                    {
                        strChannelFileLocation = m_dicTotalChannelCalibration[nChannelIndex].FileLocation;

                        strFileName = m_dicTotalChannelCalibration[nChannelIndex].FileName;
                    }

                    string strChannelFilePath = string.Format("{0}\\{1}{2}", strChannelFileLocation, strFileName, Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

                    if (false == Directory.Exists(strChannelFileLocation))
                        Directory.CreateDirectory(strChannelFileLocation);

                    strDescription = String.Format("{0},{1},{2}", nChannelIndex, strChannelFileLocation, strFileName);

                    writeFile.WriteLine(strDescription);
                }
            }

            return true;
        }

        // 현재 사용중인 Channel Calibraion Data 저장
        private bool Save()
        {
            string strFilePath = String.Format("{0}\\{1}{2}"
                                , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                                , m_strCalibrationFileName
                                , Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

            string strDescription = string.Empty;

            if (false == Directory.Exists(Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER))
                Directory.CreateDirectory(Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER);


            using (StreamWriter writeFile = new StreamWriter(strFilePath))
            {
                for (int nChannelIndex = 0; nChannelIndex < m_nChannelCount; ++nChannelIndex)
                {
                    strDescription = string.Empty;

                    string strChannelFileLocation = string.Empty;
                    string strFileName = string.Empty;

                    if(string.Empty == m_dicTotalChannelCalibration[nChannelIndex].FileLocation)
                    {
                        strChannelFileLocation = String.Format("{0}\\{1}"
                                , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                                , m_strCalibrationFileName);

                        strFileName = String.Format("{0}"
                                , string.Format("Channel_{0}", nChannelIndex));
                    }

                    else
                    {
                        strChannelFileLocation = m_dicTotalChannelCalibration[nChannelIndex].FileLocation;

                        strFileName = m_dicTotalChannelCalibration[nChannelIndex].FileName;
                    }

                    string strChannelFilePath = string.Format("{0}\\{1}{2}", strChannelFileLocation, strFileName, Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

                    if (false == Directory.Exists(strChannelFileLocation))
                        Directory.CreateDirectory(strChannelFileLocation);

                    strDescription = String.Format("{0},{1},{2}", nChannelIndex, strChannelFileLocation, strFileName);

                    writeFile.WriteLine(strDescription);

                    using (StreamWriter writeChannelFile = new StreamWriter(strChannelFilePath))
                    {
                        strDescription = string.Empty;
                        foreach (EN_CALIBRATION_INDEX_2 enIndex in Enum.GetValues(typeof(EN_CALIBRATION_INDEX_2)))
                        {
                            strDescription += enIndex.ToString() + ",";
                        }

                        writeChannelFile.WriteLine(strDescription);

                        foreach (var kvp in m_dicTotalChannelCalibration[nChannelIndex].CalibrationData)
                        {
                            strDescription = String.Format("{0},{1:0.000},{2:0.000},{3:0.000}"
                                                            , kvp.Value.Index_2
                                                            , kvp.Value.TargetVolt_2
                                                            , kvp.Value.PowerOutputWatt_2
                                                            , kvp.Value.PowerInputVolt_2);

                            writeChannelFile.WriteLine(strDescription);
                        }
                    }
                }
            }

            return true;
        }
        #endregion

        #region Calculate Calibration
        private double CalcResultByTwoPair(double dblLeftKey, double dblLeftValue, double dblRightKey, double dblRightValue, double dblkey)
        {
            return dblLeftValue + (((dblkey - dblLeftKey) * 0.001) * ((dblRightValue - dblLeftValue) / ((dblRightKey - dblLeftKey) * 0.001)));
        }
        #endregion

        #endregion
    }

    #region Class
    public class ProtecLaserChannelData_2
    {
        private int m_nChannelIndex = -1;
        private int m_nAnalogIndex = -1;

        string m_strFileName = string.Empty;
        string m_strFilePath = string.Empty;
        private Dictionary<int, ProtecLaserCalibrationData_2> m_dicCalibrationData = new Dictionary<int, ProtecLaserCalibrationData_2>();

        public Dictionary<int, ProtecLaserCalibrationData_2> CalibrationData { get { return m_dicCalibrationData; } set { m_dicCalibrationData = value; } }
        public int AnalogIndex { get { return m_nAnalogIndex; } set { m_nAnalogIndex = value; } }
        public string FileName { get { return m_strFileName; } set { m_strFileName = value; } }
        public string FileLocation { get { return m_strFilePath; } set { m_strFilePath = value; } }

        public ProtecLaserChannelData_2(int nChannelIndex)
        {
            m_nChannelIndex = nChannelIndex;
            for (int nIndex = 0; nIndex < 20; ++nIndex)
                m_dicCalibrationData.Add(nIndex, new ProtecLaserCalibrationData_2(nIndex));
        }
    }

    public class ProtecLaserCalibrationData_2
    {
        #region Variables

        private int m_nIndex = 0;
        private double m_dblTargetVolt_2 = 0;
        private double m_dblPowerOutputWatt_2 = -1;
        private double m_dblPowerInputVolt_2 = -1;
        #endregion

        #region Property

        public int Index_2 { get { return m_nIndex; } }
        public double TargetVolt_2 { set { m_dblTargetVolt_2 = value; } get { return m_dblTargetVolt_2; } }
        public double PowerOutputWatt_2 { set { m_dblPowerOutputWatt_2 = value; } get { return m_dblPowerOutputWatt_2; } }
        public double PowerInputVolt_2 { set { m_dblPowerInputVolt_2 = value; } get { return m_dblPowerInputVolt_2; } }
        #endregion

        #region Consructor
        public ProtecLaserCalibrationData_2(int nIndex)
        {
            m_nIndex = nIndex;
        }
        #endregion

        #region External Interface
        public void InitializeValue(int nVolt)
        {
            m_dblTargetVolt_2 = nVolt;

            m_dblPowerOutputWatt_2 = -1;
            m_dblPowerInputVolt_2 = -1;
        }
        #endregion
    }
    #endregion /Class
}
