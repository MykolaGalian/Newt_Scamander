using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newt_Scamander_sc.animals
{
    public class Bowtruckle : IAnimal //Лечурка 

    {
        public String Name { get;  set; }  // имя зверя
        public double FoodPerDay { get;  set; }   // количество еды в день
        public SuitcaseDepartType AnimalDepartType { get;  set; }   // тип отдела в чемодане
        public AnimalCompatibility AnimalComp { get; set; }   // группа к которой относится животное (учет совместимости)
        public Bowtruckle(String name, double foodPerDay, SuitcaseDepartType DepartType, AnimalCompatibility AnimalComp)
        {
            this.Name = name;
            this.FoodPerDay = foodPerDay;
            this.AnimalDepartType = DepartType;
            this.AnimalComp = AnimalComp;
        }
        public String AnimalSound()
        {
            return "Booo";
        }
    }       
}
