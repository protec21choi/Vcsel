using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using RecipeManager_;
using FileIOManager_;
using FileComposite_;

using FileBorn_;

using FrameOfSystem3.Log;
using Define.DefineEnumBase.Log;

namespace FrameOfSystem3.Recipe
{
	#region 열거형
	public enum EN_RECIPE_TYPE
	{
		COMMON = 0,
		EQUIPMENT = 1,
		PROCESS = 2,
	}
	public enum EN_RECIPE_PARAM_TYPE
	{
		MIN = 0,
		MAX = 1,
		VALUE = 2,
		UNIT = 3,
        AUTHORITY = 4,
        DATA_TYPE = 5,
        DESCRIPTION = 6,
	}
    public enum EN_DATA_TYPE
    {
        ASCII,
        BINARY,
        BOOL,
        UINT1,
        UINT2,
        UINT4,
        INT1,
        INT2,
        INT4,
        FLOAT4,
        FLOAT8
    }
	#endregion

	/// <summary>
	/// 2020.06.29 by yjlee [ADD] Manages the recipe parameters.
	/// </summary>
	public class Recipe
	{
		#region Singleton
		private Recipe() { }
		private static Recipe m_instance            = new Recipe();
		public static Recipe GetInstance() { return m_instance; }
		#endregion

		#region Constant
		private const string TOKEN_GROUP			= "GROUP ";
		private const string ROOT_COMMON			= "COMMON";
		private const string ROOT_EQUIPMENT			= "EQUIPMENT";
		private const string ROOT_PROCESS			= "PROCESS";
		private const string ROOT_PROCESS_NEW		= "PROCESS_NEW";
		private const string ROOT_PROCESS_PROPERTY	= "PROCESS_PROPERTY";

		private const int SIZE_TABLE				= 100;

		private const int BACKUP_MAINTAIN_DAYS		= 3;
		#endregion

		#region Variables
		RecipeManager m_instanceRecipeManager   = null;
		FileIOManager m_instanceFileIO          = null;
		FileComposite m_instanceFileComposite   = null;
		LogManager m_instanceLog                = null;

		string[] m_arIntToString                = null;

		string m_strLoadedProcessFilePath		= string.Empty;
		string m_strLoadedProcessFileName		= string.Empty;
		string m_strFullFilePath                = string.Empty;

		Dictionary<EN_RECIPE_TYPE, RECIPE_TYPE> m_dicForRecipeType				= new Dictionary<EN_RECIPE_TYPE, RECIPE_TYPE>();
		Dictionary<EN_RECIPE_PARAM_TYPE, RECIPE_PARAM_TYPE> m_dicForParamType	= new Dictionary<EN_RECIPE_PARAM_TYPE, RECIPE_PARAM_TYPE>();

		string[] m_arTypeOfParameter            = null;
		Dictionary<string, RECIPE_PARAM_TYPE> m_mappingEnumForType              = new Dictionary<string, RECIPE_PARAM_TYPE>();
		#endregion

		#region Internal Interface

