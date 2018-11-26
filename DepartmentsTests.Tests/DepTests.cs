using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newt_Scamander_sc.animals;
using Newt_Scamander_sc.TimesOfDay;
using Newt_Scamander_sc.Creators;
using Newt_Scamander_sc.Departments;
using Newt_Scamander_sc;


namespace DepartmentsTests.Tests
{
    [TestClass]
    public class DepTests
    {            
            OccamyCreator OccamyCr;    // фабричный метод для Occamy (змее-птица)
            BowtruckleCreator BowtruckleCr;    //фабричный метод для  Bowtruckle (Лечурка)
            DemiguiseCreator DemiguiseCr;    //фабричный метод для  Demiguise (Камуфлори)
            RunespoorCreator RunespoorCr;    //фабричный метод для  Runespoor (трёхголовая змея)

            //ICreator RandomAnimalsCr; //фабричный метод для случайного животного (Occamy,Bowtruckle,Demiguise)

            SuitcaseDepartment rootDep; // создаем корневой отдел в чемодане (вольер - Aviary для Occamy) 

            //  отделы в чемодане (эти комнаты будут доступны из корневого отдела)
            SuitcaseDepartment AviaryDepFirst; 
            SuitcaseDepartment GrazingDepFirst;  
            SuitcaseDepartment RoomDepFirst;

            // дочерние отделы (с одним входом - листья)
            SuitcaseDepartment AviaryDepSecondLeaf;
            SuitcaseDepartment GrazingDepSecondLeaf;
            SuitcaseDepartment RoomDepSecondLeaf;
            SuitcaseDepartment AviaryDepSecondLeaf2;

            //IAnimal animalRand1; //  случайное животное            
            //  животные (в "композит")
            IAnimal Occamy1;          
            IAnimal Bowtruckle1;           
            IAnimal Demiguise1;
                       
            // животные (в "листья")
            IAnimal Occamy2;            
            IAnimal Bowtruckle2;            
            IAnimal Demiguise2;            

            IAnimal Runespoor1; //  трёхголовая змея             

