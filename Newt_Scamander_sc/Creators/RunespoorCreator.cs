using Newt_Scamander_sc.animals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newt_Scamander_sc.Creators
{
    public class RunespoorCreator : ICreator //класс реализует интерфейс ICreator, определяет свою реализацию фабричного метода getAnimalFM() 
    {
        public double Runespoor_foodPerDay; // количество еды в день для Runespoor
        public SuitcaseDepartType Runespoor_SuitcaseDep; // вольер для Runespoor - SuitcaseDepartType.Aviary
        public AnimalCompatibility Runespoor_AnimalComp;   // группа к которой относится животное (учет совместимости)
        
        ArrayList RunespoorNames = new ArrayList() { "Jigu", "Hamel", "Lyik", "Vizor", "Ony", "Klish" };

        public RunespoorCreator(double Runespoor_foodPerDay, SuitcaseDepartType Runespoor_SuitcaseDep, AnimalCompatibility Runespoor_AnimalComp)  // 
        {
           this.Runespoor_foodPerDay = Runespoor_foodPerDay;
           this.Runespoor_SuitcaseDep = Runespoor_SuitcaseDep;
           this.Runespoor_AnimalComp = Runespoor_AnimalComp;
        }

        public IAnimal getAnimalFM() //фабричный метод, который возвращает Runespoor
        {
            Thread.Sleep(40); // задержка для генерации отличного случайного числа
            Random rnd4 = new Random();
            
            return new Runespoor(RunespoorNames[rnd4.Next(RunespoorNames.Count)].ToString(), this.Runespoor_foodPerDay,
                this.Runespoor_SuitcaseDep, this.Runespoor_AnimalComp);
            //возвращаем Runespoor с рандомным именем из списка и заданным весом еды в день, отделом в чемодан, группа к которой относится 
        }   


    }
}
