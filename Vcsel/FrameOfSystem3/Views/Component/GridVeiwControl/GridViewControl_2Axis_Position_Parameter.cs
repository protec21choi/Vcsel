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

namespace FrameOfSystem3.Component
{
    public partial class GridViewControl_2Axis_Position_Parameter : UserControl
    {
        public delegate double DelGetOffsetValue();
        public delegate void DelDrawMap();

        public GridViewControl_2Axis_Position_Parameter()
        {
            InitializeComponent();

            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance
                                        | BindingFlags.SetProperty, null, dataGridView, new object[] { true });  
        }
       
        #region Inner class
        public class ControlItem
        {
            public ControlItem(PARAM_COMMON enFirstRecipe, int nFirstAxisIndex, PARAM_COMMON enSecondRecipe, int nSecondAxisIndex, int nParameterIndex = 0)
            {
                m_enRecipeType = EN_RECIPE_TYPE.COMMON;
                m_strFirstParameterName = enFirstRecipe.ToString();
                m_strSecondParameterName = enSecondRecipe.ToString();
                m_nFirstAxisIndex = nFirstAxisIndex;
                m_nSecondAxisIndex = nSecondAxisIndex;
                m_nParameterIndex = nParameterIndex;
            }
            public ControlItem(PARAM_EQUIPMENT enFirstRecipe, int nFirstAxisIndex, PARAM_EQUIPMENT enSecondRecipe, int nSecondAxisIndex, int nParameterIndex = 0)
            {
                m_enRecipeType = EN_RECIPE_TYPE.EQUIPMENT;
                m_strFirstParameterName = enFirstRecipe.ToString();
                m_strSecondParameterName = enSecondRecipe.ToString();
                m_nFirstAxisIndex = nFirstAxisIndex;
                m_nSecondAxisIndex = nSecondAxisIndex;
                m_nParameterIndex = nParameterIndex;
            }
            public ControlItem(EN_TASK_LIST enTask, string strFirstParameterName, int nFirstAxisIndex, string strSecondParameterName, int nSecondAxisIndex, int nParameterIndex = 0)
            {
                m_enRecipeType = EN_RECIPE_TYPE.PROCESS;
                m_enTask = enTask;
                m_strFirstParameterName = strFirstParameterName;
                m_strSecondParameterName = strSecondParameterName;
                m_nFirstAxisIndex = nFirstAxisIndex;
                m_nSecondAxisIndex = nSecondAxisIndex;
                m_nParameterIndex = nParameterIndex;
            }

            private bool m_bEnable = true;
            private EN_RECIPE_TYPE m_enRecipeType = EN_RECIPE_TYPE.PROCESS; //동일하게 사용
            private EN_TASK_LIST m_enTask = EN_TASK_LIST.BOND_HEAD;//동일하게 사용
            private string m_strFirstParameterName = "";
            private string m_strSecondParameterName = "";
            private int m_nParameterIndex = 0;
            private int m_nFirstAxisIndex = -1;
            private int m_nSecondAxisIndex = -1;
            private string m_strFirstAxisName = "";
            private string m_strSecondAxisName = "";
            private string m_strDisplayName = "";
            private bool m_bNeedRemakeMap = false;
            private EN_REFERANCE_MAP_LIST m_enReferanceMap = EN_REFERANCE_MAP_LIST.MATERIAL_BOND;
            private DelDrawMap delDwawMap = null;
            private DelGetOffsetValue delGetFirstAxisOffsetValue = null;
            private DelGetOffsetValue delGetSecondAxisOffsetValue = null;
            private string m_strMoveConfirmMessage = "DO YOU WANT MOVE " ;

