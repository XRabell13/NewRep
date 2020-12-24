using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.IO;


public class Potok
{
   static string a = "null";

    private int numberValue;

    private static SemaphoreSlim sema = new SemaphoreSlim(1);

    public static void Save(int a, string path)
    {
        try
        {

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
            {
                sw.Write($"\n{a}");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static void Save1(int a, string path)
    {
        try
        {

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
            {
                sw.Write($"\n{a}");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public Potok(int number)
    {
        numberValue = number;
    }

 
    public void SimplNumber()
    {
        for (int i = 1; i <= numberValue; i++)
        {
            if (isSimple(i))
            {
                Console.Write(i.ToString() + " ");
                Save(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\File.txt");
            }
        }
    }
    //метод который определяет простое число или нет
    public bool isSimple(int N)
    {
        //чтоб убедится простое число или нет достаточно проверить не делитсья ли 
        //число на числа до его половины
        for (int i = 2; i <= (int)(N / 2); i++)
        {
            if (N % i == 0)
                return false;
        }
        return true;
    }

    public void Chet()
    {
        Console.WriteLine();
        for (int i = 1; i <= numberValue; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i + " ");
                Save(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\ChetNechet1.txt");
            }
            Thread.Sleep(150);
        }
    }

    public void NeChet()
    {
        Console.WriteLine();
        for (int i = 1; i <= numberValue; i++)
        {
            if (i % 2 != 0)
            {
                Console.WriteLine(i + " ");
                Save(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\ChetNechet1.txt");
            }
            Thread.Sleep(100);
        }
      
    }
    public void Chet1()
    {
        Monitor.Enter(a);
        for (int i = 1; i <= numberValue; i++)
        {
          
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " ");
                    Save(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\ChetNechet1.txt");
                }
            }
          
        }
        Monitor.Exit(a);

    }

    public void NeChet1()
    {
        Monitor.Enter(a);
        for (int i = 1; i <= numberValue; i++)
        {
          
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i + " ");
                    Save(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\ChetNechet1.txt");
                }
              
            }
      
        }
        Monitor.Exit(a);
    }

    public void Chet2()
    {
       
        Console.WriteLine();
        for (int i = 1; i <= numberValue; i++)
        {
         
            if (i % 2 == 0)
            {
                Console.WriteLine(i + " ");
                sema.Wait();
                Save1(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\ChetNechet1.txt");
                sema.Release();
            }
            
           
        }
        
    }

    public void NeChet2()
    {
        Console.WriteLine();
        for (int i = 1; i <= numberValue; i++)
        {
           
            if (i % 2 != 0)
            {
                Console.WriteLine(i + " ");
                sema.Wait();
                Save1(i, @"C:\Users\hp\source\repos\2kLabsSharp_15\ChetNechet1.txt");
                sema.Release();
            }
           

        }
        
    }

}