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

namespace _2kLabsSharp_5
{

    public partial class Program
    {
       
        /*
         * Создать частое Транспортное агентство. 
         * Подсчитать стоимость всех транспортных средств. (суммма всех прайз)
         * Провести сортировку автомобилей по расходу топлива. 
         * Найти транспортное в компании, соответствующий заданному диапазону параметров скорости.(вывод всех средств в цикле)
         */

        /* https://www.cyberforum.ru/csharp-beginners/thread777840.html */
        struct Str
        {
            int elem;
            string fhraza;
            //и т.д... инициилизировать в самой структуре нельзя
            public Str(int elem, string fhraza)
            {
                Console.WriteLine($"Конструктор Str");
                this.elem = elem;
                this.fhraza = fhraza;
            }
           /* public Str(int elem)
            {
                this.elem = elem;
               
            }

            public Str()
              { }*/

            public void DisplayInfo()
            {
                Console.WriteLine($"Elem: {elem}  Fhraza: {fhraza}");
            }
        }

       public  abstract class TransAgency
        {
            protected const int n = 15;
            public Transport[] TransMas = new Transport[n];

            int ind;
            int Index { get { return Index; } set { if (value < 15) Index = value; else Index = 14; } }

            public void Add(Transport TrObj)
            {
                Console.WriteLine("\n\t\t\t\tСработал метод Add");

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
            public void Delete(int Index)
            {
                TransMas[Index] = new Transport();
               for (int j = Index; j < ind; j++)
                {
                    TransMas[j] = TransMas[j + 1];
                   if (j + 1 == ind) TransMas[j + 1] = new Transport();
                }
                ind--;
            }
         
            public void Show()
            {
                Console.WriteLine("\n\t\t\t\tНаходимся в методе Show в CodeFiles1.cs");

                for (int i = 0; i <ind; i++)
                {
                    Console.WriteLine($"{ TransMas[i]}\n");

                }
            }
        }

        public class Controller : TransAgency
        {
            public decimal Summ()
            {
                Console.WriteLine("\n\t\t\t\tСработал метод Summ");

                decimal summ = 0;
               
                for (int j = 0; TransMas[j].GetPrice() != 0; j++)
                {
                    summ += TransMas[j].GetPrice();
                }
                return summ;

            }

            public void SortAvto()
            {
                Console.WriteLine("\n\t\t\t\tСработал метод SortAvto");

                int k =0, N=0;
                for (int j = 0; TransMas[j].GetPrice() != 0; j++)
                {

                    if (TransMas[j] is Car) N++;
                }

                Transport[] Mas = new Transport[N];
                for (int j = 0; j < Mas.Length; j++)
                {
                    Mas[j] = new Transport();
                }
                for (int j = 0; TransMas[j].GetPrice() != 0; j++)
                {
                 //   Console.WriteLine(TransMas[j].GetType());
                    if (TransMas[j] is Car) { Mas[k] = TransMas[j]; k++; }
                }

                Transport temp = new Transport();
                for (int i = 0; i < Mas.Length; i++)
                {
                    for (int j = i + 1; j < Mas.Length; j++)
                    {
                        if (Mas[i].GetConsumption() > Mas[j].GetConsumption())
                        {
                            temp = Mas[i];
                            Mas[i] = Mas[j];
                            Mas[j] = temp;
                        }
                    }
                }
                for (int j = 0; j<Mas.Length; j++)
                {
                    Console.WriteLine("\n{0}",Mas[j]);
                }

            }

            public void DiapazonSpeed(int from, int to)
            {
                Console.WriteLine("\n\t\t\t\tМетод DiapazonSpeed"); 
                for (int i = 0; i < TransMas.Length; i++)
                {
                    if (TransMas[i].GetMaxSpeed() > from & TransMas[i].GetMaxSpeed() < to)
                        Console.WriteLine("\n{0}\n",TransMas[i]);
                }
            }

        }


    }

}