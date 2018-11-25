using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newt_Scamander_sc.Departments;

namespace Newt_Scamander_sc.TimesOfDay
{
    public abstract class State_DayNight
    {
        public abstract void TurnTo_Day(SuitcaseDepartment newt);
        public abstract void TurnTo_Night(SuitcaseDepartment newt);
    }
}
