using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newt_Scamander_sc.Departments;

namespace Newt_Scamander_sc.TimesOfDay
{
    public class State_Day : State_DayNight
    {
        public override void TurnTo_Day(SuitcaseDepartment newt)
        {

        }
        public override void TurnTo_Night(SuitcaseDepartment newt)
        {
            newt.DayState = new State_Night();
        }
    }
}
