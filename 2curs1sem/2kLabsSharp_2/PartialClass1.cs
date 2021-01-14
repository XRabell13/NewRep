using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2KLabsSharp_2_New_
{
    partial class Program
    {
        partial class Menu
        {
            public static void ShowGeneral()
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(" 1. Ввести данные о поезде.");
                Console.WriteLine(" 2. Ввести расширенные данные о поезде.");
                Console.WriteLine(" 3. Получить данные о поезде, следующего до заданного пункта назначения.");
                Console.WriteLine(" 4. Получить данные о поезде, следующего до заданного пункта назначения и отправляющихся после заданного часа.");
                Console.WriteLine(" 5. Получить данные о всех поездах.");
                Console.WriteLine(" 6. Проверка out и ref.");

                Console.WriteLine(" 7. Дополнительно.");
                Console.WriteLine(" 0. Выход.");
                Console.WriteLine("------------------------------------------------------------------\n Ваш выбор: ");

            }
        }
    }
}
