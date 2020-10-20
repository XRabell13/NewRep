using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _2kLabs_Sharp_3_2_
{
    /*Класс - список List. 
    * Дополнительно перегрузить следующие операции: 
    * + - добавить элемент в конец (list+item); 
    * -- - удалить элемент из конца (типа list--); 
    * != - проверка на неравенство;
    * true – проверка упорядоченности элементов.
    
    * Методы расширения: 
    * 1) Подсчет количества слов.  
    * 2) Проверка на нулевые элементы */
    public static class StatisticOperation
    {
        public class Owner
        {
            static string ID = "124563765433";
            static  string Name = "Цягунович Татьяна", NameOrganization = "NameOrg";

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

        public static bool IsNull(this Program.List list)//проверка на нулевые элементы в списке
        {

            if (list.Element == null) return true; // true если имеется элемент null или "0"
            return false;//false, если не имеется
        }

        //n - номер строки в массиве
        public static int Split(this Program.List list)//подсчет количества слов в строке массива
        {
            if (list.Element != null)
                return list.Element.Split(new char[] { ' ' }).Length;
            else return 0;
        }

        public static int Sum(this Program.List list)//сумма количеств символов в словах строки
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

        public static int Count(this Program.List list)
        {
            return list.numb+1;
        }

        public static int Razn(this Program.List list)//сумма количеств символов в словах строки
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

            return max-min;
        }

    }

    public class Program
    {

        public class List
        {

            public string Element;
            public int numb;

            //------------------------------Конструкторы--------------------------

            public List()//конструктор без параметров
            {
                Element = null;
                
            }

            public List(string value)//конструктор с параметрами
            {
                Element = value;
            }

          

            //-------------------------Методы расширения---------------------------

            public static Program.List operator +(Program.List elm, string a)
            {
                Console.WriteLine("Используется метод расширения +");
                return new List { Element = a };

            }
            public static Program.List operator --(Program.List elm)
            {
                Console.WriteLine("Используется метод расширения --");
                if (elm.Element != null)
                {
                    return new List { Element = null };
                }
                else return new List { Element = null };
            }

            public static bool operator !=(Program.List elm1, Program.List elm2)// проверка на неравенство
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

            public static bool operator ==(Program.List elm1, Program.List elm2)
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
            }

            public static bool operator true(List list)//если строка упорядочена, то буедт тр
            {
                char[] mas = list.Element.ToCharArray();
                int num = mas.Length;
                int u = 0;
                for (int i = 0; i < num - 1; i++)
                    if (mas[i] < mas[i + 1]) u++;
                    else return false;//строка не упорядочена по символам unicode
                return true;//строка упорядочена по символам unicode

            }

            public static bool operator false(List list)
            {
                char[] mas = list.Element.ToCharArray();
                int num = mas.Length;
                int u = 0;
                for (int i = 0; i < num - 1; i++)
                    if (mas[i] < mas[i - 1]) u++;
                    else return true;//строка не упорядочена по символам unicode
                return false;
            }
        }

            class Menu
            {
                public static void Show()
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine(" 1. Добавить элемент(+)");
                    Console.WriteLine(" 2. Посчитать количество слов в строке(Split).");
                    Console.WriteLine(" 3. Проверить, есть ли нулевые элементы в массиве(IsNull).");
                    Console.WriteLine(" 4. Вывести все элементы.");
                    Console.WriteLine(" 5. Удалить последний элемент(--).");
                    Console.WriteLine(" 6. Проверить на неравенство два элемента(!=)(not work).");
                    Console.WriteLine(" 7. Проверить на упорядоченность(true).");
                    Console.WriteLine(" 8. Сумма элементов.");
                    Console.WriteLine(" 9. Разность между максимальным и минимальным элементами.");
                    Console.WriteLine(" 10. Количество элементов.");
                    Console.WriteLine("11. Вывести дату создания, имя и организацию создателя.");
                    Console.WriteLine(" 0. Выход.");
                    Console.WriteLine("------------------------------------------------------------------\n Ваш выбор: ");

                }
            }

            static void Main(string[] args)
            {

                int num;
                bool fl = true;
                string str;
                int n = 0;
                int ind = 0;
    
           
                Console.WriteLine("Введите количество элементов: ");
                num = Convert.ToInt32(Console.ReadLine()); 
                List[] elem = new List[num]; 
              

               for (int u = 0; u < elem.Length; u++)
                {
                elem[u] = new List();
              

            }
            elem[0].numb = num;

            while (fl)
                {

                    Menu.Show();
                    n = Convert.ToInt32(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите элемент: ");
                                str = Convert.ToString(Console.ReadLine());
                                elem[ind] += str;
                            elem[0].numb = ind;
                            Console.WriteLine($"Количество элементов: {elem[0].Count()}");
                            ind++;

                            }

                            break;
                        case 2:
                             {
                                  Console.WriteLine("Введите номер элемента: ");
                                  n = Convert.ToInt32(Console.ReadLine());
                                  Console.WriteLine("Количество слов: {0}", elem[n].Split());
                             }
                            break;
                        case 3:
                             {
                                int fs=0, tr=0;
                                for (int i = 0; i < num; i++)
                                    if (elem[i].IsNull())
                                        fs++;
                                    else
                                        tr++;

                                if (fs>tr)
                                    Console.WriteLine("В списке есть нулевые элементы");
                                else
                                    Console.WriteLine("В списке НЕТ нулевых элементов");


                            }
                            break;
                        case 4:
                            {
                                    for (int u = 0; u != num; u++)                           
                                    Console.WriteLine("Element[{0}]: {1}", u, elem[u].Element);              
                            }
                            break;
                        case 5:
                            {
                                if (!(elem[0].IsNull()))
                                {
                                    for (int i = 0; i < num; i++)
                                        if (elem[i].IsNull())
                                        {
                                        elem[i - 1]--;
                                        ind--;
                                            break;
                                        }
                                }
                                else Console.WriteLine("Список пуст!");
                            }
                            break;
                    case 6:
                        {
                            int a, b;
                            Console.WriteLine("Введите номер элемента 1: ");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите номер элемента 2: ");
                            b = Convert.ToInt32(Console.ReadLine());

                            if(elem[a]!=elem[b]) Console.WriteLine("Элементы НЕ равны!");
                            else Console.WriteLine("Элементы равны!");

                        }
                        break;
                    case 7:
                        Console.WriteLine("Введите номер элемента: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (elem[n]) Console.WriteLine("Упорядочено");
                            else Console.WriteLine("Не упорядочено");
                        break;

                    case 8://сумма длин слов в строке
                        {
                            Console.WriteLine("Введите номер элемента: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Сумма: {0}", elem[n].Sum());
                           
                        }
                            break;
                    case 9: //найти максимальный и минимальный разницу длин слов
                        {
                            Console.WriteLine("Введите номер элемента: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Разность макс. и мин. : {0}", elem[n].Razn());

                        }
                        
                            break;
                    case 10:
                        {
                          
                            Console.WriteLine($"Количество элементов: {elem[0].Count()}");
                        }
                        break;
                    case 11:
                        {

                            Console.WriteLine(StatisticOperation.Owner.inf());
                            Console.WriteLine(StatisticOperation.Date.inf());
                        }
                        break;

                    case 0:
                            fl = false;
                            break;
                        default: fl = false; break;
                    }
                }
            }
    }
}

