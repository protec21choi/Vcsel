using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

using FrameOfSystem3.Recipe;
using FrameOfSystem3;

namespace FrameOfSystem3.Functional
{
    class FunctionsETC
	{
		#region <CALCULATE>
		/// <summary>
        /// 2019.11.21 by junho [ADD] Target 값이 Min/Max Area 안에 들어와 있는지 여부 반환
        /// (Min, Max 포함)
        /// </summary>
		public static bool IsInRangeMinMax(double target, double min, double max, bool isInclusion = true)
		{
			double realMin = Math.Min(min, max), realMax = Math.Max(min, max);

			if (isInclusion)
			{
				if (realMin <= target && target <= realMax) return true;
			}
			else
			{
				if (realMin < target && target < realMax) return true;
			}
			return false;
		}
		/// <summary>
		/// 2019.11.21 by junho [ADD] Target 값이 Min/Max Area 안에 들어와 있는지 여부 반환
		/// (Min, Max 포함)
		/// </summary>
		public static bool IsInRangeMinMax(int target, int min, int max, bool bMinInclusion = true, bool bMaxInclusion = true)
		{
			int realMin = Math.Min(min, max), realMax = Math.Max(min, max);
			if (realMin <= target && target <= realMax) return true;

			return false;
		}
		/// <summary>
		/// 2022.06.29 by junho [ADD] +- 범위의 공차로 min, max 만들어서 IsInRangeMinMax 반환
		/// </summary>
		public static bool IsInTolerance(double target, double threshold, double tolerance)
		{
			double min = threshold + Math.Abs(tolerance) * -1;
			double max = threshold + Math.Abs(tolerance);

			return IsInRangeMinMax(target, min, max);
		}
        /// <summary>
        /// Range A와 Range B의 겹침 여부 반환
        /// </summary>
        public static bool IsCrossRange(DPointXY ptRangeA, DPointXY ptRangeB)
        {
            double AMax = Math.Max(ptRangeA.x, ptRangeA.y);
			double AMin = Math.Min(ptRangeA.x, ptRangeA.y);
			double BMax = Math.Max(ptRangeB.x, ptRangeB.y);
			double BMin = Math.Min(ptRangeB.x, ptRangeB.y);

            if (AMax < BMin && AMax < BMax) return false;                   // A-----A B-----B
            if (AMin > BMin && AMin > BMax) return false;                   // B-----B A-----A

            return true;
        }
		/// <summary>
		/// Line A와 Line B의 겹침 여부 반환
		/// </summary>
		public static bool IsCrossLine(double startLineA, double endLineA, double startLineB, double endLineB, bool isInclusion = true)
		{
			double AMax = Math.Max(startLineA, endLineA);
			double AMin = Math.Min(startLineA, endLineA);
			double BMax = Math.Max(startLineB, endLineB);
			double BMin = Math.Min(startLineB, endLineB);

			if (isInclusion)
			{
				if (AMax < BMin && AMax < BMax) return false;                   // A-----A B-----B
				if (AMin > BMin && AMin > BMax) return false;                   // B-----B A-----A
			}
			else
			{
				if (AMax <= BMin && AMax <= BMax) return false;                   // A-----A B-----B
				if (AMin >= BMin && AMin >= BMax) return false;                   // B-----B A-----A
			}
			return true;
		}
		/// <summary>
		/// Vactor와 Area의 겹침 여부 반환
		/// </summary>
		public static bool IsRouteInArea(DPointXY vactorStart, DPointXY vactorEnd, DRectangle area, bool isInclusion = true)
		{
			bool isCrossX = IsCrossLine(vactorStart.x, vactorEnd.x, area.left, area.right, isInclusion);
			bool isCrossY = IsCrossLine(vactorStart.y, vactorEnd.y, area.top, area.bottom, isInclusion);

			return isCrossX && isCrossY;
		}
		/// <summary>
		/// Target Point가 threshold Area안에 들어있는지 여부 반환
		/// </summary>
		public static bool IsInRangeArea(DPointXY target, DRectangle area, bool isInclusion = true)
		{
			bool resultX = IsInRangeMinMax(target.x, area.left, area.right, isInclusion);
			bool resultY = IsInRangeMinMax(target.y, area.top, area.bottom, isInclusion);

			return resultX && resultY;
		}

