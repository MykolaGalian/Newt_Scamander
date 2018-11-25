using Newt_Scamander_sc.animals;
using Newt_Scamander_sc.Creators;
using Newt_Scamander_sc.TimesOfDay;
using Newt_Scamander_sc.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Галян Николай ЗПI-71 (номер №3 в списке )
 * додаток Чомодан Ньюта Саламандера (реализация паттернов проетирования)
 * Паттерн Фабричний метод - для создания обьектов - животные, организации случайного попадания животных в чемодан и др.);
 * Паттерн Состояние - для смены дня/ночи в чемодане; 
 * Паттерн Компоновщик - для создания вложенной (древовидной) структуры отделов (комнат, вальеров, пастбищ) в чемодане
 */

namespace Newt_Scamander_sc
{
    public enum SuitcaseDepartType   // отделы чемодана
    {
        Room,  // комната (для Demiguise - Камуфлори (обезьянка))
        Grazing,  //пастбище (для Bowtruckle - Лечурка (растениевидное))
        Aviary  // вольер (для Occamy, Runespoor)
    }

    public enum AnimalCompatibility // группы животных (совместимость)
    {
        feathered, // пернатые (Occamy (змее-птица))
        mammals, //млекопитающие (для Demiguise - Камуфлори (обезьянка))
        herbLike, // растениевидные (Bowtruckle - Лечурка (растениевидное))
        reptiles  // рептилии (Runespoor - трёхголовая змея)
    }
    
    class Program
    {            
        static void Main(string[] args)
        {          

            // Создаем все типы Creator для разных животных
            RunespoorCreator RunespoorCr = new RunespoorCreator(30, SuitcaseDepartType.Aviary, AnimalCompatibility.reptiles);    // для  Runespoor (трёхголовая змея)
            OccamyCreator OccamyCr = new OccamyCreator(5, SuitcaseDepartType.Aviary, AnimalCompatibility.feathered);    //  для Occamy (змее-птица)
            BowtruckleCreator BowtruckleCr = new BowtruckleCreator(20, SuitcaseDepartType.Grazing, AnimalCompatibility.herbLike);    // для  Bowtruckle (Лечурка)
            DemiguiseCreator DemiguiseCr = new DemiguiseCreator(10, SuitcaseDepartType.Room, AnimalCompatibility.mammals);    // для  Demiguise (Камуфлори)
            ICreator RandomAnimalsCr = new RandomAnimalsCreator(OccamyCr, DemiguiseCr, BowtruckleCr, 0.33, 0.33, 0.34); // дя случайного животного (Occamy,Bowtruckle,Demiguise)

            SuitcaseDepartment rootDep = new DepWithManyDoors(SuitcaseDepartType.Aviary, new State_Day(), 3); // создаем корневой отдел в чемодане (вольер - Aviary для Occamy) 

            // создаем отделы в чемодане (эти комнаты будут доступны из корневого отдела)
            SuitcaseDepartment AviaryDepFirst = new DepWithManyDoors(SuitcaseDepartType.Aviary, new State_Day(), 3); 
            SuitcaseDepartment GrazingDepFirst = new DepWithManyDoors(SuitcaseDepartType.Grazing, new State_Day(), 3);  
            SuitcaseDepartment RoomDepFirst = new DepWithManyDoors(SuitcaseDepartType.Room, new State_Day(), 3);

            // добавляем  доступ из корневого отдела rootDep в другие отделы чемодана
            rootDep.AddDep(AviaryDepFirst); 
            rootDep.AddDep(GrazingDepFirst);
            rootDep.AddDep(RoomDepFirst);

            //Создаем дочерние отделы (с одним входом - листья)
            SuitcaseDepartment AviaryDepSecondLeaf = new DepWithSingleDoor(SuitcaseDepartType.Aviary, new State_Day(), 2); 
            SuitcaseDepartment GrazingDepSecondLeaf = new DepWithSingleDoor(SuitcaseDepartType.Grazing, new State_Day(), 2); 
            SuitcaseDepartment RoomDepSecondLeaf = new DepWithSingleDoor(SuitcaseDepartType.Room, new State_Day(), 2); 

            // добавляем  доступ из одних отделов в другие отделы чемодана (здесь, например из одного вольера можно попасть только в др. вольер)
            AviaryDepFirst.AddDep(AviaryDepSecondLeaf);
            GrazingDepFirst.AddDep(GrazingDepSecondLeaf);
            RoomDepFirst.AddDep(RoomDepSecondLeaf);

            // создаем животных и добавляем их в отделы чемодана
            IAnimal animalRand1 = RandomAnimalsCr.getAnimalFM(); // создаем случайное животное
            AviaryDepFirst.AddPet(animalRand1); // перебираем отделы куда можно добавить случайное животное (в "композит") 
            GrazingDepFirst.AddPet(animalRand1);
            RoomDepFirst.AddPet(animalRand1);

            // Ньют сам добавляет конкретное животное (в "композит")
            IAnimal Occamy1 = OccamyCr.getAnimalFM();
            AviaryDepFirst.AddPet(Occamy1);
            IAnimal Bowtruckle1 = BowtruckleCr.getAnimalFM();
            GrazingDepFirst.AddPet(Bowtruckle1);
            IAnimal Demiguise1 = DemiguiseCr.getAnimalFM();
            RoomDepFirst.AddPet(Demiguise1);
            
            // Ньют сам добавляет конкретное животное (в "листья")
            IAnimal Occamy2 = OccamyCr.getAnimalFM();
            AviaryDepSecondLeaf.AddPet(Occamy2);
            IAnimal Bowtruckle2 = BowtruckleCr.getAnimalFM();
            GrazingDepSecondLeaf.AddPet(Bowtruckle2);
            IAnimal Demiguise2 = DemiguiseCr.getAnimalFM();
            RoomDepSecondLeaf.AddPet(Demiguise2);

            IAnimal Runespoor1 = RunespoorCr.getAnimalFM(); // создадим трёхголовая змея 
            AviaryDepSecondLeaf.AddPet(Runespoor1);  // пробуем добавить змея к окками
            AviaryDepSecondLeaf.RemovePet(Occamy2); // убираем окками из чемодана (т.к. окками и змея не совместимы (относятся к разным группам животных))
            AviaryDepSecondLeaf.AddPet(Runespoor1);  // теперь добавить змея 
                      
            
            rootDep.AnimalSoundAll();  // все животные которые в чемодане подают голос
            rootDep.SuitcaseDepAll();
            rootDep.Night();
            rootDep.AnimalSoundAll();
            rootDep.Day();
            rootDep.AnimalSoundAll();
            rootDep.ByName_AnimalSound("Tigrou");

            Console.WriteLine("Total food quantity for all animals (per/day):" + rootDep.FoodPerDayAll(.0)); // вывод общ. количества еды необходимой в день в чемодане
            Console.WriteLine("Average food quantity for one animals (per/day):" + rootDep.FoodPerDayAll(.0)/rootDep.TotalAnimal(.0)); // вывод середнего количества еды на одно животное
            Console.WriteLine("Total quantity of animals in suitcase:" + rootDep.TotalAnimal(.0));  // вывод общего количества животных в чемодане          
            
            Console.ReadKey();
        }
    }
}
