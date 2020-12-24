using System;
using System.Collections.Generic;
using System.IO;

namespace _2kLabs_Sharp_3_2_
{
    public static class StatisticOperation
    {
        public class Owner
        {
            static string ID = "124563765433";
            static string Name = "Цягунович Татьяна", NameOrganization = "NameOrg";

            public static string inf()
            {

                return "Создель:" + Name + "\nОрганизация: " + NameOrganization + "\nID:" + ID;
            }
        }

        public class Date
        {
            static public DateTime time = new DateTime(2020, 10, 19, 9, 0, 0);
            public static string inf()
            {

                return "Время создания: " + time;

            }

        }

        public static bool IsNull(this Program.MineCollectionType<bool> list)//проверка на нулевые элементы в списке
        {

            if (list.Element == null) return true; // true если имеется элемент null или "0"
            return false;//false, если не имеется
        }

        //n - номер строки в массиве
        public static int Split(this Program.MineCollectionType<int> list)//подсчет количества слов в строке массива
        {
            if (list.Element != null)
                return list.Element.Split(new char[] { ' ' }).Length;
            else return 0;
        }

        public static int Sum(this Program.MineCollectionType<int> list)//сумма количеств символов в словах строки
        {
            int summ = 0;
            string[] str = list.Element.Split(new char[] { ' ' });

            for (int k = 0; k < str.Length; k++)
            {
                char[] ch = str[k].ToCharArray();
                summ += ch.Length;
            }

            return summ;
        }

      public static int Count(this Program.MineCollectionType<int> list)
        {
            return list.numb + 1;
        }
        public static int Razn(this Program.MineCollectionType<int> list)//сумма количеств символов в словах строки
        {

            string[] str = list.Element.Split(new char[] { ' ' });
            int max = 0, min = 0; int w = 1;

            for (int k = 0; k < str.Length; k++)
            {
                char[] ch = str[k].ToCharArray();

                if (w == 1) { max = ch.Length; min = ch.Length; w++; }
                if (max <= ch.Length) max = ch.Length;
                if (min >= ch.Length) min = ch.Length;

            }

            Console.WriteLine("Макс: {0};\nМин: {1}.", max, min);

            return max - min;
        }

    }

    public partial class Program
    {
        public class MineCollectionType<T> : IMineOperation<T> //T может принимать только наследников класса Transport
        {

            public string Element;
            private List<T> LParts = new List<T>();
            public int numb;
            //------------------------------Конструкторы--------------------------

            public MineCollectionType()//конструктор без параметров
            {
                Console.WriteLine("\t\t\t\tИспользуется конструктор без параметров");
                Element = "Null";
                numb = 0;
            }

            public MineCollectionType(string value)//конструктор с параметрами
            {
                Console.WriteLine("\t\t\t\tИспользуется конструктор с параметрами");
                Element = value;
                numb = 0;
            }



            //-----------------------------Методы----------------------------------
            public void Add(T a)
            {
                Console.WriteLine("\t\t\t\tИспользуется метод Add");
                LParts.Add(a);
            }

            public void Delete(int ind)
            {

                Console.WriteLine("\t\t\t\tИспользуется метод Delete");
                LParts.RemoveAt(ind);
            }

            public void Show()
            {
                Console.WriteLine("\t\t\t\tИспользуется метод Show");
                Console.WriteLine($"Element: {Element}\nnumb: {numb}\nCollection LParts: ");
                for (int i = 0; i < LParts.Count; i++)
                    Console.WriteLine($"LParts[{i}]: {LParts[i]}\n\n\n");
               
            }

