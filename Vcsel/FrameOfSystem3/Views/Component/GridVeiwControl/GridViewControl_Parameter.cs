using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using FrameOfSystem3.Recipe;
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Map;
using Define.DefineEnumBase.Component;

namespace FrameOfSystem3.Component
{
    public partial class GridViewControl_Parameter : UserControl
    {
        public delegate void DelAfterSetParameter();

        public GridViewControl_Parameter()
        {
            InitializeComponent();

            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance
                                        | BindingFlags.SetProperty, null, dataGridView, new object[] { true });  
        }

        #region Inner class
        public class ParameterItem
        {
            public ParameterItem(PARAM_COMMON enRecipe, int nParaIndex = 0)
            {
                m_enRecipeType = EN_RECIPE_TYPE.COMMON;
                m_lstParameterName.Add(enRecipe.ToString());
                m_lstParameterIndex.Add(nParaIndex);
            }
            public ParameterItem(PARAM_EQUIPMENT enRecipe, int nParaIndex = 0)
            {
                m_enRecipeType = EN_RECIPE_TYPE.EQUIPMENT;
                m_lstParameterName.Add(enRecipe.ToString());
                m_lstParameterIndex.Add(nParaIndex);
            }
            public ParameterItem(EN_TASK_LIST enTask, string strParameterName, int nParaIndex = 0)
            {
                m_enRecipeType = EN_RECIPE_TYPE.PROCESS;
                m_enTask = enTask;
                 m_lstParameterName.Add(strParameterName);
                 m_lstParameterIndex.Add(nParaIndex);
            }

            public ParameterItem(EN_RECIPE_TYPE enType, List<string> lstParameterName, List<int> lstParaIndex = null)
            {
                m_enRecipeType = enType;
                m_lstParameterName = lstParameterName;

                if (lstParaIndex == null)
                    lstParaIndex = new List<int>();

                m_lstParameterIndex = lstParaIndex;

                if (lstParameterName.Count != lstParaIndex.Count)
                {
                    for (int nIndex = lstParaIndex.Count; nIndex < lstParameterName.Count; nIndex++)
                    {
                        m_lstParameterIndex.Add(0);
                    }
                }
            }
            public ParameterItem(List<PARAM_COMMON> lstRecipe, List<int> lstParaIndex = null)
            {
                m_enRecipeType = EN_RECIPE_TYPE.COMMON;
                foreach (PARAM_COMMON en in lstRecipe)
                {
                    m_lstParameterName.Add(en.ToString());
                }

                if (lstParaIndex == null)
                    lstParaIndex = new List<int>();

                m_lstParameterIndex = lstParaIndex;

                if (lstRecipe.Count != lstParaIndex.Count)
                {
                    for (int nIndex = lstParaIndex.Count; nIndex < lstRecipe.Count; nIndex++)
                    {
                        m_lstParameterIndex.Add(0);
                    }
                }

            }
            public ParameterItem(List<PARAM_EQUIPMENT> lstRecipe, List<int> lstParaIndex = null)
            {
                m_enRecipeType = EN_RECIPE_TYPE.EQUIPMENT;
                foreach (PARAM_EQUIPMENT en in lstRecipe)
                {
                    m_lstParameterName.Add(en.ToString());
                }

                if (lstParaIndex == null)
                    lstParaIndex = new List<int>();

                m_lstParameterIndex = lstParaIndex;

                if (lstRecipe.Count != lstParaIndex.Count)
                {
                    for (int nIndex = lstParaIndex.Count; nIndex < lstRecipe.Count; nIndex++)
                    {
                        m_lstParameterIndex.Add(0);
                    }
                }
            }
            public ParameterItem(EN_TASK_LIST enTask, List<string> lstParameterName, List<int> lstParaIndex = null)
            {
                m_enRecipeType = EN_RECIPE_TYPE.PROCESS;
                m_enTask = enTask;
                m_lstParameterName = lstParameterName;

                if (lstParaIndex == null)
                    lstParaIndex = new List<int>();

                m_lstParameterIndex = lstParaIndex;

                if (lstParameterName.Count != lstParaIndex.Count)
                {
                    for (int nIndex = lstParaIndex.Count; nIndex < lstParameterName.Count; nIndex++)
                    {
                        m_lstParameterIndex.Add(0);
                    }
                }
            }