            public bool Enable { get { return m_bEnable; } set { m_bEnable = value; } }
            public EN_RECIPE_TYPE RecipeType { get { return m_enRecipeType; } set { m_enRecipeType = value; } }
            public EN_TASK_LIST Task { get { return m_enTask; } set { m_enTask = value; } }
            public string FirstParameterName { get { return m_strFirstParameterName; } set { m_strFirstParameterName = value; } }
            public string SecondParameterName { get { return m_strSecondParameterName; } set { m_strSecondParameterName = value; } }
            public int ParameterIndex { get { return m_nParameterIndex; } set { m_nParameterIndex = value; } }
            public int FirstAxisIndex { get { return m_nFirstAxisIndex; } set { m_nFirstAxisIndex = value; } }
            public int SecondAxisIndex { get { return m_nSecondAxisIndex; } set { m_nSecondAxisIndex = value; } }
            public string FirstAxisName { get { return m_strFirstAxisName; } set { m_strFirstAxisName = value; } }
            public string SecondAxisName { get { return m_strSecondAxisName; } set { m_strSecondAxisName = value; } }
            public string DisplayName { get { return m_strDisplayName; } set { m_strDisplayName = value; } }
            public bool NeedRemakeMap { get { return m_bNeedRemakeMap; } set { m_bNeedRemakeMap = value; } }
            public EN_REFERANCE_MAP_LIST ReferanceMap { get { return m_enReferanceMap; } set { m_enReferanceMap = value; } }
            public DelDrawMap DrawMap { get { return delDwawMap; } set { delDwawMap = value; } }
            public DelGetOffsetValue GetFirstAxisOffsetValue { get { return delGetFirstAxisOffsetValue; } set { delGetFirstAxisOffsetValue = value; } }
            public DelGetOffsetValue GetSecondAxisOffsetValue { get { return delGetSecondAxisOffsetValue; } set { delGetSecondAxisOffsetValue = value; } }

            public string MoveConfirmMessage { get { return m_strMoveConfirmMessage; } set { m_strMoveConfirmMessage = value; } }

        }
        #endregion

        #region Field
        private List<ControlItem> m_ControlCollection;
        private FrameOfSystem3.Config.ConfigMotion m_InstanceMotion;
        private Recipe.Recipe m_InstanceRecipe;
        private bool m_bControl_Enable = true;
        private FrameOfSystem3.Views.Functional.Form_MessageBox m_InstanceOfMessageBox = null;
        private FrameOfSystem3.Views.Functional.Form_Calculator m_InstnaceOfCalculator = null;

        #endregion /Field

        #region Const
        private readonly Color c_clrDisable = Color.Gray;
        private readonly Color c_clrProcessParam = Color.SteelBlue;
        private readonly Color c_clrEquipmentrParam = Color.LightGray;
        private readonly Color c_clrAxisName = Color.LightGray;
        private readonly Color c_clrHighlight = Color.DimGray;
        
        #endregion /Const

        #region Property
        [Category("Control"), Description("")]
        public bool Control_Enable { get { return m_bControl_Enable; } set { m_bControl_Enable = value; } }
        [Category("Control"), Description("")]
        public List<ControlItem> controlCollection { get { return m_ControlCollection; } set { m_ControlCollection = value; } }
        #endregion /Property

        #region Method
        public void Initialize(List<ControlItem> lstItem = null, int nViewCount = -1, int AxisNameWidth = 100)
        {
            if(nViewCount == -1)
                nViewCount = lstItem.Count;
            base.Height = nViewCount * 25 + 3;
            //control hight는 (List 갯수 * 25) + 3
            if (m_bControl_Enable)
                dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);

            m_InstanceMotion = FrameOfSystem3.Config.ConfigMotion.GetInstance();
            m_InstanceRecipe = Recipe.Recipe.GetInstance();
            m_InstanceOfMessageBox = FrameOfSystem3.Views.Functional.Form_MessageBox.GetInstance();
            m_InstnaceOfCalculator = FrameOfSystem3.Views.Functional.Form_Calculator.GetInstance();

            if (lstItem != null)
                m_ControlCollection = lstItem;

            dataGridView.Columns[1].Width = AxisNameWidth;
            dataGridView.Columns[3].Width = AxisNameWidth;

