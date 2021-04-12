using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kLabsSharp_1
{
    class Program
    {

        
        static void iuncheck()
            {
            int ia = 2147483647; //максимальное значение для int
            unchecked
                {
                   
                    int ib =ia + 1;
                    //ib = a + 1;
                    Console.WriteLine(ib);

                }
                return;
               
            }

  static void icheck()
 {
            int ia = 2147483647; //максимальное значение для int
      checked
    {
       
        int ib = ia + 1;
        //int ib = a + 1;
        Console.WriteLine(ib);

    }
    return;

}


static void Main(string[] args)
        {



            ////////////////////////////////////////1)ТИПЫ////////////////////////////////////////

            bool alive = true;
            bool isbool;
            byte bit = 102;
            byte bit1;

            short n1 = 102;
            short n2;
            int a = 10;
            int b = 0b101;  // бинарная форма b =5
            int c = 0xFF;   // шестнадцатеричная форма c = 255
            int f;
            long lb = 20L;

            float fa = 1.01234f;
            /*
             * при присвоении переменной значения с плавающей точкой важно знать о суффиксах.
             * Компиляторы зачастую по умолчанию воспринимают числа с плавающей точкой как тип double. 
             * Для типа float нужно добавлять в конце f, для decimal – m, а для double – d
             */
            double da = 1.2345678910d;

            decimal dec = 28.23444m;

            char ca = 'A';
            char cb = '\x5A';
            char cc = '\u0420';
            char ch;

            string hello = "Hello";
            string text;

            object oa = 22;
            object ob = 3.14;
            object oc = "hello code";
            object obj;

            Console.WriteLine("bool: {0};\nbyte: {1};\nshort: {2};\nint: a = {3}; b = {4} c = {5};\nlong: {6};\nfloat: {7};\ndouble: {8};\ndecimal: {9};", alive, bit, n1, a, b, c, lb, fa, da, dec);
            Console.WriteLine("char: a = {0}, b = {1}, c = {2};\nstring: {3};\nobject: a = {4}; b = {5} c = {6};", ca, cb, cc, hello, oa, ob, oc);
            //Явное преобразование
            Console.Write("bool: "); isbool = Convert.ToBoolean(Console.ReadLine());
            Console.Write("byte: "); bit1 = Convert.ToByte(Console.ReadLine());
            Console.Write("short: "); n2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("int: "); f = Convert.ToInt16(Console.ReadLine());
            Console.Write("char: "); ch = Convert.ToChar(Console.ReadLine());
            Console.Write("string: "); text = Convert.ToString(Console.ReadLine());
            Console.Write("object: "); obj = Console.ReadLine();

            //Неявное преобразование
            da = fa; //из float в double
            n1 = bit; //из byte в short
            f = bit1;
            lb = a;
            c = n2;
            //Выполните упаковку и распаковку значимых типов. 
            int s = 5;
            object o = s; //упаковка
            s = (int)o; //распаковка
                        //Неявно типизированная переменная
            var name = "Alex Erohin";
            var age = 26;
            var isProgrammer = true;

            // Определяем тип переменных
            Type nameType = name.GetType();
            Type ageType = age.GetType();
            Type isProgrammerType = isProgrammer.GetType();

            // Выводим в консоль результаты
            Console.WriteLine("Тип name: {0}", nameType);
            Console.WriteLine("Тип age {0}", ageType);
            Console.WriteLine("Тип isProgrammer {0}", isProgrammerType);
            // Пример работы с Nullable переменной 
            int? z1 = 5;
            bool? enabled1 = null;
            double? d1 = 3.3;

            Nullable<int> z2 = 5;
            Nullable<bool> enabled2 = null;
            Nullable<double> d2 = 3.3;

            if (z1.HasValue)
                Console.WriteLine("z1 = {0} ", z1.Value);
            else
                Console.WriteLine("z1 is equal to null");
            if (enabled1.HasValue)
                Console.WriteLine("enabled1 = {0} ", enabled1.Value);
            else
                Console.WriteLine("enabled is equal to null");
            /*
             * Определите переменную  типа  var и присвойте ей любое значение.
             * Затем следующей инструкцией присвойте ей значение другого типа. 
             * Объясните причину ошибки. 
             */
            var age1 = 26;
            //age1 = "qwert"; возникает ошибка, так как после неявной типизации переменной, ее неявный тип закрепляется за ней

            ////////////////////////////////////////2)СТРОКИ////////////////////////////////////////
            //Строковые литералы
            string text1 = "It's literal";
            string text2 = "And it's literal";
            string text3 = "Literal";
            //сравнение
            /*Данная версия метода Compare принимает две строки и возвращает число.
             * Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля.
             * В противном случае возвращается число больше нуля.
             * И третий случай - если строки равны, то возвращается число 0.*/
            int result = String.Compare(text1, text2);
            if (result < 0)
            {
                Console.WriteLine("Строка text1 перед строкой text2");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка text1 стоит после строки text2");
            }
            else
            {
                Console.WriteLine("Строки text1 и text2 идентичны");
            }

            //сцепление(конкатенация)

            string text4 = String.Concat(text3, "!!!");
            Console.WriteLine("text4: {0}", text4);

            //копирование

            string text5 = String.Copy(text4);
            Console.WriteLine("text5: {0}", text5);

            //выделение подстроки

            string text6 = text5.Substring(4);//если считать от 0, то в скобках указывается номер символа, с которого нужно начать вывод подстроки
            Console.WriteLine("text6: {0}", text6);

            //разделение

            string text7 = "И поэтому все будет хорошо";
            string[] words = text7.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", words);

            //вставка подстроки в заданную позицию

            string text8 = "Хороший день";
            string subString = "замечательный ";

            text8 = text8.Insert(8, subString);
            Console.WriteLine(text8);
            Console.WriteLine("\n");

            //удаление заданной подстроки

            string text9 = "Хороший день";
            // индекс последнего символа
            int ind = text9.Length - 1;
            // вырезаем последний символ
            text9 = text9.Remove(ind);
            Console.WriteLine(text9);
            Console.WriteLine("\n");
            // вырезаем первые два символа
            text9 = text9.Remove(0, 2);
            Console.WriteLine(text9);
            Console.WriteLine("\n");

            //интерполирование строк

            Console.WriteLine($"Разный текст здесь будет:\n {text1}\n{text2}\n{text3}\n{text3}\n" +
                $"\nПару цифр: {a}, {b}, {c}, сумма первых двух: {a + b}\n");

            string voidstring = "";
            string voidstr = null;

            if (voidstr == voidstring) Console.WriteLine("Равны");
            else Console.WriteLine("Не равны");

            if (string.IsNullOrEmpty(voidstr)) Console.WriteLine("\"Null\" или пустая строка\n");
            else Console.WriteLine("В строке что-то написано\n");
            Console.WriteLine("Количество символов в пустой строке... {0}! Логично, да?\n", voidstring.Length);

            //StringBuilder

            StringBuilder sb = new StringBuilder("Привет мир");
            sb.Append("!");
            sb.Insert(7, "компьютерный ");
            Console.WriteLine(sb);

            // заменяем слово
            sb.Replace("мир", "world");
            Console.WriteLine(sb);

            // удаляем 13 символов, начиная с 7-го
            sb.Remove(7, 13);
            Console.WriteLine($"{sb}\n");

            ////////////////////////////////////////3)МАССИВЫ////////////////////////////////////////

            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            int rows = mas.GetUpperBound(0) + 1; //возвращает индекс последнего элемента в определенной размерности
            int columns = mas.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas[i, j]} \t");
                }
                Console.WriteLine();
            }
            //массив строк
            a = words.Length;//размер массива
            for (int i = 0; i < a; i++)
            {
                Console.Write($" {words[i]}");
            }

            Console.WriteLine("\nВведите позицию и новый символ. \nПозиция: ");

            b = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Новая строка: ");
            voidstr = Convert.ToString(Console.ReadLine());

            words[b] = voidstr;

            for (int i = 0; i < a; i++)
            {
                Console.Write($" {words[i]}");
            }
            Console.WriteLine();

            //зубчатый массив

            double[][] numbers = new double[3][];
            numbers[0] = new double[2];
            numbers[1] = new double[3];
            numbers[2] = new double[4];
            Console.WriteLine("Введите элементы массива: ");
            // перебор с помощью цикла for
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    numbers[i][j] = Convert.ToDouble(Console.ReadLine());
                    //Console.Write($"{numbers[i][j]} \t");
                }

            }
            Console.WriteLine();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
                Console.WriteLine();
            }

            //создание неявнотипизированной переменной для массива и строки

            var array = new object[0];
            var str = "";

            ////////////////////////////////////////3)КОРТЕЖИ////////////////////////////////////////

            (int, string, char, string, ulong) tuple = (13, "qwerty", 'u', "hahaha", 1234);

            Console.WriteLine($"Весь кортеж: {tuple}\n");
            Console.WriteLine($"Некоторые его элементы: {tuple.Item1}, {tuple.Item3}, {tuple.Item4}");
            //способы распаковки кортежей и их сравнение 
            var A = tuple.Item1;
            (string tu, int ty) kort1 = ("Hello", 10);
            (string, int) kort2 = ("Hell", 10);
            if (kort1 == kort2) Console.WriteLine("Кортежи равны!");
            else Console.WriteLine("Кортежи НЕ равны");

            ////////////////////////////////////////4)ЛОКАЛЬНАЯ ФУНКЦИЯ///////////////////////////////////////////

            (int maxEl, int minEl, int sum, char firstS) LocalFunc(int[] mass, string stroka)
            {
                int summa = 0, maxElem, minElem;
                char firstS;

                for (int i = 0; i < mass.Length; i++)
                {
                    summa += mass[i];
                }

                maxElem = mass.Max();
                minElem = mass.Min();

                firstS = stroka[0];

                return (maxElem, minElem, summa, firstS);
            }

            int[] mas1 = { 1, 2, 3, 4, 5 };
            var (maxEl, minEl, sum, firsts) = LocalFunc(mas1, text7);

            Console.WriteLine($"{maxEl}, {minEl}, {sum}, {firsts}\n");
            ////////////////////////////////////////5) Работа с checked/ unchecked: ///////////////////////////////////////////

            //2147483647

           

            iuncheck();
            icheck();

            /*
                      Console.Write("Введите ba: ");
                      // Используем unchecked в одном выражении
                      ba = unchecked((byte)int.Parse(Console.ReadLine()));
                      Console.Write("Введите bb: ");
                      bb = unchecked((byte)int.Parse(Console.ReadLine()));

                      // Используем checked для всего блока операторов
                      checked
                      {
                          bresult = (byte)(ba + bb);
                          Console.WriteLine("ba + bb = " + bresult);
                          bresult = (byte)(ba * bb);
                          Console.WriteLine("ba*bb = " + bresult + "\n");
                      }
                */

            


        }
    }
}
