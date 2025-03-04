using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrameOfSystem3.Functional;

namespace FrameOfSystem3.Views.Functional
{
    public partial class Form_SelectionList : Form
    {
        #region 싱글톤
        private static Form_SelectionList _Instance = new Form_SelectionList();
        public static Form_SelectionList GetInstance()
        {
            return _Instance;
        }
        #endregion

        #region 상수
        private const int c_nHeight                     = 170;       // 폼의 높이
        private const int c_nStartPosYForButtons        = 110;		 // 기본 버튼들의 시작 위치
		private const int c_nLabelHeight				= 40;

        private const int c_nMaxCountOfDisplay          = 15;		 // 한 화면에 출력되는 열 갯수
        private const int c_nWidthLed                   = 30;        // LED 컨트롤 너비
        private const int c_nHeightLed                  = 45;        // LED 컨트롤 높이
        private const int c_nWidthButton                = 370;       // 버튼 너비
        private const int c_nHeightButton               = 46;        // 버튼 높이

        private const int c_nStartPosXForLeftLed        = 10;		 // 좌측 LED 컨트롤의 시작 좌표(X)
        private const int c_nStartPosYForLed            = 110;		 // LED 컨트롤의 시작 좌표(Y)
        private const int c_nStartPosXForLeftButton     = 39;		 // 좌측 버튼 컨트롤의 시작 좌표(X)
        private const int c_nStartPosYForButton         = 110;		 // 버튼 컨트롤의 시작 좌표(Y)

		private const int c_nStartPosXForRightLed       = 430;       // 우측 LED 컨트롤의 시작 좌표(X)
		private const int c_nStartPosXForRightButton    = 459;       // 우측 버튼 컨틀홀의 시작 좌표(X)

        private const int c_nPadding                    = 10;        // 각 컨트롤간의 간격

		private const string	PREVALUE				= "Prevalue.";
		private const string	DEFAULT_VALUE			= "DefaultIndex.";
		private const int		FIRST_INDEX_OF_ARRY		= 0;
		private const int		FIRST_PAGE				= 1;
        #endregion

        #region 변수

		#region GUI
		private int m_nRecentPageLeft                   = 1;
		private int m_nLastPageLeft                     = 1;
		private int m_nRecentPageRight                  = 1;
		private int m_nLastPageRight                    = 1;

		private bool m_bMouseDownTitle					= false;
		private Point m_pMouseDownCoordinate			= new Point();
		#endregion

		private List<int> m_ListSelected				= new List<int>();

		private int m_nIndexOfPreviousSelectedItem      = -1;			// 직전에 선택된 아이템
        private bool m_bMultiselection                  = false;		//다중 선택

        private string m_strSelectedItem                = string.Empty; // 선택된 아이템
		private string m_strDefaultValue				= string.Empty; // 디폴트값
		private int m_nDefalutValue						= -1;
        
		private int m_nCountOfSelectedItem				= 0;
        private int m_nCountOfItem                      = 0;			// 전체 아이템 수
        private int m_nCountOfDisplayItem               = 0;			// 현재 화면에 표시된 아이템 수

		private string m_strResult						= string.Empty;
		private int m_nResult							= -1;
		private int[] m_nArrResult						= null;

        private string[] m_strArrItem                   = null;
		private int[] m_nArrIndexOfItem					= null;
        private bool[] m_bArrSelected                   = null;

		#region Controls
		private Dictionary<int, Sys3Controls.Sys3LedLabel> m_DicOfLedControlRight   = new Dictionary<int, Sys3Controls.Sys3LedLabel>();
		private Dictionary<int, Sys3Controls.Sys3button> m_DicOfButtonControlRight  = new Dictionary<int, Sys3Controls.Sys3button>();

		private Dictionary<int, Sys3Controls.Sys3LedLabel> m_DicOfLedControlLeft    = new Dictionary<int, Sys3Controls.Sys3LedLabel>();
		private Dictionary<int, Sys3Controls.Sys3button> m_DicOfButtonControlLeft   = new Dictionary<int, Sys3Controls.Sys3button>();
		#endregion

		#region Instance
		FrameOfSystem3.Functional.SelectionList m_InstanceOfSelection	= FrameOfSystem3.Functional.SelectionList.GetInstance();
		#endregion

        #endregion

        private Form_SelectionList()
        {
            InitializeComponent();
        }

