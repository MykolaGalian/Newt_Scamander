using Newt_Scamander_sc.animals;
using Newt_Scamander_sc.TimesOfDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Newt_Scamander_sc.Departments
{
    public class DepWithManyDoors : SuitcaseDepartment  // класс описывает отдел в чемодане c множеством дверей в др. отделы чемодана (аналог Composite - реализация паттерна компоновщик)
    {
        public List<IAnimal> animalList = new List<IAnimal>(); // лист всех животных в этом отделе чемодана
        public List<SuitcaseDepartment> doorslist = new List<SuitcaseDepartment>(); // список отделов (комнат, вольеров и т.д.) в которые можно попасть из этого отдела
        public int MaxNumberAnimals { get; set; }  // макс. кол-во животных в отделе

        public DepWithManyDoors(SuitcaseDepartType DepartType, State_DayNight DayState, int MaxNumberAnimals) // вызов конструктора базового класса  
            : base(DepartType, DayState) 
        {
            this.MaxNumberAnimals = MaxNumberAnimals;
        }

        /// ////////////////////////////////////////////////////////////////////////////////////

        public override void ByName_AnimalSound(String name) // запрос голоса у конкретного животного по его имени (перебор листа по условию)       
            {
                int countRec = 0;
                foreach (var animal in this.animalList)
                {
                    if (animal.Name == name)
                        Console.WriteLine(animal.ToString().Substring(26) + " name (answered the on call): " + animal.Name + "; sound: " + animal.AnimalSound());
                    else countRec++;
                }
                if (countRec == this.animalList.Count) Console.WriteLine("There is no animal in this suitcase department with name: " + name);

                foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор животных в дочерних отделах
                {
                    child.ByName_AnimalSound(name);
                }
            }  

        public override void AnimalSoundAll() // все животные которые в чемодане подают голос (добавить состояние - ночь/день, ночью не отвечать)
        {
            State_DayNight DayStateL = new State_Day(); // создаем - дневное время суток
            String n1 = DayStateL.GetType().ToString();

            if (this.DayState.GetType().ToString() == n1)  // проверка равенства типов (текстового представления) - для проверки состояния ночь/день
            {
                foreach (var animal in this.animalList)
                {
                    Console.WriteLine(animal.ToString().Substring(26) + " name: " + animal.Name + "; sound: " + animal.AnimalSound());
                }
            }
            else Console.WriteLine("______All animals sleeping_____");


            foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор животных в дочерних отделах
            {
                child.AnimalSoundAll();
            }
          }


        public override void SuitcaseDepAll() // расположение всех животных
        {
            foreach (var animal in this.animalList)
            {
                Console.WriteLine(animal.ToString().Substring(26) + " name: " + animal.Name + "; Suitcase Department: " + animal.AnimalDepartType);
            }

            foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор животных в дочерних отделах
            {
                child.SuitcaseDepAll();
            }
        }

        public override double FoodPerDayAll(double Total) // Общее дневное потребление еды для всех животных в чемодане 
        {

            double TotalFoodPerDay = 0; //переменная накапливает общее количество еды в день в текущем отделе
            foreach (var animal in this.animalList) // перебор животных в текущем отделе
            {
                Total += animal.FoodPerDay;                
            }
                       
            foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор животных в дочерних отделах
            {
                TotalFoodPerDay += child.FoodPerDayAll(Total);
            }
            return TotalFoodPerDay;
        }
        public override double TotalAnimal(double Total)// Общее количество всех животных в отделе чемодана 
        {
            double TotalAnimal = 0; //переменная накапливает общее количество животных в текущем отделе
            foreach (var animal in this.animalList) // перебор животных в текущем отделе
            {
                Total++;
            }

            foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор животных в дочерних отделах
            {
                TotalAnimal += child.TotalAnimal(Total);
            }
            return TotalAnimal;
        }


        /// ////////////////////////////////////////////////////////////////////////////////////
        public override void Day() // изменяем состояние на - день (состояние)
        {
            DayState.TurnTo_Day(this);

            foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор в дочерних отделах
            {
                child.Day();
            }

        }
        public override void Night() // изменяем состояние на - ночь (состояние)
        {
            DayState.TurnTo_Night(this);

            foreach (SuitcaseDepartment child in doorslist) // рекурсионный перебор в дочерних отделах
            {
                child.Night();
            }
        }
       
        /// ////////////////////////////////////////////////////////////////////////////////////
        

        public override void AddDep(SuitcaseDepartment c)  // открыть доступ в комнату в которую можно попасть из текущей комнаты
        {
            doorslist.Add(c);
        }

        public override void RemovDep(SuitcaseDepartment c) // закрыть доступ в комнату в которую можно попасть из текущей комнаты
        {
            doorslist.Remove(c);
        }

        public override string AddPet(IAnimal animal) // добавление животного в данный отдел чемодана 
        {
            // проверка - подходит ли данное животное для данного отдела чемодана
            if (animal.AnimalDepartType.Equals(this.DepartType)
                && animalList.Count <= MaxNumberAnimals)  //проверка - не больше n животных в отделе
            {
                if (animalList.Count == 0)
                {
                    this.animalList.Add(animal);   // если еще нет животных в отделе, то добавить без проверки на совместимость
                    Console.WriteLine("Animal " + animal.ToString().Substring(26) + " added to this suitcase department " + this.DepartType.ToString());

                    return "Animal " + animal.ToString().Substring(26) + " added";
                }
                else if (animal.AnimalComp.Equals(this.animalList[0].AnimalComp))
                {
                    this.animalList.Add(animal); // проверка на совместимость животных
                    Console.WriteLine("Animal " + animal.ToString().Substring(26) + " added to this suitcase department " + this.DepartType.ToString());

                    return "Animal " + animal.ToString().Substring(26) + " added";
                }
                else
                {
                    Console.WriteLine("Sorry! This " + animal.ToString().Substring(26) + " is not suitable for this animal group "
                      + this.animalList[0].AnimalComp.ToString());

                    return "Sorry! This " + animal.ToString().Substring(26) + " is not suitable for this animal group "
                      + this.animalList[0].AnimalComp.ToString();
                }
            }
            else
            {
                Console.WriteLine("Sorry! This " + animal.ToString().Substring(26) + " is not suitable for this suitcase department " + this.DepartType.ToString());
                return "Sorry! This " + animal.ToString().Substring(26) + " is not suitable for this suitcase department " + this.DepartType.ToString();
            }
        }

        public override string RemovePet(IAnimal animal) // удаление животного из даного отдела чемодана (для перемещения в др. комнату или изьятия из чемодана)
        {
            if (animal.AnimalDepartType.Equals(this.DepartType)) // проверка - может ли данное животное быть в данном отдела чемодана
            {
                this.animalList.Remove(animal);
                Console.WriteLine("Animal " + animal.ToString().Substring(26) + " removed from this suitcase department " + this.DepartType.ToString());
                return "Animal " + animal.ToString().Substring(26) + " removed from this suitcase department " + this.DepartType.ToString();
            }
            else return "Sorry! This " + animal.ToString().Substring(26) + "  is not suitable for this suitcase department " + this.DepartType.ToString();
        }
    }
}