            dataGridView.Rows.Clear();
            int nRow = 0;
            foreach (ControlItem Item in m_ControlCollection)
            {
                dataGridView.Rows.Add();
                if (Item.DisplayName == "")
                {
                    dataGridView[0, nRow].Value = Item.FirstParameterName;
                }
                else
                {
                    dataGridView[0, nRow].Value = Item.DisplayName;
                }

                if (Item.FirstAxisName == "")
                {
                    dataGridView[1, nRow].Value = m_InstanceMotion.GetName(Item.FirstAxisIndex).Replace("_", " ");
                }
                else
                {
                    dataGridView[1, nRow].Value = Item.FirstAxisName;
                }

                if (Item.SecondAxisName == "")
                {
                    dataGridView[3, nRow].Value = m_InstanceMotion.GetName(Item.SecondAxisIndex).Replace("_", " ");
                }
                else
                {
                    dataGridView[3, nRow].Value = Item.SecondAxisName;
                }

                string strValue = "";
                double dValue = 0;
                if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.Task.ToString(), Item.FirstParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[2, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Red;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[2, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Black;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }
                else
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.RecipeType, Item.FirstParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[2, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Red;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[2, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.RecipeType, Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Black;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }

                if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.Task.ToString(), Item.SecondParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[4, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Red;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[4, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Black;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }
                else
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.RecipeType, Item.SecondParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[4, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Red;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[4, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.RecipeType, Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Black;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }

//                 if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
//                     dataGridView[2, nRow].Value = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0) + " mm";
//                 else
//                     dataGridView[2, nRow].Value = m_InstanceRecipe.GetValue(Item.RecipeType, Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0) + " mm";
// 
//                 if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
//                     dataGridView[4, nRow].Value = m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0) + " mm";
//                 else
//                     dataGridView[4, nRow].Value = m_InstanceRecipe.GetValue(Item.RecipeType, Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0) + " mm";
//                 
                dataGridView[0, nRow].Style.BackColor = Item.RecipeType == EN_RECIPE_TYPE.PROCESS ? c_clrProcessParam : c_clrEquipmentrParam;
                dataGridView[0, nRow].Style.SelectionBackColor = Item.RecipeType == EN_RECIPE_TYPE.PROCESS ? c_clrProcessParam : c_clrEquipmentrParam;

                dataGridView[1, nRow].Style.BackColor = c_clrAxisName;
                dataGridView[1, nRow].Style.SelectionBackColor = c_clrAxisName;

                dataGridView[3, nRow].Style.BackColor = c_clrAxisName;
                dataGridView[3, nRow].Style.SelectionBackColor = c_clrAxisName;


                if (Item.Enable)
                {
                    DataGridViewButtonCell MoveButton = new DataGridViewButtonCell();
                    MoveButton.Value = "MOVE";
                    dataGridView[5, nRow] = MoveButton;

                    DataGridViewButtonCell SetButton = new DataGridViewButtonCell();
                    SetButton.Value = "SET";
                    dataGridView[6, nRow] = SetButton;
                }
                else
                {
                    dataGridView[2, nRow].Style.BackColor = c_clrDisable;
                    dataGridView[2, nRow].Style.SelectionBackColor = c_clrDisable;
                    dataGridView[4, nRow].Style.BackColor = c_clrDisable;
                    dataGridView[4, nRow].Style.SelectionBackColor = c_clrDisable;
                    dataGridView[5, nRow].Style.BackColor = c_clrDisable;
                    dataGridView[5, nRow].Style.SelectionBackColor = c_clrDisable;
                    dataGridView[6, nRow].Style.BackColor = c_clrDisable;
                    dataGridView[6, nRow].Style.SelectionBackColor = c_clrDisable;
                }
                nRow++;
            }
        }

        public void UpdateValue() 
        {
            int nRow = 0;
            foreach (ControlItem Item in m_ControlCollection)
            {
                string strValue = "";
                double dValue = 0;
                if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.Task.ToString(), Item.FirstParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[2, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Red;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[2, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Black;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }
                else
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.RecipeType, Item.FirstParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[2, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Red;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[2, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.RecipeType, Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[2, nRow].Style.ForeColor = Color.Black;
                        dataGridView[2, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }

                if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.Task.ToString(), Item.SecondParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[4, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Red;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[4, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Black;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }
                else
                {
                    if (m_InstanceRecipe.GetDeferredStorage(Item.RecipeType, Item.SecondParameterName, Item.ParameterIndex, out strValue))
                    {
                        double.TryParse(strValue, out dValue);

                        dataGridView[4, nRow].Value = Math.Round(dValue, 3).ToString() + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Red;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView[4, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.RecipeType, Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
                        dataGridView[4, nRow].Style.ForeColor = Color.Black;
                        dataGridView[4, nRow].Style.SelectionForeColor = Color.Black;
                    }
                }

//                 if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
//                     dataGridView[2, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
//                 else
//                     dataGridView[2, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.RecipeType, Item.FirstParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
// 
//                 if (Item.RecipeType == EN_RECIPE_TYPE.PROCESS)
//                     dataGridView[4, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.Task.ToString(), Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";
//                 else
//                     dataGridView[4, nRow].Value = Math.Round(m_InstanceRecipe.GetValue(Item.RecipeType, Item.SecondParameterName, Item.ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0), 3) + " mm";

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

            if (nRowindex < 0 || nRowindex >= dataGridView.RowCount) { return; }

            if (!m_ControlCollection[nRowindex].Enable)
                return;

            switch (nColumnIndex)
            {
                case 2: //SetValue by Calculator
                case 4: //SetValue by Calculator
                    string ParameterName = nColumnIndex == 2 ? m_ControlCollection[nRowindex].FirstParameterName : m_ControlCollection[nRowindex].SecondParameterName;
                    double dOldVal = 0;
                    double dOldMin = 0;
                    double dOldMax = 0;
                    string strOldUnit = "";
                    if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                    {
                        dOldVal = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        dOldMin = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MIN, 0.0);
                        dOldMax = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MAX, 0.0);
                        strOldUnit = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.UNIT, "");
                    }
                    else
                    {
                        dOldVal = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        dOldMin = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MIN, 0.0);
                        dOldMax = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MAX, 0.0);
                        strOldUnit = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.UNIT, "");
                    }

                    if (m_InstnaceOfCalculator.CreateForm(dOldVal.ToString(), dOldMin.ToString(), dOldMax.ToString(), strOldUnit))
                    {
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
                                m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MIN, dMin.ToString());
                            }
                            else
                            {
                                m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MIN, dMin.ToString());
                            }
                        }
                        if (dMax != dOldMax)
                        {
                            if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MAX, dMax.ToString());
                            }
                            else
                            {
                                m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.MAX, dMax.ToString());
                            }
                        }
                        if (strUnit != "mm")
                        {
                            if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                            {
                                m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.UNIT, "mm");
                            }
                            else
                            {
                                m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.UNIT, "mm");
                            }
                        }
                        double dVal = 0;
                        m_InstnaceOfCalculator.GetResult(ref dVal);
                        if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                        {
//                             if (m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, dVal.ToString())
//                                 && m_ControlCollection[nRowindex].NeedRemakeMap)
//                             {
//                                 //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
//                                 if (m_ControlCollection[nRowindex].DrawMap != null)
//                                 {
//                                     m_ControlCollection[nRowindex].DrawMap();
//                                 }
//                             }

                            if (m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), ParameterName, m_ControlCollection[nRowindex].ParameterIndex, dVal.ToString())
                             && m_ControlCollection[nRowindex].NeedRemakeMap)
                            {
                                //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
                                if (m_ControlCollection[nRowindex].DrawMap != null)
                                {
                                    m_ControlCollection[nRowindex].DrawMap();
                                }
                            }
                        }
                        else
                        {
                            if (m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, dVal.ToString())
                                    && m_ControlCollection[nRowindex].NeedRemakeMap)
                            {
                                //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);

                                if (m_ControlCollection[nRowindex].DrawMap != null)
                                {
                                    m_ControlCollection[nRowindex].DrawMap();
                                }
                            }
