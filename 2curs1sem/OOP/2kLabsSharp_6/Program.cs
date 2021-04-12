using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Diagnostics;

namespace _2kLabsSharp_6
{
    public partial class Program
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

            int Consumption { get; set; }// колво литров на 100 км

            decimal Price { get; set; } // в долларах

        }
        // то, что может быть, а может и не быть

        public class Transport//общий, базовый класс. Абстрактный. Все его методы МОГУТ БЫТЬ реализованы 
        {

            int MaxSpeed { get; set; }
            int MinSpeed { get; set; }
            decimal Price;
            int Consumption;
            int WayKm { get; set; }
            public virtual decimal GetPrice() => Price;
            public virtual int GetConsumption() => Consumption;

            public virtual decimal GetMaxSpeed() => MaxSpeed;


            public int MoveInWay(int wayKm, int speed) => wayKm / speed;//реализован уже и можно просто использовать

            public virtual void MaxSpeeds(int speed)//нужно реализовать
            {
                if (speed > 0 && speed < 240) MaxSpeed = speed; else MaxSpeed = 240;
                Console.WriteLine($"MaxСкорость установлена для ?? равная: {MaxSpeed}km/h");
            }

        }
        //для абстрактныз классов нужно писать при перереализации метода ovveride
        class Express : Transport, IMovable
        {
            public string NameOrganization { get; set; }   // название транспорта
            public string Marka { get; set; }  // марка транспорта
            public string Number { get; set; } // номер транспорта

            public int Consumption { get; set; }

            public decimal Price { get; set; }
            int maxSpeed { get; set; }
            int minSpeed { get { return minSpeed; } set { minSpeed = 1; } }//1, чтобы при делении на 0 не было ошибки

            public override decimal GetPrice() => Price;
            public override int GetConsumption() => Consumption;
            public override decimal GetMaxSpeed() => maxSpeed;

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
                Consumption = 300;
                Price = 60000;
            }

            public override string ToString()
            {
                return "Класс: Express\nНаименование фирмы: " + NameOrganization + "\nМарка:" + Marka + "\nНомер:" + Number + "\nMaxSpeed:" + maxSpeed +
                    "\nРасход топлива на 100км: " + Consumption + "л\nЦена: " + Price + "$" + "\nМетоды: Move, MaxSpeed\nПереопределения:  toString()";
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
            public int Consumption { get; set; }

            public decimal Price { get; set; }
            public int Speed { get; set; }
            public override decimal GetPrice() => Price;
            public override int GetConsumption() => Consumption;
            public override decimal GetMaxSpeed() => MaxSpeed;
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
                Consumption = 100;
                Price = 30000;
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
                 MaxSpeed + "\nРасход топлива на 100км: " + Consumption + "л\nЦена: " + Price + "$" + "\nМетоды: Move, MaxSpeed\nПереопределения:  toString()";
            }
        }

        class Car : Transport, IMovable
        {
            enum Colors
            {
                Red, Orange, Yellow, Green, Blue, Purple
            }
            Colors Color;
            public string NameOrganization { get; set; }   // название транспорта
            public string Marka { get; set; }  // марка транспорта
            public string Number { get; set; } // номер транспорта
            public override decimal GetPrice() => Price;
            public override int GetConsumption() => Consumption;
            public override decimal GetMaxSpeed() => MaxSpeed;

            public readonly string ID;
            public int Consumption { get; set; }
            public decimal Price { get; set; }
            int MaxSpeed { get; set; }
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
                //if (speed > 0 && speed < 190)
                MaxSpeed = speed;
                Console.WriteLine($"MaxСкорость установлена для Car равная: {MaxSpeed}km/h");
            }

            public Car(string n, string m, string num)
            {
                NameOrganization = n;  // название транспорта
                Marka = m;  // марка транспорта
                Number = num; // номер транспорта
                MaxSpeeds(150);
                ID = Convert.ToString(Number.GetHashCode() + NameOrganization.GetHashCode());
                Color = Colors.Yellow;
                Consumption = 12;
                Price = 8000;
            }

            public Car(string n, string m, string num, int MxSpeed, int Consumpt, int Price)
            {
                NameOrganization = n;  // название транспорта
                Marka = m;  // марка транспорта
                Number = num; // номер транспорта

                MaxSpeeds(MxSpeed);
                ID = Convert.ToString(Number.GetHashCode() + NameOrganization.GetHashCode());
                Color = Colors.Yellow;
                Consumption = Consumpt;
                this.Price = Price;
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
                     MaxSpeed + "\nЦвет:" + Colors.Yellow + "\nРасход  топлива на 100км: " + Consumption + "л\nЦена: " + Price + "$" +
                     "\nМетоды: Move, MaxSpeed\nПереопределения: GetType(),GetHashCode(), Finallize()" +
                     "toString(), Eguals()";
            }


        }

        class Printer
        {

            public void IAmPrinting(Transport someobj)
            {
                Console.WriteLine(someobj.ToString());

            }

        }

        class Menu
        {
            public static void Show()
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(" 1. Создать объект Car.");
                Console.WriteLine(" 2. Создать объект Train.");
                Console.WriteLine(" 3. Создать объект  Express.");
                Console.WriteLine(" 4. Вывести весь список транспортных средств.");
                Console.WriteLine(" 5. Удалить транспорт из списка.");
                Console.WriteLine(" 6. Вывести сумму цен всех транспортных средств.");
                Console.WriteLine(" 7. Сортировать автомобили по расходу топлива.");
                Console.WriteLine(" 8. Вывести транспортные средства по диапазону скорости.");

                Console.WriteLine(" 0. Выход.");
                Console.WriteLine("------------------------------------------------------------------\n Ваш выбор: ");

            }
        }

        static void Main(string[] args)
        {
            bool flag = true;
            int n, sp1, sp2;
            string org, mark, avtoNum, speedStr;
            int speed = 0, litr = 0, price = 0;
            Controller C1 = new Controller();

            Car Avto1 = new Car("Avtos", "Bently", "499212");
            Transport Avto2 = new Car("Cars", "Zafira", "327878");
            Car Avto3 = new Car("Avtos", "A1", "13451", 150, 14, 14999);
            Car Avto4 = new Car("Avtos", "A2", "23543", 170, 10, 34999);
            Car.Engine EngineAvto1 = new Car.Engine();

            Train Train1 = new Train("TrainsOrg", "BelMark", "12");
            Train.Wagon WagonTrain2 = new Train.Wagon();
            Train.Engine EngineTrain2 = new Train.Engine();

            Express Express1 = new Express("SpeedEXP", "JN", "13-B");

            Transport Train2 = new Train("OrgTR", "RUS", "23");

            Transport Express2 = new Express("ExpressSpeed", "JN", "123-A");

            Console.WriteLine("\n\n");
            //  Проверка на то, добавляется ли в контейнер объект нужного типа

            C1.Add(Avto1); C1.Add(Avto2); C1.Add(Train1); C1.Add(Train2); C1.Add(Express1); C1.Add(Express2);
            C1.Add(Avto3); C1.Add(Avto4);
            //добавление элементов в массив

            C1.Show();//показать все записи

            Console.WriteLine($"Summ: {C1.Summ()}");// показать сумму
            C1.SortAvto();//вывести список авто сортированных по количеству употребляемого топлива
            C1.DiapazonSpeed(160, 280);// вывести транспортные средства в диапазоне от 160 до 280 км в ч
            C1.Show();
            //  C1.Delete(1); C1.Delete(2); C1.Delete(3);//удалить обьекты из массива
            // C1.Show();


            Console.WriteLine("Создаем объект класса Car: ");
            Console.WriteLine("Organization: ");
            org = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Marka: ");
            mark = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Number Avto: ");
            avtoNum = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Speed: ");

            try
            {
                speed = Convert.ToInt32(Console.ReadLine());

                if (speed <= 0 || speed > 190)
                {
                    MaxSpeedInvlidValueException exCar = new MaxSpeedInvlidValueException();

                    throw exCar;
                }

            }
            catch (MaxSpeedInvlidValueException exCar)
            {
                Console.WriteLine("Блок catch (MaxSpeedInvlidValueException exCar)");
                exCar.MyExeption(speed);
                while (flag)
                {
                    Console.WriteLine("Введите верное значение Speed: ");
                    speed = Convert.ToInt32(Console.ReadLine());
                    if (speed > 0 & speed < 190) flag = false;
                }
            }
            catch (FormatException form)
            {

                Console.Write(form.Message + "\n\n");
                Console.Write(form.TargetSite + "\n\n");
                Console.Write(form.StackTrace + "\n\n");
                while (flag)
                {
                    Console.WriteLine("Введите числое значение скорости: ");
                    speedStr = Console.ReadLine();

                    if (int.TryParse(speedStr, out speed))
                    {
                        Console.WriteLine("Преобразование прошло успешно");
                        flag = false;
                    }
                    else
                        Console.WriteLine("Преобразование завершилось неудачно");
                }
            } 
            catch (Exception a)
            {
                Debug.Assert(a == null, "Непредвиденное исключение!"); 
             
                Console.Write(a.Message + "\n\n");
                Console.Write(a.TargetSite + "\n\n");
                Console.Write(a.StackTrace + "\n\n");
            }
            finally
            {
                flag = true;
                Console.WriteLine("Первый Блок finally");
            }

            Console.WriteLine("Consum(litr): ");
            litr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Price: ");
            price = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (price <= 0)
                {
                    PriceInvlidValueException exCar = new PriceInvlidValueException();
                    throw exCar;
                }

            }
            catch (PriceInvlidValueException exCar)
            {
                Console.WriteLine("Блок  catch (PriceInvlidValueException exCar)");
                exCar.MyExeption();
                while (flag)
                {
                   
                    Console.WriteLine("Введите верное значение Price: ");
                    price = Convert.ToInt32(Console.ReadLine());
                    if (price > 0) flag = false;
                }
            }
            catch (Exception a)
            {
                Debug.Assert(a == null, "Непредвиденное исключение!");

                Console.Write(a.Message + "\n\n");
                Console.Write(a.TargetSite + "\n\n");
                Console.Write(a.StackTrace + "\n\n");

            }
            finally
            {
                flag = true;
                Console.WriteLine("Второй Блок finally");
            }
           
            Car Avto5 = new Car(org, mark, avtoNum, speed, litr, price);
            C1.Add(Avto5);
            Console.WriteLine("Введите значения диапазона: ");
                  sp1 = Convert.ToInt32(Console.ReadLine());
                  sp2 = Convert.ToInt32(Console.ReadLine());
            try
                  {
                      if (sp1 >= sp2 || sp1 < 0 || sp2 < 0)
                      {
                          DiapasonInvalidException exDia = new DiapasonInvalidException();
                          throw exDia;
                      }

                  }
                  catch (DiapasonInvalidException exDia)
                  {
                      Console.WriteLine("Блок   catch (DiapasonInvalidException exDia)");
                      exDia.FromOrToInvalidValue();
                      while (flag)
                      {
                          Console.WriteLine($"Введите верные значения: ");
                          sp1 = Convert.ToInt32(Console.ReadLine());
                          sp2 = Convert.ToInt32(Console.ReadLine());
                          if (sp1 < sp2 & sp2 > 0 & sp1 > 0) flag = false;
                      }
                  }
                  catch (Exception a)
                  {
                  Debug.Assert(a == null, "Непредвиденное исключение!");
                Console.Write(a.Message + "\n\n");
                Console.Write(a.TargetSite + "\n\n");
                Console.Write(a.StackTrace + "\n\n");
            }
                  finally
                  {
                      flag = true;
                      Console.WriteLine("Третий Блок finally");
                  }
            C1.DiapazonSpeed(sp1, sp2);
           
        }
    }
 }
