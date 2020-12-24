using System;

namespace _2kLabsSharp_8
{
    //Первая часть задания из лабораторной работы(11 вариант)
    partial class Program
    {
        public delegate void SomeDelegat();//свой делегат, используется в User для создания события
        public class User
        {
            public event SomeDelegat Upgrade;
            public event EventHandler Work;
          //  static int count = 0;//кол-во объектов этого класса
            public void CommandUpgrade()
            {
                Console.WriteLine("Вышла новая версия приложения! Обновить?(y/n)");
                string str = Console.ReadLine();
                if (str == "y" || str =="Y") Upgrade?.Invoke();
                else Console.WriteLine("\t\t\t\tОбновление отложено.\n");
            }
            public void CommandWork()
            {
                Console.WriteLine("\t\t\t\tПриложениe запущено.\n");
                // if (Work != null) Work(this, null); //равносильно нижнему
                Work?.Invoke(this, null);
            }
            /*static User()
            {
                count++;
            }*/
        }
        //--------------------------------------Классы-наблюдатели-------------------------------------------------
        public class PO_1
        {
            int versionNum;//номер версии до обновления
            string nameApp;
            static string namePO = "PO_1 v";//неизменное начало
            string version;//строка в себе имеющая неизвенное начало и номер новой версии
            DateTime AwokeTime = new DateTime();

            string times = null;
            //--------------------------------------Обработчики событий Upgrade-------------------------------------------------
            public void OnUpgrade()
            {
                Console.WriteLine($"\t\t\t\tМетод OnUpgrade класса PO_1 {nameApp}\n");
                versionNum++;
                version = namePO + versionNum;
                Console.WriteLine($"Приложение {nameApp} было обновлено до версии {version}\n");

            }

            public void OnShowUpgrade() =>
                Console.WriteLine($"\t\t\t\tМетод OnShowUpgrade класса PO_1\nПоследняя версия {nameApp}: {version}\n");

            //--------------------------------------Обработчики событий Work-------------------------------------------------

            public void OnWork(object sender, EventArgs e)
            {
                AwokeTime = DateTime.Now;
                times += Convert.ToString(AwokeTime) + "\n";
            }

            public void OnShowWork(object sender, EventArgs e)
            {
                if (times != null)
                    Console.WriteLine($"\t\t\t\tМетод OnShowWork класса PO_1\nПриложение {nameApp} было запущено: \n{times}");
                else Console.WriteLine($"Приложение запущено впервые {DateTime.Now}");
            }
            

        //--------------------------------------Конструкторы-------------------------------------------------
            public PO_1(int beginVersion, string nameApp)
            {
                versionNum = beginVersion;
                version = namePO + versionNum;
                this.nameApp = nameApp;
            }
            public PO_1()
            {
                versionNum = 0;
                version = namePO + versionNum;
                nameApp = "AppConstName";
            }

        }
    }
}
