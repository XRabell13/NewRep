using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class MagicClass
{
    private int magicBaseValue;

    public MagicClass()
    {
        magicBaseValue = 9;
    }

    public int ItsMagic(int preMagic, int Hi, string a)
    {
        Console.WriteLine("Метод ItsMagic сказал {0}", a);
        return preMagic * magicBaseValue*Hi;
    }
}

    public class Train
        {
            int Pole = 12;
            public int Svoistvo { get; set; }
            const string NameStation = "Минск-Пассажирский";// поле константа
            private static int count = 0;//статическая переменная
            public string EndPunct { get; set; } //свойство
            public readonly string ID;// поле только для чтения
                                      //закрытый конструктор для создания хэшфункции
            public int PrimSet
            {
                get
                {
                    return PrimSet;
                }
                set//ограничение по set
                {
                    if (value > 0) PrimSet = value;
                    else PrimSet = 0;
                }

            }
            public DateTime time { get; set; }
            public int numberTrain { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }

            public int Allseat { get; set; }

            public (int general, int compartment, int reserved, int lux) CountSeats { get; set; }//compartament(купе) reserved(плацкарт) 

          

            public Train()  // 1 конструктор без параметров, при создании без параметров будет использоваться прогой
            {
                Console.WriteLine("\n\t\t\t\tСработал конструктор без параметров Train");
                count++;
                // Console.WriteLine(count);
                EndPunct = "Неизвестно";
                time = new DateTime();
                numberTrain = 0;
                CountSeats = (0, 0, 0, 0);
                ID = Convert.ToString(EndPunct.GetHashCode() + time.GetHashCode());
                Allseat = this.AllSeats();

            }

          public Train(string n, int hour, int minute, int numberTr, int g, int c, int r, int l) // 2 конструктор со всеми параметрами
            {

                try
                {
                    EndPunct = n;
                    time = new DateTime(2020, 9, 27, hour, minute, 0);  // год - месяц - день - час - минута - секунда
                    numberTrain = numberTr;
                    CountSeats = (g, c, r, l);
                    ID = Convert.ToString(EndPunct.GetHashCode() + time.GetHashCode());
                    count++;
                    Allseat = this.AllSeats();
                }
                catch
                {
                    Console.WriteLine("Введены неверные данные");

                }



            }

            public Train(string n, int hour, int minute, int numberTr) // 3 конструктор с некоторыми параметрами по умолчанию
            {
                count++;
                try
                {
                    EndPunct = n;
                    time = new DateTime(2020, 9, 27, hour, minute, 0);  // год - месяц - день - час - минута - секунда
                    numberTrain = numberTr;
                    CountSeats = (100, 50, 25, 10);//типа стандарт
                    ID = Convert.ToString(EndPunct.GetHashCode() + time.GetHashCode());
                    Allseat = this.AllSeats();
                }
                catch
                {

                    Console.WriteLine("Введены неверные данные");

                }
            }

            //без параметров по умолчаниб вызывается всегда при запуске программы
            //Статические поля, методы, свойства относятся ко всему классу 
            //и для обращения к подобным членам класса необязательно создавать экземпляр класса. 


            // статический метод для просмотра информации о классе
            public static void GetInfo()
            {
                Console.WriteLine("\nКласс содержит: поля(ID,NameStation, count);\n" +
                    "свойства(endPunkt, time, numberTrain, hour, minute);\n" +
                    "кортеж countSeats(int general, int compartment, int reserved, int lux)\n" +
                    "Четыре конструктора;\n" +
                    "Методы: GetInfo\n" +
                    "Переопределения: ToStaring, GetHachCode, Equels.\n\n");

            }
            public int Billet(ref int typeSeats, int numbil, out bool fl3)//использование ref и out
            {
                typeSeats--;
                fl3 = true;
                numbil++;
                return 1;
            }

            public int AllSeats()//количестов мест в поезде
            {
                return CountSeats.general + CountSeats.compartment + CountSeats.reserved + CountSeats.lux;
            }

            private void HelloWorld()
            { }

            ///////////////////ПЕРЕОПРЕДЕЛЕНИЯ МЕТОДОВ/////////////////////////////////

            public override string ToString()
            {
                return "\nСтанция отправления: " + NameStation + "\nКонечная станция: " + EndPunct +
                    "\nВремя отправления:  " + time.TimeOfDay + "\nНомер поезда: " + numberTrain +
                    "\nКоличество общих мест: " + CountSeats.general + "\nКоличество купэ мест: " + CountSeats.compartment +
                    "\nКоличество плацкарт мест: " + CountSeats.reserved + "\nКоличество люкс мест: " + CountSeats.lux +
                    "\nКоличество всех мест в поезде: " + this.AllSeats();
            }

            public override int GetHashCode()
            {
                // 269 или 47 простые
                int hash = 269;
                hash = string.IsNullOrEmpty(EndPunct) ? 0 : EndPunct.GetHashCode();
                hash = (hash * 47) + time.GetHashCode();
                return hash;
            }

            public virtual Boolean Equals(Train obj)
            {
                // Сравниваемый объект не может быть равным null
                if (obj == null) return false;
                // Объекты разных типов не могут быть равны
                //  if (this.GetType() != obj.GetType()) return false;
                if (this.ID != obj.ID) return false;//сравниваем по ID, ибо если ID разные, то и поля в чем-то различаются

                return true;
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

        public class ParamType<T> where T:struct
        {
            public void Hello() => 
                Console.WriteLine(typeof(T));
            public void Str(string Hi) => Console.WriteLine(Hi);
            
        }