            private bool m_bEnable = true;
            private EN_RECIPE_TYPE m_enRecipeType = EN_RECIPE_TYPE.PROCESS;
            private EN_TASK_LIST m_enTask = EN_TASK_LIST.BOND_HEAD;
            private List<string> m_lstParameterName = new List<string>();
            private List<string> m_lstTrueFalseName = new List<string>();
            private List<int> m_lstParameterIndex = new List<int>();
            private string m_strDisplayName = "";
            private bool m_bNeedRemakeMap = false;
            private EN_REFERANCE_MAP_LIST m_enReferanceMap = EN_REFERANCE_MAP_LIST.MATERIAL_BOND;
            private DelAfterSetParameter delAfterSetParameter = null;
            private DelAfterSetParameter delBeforeSetParameter = null;
            private EN_PARAMETER_SETTING_TYPE m_enParameterSettingType = EN_PARAMETER_SETTING_TYPE.CALCULATE;
            private Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST m_enSelectionList = Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST.TRUE_FALSE;
            public bool Enable { get { return m_bEnable; } set { m_bEnable = value; } }
            public EN_RECIPE_TYPE RecipeType { get { return m_enRecipeType; } set { m_enRecipeType = value; } }
            public EN_TASK_LIST Task { get { return m_enTask; } set { m_enTask = value; } }
            public List<string> ParameterNameList { get { return m_lstParameterName; } set { m_lstParameterName = value; } }
            public List<string> TrueFalseName { get { return m_lstTrueFalseName; } set { m_lstTrueFalseName = value; } }
            public List<int> ParameterIndexList { get { return m_lstParameterIndex; } set { m_lstParameterIndex = value; } }
            public string DisplayName { get { return m_strDisplayName; } set { m_strDisplayName = value; } }
            public bool NeedRemakeMap { get { return m_bNeedRemakeMap; } set { m_bNeedRemakeMap = value; } }
            public EN_REFERANCE_MAP_LIST ReferanceMap { get { return m_enReferanceMap; } set { m_enReferanceMap = value; } }
            public DelAfterSetParameter AfterSetParameter { get { return delAfterSetParameter; } set { delAfterSetParameter = value; } }
            public DelAfterSetParameter BeforeSetParameter { get { return delBeforeSetParameter; } set { delBeforeSetParameter = value; } }
            public EN_PARAMETER_SETTING_TYPE ParameterSettingType
            {
                set { m_enParameterSettingType = value; }
                get { return m_enParameterSettingType; }
            }
            public Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST SelectionList
            {
                set
                {
                    m_enSelectionList = value;
                }
                get { return m_enSelectionList; }
            }

        }
        #endregion

        #region Field
        private List<ParameterItem> m_ControlCollection;
        private bool m_bControl_Enable = true;
        private Recipe.Recipe m_InstanceRecipe;
        private FrameOfSystem3.Views.Functional.Form_MessageBox m_InstanceOfMessageBox = null;
        private FrameOfSystem3.Views.Functional.Form_Calculator m_InstnaceOfCalculator = null;
        private FrameOfSystem3.Views.Functional.Form_Keyboard m_InstnaceOfKeyboard = null;
        private FrameOfSystem3.Views.Functional.Form_SelectionList m_InstanceOfSelection = null;

        #endregion /Field

        #region Const
        private readonly Color c_clrTrue = Color.Green;
        private readonly Color c_clrFalse = Color.White;
        private readonly Color c_clrDisable = Color.Gray;
        private readonly Color c_clrProcessParam = Color.SteelBlue;
        private readonly Color c_clrEquipmentrParam = Color.LightGray;
        private readonly Color c_clrHighlight = Color.DimGray;
        #endregion /Const

