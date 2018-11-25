using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newt_Scamander_sc.animals
{
    public interface IAnimal 
    {
        String Name { get; set; }
        double FoodPerDay { get; set; }
        SuitcaseDepartType AnimalDepartType { get; set; }
        AnimalCompatibility AnimalComp { get; set; }   // группа к которой относится животное (учет совместимости)
                
          String AnimalSound(); // возвращает строку со своим голосом           
    }
}