		#region Table
		/// <summary>
		/// 2020.07.01 by yjlee [ADD] Make the mapping table for this class.
		/// </summary>
		private void MakeMappingTable()
		{
			m_arIntToString = new string[SIZE_TABLE];

			for (int nIndex = 0; nIndex < SIZE_TABLE; ++nIndex)
			{
				m_arIntToString[nIndex] = nIndex.ToString();
			}

			m_dicForRecipeType.Clear();
			m_dicForRecipeType.Add(EN_RECIPE_TYPE.COMMON, RECIPE_TYPE.COMMON);
			m_dicForRecipeType.Add(EN_RECIPE_TYPE.EQUIPMENT, RECIPE_TYPE.EQUIPMENT);

			m_dicForParamType.Clear();
			m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.AUTHORITY, RECIPE_PARAM_TYPE.AUTHORITY);
			m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.MAX, RECIPE_PARAM_TYPE.MAX);
			m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.MIN, RECIPE_PARAM_TYPE.MIN);
			m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.UNIT, RECIPE_PARAM_TYPE.UNIT);
            m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.VALUE, RECIPE_PARAM_TYPE.VALUE);
            m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.DATA_TYPE, RECIPE_PARAM_TYPE.DATA_TYPE);
            m_dicForParamType.Add(EN_RECIPE_PARAM_TYPE.DESCRIPTION, RECIPE_PARAM_TYPE.DESCRIPTION);

			m_arTypeOfParameter = Enum.GetNames(typeof(EN_RECIPE_PARAM_TYPE));

			foreach (string strType in m_arTypeOfParameter)
			{
				RECIPE_PARAM_TYPE enType        = RECIPE_PARAM_TYPE.VALUE;

				if (Enum.TryParse(strType, out enType))
				{
					m_mappingEnumForType.Add(strType, enType);
				}
			}
		}
		#endregion

		#region Load
		/// <summary>
		/// 2020.06.29 by yjlee [ADD] Load the common or equipment recipe file.
		/// </summary>
		private bool LoadRecipe(RECIPE_TYPE enType)
		{
			string strFileName          = string.Empty;
			string strRootName          = string.Empty;
			string strData              = string.Empty;
			string[] arParam            = null;

			switch (enType)
			{
				case RECIPE_TYPE.COMMON:
					strFileName = Define.DefineConstant.FileName.FILENAME_RECIPE_COMMON;
					strRootName = ROOT_COMMON;
					arParam = Enum.GetNames(typeof(PARAM_COMMON));
					break;

				case RECIPE_TYPE.EQUIPMENT:
					strFileName = Define.DefineConstant.FileName.FILENAME_RECIPE_EQUIPMENT;
					strRootName = ROOT_EQUIPMENT;
					arParam = Enum.GetNames(typeof(PARAM_EQUIPMENT));
					break;
			}

			strFileName += Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER;

			string strFullFilePath      = System.IO.Path.Combine(Define.DefineConstant.FilePath.FILEPATH_RECIPE
				, strFileName);

			System.IO.FileInfo fInfo    = new System.IO.FileInfo(strFullFilePath);

			if (fInfo.Exists)
			{
				if (m_instanceFileIO.Read(Define.DefineConstant.FilePath.FILEPATH_RECIPE
				, strFileName
				, ref strData
				, Define.DefineConstant.FileIO.TIMEOUT_READ))
				{
					string[] arData = strData.Split('\n');

					if (m_instanceFileComposite.CreateRootByString(ref arData))
					{
						#region Check the changed parameters
                        AddParameterItem(ref strFileName, ref strRootName, ref arParam);
						#endregion

						return SetParameter(ref enType, ref arParam);
					}
				}
			}
			else
			{
				#region Create a recipe file.
				string[] arData     = null;
				string[] arType     = new string[] { strRootName };

				FileBorn.GetInstance().GetBornFrame(BORN_LIST.RECIPE, ref arType, ref arData);

				if (m_instanceFileComposite.CreateRootByString(ref arData))
				{
                    AddParameterItem(ref strFileName, ref strRootName, ref arParam);
				}
				#endregion
			}

			return false;
		}

        /// <summary>
        /// 2020.07.01 by yjlee [ADD] Load the process recipe file.
        /// 2022.01.17. by shkim. [ADD] Vision Recipe Load 관련 파라미터 추가 (프로그램실행타임)
        /// </summary>
        private bool LoadProcessRecipe(bool bIgnoreFailedToLoadRecipeToVision = false)
        {
            string strFilePath          = string.Empty;
            string[] arGroup            = new string[]{PARAM_COMMON.PROCESS_FILE_PATH.ToString(), m_arIntToString[0]};

            if(false == m_instanceFileComposite.GetValue(ROOT_COMMON
                , ConvertParamEnumToString(RECIPE_PARAM_TYPE.VALUE)
                , ref strFilePath
                , arGroup))
            {
                return false;
            }

            string strFileName          = string.Empty;
            arGroup[0]                  = PARAM_COMMON.PROCESS_FILE_NAME.ToString();

            if (false == m_instanceFileComposite.GetValue(ROOT_COMMON
                , ConvertParamEnumToString(RECIPE_PARAM_TYPE.VALUE)
                , ref strFileName
                , arGroup))
            {
                return false;
            }
            string strErrorMsg = string.Empty;

            return LoadProcessRecipe(ref strFilePath, ref strFileName, ref strErrorMsg, bIgnoreFailedToLoadRecipeToVision);
        }
		/// <summary>
		/// 2021.07.08 by twkang [ADD] Load the process property file
		/// </summary>
		private bool LoadProcessProperty()
		{
			string strData				= string.Empty;
			//string strFilePath			= Define.DefineConstant.FilePath.FILEPATH_RECIPE;
			string strFileName			= Define.DefineConstant.FileName.FILENAME_RECIPE_PROPERTY + Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER;
			string strFullFilePath      = System.IO.Path.Combine(Define.DefineConstant.FilePath.FILEPATH_RECIPE
				, strFileName);

			System.IO.FileInfo fInfo    = new System.IO.FileInfo(strFullFilePath);

			if (fInfo.Exists)
			{
				if (m_instanceFileIO.Read(Define.DefineConstant.FilePath.FILEPATH_RECIPE
				, strFileName
				, ref strData
				, Define.DefineConstant.FileIO.TIMEOUT_READ))
				{
					string[] arData = strData.Split('\n');

					m_instanceFileComposite.RemoveRoot(ROOT_PROCESS_PROPERTY);

					return m_instanceFileComposite.CreateRootByString(ref arData);
				}
			}

			return false;
		}
		/// <summary>
		/// 2020.12.15 by yjlee [ADD] Set the parameter to the recipe.
		/// 2023.05.08. by wdw [MOD] Parameter Index 저장 형식 변경.
		/// </summary>
		private bool SetParameter(ref RECIPE_TYPE enType, ref string[] arParam)
		{
			string strRootName      = enType == RECIPE_TYPE.COMMON ? ROOT_COMMON : ROOT_EQUIPMENT;

			for (int nIndex = 0, nEnd = arParam.Length; nIndex < nEnd; ++nIndex)
			{
				string strParameter     = arParam[nIndex];
				int nCountOfItem        = m_instanceRecipeManager.GetCountOfParameter(ref strParameter);

				string[] arGroup        = new string[] { strParameter, string.Empty };

				for (int nIndexOfParameter = 0; nIndexOfParameter < nCountOfItem; ++nIndexOfParameter)
				{
                    if (nCountOfItem > 1)
                    {
                        string strParameterCount = strParameter.Split('_').Last();
                        arGroup[0] =  strParameter.Remove(strParameter.Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nIndexOfParameter + 1];
                    }

					arGroup[1] = m_arIntToString[0];

					foreach (string strType in m_arTypeOfParameter)
					{
						string strData      = string.Empty;

						if (m_instanceFileComposite.GetValue(strRootName
							, strType
							, ref strData
							, arGroup))
						{
							if (false == m_instanceRecipeManager.SetValue(enType
								, strParameter
                                , nIndexOfParameter
								, m_mappingEnumForType[strType]
								, strData))
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					}
				}
			}

			return true;
		}
		/// <summary>
		/// 2020.10.16 by yjlee [ADD] Set the process parameter value by the composite.
		/// </summary>
		private bool SetProcessParameter()
		{
			string[] arTask             = null;
			int nTotalCountOfParameter  = 0;
			string[] arParameter        = null;
			int[] arCountOfParameter    = null;

			if (m_instanceRecipeManager.GetListOfProcessParameter(ref arTask
				, ref nTotalCountOfParameter
				, ref arParameter
				, ref arCountOfParameter))
			{
				for (int nIndex = 0; nIndex < nTotalCountOfParameter; ++nIndex)
				{
					string strTaskName      = arTask[nIndex];
					string strParameterName = arParameter[nIndex];

					string[] arGroup        = new string[] { strTaskName, strParameterName, string.Empty };

					for (int nIndexOfParameter = 0; nIndexOfParameter < arCountOfParameter[nIndex]; ++nIndexOfParameter)
					{
						

						foreach (var kvp in m_mappingEnumForType)
						{
							string strData      = string.Empty;
							string strRootName	= string.Empty;

							switch (kvp.Value)
							{
								case RECIPE_PARAM_TYPE.VALUE:
									strRootName = ROOT_PROCESS;
                                    if (arCountOfParameter[nIndex] > 1)
                                    {
                                        string strParameterCount = strParameterName.Split('_').Last();
                                        arGroup[1] = strParameterName.Remove(strParameterName.Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nIndexOfParameter + 1];
                                        arGroup[2] = m_arIntToString[0];
                                    }
									break;
								default:
                                     arGroup[1] = strParameterName;
                                     arGroup[2] = m_arIntToString[nIndexOfParameter];
									strRootName = ROOT_PROCESS_PROPERTY;
									break;
							}

							if (m_instanceFileComposite.GetValue(strRootName
								, kvp.Key
								, ref strData
								, arGroup))
							{
								if (false == m_instanceRecipeManager.SetValue(strTaskName
									, strParameterName
									, nIndexOfParameter
									, m_mappingEnumForType[kvp.Key]
									, strData))
								{
									return false;
								}
							}
							else
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}
		#endregion

		#region Parameter
		/// <summary>
		/// 2020.12.15 by yjlee [ADD] Add the parameters to the recipe instance.
		/// </summary>
		private void AddParameterToInstance()
		{
			foreach (PARAM_COMMON enParam in Enum.GetValues(typeof(PARAM_COMMON)))
			{
				m_instanceRecipeManager.AddRecipeItem(RECIPE_TYPE.COMMON, enParam.ToString());
			}

			foreach (PARAM_EQUIPMENT enParam in Enum.GetValues(typeof(PARAM_EQUIPMENT)))
			{
				m_instanceRecipeManager.AddRecipeItem(RECIPE_TYPE.EQUIPMENT, enParam.ToString());
			}
		}
		/// <summary>
		/// 2020.11.26 by yjlee [ADD] Add the parameter item that is no existent in the structure.
		/// 2023.05.08. by wdw [MOD] Parameter Index 저장 형식 변경.
		/// </summary>
		private void AddParameterItem(ref string strFileName, ref string strRootName, ref string[] arParam)
		{
			string[] arType         = new string[] { strRootName };
			string[] arData         = null;
			bool bRewriteFile       = false;

			#region Add the parameters
			for (int nIndex = 0, nEnd = arParam.Length; nIndex < nEnd; ++nIndex)
			{
				string strParameter = arParam[nIndex];

				if (false == m_instanceFileComposite.IsGroupExist(strRootName, strParameter))
				{
					arType[0] = strParameter;

					int nCountOfItem    = m_instanceRecipeManager.GetCountOfParameter(ref strParameter);

					for (int nIndexOfParam = 0, nEndOfIndex = nCountOfItem
						; nIndexOfParam < nEndOfIndex; ++nIndexOfParam)
					{

                        if (nCountOfItem > 1)
                        {
                            string strParameterCount = strParameter.Split('_').Last();
                            strParameter = strParameter.Remove(strParameter.Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nIndexOfParam + 1];
                            arType[0] = strParameter;
                        }

						if (FileBorn.GetInstance().GetItemFrame(BORN_LIST.RECIPE
						, ref arType
						, m_arIntToString[0]
						, ref arData))
						{
							m_instanceFileComposite.CreateGroupAndItemByString(strRootName, ref arData);
						}
					}

					bRewriteFile = true;
				}
			}
			#endregion

			if (bRewriteFile)
			{
				string strData      = string.Empty;

				m_instanceFileComposite.GetStructureAsString(strRootName, ref strData);

				m_instanceFileIO.Write(Define.DefineConstant.FilePath.FILEPATH_RECIPE
                    , strFileName
					, strData
					, false
					, false);
			}
		}
		/// <summary>
		/// 2021.07.08 by twkang [ADD] 
		/// </summary>
		private bool UpdateProcessPropertyItem()
		{
			string[] arTask         = null;
			string[] arParam        = null;
			int[] arCountOfItem     = null;
			int nCountOfParam       = 0;

			bool bRewrite           = false;

			if (m_instanceRecipeManager.GetListOfProcessParameter(ref arTask
				, ref nCountOfParam
				, ref arParam
				, ref arCountOfItem))
			{
				if (false == m_instanceFileComposite.IsGroupExist(ROOT_PROCESS_PROPERTY))
					m_instanceFileComposite.CreateRoot(ROOT_PROCESS_PROPERTY);

				string[] arPreGroup     = new string[2] { string.Empty, string.Empty };

				for (int nIndex = 0, nEnd = arParam.Length; nIndex < nEnd; ++nIndex)
				{
					arPreGroup[0] = arTask[nIndex];
					arPreGroup[1] = arParam[nIndex];

					if (false == m_instanceFileComposite.IsGroupExist(ROOT_PROCESS_PROPERTY, arPreGroup))
					{
						for (int nCount = 0, nCountEnd = arCountOfItem[nIndex]; nCount < nCountEnd; ++nCount)
						{
							string[] arData     = null;

							/// 2021.07.08 by twkang [ADD] Process Property
							if (FileBorn.GetInstance().GetItemFrame(BORN_LIST.RECIPE_PROCESS
							, ref arPreGroup
							, m_arIntToString[nCount]
							, ref arData))
							{
								m_instanceFileComposite.CreateGroupAndItemByString(ROOT_PROCESS_PROPERTY, ref arData);
							}
						}

						bRewrite = true;
					}
				}
			}

			return bRewrite;
		}
		/// <summary>
		/// 2020.11.26 by yjlee [ADD] Add the process parameter item that is no existent in the structure.
		/// 2023.05.08. by wdw [MOD] Parameter Index 저장 형식 변경.
		/// </summary>
		private bool UpdateProcessParameterItem(string strRootName)
		{
			string[] arTask         = null;
			string[] arParam        = null;
			int[] arCountOfItem     = null;
			int nCountOfParam       = 0;

			bool bRewrite           = false;

			if (m_instanceRecipeManager.GetListOfProcessParameter(ref arTask
				, ref nCountOfParam
				, ref arParam
				, ref arCountOfItem))
			{
				string[] arPreGroup     = new string[2] { string.Empty, string.Empty };

				if (false == m_instanceFileComposite.IsGroupExist(strRootName))
					m_instanceFileComposite.CreateRoot(strRootName);

				for (int nIndex = 0, nEnd = arParam.Length; nIndex < nEnd; ++nIndex)
				{
					arPreGroup[0] = arTask[nIndex];
					arPreGroup[1] = arParam[nIndex];

					for (int nCount = 0, nCountEnd = arCountOfItem[nIndex]; nCount < nCountEnd; ++nCount)
					{
                        if (arCountOfItem[nIndex] > 1)
                        {
                            string strParameterCount = arParam[nIndex].Split('_').Last();
                            arPreGroup[1] = arParam[nIndex].Remove(arParam[nIndex].Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nCount + 1];
                        }
					    if (false == m_instanceFileComposite.IsGroupExist(strRootName, arPreGroup))
						{
							string[] arData     = null;

							if (FileBorn.GetInstance().GetItemFrame(BORN_LIST.RECIPE_PROCESS_VALUE
							, ref arPreGroup
							, m_arIntToString[0]
							, ref arData))
							{
								bool bCheck	= m_instanceFileComposite.CreateGroupAndItemByString(strRootName, ref arData);
							}
						}

						bRewrite = true;
					}
				}
			}

			return bRewrite;
		}

		#endregion

		#region Time
		/// <summary>
		/// 2021.01.15 by yjlee [ADD] Get the current time.
		/// </summary>
		private string GetCurrentTime()
		{
			return DateTime.Now.ToString("yyMMdd_HHmmss");
		}
		#endregion

		#region Save
		/// <summary>
		/// 2021.07.12 by twkang [ADD] Save the process recipe
		/// </summary>
		private bool SaveProcessRecipe(string strFilePath, string strRootName, string strFileName)
		{
			string strData			= string.Empty;
			string[] arTaskName		= null;
			int nCountOfParam		= -1;
			string[] arParamList	= null;
			int[] arCountOfItem		= null;

			if (false == BackupProcessRecipe(strFileName, strFilePath))
				return false;

			if (false == m_instanceRecipeManager.GetListOfProcessParameter(ref arTaskName
				, ref nCountOfParam
				, ref arParamList
				, ref arCountOfItem))
				return false;

			string[] arPreGroup     = new string[2] { string.Empty, string.Empty };

			m_instanceFileComposite.RemoveRoot(strRootName);
			m_instanceFileComposite.CreateRoot(strRootName);

			m_instanceFileComposite.RemoveRoot(ROOT_PROCESS_PROPERTY);
			m_instanceFileComposite.CreateRoot(ROOT_PROCESS_PROPERTY);

			for (int nIndex = 0, nEnd = arParamList.Length; nIndex < nEnd; ++nIndex)
			{
				arPreGroup[0] = arTaskName[nIndex];
				arPreGroup[1] = arParamList[nIndex];

				for (int nCount = 0, nCountEnd = arCountOfItem[nIndex]; nCount < nCountEnd; ++nCount)
				{
					string[] arPropertyData     = null;
					string[] arProcessData		= null;

					string[] strGroupLevel	= new string[] { arTaskName[nIndex], arParamList[nIndex], m_arIntToString[nCount] };

                    arPreGroup[1] = arParamList[nIndex];

                    FileBorn.GetInstance().GetItemFrame(BORN_LIST.RECIPE_PROCESS, ref arPreGroup, m_arIntToString[nCount], ref arPropertyData);

                    m_instanceFileComposite.CreateGroupAndItemByString(ROOT_PROCESS_PROPERTY, ref arPropertyData);

				
					foreach (EN_RECIPE_PARAM_TYPE en in Enum.GetValues(typeof(EN_RECIPE_PARAM_TYPE)))
					{
						string strValue = string.Empty;

                        switch (en)
                        {
                            case EN_RECIPE_PARAM_TYPE.VALUE:
                                strValue = m_instanceRecipeManager.GetValue(arTaskName[nIndex], arParamList[nIndex], nCount, m_dicForParamType[en], string.Empty);
                                if (arCountOfItem[nIndex] > 1)
                                {
                                    string strParameterCount = arParamList[nIndex].Split('_').Last();
                                    string strParaName = arParamList[nIndex].Remove(arParamList[nIndex].Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nCount + 1];

                                    arPreGroup[1] = strParaName;

                                    strGroupLevel[1] = strParaName;
                                    strGroupLevel[2] = m_arIntToString[0];
                                }
                                FileBorn.GetInstance().GetItemFrame(BORN_LIST.RECIPE_PROCESS_VALUE, ref arPreGroup, m_arIntToString[0], ref arProcessData);

                                m_instanceFileComposite.CreateGroupAndItemByString(strRootName, ref arProcessData);

                                m_instanceFileComposite.SetValue(strRootName, en.ToString(), strValue, strGroupLevel);
                                break;
                            default:
                                strGroupLevel[1] = arParamList[nIndex];
                                strGroupLevel[2] = m_arIntToString[nCount];

                                strValue = m_instanceRecipeManager.GetValue(arTaskName[nIndex], arParamList[nIndex], nCount, m_dicForParamType[en], string.Empty);
                               
                                m_instanceFileComposite.SetValue(ROOT_PROCESS_PROPERTY, en.ToString(), strValue, strGroupLevel);
                                break;
                        }
					}

				}
			}

			m_instanceFileComposite.GetStructureAsString(ROOT_PROCESS_PROPERTY, ref strData);

			bool bResult	= m_instanceFileIO.Write(Define.DefineConstant.FilePath.FILEPATH_RECIPE
								, Define.DefineConstant.FileName.FILENAME_RECIPE_PROPERTY + Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER
								, strData
								, false
								, false);

			m_instanceFileComposite.GetStructureAsString(strRootName, ref strData);

			bResult = m_instanceFileIO.Write(strFilePath
								, strFileName
								, strData
								, false
								, false);

			return bResult;
		}
		/// <summary>
		/// 2021.07.12 by twkang [ADD] 
		/// </summary>
		private bool BackupProcessRecipe(string strFileName, string strFilePath)
		{
			string strCurruntTime		= GetCurrentTime();
			string strBackUpPath		= Path.Combine(Define.DefineConstant.FilePath.FILEPATH_RECIPE, "BACKUP");

			//DirectoryInfo dirInfor	= new DirectoryInfo(strFilePath);

			if (false == Directory.Exists(strFilePath))
				return false;

			DirectoryInfo dirInfor	= new DirectoryInfo(strBackUpPath);
			FileInfo pCopyedFile	= null;

			#region Action before FileBackup
			// 해당 경로의 폴더가 존재하지 않을 경우
			if (false == dirInfor.Exists)
			{
				dirInfor.Create();
			}
			else
			{
				// 폴더가 존재하면 백업파일 정리
				var pTime	= DateTime.Now.AddDays(-BACKUP_MAINTAIN_DAYS);

				// 파일 날짜 체크
				foreach (var fInfo in dirInfor.GetFiles())
				{
					if (fInfo.LastWriteTime < pTime)
						fInfo.Delete();
				}
			}
			#endregion

			#region ProcessValue
			string strRecipeSource      = Path.Combine(strFilePath, strFileName);
			string strDestFileName		= strCurruntTime + strFileName;
			string strRecipeDest        = Path.Combine(strBackUpPath, strDestFileName);

			if (File.Exists(strRecipeSource))
			{
				File.Copy(strRecipeSource, strRecipeDest);

				pCopyedFile = new FileInfo(strRecipeDest);
				pCopyedFile.LastWriteTime = DateTime.Now;
			}

			#endregion

			#region ProcessProperty
			string strPropertyFileName	= Define.DefineConstant.FileName.FILENAME_RECIPE_PROPERTY + Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER;
			strRecipeSource = Path.Combine(Define.DefineConstant.FilePath.FILEPATH_RECIPE, strPropertyFileName);
			strDestFileName = strCurruntTime + strPropertyFileName;
			strRecipeDest = Path.Combine(strBackUpPath, strDestFileName);

			if (File.Exists(strRecipeSource))
			{
				File.Copy(strRecipeSource, strRecipeDest);
				pCopyedFile = new FileInfo(strRecipeDest);
				pCopyedFile.LastWriteTime = DateTime.Now;
			}
			#endregion

			return true;
		}
		#endregion

		#region Convert
		/// <summary>
		/// 2020.07.01 by yjlee [ADD] Convert the type of the parameter to the string.
		/// </summary>
		private string ConvertParamEnumToString(RECIPE_PARAM_TYPE enType)
		{
			switch (enType)
			{
				case RECIPE_PARAM_TYPE.MIN:
					return "MIN";

				case RECIPE_PARAM_TYPE.MAX:
					return "MAX";

				case RECIPE_PARAM_TYPE.AUTHORITY:
					return "AUTHORITY";

				case RECIPE_PARAM_TYPE.UNIT:
					return "UNIT";

				default:        // VALUE
					return "VALUE";
			}
		}
		#endregion

		#endregion

		#region External Interface

		#region Initialize & Exit
		/// <summary>
		/// 2020.06.29 by yjlee [ADD] Initialize the class for loading and using the recipe parameters.
		/// </summary>
		public bool Init()
		{
			m_instanceRecipeManager = RecipeManager.GetInstance();
			m_instanceFileIO = FileIOManager.GetInstance();
			m_instanceFileComposite = FileComposite.GetInstance();
			m_instanceLog = LogManager.GetInstance();

			MakeMappingTable();

			AddParameterToInstance();

			bool bLoadCommonRecipe      = LoadRecipe(RECIPE_TYPE.COMMON);
			bool bLoadEquipmentRecipe   = LoadRecipe(RECIPE_TYPE.EQUIPMENT);
			bool bLoadPropertyRecipe	= LoadProcessProperty();
            // 2022.01.17. [MOD] 프로그램 초기 실행 중에는 비전 프로그램이 실행안되어있을 수도 있으니, 비전 레시피 로드 결과를 무시한다.
            bool bLoadProcessRecipe = bLoadCommonRecipe && LoadProcessRecipe(true);
            // bool bLoadProcessRecipe     = bLoadCommonRecipe && LoadProcessRecipe();

			return bLoadCommonRecipe && bLoadEquipmentRecipe && bLoadProcessRecipe;
		}
		#endregion

        #region Load
        /// <summary>
        /// 2020.06.29 by yjlee [ADD] Load the process recipe file.
        /// 2022.01.17. by shkim. [ADD] Vision Recipe Load 관련 파라미터 추가 (프로그램실행타임)
        /// </summary>
        public bool LoadProcessRecipe(ref string strFilePath, ref string strFileName, ref string strErrorMsg, bool bIgnoreFailedToLoadRecipeToVision = false)
        {
            strErrorMsg = "";

            if(string.IsNullOrEmpty(strFilePath)
                || string.IsNullOrEmpty(strFileName))
            {
                return false;
            }

			string strData          = string.Empty;

			if (m_instanceFileIO.Read(strFilePath, strFileName, ref strData, Define.DefineConstant.FileIO.TIMEOUT_READ))
			{
				m_instanceFileComposite.RemoveRoot(ROOT_PROCESS);

				string[] arData     = strData.Split('\n');

				if (m_instanceFileComposite.CreateRootByString(ref arData))
				{
					#region Set the file path of the process parameter
					string[] arGroup            = new string[] { PARAM_COMMON.PROCESS_FILE_PATH.ToString(), m_arIntToString[0] };

					if (false == m_instanceFileComposite.SetValue(ROOT_COMMON, ConvertParamEnumToString(RECIPE_PARAM_TYPE.VALUE)
						, strFilePath
						, arGroup)
						|| false == m_instanceRecipeManager.SetValue(RECIPE_TYPE.COMMON, arGroup[0], 0, RECIPE_PARAM_TYPE.VALUE, strFilePath))
					{
						return false;
					}

					arGroup[0] = PARAM_COMMON.PROCESS_FILE_NAME.ToString();

					if (false == m_instanceFileComposite.SetValue(ROOT_COMMON, ConvertParamEnumToString(RECIPE_PARAM_TYPE.VALUE)
						, strFileName
						, arGroup)
						|| false == m_instanceRecipeManager.SetValue(RECIPE_TYPE.COMMON, arGroup[0], 0, RECIPE_PARAM_TYPE.VALUE, strFileName))
					{
						return false;
					}
					#endregion

					if (m_instanceFileComposite.GetStructureAsString(ROOT_COMMON, ref strData)
						&& m_instanceFileIO.Write(Define.DefineConstant.FilePath.FILEPATH_RECIPE
							, Define.DefineConstant.FileName.FILENAME_RECIPE_COMMON + Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER
							, strData
							, false
							, false))
					{
						m_strLoadedProcessFileName = strFileName;
						m_strLoadedProcessFilePath = strFilePath;

						m_strFullFilePath = System.IO.Path.Combine(m_strLoadedProcessFilePath, m_strLoadedProcessFileName);

						if (UpdateProcessParameterItem(ROOT_PROCESS))
						{
							m_instanceFileComposite.GetStructureAsString(ROOT_PROCESS, ref strData);
							m_instanceFileIO.Write(strFilePath, strFileName, strData, false, false);
						}

						if (UpdateProcessPropertyItem())
						{
							/// 2021.07.08 by twkang [ADD] Property Parameter Save
							m_instanceFileComposite.GetStructureAsString(ROOT_PROCESS_PROPERTY, ref strData);
							m_instanceFileIO.Write(Define.DefineConstant.FilePath.FILEPATH_RECIPE
								, Define.DefineConstant.FileName.FILENAME_RECIPE_PROPERTY + Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER
								, strData
								, false
								, false);
						}
                        if (SetProcessParameter())
                        {
							//return bIgnoreFailedToLoadRecipeToVision;
							// 2022.11.03. by shkim. [CHECKS] 레시피를 로드할 때 비전레시피도 함께 로드하도록 하는 것인데,
							// 이를 위해선 현재 Vision.dll에 연결 상태 관련 인터페이스와 설비 파라미터가 추가로 필요하다.
							// -> vision time out으로 처리하도록 한다 by junho

							//bool bUseVision = GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.Use_Vision.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);
							bool bUseVision = false;
							if (false == bUseVision) return true;

							string recipeName = GetValue(EN_RECIPE_TYPE.COMMON, PARAM_COMMON.PROCESS_FILE_NAME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, "RECIPE");
							if (string.IsNullOrEmpty(recipeName)) return false;
							string reicpeNameWithoutExtenstion = System.IO.Path.GetFileNameWithoutExtension(recipeName);
							if (string.IsNullOrEmpty(reicpeNameWithoutExtenstion)) return false;


							Vision_.Vision vision = Vision_.Vision.GetInstance();
							Vision_.VISION_RESULT result;
							vision.ResetVision();

							while (true)
							{
								result = vision.LoadRecipe(reicpeNameWithoutExtenstion);
								if (result != Vision_.VISION_RESULT.IN_PROCESS)
								{
									break;
								}
								System.Threading.Thread.Sleep(1);
							}

							if (result == Vision_.VISION_RESULT.TIMEOUT_VISION)
							{
								strErrorMsg = "Vision Program 통신 시간 초과";
								return bIgnoreFailedToLoadRecipeToVision;
							}
							else if (result != Vision_.VISION_RESULT.COMPLETE)
							{
								strErrorMsg = "Vision Program Recipe 불러오기 실패";
								return bIgnoreFailedToLoadRecipeToVision;
							}
							return true;
                        }
                        else
                        {
                            return bIgnoreFailedToLoadRecipeToVision;
                        }
					}
				}
			}

			return false;
		}
		#endregion

		#region Save
		/// <summary>
		/// 2021.07.12 by twkang [ADD] Save the process recipe
		/// </summary>
		public void SaveProcessRecipe()
		{
			SaveProcessRecipe(m_strLoadedProcessFilePath, ROOT_PROCESS, m_strLoadedProcessFileName);
		}
		#endregion

		#region File Management
		/// <summary>
		/// 2020.06.29 by yjlee [ADD] Make the process recipe file.
		/// </summary>
		public bool MakeProcessRecipeFile(ref string strFilePath, ref string strFileName)
		{
			string[] arData     = null;
			string[] arType     = new string[] { ROOT_PROCESS_NEW };
			bool bReturnValue   = false;

			FileBorn.GetInstance().GetBornFrame(BORN_LIST.RECIPE_PROCESS_VALUE
				, ref arType
				, ref arData);

			if (m_instanceFileComposite.CreateRootByString(ref arData))
			{
				if (UpdateProcessParameterItem(ROOT_PROCESS_NEW))
				{
					string strData      = string.Empty;

					if (m_instanceFileComposite.GetStructureAsString(ROOT_PROCESS_NEW, ref strData)
						&& m_instanceFileIO.Write(strFilePath
							, strFileName
							, strData.Replace(TOKEN_GROUP + ROOT_PROCESS_NEW, TOKEN_GROUP + ROOT_PROCESS)
							, false
							, false))
					{
						bReturnValue = true;
					}
				}
			}

			m_instanceFileComposite.RemoveRoot(ROOT_PROCESS_NEW);

			return bReturnValue;
		}
		#endregion

		#region Get Information

		#region Common & Equipment
		/// <summary>
		/// 2020.07.03 by yjlee [ADD] Get the information of the loaded process recipe.
		/// </summary>
		public bool GetProcessFileInformation(ref string strFilePath, ref string strFileName)
		{
			if (string.IsNullOrEmpty(m_strLoadedProcessFilePath)
				|| string.IsNullOrEmpty(m_strLoadedProcessFileName)) { return false; }

			strFilePath = m_strLoadedProcessFilePath;
			strFileName = m_strLoadedProcessFileName;

			return true;
		}

		/// <summary>
		/// 2021.08.25 by twkang [ADD] Get the filename of loaded process recipe without extention
		/// </summary>
		public bool GetProcessFileNameWithoutExtension(ref string strProcessFileName)
		{
			if (string.IsNullOrEmpty(m_strLoadedProcessFileName)) { return false; }

			strProcessFileName = Path.GetFileNameWithoutExtension(m_strLoadedProcessFileName);

			return true;
		}

		/// <summary>
		/// 2020.08.28 by twkang [ADD] 레피시 파라미터의 값을 반환한다.
		/// </summary>
		public bool GetValue(EN_RECIPE_TYPE enType, string strName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, bool bDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(m_dicForRecipeType[enType], strName, nIndexOfItem, m_dicForParamType[enParam], bDefaultValue);
		}
		/// <summary>
		/// 2020.08.28 by twkang [ADD] 레피시 파라미터의 값을 반환한다.
		/// </summary>
		public int GetValue(EN_RECIPE_TYPE enType, string strName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, int nDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(m_dicForRecipeType[enType], strName, nIndexOfItem, m_dicForParamType[enParam], nDefaultValue);
		}
		/// <summary>
		/// 2020.08.28 by twkang [ADD] 레피시 파라미터의 값을 반환한다.
		/// </summary>
		public string GetValue(EN_RECIPE_TYPE enType, string strName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, string strDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(m_dicForRecipeType[enType], strName, nIndexOfItem, m_dicForParamType[enParam], strDefaultValue);
		}
		/// <summary>
		/// 2020.08.28 by twkang [ADD] 레피시 파라미터의 값을 반환한다.
		/// </summary>
		public double GetValue(EN_RECIPE_TYPE enType, string strName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, double dblDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(m_dicForRecipeType[enType], strName, nIndexOfItem, m_dicForParamType[enParam], dblDefaultValue);
		}
		#endregion

		#region Process
		/// <summary>
		/// 2020.10.16 by yjlee [ADD] Get the value of the process recipe.
		/// </summary>
		public bool GetValue(string strTaskName, string strParameterName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, bool bDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(strTaskName, strParameterName, nIndexOfItem, m_dicForParamType[enParam], bDefaultValue);
		}
		/// <summary>
		/// 2020.10.16 by yjlee [ADD] Get the value of the process recipe.
		/// </summary>
		public int GetValue(string strTaskName, string strParameterName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, int nDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(strTaskName, strParameterName, nIndexOfItem, m_dicForParamType[enParam], nDefaultValue);
		}
		/// <summary>
		/// 2020.10.16 by yjlee [ADD] Get the value of the process recipe.
		/// </summary>
		public string GetValue(string strTaskName, string strParameterName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, string strDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(strTaskName, strParameterName, nIndexOfItem, m_dicForParamType[enParam], strDefaultValue);
		}
		/// <summary>
		/// 2020.10.16 by yjlee [ADD] Get the value of the process recipe.
		/// </summary>
		public double GetValue(string strTaskName, string strParameterName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, double dblDefaultValue)
		{
			return m_instanceRecipeManager.GetValue(strTaskName, strParameterName, nIndexOfItem, m_dicForParamType[enParam], dblDefaultValue);
		}
		/// <summary>
		/// 2021.03.16 by twkang [ADD] Get the list of process parameter
		/// </summary>
		public bool GetListOfProcessParameter(ref string[] arTaskName, ref int nCountOfParam, ref string[] arParamList, ref int[] arCountOfItem)
		{
			return m_instanceRecipeManager.GetListOfProcessParameter(ref arTaskName, ref nCountOfParam, ref arParamList, ref arCountOfItem);
		}
		/// <summary>
		/// 2021.03.16 by twkang [ADD] Get the value of all process parameter
		/// </summary>
		public void GetProcessValueAll(string strTaskName, int nCountOfParam, ref string[] arParamList, ref int[] arCountOfItem, ref string[][] arValue)
		{
			m_instanceRecipeManager.GetProcessValueAll(strTaskName, nCountOfParam, ref arParamList, ref arCountOfItem, ref arValue);
		}
		#endregion

		#endregion

		#region Set Information
		/// <summary>
		/// 2020.08.27 by twkang [ADD] 레시피 파라미터의 값을 설정한다.
		/// 2020.12.16 by yjlee [ADD] Bug fixed about the file path to save it.
		/// 2021.01.18 by yjlee [ADD] Add the configuration log.
		/// 2022.05.01 by junho [ADD] Add the Write Log option
		/// 2023.05.08. by wdw [MOD] Parameter Index 저장 형식 변경.
		/// </summary>
		public bool SetValue(EN_RECIPE_TYPE enType, string strName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, string strValue, bool isWriteLog = true)
		{
			string[] arGroup			= new string[] { strName, m_arIntToString[0] };
            int nParameterCount = m_instanceRecipeManager.GetCountOfParameter(ref strName);
            string strIndexParameterName = strName;
            if (nParameterCount > 1)
            {
                string strParameterCount = strName.Split('_').Last();
                strIndexParameterName = strName.Remove(strName.Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nIndexOfItem + 1];
                arGroup = new string[] { strIndexParameterName, m_arIntToString[0] };
            }

			string strData				= string.Empty;
			string strFileName          = string.Empty;
			string strType              = enType.ToString();
			string strParam             = enParam.ToString();
			string strPreviousData		= string.Empty;

			// 2021.05.31 by twkang [ADD] Log 작성을 위해 추가
			m_instanceFileComposite.GetValue(strType, strParam, ref strPreviousData, arGroup);

			if (m_instanceFileComposite.SetValue(strType, strParam, strValue, arGroup))
			{
				if (m_dicForRecipeType.ContainsKey(enType)
					&& m_dicForParamType.ContainsKey(enParam))
				{
					switch (enType)
					{
						case EN_RECIPE_TYPE.COMMON:
							strFileName = Define.DefineConstant.FileName.FILENAME_RECIPE_COMMON;
							break;

						case EN_RECIPE_TYPE.EQUIPMENT:
							strFileName = Define.DefineConstant.FileName.FILENAME_RECIPE_EQUIPMENT;
							break;
					}

					strFileName += Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER;

					if (m_instanceFileComposite.GetStructureAsString(enType.ToString(), ref strData)
						&& m_instanceFileIO.Write(Define.DefineConstant.FilePath.FILEPATH_RECIPE
						, strFileName
						, strData
						, false
						, false)
						&& m_instanceRecipeManager.SetValue(m_dicForRecipeType[enType], strName, nIndexOfItem, m_dicForParamType[enParam], strValue))
					{
						string strFullFilePath      = System.IO.Path.Combine(Define.DefineConstant.FilePath.FILEPATH_RECIPE, strFileName);

						if (isWriteLog)
						{
							// 2021.01.18 by yjlee [ADD] Write the configuration log.
							// 2021.05.31 by twkang [MOD] Setting Log 에서 Change 로 변경
							m_instanceLog.WriteConfigurationLog(ref strType, EN_CFG_TYPE.CHANGE, strIndexParameterName, strPreviousData, strValue);
							m_instanceLog.WriteConfigurationLog(ref strType, EN_CFG_TYPE.SAVE, string.Empty, string.Empty, strFullFilePath);
						}
						return true;
					}
				}
			}

			return false;
		}
		/// <summary>
		/// 2020.10.16 by yjlee [ADD] Set the value of the process recipe.
		/// 2021.01.18 by yjlee [ADD] Add to write the log.
		/// 2023.05.08. by wdw [MOD] Parameter Index 저장 형식 변경.
		/// </summary>
		public bool SetValue(string strTaskName, string strParameterName, int nIndexOfItem, EN_RECIPE_PARAM_TYPE enParam, string strValue)
		{
            if (nIndexOfItem < 0)
                nIndexOfItem = 0;

            string[] arGroup = new string[] { strTaskName, strParameterName, m_arIntToString[nIndexOfItem] };
            string strIndexParameterName = strParameterName;
            int nParameterCount = m_instanceRecipeManager.GetCountOfParameter(ref strParameterName);
            if (nParameterCount > 1
                && enParam == EN_RECIPE_PARAM_TYPE.VALUE)
            {
                string strParameterCount = strParameterName.Split('_').Last();
                strIndexParameterName = strParameterName.Remove(strParameterName.Length - strParameterCount.Length, strParameterCount.Length) + m_arIntToString[nIndexOfItem + 1];
                arGroup = new string[] { strTaskName, strIndexParameterName, m_arIntToString[0] };
            }
         
			string strPreviousData  = string.Empty;
			string strItemName      = enParam.ToString();
			string strRootName		= string.Empty;
			string strFilePath		= string.Empty;
			string strFileName		= string.Empty;
			string strFullFilePath	= string.Empty;

			switch (enParam)
			{
				case EN_RECIPE_PARAM_TYPE.VALUE:
					strRootName = ROOT_PROCESS;
					strFilePath = m_strLoadedProcessFilePath;
					strFileName = m_strLoadedProcessFileName;
					break;
				default:
					strRootName = ROOT_PROCESS_PROPERTY;
					strFilePath = Define.DefineConstant.FilePath.FILEPATH_RECIPE;
					strFileName = Define.DefineConstant.FileName.FILENAME_RECIPE_PROPERTY + Define.DefineConstant.FileFormat.FILEFORMAT_PARAMETER;
					break;
			}

			strFullFilePath = System.IO.Path.Combine(strFilePath, strFileName);

			if (m_instanceFileComposite.GetValue(strRootName, strItemName, ref strPreviousData, arGroup))
			{
				if (m_instanceFileComposite.SetValue(strRootName, strItemName, strValue, arGroup))
				{
					string strData          = string.Empty;

					if (m_instanceFileComposite.GetStructureAsString(strRootName, ref strData)
							&& m_instanceFileIO.Write(strFilePath
							, strFileName
							, strData
							, false
							, false)
							&& m_instanceRecipeManager.SetValue(strTaskName, strParameterName, nIndexOfItem, m_dicForParamType[enParam], strValue))
					{
						// 2021.12.03 by junho [MOD] improve code
						// 2021.01.18 by yjlee [ADD] Write the configuration log.
						//m_instanceLog.WriteConfigurationLog(ref strTaskName, EN_CFG_TYPE.CHANGE, strItemName, strPreviousData, strValue);
                        m_instanceLog.WriteConfigurationLog(ref strTaskName, EN_CFG_TYPE.CHANGE, strIndexParameterName, strPreviousData, strValue);
						m_instanceLog.WriteConfigurationLog(ref strTaskName, EN_CFG_TYPE.SAVE, string.Empty, string.Empty, strFullFilePath);

						return true;
					}
				}
			}

			return false;
		}
		#endregion

		#endregion
	}
}