        /// <summary>
        /// Dictionary를 정렬하여 반환한다.
		/// Key 오름차순 정렬
        /// </summary>
		public static ConcurrentDictionary<T, T> SortingDictionaryKey<T>(ConcurrentDictionary<T, T> dicTarget)
        {
            ConcurrentDictionary<T, T> dicBuffer = new ConcurrentDictionary<T, T>();
            List<T> listKey = dicTarget.Keys.ToList();
            foreach (KeyValuePair<T, T> kvp in dicTarget)
            {
                dicBuffer.TryAdd(kvp.Key, kvp.Value);
            }
            listKey.Sort();

            dicTarget.Clear();
            foreach (T nKey in listKey)
            {
                dicTarget.TryAdd(nKey, dicBuffer[nKey]);
            }
            return dicTarget;
        }
		/// <summary>
		/// Dictionary를 정렬하여 반환한다.
		/// Key 오름차순 정렬
		/// </summary>
		public static Dictionary<T, T> SortingDictionaryKey<T>(Dictionary<T, T> dicTarget)
		{
			Dictionary<T, T> dicBuffer = new Dictionary<T, T>();
			List<T> listKey = dicTarget.Keys.ToList();
			foreach (KeyValuePair<T, T> kvp in dicTarget)
			{
				dicBuffer.Add(kvp.Key, kvp.Value);
			}
			listKey.Sort();

			dicTarget.Clear();
			foreach (T nKey in listKey)
			{
				dicTarget.Add(nKey, dicBuffer[nKey]);
			}
			return dicTarget;
		}
		/// <summary>
		/// Dictionary를 정렬하여 반환한다.
		/// Value 오름차순 정렬
		/// </summary>
		public static ConcurrentDictionary<T, T> SortingDictionaryValue<T>(ConcurrentDictionary<T, T> dicTarget)
		{
			ConcurrentDictionary<T, T> dicBuffer = new ConcurrentDictionary<T, T>();
			List<T> listValue = dicTarget.Values.ToList();
			foreach (KeyValuePair<T, T> kvp in dicTarget)
			{
				dicBuffer.TryAdd(kvp.Value, kvp.Key);
			}
			listValue.Sort();

			dicTarget.Clear();
			foreach (T nValue in listValue)
			{
				dicTarget.TryAdd(dicBuffer[nValue], nValue);
			}
			return dicTarget;
		}
		/// <summary>
		/// Dictionary를 정렬하여 반환한다.
		/// Value 오름차순 정렬
		/// </summary>
		public static Dictionary<T, T> SortingDictionaryValue<T>(Dictionary<T, T> dicTarget)
		{
			Dictionary<T, T> dicBuffer = new Dictionary<T, T>();
			List<T> listValue = dicTarget.Values.ToList();
			foreach (KeyValuePair<T, T> kvp in dicTarget)
			{
				dicBuffer.Add(kvp.Value, kvp.Key);
			}
			listValue.Sort();

			dicTarget.Clear();
			foreach (T nValue in listValue)
			{
				dicTarget.Add(dicBuffer[nValue], nValue);
			}
			return dicTarget;
		}
        /// <summary>
        /// 2020.06.24 by junho [ADD]
        /// 두 Double의 중앙값을 반환한다.
        /// 내부에서 High Low 구분함
        /// </summary>
        public static double GetMedianDtoD(double dValue1, double dValue2, bool bABS = false)
        {
            double dHigh, dLow, dResult;
            if(dValue1 == dValue2) return dValue1;
            if(dValue1 > dValue2)
            {
                dHigh = dValue1;
                dLow = dValue2;
            }
            else
            {
                dHigh = dValue2;
                dLow = dValue1;
            }

            if (dHigh >= 0 && dLow >= 0)
            {
                dResult = (dHigh - dLow) / 2;
            }
            else if (dHigh >= 0 && dLow < 0)
            {
                dResult = (dHigh + dLow) / 2;
            }
            else if (dHigh <= 0 && dLow < 0)
            {
                dResult = (dLow - dHigh) / 2;
            }
            else
            {
                dResult = 0.0;
            }

            if (bABS) dResult = Math.Abs(dResult);

            return dResult;
        }
		/// <summary>
		/// 2021.03.27 by junho [ADD]
		/// 비례식을 계산한다.
		/// A : B = C : D
		/// </summary>
		public static double GetProportionalExpression(double dA, double dB, double dC, double dD, int nUnkownPosition)
		{
			switch(nUnkownPosition)
			{
				case 1:	// x : B = C : D
					if (dD == 0) return 0;
					return (dB * dC) / dD;
				case 2: // A : x = C : D	
					if (dC == 0) return 0;
					return (dA * dD) / dC;
				case 3:	// A : B = x : D
					if (dB == 0) return 0;
					return (dA * dD) / dB;
				case 4: // A : B = C : x
					if (dA == 0) return 0;
					return (dB * dC) / dA;
				default: return 0;
			}
		}
		/// <summary>
		/// 2021.03.27 by junho [ADD]
		/// 비례식을 계산한다.
		/// A : B = C : D
		/// </summary>
		public static int GetProportionalExpression(int nA, int nB, int nC, int nD, int nUnkownPosition)
		{
			switch (nUnkownPosition)
			{
				case 1:	// x : B = C : D
					if (nD == 0) return 0;
					return (nB * nC) / nD;
				case 2: // A : x = C : D	
					if (nC == 0) return 0;
					return (nA * nD) / nC;
				case 3:	// A : B = x : D
					if (nB == 0) return 0;
					return (nA * nD) / nB;
				case 4: // A : B = C : x
					if (nA == 0) return 0;
					return (nB * nC) / nA;
				default: return 0;
			}
		}

