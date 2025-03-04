using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Define.DefineEnumProject.Laser;
//using Define.DefineEnumProject.Task;

namespace FrameOfSystem3.Laser
{
    class AjinAnalogListControl
    {
        #region Variables
        private AnalogIO_.AnalogIO m_instanceAnalog = AnalogIO_.AnalogIO.GetInstance();
        private const int m_nMaxTableCount = 8196;
        private double[] m_arLaserTable = new double[m_nMaxTableCount];
        //private int m_nLaserListCount = 0;

        private int m_nInterval = 1;
        #endregion

        #region 속성
    
        #endregion

        #region SingleTone
        private AjinAnalogListControl() { }
        private static AjinAnalogListControl _Instance = null;
        public static AjinAnalogListControl GetInstance() 
        {
            if (_Instance == null)
            {
                _Instance = new AjinAnalogListControl();
            }
            return _Instance; 
        }
        #endregion

        #region External Interface


        public void Ready(int nIndex, int nTime, double dOutputVolt)
        {
            int[] arIndex = new int[] { nIndex };
            m_instanceAnalog.StopOutputListTable(ref arIndex, arIndex.Length);

            m_instanceAnalog.ResetOutputListTable(nIndex);

            m_nInterval = (nTime / m_nMaxTableCount) + 1;

            m_instanceAnalog.SetOutputListTableInterval(nIndex, m_nInterval);
            
            m_arLaserTable = new double[m_nMaxTableCount];

            
            int m_nLaserListCount = nTime / m_nInterval;
            for (int nRepeat = 0; nRepeat < m_nLaserListCount; nRepeat++)
            {
                m_arLaserTable[nRepeat] = dOutputVolt;
            }

            m_instanceAnalog.SetOutputListTable(nIndex
               , 1
               , m_nLaserListCount + 1
               , ref m_arLaserTable);
        }

        public void Start(int nIndex)
        {
            int[] arIndex = new int[] { nIndex };
            m_instanceAnalog.StartOutputListTable(ref arIndex, arIndex.Length);
        }

        public bool CheckEnd(int nIndex)
        {
            int nPatternIndex = 0;
            int nCountOfLoof = 0;
            uint nBusy = 0;

            m_instanceAnalog.GetOutputListTableStatus(nIndex
                , ref nPatternIndex
                , ref nCountOfLoof
                , ref nBusy);

            return nBusy == 0;
        }

        public void Stop(int nIndex)
        {
            int[] arIndex = new int[] { nIndex };
            m_instanceAnalog.StopOutputListTable(ref arIndex, arIndex.Length);

            m_instanceAnalog.ResetOutputListTable(nIndex);
        }
        #endregion

        #region Internal

        #endregion
    }
}
