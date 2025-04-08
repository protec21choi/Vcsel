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

namespace FrameOfSystem3.Component
{
    public partial class GridVeiwControl_Device : UserControl
    {
        public GridVeiwControl_Device()
        {
            InitializeComponent();

            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance
                                        | BindingFlags.SetProperty, null, dataGridView, new object[] { true });  
        }

        #region Enum
        public enum EN_CONTROL_TYPE
        {
            DIGITAL_INPUT,
            DIGITAL_OUTPUT,
            ANALOG_INPUT_VALUE,
            ANALOG_INPUT_VOLT,
            ANALOG_OUTPUT_VALUE,
            ANALOG_OUTPUT_VOLT,
            CYLINDER,
        }
        #endregion /Enum

        #region Inner class
        public class ControlItem
        {
            public ControlItem(int nIndex, EN_CONTROL_TYPE enType, string strName = "", string strUnit = "")
            {
                m_lstIndex.Add(nIndex);
                m_lstControlType.Add(enType);
                m_strName = strName;
                m_strAnalogUnit = strUnit;
            }
            public ControlItem(List<int> lstIndex, EN_CONTROL_TYPE enType, string strName = "", string strUnit = "")
            {
                m_lstIndex = lstIndex;
                m_lstControlType.Add(enType);
                m_strName = strName;
                m_strAnalogUnit = strUnit;
            }
            public ControlItem(List<int> lstIndex, List<EN_CONTROL_TYPE> lstType, string strName = "", string strUnit = "")
            {
                m_lstIndex = lstIndex;
                m_lstControlType = lstType;
                m_strName = strName;
                m_strAnalogUnit = strUnit;
            }
            private List<int> m_lstIndex = new List<int> ();
            private List<EN_CONTROL_TYPE> m_lstControlType = new List<EN_CONTROL_TYPE>();
            private string m_strName;
            private string m_strAnalogUnit;

            private string m_strPositiveConfirmMessage = ""; //IO는 ON, cylinder는 Forward
            private string m_strNegativeConfirmMessage = ""; //IO는 OFF, cylinder는 Backward

            public List<int> DeviceIndexLIst { get { return m_lstIndex; } set { m_lstIndex = value; } }
            public List<EN_CONTROL_TYPE> ControlType { get { return m_lstControlType; } set { m_lstControlType = value; } }
            public string AnalogUnit { get { return m_strAnalogUnit; } set { m_strAnalogUnit = value; } }
            public string Name { get { return m_strName; } set { m_strName = value; } }

            // 요약:
            //     IO: ON, Cylinder: Forward 조작시 발생할 Confirm Message입니다.
            //     empty 일시 발생하지 않습니다. 
            [Category("Control"), Description("IO: ON, Cylinder: Forward")]
            public string PositiveConfirmMessage { get { return m_strPositiveConfirmMessage; } set { m_strPositiveConfirmMessage = value; } }

            // 요약:
            //     IO: OFF, Cylinder: Backward 조작시 발생할 Confirm Message입니다.
            //     empty 일시 발생하지 않습니다. 
            [Category("Control"), Description("IO: OFF, Cylinder: Backward")]
            public string NegativeConfirmMessage { get { return m_strNegativeConfirmMessage; } set { m_strNegativeConfirmMessage = value; } }

        }
        #endregion

        #region Field
        private List<ControlItem> m_ControlCollection;
        private FrameOfSystem3.Config.ConfigDigitalIO m_InstanceDIO;
        private FrameOfSystem3.Config.ConfigAnalogIO m_InstanceAIO;
        private FrameOfSystem3.Config.ConfigCylinder m_InstanceCylinder;
        private bool m_bControl_Enable = true;
        private FrameOfSystem3.Views.Functional.Form_MessageBox m_InstanceOfMessageBox = null;
        #endregion /Field

        #region Const
        private readonly Color c_clrDITrue = Color.Green;
        private readonly Color c_clrDOTrue = Color.Red;
        private readonly Color c_clrFalse = Color.White;

        private readonly Color c_clrMonitorName = Color.LightGray;
        private readonly Color c_clrControlName = Color.SteelBlue;

        private readonly Color c_clrDisable = Color.Gray;

        private readonly Color c_clrHighlight = Color.DimGray;
        #endregion /Const

        #region Property
        [Category("Control"), Description("")]
        public bool Control_Enable { get { return m_bControl_Enable; } set { m_bControl_Enable = value; } }
        [Category("Control"), Description("")]
        public List<ControlItem> controlCollection { get { return m_ControlCollection; } set { m_ControlCollection = value; } }
        #endregion /Property

        #region Method
        public void Initialize(List<ControlItem> lstItem = null, int nViewCount = -1, int nValueWidth = 120)
        {
            if(nViewCount == -1)
                nViewCount = lstItem.Count;
            base.Height = nViewCount * 25 + 3;
            //control hight는 (List 갯수 * 25) + 3

      
            if (m_bControl_Enable)
                dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);