		public static string GetStringFromPoint(DPointXY point, int round = 3)
		{
			point.x = Math.Round(point.x, round);
			point.y = Math.Round(point.y, round);
			return string.Format("{0},{1}", point.x, point.y);
		}
		public static DPointXY GetPointXyFromString(string sPoint)
		{
			DPointXY dpReturn = new DPointXY(0,0);

			string[] tempSplit = sPoint.Split(',');

			if (false == tempSplit.Length.Equals(2) && false == tempSplit.Length.Equals(3)) return dpReturn;
			if (false == double.TryParse(tempSplit[0], out dpReturn.x)) return dpReturn;
			if (false == double.TryParse(tempSplit[1], out dpReturn.y)) return dpReturn;

			dpReturn.x = Math.Round(dpReturn.x, 3);
			dpReturn.y = Math.Round(dpReturn.y, 3);
			return dpReturn;
		}
		public static string GetStringFromPoint(DPointXYT point)
		{
			point.x = Math.Round(point.x, 3);
			point.y = Math.Round(point.y, 3);
			point.t = Math.Round(point.t, 3);
			return string.Format("{0},{1},{2}", point.x, point.y, point.t);
		}
		public static DPointXYT GetPointXytFromString(string sPoint)
		{
			DPointXYT dpReturn = new DPointXYT(0, 0, 0);

			string[] tempSplit = sPoint.Split(',');

			if (tempSplit.Length.Equals(2))
			{
				if (false == double.TryParse(tempSplit[0], out dpReturn.x)) return dpReturn;
				if (false == double.TryParse(tempSplit[1], out dpReturn.y)) return dpReturn;
				dpReturn.y = 0.0;
			}
			else if (tempSplit.Length.Equals(3))
			{
				if (false == double.TryParse(tempSplit[0], out dpReturn.x)) return dpReturn;
				if (false == double.TryParse(tempSplit[1], out dpReturn.y)) return dpReturn;
				if (false == double.TryParse(tempSplit[2], out dpReturn.t)) return dpReturn;
			}
			else
				return dpReturn;

			dpReturn.x = Math.Round(dpReturn.x, 3);
			dpReturn.y = Math.Round(dpReturn.y, 3);
			dpReturn.t = Math.Round(dpReturn.t, 3);
			return dpReturn;
		}