        #region 내부인터페이스
        /// <summary>
        /// 2020.05.26 by twkang [ADD] 폼이 생성될 때 초기화 작업을 수행한다.
        /// </summary>
        private void InitializeForm(ref string strTitle, ref string[] arrItems, int[] arrIndex, ref string strPreValue, bool bMultiSelection, ref string strDefaultValue)
		{
			m_groupTitle.Text	= strTitle;

			m_bMultiselection	= bMultiSelection;

			//Default Value
			if(strDefaultValue.Contains(DEFAULT_VALUE))
			{
				string[] temp	= strDefaultValue.Split('.');
				int.TryParse(temp[1], out m_nDefalutValue);
				m_strDefaultValue	= string.Empty;
			}
			else
			{
				m_nDefalutValue		= -1;
				m_strDefaultValue	= strDefaultValue;
			}
			
			m_nCountOfSelectedItem			= 0;
			m_nRecentPageLeft				= 1;
			m_nRecentPageRight				= 1;

			m_nCountOfItem					= 0;
			m_nIndexOfPreviousSelectedItem	= -1;
			
			m_ListSelected.Clear();

			MakeItemList(ref arrItems, arrIndex);

			CreateControls();

			SetLocationOfControls();

			SetFormSize();

			CheckPreSelectedValue(ref strPreValue);

			SetItemPage();

			SetControlValueSelected();

			SetControlValueList();
		}
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 현재 아이템 수에 따라 페이지 정보를 업데이트한다.
        /// </summary>
        private void SetItemPage()
        {
			m_nLastPageRight = (int)((m_nCountOfItem) / c_nMaxCountOfDisplay);

			if ((m_nCountOfItem) % c_nMaxCountOfDisplay != 0)
			{
				++m_nLastPageRight;
			}

			m_btnRPage.Text = m_nRecentPageRight.ToString();
			m_btnRPage.SubText = string.Format("/ {0}", m_nLastPageRight);

			m_nLastPageLeft = (int)(m_nCountOfSelectedItem / c_nMaxCountOfDisplay);

			if (m_nCountOfSelectedItem % c_nMaxCountOfDisplay != 0)
			{
				++m_nLastPageLeft;
			}
			if(m_nLastPageLeft == 0)
			{
				m_nLastPageLeft++;
			}

			if(m_nRecentPageLeft > m_nLastPageLeft)
			{
				m_nRecentPageLeft = m_nLastPageLeft;
			}
			m_btnLPage.Text = m_nRecentPageLeft.ToString();
			m_btnLPage.SubText = string.Format("/ {0}", m_nLastPageLeft);
        }
        /// <summary>
        /// 2020.05.26 by twkang [ADD] 아이템 리스트를 만든다.
        /// </summary>
        private void MakeItemList(ref string[] arItems, int[] arIndexes)
        {
			m_nCountOfItem	= arItems.Length;

			m_nCountOfDisplayItem	= m_nCountOfItem > c_nMaxCountOfDisplay ? c_nMaxCountOfDisplay : m_nCountOfItem;

			m_bArrSelected	= new bool[m_nCountOfItem];
            
			m_strArrItem	= arItems;

			if(null == arIndexes)
			{
				m_nArrIndexOfItem	= new int[m_nCountOfItem];

				for(int i = 0; i < m_nCountOfItem; ++i)
				{
					m_nArrIndexOfItem[i] = i;
				}
			}
			else
			{
				m_nArrIndexOfItem	= arIndexes;
			}

        }
        /// <summary>
        /// 2020.05.26 by twkang [ADD] LED와 버튼 컨트롤들을 생성한다.
        /// </summary>
        private void CreateControls()
        {
			//LED와 버튼 컨트롤의 인덱스번호
			
            int nAddIndex   = 0;

			m_DicOfLedControlRight		= new Dictionary<int,Sys3Controls.Sys3LedLabel>();
			m_DicOfButtonControlRight	= new Dictionary<int,Sys3Controls.Sys3button>();

            var varDictionaryLED        = m_DicOfLedControlRight;
            var varDictionaryButton     = m_DicOfButtonControlRight;

            while(true)
            {
                for(int i = 0; i < m_nCountOfDisplayItem; ++i)
                {
                    Sys3Controls.Sys3LedLabel label = new Sys3Controls.Sys3LedLabel();

                    label.Height                 = c_nHeightLed;
                    label.Width                  = c_nWidthLed;

                    this.Controls.Add(label);                    
                    varDictionaryLED.Add(i, label);

                    Sys3Controls.Sys3button button = new Sys3Controls.Sys3button();

                    button.Height                   = c_nHeightButton;
                    button.Width                    = c_nWidthButton;

                    button.UseSubFont               = true;
                    button.TextAlignSub             = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
                    button.SubFont                  = new Font("맑은 고딕", 10, FontStyle.Bold);
                    button.SubFontColor             = Color.Black;

                    button.TextAlignMain            = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
                    button.MainFontColor            = Color.Black;
                    button.MainFont                 = new Font("맑은 고딕", 12, FontStyle.Bold);

                    button.GradientFirstColor       = Color.FromArgb(235, 235, 235);
                    button.GradientSecondColor      = Color.FromArgb(180, 186, 193);
					button.GradientAngle			= 85;

					button.BorderWidth				= 1;

                    button.TabIndex					= i + nAddIndex;
                    button.MouseClick				+= Click_Item;

                    this.Controls.Add(button);                    
                    varDictionaryButton.Add(i, button);
                }

                if(varDictionaryLED == m_DicOfLedControlRight)
                {
					//최대 아이템수만큼 인덱스를 더한다.
					//우측 INDEX 번호가 더 작음
                    nAddIndex               = c_nMaxCountOfDisplay;

					m_DicOfLedControlLeft		= new Dictionary<int,Sys3Controls.Sys3LedLabel>();
					m_DicOfButtonControlLeft	= new Dictionary<int,Sys3Controls.Sys3button>();

                    varDictionaryLED        = m_DicOfLedControlLeft;
                    varDictionaryButton     = m_DicOfButtonControlLeft;
                    continue;
                }
                else
                {
                    break;
                }
            }

			m_btnAllSelect.Visible		= m_bMultiselection;
			m_btnAllUnSelect.Visible	= m_bMultiselection;
        }
		/// <summary>
		/// 2020.05.28 by twkang [ADD] 아이템 수에 따라 컨트롤의 위치를 설정한다.
		/// </summary>
		private void SetLocationOfControls()
		{
			Point pt    = new Point();

			int nHeightPadding  = c_nHeightLed + c_nPadding;

			for(int i = 0; i < m_nCountOfDisplayItem; i++)
			{
				pt.X	= c_nStartPosXForLeftButton;
				pt.Y	= c_nStartPosYForButton + (i * nHeightPadding);
				m_DicOfButtonControlLeft[i].Location	= pt;

				pt.X	= c_nStartPosXForLeftLed;				
				m_DicOfLedControlLeft[i].Location		= pt;

				pt.X	= c_nStartPosXForRightButton;
				m_DicOfButtonControlRight[i].Location	= pt;

				pt.X	= c_nStartPosXForRightLed;
				m_DicOfLedControlRight[i].Location		= pt;
			}

		}

