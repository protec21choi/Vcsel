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
    public class ProtecLaserLossRateCalibration
    {
        #region Singleton
        static private ProtecLaserLossRateCalibration _Instance = new ProtecLaserLossRateCalibration();
        static public ProtecLaserLossRateCalibration GetInstance()
        {
            return _Instance;
        }
        #endregion

        #region Variables

        List<CalData> m_ListCalData = new List<CalData>();
        #region Instance
        #endregion

        #region Calibration

        private string m_strLossRateFileName = "LossRateCalData";
        #endregion
        #endregion

        #region Property

        #endregion

        #region External Interface

        #region Init
        public void Init()
        {
            LoadFile();
        }
        #endregion /Init

        #region Calculate Data
        public double GetConverteData(double TargetPower)
        {
            double dResult = 0;

            if (m_ListCalData.Count < 2)
                return TargetPower;

            //손실이 없을 때의 예상 출력
            double dForecastPower = TargetPower * m_ListCalData[0].dMeasurePower / m_ListCalData[0].dTargetPower;

            double dUnderKey = 0;
            double dUnderValue = 0;
            double dUpperKey = 0;
            double dUpperValue = 0;

            //손실된 측정치
            double dLossValue = 0;

            for (int nIndex = 0; nIndex < m_ListCalData.Count - 1; nIndex++)
            {
                if (TargetPower < m_ListCalData[0].dTargetPower)
                {
                    //최소치는 손실률 없을것으로 판단됨
                    return TargetPower;
                    // 추후에 필요하다면 고민
                }
                else if (m_ListCalData[nIndex].dTargetPower < TargetPower
                    && m_ListCalData[nIndex + 1].dTargetPower > TargetPower)
                {
                    dUnderKey = m_ListCalData[nIndex].dTargetPower;
                    dUnderValue = m_ListCalData[nIndex].dMeasurePower;
                    dUpperKey = m_ListCalData[nIndex + 1].dTargetPower;
                    dUpperValue = m_ListCalData[nIndex + 1].dMeasurePower;

                    dLossValue = CalcResultByTwoPair(dUnderKey, dUnderValue, dUpperKey, dUpperValue, TargetPower);
                }
            }

            if (dLossValue == 0)
            {
                //측정 타겟을 넘어가는 데이터는 마지막 테이블로 손실률 계산 하자.
                dUnderKey = m_ListCalData[m_ListCalData.Count - 2].dTargetPower;
                dUnderValue = m_ListCalData[m_ListCalData.Count - 2].dMeasurePower;
                dUpperKey = m_ListCalData[m_ListCalData.Count - 1].dTargetPower;
                dUpperValue = m_ListCalData[m_ListCalData.Count - 1].dMeasurePower;

                dLossValue = CalcResultUpperOutOfRange(dUnderKey, dUnderValue, dUpperKey, dUpperValue, TargetPower);
            }
            dResult = TargetPower * (dForecastPower / dLossValue);

            return dResult;
        }
        #endregion /Calculate Data

        #region Calibration Information
        public void AddCalibrationData(bool bSave = true)
        {
            CalData calData = new CalData();
            m_ListCalData.Add(calData);
            if (bSave)
                SaveFile();
        }
        public void SetTargetPower(int nIndex, double dValue, bool bSave = true)
        {
            //없는 Index 추가
            for (int nCount = m_ListCalData.Count; nCount <= nIndex; nCount++)
            {
                CalData calData = new CalData();
                m_ListCalData.Add(calData);
            }

            m_ListCalData[nIndex].dTargetPower = dValue;
             if (bSave)
                SaveFile();
        }
        public void SetMeasurePower(int nIndex, double dValue, bool bSave = true)
        {
            //없는 Index 추가
            for (int nCount = m_ListCalData.Count; nCount <= nIndex; nCount++)
            {
                CalData calData = new CalData();
                m_ListCalData.Add(calData);
            }

            m_ListCalData[nIndex].dMeasurePower = dValue;
             if (bSave)
                SaveFile();
        }

        public double GetTargetPower(int nIndex)
        {
            if(m_ListCalData.Count <= nIndex)
            {
                return -1;
            }
            return m_ListCalData[nIndex].dTargetPower;
        }
        public double GetMeasurePower(int nIndex)
        {
            if (m_ListCalData.Count <= nIndex)
            {
                return -1;
            }
            return m_ListCalData[nIndex].dMeasurePower;
        }

        public double GetLossRate(int nIndex)
        {
            double dForecastPower = m_ListCalData[nIndex].dTargetPower * m_ListCalData[0].dMeasurePower / m_ListCalData[0].dTargetPower;

            return (dForecastPower - m_ListCalData[nIndex].dTargetPower) / dForecastPower;
        }
        #endregion /Calibration Information

        #endregion /External Interface

        #region Internal Interface

        #region Calculate Calibration
        private double CalcResultByTwoPair(double dblLeftKey, double dblLeftValue, double dblRightKey, double dblRightValue, double dblkey)
        {
            return dblLeftValue + (((dblkey - dblLeftKey) * 0.001) * ((dblRightValue - dblLeftValue) / ((dblRightKey - dblLeftKey) * 0.001)));
        }

        private double CalcResultUpperOutOfRange(double dblLeftKey, double dblLeftValue, double dblRightKey, double dblRightValue, double dblkey)
        {
            return dblRightValue + (((dblkey - dblRightKey) * 0.001) * ((dblRightValue - dblLeftValue) / ((dblRightKey - dblLeftKey) * 0.001)));
        }
        #endregion

        #region FileMananger
        private bool SaveFile()
        {
            string strFilePath = String.Format("{0}\\{1}{2}"
                                         , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                                         , m_strLossRateFileName
                                         , Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);


            if (false == Directory.Exists(Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER))
                Directory.CreateDirectory(Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER);


            using (StreamWriter writeFile = new StreamWriter(strFilePath))
            {
               string strData = "TARGET POWER,MEASURE POWER";
                    writeFile.WriteLine(strData);

                  foreach(CalData calData in m_ListCalData)
                  {
                      strData = string.Format("{0},{1}", calData.dTargetPower, calData.dMeasurePower);
                      writeFile.WriteLine(strData);
                  }
            }

            return true;
        }

        private bool LoadFile()
        {
            string strFilePath = String.Format("{0}\\{1}{2}"
                                         , Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER
                                         , m_strLossRateFileName
                                         , Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION);

          
            string[] arData = null;
            string strReadData = "";

            if (File.Exists(strFilePath) == false)
                return false;

            m_ListCalData.Clear();
            
            using (StreamReader readFile = new StreamReader(strFilePath))
            {
                while (!readFile.EndOfStream)
                {
                    strReadData = readFile.ReadLine();

                    arData = strReadData.Split(',');

                    double dTargetPower = 0;
                    double dMeasurePower = 0;
                    
                    if(double.TryParse(arData[0], out dTargetPower)
                        && double.TryParse(arData[1], out dMeasurePower))
                    {
                        CalData calData = new CalData();
                        calData.dTargetPower = dTargetPower;
                        calData.dMeasurePower = dMeasurePower;
                        m_ListCalData.Add(calData);
                    }
                }
            }
            return true;
        }
        #endregion

        class CalData
        {
            public double dTargetPower = 0;
            public double dMeasurePower = 0;
        }
        #endregion
    }
}
 