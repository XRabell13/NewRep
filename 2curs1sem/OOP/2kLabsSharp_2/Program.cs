using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

/*
     Создать класс Train: Пункт назначения, Номер поезда, Время отправления, 
    Число мест (общих, купе, плацкарт, люкс). 
    Свойства и конструкторы должны обеспечивать проверку корректности.  
    Добавить метод вывода общего числа мест в поезде. Создать массив объектов. 
    Вывести: 
    a)  список поездов, следующих до заданного пункта назначения; 
    b)  список поездов, следующих до заданного пункта назначения и отправляющихся после заданного часа
     */


namespace _2KLabsSharp_2_New_
{
  class Program
    {

        partial class Menu
        {

            private Menu() { }

          

            public static void ShowDop()
            {

                Console.WriteLine(" 11. Сравнить два обьекта.");
                Console.WriteLine(" 22. Показать информацию о классе Train.");
                //   Console.WriteLine(" 33. Создать обьект класса Train по умолчанию.");

            }
        }

        partial class Menu
        {
            public static void ShowGeneral()
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(" 1. Ввести данные о поезде.");
                Console.WriteLine(" 2. Ввести расширенные данные о поезде.");
                Console.WriteLine(" 3. Получить данные о поезде, следующего до заданного пункта назначения.");
                Console.WriteLine(" 4. Получить данные о поезде, следующего до заданного пункта назначения и отправляющихся после заданного часа.");
              //Console.WriteLine(" 5. Получить данные о всех поездах.");
                Console.WriteLine(" 5 Проверка out и ref.");

                Console.WriteLine(" 6 Дополнительно.");
                Console.WriteLine(" 7 Вывести общее число мест в поезде.");

                Console.WriteLine(" 0. Выход.");
                Console.WriteLine("------------------------------------------------------------------\n Ваш выбор: ");

            }
        }

        public class Train
        {
            const string NameStation = "Минск-Пассажирский";// поле константа
            private static int count = 0;//статическая переменная
            public string endPunct { get; set; } //свойство
            public readonly string ID;// поле только для чтения
                                      //закрытый конструктор для создания хэшфункции

            public DateTime time { get; set; }
            public int numberTrain { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }

           public (int general, int compartment, int reserved, int lux) CountSeats { get; set; }//compartament(купе) reserved(плацкарт) 

            public Train()  // 1 конструктор без параметров
            {
                count++;
                // Console.WriteLine(count);
                endPunct = "Неизвестно";
                time = new DateTime();
                numberTrain = 0;
                CountSeats = (0, 0, 0, 0);
                ID = Convert.ToString(endPunct.GetHashCode() + time.GetHashCode());
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

                }
                catch
                {

                    Console.WriteLine("Введены неверные данные");
                   
                }
            }

