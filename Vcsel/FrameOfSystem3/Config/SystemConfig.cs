using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

using Define.DefineConstant;

namespace FrameOfSystem3.Config
{
    class SystemConfig
    {
        #region 싱글톤
        private SystemConfig() 
        {
            Load();

            CamCount = GetValue(NameOf(() => CamCount), 1);
            Powermeter = (FrameOfSystem3.ExternalDevice.Serial.EN_POWERMETER_DEVICETYPE)GetValue(NameOf(() => Powermeter), typeof(FrameOfSystem3.ExternalDevice.Serial.EN_POWERMETER_DEVICETYPE), FrameOfSystem3.ExternalDevice.Serial.EN_POWERMETER_DEVICETYPE.LABMAX);
            PowermeterGraphVisible = GetValue(NameOf(() => PowermeterGraphVisible), true);
        }

        private static readonly Lazy<SystemConfig> lazyInstance = new Lazy<SystemConfig>(() => new SystemConfig());
        static public SystemConfig GetInstance() 
        {
            return lazyInstance.Value; 
        }
        #endregion

        #region Varible
        private Dictionary<string, string> dicItem = new Dictionary<string, string>();

        public readonly int CamCount;
        public readonly FrameOfSystem3.ExternalDevice.Serial.EN_POWERMETER_DEVICETYPE Powermeter;
        public bool PowermeterGraphVisible;
        #endregion

        #region method
        private bool Load()
        {
            string strFilePath = FilePath.FILEPATH_CONFIG + "\\System.cfg";

            if(File.Exists(strFilePath) == false)
                return false;

            string[] arReadLines;
            using (FileStream fstream = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sReader = new StreamReader(fstream, Encoding.UTF8))
                {
                    arReadLines = sReader.ReadToEnd().Split('\n');

                    sReader.Close();
                }
                fstream.Close();
            }
            for (int nIndex = 0; nIndex < arReadLines.Length; nIndex++)
            {
                string[] arItem = arReadLines[nIndex].Split('=');

                if (arItem.Length == 2)
                {
                    string strName = arItem[0].Trim();
                    string strValue = arItem[1].Trim();
                    if (dicItem.ContainsKey(strName) == false)
                    {
                        dicItem.Add(strName, strValue);
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// 변수 이름을 string으로 반환
        /// </summary>
        string NameOf<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;

            return (body.Member.Name);
        }

        string GetValue(string strName, string strDefault)
        {
            string strRetun = strDefault;

            if (dicItem.ContainsKey(strName))
            {
                return dicItem[strName];
            }

            return strDefault;
        }
        bool GetValue(string strName, bool bDefault)
        {
            bool bRetun = bDefault;

            if (dicItem.ContainsKey(strName))
            {
                if (bool.TryParse(dicItem[strName], out bRetun))
                {
                    return bRetun;
                }
            }

            return bDefault;
        }
        int GetValue(string strName, int nDefault)
        {
            int nRetun = nDefault;

            if (dicItem.ContainsKey(strName))
            {
                if (int.TryParse(dicItem[strName], out nRetun))
                {
                    return nRetun;
                }
            }

            return nDefault;
        }
        object GetValue(string strName, Type enumType, Enum enDefault)
        {
            object enRetun = enDefault;

            if (dicItem.ContainsKey(strName))
            {
                try
                {
                    return Enum.Parse(enumType, dicItem[strName]);
                }
                catch
                {
                    return enDefault;
                }
            }

            return enDefault;
        }
        #endregion /method
    }
}
