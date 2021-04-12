using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace _2KLabsSharp_9
{
    public partial class Program
    {
        /* class Gen<T, G>
         {
             G ob;
             T bo;
             public Gen(G o) { ob = o; }//конструктор
             public T GetOb() { return bo; }
         }*/



        static void Main(string[] args)
        {
            //===========================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ===========================================

            /*  Gen<int, string> g = new Gen<int, string>("qwerty");
              Console.WriteLine(g.GetOb());*/
            Console.WriteLine("===========================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ===========================================\n\n");
            Stack CollFigurs = new Stack();//необобщенная, неуниверсальная коллекция стек
            

            GeomFigure quedrat = new GeomFigure(4,5);
            GeomFigure others = new GeomFigure(10,45);
            GeomFigure triangle = new GeomFigure(3, 13);
            triangle.Add(3,20); triangle.Add(3,10);
            quedrat.Add(4, 20); quedrat.Add(4, 9);
            others.Add(6, 10); others.Add(15, 15);
            
            //Добавление объектов в стек
            CollFigurs.Push(others);
            CollFigurs.Push(triangle);
            CollFigurs.Push(quedrat);
            CollFigurs.Push(123);
           

            //вывод данных из стека
            foreach (var figure in CollFigurs) Console.WriteLine(figure);
           

            //удаление данных из стека
            Console.WriteLine("\t\t\t\tУдалили последний добавленный в стек объект 'quedrat'\n");
            CollFigurs.Pop();

            foreach (var figure in CollFigurs) Console.WriteLine(figure);
        
            //===========================================ВТОРОЙ ПУНКТ ЗАДАНИЯ===========================================

            Console.WriteLine("===========================================ВТОРОЙ ПУНКТ ЗАДАНИЯ===========================================\n\n");

            Stack<int> IntCollec = new Stack<int>();//обобщенная универсальная
            Stack<char> CharCollec = new Stack<char>();
          
            IntCollec.Push(3); IntCollec.Push(2); IntCollec.Push(1); IntCollec.Push(0);
            CharCollec.Push('\n'); CharCollec.Push('!'); CharCollec.Push('!'); CharCollec.Push('i'); CharCollec.Push('H');

            foreach (var figure in IntCollec) Console.WriteLine(figure);
            
            foreach (var figure in CharCollec)Console.WriteLine(figure);
            
            
            //удаление элементов из стека
            Console.WriteLine($"Удаляем элементы {IntCollec.Pop()}, {IntCollec.Pop()}, {IntCollec.Pop()}");
            Console.WriteLine($"Удаляем элементы {CharCollec.Pop()}, {CharCollec.Pop()}, {CharCollec.Pop()}");
            
            Console.WriteLine("\nЭлементы IntCollec");
            foreach (var figure in IntCollec) Console.WriteLine(figure);

            Console.WriteLine("\nЭлементы CharCollec");

            foreach (var figure in CharCollec) Console.WriteLine(figure);
            
            //Создание новой коллекции
            List<int> IntList = new List<int>();
            List<char> CharList = new List<char>();

            foreach (var figure in IntCollec)  IntList.Add(figure);
            
            foreach (var figure in CharCollec)   CharList.Add(figure);
            
            Console.WriteLine($"Элементы IntList:");

            for (int i = 0; i < IntList.Count(); i++)
            Console.WriteLine($"Элемент {i}: {IntList[i]}");

            Console.WriteLine($"Элементы CharList:");

            for (int i = 0; i < CharList.Count(); i++)
                Console.WriteLine($"Элемент {i}: {CharList[i]}");

            Console.WriteLine("Добавили новых элементов, чтобы было что искать.");
            CharList.Add('l'); CharList.Add('l'); CharList.Add('o');
            IntList.Add(123); IntList.Add(-23); IntList.Add(90);
            
            Console.WriteLine($"\nЭлементы IntList:");

            for (int i = 0; i < IntList.Count(); i++)
                Console.WriteLine($"Элемент {i}: {IntList[i]}");

            Console.WriteLine($"\nЭлементы CharList:");

            for (int i = 0; i < CharList.Count(); i++)
                Console.WriteLine($"Элемент {i}: {CharList[i]}");

            //поиск значения в коллекциях
            Console.WriteLine($"\nПоиск буквы l в первой коллекции и поиск отрицательного числа в другой:");

            for (int i = 0; i < CharList.Count(); i++)
                if (CharList[i] == 'l') Console.WriteLine(CharList[i]);

            for (int i = 0; i < IntList.Count(); i++)
                if (IntList[i] < 0) Console.WriteLine(IntList[i]);

            //===========================================ТРЕТИЙ ПУНКТ ЗАДАНИЯ===========================================
            Console.WriteLine("===========================================ТРЕТИЙ ПУНКТ ЗАДАНИЯ===========================================\n\n");

            ObservableCollection<GeomFigure> Inspector = new ObservableCollection<GeomFigure>();

            Inspector.CollectionChanged += GeomFigure_CollectionChanged;

            Inspector.Add(others);
            Inspector.Add(triangle);
            Inspector.Add(quedrat);

            Console.WriteLine($"\nНаблюдаемая коллекция после добавления: ");

            foreach (GeomFigure figur in Inspector)
            {
                Console.WriteLine('\n');
                for (int i = 0; figur.figurs[i] != null; i++)
                    Console.WriteLine(figur.figurs[i]);
            }

            Inspector.RemoveAt(0);
         
            Console.WriteLine($"\nНаблюдаемая коллекция после удаления: ");

            foreach (GeomFigure figur in Inspector)
            {
                Console.WriteLine('\n');
                for(int i =0; figur.figurs[i]!=null; i++)
                Console.WriteLine(figur.figurs[i]);
            }
            Console.WriteLine("\n\n");

        }
    }
}
