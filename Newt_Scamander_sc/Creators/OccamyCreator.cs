using Newt_Scamander_sc.animals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Newt_Scamander_sc.Creators
{
    public class OccamyCreator : ICreator //класс реализует интерфейс ICreator, определяет свою реализацию фабричного метода getAnimalFM() 
    {                                      //Причем метод getAnimalFM() каждого отдельного класса-создателя возвращает определенный конкретный тип животного

        public double Occamy_foodPerDay; // количество еды в день для Occamy
        public SuitcaseDepartType Occamy_SuitcaseDep; // вольер для Occamy - SuitcaseDepartType.Aviary
        public AnimalCompatibility Occamy_AnimalComp;   // группа к которой относится животное (учет совместимости)
        
        ArrayList OccamyNames = new ArrayList() { "Tigrou", "Caramel", "Myk", "Sidor", "Any", "Fish" };

        public OccamyCreator(double Occamy_foodPerDay, SuitcaseDepartType Occamy_SuitcaseDep, AnimalCompatibility Occamy_AnimalComp)  // 
        {
           this.Occamy_foodPerDay = Occamy_foodPerDay;
           this.Occamy_SuitcaseDep = Occamy_SuitcaseDep;
           this.Occamy_AnimalComp = Occamy_AnimalComp;
        }

        public IAnimal getAnimalFM() //фабричный метод, который возвращает Occamy
        {
            Thread.Sleep(20); // задержка для генерации отличного случайного числа
            Random rnd3 = new Random();
            
            return new Occamy(OccamyNames[rnd3.Next(OccamyNames.Count)].ToString(), this.Occamy_foodPerDay,
                this.Occamy_SuitcaseDep, this.Occamy_AnimalComp);
            //возвращаем Occamy с рандомным именем из списка и заданным весом еды в день, отделом в чемодан, группа к которой относится 
        }       

    }
}