		/// <summary>
		/// 2020.05.28 by twkang [ADD] 아이템 수에 따라 Form 크기를 설정한다.
		/// </summary>
        private void SetFormSize()
		{
			Point pt    = new Point();

			int nHeightPadding			= c_nHeightLed + c_nPadding;

			int nHeight					= m_nCountOfDisplayItem * nHeightPadding;

			this.Height					= c_nHeight + nHeight;
            m_groupTitle.Height			= this.Height - c_nLabelHeight;
			m_groupTitleSelected.Height	= this.Height - c_nLabelHeight;

			int nPositionForButton		= c_nStartPosYForButtons + nHeight;

			pt		= m_btnLPrevious.Location;
			pt.Y	= nPositionForButton;
			m_btnLPrevious.Location	= pt;

			pt		= m_btnLPage.Location;
			pt.Y	= nPositionForButton;
			m_btnLPage.Location		= pt;

			pt		= m_btnLNext.Location;
			pt.Y	= nPositionForButton;
			m_btnLNext.Location		= pt;

			pt      = m_btnRPrevious.Location;
            pt.Y    = nPositionForButton;
            m_btnRPrevious.Location  = pt;

            pt      = m_btnRNext.Location;
            pt.Y    = nPositionForButton;
            m_btnRNext.Location  = pt;

            pt      = m_btnRPage.Location;
            pt.Y    = nPositionForButton;
            m_btnRPage.Location  = pt;

            pt      = m_btnApply.Location;
            pt.Y    = nPositionForButton;
            m_btnApply.Location  = pt;

            pt      = m_btnCancel.Location;
            pt.Y    = nPositionForButton;
            m_btnCancel.Location  = pt;
			
			m_groupTitleSelected.SendToBack();
			m_groupTitle.SendToBack();
			m_groupTitleMain.SendToBack();

			this.CenterToScreen();
		}