//                             if (m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, ParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, dVal.ToString())
//                                      && m_ControlCollection[nRowindex].NeedRemakeMap)
//                             {
//                                 //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
// 
//                                 if (m_ControlCollection[nRowindex].DrawMap != null)
//                                 {
//                                     m_ControlCollection[nRowindex].DrawMap();
//                                 }
//                             }
                        }

                    }
                    break;
                case 5: //Move
                    {
                        double dFirstParameterValue = 0;
                        double dFirstOffset = 0;
                        double dFirstPositon = 0;

                        double dSecondParameterValue = 0;
                        double dSecondOffset = 0;
                        double dSecondPositon = 0;

                        if (m_ControlCollection[nRowindex].MoveConfirmMessage != "")
                        {
                              string strPara = "";

                            if (m_ControlCollection[nRowindex].DisplayName == "")
                            {
                                strPara = m_ControlCollection[nRowindex].FirstParameterName.Replace("_", " ");
                            }
                            else
                            {
                                strPara = m_ControlCollection[nRowindex].DisplayName;
                            }

                            if (!m_InstanceOfMessageBox.ShowMessage(m_ControlCollection[nRowindex].MoveConfirmMessage + strPara + "?", "MOVE CONFIRM"))
                            {
                                return;
                            }
                        }

                        if (m_ControlCollection[nRowindex].GetFirstAxisOffsetValue != null)
                        {
                            dFirstOffset = m_ControlCollection[nRowindex].GetFirstAxisOffsetValue();
                        }
                        if (m_ControlCollection[nRowindex].GetSecondAxisOffsetValue != null)
                        {
                            dSecondOffset = m_ControlCollection[nRowindex].GetSecondAxisOffsetValue();
                        }

                        string strValue = "";
                        if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                        {
                            if (m_InstanceRecipe.GetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, out strValue))
                            {
                                double.TryParse(strValue, out dFirstParameterValue);
                            }
                            else
                            {
                                dFirstParameterValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            }
                          //  dFirstParameterValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        }
                        else
                        {
                            if (m_InstanceRecipe.GetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, out strValue))
                            {
                                double.TryParse(strValue, out dFirstParameterValue);
                            }
                            else
                            {
                                dFirstParameterValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            }
                            //dFirstParameterValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        }
                        if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                        {
                            if (m_InstanceRecipe.GetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, out strValue))
                            {
                                double.TryParse(strValue, out dSecondParameterValue);
                            }
                            else
                            {
                                dSecondParameterValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            }
                        }
                        else
                        {
                            if (m_InstanceRecipe.GetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, out strValue))
                            {
                                double.TryParse(strValue, out dSecondParameterValue);
                            }
                            else
                            {
                                dSecondParameterValue = m_InstanceRecipe.GetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            }
                        }

                        dFirstPositon = dFirstParameterValue + dFirstOffset;
                        dSecondPositon = dSecondParameterValue + dSecondOffset;

                        Motion_.MOTION_RESULT enFirstResult = m_InstanceMotion.MoveAbsolutely(m_ControlCollection[nRowindex].FirstAxisIndex, dFirstPositon, Motion_.MOTION_SPEED_CONTENT.MANUAL, 100, 100);
                        Motion_.MOTION_RESULT enSecondResult = m_InstanceMotion.MoveAbsolutely(m_ControlCollection[nRowindex].SecondAxisIndex, dSecondPositon, Motion_.MOTION_SPEED_CONTENT.MANUAL, 100, 100);

                        string FirstAxisName = m_InstanceMotion.GetName(m_ControlCollection[nRowindex].FirstAxisIndex);
                        switch (enFirstResult)
                        {
                            case Motion_.MOTION_RESULT.OK:
                                break;

                            case Motion_.MOTION_RESULT.OCCUR_INTERLOCK:
                                string strInterlockInformation = Config.ConfigInterlock.GetInstance().GetMotionLastInterference(m_ControlCollection[nRowindex].FirstAxisIndex);
                                m_InstanceOfMessageBox.ShowMessage(strInterlockInformation, FirstAxisName + " OCCUR INTERLOCK");
                                break;
                            default:
                                m_InstanceOfMessageBox.ShowMessage(enFirstResult.ToString(), FirstAxisName + " MOVE FAIL");
                                break;
                        }

                        string SecondAxisName = m_InstanceMotion.GetName(m_ControlCollection[nRowindex].SecondAxisIndex);
                        switch (enSecondResult)
                        {
                            case Motion_.MOTION_RESULT.OK:
                                break;

                            case Motion_.MOTION_RESULT.OCCUR_INTERLOCK:
                                string strInterlockInformation = Config.ConfigInterlock.GetInstance().GetMotionLastInterference(m_ControlCollection[nRowindex].SecondAxisIndex);
                                m_InstanceOfMessageBox.ShowMessage(strInterlockInformation, SecondAxisName + " OCCUR INTERLOCK");
                                break;
                            default:
                                m_InstanceOfMessageBox.ShowMessage(enFirstResult.ToString(), SecondAxisName + " MOVE FAIL");
                                break;
                        }
                        break;
                    }
                case 6: //SetValue Current Position
                    {
                        double dFirstAxisCurrentPosiotn = m_InstanceMotion.GetActualPosition(m_ControlCollection[nRowindex].FirstAxisIndex);
                        double dFirstOffset = 0;
                        if (m_ControlCollection[nRowindex].GetFirstAxisOffsetValue != null)
                        {
                            dFirstOffset = m_ControlCollection[nRowindex].GetFirstAxisOffsetValue();
                        }

                        double dFirstVal = dFirstAxisCurrentPosiotn - dFirstOffset;

                        double dSecondAxisCurrentPosiotn = m_InstanceMotion.GetActualPosition(m_ControlCollection[nRowindex].SecondAxisIndex);
                        double dSecondOffset = 0;
                        if (m_ControlCollection[nRowindex].GetSecondAxisOffsetValue != null)
                        {
                            dSecondOffset = m_ControlCollection[nRowindex].GetSecondAxisOffsetValue();
                        }

                        double dSecondVal = dSecondAxisCurrentPosiotn - dSecondOffset;

                        if (m_ControlCollection[nRowindex].RecipeType == EN_RECIPE_TYPE.PROCESS)
                        {
                            if (m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, dFirstVal.ToString())
                                && m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, dSecondVal.ToString())
                                && m_ControlCollection[nRowindex].NeedRemakeMap)
                            {
                                //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);

                                if (m_ControlCollection[nRowindex].DrawMap != null)
                                {
                                    m_ControlCollection[nRowindex].DrawMap();
                                }
                            }

