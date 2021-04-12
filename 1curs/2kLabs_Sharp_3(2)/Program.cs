using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public static bool IsNull(this Program.List list)//проверка на нулевые элементы в списке
        {
            for (Int32 index = 0; index < list.Mas.Length; index++)
                if (list.Mas[index] == null || list.Mas[index]=="0") return true; // true если имеется элемент null или "0"
            return false;//false, если не имеется
        }

        //n - номер строки в массиве
        public static int Split(this Program.List list, int n)//подсчет количества слов в строке массива
        {
            if (list.Mas[n] != null)
                return list.Mas[n].Split(new char[] { ' ' }).Length;
            else return 0;
        }
    }
   
  public class Program
    {
     
     public class List
        {

            public string[] Mas;
 
            //------------------------------Конструкторы--------------------------

            public List()//конструктор без параметров
            {
                Mas = new string[10];
                for (int i = 0; i < this.Mas.Length; i++)
                    this.Mas[i] = "0";

            }


            //---------------------------------------------------------------------

            public static Program.List operator +(Program.List elm, string a)
            {
                Console.WriteLine("!!!");
                for (int i = 0; i < elm.Mas[i].Length; i++)
                {
                    Console.WriteLine("!!!{0}", i);
                    if (elm.Mas[i] == "0" || elm.Mas[i] == null)
                    {
                        return new List (elm.Mas[i] = a );
                    }
                    else return new List ( elm.Mas[i] = a );
                }
               // List elm1 = new List();//создали совсем новый экземпляр
                //elm.Mas.CopyTo(elm1.Mas, 0);
               /* for (int i = 0; i < elm.Mas[i].Length; i++)
                {
                    Console.WriteLine(elm.Mas[i]);
                   
                }

                for (int i = 0; i < elm.Mas[i].Length; i++)
                { 
                    Console.WriteLine("!!!{0}", i);
                    if (elm.Mas[i] == "0")
                    {
                        elm.Mas[i] = a;
                        return elm;
                    };
                }         
                return elm;*/ //если нет места, то он просто вернет тот массив, который есть, без изменений
            }

/*            public static bool operator true(List elt)//если упорядочено по возрастанию
            {
                
                int n = elt.Mas[0];
                

                if ((elt.Mas[0] != 0) || (v.Y != 0))
                    return true;
                else
                    return false;
            }

            public static bool operator false(List elt)
            {
                if ((elt.X == 0) && (v.Y == 0))
                    return true;
                else
                    return false;
            }*/


        }
        class Menu
        {
            public static void Show()
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(" 1. Добавить элемент");
                Console.WriteLine(" 2. Посчитать количество букв в строке.");
                Console.WriteLine(" 3. Проверить, есть ли нулевые элементы в массиве.");
                Console.WriteLine(" 4. Вывести все элементы.");
                Console.WriteLine(" 5. Удалить последний элемент.");
                Console.WriteLine(" 0. Выход.");
                Console.WriteLine("------------------------------------------------------------------\n Ваш выбор: ");

            }
        }
        static void Main(string[] args)
            {
            // List[] elem1 = new List[5];

            //если будет на цифра, а слово, то оно будет корвертироваться в 0 при использовании всяких арифм. операций
            List elem = new List();
         //  for (int j = 0; j < elem.Mas.Length; j++)
          //     elem.Mas[j] = "0";

            for (int j = 0; j < elem.Mas.Length; j++)
                Console.WriteLine(elem.Mas[j]);

            bool fl = true;
            string str;
            int n = 0;
            int ind=0;
            // List elem1 = new List();
            //elem = elem1;
            //  elem = 1;
            // elem.Mas[1] = elem + 34;
            //  elem.Mas[0] = elem + 78;
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
                            elem = elem + str;
                            ind++;
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Введите номер элемента: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Количество слов: {0}", elem.Split(n));
                        }
                        break;
                    case 3:
                        {
                            if (elem.IsNull())
                                Console.WriteLine("В списке есть нулевые элементы");
                            else
                                Console.WriteLine("В списке нет нулевых элементов");

                        }
                        break;
                    case 4:
                        {
                            for (int k = 0; k < elem.Mas.Length; k++)
                                Console.WriteLine("Element[{0}]: {1}", k, elem.Mas[k]);
                        }
                        break;
                    case 5:
                        break;
                    case 0: fl = false;
                        break;

                }



            }

          /*  Console.WriteLine(elem.Mas.Length);
            Console.WriteLine(elem.Mas[0]);
            Console.WriteLine(elem.IsNull());
            Console.WriteLine(Convert.ToInt32(elem.Mas[0]));
            if (int.TryParse(elem.Mas[1], out int i))
                Console.WriteLine(Convert.ToInt32(elem.Mas[1]));
            else
                Console.WriteLine("Введенная строка не являлась числом.");
            Console.WriteLine(elem.Split(1));
            Console.WriteLine(elem.Split(0));*/
            //   if (Convert.ToInt32(elem.Mas[0]) < Convert.ToInt32(elem.Mas[1])) Console.WriteLine("1<12");
            // else Console.WriteLine("heehehe");
            //elem1 = elem1 + 1;

        }
        
    }
}