        #region Property
        [Category("Control"), Description("")]
        public bool Control_Enable { get { return m_bControl_Enable; } set { m_bControl_Enable = value; } }
        [Category("Control"), Description("")]
        public List<ParameterItem> controlCollection { get { return m_ControlCollection; } set { m_ControlCollection = value; } }
        #endregion /Property

        #region Method
        public void Initialize(List<ParameterItem> lstItem = null, int nViewCount = -1, int nValueWidth = 100)
        {
            if (nViewCount == -1)
                nViewCount = lstItem.Count;
            base.Height = nViewCount * 25 + 3;
            //control hight는 (List 갯수 * 25) + 3
            if (m_bControl_Enable)
                dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);

            m_InstanceRecipe = Recipe.Recipe.GetInstance();
            m_InstanceOfMessageBox = FrameOfSystem3.Views.Functional.Form_MessageBox.GetInstance();
            m_InstnaceOfCalculator = FrameOfSystem3.Views.Functional.Form_Calculator.GetInstance();
            m_InstnaceOfKeyboard = FrameOfSystem3.Views.Functional.Form_Keyboard.GetInstance();
            m_InstanceOfSelection = FrameOfSystem3.Views.Functional.Form_SelectionList.GetInstance();

            if (lstItem != null)
                m_ControlCollection = lstItem;
            dataGridView.Rows.Clear();

            int nColumnCount = 2;
            foreach (ParameterItem Item in m_ControlCollection)
            {
                nColumnCount = nColumnCount < Item.ParameterNameList.Count + 1 ? Item.ParameterNameList.Count + 1 : nColumnCount;
            }
            dataGridView.ColumnCount = nColumnCount;
            for (int i = 1; i < nColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns[i].Width = nValueWidth;
                dataGridView.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                dataGridView.Columns[i].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            }
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            int nRow = 0;
            foreach (ParameterItem Item in m_ControlCollection)
            {
                dataGridView.Rows.Add();
                if (Item.DisplayName == "")
                {
                    dataGridView[0, nRow].Value = Item.ParameterNameList[0].Replace("_", " ");
                }
                else
                {
                    dataGridView[0, nRow].Value = Item.DisplayName;
                }
                for (int i = 0; i < Item.ParameterNameList.Count; i++)
                {
                    if (Item.ParameterNameList[i] == "")
                    {
                        dataGridView[1 + i, nRow].Style.BackColor = c_clrDisable;
                        dataGridView[1 + i, nRow].Style.SelectionBackColor = c_clrDisable;
                        continue;
                    }
                    string strValue = "";
                    bool bDeferred = false;
                    if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                    {
                        if (m_InstanceRecipe.GetDeferredStorage(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], out strValue))
                            bDeferred = true;
                    }
                    else
                    {
                        if (m_InstanceRecipe.GetDeferredStorage(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], out strValue))
                            bDeferred = true;
                    }
                    dataGridView[1 + i, nRow].Style.ForeColor = bDeferred ? Color.Red : Color.Black;
                    dataGridView[1 + i, nRow].Style.SelectionForeColor = bDeferred ? Color.Red : Color.Black;

