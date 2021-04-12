using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2kLabs_Sharp_3_1_
{
    /*Класс - список List. 
     * Дополнительно перегрузить следующие операции: 
     * + - добавить элемент в конец (list+item); 
     * -- - удалить элемент из конца (типа list--); 
     * != - проверка на неравенство; true – проверка упорядоченности элементов.
     * Методы расширения: 
    1) Подсчет количества слов.  
    2) Проверка на нулевые элементы */

    public static class StatisticOperation
    {
        public static int Length(this String elt, char a)
        {
            return 0;
        }
    }
    class Program
    {

        class Elements
        {

            public int Element { get; set; }
        }

        class List
        {

           public Elements[] el;

            //------------------------------Конструкторы--------------------------

            public List()//конструктор без параметров
            {
                el = new Elements[10];
                
            }

            public List(int n)//конструктор с параметрами
            {
                el = new Elements[n];

            }



            //---------------------------------------------------------------------



            // индексатор
            public Elements this[int index]
            {
                get
                {
                    return el[index];
                }
                set
                {
                    el[index] = value;
                }
            }

            public int Count()
            {

                return 0;
            }


            public static List operator +(List elm, int a)
            {
                List elemt = new List();
                elemt[0] = new Elements { Element = a };
               

            }



        }

     


        static void Main(string[] args) 
        {


            List elem = new List();
            elem[0] = new Elements { Element = 23 };
            elem[1] = new Elements { Element = 13 };
            
            //elem = elem + 25;
            Elements tom = elem[0];
            Console.WriteLine(tom.Element);
            int n = elem.el.Length;

        }
    }
    
}