            m_InstanceDIO = FrameOfSystem3.Config.ConfigDigitalIO.GetInstance();
            m_InstanceAIO = FrameOfSystem3.Config.ConfigAnalogIO.GetInstance();
            m_InstanceCylinder = FrameOfSystem3.Config.ConfigCylinder.GetInstance();

            m_InstanceOfMessageBox = FrameOfSystem3.Views.Functional.Form_MessageBox.GetInstance();

            if (lstItem != null)
                m_ControlCollection = lstItem;

            int nColumnCount = 2;
            foreach (ControlItem Item in m_ControlCollection)
            {
                nColumnCount = nColumnCount < Item.DeviceIndexLIst.Count + 1 ? Item.DeviceIndexLIst.Count + 1 : nColumnCount;
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

            dataGridView.Rows.Clear();
            int nRow = 0;
            foreach (ControlItem Item in m_ControlCollection)
            {
                dataGridView.Rows.Add();
                if (Item.Name == "")
                {
                    switch (Item.ControlType[0])//첫번째 아이템 이름으로 하자.
                    {
                        case EN_CONTROL_TYPE.DIGITAL_INPUT:
                            dataGridView[0, nRow].Value = m_InstanceDIO.GetName(true, Item.DeviceIndexLIst[0]).Replace("_", " ");
                            break;
                        case EN_CONTROL_TYPE.DIGITAL_OUTPUT:
                            dataGridView[0, nRow].Value = m_InstanceDIO.GetName(false, Item.DeviceIndexLIst[0]).Replace("_", " ");
                            break;
                        case EN_CONTROL_TYPE.ANALOG_INPUT_VALUE:
                        case EN_CONTROL_TYPE.ANALOG_INPUT_VOLT:
                            dataGridView[0, nRow].Value = m_InstanceAIO.GetName(true, Item.DeviceIndexLIst[0]).Replace("_", " ");
                            break;
                        case EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE:
                        case EN_CONTROL_TYPE.ANALOG_OUTPUT_VOLT:
                            dataGridView[0, nRow].Value = m_InstanceAIO.GetName(false, Item.DeviceIndexLIst[0]).Replace("_", " ");
                            break;
                        case EN_CONTROL_TYPE.CYLINDER:
                            dataGridView[0, nRow].Value = m_InstanceCylinder.GetName(Item.DeviceIndexLIst[0]).Replace("_", " ");
                            break;
                    }
                }
                else
                {
                    dataGridView[0, nRow].Value = Item.Name;
                }

                if (Item.ControlType.Contains(EN_CONTROL_TYPE.DIGITAL_OUTPUT)//제어 요소가 있으면
                    || Item.ControlType.Contains(EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE)
                    || Item.ControlType.Contains(EN_CONTROL_TYPE.ANALOG_OUTPUT_VOLT)
                    || Item.ControlType.Contains(EN_CONTROL_TYPE.CYLINDER))
                {
                    dataGridView[0, nRow].Style.BackColor = c_clrControlName;
                    dataGridView[0, nRow].Style.SelectionBackColor = c_clrControlName;
                }
                else
                {
                    dataGridView[0, nRow].Style.BackColor = c_clrMonitorName;
                    dataGridView[0, nRow].Style.SelectionBackColor = c_clrMonitorName;
                }
//                 switch (Item.ControlType)
//                 {
//                     case EN_CONTROL_TYPE.DIGITAL_INPUT:
//                     case EN_CONTROL_TYPE.ANALOG_INPUT_VALUE:
//                     case EN_CONTROL_TYPE.ANALOG_INPUT_VOLT:
//                         dataGridView[0, nRow].Style.BackColor = c_clrMonitorName;
//                         dataGridView[0, nRow].Style.SelectionBackColor = c_clrMonitorName;
//                         break;
//                     case EN_CONTROL_TYPE.DIGITAL_OUTPUT:
//                     case EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE:
//                     case EN_CONTROL_TYPE.ANALOG_OUTPUT_VOLT:
//                     case EN_CONTROL_TYPE.CYLINDER:
//                         dataGridView[0, nRow].Style.BackColor = c_clrControlName;
//                         dataGridView[0, nRow].Style.SelectionBackColor = c_clrControlName;
//                         break;
//                 }

                for (int nCol = 1; nCol < dataGridView.ColumnCount; nCol++)
                {
                    if (nCol > Item.DeviceIndexLIst.Count)
                    {
                        dataGridView[nCol, nRow].Style.BackColor = c_clrDisable;
                        dataGridView[nCol, nRow].Style.SelectionBackColor = c_clrDisable;
                    }
                }

                nRow++;
            }
        }