            public string Read(string patch)
            {
                string str = null;
                string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_7\";
                try
                {
                    writePath += patch;
                    using (StreamReader sr = new StreamReader(writePath))
                    {
                      str = sr.ReadToEnd();
                    }
                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return str;
            }

            public void Save(string patch)
            {
                string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_7\";          
                try
                {
                    writePath += patch;
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        sw.Write(this);
                    }
                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //-------------------------Методы расширения---------------------------

            public static Program.MineCollectionType<T> operator +(Program.MineCollectionType<T> elm, string a)
            {
                Console.WriteLine("Используется метод расширения +");
                return new MineCollectionType<T> { Element = a };

            }
            public static Program.MineCollectionType<T> operator --(Program.MineCollectionType<T> elm)
            {
                Console.WriteLine("Используется метод расширения --");
                if (elm.Element != null)
                {
                    return new MineCollectionType<T> { Element = null };
                }
                else return new MineCollectionType<T> { Element = null };
            }

        /*    public static bool operator !=(Program.MineCollectionType<T> elm1, Program.MineCollectionType<T> elm2)// проверка на неравенство
            {
                if (!int.TryParse(elm1.Element, out int i))
                {
                    Console.WriteLine("Число 1 строка, за числовое значение считаем колво слов");
                    i = elm1.Split();

                }

                if (!int.TryParse(elm2.Element, out int j))
                {
                    Console.WriteLine("Число 2 строка, за числовое значение считаем колво слов");
                    j = elm2.Split();
                }
                //  Console.WriteLine($"{i},{j}");

                if (i != j) return true;
                else return false;
            }
            
            public static bool operator ==(Program.MineCollectionType<T> elm1, Program.MineCollectionType<T> elm2)
            {
                if (!int.TryParse(elm1.Element, out int i))
                {
                    Console.WriteLine("Число 1 строка, за числовое значение считаем колво слов");
                    i = elm1.Split();

                }
       
                if (!int.TryParse(elm2.Element, out int j))
                {
                    Console.WriteLine("Число 2 строка, за числовое значение считаем колво слов");
                    j = elm2.Split();
                }
                //   Console.WriteLine($"{i},{j}");

                if (i == j) return true;
                else return false;
            } */
            
            public static bool operator true(MineCollectionType<T> list)//если строка упорядочена, то буедт тр
            {
                char[] mas = list.Element.ToCharArray();
                int num = mas.Length;
                int u = 0;
                for (int i = 0; i < num - 1; i++)
                    if (mas[i] < mas[i + 1]) u++;
                    else return false;//строка не упорядочена по символам unicode
                return true;//строка упорядочена по символам unicode

            }

            public static bool operator false(MineCollectionType<T> list)
            {
                char[] mas = list.Element.ToCharArray();
                int num = mas.Length;
                int u = 0;
                for (int i = 0; i < num - 1; i++)
                    if (mas[i] < mas[i - 1]) u++;
                    else return true;//строка не упорядочена по символам unicode
                return false;
            }
            public override string ToString()
            {
                string str = null ;
                for (int i = 0; i < LParts.Count; i++)
                { str += LParts[i]; }
                return Element + " " + numb + " "+ str;
            }
        }


        static void Main(string[] args)
        {
            int n = 0;
            bool flag = true;
            MineCollectionType_1<int> IntCollec = new MineCollectionType_1<int>();
            MineCollectionType_1<double> FloatCollec = new MineCollectionType_1<double>();
            IntCollec.Add(23); IntCollec.Add(2);
            FloatCollec.Add(23.333); FloatCollec.Add(1.13); FloatCollec.Add(20.20);
            IntCollec.Show();
            FloatCollec.Show();
            FloatCollec.Delete(1);
            FloatCollec.Show();
            MineCollectionType<Car> Cars = new MineCollectionType<Car>();
            Car car1 = new Car("qwerty", "bently", "123943");
            Car car2 = new Car("cars", "astra", "143212");
            Cars.Add(car1); Cars.Add(car2);
            Cars.Show(); Cars.Delete(1); Cars.Show();
            Console.WriteLine("Введите значение, которое необходимо добавить в коллекцию IntCollec: ");
            try
            {
                Console.WriteLine("Используется try");
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Используется catch(Exception)");
                Console.Write(ex.Message + "\n\n");
                Console.Write(ex.TargetSite + "\n\n");
                Console.Write(ex.StackTrace + "\n\n");
                while (flag)
                {
                    string k;
                    Console.WriteLine("Введите допустимое значение для IntCollec: ");
                    k = Console.ReadLine();
                    if (int.TryParse(k, out n))
                    {
                        Console.WriteLine("Преобразование прошло успешно");
                        flag = false;
                    }
                    else
                        Console.WriteLine("Преобразование завершилось неудачно");
                }
            }
            finally{
                Console.WriteLine("Используется finally");
                flag = true;
                IntCollec.Add(n);
            }
          
            IntCollec.Show();
            Cars.Save("saveObj.txt");
            Console.WriteLine(Cars.Read("saveObj.txt"));
            FloatCollec.Save("saveObj_1.txt");
            Console.WriteLine(FloatCollec.Read("saveObj_1.txt"));
        }
    }  
}


   
