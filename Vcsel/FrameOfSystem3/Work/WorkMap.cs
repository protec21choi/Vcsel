using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FrameOfSystem3.Work
{
    public enum EN_WORK_STATUS
    {
        UNDEFINE = -1,
        WAIT,
        DONE,
        LOW_TEMP,
        TEMP_GROW_FAIL,
        TEMP_DEVOVER,
        HIGH_TEMP,
        MAX_HIGH_TEMP,
        EMG_LOW_TEMP,
        EMG_HIGH_TEMP,
        POWER_FAULT,
        SOURCE_ALARM,
        RESULT_GETFAIL,
    }

    public enum EN_WAFER_ITEM
    {
        Lane,
        WAFER_ID,
        LOT_ID,
        PART_NAME,
        LOT_TYPE,
        STEP_SEQ,
        WAFER_COL,
        WAFER_ROW,
        ANGLE,
        WAFER_MAP,
        COUNT_CHIPS,
        SLOT_NO,
        ProcessResult,
        WORK_STATUS,
    }
    public class WorkMap
    {
        
        #region 싱글톤
        private WorkMap() 
        {
            m_pWorkMap = new MapData();
        }

        private static readonly Lazy<WorkMap> lazyInstance = new Lazy<WorkMap>(() => new WorkMap());
        static public WorkMap GetInstance() 
        {
            return lazyInstance.Value; 
        }
        #endregion

        #region 상수
        //private readonly string WorkStaus = "WorkStatus";
        readonly string strFilePath = Define.DefineConstant.FilePath.FILEPATH_WORK;//work중인 Map은 이걸로 확인하자.
        readonly string strFileName = "Work.Map";

        #endregion

        #region 필드
        MapData m_pWorkMap;
        #endregion

        #region 인터페이스
        public bool Init()
        {
            return m_pWorkMap.Load(strFilePath, strFileName);
        }

        public void ResetMap(string MapID = "", bool bSave = true)
        {
            m_pWorkMap = new MapData();
            m_pWorkMap.strMapName = MapID;
            m_pWorkMap.SetValue(EN_WAFER_ITEM.WAFER_ID.ToString(), MapID);
            m_pWorkMap.SetValue(EN_WAFER_ITEM.WORK_STATUS.ToString(), EN_WORK_STATUS.WAIT.ToString());
            if (bSave)
                m_pWorkMap.Save(strFilePath, strFileName);
        }

        public void SetWorkStatus(EN_WORK_STATUS enStatus, bool bSave = true)
        {
            m_pWorkMap.SetValue(EN_WAFER_ITEM.WORK_STATUS.ToString(), enStatus.ToString());
            if (bSave)
                m_pWorkMap.Save(strFilePath, strFileName);
        }
        public void SetWorkStatus(string strStatus, bool bSave = true)
        {
            m_pWorkMap.SetValue(EN_WAFER_ITEM.WORK_STATUS.ToString(), strStatus);
            if (bSave)
                m_pWorkMap.Save(strFilePath, strFileName);
        }
        public string GetID()
        {
            return m_pWorkMap.strMapName;
        }
        public EN_WORK_STATUS GetWorkStatus()
        {
            string strStatus = m_pWorkMap.GetValue(EN_WAFER_ITEM.WORK_STATUS.ToString());
            EN_WORK_STATUS enStatus = EN_WORK_STATUS.UNDEFINE;
            Enum.TryParse(strStatus, out enStatus);

            return enStatus;
        }

        public void SetValue(EN_WAFER_ITEM enItem, string strValue, bool bSave = true)
        {
            m_pWorkMap.SetValue(enItem.ToString(), strValue);
            if (bSave)
                m_pWorkMap.Save(strFilePath, strFileName);
        }
        public string GetValue(EN_WAFER_ITEM enItem)
        {
           return m_pWorkMap.GetValue(enItem.ToString());

        }
        public void SaveBackup()
        {
            if(m_pWorkMap.strMapName != string.Empty)
            {
                string strFullPathSourceFile = strFilePath + "\\" + strFileName;

                string strPathDestFile = strFilePath;
                strPathDestFile += string.Format("\\{0}", DateTime.Now.ToString("yyMMdd"));

                if (!Directory.Exists(strPathDestFile))
                    Directory.CreateDirectory(strPathDestFile);

                string strFullPathDestFile = strPathDestFile + "\\" + m_pWorkMap.strMapName;

                if (File.Exists(strFullPathDestFile))
                    File.Delete(strFullPathDestFile);

                if (File.Exists(strFullPathSourceFile))
                    File.Copy(strFullPathSourceFile, strFullPathDestFile);
            }
            m_pWorkMap.SetValue(EN_WAFER_ITEM.WORK_STATUS.ToString(), EN_WORK_STATUS.WAIT.ToString());
        }
        #endregion
    }
}