                    if (Item.ParameterSettingType == EN_PARAMETER_SETTING_TYPE.TRUE_FALSE)
                    {
                        bool bValue = true;

                        if (bDeferred)
                        {
                            bool.TryParse(strValue, out bValue);
                        }
                        else
                        {
                            if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                bValue = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, true);
                            }
                            else
                            {
                                bValue = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, true);
                            }
                        }
                
                        dataGridView[1 + i, nRow].Style.BackColor = bValue ? c_clrTrue : c_clrFalse;
                        dataGridView[1 + i, nRow].Style.SelectionBackColor = bValue ? c_clrTrue : c_clrFalse;

                        if (Item.TrueFalseName.Count > i && Item.TrueFalseName[i] != string.Empty)
                        {
                            dataGridView[1 + i, nRow].Value = Item.TrueFalseName[i];
                            dataGridView[1 + i, nRow].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            dataGridView[1 + i, nRow].Value = bValue ? "ON" : "OFF"; 
                            dataGridView[1 + i, nRow].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    else if (Item.ParameterSettingType == EN_PARAMETER_SETTING_TYPE.COLOR)
                    {
                        //color 애매한데 저장시 업데이트 로 유지하자.
                        int nValue = 0;
                        if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                            nValue = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        else
                            nValue = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        Color cValue = Color.FromArgb(nValue);

                        dataGridView[1 + i, nRow].Style.BackColor = cValue;
                        dataGridView[1 + i, nRow].Style.SelectionBackColor = cValue;
                    }
                    else
                    {
                        if (bDeferred)
                        {
                            dataGridView[1 + i, nRow].Value = strValue + " "
                                    + m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.UNIT, "");
                        }
                        else
                        {
                            if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                                dataGridView[1 + i, nRow].Value = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, "") + " "
                                    + m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.UNIT, "");
                            else
                                dataGridView[1 + i, nRow].Value = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, "") + " "
                                    + m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.UNIT, "");
                        }
                    }
                  
                }

                dataGridView[0, nRow].Style.BackColor = Item.RecipeType == EN_RECIPE_TYPE.PROCESS ? c_clrProcessParam : c_clrEquipmentrParam;
                dataGridView[0, nRow].Style.SelectionBackColor = Item.RecipeType == EN_RECIPE_TYPE.PROCESS ? c_clrProcessParam : c_clrEquipmentrParam;
               
                if (!Item.Enable)
                {
                   
                    for (int Col = 1; Col < nColumnCount; Col++)
                    {
                        dataGridView[Col, nRow].Style.BackColor = c_clrDisable;
                        dataGridView[Col, nRow].Style.SelectionBackColor = c_clrDisable;
                    }
                }
                nRow++;
            }
        }

        public void ShowHeader(List<string> lstHeaderName)
        {
            dataGridView.ColumnHeadersVisible = true;
            base.Height += 25;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            for (int i = 0; i < lstHeaderName.Count; i++ )
            {
                dataGridView.Columns[i].HeaderText = lstHeaderName[i];
            }
        }

        public void UpdateValue()
        {
            int nRow = 0;
            foreach (ParameterItem Item in m_ControlCollection)
            {
                for (int i = 0; i < Item.ParameterNameList.Count; i++)
                {
                    if (Item.ParameterNameList[i] == "")
                    {
                        dataGridView[1 + i, nRow].Style.BackColor = c_clrDisable;
                        dataGridView[1 + i, nRow].Style.SelectionBackColor = c_clrDisable;
                        continue;
                    }
                    string strValue = "";
                    bool bDeferred = false;
                    if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                    {
                        if (m_InstanceRecipe.GetDeferredStorage(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], out strValue))
                            bDeferred = true;
                    }
                    else
                    {
                        if (m_InstanceRecipe.GetDeferredStorage(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], out strValue))
                            bDeferred = true;
                    }
                    dataGridView[1 + i, nRow].Style.ForeColor = bDeferred ? Color.Red : Color.Black;
                    dataGridView[1 + i, nRow].Style.SelectionForeColor = bDeferred ? Color.Red : Color.Black;


                    if (Item.ParameterSettingType == EN_PARAMETER_SETTING_TYPE.TRUE_FALSE)
                    {
                        bool bValue = true;
                        if (bDeferred)
                        {
                            bool.TryParse(strValue, out bValue);
                        }
                        else
                        {
                            if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                                bValue = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, true);
                            else
                                bValue = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, true);
                        }
                        dataGridView[1 + i, nRow].Style.BackColor = bValue ? c_clrTrue : c_clrFalse;
                        dataGridView[1 + i, nRow].Style.SelectionBackColor = bValue ? c_clrTrue : c_clrFalse;


                        if (Item.TrueFalseName.Count > i && Item.TrueFalseName[i] != string.Empty)
                        {
                            
                        }
                        else
                        {
                            dataGridView[1 + i, nRow].Value = bValue ? "ON" : "OFF";
                            dataGridView[1 + i, nRow].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    else if (Item.ParameterSettingType == EN_PARAMETER_SETTING_TYPE.COLOR)
                    {
                        int nValue = 0;
                        if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                            nValue = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        else
                            nValue = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        Color cValue = Color.FromArgb(nValue);

                        dataGridView[1 + i, nRow].Style.BackColor = cValue;
                        dataGridView[1 + i, nRow].Style.SelectionBackColor = cValue;
                    }
                    else
                    {
                        double dValue = 0;
                        string strUnit = "";
                        if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                        {
                            strUnit = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.UNIT, "");
                        }
                        else
                        {
                            strUnit = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.UNIT, "");
                        }

                        if (bDeferred == false)
                        {
                            if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                strValue = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, "");
                            }
                            else
                            {
                                strValue = m_InstanceRecipe.GetValue(Item.RecipeType, Item.ParameterNameList[i], Item.ParameterIndexList[i], EN_RECIPE_PARAM_TYPE.VALUE, "");
                            }
                        }
                      
                        if (double.TryParse(strValue, out dValue))
                        {
                            strValue = Math.Round(dValue, 3).ToString();
                        }
                        if (strUnit != "")
                        {
                            strUnit = " " + strUnit;
                        }
                        dataGridView[1 + i, nRow].Value = strValue + strUnit;
                    }
                }
                nRow++;
            }
        }
        #endregion /Method

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EquipmentState_.EquipmentState.GetInstance().GetState() != EquipmentState_.EQUIPMENT_STATE.IDLE)
                return;


            int nRowindex = e.RowIndex;
            int nColumnIndex = e.ColumnIndex;
            int nParaIndex = nColumnIndex - 1;
            if (nRowindex < 0 || nRowindex >= dataGridView.RowCount) { return; }

            if (!m_ControlCollection[nRowindex].Enable)
                return;

            if (m_ControlCollection[nRowindex].BeforeSetParameter != null)
                m_ControlCollection[nRowindex].BeforeSetParameter();

            switch (nColumnIndex)
            {
                default:
                    if (m_ControlCollection[nRowindex].ParameterNameList[nParaIndex] == "")
                        return;

                    string strTitle = m_ControlCollection[nRowindex].ParameterNameList[nParaIndex].Replace("_", " ");

                    string strResult = string.Empty;

                    switch (m_ControlCollection[nRowindex].ParameterSettingType)
                    {
                        case EN_PARAMETER_SETTING_TYPE.CALCULATE:
                            double dOldVal = 0;
                            double dOldMin = 0;
                            double dOldMax = 0;
                            string strOldUnit = "";
                            if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                dOldVal = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                                dOldMin = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MIN, 0.0);
                                dOldMax = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MAX, 0.0);
                                strOldUnit = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.UNIT, "");
                            }
                            else
                            {
                                dOldVal = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                                dOldMin = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MIN, 0.0);
                                dOldMax = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MAX, 0.0);
                                strOldUnit = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.UNIT, "");
                            }

                            if (m_InstnaceOfCalculator.CreateForm(dOldVal.ToString(), dOldMin.ToString(), dOldMax.ToString(), strOldUnit, strTitle))
                            {
                                double dVal = 0;
                                double dMin = 0;
                                double dMax = 0;
                                string strUnit = "";
                                m_InstnaceOfCalculator.GetMin(ref dMin);
                                m_InstnaceOfCalculator.GetMax(ref dMax);
                                m_InstnaceOfCalculator.GetUnit(ref strUnit);
                                if (dMin != dOldMin)
                                {
                                    if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                                    {
                                        m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MIN, dMin.ToString());
                                         
                                    }
                                    else
                                    {
                                        m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MIN, dMin.ToString());
                                    }
                                }
                                if (dMax != dOldMax)
                                {
                                    if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                                    {
                                        m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MAX, dMax.ToString());
                                    }
                                    else
                                    {
                                        m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.MAX, dMax.ToString());
                                    }
                                }
                                if (strOldUnit != strUnit)
                                {
                                    if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                                    {
                                        m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.UNIT, strUnit);
                                    }
                                    else
                                    {
                                        m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.UNIT, strUnit);
                                    }
                                }
                                m_InstnaceOfCalculator.GetResult(ref dVal);
                                strResult = dVal.ToString();
                            }
                            else
                                return;

                            break;
                        case EN_PARAMETER_SETTING_TYPE.KEYBOARD:
                            if (m_InstnaceOfKeyboard.CreateForm(strTitle) == false)
                                return;

                            m_InstnaceOfKeyboard.GetResult(ref strResult);
                            break;
                        case EN_PARAMETER_SETTING_TYPE.SELECT:
                            string strOldValue = "";
                            if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                strOldValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, "");
                            }
                            else
                            {
                                strOldValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, "");
                            }

                            if (false == m_InstanceOfSelection.CreateForm(strTitle, m_ControlCollection[nRowindex].SelectionList, strOldValue))
                                return;

                            m_InstanceOfSelection.GetResult(ref strResult);
                            break;
                        case EN_PARAMETER_SETTING_TYPE.FOLDER_DIALOG:
                            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
                            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                            {
                                dlg.Dispose();
                                return;
                            }
                            strResult = dlg.SelectedPath;
                            dlg.Dispose();
                            break;
                        case EN_PARAMETER_SETTING_TYPE.TRUE_FALSE:
                            bool bOld = true;
                            string strOld = "";
                            if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                m_InstanceRecipe.GetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], out strOld);
                               // bOld = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, true);
                            }
                            else
                            {
                                m_InstanceRecipe.GetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], out strOld);
                               // bOld = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, true);
                            }
                             bool.TryParse(strOld, out bOld);
                            strResult = bOld ? "False" : "True";
                            break;
                        case EN_PARAMETER_SETTING_TYPE.COLOR:
                             ColorDialog cd = new ColorDialog();

                             if (cd.ShowDialog() != DialogResult.OK)
                             {
                                 return;
                             }

                             strResult = cd.Color.ToArgb().ToString();
                            break;
                        default:
                            return;

                    }


                    if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                    {
                            if (m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], strResult))
                            {
                                if (m_ControlCollection[nRowindex].AfterSetParameter != null)
                                {
                                    m_ControlCollection[nRowindex].AfterSetParameter();
                                }
                            }

