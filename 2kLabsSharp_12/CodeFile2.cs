using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    static class Reflector
    {
        //============================================ПЕРВЫЙ ПУНКТ ЗАДАНИЯ============================================

        public static void Info(Type clazz, bool attr)
        {
            if (attr) InfoInFile(clazz);
            else InfoInConsole(clazz);
        }

        static void InfoInFile(Type clazz)
        {
            NameBield(clazz);
            ExistPublicConstructor(clazz);
            GetPublicMethods(clazz);
            GetFieldAndProperties(clazz);
            GetInterfaces(clazz);
        }
       
        static void InfoInConsole(Type clazz)
        {
            InfoInFile(clazz);
            Console.WriteLine(Read("test_1.txt"));

        }
        //============================================МЕТОДЫ ДЛЯ РАБОТЫ С КЛАССАМИ============================================

        public static void NameBield(Type clazz)//полное имя сборки
        {
            Console.WriteLine("\n\t\t\t\tИспользуется метод NameBield из статического класса Reflector");
            Save("test_1.txt", clazz.Assembly.FullName.ToString(), $"Имя сборки класса{clazz}:");

        }
      
        public static void ExistPublicConstructor(Type clazz)//есть ли публичные конструкторы
        {
            ConstructorInfo[] ci = clazz.GetConstructors();
            Console.WriteLine("\n\t\t\t\tИспользуется метод ExistPublicConstructor из статического класса Reflector");
            foreach (var con in ci)
            {
                if (con.Name == null) { Save("test_1.txt", $"\nУ класса {clazz} нет публичного/ых конструктора/ов.\n"); return; }

                else { Save("test_1.txt", $"\nУ класса {clazz} есть публичный конструктор/конструкторы.\n"); return; }
            }


        }

        public static void GetFieldAndProperties(Type clazz)//получение полей и свойств
        {
            Save("test_1.txt", $"\n\nСвойства класса {clazz}:");

            foreach (var Met in GetProperties_IE(clazz))
            {
                Save("test_1.txt", $"\n{Met}");
            }

            Save("test_1.txt", $"\n\nПоля класса {clazz}:");

            foreach (var Met in GetField_IE(clazz))
            {
                Save("test_1.txt", $"\n{Met}");
            }
            Console.WriteLine("\n\t\t\t\tИспользуется метод GetPublicMethods из статического класса Reflector");

        }
       
        static IEnumerable<string> GetField_IE(Type clazz) =>
            clazz.GetFields(BindingFlags.Instance
                                | BindingFlags.Static
                                | BindingFlags.Public
                                | BindingFlags.NonPublic).Select(p => p.Name);
        
        static IEnumerable<string> GetProperties_IE(Type clazz) => clazz.GetProperties().Select(p => p.Name);

        public static void GetPublicMethods(Type clazz)//получение общедоступных методов
        {
            Save("test_1.txt", $"\nПубличные методы класса {clazz}:");

            foreach (var Met in GetPublicMethods_IE(clazz))
            {
                Save("test_1.txt", $"\n{Met}");
            }
            Console.WriteLine("\n\t\t\t\tИспользуется метод GetPublicMethods из статического класса Reflector");

        }

        static IEnumerable<string> GetPublicMethods_IE(Type clazz) => 
            clazz.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Select(p => p.Name).Distinct();
        //используем Distinct, чтобы не было повторяющихся имен методов из-за многочисленных перегрузок
      
        public static void GetInterfaces(Type clazz)//получение интерфейсов, которые реализует класс
        {
            Save("test_1.txt", $"\n\nИспользованные интерфейсы в классе {clazz}:\n");

            foreach (var Met in GetInterfaces_IE(clazz))
            {
                    Save("test_1.txt", $"\n{Met}\n");
            }
            Console.WriteLine("\n\t\t\t\tИспользуется метод GetInterfaces из статического класса Reflector");
        }
       
        static IEnumerable<string> GetInterfaces_IE(Type clazz) =>
          clazz.GetInterfaces().Select(p => p.Name);

        public static void GetMethodsWithParamType(Type clazz, Type Param)//получаем имя метода, который принимает параметры указанного типа
        {
            Console.WriteLine("\n\t\t\t\tИспользуется метод GetMethodsWithParamType из статического класса Reflector");

            MethodInfo[] Met = clazz.GetMethods();
            
            Save("test_1.txt", $"\nМетоды из класса {clazz}, содержащие параметры типа {Param}: \n");
           
            foreach (var m in Met)
            {
                ParameterInfo[] pars = m.GetParameters();

                foreach (var p in pars)
                    if (p.ParameterType == Param)
                        Save("test_1.txt", $"\n{m.Name}");
            }
        }
    //============================================МЕТОДЫ Invoke============================================


    public static object[] GeneratorParam(string NameClass, string NameMet)//генератор значений для каждого типа(почти)
    {
        Type magicType = Type.GetType(NameClass);
        Console.WriteLine(magicType.Name);

        MethodInfo[] Met = magicType.GetMethods();

        int index = 0;
        string[] nameT = new string[16];

        foreach (var m in Met)
        {
            ParameterInfo[] pars = m.GetParameters();//получаем массив параметров метода
            if (m.Name == NameMet)//если нашли метод, который нам нужен, то из него вытаскиваем параметры
            {

                Console.WriteLine($"\nМетод: {m.Name}\nПараметры: ");
                foreach (var p in pars)
                {
                    nameT[index] = Convert.ToString(p.ParameterType);
                    Console.WriteLine($"{p.Name}, тип параметра: {nameT[index]}\n");
                    index++;
                }
            }
        }
        
        Console.WriteLine("Colvo param: {0}",index);
        object[] param = new object[index];

        for (int i = 0; nameT[i] != null; i++)
        {
            switch (nameT[i])
            {
                case "System.Int32": param[i] = 100; break;
                case "System.Int16": param[i] = -1; break;
                case "System.Double": param[i] = 23.23; break;
                case "System.Float": param[i] = 23; break;
                case "System.String": param[i] = "Hello"; break;
               // case "System.Object": param[i] = 2; break;
                default: break;
            }
        }
            return param;
    }

        public static void Invoke(object Ob, string NameMet, object[] Pars)//2 вариант Invoke
        {
        MethodInfo obMethod = Ob.GetType().GetMethod(NameMet);
        object magicValue = obMethod.Invoke(Ob, Pars);
        Console.WriteLine("MagicClass.ItsMagic() вернет: {0}", magicValue);
        }

        public static void Invoke(string NameClass, string NameMet)//1 вариант Invoke(чтение данных из файла)
    {
        int sp;
        //создаем экземпляр класса, методы которого и будем использовать на нем же
            Type magicType = Type.GetType(NameClass);
            Console.WriteLine(magicType.Name);
            
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[] { });

        //Вызываем метод из этого класса
        string a = Read("param1.txt");
       
        string[] wordsParam = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        object[] Params = new object[wordsParam.Length];

        for (int i = 0; i < wordsParam.Length; i++)
        {
            Console.WriteLine(wordsParam[i]);
            if (int.TryParse(wordsParam[i], out sp))
            {
                Console.WriteLine($"Получаем {sp.GetType()}");
                Params[i] = sp;
            }
            else { Console.WriteLine($"Получаем {wordsParam[i].GetType()}"); Params[i] = wordsParam[i]; }
        }
        //Вызываем метод из этого класса
        MethodInfo magicMethod = magicType.GetMethod(NameMet);
            object magicValue = magicMethod.Invoke(magicClassObject, Params);

            Console.WriteLine("MagicClass.ItsMagic() вернет: {0}", magicValue);

        }
        //============================================ВТОРОЙ ПУНКТ ЗАДАНИЯ============================================

        public static Object Create(Type clazz)
        {
         Console.WriteLine("\n\t\t\t\tИспользуется метод Create из статического класса Reflector");
         return Activator.CreateInstance(clazz);
        }

        //============================================МЕТОДЫ РАБОТЫ С ФАЙЛАМИ============================================
        public static string Read(string patch)
        {
            string str = null;
            string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_12\";
            try
            {
                writePath += patch;
                using (StreamReader sr = new StreamReader(writePath, Encoding.GetEncoding(1251)))
                {
                    str = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return str;
        }

        public static void Save(string patch, string inf)
        {
            string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_12\";
            try
            {
                writePath += patch;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
                {        
                    sw.Write(inf);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Save(string patch, string inf, string comment)
        {
            string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_12\";
            try
            {
                writePath += patch;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
                {
                    sw.Write($"\n{comment}\n");
                    sw.Write($"\n{inf}\n");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
      

    
    }