		public static string GetStringFromPoint(IPointXY point)
		{
			return string.Format("{0},{1}", point.x, point.y);
		}
		public static IPointXY GetIPointXyFromString(string sPoint)
		{
			IPointXY ipReturn = new IPointXY(0, 0);

			string[] tempSplit = sPoint.Split(',');

			if (false == tempSplit.Length.Equals(2) && false == tempSplit.Length.Equals(3)) return ipReturn;
			if (false == int.TryParse(tempSplit[0], out ipReturn.x)) return ipReturn;
			if (false == int.TryParse(tempSplit[1], out ipReturn.y)) return ipReturn;

			return ipReturn;
		}
		/// <summary>
		/// data table의 value에서 target을 찾아서 key값을 반환 (사잇값 보상)
		/// target이 범위를 벗어날 경우 첫번째 혹은 마지막 key값을 반환
		/// </summary>
		public static double ConvertValueToKey(double target, Dictionary<double, double> dataTable)
		{
			double oldValue = 0.0, newValue;
			double[] values = dataTable.Values.ToArray();

			bool isFirst = true, isFind = false;
			int findIndex = 0;
			double ratio = 0.0;
			for (int i = 0; i < values.Length; ++i )
			{
				if(isFirst)
				{
					isFirst = false;
					oldValue = values[i];
					continue;
				}

				newValue = values[i];

				if(false == IsInRangeMinMax(target, oldValue, newValue))
				{
					oldValue = values[i];
					continue;
				}

				isFind = true;
				findIndex = i;
				ratio = (target - oldValue) * 100 / (newValue - oldValue);
				break;
			}

			double[] keys = dataTable.Keys.ToArray();
			if (isFirst)	// data table이 비어있음
			{
				return 0;
			}
			else if (false == isFind) // data table 범위를 벗어남.
			{
				if (values.Length == 1) return keys[0];	// data table에 값이 1개뿐인 경우 그 값을 반환

				if (values[0] == Math.Min(values[0], values[values.Length - 1]))	// table value가 오름차순인 경우.
				{
					if(target < values[0])	// target이 범위보다 낮은 값이면 첫번째 값 반환
					{
						return keys[0];
					}
					else
					{
						return keys[keys.Length - 1];
					}
				}
				else // table value가 내림차순인 경우.
				{
					if (target > values[0])	// target이 범위보다 높은 값이면 첫번째 값 반환
					{
						return keys[0];
					}
					else
					{
						return keys[keys.Length - 1];
					}
				}
			}
			else
			{
				double result = keys[findIndex - 1] + ((keys[findIndex] - keys[findIndex - 1]) * ratio / 100);
				return result;
			}
		}
		#endregion </CALCULATE>

		#region <TRANSFORM>
		/// <summary>
		/// 숫자 -> 알파벳
		/// ex) 0 > A, 27 > AB, 16383 > XFD
		/// </summary>
		public static string DecToAlphabet(int num)
		{
			int rest; //나눗셈 계산에 사용될 나머지 값
			string alphabet; //10진수에서 알파벳으로 변환될 값

			byte[] asciiA = Encoding.ASCII.GetBytes("A"); // 0=>A
			rest = num % 26; // A~Z 26자
			asciiA[0] += (byte)rest; // num 0일 때 A, num 4일 때 A+4 => E

			alphabet = Encoding.ASCII.GetString(asciiA); //변환된 알파벳 저장

			num = num / 26 - 1; // 그 다음 자리의 알파벳 계산을 재귀하기 위해, 받은 수/알파벳수 -1 (0은 A라는 문자값이 있으므로 -1을 기준으로 계산함)
			if (num > -1)
			{
				alphabet = alphabet.Insert(0, DecToAlphabet(num)); //재귀 호출하며 결과를 앞자리에 insert
			}
			return alphabet; // 최종값 return
		}
		#endregion </TRANSFORM>

