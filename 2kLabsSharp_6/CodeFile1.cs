using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _2kLabsSharp_4
{

    public partial class Program
    {
        /*   enum Color
           {
               Red, Orange, Yellow, Green, Blue, Purple
           }*/
        /*
         * Создать частое Транспортное агентство. 
         * Подсчитать стоимость всех транспортных средств. (суммма всех прайз)
         * Провести сортировку автомобилей по расходу топлива. (перебирать обьекты и в массив записывать, а потом рассортировать в массива
         * и вывести в нужном порядке из того массива)
         * Найти транспортное в компании, соответствующий заданному диапазону параметров скорости.(вывод всех средств в цикле)
         */

        /*класс-контейнер иммет гет и сет для вывода определнного обьтека из массива, или ввода
        методы добавить и удалить... в контейнере типа массив класса Transport, чтобы в нем могли храниться 
        все эти обьекты, наследники же.. ?
        в классе контролере...
        есть методы, которые принимают обьект контейнера и делают над ним всякие дейсвия... для этого точно масив внутри класса
        быть должен, ане классовый массив*/
        struct Str
        {
            int elem;
            string[] fhraza;
            //и т.д... инициилизировать в самой структуре нельзя
        }

       public  abstract class TransAgency
        {
            const int n = 15;
            public Transport[] TransMas = new Transport[n];

            int ind;
            int Index { get { return Index; } set { if (value < 15) Index = value; else Index = 14; } }

            public void Add(Transport TrObj)
            {
                if (ind == 0)
                {
                    for (int k = 0; k < n; k++)
                    {
                        TransMas[k] = new Transport();
                    }
                }
                TransMas[ind] = TrObj;
                ind++;
            }
            public void Delete()
            {
                Console.WriteLine("Введите номер удаляемоего элементв: ");
                Index = Convert.ToInt32(Console.ReadLine());
                TransMas[Index] = new Transport();
                for (int j = Index; j < TransMas.Length; j++)
                {
                    TransMas[j] = TransMas[j + 1];
                    if (j + 1 == TransMas.Length) TransMas[j + 1] = new Transport();
                }
            }
            public void IAmPrinting(Transport someobj)
            {
                Console.WriteLine(someobj.ToString());

            }
            public void Show()
            {

                for (int i = 0; i < TransMas.Length; i++)
                {
                    Console.WriteLine(TransMas[i]);

                }
            }
        }

        public class Controller:TransAgency
        { 
           public decimal Count(Transport TrObj)
            {
                decimal summ = 0;
                for (int j = 0; j < TransMas.Length; j++)
                {
                  
                }
                return summ;

            }


        }


    }

}