        /// <summary>
        /// 2020.05.26 by twkang [ADD] 
        /// </summary>
        private void ReDisplayControlSelected(ref int nCountOfDisplayNum)
        {
			for(int i = nCountOfDisplayNum; i < m_nCountOfDisplayItem; i++)
			{
				m_DicOfButtonControlLeft[i].Hide();
				m_DicOfLedControlLeft[i].Hide();
			}
			for(int i = 0; i < nCountOfDisplayNum; i++)
			{
				m_DicOfButtonControlLeft[i].Show();
				m_DicOfLedControlLeft[i].Show();
			}

			m_groupTitleSelected.Invalidate();
        }
		/// <summary>
		/// 2020.05.26 by twkang [ADD]
		/// </summary>		
		private void ReDisplayControlItemList(ref int nCountOfDisplayNum)
		{
			for(int i = nCountOfDisplayNum; i < m_nCountOfDisplayItem; i++)
			{
				m_DicOfButtonControlRight[i].Hide();
				m_DicOfLedControlRight[i].Hide();
			}

			for(int i = 0; i < nCountOfDisplayNum; ++i)
			{
				m_DicOfButtonControlRight[i].Show();
				m_DicOfLedControlRight[i].Show();
			}

			m_groupTitle.Invalidate();

		}
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 기존에 선택된 아이템들을 반영한다.
        /// </summary>
        private void CheckPreSelectedValue(ref string strSelectedValue)
        {
			string[] strArrSelectItem	= null;
			int nPreValue				= -1;

			if(strSelectedValue.Contains(PREVALUE))
			{
				strArrSelectItem	= strSelectedValue.Split('.');
				int.TryParse(strArrSelectItem[1], out nPreValue);

				for(int nIndex = 0, nEnd = m_nArrIndexOfItem.Length; nIndex < nEnd; nIndex++)
				{
					if(m_nArrIndexOfItem[nIndex] == nPreValue)
					{
						m_bArrSelected[nIndex]	= true;
						m_ListSelected.Add(nIndex);
						m_nIndexOfPreviousSelectedItem	= nIndex;
						++m_nCountOfSelectedItem;
					}
				}
			}
			else
			{
				strArrSelectItem		= strSelectedValue.Replace(" ","").Split(',');


				/// 2021.07.29 by twkang [MOD] BUG FIX
				for(int nSelectedIndex = 0, nSelectedEnd = strArrSelectItem.Length; nSelectedIndex < nSelectedEnd; ++nSelectedIndex)
				{
					if (false == m_bMultiselection && m_nCountOfSelectedItem > 0) { return; }
					if ("" == strArrSelectItem[nSelectedIndex]) { return; }

					for(int nIndex = 0, nEnd = m_nCountOfItem; nIndex < nEnd; ++nIndex)
					{
						if (strArrSelectItem[nSelectedIndex].Equals(m_strArrItem[nIndex].Replace(" ","")) && m_bArrSelected[nIndex] == false)
						{
							m_bArrSelected[nIndex] = true;
							m_ListSelected.Add(nIndex);
							m_nIndexOfPreviousSelectedItem = nIndex;
							++m_nCountOfSelectedItem;
							break;
						}
					}
				}

				// 2021.07.29 by twkang [DEL] Not Use
				//for (int i = 0; i < m_nCountOfItem; ++i)
				//{
				//	for (int nIndex = 0, nEnd = strArrSelectItem.Length; nIndex < nEnd; ++nIndex)
				//	{
				//		if (strArrSelectItem[nIndex].Equals(m_strArrItem[i].Replace(" ","")))
				//		{
				//			if (false == m_bMultiselection && m_nCountOfSelectedItem > 0) { return; }
				//			if ("" == strArrSelectItem[nIndex]) { return; }
				//			m_bArrSelected[i] = true;
				//			m_ListSelected.Add(i);
				//			m_nIndexOfPreviousSelectedItem = i;
				//			++m_nCountOfSelectedItem;
				//			break;
				//		}
				//	}
				//}
			}
        }
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 컨트롤에 데이터를 입력한다.
        /// </summary>
        private void SetControlValueSelected()
		{
			int nPage			= m_nRecentPageLeft	- 1;
			int nIndexOfItem	= nPage * c_nMaxCountOfDisplay;

			int nReDisplayCount	= 0;

			if(m_nCountOfDisplayItem < c_nMaxCountOfDisplay)
			{
				for(int nIndex = 0, nEnd = m_ListSelected.Count; nIndex < nEnd; nIndex++)
				{
					int nItemNum	= m_ListSelected.ElementAt(nIndex);
					m_DicOfButtonControlLeft[nIndex].Text	= m_strArrItem[nItemNum];
					m_DicOfButtonControlLeft[nIndex].SubText	= "[ " + m_nArrIndexOfItem[nItemNum].ToString() + " ]";
					m_DicOfLedControlLeft[nIndex].Active		= true;
					++nReDisplayCount;
				}
			}
			else
			{
				for (int i = 0, nSelectedItemCount = m_ListSelected.Count; i < m_nCountOfDisplayItem; i++)
				{
					if (nIndexOfItem < nSelectedItemCount)
					{
						int nIndex	= m_ListSelected.ElementAt(nIndexOfItem);
						m_DicOfButtonControlLeft[i].Text = m_strArrItem[nIndex];
						m_DicOfButtonControlLeft[i].SubText = "[ " + m_nArrIndexOfItem[nIndex].ToString() + " ]";
						m_DicOfLedControlLeft[i].Active = true;
					}
					else
					{
						break;
					}
					++nReDisplayCount;
					++nIndexOfItem;
				}
			}
			ReDisplayControlSelected(ref nReDisplayCount);
		}
		/// <summary>
		/// 
		/// </summary>
		private void SetControlValueList()
		{
			int nPage			= m_nRecentPageRight	- 1;
			int nIndexOfItem	= nPage * c_nMaxCountOfDisplay;

			int nReDisplayCount	= 0;

			while (nReDisplayCount < m_nCountOfDisplayItem)
			{
				if(m_bArrSelected.Length <= nIndexOfItem)
				{					
					break;
				}
				if (nIndexOfItem < m_nCountOfItem)
				{
					m_DicOfButtonControlRight[nReDisplayCount].Text = m_strArrItem[nIndexOfItem];
					m_DicOfButtonControlRight[nReDisplayCount].SubText = "[ " + m_nArrIndexOfItem[nIndexOfItem].ToString() + " ]";
					m_DicOfLedControlRight[nReDisplayCount].Active = m_bArrSelected[nIndexOfItem];
				}
				else
				{
					break;					
				}
				++nReDisplayCount;
				++nIndexOfItem;
			}

			ReDisplayControlItemList(ref nReDisplayCount);
		}
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 생성한 컨트롤들을 제거한다.
        /// </summary>
        private void DestroyControls()
        {
            for(int i = 0; i < m_nCountOfDisplayItem; ++i)
            {
                Control ctrl    = m_DicOfLedControlRight[i];
                this.Controls.Remove(ctrl);
                m_DicOfLedControlRight.Remove(i);                
                ctrl.Dispose();

                ctrl            = m_DicOfButtonControlRight[i];
                this.Controls.Remove(ctrl);
                m_DicOfButtonControlRight.Remove(i);
                ctrl.Dispose();

				ctrl			= m_DicOfButtonControlLeft[i];
				this.Controls.Remove(ctrl);
				m_DicOfButtonControlLeft.Remove(i);
				ctrl.Dispose();

				ctrl			= m_DicOfLedControlLeft[i];
				this.Controls.Remove(ctrl);
				m_DicOfLedControlLeft.Remove(i);
				ctrl.Dispose();
            }
        }
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 선택된 아이템으로 결과값을 생성한다.
        /// </summary>
        private void MakeResult()
        {
			m_nArrResult		= new int[m_ListSelected.Count];

			if(m_ListSelected.Count == 0)
			{
				m_strResult = m_strDefaultValue;
				m_nResult	= m_nDefalutValue;
				return;
			}
			

			int nArrayCount			= 0;
			List<string> tempResult = new List<string>();

			for (int i = 0; i < m_nCountOfItem; ++i)
			{
				if (m_bArrSelected[i])
				{
					m_nArrResult[nArrayCount] = m_nArrIndexOfItem[i];
					tempResult.Add(m_strArrItem[i]);
					++nArrayCount;
				}
			}
			m_nResult	= m_nArrResult[0];
			m_strResult	= string.Join(", ", tempResult.ToArray());
        }
		/// <summary>
		/// 2018.06.29 by yjlee [ADD] 괄호를 제거하고 정수로 캐스팅하여 반환한다.
		/// </summary>
		private int RemoveBrakets(string strNumber)
		{
			string strValue = strNumber.Remove(0, 2);

			int nValue = -1;

			try
			{
				nValue = int.Parse(strValue.Remove(strValue.Length - 2, 2));
			}
			catch (FormatException e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);

				return -1;
			}

