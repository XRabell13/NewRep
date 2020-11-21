using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kLabsSharp_10
{
    /*
  Вывести: 
    список поездов, следующих до заданного пункта назначения; 
    список поездов, следующих до заданного пункта назначения и отправляющихся после заданного часа; 
    максимальный поезд по количеству мест 
    последние пять поездов по времени отправления 
    упорядоченный список поездов по пункту назначения в алфавитном порядке    
     */
    class Program
    {
        public class Train
        {
            const string NameStation = "Минск-Пассажирский";// поле константа
            private static int count = 0;//статическая переменная
            public string endPunct { get; set; } //свойство
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
                count++;
                // Console.WriteLine(count);
                endPunct = "Неизвестно";
                time = new DateTime();
                numberTrain = 0;
                CountSeats = (0, 0, 0, 0);
                ID = Convert.ToString(endPunct.GetHashCode() + time.GetHashCode());
                Allseat = this.AllSeats();

            }

            public Train(string n, int hour, int minute, int numberTr, int g, int c, int r, int l) // 2 конструктор со всеми параметрами
            {

                try
                {
                    endPunct = n;
                    time = new DateTime(2020, 9, 27, hour, minute, 0);  // год - месяц - день - час - минута - секунда
                    numberTrain = numberTr;
                    CountSeats = (g, c, r, l);
                    ID = Convert.ToString(endPunct.GetHashCode() + time.GetHashCode());
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
                    endPunct = n;
                    time = new DateTime(2020, 9, 27, hour, minute, 0);  // год - месяц - день - час - минута - секунда
                    numberTrain = numberTr;
                    CountSeats = (100, 50, 25, 10);//типа стандарт
                    ID = Convert.ToString(endPunct.GetHashCode() + time.GetHashCode());
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


            ///////////////////ПЕРЕОПРЕДЕЛЕНИЯ МЕТОДОВ/////////////////////////////////

            public override string ToString()
            {
                return "\nСтанция отправления: " + NameStation + "\nКонечная станция: " + endPunct +
                    "\nВремя отправления:  " + time.TimeOfDay + "\nНомер поезда: " + numberTrain +
                    "\nКоличество общих мест: " + CountSeats.general + "\nКоличество купэ мест: " + CountSeats.compartment +
                    "\nКоличество плацкарт мест: " + CountSeats.reserved + "\nКоличество люкс мест: " + CountSeats.lux +
                    "\nКоличество всех мест в поезде: " + this.AllSeats();
            }

            public override int GetHashCode()
            {
                // 269 или 47 простые
                int hash = 269;
                hash = string.IsNullOrEmpty(endPunct) ? 0 : endPunct.GetHashCode();
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

        public class Passenger
        {
            public string Punct { get; set; } //пункт назначения 
            public string Name { get; set; } //имя пассажира
            public DateTime Time { get; set; } //время отправления
        }
      
        static void Main(string[] args)
        {
            //===========================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ===========================================

            Console.WriteLine("===========================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ===========================================\n");

            int n;
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "Septemder", "October", "November", "Decemder" };

            // var selectedTeams = from t in months // определяем каждый объект из teams как t
            //                    where t.ToUpper().StartsWith("Б") //фильтрация по критерию
            //                    orderby t  // упорядочиваем по возрастанию
            //                   select t; // выбираем объектString.Equals(n, "Ольга"))

            Console.WriteLine("Введите количество букв в месяце: ");
            n = Convert.ToInt32(Console.ReadLine());

            IEnumerable<string> aMonths = from objM in months
                                          where objM.Length == n
                                          select objM;

            foreach (string a in aMonths)
                Console.WriteLine(a);
            Console.WriteLine("\nЗимние и летние месяцы\n");
            IEnumerable<string> WinterAndSummer = months.Where(objM => objM == "January" || objM == "February" || objM == "Decemder"
                                                 || objM == "June"
                                                 || objM == "July"
                                                 || objM == "August");
            foreach (string a in WinterAndSummer)
                Console.WriteLine(a);
            Console.WriteLine("\nМесяцы в алфавитном порядке\n");
            IEnumerable<string> alph = months.OrderBy(s => s).ThenBy(s => s);

            foreach (string a in alph)
                Console.WriteLine(a);
            
            IEnumerable<string> uNum = months.Where(objM => objM.IndexOf("u") >= 1 && objM.Length >= 4);

            Console.WriteLine("\nМесяцы c u и с количеством букв не менее 4\n");
            foreach (string a in uNum)
                Console.WriteLine(a);
            Console.WriteLine($"Количество их: {uNum.Count()}");


            //===========================================ВТОРОЙ И ТРЕТИЙ ПУНКТ ЗАДАНИЯ===========================================

            Console.WriteLine("\n===========================================ВТОРОЙ И ТРЕТИЙ ПУНКТ ЗАДАНИЯ===========================================\n");

            List<Train> ListTrains = new List<Train>();

            Train train_1 = new Train("Brest", 12, 43, 27, 12, 34, 12, 34);
            Train train_2 = new Train("Grodno", 19, 25, 13, 65,11,5,77);
            Train train_3 = new Train("Knyaginin", 18, 16, 3,34,23,12,7);
            Train train_4 = new Train("Mozir", 8, 15, 19, 6,4,23,12);
            Train train_5 = new Train("Budslow", 13, 3, 45,45,45,45,45);
            Train train_6 = new Train("Vitebsk", 14, 55, 23,22,22,22,22);
            Train train_7 = new Train("Moskwa", 16, 34, 1,12,12,12,12);
            Train train_77 = new Train("Moskwa", 16, 34, 1,12,12,12,12);
            Train train_8 = new Train("Brest", 6, 0, 54,0,0,70,30);
            Train train_9 = new Train("Knyaginin", 5, 48, 26,12,12,34,23);

            ListTrains.Add(train_1);
            ListTrains.Add(train_2);
            ListTrains.Add(train_3);
            ListTrains.Add(train_4);
            ListTrains.Add(train_5);
            ListTrains.Add(train_6);
            ListTrains.Add(train_7);
            ListTrains.Add(train_77);
            ListTrains.Add(train_8);
            ListTrains.Add(train_9);

            Console.WriteLine("\n\t\t\t\tВывод поездов до пункта назначения Княгинин: ");
            //точечна нотация
            IEnumerable<Train> zapros_1 = ListTrains.Where(objM => objM.endPunct == "Knyaginin");
            // синтаксис выражения запросов
            // IEnumerable<Train> zapros_11 = from objM in ListTrains where objM.endPunct == "Knyaginin" select objM;

            foreach (var a in zapros_1)
                Console.WriteLine(a);

            Console.WriteLine("\n\t\t\t\tВывод поездов до пункта назначения Княгинин и отправляющиеся после заданного часа(15): ");
            IEnumerable<Train> zapros_2 = ListTrains.Where(objM => objM.endPunct == "Knyaginin" && objM.time.Hour > 15);

            foreach (var a in zapros_2)
                Console.WriteLine(a);

            Console.WriteLine("\n\t\t\t\tПоезд с максимальным количеством мест: ");
            
            var maxs = ListTrains.Max(objM => objM.Allseat);
            var zapros_3 = ListTrains.Where(objM => objM.Allseat==maxs);
            foreach (var a in zapros_3)
                Console.WriteLine(a);

           
            Console.WriteLine("\n\t\t\t\tПять последних поездов: ");

            IEnumerable<Train> zapros_4 = ListTrains.OrderBy(ObjM => ObjM.time.Hour).Skip(Math.Max(0, ListTrains.Count() - 5));
            foreach (var a in zapros_4)
                Console.WriteLine(a);

            Console.WriteLine("\n\t\t\t\tСписок поездов в алфавитном порядке: ");

            IEnumerable<Train> zapros_5 = ListTrains.OrderBy(s => s.endPunct);
            foreach (var a in zapros_5)
                Console.WriteLine(a);

            //===========================================ЧЕТВЕРТЫЙ ПУНКТ ЗАДАНИЯ===========================================

            Console.WriteLine("\n===========================================ЧЕТВЕРТЫЙ ПУНКТ ЗАДАНИЯ===========================================\n");
            //алфавитный порядок(упорядочивание), после 13 часов(ограничение), отобрать 4 записи с начала(разбиение),убрать повторяющиеся 
            //элементы(множество), последний(элемент).Last(),
            var PrimZapros = ListTrains.Where(objM => objM.time.Hour >= 13).OrderBy(s => s.endPunct).Take(4).Distinct().Last();

            Console.WriteLine(PrimZapros.ToString());


            //===========================================ПЯТЫЙ ПУНКТ ЗАДАНИЯ===========================================

            Console.WriteLine("\n===========================================ПЯТЫЙ ПУНКТ ЗАДАНИЯ===========================================\n");

            List<Passenger> passengers = new List<Passenger>()
            {
            new Passenger {Name="Олег",Punct="Brest", Time= new DateTime(2020, 9, 27, 6, 0, 0)},
            new Passenger {Name="Мария",Punct="Brest", Time= new DateTime(2020, 9, 27, 12, 43, 0)},
            new Passenger {Name="Гриша", Punct="Mozir", Time= new DateTime(2020, 9, 27, 8, 15, 0)},
            new Passenger {Name="Егор", Punct="Grodno", Time= new DateTime(2020, 9, 27, 19, 25, 0)},

            };

            var result = from pass in passengers
                         join tr in ListTrains on pass.Time equals tr.time
                         select new { Name = pass.Name, Inf = tr.ToString()};

            foreach (var a in result)
                Console.WriteLine($"Пассажир:{a.Name}\nИнформация о поезде пассажира:{a.Inf}\n");

        }
        }
    }

