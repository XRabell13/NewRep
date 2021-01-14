using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
    partial class Program
    {
       public static void Main()
        {
            //============================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ============================================
            Console.WriteLine("\n ============================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ============================================\n");
        Console.WriteLine("\n\t\t\t\tИспользование первого Invoke\n");
        Reflector.Invoke("MagicClass", "ItsMagic");

        MagicClass Magic = new MagicClass();
       
        object[] Pars = Reflector.GeneratorParam("MagicClass", "ItsMagic");
        Console.WriteLine("\n\t\t\t\tИспользование второго Invoke\n");

        Reflector.Invoke(Magic, "ItsMagic", Pars);

        Console.WriteLine("\n\t\t\t\tВывод информации о своих типах и типах .Net\n");
        Reflector.Info(typeof(Train), false);
        Reflector.Info(typeof(GeomFigureEnumerator), false);
        Reflector.Info(typeof(GeomFigure), false);
        Reflector.Info(typeof(MagicClass), false);

        Reflector.Info(typeof(int), false);
        Reflector.Info(typeof(string), false);
        Reflector.Info(typeof(object), false);

        //============================================ВТОРОЙ ПУНКТ ЗАДАНИЯ============================================
        Console.WriteLine("\n ============================================ВТОРОЙ ПУНКТ ЗАДАНИЯ============================================\n");
           // Reflector.GetPublicMethods(typeof(Train));
                var ob1 = Reflector.Create(typeof(Train));
                var ob2 = Reflector.Create(typeof(GeomFigure));
                Console.WriteLine($"\n{ob1}");
                Console.WriteLine($"\n{ob2}");
        }
    }