			return nValue;
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] 아이템 클릭 Action
		/// </summary>
		private void ClickItem(int nItemIndex, int nControlIndex)
		{
			int nItemNum			= nItemIndex;
			int nindex				= -1;

			for (int i = 0, nEnd = m_nArrIndexOfItem.Length; i < nEnd; i++)
			{
				if (m_nArrIndexOfItem[i] == nItemNum)
				{
					nindex = i;
					break;
				}
			}

			bool bResult	= !m_bArrSelected[nindex];

			SelectItem(nindex, nControlIndex, bResult);
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] 아이템 클릭 Action
		/// </summary>
		private void ClickItem(int nItemIndex, int nControlIndex, bool bSelect)
		{
			int nItemNum			= nItemIndex;
			int nindex				= -1;

			for (int i = 0, nEnd = m_nArrIndexOfItem.Length; i < nEnd; i++)
			{
				if (m_nArrIndexOfItem[i] == nItemNum)
				{
					nindex = i;
					break;
				}
			}

			if(bSelect != m_bArrSelected[nindex])
				SelectItem(nindex, nControlIndex, bSelect);
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] 아이템 선택
		/// </summary>
		private void SelectItem(int nItemIndex, int nControlIndex, bool bResult)
		{
			//우측 리스트 클릭
			if (nControlIndex < c_nMaxCountOfDisplay)
			{
				if (bResult)
				{
					if (false == m_bMultiselection && m_nCountOfSelectedItem > 0)
					{
						m_bArrSelected[m_nIndexOfPreviousSelectedItem] = false;
						m_ListSelected.Clear();
						m_nCountOfSelectedItem = 0;
					}
					m_ListSelected.Add(nItemIndex);
					m_bArrSelected[nItemIndex] = true;
					m_nCountOfSelectedItem++;
				}
				else
				{
					m_ListSelected.Remove(nItemIndex);
					m_bArrSelected[nItemIndex] = false;
					--m_nCountOfSelectedItem;
				}
				m_nIndexOfPreviousSelectedItem = nItemIndex;
			}
			else //좌측 리스트 클릭
			{
				m_ListSelected.Remove(nItemIndex);
				m_bArrSelected[nItemIndex] = false;
				--m_nCountOfSelectedItem;
				m_nIndexOfPreviousSelectedItem = nItemIndex;
			}
			if (false == m_DicOfButtonControlLeft[FIRST_INDEX_OF_ARRY].Visible && m_nRecentPageLeft != FIRST_PAGE)
			{
				--m_nRecentPageLeft;
			}
			SetItemPage();
			SetControlValueList();
			SetControlValueSelected();
		}
        #endregion

