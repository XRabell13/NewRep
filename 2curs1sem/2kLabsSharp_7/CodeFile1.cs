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
using System.Diagnostics;

namespace _2kLabsSharp_6
{

    public partial class Program
    {

        /* https://www.cyberforum.ru/csharp-beginners/thread777840.html */
        struct Str
        {
            int elem;
            string[] fhraza;
            //и т.д... инициилизировать в самой структуре нельзя
        }

        public abstract class TransAgency
        {
            protected const int n = 8;
            public Transport[] TransMas = new Transport[n];

            int ind;
            int Index { get { return Index; } set { if (value < n) Index = value; else Index = n-1; } }

            public void Add(Transport TrObj)
            {
                int di;
                Console.WriteLine("\n\t\t\t\tСработал метод Add");

                if (ind == 0)
                {
                    for (int k = 0; k < n; k++)
                    {
                        TransMas[k] = new Transport();
                    }
                }
               
                try
                {
                    TransMas[ind] = TrObj;
                    ind++;

                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Недостаточно места! Удалите один из объектов для добавления в контейнер.\n");
                    Console.Write(ex.Message + "\n\n");
                    Console.Write(ex.TargetSite + "\n\n");
                    Console.Write(ex.StackTrace + "\n\n");
                    Console.WriteLine("Выберите элемент для удаления: \n");
                    di = Convert.ToInt32(Console.ReadLine());
                    this.Delete(di);
                    TransMas[ind] = TrObj;
                    ind++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Непредвиденное исключение!");
                }
                finally
                {
                    
                    Console.WriteLine("Блок finally из метода Add");
                }
              
            }
            public void Delete(int Index)
            {
                TransMas[Index] = new Transport();
                for (int j = Index; j < ind; j++)
                {
                    if (j + 1 >= ind) { TransMas[j] = new Transport(); break; }
                    TransMas[j] = TransMas[j + 1];

                }

                ind--;
               
            }

            public void Show()
            {
                Console.WriteLine("\n\t\t\t\tНаходимся в методе Show в CodeFiles1.cs");

                for (int i = 0; i < ind; i++)
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

                for (int j = 0; j < n; j++)
                {
                    summ += TransMas[j].GetPrice();
                }
                return summ;

            }

            public void SortAvto()
            {
                Console.WriteLine("\n\t\t\t\tСработал метод SortAvto");

                int k = 0, N = 0;
                for (int j = 0; j < n; j++)
                {

                    if (TransMas[j] is Car) N++;
                }

                Transport[] Mas = new Transport[N];
                for (int j = 0; j < Mas.Length; j++)
                {
                    Mas[j] = new Transport();
                }
                for (int j = 0; j < n; j++)
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
                for (int j = 0; j < Mas.Length; j++)
                {
                    Console.WriteLine("\n{0}", Mas[j]);
                }
            }

            public void DiapazonSpeed(int from, int to)
            {
                Console.WriteLine("\n\t\t\t\tМетод DiapazonSpeed");
                bool n = true;
                for (int i = 0; i < TransMas.Length; i++)
                {
                    if (TransMas[i].GetMaxSpeed() > from & TransMas[i].GetMaxSpeed() < to) 
                    {
                        Console.WriteLine("\n{0}\n", TransMas[i]);
                        n = false;
                    }
                     
                    
                }
                     
                if(n) Console.WriteLine("Ничего не найдено!");
            }

        }

    }

}