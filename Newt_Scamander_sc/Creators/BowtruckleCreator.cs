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
    public class BowtruckleCreator : ICreator //класс реализует интерфейс ICreator, определяет свою реализацию фабричного метода getAnimalFM() 
    {                                      //Причем метод getAnimalFM() каждого отдельного класса-создателя возвращает определенный конкретный тип животного

        public double Bowtruckle_foodPerDay; // количество еды для в день Bowtruckle
        public SuitcaseDepartType Bowtruckle_SuitcaseDep; // Пастбище для Bowtruckle - SuitcaseDepartType.Grazing
        public AnimalCompatibility Bowtruckle_AnimalComp;   // группа к которой относится животное (учет совместимости)

        ArrayList BowtruckleNames = new ArrayList() { "Felix", "Simba", "Filou", "Sem", "Coco", "Denzel" };

        public BowtruckleCreator(double Bowtruckle_foodPerDay, SuitcaseDepartType Bowtruckle_SuitcaseDep, AnimalCompatibility Bowtruckle_AnimalComp)  
        {
            this.Bowtruckle_foodPerDay = Bowtruckle_foodPerDay;
            this.Bowtruckle_SuitcaseDep = Bowtruckle_SuitcaseDep;
            this.Bowtruckle_AnimalComp = Bowtruckle_AnimalComp;
        }

        public IAnimal getAnimalFM() //фабричный метод, который возвращает Bowtruckle
        {
            Thread.Sleep(10); // задержка для генерации отличного случайного числа
            Random rnd2 = new Random();

            return new Bowtruckle(BowtruckleNames[rnd2.Next(BowtruckleNames.Count)].ToString(), this.Bowtruckle_foodPerDay,
                      this.Bowtruckle_SuitcaseDep, this.Bowtruckle_AnimalComp);   
            //возвращаем Bowtruckle с рандомным именем из списка и заданным весом еды в день,  отделом в чемодане, группа к которой относится 
        }     

    }
}
