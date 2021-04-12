using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public partial class Programm
{

    static void EratosfenArray(ref bool[] Simple)
    {
        for (int i = 2; i < Math.Sqrt(Simple.Length) + 1; i++)
        {
            if (Simple[i])
                for (int j = i * i; j < Simple.Length; j += i)
                    Simple[j] = false;
        }
    }
    static void NegativeValue(int x)
    {
        if (x > 100)
            Console.WriteLine($" {x}\tВыполняется задача {Task.CurrentId}");
    }


   /* static BlockingCollection<int> sklad;

    static void producer()
    {
        for (int i = 0; i < 30; i++)
        {
            sklad.Add(i);
            Console.WriteLine("\nЗавезена техника с артикулом: " + i);
        }
        sklad.CompleteAdding();
    }

    static void consumer()
    {
        int i;
        while (!sklad.IsCompleted)
        {
            if (sklad.TryTake(out i))
                Console.WriteLine("\nКуплена техника с артикулом: " + i);
        }
    }
    */


}