        [TestInitialize]
        public void TestInitialize()
        {
            RunespoorCr = new RunespoorCreator(30, SuitcaseDepartType.Aviary, AnimalCompatibility.reptiles);    // фабричный метод для  Runespoor (трёхголовая змея)
            OccamyCr = new OccamyCreator(5, SuitcaseDepartType.Aviary, AnimalCompatibility.feathered);    //  фабричный метод для Occamy (змее-птица)
            BowtruckleCr = new BowtruckleCreator(20, SuitcaseDepartType.Grazing, AnimalCompatibility.herbLike);    // фабричный метод для  Bowtruckle (Лечурка)
            DemiguiseCr = new DemiguiseCreator(10, SuitcaseDepartType.Room, AnimalCompatibility.mammals);    // фабричный метод для  Demiguise (Камуфлори)

            //RandomAnimalsCr = new RandomAnimalsCreator(OccamyCr, DemiguiseCr, BowtruckleCr, 0.33, 0.33, 0.34); // фабричный метод для случайного животного (Occamy,Bowtruckle,Demiguise)

            rootDep = new DepWithManyDoors(SuitcaseDepartType.Aviary, new State_Day(), 3); //  корневой отдел в чемодане (вольер - Aviary для Occamy) 

            //  отделы в чемодане (эти комнаты будут доступны из корневого отдела)
            AviaryDepFirst = new DepWithManyDoors(SuitcaseDepartType.Aviary, new State_Day(), 3);
            GrazingDepFirst = new DepWithManyDoors(SuitcaseDepartType.Grazing, new State_Day(), 3);
            RoomDepFirst = new DepWithManyDoors(SuitcaseDepartType.Room, new State_Day(), 3);

            // дочерние отделы (с одним входом - листья)
            AviaryDepSecondLeaf = new DepWithSingleDoor(SuitcaseDepartType.Aviary, new State_Day(), 2);
            GrazingDepSecondLeaf = new DepWithSingleDoor(SuitcaseDepartType.Grazing, new State_Day(), 2);
            RoomDepSecondLeaf = new DepWithSingleDoor(SuitcaseDepartType.Room, new State_Day(), 2);

            AviaryDepSecondLeaf2 = new DepWithSingleDoor(SuitcaseDepartType.Aviary, new State_Day(), 2);

            //animalRand1= RandomAnimalsCr.getAnimalFM(); //  случайное животное            

            //  животные (в "композит")
            Occamy1 = OccamyCr.getAnimalFM();
            Bowtruckle1 = BowtruckleCr.getAnimalFM();
            Demiguise1 = DemiguiseCr.getAnimalFM();

            // животные (в "листья")
            Occamy2 = OccamyCr.getAnimalFM();
            Bowtruckle2 = BowtruckleCr.getAnimalFM();
            Demiguise2 = DemiguiseCr.getAnimalFM();

            Runespoor1 = RunespoorCr.getAnimalFM();  //  трёхголовая змея (в качестве проверки совместимости с окками)


            // добавляем  доступ из корневого отдела rootDep в другие отделы чемодана
            rootDep.AddDep(AviaryDepFirst);
            rootDep.AddDep(GrazingDepFirst);
            rootDep.AddDep(RoomDepFirst);

            // добавляем  доступ из одних отделов в другие отделы чемодана (здесь, например из одного вольера можно попасть только в др. вольер)
            AviaryDepFirst.AddDep(AviaryDepSecondLeaf);
            GrazingDepFirst.AddDep(GrazingDepSecondLeaf);
            RoomDepFirst.AddDep(RoomDepSecondLeaf);

            RoomDepFirst.AddDep(AviaryDepSecondLeaf2);

            // Ньют сам добавляет конкретное животное (в "композит")
            AviaryDepFirst.AddPet(Occamy1);            
            GrazingDepFirst.AddPet(Bowtruckle1);           
            RoomDepFirst.AddPet(Demiguise1);

            // Ньют сам добавляет конкретное животное (в "листья")            
            AviaryDepSecondLeaf.AddPet(Occamy2);            
            GrazingDepSecondLeaf.AddPet(Bowtruckle2);           
            RoomDepSecondLeaf.AddPet(Demiguise2);

        }

        [TestMethod]
        public void FoodPerDayAllTest() //Общее дневное потребление еды для всех животных в чемодане    
        {
            double FoodPerDayAll = rootDep.FoodPerDayAll(.0);
            double ExpectedFoodPerDayAll = 80.0;
            Assert.AreEqual(ExpectedFoodPerDayAll, FoodPerDayAll);
        }

        [TestMethod]
        public void TotalAnimalTest() // Общее количество всех животных в отделе чемодана
        {
            double TotalAnimal = rootDep.TotalAnimal(.0);
            double ExpectedTotalAnimal = 7.0;
            Assert.AreEqual(ExpectedTotalAnimal, TotalAnimal);
        }

        [TestMethod]
        public void AddPetTest_AnimalCountZero()//добавление животного в данный ПУСТОЙ отдел чемодана
        {
            string ExpectString = "Animal " + Runespoor1.ToString().Substring(26) + " added";
            string ResultString = AviaryDepSecondLeaf2.AddPet(Runespoor1);
            Assert.AreEqual(ExpectString, ResultString);            
        }

         [TestMethod]
        public void AddPetTest_AnimalComp() // проверка на совместимость животных при добавлении несовместимого животного в данный отдел чемодана
        {
            string ExpectString = "Sorry " + Runespoor1.ToString().Substring(26) + " wrong animal group";
            string ResultString = AviaryDepSecondLeaf.AddPet(Runespoor1); // добавляем змею к окками (не совместимы)
            Assert.AreEqual(ExpectString, ResultString);
            //Assert.AreEqual(typeof(string), " ".GetType());
        }

         [TestMethod]
         public void DayTest() // public override void Day() // изменяем состояние на - день (состояние)
         {
             State_DayNight DayStateL = new State_Night(); // создаем - ночное время суток
             String ExpectString = DayStateL.GetType().ToString();
             rootDep.Night();

             Assert.AreEqual(ExpectString, rootDep.DayState.GetType().ToString());             
         }

    }
}
