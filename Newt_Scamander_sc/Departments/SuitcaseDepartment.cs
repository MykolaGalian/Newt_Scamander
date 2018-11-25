using Newt_Scamander_sc.animals;
using Newt_Scamander_sc.TimesOfDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Newt_Scamander_sc.Departments
{
    public abstract class SuitcaseDepartment // абстрактный класс описывает отдел в чемодане (аналог Component - реализация паттерна компоновщик)
    {
        
        public SuitcaseDepartType DepartType { get;  set; }   // тип отдела в чемодане
        public State_DayNight DayState { get; set; } // время суток в отделе чемодана(состояние)

        
        public SuitcaseDepartment(SuitcaseDepartType DepartType, State_DayNight DayState)
      {
          this.DepartType = DepartType;
          this.DayState = DayState;
      }
       public abstract string AddPet(IAnimal animal); // добавление животного в данный отдел чемодана
       public abstract string RemovePet(IAnimal animal); // удаление животного из даного отдела чемодана (для перемещения в др. комнату или изьятия из чемодана)
       public abstract void ByName_AnimalSound(String name); // запрос голоса у конкретного животного по его имени (перебор листа по условию)    
       public abstract void AnimalSoundAll(); // все животные которые в чемодане подают голос (добавить состояние - ночь/день, ночью не отвечать)       
       public abstract void SuitcaseDepAll(); // расположение всех животных

       public abstract double FoodPerDayAll(double Total); // Общее дневное потребление еды для всех животных в отделе чемодана 
       public abstract double TotalAnimal(double Total); // Общее количество всех животных в отделе чемодана 
       public abstract void Day(); // изменяем состояние на - день (состояние)
       public abstract void Night(); // изменяем состояние на - ночь (состояние)


       public abstract void AddDep(SuitcaseDepartment c); // открыть доступ в комнату в которую можно попасть из текущей комнаты

       public abstract void RemovDep(SuitcaseDepartment c); // закрыть доступ в комнату в которую можно попасть из текущей комнаты

    }
}