		#region <EXPORT>
		/// <summary>
		/// Grid view를 CSV file로 export한다.
		/// </summary>
		public static bool CsvExportToGridView(System.Windows.Forms.DataGridView gridView)
		{
			List<string> writeData = new List<string>();
			List<string> oneLineItem = new List<string>();
			string oneLine = "";

			// Header
			for (int i = 0; i < gridView.Columns.Count; i++)
			{
				oneLineItem.Add(gridView.Columns[i].HeaderText);
				oneLine = string.Join(",", oneLineItem);
			}
			writeData.Add(oneLine);
			oneLineItem.Clear();

			// Data
			int rowCount = gridView.Rows.Count;
			if (gridView.AllowUserToAddRows == true)
			{
				rowCount--;
			}

			for (int i = 0; i < rowCount; ++i)
			{
				for (int j = 0; j < gridView.Columns.Count; ++j)
				{
					if (gridView[j, i].Value == null)
					{
						oneLineItem.Add("null");
					}
					else
					{
						oneLineItem.Add(gridView[j, i].Value.ToString());
					}
				}
				oneLine = string.Join(",", oneLineItem);
				writeData.Add(oneLine);
				oneLineItem.Clear();
			}

			return WriteCsvFile(writeData);
		}
		public static bool WriteCsvFile(List<string> fullData)
		{
			string filePath, fileName;
			if (false == GetFilePathWithSaveFileDialog(out filePath, out fileName))
				return false;

			if(FileExistCheck(filePath, fileName))
			{
				if (false == FileDelete(filePath, fileName)) return false;
			}

			using (System.IO.StreamWriter writer = new System.IO.StreamWriter(string.Format(@"{0}\{1}.csv", filePath, fileName)))
			{
				fullData.ForEach(oneLine => writer.WriteLine(oneLine));
				writer.Close();
			}

			Console.WriteLine("Csv File Write Finish");
			return true;
		}
		#endregion </EXPORT>