            //без параметров по умолчаниб вызывается всегда при запуске программы
            //Статические поля, методы, свойства относятся ко всему классу 
            //и для обращения к подобным членам класса необязательно создавать экземпляр класса. 
            static Train()//статический конструктор, вызывается только один раз при создании обьекта
            {
                count = 0;
                Console.WriteLine("--------------------Добро пожаловать--------------------");

            }


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
                return CountSeats.general+CountSeats.compartment+CountSeats.reserved+CountSeats.lux;
            }

            
            ///////////////////ПЕРЕОПРЕДЕЛЕНИЯ МЕТОДОВ/////////////////////////////////
            
            public override string ToString()
            {
                return "\nСтанция отправления: " + NameStation + "\nКонечная станция: " + endPunct +
                    "\nВремя отправления:  " + time.TimeOfDay + "\nНомер поезда: " + numberTrain +
                    "Количество общих мест: " + CountSeats.general + "Количество купэ мест: " + CountSeats.compartment +
                    "Количество плацкарт мест: " + CountSeats.reserved + "Количество люкс мест: " + CountSeats.lux;
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

        static void Main(string[] args)
        {
            const int num = 10;
            int n;
            string nameSt;
            int h, m, number, g, c, r, l, i = 0;
            bool flag = true;
            bool fl = true, fl1=true;
            Train poezd = new Train();
            Train poezd1 = new Train();
            //string n, int hour, int minute, int numberTr
            Train[] Massiv = new Train[num];//создали уже num обьектов

         

            while (fl1)
            {

                if (fl)
                    Menu.ShowGeneral(); // закрытый статический класс
                else fl = true;
                n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 0: fl1 = false; break;
                    case 1:
                        {
                            if (i < num)
                            {
                                Console.WriteLine("Конечная станция: ");
                                nameSt = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("Номер поезда: ");
                                number = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Время:\n Час: ");
                                h = Convert.ToInt16(Console.ReadLine());//использовать try catch можно
                                Console.WriteLine("\n Минуты: ");
                                m = Convert.ToInt16(Console.ReadLine());

                                Massiv[i] = new Train(nameSt, h, m, number);
                                i++;
                            }
                            else Console.WriteLine("Массив переполнен!");
                        }
                        break;
                    case 2:
                        if (i < num)
                        {
                            Console.WriteLine("Конечная станция: ");
                            nameSt = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Номер поезда: ");
                            number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Время:\n Час: ");
                            h = Convert.ToInt16(Console.ReadLine());//использовать try catch можно
                            Console.WriteLine("\n Минуты: ");
                            m = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("\nКолво общих мест: ");
                            g = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("\nКолво купе мест: ");
                            c = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("\nКолво плацкарт мест: ");
                            r = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("\nКолво люкс мест: ");
                            l = Convert.ToInt16(Console.ReadLine());

                            Massiv[i] = new Train(nameSt, h, m, number, g, c, r, l);
                            i++;
                        }
                        else Console.WriteLine("Массив переполнен!");
                        break;
                    case 3:
                        {
                            Console.WriteLine("Введите конечную станцию: ");
                            nameSt = Convert.ToString(Console.ReadLine());
                            for (int k = 0; Massiv[k] != null; k++)
                                if (Massiv[k].endPunct == nameSt) { Console.WriteLine("\n{0}\n", Massiv[k].ToString()); flag = false; }
                            if (flag) { Console.WriteLine("Ничего не найдено!\n"); flag = true; }
                        }
                        break;

                    case 4:
                        {

                            Console.WriteLine("Введите конечную станцию: ");
                            nameSt = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Введите час: ");
                            h = Convert.ToInt32(Console.ReadLine());

                            for (int k = 0; Massiv[k] != null; k++)
                                if ((Massiv[k].endPunct == nameSt) && (h < Massiv[k].time.Hour)) { Console.WriteLine("\n{0}\n", Massiv[k].ToString()); flag = false; }
                            if (flag) { Console.WriteLine("Ничего не найдено!\n"); flag = true; }
                        }
                        break;

                    case 5:
                        {
                            /*  int countB;
                              int k = 0;
                             
                              Console.WriteLine("Введите конечную станцию: ");
                              nameSt = Convert.ToString(Console.ReadLine());
                              Console.WriteLine("Введите час: ");
                              h = Convert.ToInt32(Console.ReadLine());

                              for (int u=0; Massiv[u] != null; u++)
                                  if ((Massiv[u].endPunct == nameSt) && (h < Massiv[k].time.Hour)) { k=u; flag = false; }
                              if (flag) { Console.WriteLine("Ничего не найдено!\n"); flag = true; }


                              Console.WriteLine("Выберите вид биллета: \n1) Общее; \n2) Купэ; \n3) Плацкарт; \n4) Люкс. ");

                              n = Convert.ToInt32(Console.ReadLine());
                              if (n <= 0 || n > 4)
                              { Console.WriteLine("Введены неверные данные.");
                                break;
                              }

                              Console.WriteLine("Количество билетов выбранного типа: ");
                              countB = Convert.ToInt32(Console.ReadLine());*/
                            int q = 10, u = 0; bool fl3;
                            Console.WriteLine($"До:\nq: {q}, u: {u}, fl3: не присвоено значение");
                            poezd.Billet(ref q, u, out fl3);
                            Console.WriteLine($"После:\nq: {q}, u: {u}, fl3: {fl3}\n");

                        }
                        break;

                    case 6:
                        {
                            Menu.ShowDop();
                            fl = false;
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("Номер поезда: ");
                            number = Convert.ToInt32(Console.ReadLine());
                            for (int k = 0; Massiv[k] != null; k++)
                                if (Massiv[k].numberTrain == number) 
                                {
                                    Console.WriteLine($"Количество мест в поезде {number}:");
                                    number = Massiv[k].AllSeats();
                                    Console.WriteLine(number);
                                    
                                    break;
                                }
                        }
                        break;

                    case 11:
                        //  if (Train.ReferenceEquals(poezd, poezd1))
                        //    Console.WriteLine("Обьекты равны");
                        // else Console.WriteLine("Обьекты НЕ равны");
                        if (Massiv[1] != null)
                        {
                            if (Massiv[1].Equals(Massiv[0])) Console.WriteLine("Обьекты равны");
                            else Console.WriteLine("Обьекты НЕ равны");
                        }
                        else
                             if (poezd.Equals(Massiv[0])) Console.WriteLine("Обьекты равны");
                        else Console.WriteLine("Обьекты НЕ равны");

                        break;
                    case 22:
                        Train.GetInfo(); break;

                 //   default: Environment.Exit(1); break;

                }
            }
            if((Massiv[1]!=null)||(Massiv[0]!=null))
            Console.WriteLine("ID первых двух обьектов массива: 1) {0}, 2) {1}\n", Massiv[0].ID, Massiv[1].ID);
            
            if (poezd.GetType() == typeof(Train))
                Console.WriteLine("Type Train\n");

            var Train2 = new { NameStat = "Минск", hour = 12, minute = 12, numTr = 13};
            Console.WriteLine("Тип анонимного класса: {0}\n", Train2.GetType());
            Console.WriteLine("Содержимое анонимного класса: {0}", Train2);
        }
    }
}
