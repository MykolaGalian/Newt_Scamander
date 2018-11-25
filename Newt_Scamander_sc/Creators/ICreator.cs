using Newt_Scamander_sc.animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newt_Scamander_sc.Creators
{
    public interface ICreator   //интерфейс определяет  фабричный метод, который возвращает нужный тип животного
    {
        IAnimal getAnimalFM();   
    }

}