        #region 외부인터페이스

		#region Create Form
		/// <summary>
        /// 2020.05.28 by twkang [ADD] SelectionList Form 을 생성한다.
        /// </summary>
        public bool CreateForm(string strTitle, string[] arrItems, string strPreValue, bool bMultiSelection = false, string strDefaultValue = "")
        {
            if (null == arrItems) { return false;}

			if(string.IsNullOrEmpty(strDefaultValue))
			{
				strDefaultValue = strPreValue;
			}

            InitializeForm(ref strTitle, ref arrItems, null, ref strPreValue, bMultiSelection,  ref strDefaultValue);

            this.ShowDialog();

            if(this.DialogResult==System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 2020.05.28 by twkang [ADD] SelectionList Form 을 생성한다.
        /// </summary>
        public bool CreateForm(string strTitle, string[] arrItems, int[] arrIndex, int nPreValueIndex, bool bMultiSelection = false, int nDefaultValue = -1)
        {
            if(null == arrIndex)
            {
                return false;
            }

			string strDefaultValue	= DEFAULT_VALUE + nDefaultValue.ToString();
			string strPreValue		= string.Empty;

			if(nPreValueIndex > -1 || nPreValueIndex < arrIndex.Length)
			{
				strPreValue = PREVALUE + nPreValueIndex.ToString();
			}
			else
			{
				strPreValue	= Define.DefineConstant.Common.NONE;
			}

            InitializeForm(ref strTitle, ref arrItems, arrIndex, ref strPreValue, bMultiSelection, ref strDefaultValue);
            
			this.ShowDialog();
            
            if(this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }

            return false;
        }
		/// <summary>
		/// 2020.06.05 by twkang [ADD] SelectionList Form 을 생성한다.
		/// </summary>
		public bool CreateForm(string strTitle, Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST enList, string strPreValue, bool bMultiSelection = false, string strDefaultValue = "")
		{
			if(string.IsNullOrEmpty(strDefaultValue))
			{
				strDefaultValue	= strPreValue;
			}

			string[] strArr = null;

			if(m_InstanceOfSelection.GetList(enList, ref strArr))
			{
				return CreateForm(strTitle, strArr, strPreValue, bMultiSelection, strDefaultValue);
			}
			
			return false;
		}
		public bool CreateForm(string strTitel, string[] arItems, int[] arIndex, string[] arPreValue, bool bMultiSelection = false, string strDefaultValue = "")
		{
			string strPreValue	= string.Empty;
			if(arPreValue != null)
			{
				strPreValue		= string.Join(", ", arPreValue);
			}

			InitializeForm(ref strTitel, ref arItems, arIndex, ref strPreValue, bMultiSelection, ref strDefaultValue);

			this.ShowDialog();

			if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
			{
				return true;
			}

			return false;
		}
		#endregion

		#region GetData
		/// <summary>
        /// 2022.03.26 by shkim [MOD] SelectionList 결과값 선택 순서대로 받환 받는 옵션 추가
     	/// 2020.05.28 by twkang [ADD] SelectionList 결과값을 반환한다.
     	/// </summary>
		public void GetResult(ref int[] nArrResult, bool bUseOrder = false)
		{
            if(false == bUseOrder)
            {
                nArrResult = m_nArrResult;
            }
            else
            {
                nArrResult = m_ListSelected.Cast<int>().ToArray();
            }
		}
		/// <summary>
		/// 2020.05.28 by twkang [ADD] SelectionList 결과값을 반환한다.
		/// </summary>
		public void GetResult(ref string strResult)
		{
			strResult = m_strResult;
		}
		/// <summary>
		/// /// 2020.05.28 by twkang [ADD] SelectionList 결과값을 반환한다.
		/// </summary>
		public void GetResult(ref int nIndex)
		{
			nIndex = m_nResult;
		}
		#endregion
		
        #endregion

        #region UI 이벤트
        /// <summary>
        /// 2020.05.28 by twkang [ADD] Apply or Cancel 버튼을 눌렀을 경우의 이벤트 처리
        /// </summary>
        private void Click_ApplyOrCancel(object sender, EventArgs e)
        {
            DestroyControls();

            Control ctr = sender as Control;

            switch(ctr.TabIndex)
            {
                case 0: // Apply
                    MakeResult();
                    this.DialogResult       = System.Windows.Forms.DialogResult.OK;
                    break;
                case 1: // Cancel
                    this.DialogResult       = System.Windows.Forms.DialogResult.Cancel;
                    break;
            }
            this.Close();
        }
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 아이템 항목을 클릭했을 때 이벤트 처리
        /// </summary>
        private void Click_Item(object sender, EventArgs e)
        {          	
			Sys3Controls.Sys3button ctrl	= sender as Sys3Controls.Sys3button;

			int nItemIndex =  RemoveBrakets(ctrl.SubText);

			ClickItem(nItemIndex, ctrl.TabIndex);

			//int nItemNum			= RemoveBrakets(ctrl.SubText);
			//int nindex				= -1;

			//for(int i = 0, nEnd = m_nArrIndexOfItem.Length; i < nEnd; i++)
			//{
			//	if(m_nArrIndexOfItem[i] == nItemNum)
			//	{
			//		nindex = i;
			//		break;
			//	}
			//}			
			//bool bResult	= !m_bArrSelected[nindex];

			////우측 리스트 클릭
			//if(ctrl.TabIndex < c_nMaxCountOfDisplay)
			//{
			//	if(bResult)
			//	{
			//		if (false == m_bMultiselection && m_nCountOfSelectedItem > 0)
			//		{
			//			m_bArrSelected[m_nIndexOfPreviousSelectedItem] = false;
			//			m_ListSelected.Clear();
			//			m_nCountOfSelectedItem = 0;
			//		}
			//		m_ListSelected.Add(nindex);
			//		m_bArrSelected[nindex] = true;					
			//		m_nCountOfSelectedItem++;
			//	}
			//	else
			//	{
			//		m_ListSelected.Remove(nindex);
			//		m_bArrSelected[nindex] = false;
			//		--m_nCountOfSelectedItem;
			//	}
			//	m_nIndexOfPreviousSelectedItem = nindex;
			//}
			//else //좌측 리스트 클릭
			//{
			//	m_ListSelected.Remove(nindex);
			//	m_bArrSelected[nindex] = false;
			//	--m_nCountOfSelectedItem;
			//	m_nIndexOfPreviousSelectedItem = nindex;
			//}
			//if (false == m_DicOfButtonControlLeft[FIRST_INDEX_OF_ARRY].Visible && m_nRecentPageLeft != FIRST_PAGE)
			//{
			//	--m_nRecentPageLeft;
			//}
			//SetItemPage();
			//SetControlValueList();
			//SetControlValueSelected();

        }
        /// <summary>
        /// 2020.05.28 by twkang [ADD] 페이지 이동 버튼을 눌렀을 때 이벤트처리
        /// </summary>
        private void Click_MovePage(object sender, EventArgs e)
        {
			Control ctrl		= sender as Control;

			switch(ctrl.TabIndex)
			{
				case 0: // Unselected PreVious Page
					if(m_nRecentPageRight == FIRST_PAGE) return;

					--m_nRecentPageRight;
					break;
				case 1: // Unselected Next Page
					if (m_nRecentPageRight >= m_nLastPageRight) return;

					++m_nRecentPageRight;
					break;
				case 2: // selected PreVious Page
					if(m_nRecentPageLeft == FIRST_PAGE) return;

					--m_nRecentPageLeft;
					break;
				case 3: // selected Next Page
					if(m_nRecentPageLeft >= m_nLastPageLeft) return;

					++m_nRecentPageLeft;

					break;
			}
			SetItemPage();
			SetControlValueList();
			SetControlValueSelected();

        }
		private void Form_SelectionList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				DestroyControls();

				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] All Select, UnSelect 버튼 클릭 이벤트
		/// </summary>
		private void Click_SelectButton(object sender, EventArgs e)
		{
			Control ctrl	= sender as Control;

			bool bSelectAction	= ctrl.TabIndex == 1;

			var pItemEnumerator = bSelectAction ? m_DicOfButtonControlRight.AsEnumerable() : m_DicOfButtonControlLeft.Reverse();

			foreach (var kvp in pItemEnumerator)
			{
				if (kvp.Value.Visible)
				{
					int nItemIndex =  RemoveBrakets(kvp.Value.SubText);

					ClickItem(nItemIndex, kvp.Value.TabIndex, bSelectAction);
				}
			}
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] TitleBar Mouse Down 이벤트
		/// </summary>
		private void MouseDown_Title(object sender, MouseEventArgs e)
		{
			m_bMouseDownTitle = true;
			m_pMouseDownCoordinate = e.Location;
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] TitleBar Mouse Move 이벤트
		/// </summary>
		private void MouseMove_Title(object sender, MouseEventArgs e)
		{
			if (m_bMouseDownTitle)
			{
				this.SetDesktopLocation(MousePosition.X - m_pMouseDownCoordinate.X, MousePosition.Y - m_pMouseDownCoordinate.Y);
			}
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] TitleBar Mouse Up 이벤트
		/// </summary>
		private void MouseUp_Title(object sender, MouseEventArgs e)
		{
			m_bMouseDownTitle = false;
		}
        #endregion
    }
}
