using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameOfSystem3.Work
{
    class MapData
    {
        private string m_strMapName = string.Empty;
        private Dictionary<string, string> m_dicItem = new Dictionary<string, string>();
        private Dictionary<int, MapData> m_dicUnit = new Dictionary<int, MapData>();

        private const string ItemMapName = "MAPNAME";

        public string strMapName { get { return m_strMapName; } set { m_strMapName = value; } }
     
        private void GetMapList(ref List<string> lstMapName)
        {
            if (false == lstMapName.Contains(m_strMapName)
                && m_strMapName != "")
                lstMapName.Add(m_strMapName);

            int[] arKeys = m_dicUnit.Keys.ToArray();
            for (int nIndex = 0; nIndex < m_dicUnit.Count; nIndex++)
            {
                m_dicUnit[arKeys[nIndex]].GetMapList(ref lstMapName);
            }
        }

        public MapData GetUnitMap(int nIndex)
        {
            if (m_dicUnit.ContainsKey(nIndex))
                return m_dicUnit[nIndex];

            return null;
        }

        public MapData GetUnitMap(string strMapName)
        {
            if (m_strMapName == strMapName)
                return this;

            int[] arKeys = m_dicUnit.Keys.ToArray();
            for (int nIndex = 0; nIndex < m_dicUnit.Count; nIndex++)
            {
                MapData ReturnMap = m_dicUnit[arKeys[nIndex]].GetUnitMap(strMapName);
                if (ReturnMap != null)
                    return ReturnMap;
            }

            return null;
        }

        public void SetUnitMap(int nIndex, MapData UnitMap)
        {
            if (m_dicUnit.ContainsKey(nIndex))
                m_dicUnit.Remove(nIndex);

            m_dicUnit.Add(nIndex, UnitMap);
        }

        public string GetValue(string ItemName)
        {
            if (m_dicItem.ContainsKey(ItemName))
                return m_dicItem[ItemName];

            return "";
        }

        public void SetValue(string ItemName, string Value)
        {
            if (Value == null) Value = string.Empty;
            if (m_dicItem.ContainsKey(ItemName))
                m_dicItem[ItemName] = Value;
            else
                m_dicItem.Add(ItemName, Value);
        }

        public void Save(string FilePath, string FileName)
        {
            FileComposite_.FileComposite fComp = FileComposite_.FileComposite.GetInstance();

            fComp.RemoveRoot(m_strMapName);
            fComp.CreateRoot(m_strMapName);

            List<string> lstMapName = new List<string>();
            GetMapList(ref lstMapName);

            for (int nMapIndex = 0; nMapIndex < lstMapName.Count; nMapIndex++)
            {
                string MapName = lstMapName[nMapIndex];
                MapData Map = GetUnitMap(MapName);
                fComp.AddGroup(m_strMapName, MapName);
                if (Map.m_strMapName != string.Empty)
                    fComp.AddItem(m_strMapName, ItemMapName, Map.m_strMapName, MapName);
           
                if (MapName == m_strMapName) //Map Item은 최상위 맵에만 저장 (중복 저장 방지)
                {
                    string[] arItemKeys = m_dicItem.Keys.ToArray();
                    for (int nItemIndex = 0; nItemIndex < m_dicItem.Count; nItemIndex++)
                    {
                        
                        fComp.AddItem(m_strMapName, arItemKeys[nItemIndex], m_dicItem[arItemKeys[nItemIndex]], MapName);
                    }
                }

                int[] arUnitKeys = Map.m_dicUnit.Keys.ToArray();
                for (int nUnitIIndex = 0; nUnitIIndex < Map.m_dicUnit.Count; nUnitIIndex++)
                {
                    string[] arGroupLevel = new string[] { MapName, arUnitKeys[nUnitIIndex].ToString() };
                    MapData UnitMap = Map.m_dicUnit[arUnitKeys[nUnitIIndex]];
                    fComp.AddGroup(m_strMapName, arGroupLevel);
                    if (UnitMap.m_strMapName != string.Empty)
                        fComp.AddItem(m_strMapName, ItemMapName, UnitMap.m_strMapName, arGroupLevel);

                    string[] arUnitItemKeys = Map.m_dicItem.Keys.ToArray();
                    for (int nItemIndex = 0; nItemIndex < UnitMap.m_dicItem.Count; nItemIndex++)
                    {
                        fComp.AddItem(m_strMapName, arUnitItemKeys[nItemIndex], UnitMap.m_dicItem[arUnitItemKeys[nItemIndex]], arGroupLevel);
                    }
                }
            }

            string sFileData = string.Empty;
            if (!fComp.GetStructureAsString(m_strMapName, ref sFileData))
                return;

             FileIOManager_.FileIOManager fIO = FileIOManager_.FileIOManager.GetInstance();

             if (!fIO.Write(FilePath, FileName, sFileData, false, false))
                return;
        }

        public bool Load(string FilePath, string FileName)
        {
            string strData = string.Empty;
            if (false == FileIOManager_.FileIOManager.GetInstance().Read(FilePath
                , FileName
                , ref strData
                , 5000))
                return false;

            FileComposite_.FileComposite fComp = FileComposite_.FileComposite.GetInstance();

            string[] arData = strData.Split('\n');
            string strRoot = string.Empty;
            if (fComp.CreateRootByString(ref arData, ref strRoot))
            {
                string[] arMapName = new string[0];
                fComp.GetListOfGroup(strRoot, ref arMapName);

                Dictionary<string, MapData> dicLoadMap = new Dictionary<string, MapData>();

                for (int nMapIndex = 0; nMapIndex < arMapName.Length; nMapIndex++)
                {
                    MapData ParentMap = new MapData();

                    string[] arItem = new string[0];
                    fComp.GetListOfItem(strRoot, ref arItem, arMapName[nMapIndex]);//root와 같은 이름이 최상위 맵

                    for (int nItemIndex = 0; nItemIndex < arItem.Length; nItemIndex++)
                    {
                        string strValue = "";
                        fComp.GetValue(strRoot, arItem[nItemIndex], ref strValue, strRoot);
                        switch (arItem[nItemIndex])
                        {
                            case ItemMapName:
                                ParentMap.m_strMapName = strValue;
                                break;

                            default:
                                ParentMap.m_dicItem.Add(arItem[nItemIndex], strValue);
                                break;
                        }
                    }


                    string[] arGroup = new string[0];
                    fComp.GetListOfGroup(strRoot, ref arGroup, arMapName[nMapIndex]);

                    for (int nGroupIndex = 0; nGroupIndex < arGroup.Length; nGroupIndex++)
                    {
                        MapData UnitMap = new MapData();

                        string[] arGroupLevel = new string[] { arMapName[nMapIndex], arGroup[nGroupIndex] };

                        string[] arUnitItem = new string[0];
                        fComp.GetListOfItem(strRoot, ref arItem, arGroupLevel);

                        for (int nItemIndex = 0; nItemIndex < arItem.Length; nItemIndex++)
                        {
                            string strValue = "";
                            fComp.GetValue(strRoot, arItem[nItemIndex], ref strValue, arGroupLevel);
                            switch (arItem[nItemIndex])
                            {
                                case ItemMapName:
                                    UnitMap.m_strMapName = strValue;
                                    break;

                                default:
                                    UnitMap.m_dicItem.Add(arItem[nItemIndex], strValue);
                                    break;
                            }
                        }

                        int UnitIndex = 0;
                        if (int.TryParse(arGroup[nGroupIndex], out UnitIndex))
                            ParentMap.SetUnitMap(UnitIndex, UnitMap);
                    }

                    dicLoadMap.Add(arMapName[nMapIndex], ParentMap);
                }

                //Tree 구조 조립
                for (int nMapIndex = arMapName.Length - 1; nMapIndex >= 0; nMapIndex--)//저장이 최상위 맵부터 됨으로 역순으로 최하위 맵부터 조립한다.
                {
                    int[] arUnitIndex = dicLoadMap[arMapName[nMapIndex]].m_dicUnit.Keys.ToArray();
                    for (int nUnitIndex = 0; nUnitIndex < dicLoadMap[arMapName[nMapIndex]].m_dicUnit.Count; nUnitIndex++)
                    {
                        if (dicLoadMap.ContainsKey(dicLoadMap[arMapName[nMapIndex]].m_dicUnit[arUnitIndex[nUnitIndex]].m_strMapName))
                        {
                            dicLoadMap[arMapName[nMapIndex]].m_dicUnit[arUnitIndex[nUnitIndex]].m_dicUnit = dicLoadMap[dicLoadMap[arMapName[nMapIndex]].m_dicUnit[arUnitIndex[nUnitIndex]].m_strMapName].m_dicUnit;
                        }
                    }
                }

                if (dicLoadMap.ContainsKey(strRoot) == false)
                    return false;
                m_strMapName = dicLoadMap[strRoot].m_strMapName;
                m_dicItem = dicLoadMap[strRoot].m_dicItem;
                m_dicUnit = dicLoadMap[strRoot].m_dicUnit;
            }
            return true;
        }

    }
}