//                             if (m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, dFirstVal.ToString())
//                                && m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].Task.ToString(), m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, dSecondVal.ToString())
//                                && m_ControlCollection[nRowindex].NeedRemakeMap)
//                             {
//                                 //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
// 
//                                 if (m_ControlCollection[nRowindex].DrawMap != null)
//                                 {
//                                     m_ControlCollection[nRowindex].DrawMap();
//                                 }
//                             }
                        }
                        else
                        {
                            if (m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, dFirstVal.ToString())
                               && m_InstanceRecipe.SetDeferredStorage(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, dSecondVal.ToString())
                               && m_ControlCollection[nRowindex].NeedRemakeMap)
                            {
                                //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);

                                if (m_ControlCollection[nRowindex].DrawMap != null)
                                {
                                    m_ControlCollection[nRowindex].DrawMap();
                                }
                            }

//                             if (m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].FirstParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, dFirstVal.ToString())
//                                 && m_InstanceRecipe.SetValue(m_ControlCollection[nRowindex].RecipeType, m_ControlCollection[nRowindex].SecondParameterName, m_ControlCollection[nRowindex].ParameterIndex, EN_RECIPE_PARAM_TYPE.VALUE, dSecondVal.ToString())
//                                 && m_ControlCollection[nRowindex].NeedRemakeMap)
//                             {
//                                 //Work.ReferanceMap.ReferanceMapManager.GetInstance().CreateMap(m_ControlCollection[nRowindex].ReferanceMap);
// 
//                                 if (m_ControlCollection[nRowindex].DrawMap != null)
//                                 {
//                                     m_ControlCollection[nRowindex].DrawMap();
//                                 }
//                             }
                        }
                        break;
                    }
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