		#region <FILE CONTROL>
		/// <summary>
		/// Source의 file을 Target으로 copy
		/// </summary>
		public static bool FileCopy(string sSourcePath, string sSourceName, string sTargetPath, string sTargetName)
		{
			string sourceFile = System.IO.Path.Combine(sSourcePath, sSourceName);
			string destFile = System.IO.Path.Combine(sTargetPath, sTargetName);

			if (System.IO.File.Exists(sourceFile))
			{
				try
				{
					System.IO.Directory.CreateDirectory(sTargetPath);
					System.IO.File.Copy(sourceFile, destFile, true);
				}
				catch (System.IO.IOException e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
			else
			{
				Console.WriteLine("Source File Not Exists");
				return false;
			}

			return true;
		}
		/// <summary>
		/// Source의 file을 Delete
		/// </summary>
		public static bool FileDelete(string sTargetPath, string sTargetName)
		{
			string destFile = System.IO.Path.Combine(sTargetPath, sTargetName);

			if (System.IO.File.Exists(destFile))
			{
				try
				{
					System.IO.File.Delete(destFile);
				}
				catch (System.IO.IOException e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}

			return true;
		}
		/// <summary>
		/// Source의 file을 Target으로 Move
		/// 같은 이름의 file을 덮어씀
		/// </summary>
		public static bool FileMove(string sSourcePath, string sSourceName, string sTargetPath, string sTargetName)
		{
			if (false == FileCopy(sSourcePath, sSourceName, sTargetPath, sTargetName)) return false;
			if (false == FileDelete(sSourcePath, sSourceName)) return false;
			return true;
		}
		/// <summary>
		/// 해당 File이 존재 하는지 확인
		/// </summary>
		public static bool FileExistCheck(string sTargetPath, string sTargetName)
		{
			string destFile = System.IO.Path.Combine(sTargetPath, sTargetName);

			if (System.IO.File.Exists(destFile)) return true;
			else return false;
		}
		/// <summary>
		/// 해당 File이 존재 하는지 확인
		/// </summary>
		public static bool FileExistCheck(string sTargetPathName)
		{
			if (System.IO.File.Exists(sTargetPathName)) return true;
			else return false;
		}
		/// <summary>
		/// Save File Dialog를 표시하고 File Path와 File Name을 반환한다.
		/// </summary>
		public static bool GetFilePathWithSaveFileDialog(out string filePath, out string fileName)
		{
			var saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			saveFileDialog.Title = "Save an File";
			if (System.Windows.Forms.DialogResult.OK == saveFileDialog.ShowDialog())
			{
				filePath = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
				fileName = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
				return true;
			}
			else
			{
				filePath = fileName = "";
				return false;
			}
		}
		public static bool GetFilePathWithOpenFileDialog(out string filePath, out string fileName)
		{
			var saveFileDialog = new System.Windows.Forms.OpenFileDialog();
			saveFileDialog.Title = "Save an File";
			if (System.Windows.Forms.DialogResult.OK == saveFileDialog.ShowDialog())
			{
				filePath = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
				fileName = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
				return true;
			}
			else
			{
				filePath = fileName = "";
				return false;
			}
		}
		/// <summary>
		/// 해당File의 내용을 String[]로 반환한다.
		/// </summary>
		public static string[] GetFileRead(string filePath, string fileName)
		{
			if (false == FunctionsETC.FileExistCheck(filePath, fileName))
				return null;

			string fullPath = string.Format("{0}\\{1}", filePath, fileName);
			string[] readLines = null;

			try
			{
				// 해당 위치의 비전 결과를 전부 읽어온다.
				readLines = System.IO.File.ReadAllLines(fullPath);
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.ToString());
				return null;
			}

			return readLines;
		}
		/// <summary>
		/// targetPath의 하위 파일과 디렉토리를 모두 삭제
		/// </summary>
		public static bool FolderDelete(string targetPath)
		{
			var dirInfo = new System.IO.DirectoryInfo(targetPath);
			try { dirInfo.Delete(true); }
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}
		/// <summary>
		/// Folder 존재 여부 반환
		/// </summary>
		public static bool FolderExistCheck(string targetPath)
		{
			var dirInfo = new System.IO.DirectoryInfo(targetPath);
			return dirInfo.Exists;
		}
		/// <summary>
		/// sourch path의 폴더명을 target path로 변경한다.
		/// 이미 동일한 target path의 폴더가 있으면 false 반환
		/// </summary>
		public static bool FolderNameChange(string sourcePath, string targetPath)
		{
			if (sourcePath == targetPath) return false;
			if (false == FolderExistCheck(sourcePath)) return false;
			if (FolderExistCheck(targetPath)) return false;

			var sourceInfo = new System.IO.DirectoryInfo(sourcePath);
			try { sourceInfo.MoveTo(targetPath); }
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return true;
		}
		/// <summary>
		/// target path 생성
		/// </summary>
		public static void FolderCreate(string targetPath)
		{
			var dirInfo = new System.IO.DirectoryInfo(targetPath);
			if(false == dirInfo.Exists)
			{
				dirInfo.Create();
			}
		}

		/// <summary>
		/// 폴더를 압축해서 지정 경로에 생성
		/// </summary>
		public static bool FolderCompress(string targetPath, string savePath, string saveName)
		{
			if (false == FileDelete(savePath, saveName)) return false;
			string resultFullPath = System.IO.Path.Combine(savePath, saveName);

			System.IO.Compression.ZipFile.CreateFromDirectory(targetPath, resultFullPath);
			return true;
		}



        private static void DeleteFile(string strPath, int nStoragePeriod)
        {
            if (!System.IO.Directory.Exists(strPath))
                return;
            foreach (string Folder in System.IO.Directory.GetDirectories(strPath))
                DeleteFile(Folder, nStoragePeriod); //재귀함수 호출

            foreach (string file in System.IO.Directory.GetFiles(strPath))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (fi.CreationTime <= DateTime.Now.AddDays(-nStoragePeriod)
                    || fi.LastWriteTime <= DateTime.Now.AddDays(-nStoragePeriod))
                    fi.Delete();
            }

            //빈 폴더 삭제
            if(System.IO.Directory.GetFiles(strPath).Length == 0
                && System.IO.Directory.GetDirectories(strPath).Length == 0)
            {
                var dirInfo = new System.IO.DirectoryInfo(strPath);
                dirInfo.Delete(true);
            }
        }


		#endregion </FILE CONTROL>

		#region <SYSTEM>

		#region <SYSTEM PERFORMANCE>
		///// <summary>
		///// CPU 사용량을 %로 반환
		///// </summary>
		//public static async Task<double> GetCpuUsage()
		//{
		//	using (var wmi = new System.Management.ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor where Name != '_Total'"))
		//	{
		//		var cpuUsages = wmi.Get().Cast<System.Management.ManagementObject>().Select(mo => (long)(ulong)mo["PercentProcessorTime"]);
		//		double totalUsage = 0.0;

		//		await System.Threading.Tasks.Task.Run(() => { totalUsage = cpuUsages.Average(); });

		//		return (double)totalUsage;
		//	}
		//}
		///// <summary>
		///// Memory사용량을 %로 반환
		///// </summary>
		//public static double GetMemoryUsage()
		//{
		//	int totalSize = 0;
		//	int freeSize = 0;
		//	System.Management.ManagementClass cls = new System.Management.ManagementClass("Win32_OperatingSystem");
		//	System.Management.ManagementObjectCollection moc = cls.GetInstances();

		//	foreach(System.Management.ManagementObject mo in moc)
		//	{
		//		totalSize = int.Parse(mo["TotalVisibleMemorySize"].ToString());
		//		freeSize = int.Parse(mo["FreePhysicalMemory"].ToString());
		//	}

		//	double result = 100 - ((freeSize * 100) / totalSize);
		//	return result;
		//}
		///// <summary>
		///// 드라이브 사용량을 %로 반환
		///// </summary>
		//public static double GetDriveCapacityUsage(string driveName)
		//{
		//	// Find Drive
		//	System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
		//	System.IO.DriveInfo targetDrive = null;

		//	foreach(System.IO.DriveInfo drive in drives)
		//	{
		//		if (drive.DriveType != System.IO.DriveType.Fixed)
		//			continue;

		//		if (false == drive.Name.Contains(driveName))
		//			continue;

		//		targetDrive = drive;
		//	}

		//	if (targetDrive == null)
		//		return 0;

		//	double totalSize = targetDrive.TotalSize / 1024 / 1024 / 1024;
		//	double freeSize = targetDrive.AvailableFreeSpace / 1024 / 1024 / 1024;

		//	double result = 100 - ((freeSize * 100) / totalSize);
		//	return result;
		//}
		#endregion </SYSTEM PERFORMANCE>

		#region <SYSTEM TIME>
		private struct SYSTEMTIME
		{
			public ushort wYear;
			public ushort wMonth;
			public ushort wDayOfWeek;
			public ushort wDay;
			public ushort wHour;
			public ushort wMinute;
			public ushort wSecond;
			public ushort wMilliseconds;
		}
		[DllImport("kernel32.dll")]
		private static extern uint SetSystemTime(ref SYSTEMTIME lpSystemTime);
		private static void ChangeSystemTime(DateTime targetTime)
		{
			// 사용 시 관리자 권한을 얻도록 프로그램 수정 필요
			var st = new SYSTEMTIME();
			st.wDayOfWeek = (ushort)targetTime.DayOfWeek;
			st.wMonth = (ushort)targetTime.Month;
			st.wDay = (ushort)targetTime.Day;
			st.wHour = (ushort)targetTime.Hour;
			st.wMinute = (ushort)targetTime.Minute;
			st.wSecond = (ushort)targetTime.Second;
			st.wMilliseconds = 0;

			SetSystemTime(ref st);
		}
		#endregion </SYSTEM TIME>

		#endregion </SYSTEM>

		#region <ETC>
		public static void ImportantFileBackup()
		{
			DateTime now = DateTime.Now;
			string savePath = Define.DefineConstant.FilePath.FILEPATH_EXE + "\\..\\..\\BACKUP\\" + now.ToString("yyyy.MM.dd");
			string sourcePath;

			try
			{
				// 경로 만들기
				FolderCreate(savePath);

				// Release folder
				sourcePath = Define.DefineConstant.FilePath.FILEPATH_EXE;
				FolderCompress(sourcePath, savePath, "Release.zip");

				// Recipe folder
				sourcePath = Define.DefineConstant.FilePath.FILEPATH_RECIPE;
				FolderCompress(sourcePath, savePath, "Recipe.zip");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

        public static void DeleteLogFile()
        {
            string strDirLog = Define.DefineConstant.FilePath.FILEPATH_LOG;
            DeleteFile(strDirLog, 90);

            string strDirWorkLog = Define.DefineConstant.FilePath.FILEPATH_LASER_WORK_LOG;
            DeleteFile(strDirWorkLog, 90);
        }
		#endregion </ETC>
	}
}