//                         if (m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, strResult))
//                         {
// //                             if(m_ControlCollection[nRowindex].NeedRemakeMap)
// //                                 Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
//                             if (m_ControlCollection[nRowindex].AfterSetParameter != null)
//                             {
//                                 m_ControlCollection[nRowindex].AfterSetParameter();
//                             }
//                         }
                    }
                    else
                    {
                        if (m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], strResult))
                        {
                            //                            if(m_ControlCollection[nRowindex].NeedRemakeMap)
                            //                                 Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
                            if (m_ControlCollection[nRowindex].AfterSetParameter != null)
                            {
                                m_ControlCollection[nRowindex].AfterSetParameter();
                            }
                        }

//                         if (m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].ParameterNameList[nParaIndex], m_ControlCollection[nRowindex].ParameterIndexList[nParaIndex], EN_RECIPE_PARAM_TYPE.VALUE, strResult))
//                         {
// //                            if(m_ControlCollection[nRowindex].NeedRemakeMap)
// //                                 Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
//                             if (m_ControlCollection[nRowindex].AfterSetParameter != null)
//                             {
//                                 m_ControlCollection[nRowindex].AfterSetParameter();
//                             }
//                         }
                    }
                    break;
                case 0:
                    return;
            }
           
            UpdateValue();
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int nRowindex = e.RowIndex;

            if (nRowindex < 0) return;

            dataGridView[0, nRowindex].Style.BackColor = c_clrHighlight;
            dataGridView[0, nRowindex].Style.SelectionBackColor = c_clrHighlight;

        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int nRowindex = e.RowIndex;

            if (nRowindex < 0) return;

            dataGridView[0, nRowindex].Style.BackColor = m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS ? c_clrProcessParam : c_clrEquipmentrParam;
            dataGridView[0, nRowindex].Style.SelectionBackColor = m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS ? c_clrProcessParam : c_clrEquipmentrParam;
        }
    }
}
