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
    public class RandomAnimalsCreator : ICreator // должен позволить на основе данных (переданных (случайное число, вес пищи) и встроенных (вероятности появления животных)) - сделать обьект рандом-фабрика,
    {                                       // который позволит рандомно выдавать разных животных с помощью фабричного метода
         
        double Occamy_probability; // вероятность что в чемодан сам залезет Occamy
        double Demiguise_probability; // вероятность что в чемодан сам залезет Demiguise
        double Bowtruckle_probability; // вероятность что в чемодан сам залезет Bowtruckle

        OccamyCreator Occamy_ ;  // ссылки на соответствующие креаторы животных
        DemiguiseCreator Demiguise_ ;
        BowtruckleCreator Bowtruckle_ ;


        public RandomAnimalsCreator(OccamyCreator Occamy_, DemiguiseCreator Demiguise_, BowtruckleCreator Bowtruckle_,
            double Occamy_probability, double Demiguise_probability, double Bowtruckle_probability)  // передаем ссылки на креаторы трех животных
        {                                                                                                              // которые могут залесть в чемодан сами
            this.Occamy_ = Occamy_;
            this.Demiguise_ = Demiguise_;
            this.Bowtruckle_ = Bowtruckle_;
            this.Occamy_probability = Occamy_probability;
            this.Demiguise_probability = Demiguise_probability;
            this.Bowtruckle_probability = Bowtruckle_probability;

        }
                     
        public ICreator getRandomFactory() // возвращает случайную фабрику 
        {
            Thread.Sleep(40); // задержка для генерации отличного случайного числа
            Random rnd = new Random();           


            double threshold = Convert.ToDouble(rnd.Next(100)) / 100; // возвращает число 0..1 (нормальное распределение)

            if (Occamy_probability >= threshold)
            {
                return Occamy_;
            }
            else if ((Occamy_probability + Demiguise_probability) >= threshold)
            {
                return Demiguise_;
            }
            else if ((Occamy_probability + Demiguise_probability + Bowtruckle_probability) >= threshold)
            {
                return Bowtruckle_;
            }
            else return null;            

        }

        public IAnimal getAnimalFM()
        {
            return getRandomFactory().getAnimalFM();           
        }

    } 
}
