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
    public partial class Program //массив кортежей
    {

        private static void GeomFigure_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    GeomFigure NewFigure = e.NewItems[0] as GeomFigure;
                    Console.WriteLine($"\nДобавлен новый объект: ");
                    for (int i = 0; NewFigure.figurs[i] != null; i++)
                        Console.WriteLine(NewFigure.figurs[i]);
                    Console.WriteLine('\n');
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    GeomFigure OldFigure = e.OldItems[0] as GeomFigure;
                    Console.WriteLine($"\nУдален объект: ");
                    for (int i = 0; OldFigure.figurs[i] != null; i++)
                        Console.WriteLine(OldFigure.figurs[i]);
                    Console.WriteLine('\n');

                    break;
            }
        }
        class GeomFigureEnumerator : IEnumerator
        {
            string[] figurs;
            int position = -1;


            public GeomFigureEnumerator(string[] figurs)
            {
                this.figurs = figurs;
            }

            public object Current
            {
                get
                {
                    if (position == -1 || position >= figurs.Length)
                        throw new InvalidOperationException();
                    return figurs[position];
                }
            }

            public bool MoveNext()
            {
                if (position < figurs.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                position = -1;
            }
        }

        class GeomFigure
        {

            public int ind = 0;
            public string[] figurs = new string[10];

            //===========================================Конструкторы===========================================

            public GeomFigure(int count, int len, string nameFigurs)
            {
                figurs[ind] = nameFigurs + " " + count + " " + len + " ";
                ind++;
                Console.WriteLine("\t\t\t\tСработал конструктор  GeomFigure(int count, int len, string nameFigurs)\n");
            }
            public GeomFigure(int count, int len)
            {
                string nameFigurs = "";
                switch (count)
                {
                    case 3: nameFigurs = "Треугольник"; break;
                    case 4: nameFigurs = "Квадрат"; break;
                    case 5: nameFigurs = "Пятиугольник"; break;
                    case 6: nameFigurs = "Шестиугольник"; break;
                    case 7: nameFigurs = "Семиугольник"; break;
                    case 8: nameFigurs = "Восьмиугольник"; break;
                    case 9: nameFigurs = "Девятиугольник"; break;
                    case 10: nameFigurs = "Правильный многоульник"; break;

                    default:
                        nameFigurs = "Неизвестно";
                        break;
                }
                figurs[ind] = nameFigurs + " " + count + " " + len;
                ind++;
                Console.WriteLine("\t\t\t\tСработал конструктор GeomFigure(int count, int len)\n");

            }
            public GeomFigure()
            {
                figurs[ind] = "Треугольник 3 10";
                ind++;
                Console.WriteLine("\t\t\t\tСработал конструктор GeomFigure()\n");

            }

            //==============================================Методы==============================================

            public IEnumerator GetEnumerator()
            {
                return new GeomFigureEnumerator(figurs);
            }
            public void Add(int count, int len, string nameFigure)
            {
                figurs[ind] = nameFigure + " " + count + " " + len;

                Console.WriteLine("\t\t\t\tСработал Add с тремя параметрами\n");
                Console.WriteLine($"Добавили {ind}-ый элемент: {figurs[ind]}\n");
                ind++;
            }
            public void Add(int count, int len)
            {
                string nameFigurs = "";
                switch (count)
                {
                    case 3: nameFigurs = "Треугольник"; break;
                    case 4: nameFigurs = "Квадрат"; break;
                    case 5: nameFigurs = "Пятиугольник"; break;
                    case 6: nameFigurs = "Шестиугольник"; break;
                    case 7: nameFigurs = "Семиугольник"; break;
                    case 8: nameFigurs = "Восьмиугольник"; break;
                    case 9: nameFigurs = "Девятиугольник"; break;
                    case 10: nameFigurs = "Правильный многоульник"; break;

                    default:
                        nameFigurs = "Неизвестно";
                        break;
                }
                figurs[ind] = nameFigurs + " " + count + " " + len;

                Console.WriteLine("\t\t\t\tСработал Add с двумя параметрами\n");
                Console.WriteLine($"Добавили {ind}-ый элемент: {figurs[ind]}\n");
                ind++;
            }

            string Shows()
            {
                string a = null;
                for (int i = 0; figurs[i] != null; i++)
                {
                    a += figurs[i] + '\n';
                }
                return a;
            }

            public override string ToString()
            {
                return this.Shows();
            }

        }
    }
}