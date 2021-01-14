using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2kLabsSharp_8
{
  partial class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------Первая часть лабораторной---------------------------------------
            Console.WriteLine("\n\t\t====================== ПЕРВАЯ ЧАСТЬ ЛАБОРАТОРНОЙ РАБОТЫ ====================== \n");

            User XR_User = new User();
            PO_1 App1 = new PO_1(4, "Apl");
            PO_1 App2 = new PO_1(8, "Game");


            //Обработчики событий на собственный делегат SomeDelegat
            XR_User.Upgrade += new SomeDelegat(() => Console.WriteLine("Используется анонимный делегат с помощью лямбда-выражения.\n\n"));
            XR_User.Upgrade += new SomeDelegat(App1.OnShowUpgrade);
            XR_User.Upgrade += new SomeDelegat(App1.OnUpgrade);
            XR_User.Upgrade += new SomeDelegat(App1.OnShowUpgrade);
            XR_User.Upgrade += new SomeDelegat(() => Console.WriteLine("Использование собственного события закончено.\n\n"));
            XR_User.Upgrade += new SomeDelegat(() =>
            {
                Console.WriteLine("Использование блочного лямбда-выражения!\n\n");
                Console.WriteLine("Теперь точно все с собственным событием Upgrade.\n\n");

            });

            XR_User.CommandUpgrade();//запускаем событие обновления

            //Обработчики событий на стандартный делегат EventHandler
            XR_User.Work += App1.OnShowWork;
            XR_User.Work += App1.OnWork;
            XR_User.Work += App1.OnShowWork;
            XR_User.Work += App2.OnShowWork;
            XR_User.Work += App2.OnWork;
            XR_User.Work += App2.OnShowWork;

            XR_User.CommandWork();//запускаем событие работы ПО
            XR_User.CommandWork();

            //------------------------------------------Вторая часть лабораторной---------------------------------------
            Console.WriteLine("\n\n\t\t====================== ВТОРАЯ ЧАСТЬ ЛАБОРАТОРНОЙ РАБОТЫ ====================== \n");
            string stroka = "   Hello,   my  name's    Tanya!       Seat    down,  please.    ";
            UserString DelegatStr;
            Action<string> DelAct;
            DelAct = (string a) => { Console.WriteLine(a); };
            Func<string, int> DelFunc;
            DelFunc = s => s.Length;

            DelAct($"Изначальное количество символов в строке: {DelFunc(stroka)}\n");//Начальное количество символов

            DelegatStr = UserOperation.DeleteOtherSpace;
           
            DelegatStr += UserOperation.DeleteBESpace;
        
            DelegatStr += UserOperation.Ins;
           
            DelegatStr += UserOperation.Rem;

            DelegatStr += UserOperation.ToUp;
           
            DelegatStr(ref stroka, DelAct, DelFunc);//вызов всех методов делегата
       
        }
    }
}
