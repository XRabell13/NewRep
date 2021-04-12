using System;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _2kLabsSharp_8
{
    //Вторая часть задания из лабораторной работы(11 вариант)
    /*Создайте пять методов пользовательской обработки строки
     * (например, 
     * удаление знаков препинания,
     * добавление символов,
     * замена на заглавные, 
     * удаление лишних пробелов и т.п.).
     * Используя стандартные типы делегатов (Action, Func) 
     * организуйте алгоритм последовательной обработки строки написанными вами методами.
     * Далее приведен перечень заданий. 
     */
    partial class Program
    {
        public delegate void UserString(ref string str, Action<string> cons, Func<string, int> f);
        public class UserOperation
        {
            //удаление лишних пробелов
            public static void DeleteOtherSpace(ref string a, Action<string> cons, Func<string, int> f)
            {
                cons("\t\t\t\tМетод DeleteOrherSpace\nУдалили повторяющиеся пробелы");
                while (a.Contains("  ")) 
                {
                    a = a.Replace("  ", " "); 
                }
                cons($"Строка: {a}\nКол-во знаков в строке:{f(a)}");

            }
            //удаление пробелов в начале и конце строки
            public static void DeleteBESpace(ref string a, Action<string> cons, Func<string, int> f)
            {
              cons("\t\t\t\tМетод DeleteBESpace\nУдалили пробелы в начале строки и в ее конце");
                a = a.Trim();
                cons($"Строка: {a}\nКол-во знаков в строке:{f(a)}");

            }
            //вставка в начало строки другой строки
            public static void Ins(ref string a, Action<string> cons, Func<string, int> f)
            {
               cons("\t\t\t\tМетод Ins\nВставили в начало строки другую строку.");

                a = a.Insert(0, "She say: ");
                cons($"Строка: {a}\nКол-во знаков в строке:{f(a)}");

            }
            //замена одного символа на другой
            public static void Rem(ref string a, Action<string> cons, Func<string, int> f)
            {
               cons("\t\t\t\tМетод Rem\nЗаменили один символ на другой");

                a = a.Replace('!', '\n');
                a = a.Replace('.', '!');
                cons($"Строка: {a}\nКол-во знаков в строке:{f(a)}");

            }
            //перевод строки в верхний регистр
            public static void ToUp(ref string a, Action<string> cons, Func<string, int> f)
            {
                cons("\t\t\t\tМетод ToUp\nПеревели строку в верхний регистр");
                a = a.ToUpper();
                cons($"Строка: {a}\nКол-во знаков в строке:{f(a)}");
            }
          
        }

    }
}