        public void UpdateState()
        {
            bool bState = true;
            string strVal = string.Empty;

            int nRow = 0;
            int nCol = 1;
            foreach (ControlItem Item in m_ControlCollection)
            {
                foreach (int nIndex in Item.DeviceIndexLIst)
                {
                    int nControlTypeIndex = 0;
                    if (Item.ControlType.Count > 1)
                        nControlTypeIndex = nCol - 1;
                    switch (Item.ControlType[nControlTypeIndex])
                    {
                        case EN_CONTROL_TYPE.DIGITAL_INPUT:
                            bState = m_InstanceDIO.ReadItem(true, nIndex);
                            dataGridView[nCol, nRow].Style.BackColor = bState ? c_clrDITrue : c_clrFalse;
                            dataGridView[nCol, nRow].Style.SelectionBackColor = bState ? c_clrDITrue : c_clrFalse;
                            dataGridView[nCol, nRow].Value = bState ? "ON" : "OFF"; 
                            dataGridView[nCol, nRow].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case EN_CONTROL_TYPE.DIGITAL_OUTPUT:
                            bState = m_InstanceDIO.ReadItem(false, nIndex);
                            dataGridView[nCol, nRow].Style.BackColor = bState ? c_clrDOTrue : c_clrFalse;
                            dataGridView[nCol, nRow].Style.SelectionBackColor = bState ? c_clrDOTrue : c_clrFalse;
                            dataGridView[nCol, nRow].Value = bState ? "ON" : "OFF";
                            dataGridView[nCol, nRow].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case EN_CONTROL_TYPE.ANALOG_INPUT_VALUE:
                            strVal = Math.Round(m_InstanceAIO.ReadInputValue(nIndex), 3).ToString();
                            if (Item.AnalogUnit.Length != 0)
                                strVal += " " + Item.AnalogUnit;
                            dataGridView[nCol, nRow].Value = strVal;
                            break;
                        case EN_CONTROL_TYPE.ANALOG_INPUT_VOLT:
                            strVal = Math.Round(m_InstanceAIO.ReadInputVolt(nIndex), 3).ToString();
                            if (Item.AnalogUnit.Length != 0)
                                strVal += " V";
                            dataGridView[nCol, nRow].Value = strVal;
                            break;
                        case EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE:
                            strVal = Math.Round(m_InstanceAIO.ReadOutputValue(nIndex), 3).ToString();
                            if (Item.AnalogUnit.Length != 0)
                                strVal += " " + Item.AnalogUnit;
                            dataGridView[nCol, nRow].Value = strVal;
                            break;
                        case EN_CONTROL_TYPE.ANALOG_OUTPUT_VOLT:
                            strVal = Math.Round(m_InstanceAIO.ReadOutputVolt(nIndex), 3).ToString();
                            if (Item.AnalogUnit.Length != 0)
                                strVal += " V";
                            dataGridView[nCol, nRow].Value = strVal;
                            break;
                        case EN_CONTROL_TYPE.CYLINDER:
                            m_InstanceCylinder.GetCylinderState(nIndex, ref strVal);
                            dataGridView[nCol, nRow].Value = strVal;
                            break;
                    }
                    nCol++;
                }
                nCol = 1;
                nRow++;

            }
        }

        public void ShowHeader(List<string> lstHeaderName)
        {
            dataGridView.ColumnHeadersVisible = true;
            base.Height += 25;
            for (int i = 0; i < lstHeaderName.Count; i++)
            {
                dataGridView.Columns[i].HeaderText = lstHeaderName[i];
            }
        }
        #endregion /Method

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EquipmentState_.EquipmentState.GetInstance().GetState() != EquipmentState_.EQUIPMENT_STATE.IDLE
                && EquipmentState_.EquipmentState.GetInstance().GetState() != EquipmentState_.EQUIPMENT_STATE.PAUSE)
                return;

            int nRowindex = e.RowIndex;
            int nColumnIndex = e.ColumnIndex;

            if (nRowindex < 0 || nRowindex >= dataGridView.RowCount) { return; }

