using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newt_Scamander_sc.animals;
using System.Threading;

namespace Newt_Scamander_sc.Creators
{
    public class DemiguiseCreator : ICreator //класс реализует интерфейс ICreator, определяет свою реализацию фабричного метода getAnimalFM() 
    {                                      //Причем метод getAnimalFM() каждого отдельного класса-создателя возвращает определенный конкретный тип животного

        public double Demiguise_foodPerDay; // количество еды в день для Demiguise
        public SuitcaseDepartType Demiguise_SuitcaseDep; // Комната для Demiguise - SuitcaseDepartType.Room
        public AnimalCompatibility Demiguise_AnimalComp;   // группа к которой относится животное (учет совместимости)

        ArrayList DemiguiseNames = new ArrayList() { "Minou", "Leo", "Joe", "Lilo", "Stich", "Deny" };

        public DemiguiseCreator(double Demiguise_foodPerDay, SuitcaseDepartType Demiguise_SuitcaseDep, AnimalCompatibility Demiguise_AnimalComp)  // 
        {            
            this.Demiguise_foodPerDay =Demiguise_foodPerDay;
            this.Demiguise_SuitcaseDep = Demiguise_SuitcaseDep;
            this.Demiguise_AnimalComp = Demiguise_AnimalComp;
        }

        public IAnimal getAnimalFM() //фабричный метод, который возвращает Demiguise
        {
            Thread.Sleep(30); // задержка для генерации отличного случайного числа
            Random rnd1 = new Random();

            return new Demiguise(DemiguiseNames[rnd1.Next(DemiguiseNames.Count)].ToString(), this.Demiguise_foodPerDay,
                 this.Demiguise_SuitcaseDep, this.Demiguise_AnimalComp);
            //возвращаем Demiguise с рандомным именем из списка и заданным весом еды в день, отделом в чемодане, группа к которой относится 
        }

    }
}
