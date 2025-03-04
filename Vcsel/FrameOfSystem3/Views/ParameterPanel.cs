using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Define.DefineEnumBase.Common;

using FrameOfSystem3.Component;

namespace FrameOfSystem3.Views
{
	public partial class ParameterPanel : UserControlForMainView.CustomView
	{
		protected ControlInterface _controlInterface;

		public virtual void SelectedMe(ControlInterface controlInterface, string tabName)
		{

		}
		public void LinkControlInterface(ControlInterface interfaceInstance)
		{
			_controlInterface = interfaceInstance;
		}
		public virtual void ChangeSelectData(string selectData)
		{

		}
	}
}
