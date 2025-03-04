using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameOfSystem3.SubSequence.SubBlockUpDown.Block;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubBlockUpDown
{
    #region <INTERFACE CLASS>
    interface IBlock
    {
        TickCounter TimeChecker { get; set; }

        bool CheckExist();
        bool MoveReady();
        bool MoveAlignIn();
        bool MoveContact(bool bUpDown, bool bSlowSpeed);
        bool MoveAlignOut();
        bool MoveBase();
        bool TurnOnVacuum();
        bool TurnOffVacuum();
        bool CheckVacuum(ref EN_ALARM enVacuumAlarm);
        bool IsMoveDone();
    }
    #endregion </INTERFACE CLASS>
}