//             if (nColumnIndex != 1)
//                 return;
            if (nColumnIndex == 0)
                return;
            if (m_ControlCollection[nRowindex].DeviceIndexLIst.Count < nColumnIndex)
                return;
            EN_CONTROL_TYPE enControlType = m_ControlCollection[nRowindex].ControlType.Count == 1 ? m_ControlCollection[nRowindex].ControlType[0] : m_ControlCollection[nRowindex].ControlType[nColumnIndex - 1];

            switch (enControlType)
            {
                case EN_CONTROL_TYPE.DIGITAL_OUTPUT:
                    bool bState = m_InstanceDIO.ReadItem(false, m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1]);
                    if (bState)
                    {
                        if (m_ControlCollection[nRowindex].NegativeConfirmMessage != "")
                        {
                            if (!m_InstanceOfMessageBox.ShowMessage(m_ControlCollection[nRowindex].NegativeConfirmMessage, "OUPUT OFF CONFIRM"))
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (m_ControlCollection[nRowindex].PositiveConfirmMessage != "")
                        {
                            if (!m_InstanceOfMessageBox.ShowMessage(m_ControlCollection[nRowindex].PositiveConfirmMessage, "OUPUT ON CONFIRM"))
                            {
                                return;
                            }
                        }
                    }
                    m_InstanceDIO.WriteOutput(!bState, m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1]);
                    break;
                case EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE:
                    double dOldVal = m_InstanceAIO.ReadOutputValue(m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1]);
                    double dMin = 0;
                    double dMax = 0;
                    m_InstanceAIO.GetDataMinMaxFromTable(false, m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1], ref dMin, ref dMax);
                    if (FrameOfSystem3.Views.Functional.Form_Calculator.GetInstance().CreateForm(dOldVal.ToString(), dMin.ToString(), dMax.ToString(), m_ControlCollection[nRowindex].AnalogUnit))
                    {
                        double dVal = 0;
                        FrameOfSystem3.Views.Functional.Form_Calculator.GetInstance().GetResult(ref dVal);
                        m_InstanceAIO.WriteOutputValue(m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1], dVal);
                    }
                    break;
                case EN_CONTROL_TYPE.CYLINDER:
                    string strState = string.Empty;
                    m_InstanceCylinder.GetCylinderState(m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1], ref strState);
                    if (strState == "BACKWARD"
                     || strState == "BACKWARD_TIMEOUT"
                     || strState == "BACKWARD_ERROR")
                    {
                        if (m_ControlCollection[nRowindex].PositiveConfirmMessage != "")
                        {
                            if (!m_InstanceOfMessageBox.ShowMessage(m_ControlCollection[nRowindex].PositiveConfirmMessage, "FORWARD CONFIRM"))
                            {
                                return;
                            }
                        }

                        m_InstanceCylinder.MoveForward(m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1]);
                    }
                    else if (strState == "FORWARD"
                          || strState == "FORWARD_TIMEOUT"
                          || strState == "FORWARD_ERROR")
                    {
                        if (m_ControlCollection[nRowindex].NegativeConfirmMessage != "")
                        {
                            if (!m_InstanceOfMessageBox.ShowMessage(m_ControlCollection[nRowindex].NegativeConfirmMessage, "BACKWARD CONFIRM"))
                            {
                                return;
                            }
                        }

                        m_InstanceCylinder.MoveBackward(m_ControlCollection[nRowindex].DeviceIndexLIst[nColumnIndex - 1]);
                    }
                    break;
            }

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

//             switch (m_ControlCollection[nRowindex].ControlType)
//             {
//                 case EN_CONTROL_TYPE.DIGITAL_INPUT:
//                 case EN_CONTROL_TYPE.ANALOG_INPUT_VALUE:
//                 case EN_CONTROL_TYPE.ANALOG_INPUT_VOLT:
//                     dataGridView[0, nRowindex].Style.BackColor = c_clrMonitorName;
//                     dataGridView[0, nRowindex].Style.SelectionBackColor = c_clrMonitorName;
//                     break;
//                 case EN_CONTROL_TYPE.DIGITAL_OUTPUT:
//                 case EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE:
//                 case EN_CONTROL_TYPE.ANALOG_OUTPUT_VOLT:
//                 case EN_CONTROL_TYPE.CYLINDER:
//                     dataGridView[0, nRowindex].Style.BackColor = c_clrControlName;
//                     dataGridView[0, nRowindex].Style.SelectionBackColor = c_clrControlName;
//                     break;
//             }

            if (m_ControlCollection[nRowindex].ControlType.Contains(EN_CONTROL_TYPE.DIGITAL_OUTPUT)//제어 요소가 있으면
                 || m_ControlCollection[nRowindex].ControlType.Contains(EN_CONTROL_TYPE.ANALOG_OUTPUT_VALUE)
                 || m_ControlCollection[nRowindex].ControlType.Contains(EN_CONTROL_TYPE.ANALOG_OUTPUT_VOLT)
                 || m_ControlCollection[nRowindex].ControlType.Contains(EN_CONTROL_TYPE.CYLINDER))
            {
                dataGridView[0, nRowindex].Style.BackColor = c_clrControlName;
                dataGridView[0, nRowindex].Style.SelectionBackColor = c_clrControlName;
            }
            else
            {
                dataGridView[0, nRowindex].Style.BackColor = c_clrMonitorName;
                dataGridView[0, nRowindex].Style.SelectionBackColor = c_clrMonitorName;
            }
        }
    }
}
