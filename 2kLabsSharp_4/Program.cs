using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _2kLabsSharp_4
{

    /*
    Перечень классов: Автомобиль, Поезд, Транспортное средство, Экспресс, Двигатель,  Вагон. 
     List of classes: Car, Train, Transport, Express, Engine, Wagon.*/

    class Program
    {
        //то, что должно быть обязательно
        interface IMovable// его методы обязательно должны быть реализованы в классах
        {


            // методы
            void Move(int speed);                // движение


            // свойства
            string NameOrganization { get; set; }   // название транспорта
            string Marka { get; set; }  // марка транспорта
            string Number { get; set; } // номер транспорта
            int Speed { get; set; }


        }

        // то, что может быть, а может и не быть
        abstract class Transport//общий, базовый класс. Абстрактный. Все его методы МОГУТ БЫТЬ реализованы 
        {

            int MaxSpeed { get; set; }
            int MinSpeed { get; set; }

            int WayKm { get; set; }


            public int MoveInWay(int wayKm, int speed) => wayKm / speed;//реализован уже и можно просто использовать

            public abstract void MaxSpeeds(int speed);//нужно реализовать

        }
        //для абстрактныз классов нужно писать при перереализации метода ovveride
        class Express : Transport, IMovable
        {
            public string NameOrganization { get; set; }   // название транспорта
            public string Marka { get; set; }  // марка транспорта
            public string Number { get; set; } // номер транспорта

            int maxSpeed { get; set; }
            int minSpeed { get { return minSpeed; } set { minSpeed = 1; } }//1, чтобы при делении на 0 не было ошибки

            public override void MaxSpeeds(int speed)
            {
                if (speed > 0 && speed < 260) maxSpeed = speed; else maxSpeed = 260;
                Console.WriteLine($"MaxСкорость установлена для Express равная: {maxSpeed}km/h");
            }
            int wayKm { get { return wayKm; } set { if (value > 0) wayKm = value; else wayKm = 1; } }//сколько проехал км

            public int Speed { get; set; }

            public void Move(int speed)
            {
                Speed = speed;
                Console.WriteLine($"Скорость установлена для Express равная: {Speed}km/h");
            }


            /*идентично 
           {return wayKm/speed;}           
             */
            public sealed class Wagon//sealed - от него нелья наследовать

            {
                int CountSeats;

                int CountLux
                {
                    get { return CountLux; }

                    set
                    {
                        if (value < 20) CountLux = value;
                        else CountLux = 20;
                    }

                }
                int CountGeneral
                {
                    get { return CountGeneral; }

                    set
                    {
                        if (value < 100) CountGeneral = value;
                        else CountGeneral = 100;
                    }

                }
                int CountReversed
                {
                    get { return CountReversed; }

                    set
                    {
                        if (value < 100) CountReversed = value;
                        else CountReversed = 100;
                    }



                }

               /* public Wagon()
                {
                    countGeneral = 50;
                    countLux = 15;
                    countReversed = 45;
                    countSeats = countReversed + countLux + countGeneral;
                }*/
            }
            public sealed class Engine //двигатель
            {
                string Type { get; set; }
                string Power { get; set; }
                /*public Engine()
                {
                    Type = "Goods";
                    Power = "2000 л.с.";
                }*/

            }

            public Express(string n, string m, string num)
            {
                NameOrganization = n;  // название транспорта
                Marka = m;  // марка транспорта
                Number = num; // номер транспорта
                MaxSpeeds(260);
            }

            public override string ToString()
            {
                return "Класс: Express\nНаименование фирмы: " + NameOrganization + "\nМарка:" + Marka + "\nНомер:" + Number +"\nMaxSpeed:"+ maxSpeed + "\nМетоды: Move, MaxSpeed\nПереопределения:  toString()";
            }
        }

        class Train : Transport, IMovable
        {
            public string NameOrganization { get; set; }   // название транспорта
            public string Marka { get; set; }  // марка транспорта
            public string Number { get; set; } // номер транспорта

            int MaxSpeed { get; set; }
            int MinSpeed { get { return MinSpeed; } set { MinSpeed = 1; } }//1, чтобы при делении на 0 не было ошибки

            int WayKm { get { return WayKm; } set { if (value > 0) WayKm = value; else WayKm = 1; } }//сколько проехал км

            public int Speed { get; set; }

            public void Move(int speed)
            {
                Speed = speed;
                Console.WriteLine($"Скорость установлена для Train равная: {Speed}km/h");
            }

            public override void MaxSpeeds(int speed)//переопределение виртуального метода
            {
                if (speed > 0 && speed < 240) MaxSpeed = speed; else MaxSpeed = 240;
                Console.WriteLine($"MaxСкорость установлена для Train равная: {MaxSpeed}km/h");
            }

            public Train(string n, string m, string num)
            {
                NameOrganization = n;  // название транспорта
                Marka = m;  // марка транспорта
                Number = num; // номер транспорта
                MaxSpeeds(240);
            }
            public sealed class Wagon
            {
               

                int countLux
                {
                    get { return countLux; }

                    set
                    {
                        if (value < 20) countLux = value;
                        else countLux = 20;
                    }

                }
                int countGeneral
                {
                    get { return countGeneral; }

                    set
                    {
                        if (value < 100) countGeneral = value;
                        else countGeneral = 100;
                    }

                }
               int countReversed
                {
                    get { return countReversed; }

                    set
                    {
                        if (value < 100) countReversed = value;
                        else countReversed = 100;
                    }

                }

              /*  public Wagon()
                {
                    countGeneral = 50;
                    countLux = 15;
                    countReversed = 45;
                 //   countSeats = countReversed + countLux + countGeneral;
                }*/
            }
            public sealed class Engine //двигатель
            {
                string Type { get; set; }
                string Power { get; set; }
                public Engine()
                {
                    Type = "Goods";
                    Power = "1000 л.с.";
                }

            }

            public override string ToString()
            {
                return "Класс: Train\nНаименование фирмы: " + NameOrganization + "\nМарка:" + Marka + "\nНомер:" + Number + "\nMaxSpeed:" +
                     MaxSpeed + "\nМетоды: Move, MaxSpeed\nПереопределения:  toString()";
            }
        }

        class Car : Transport, IMovable
        {

            public string NameOrganization { get; set; }   // название транспорта
            public string Marka { get; set; }  // марка транспорта
            public string Number { get; set; } // номер транспорта

            public readonly string ID;
            int maxSpeed { get; set; }
            int minSpeed { get { return minSpeed; } set { minSpeed = 1; } }//1, чтобы при делении на 0 не было ошибки

            int wayKm { get { return wayKm; } set { if (value > 0) wayKm = value; else wayKm = 1; } }//сколько проехал км

            public int Speed { get; set; }

            public void Move(int speed)
            {
                Speed = speed;
                Console.WriteLine($"Скорость установлена для Car равная: {Speed}km/h");
            }

            public override void MaxSpeeds(int speed)
            {
                if (speed > 0 && speed < 190) maxSpeed = speed;
                
                Console.WriteLine($"MaxСкорость установлена для Car равная: {maxSpeed}km/h");
            }

            public Car(string n, string m, string num)
            {
                NameOrganization = n;  // название транспорта
                Marka = m;  // марка транспорта
                Number = num; // номер транспорта
                MaxSpeeds(150);
                ID = Convert.ToString(Number.GetHashCode() + NameOrganization.GetHashCode());
            }


            public sealed class Engine //двигатель
            {
                string Type { get; set; }
                string Power { get; set; }

                public Engine()
                {
                    Type = "Goods";
                    Power = "240 л.с.";
                }

            }



            //переопределение всех методов унаследованных от object
            public override int GetHashCode()
            {
                // 269 или 47 простые
                int hash = 269;
                hash = string.IsNullOrEmpty(Number) ? 0 : Number.GetHashCode();
                hash = (hash * 47) + NameOrganization.GetHashCode();
                return hash;
            }

            public virtual Boolean Equals(Car obj)
            {
                // Сравниваемый объект не может быть равным null
                if (obj == null) return false;
                // Объекты разных типов не могут быть равны
                //  if (this.GetType() != obj.GetType()) return false;
                if (this.ID != obj.ID) return false;//сравниваем по ID, ибо если ID разные, то и поля в чем-то различаются

                return true;
            }

            public new Type GetType()
            {
                return typeof(Car);
            }



            public override string ToString()
            {
                return "Класс: Car\nНаименование фирмы: " + NameOrganization + "\nМарка:" + Marka + "\nНомер:" + Number + "\nID:" + ID + "\nMaxSpeed:" +
                     maxSpeed  + "\nМетоды: Move, MaxSpeed\nПереопределения: GetType(),GetHashCode(), Finallize()" +
                     "toString(), Eguals()";
            }

            //сработает при закрытии программы
            ~Car()//неявное переопределение метода finalize()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Объект class Car №{0} уничтожен", ID);
                Console.Beep();//звук в конце будет
            }
        }

        ///// чисто демонстрационное ///////////////////////////////////////////////////////////////////////////
        class DemonStrationVirtual
        {

            public virtual void Show() { Console.WriteLine("Используется метод из DemonStrationVirtual"); }

        }
        class DemonStrarion : DemonStrationVirtual
        {
            public override void Show() { Console.WriteLine("Используется переопределенный метод из DemonStration"); }

        }
        //-----------------------------------------------------------------------------------------------------
        interface ISay { public void DoSay(); }

        abstract class BaseSay { public abstract void DoSay(); }

        class Demonstrations : BaseSay, ISay
        {
            const string name = "Methode";
            public override void DoSay() { Console.WriteLine($"\n{name}: Привет из определенного абстрактного метода!\n"); }
            void ISay.DoSay() { Console.WriteLine($"\n{name}: Привет из интерфейсного метода!\n"); }


        }
        //   interface ICloneable { bool DoClone(); }

        // abstract class BaseClone { public abstract bool DoClone(); }
        //   class UserClass : BaseClone, ICloneable
        //  {       }

        class Printer
        {

            public void IAmPrinting(Transport someobj)
            {
                Console.WriteLine(someobj.ToString());

            }

        }


        static void Main(string[] args)
        {

            Car Avto1 = new Car("Avtos", "Bently", "499212");
            Car.Engine EngineAvto1 = new Car.Engine();

            Train Train1 = new Train("TrainsOrg","BelMark", "12");
            Train.Wagon WagonTrain2 = new Train.Wagon();
            Train.Engine EngineTrain2 = new Train.Engine();

            Express Express1 = new Express("SpeedEXP", "JN", "13-B");

            Transport[] mas = new Transport[6];
            Transport Train2 = new Train("OrgTR", "RUS", "23");
            Transport Avto2 = new Car("Cars", "Zafira", "327878");
            Transport Express2 = new Express("ExpressSpeed", "JN", "123-A");

            Printer Print1 = new Printer();

            Demonstrations d1 = new Demonstrations();
            DemonStrarion d2 = new DemonStrarion();

            d1.DoSay();
            ((ISay)d1).DoSay();

            d2.Show();

            Console.WriteLine(d1.GetType());
            Console.WriteLine(d2.GetType());

            Console.WriteLine($"\n\nПринадлежность d1 к классу Demonstrations: {d1 is Demonstrations}");
            Console.WriteLine($"Принадлежность d2 к классу Demonstrations: {d2 is Demonstrations}");
            Console.WriteLine($"Принадлежность d1 к классу DemonSrarions: {d1 is DemonStrarion}");
            Console.WriteLine($"Принадлежность d2 к классу DemoSrarions: {d2 is DemonStrarion}\n\n");

            Console.WriteLine($"Принадлежность (ISay)d1 к классу Demonstrations: {(ISay)d1 is Demonstrations}");
            Console.WriteLine($"Принадлежность (d1 as ISay) к классу Demonstrations: {(d1 as ISay) is Demonstrations}");

            Console.WriteLine($"Принадлежность (ISay)d1 к интерфейсу ISay:  {(ISay)d1 is ISay}");
            Console.WriteLine($"Принадлежность (d1 as ISay) к интерфейсу ISay: {(d1 as ISay) is ISay}\n\n");

            Console.WriteLine($"d1.GetType(): {d1.GetType()}");
            Console.WriteLine($"((ISay)d1).GetType(): {((ISay)d1).GetType()}");
            Console.WriteLine($"(d1 as ISay).GetType(): {(d1 as ISay).GetType()}\n\n");

            mas[0] = Avto1; mas[1] = Train1; mas[2] = Train2; mas[3] = Avto2; mas[4] = Express2; mas[5] = Express1;


            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine("\n\n");
                Print1.IAmPrinting(mas[i]);
            }
            Console.WriteLine("\n\n");

        }
    }
}
