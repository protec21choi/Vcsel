using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
//using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;

using Define.DefineEnumProject.Motion;
using Define.DefineEnumProject.DigitalIO;
using Define.DefineEnumProject.AnalogIO;
using Define.DefineEnumProject.Task;

using FrameOfSystem3.Work;
using FrameOfSystem3.Config;
using FrameOfSystem3.Task;

using FrameOfSystem3.Views.Setup;
using FrameOfSystem3.Component;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Laser;
using RecipeManager_;
 
namespace FrameOfSystem3.Views.Setup
{
    public partial class Setup_Work : UserControlForMainView.CustomView
	{
		public Setup_Work()
		{
			InitializeComponent();
        }

        
    }
}
