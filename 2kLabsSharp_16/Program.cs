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
    public static void Main()
    {
        int ms = 0;
        Task asyncT = new Task(async () => 
        {
            for (int i = 0; i < 30; i++)
            {
                await Task.Delay(300);
                ms++;
                Console.Write("\n\t\t\t\tРАБОТАЕТ АСИНХРОННАЯ ФУНКЦИЯ\n");
            }
        }
        );
        asyncT.Start();

    Console.WriteLine("\n ============================================= ПЕРВЫЙ ПУНКТ ============================================\n");
        int k = 0, n = 0;
        Console.Write("До какого числа заполнить: ");
        n = int.Parse(Console.ReadLine());
        bool[] Simple = new bool[n];

        Task task1 = new Task(() =>
        {
            Simple = Simple.Select(y => Simple[k++] = y = true).ToArray();
            EratosfenArray(ref Simple);
            for (int i = 0; i < Simple.Length; i++)
                if (Simple[i]) Console.Write($" {i}");
        });

        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        task1.Start();

        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");
        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");

        task1.Wait();
        stopWatch.Stop();

        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime);

        Console.WriteLine("\n ============================================= ВТОРОЙ ПУНКТ ============================================\n");

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token = tokenSource.Token;
        // используем  токен в двух задачах 
        bool[] Simple1 = new bool[n];
        k = 0;
        Task task2 = new Task(() =>
        {
            Simple1 = Simple1.Select(y => Simple1[k++] = y = true).ToArray();
            EratosfenArray(ref Simple1);
            for (int i = 0; i < Simple1.Length; i++)
            {
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("\nОперация прервана токеном");
                    return;
                }
                if (Simple1[i]) Console.Write($" {i}");
            }
        }, token);

        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");

        task2.Start();

        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");
        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");

        Task Stope = new Task(() => {
            Task.Delay(2500); //асинхронный, срабатывает с началом работы программы
            tokenSource.Cancel();  });
        Stope.Start();
     
        task2.Wait();
        Stope.Wait();
        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");


        Console.WriteLine("\n ============================================= ТРЕТИЙ И ЧЕТВЕРТЫЙ ПУНКТ ============================================\n");
        //формула дискриминанта
    
        Func<int> func1 = () => {
            for (int i = 0; i < Simple1.Length; i++)
                if (Simple1[i] & i > 5000)   
              return i;
            return 0;
        };
        Func<int> func2 = () => {
            for (int i = 0; i < Simple1.Length; i++)
                if (Simple1[i] & i > 4000)
                    return i;
            return 0;
        };
        Func<int> func3 = () => {
            for (int i = 0; i < Simple1.Length; i++)
                if (Simple1[i] & i > 1000)
                    return i;
            return 0;
        };

        Task<int> task3_1 = new Task<int>(func1);
        Task<int> task3_2 = new Task<int>(func2);
        Task<int> task3_3 = new Task<int>(func3);
    
        task3_1.Start(); task3_2.Start(); task3_3.Start();
        //Использование ContinueWith
        Task Discreminant = Task.WhenAll(task3_1, task3_2, task3_3).ContinueWith( h =>
        {
            double val;
            Console.WriteLine($"Значения, полученные из задач: {task3_1.Result}, {task3_2.Result}, {task3_3.Result}\n");
            val = Math.Pow(task3_1.Result, 2) - 4 * task3_2.Result * task3_3.Result;
            if (val < 0) Console.WriteLine($"Дискреминант отрицательный: {val}");
            else Console.WriteLine($"Корень из {val} равен: {Math.Sqrt(val)}\n");
        });

        Discreminant.Wait();

   //     Console.WriteLine($"\n Идентификатор задачи: {task3_1.Id}\nСтатус задачи на данный момент: {task3_1.Status}");
     //   Console.WriteLine($"\n Идентификатор задачи: {task3_2.Id}\nСтатус задачи на данный момент: {task3_2.Status}");
      //  Console.WriteLine($"\n Идентификатор задачи: {task3_3.Id}\nСтатус задачи на данный момент: {task3_3.Status}");

        Console.WriteLine("\t\t\t\tВыволнение задачи на основе обьектов ожидания\n");
    

        var awaiter1 = task3_1.GetAwaiter();
        var awaiter2 = task3_2.GetAwaiter();
        var awaiter3 = task3_3.GetAwaiter();

    //    Console.WriteLine($"\n Идентификатор задачи: {task3_1.Id}\nСтатус задачи на данный момент: {task3_1.Status}");
      //  Console.WriteLine($"\n Идентификатор задачи: {task3_2.Id}\nСтатус задачи на данный момент: {task3_2.Status}");
      //  Console.WriteLine($"\n Идентификатор задачи: {task3_3.Id}\nСтатус задачи на данный момент: {task3_3.Status}");

        if (awaiter1.IsCompleted & awaiter2.IsCompleted & awaiter3.IsCompleted)
        {
            double val;
            Console.WriteLine($"Значения, полученные из задач: {awaiter1.GetResult()}, {awaiter2.GetResult()}, {awaiter3.GetResult()}\n");
            val = Math.Pow(awaiter1.GetResult(), 2) - 4 * awaiter2.GetResult() * awaiter3.GetResult();
            if (val < 0) Console.WriteLine($"Дискреминант отрицательный: {val}");
            else Console.WriteLine($"Корень из {val} равен: {Math.Sqrt(val)}\n");
        }

        Console.WriteLine("\n ============================================= ПЯТЫЙ ПУНКТ ============================================\n");
    
        Stopwatch stopWatch1 = new Stopwatch();
        Stopwatch stopWatch2 = new Stopwatch();
        Stopwatch stopWatch3 = new Stopwatch();
        Stopwatch stopWatch4 = new Stopwatch();
    
        //Создание объекта для генерации чисел
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        int[] mass1 = new int[1000];
        int[] mass2 = new int[1000];
     
        int j = 0;
        Console.WriteLine("\n\t\t\t\t Заполняем массив с помощью Parallel.For\n");

        stopWatch1.Start();
        Parallel.For(1, 999, (int i, ParallelLoopState pd) =>
        {
            mass1[++j] = rnd1.Next(-1000, 100000);
            Console.WriteLine($" {j}: {mass1[j]}");
        });
        stopWatch1.Stop();

        Console.WriteLine("\n\t\t\t\t Заполняем массив с помощью for\n");
        stopWatch2.Start();
        for (int i = 0; i < 999; i++) 
        {
            mass2[i] = rnd2.Next(-1000, 100000);
            Console.WriteLine($" {i}: {mass2[i]}");
        }
        stopWatch2.Stop();

        ts = stopWatch1.Elapsed;
        // Format and display the TimeSpan value.
        string elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        ts = stopWatch2.Elapsed;
        // Format and display the TimeSpan value.
         elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        Console.WriteLine("\n\t\t\t\tМассивы заполнены");
        stopWatch3.Start();
        ParallelLoopResult listFact = Parallel.ForEach(mass1, NegativeValue);//перебор в foreach
        stopWatch3.Stop();

        stopWatch4.Start();
        foreach (var elem in mass2)
            NegativeValue(elem);
        stopWatch4.Stop();

        ts = stopWatch3.Elapsed;
        // Format and display the TimeSpan value.
        elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        ts = stopWatch4.Elapsed;
        // Format and display the TimeSpan value.
        elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        Console.WriteLine("\n ============================================= ШЕСТОЙ ПУНКТ ============================================\n");

        Parallel.Invoke(
       () =>
       {
           EratosfenArray(ref Simple);
           for (int i = 0; i < Simple1.Length; i++)
               if (Simple1[i]) Console.Write($" {i}");
       },
       () => {
           for (int i = 0; i < 20; i++)
           {
               Console.WriteLine($"\n\t\t\t\tВыполняется задача {Task.CurrentId}\n\n");
               Thread.Sleep(10);
           }
       });
        Console.WriteLine("\n ============================================= СЕДЬМОЙ ПУНКТ ============================================\n");
        /*
          sklad = new BlockingCollection<int>();

          // Создадим задачи поставщика и потребителя
          Task[] Pr = new Task[5];
          Task[] Cn = new Task[10];

          // Запустим задачи

          for (int i = 0; i < Pr.Length; i++)
          {
              Console.WriteLine(i);

               Pr[i] = new Task(() =>
                  {
                      int numPr = i;
                      for (int q = 1; q < 31; q++)
                      {
                          sklad.Add(q);
                          Console.WriteLine($"\nПоставщиком №{numPr} завезена техника с артикулом: {q}");
                      }
                      sklad.CompleteAdding();
                  }
                  );
                  Pr[i].Start();

          }

          for (int i = 0; i < Cn.Length; i++)
          {
              Console.WriteLine(i);

              Cn[i] = new Task(() =>
              {
                  int w, numCn = i;
                  while (!sklad.IsCompleted)
                  {
                      if (sklad.TryTake(out w))
                          Console.WriteLine($"\nПокупателем №{numCn} куплена техника с артикулом: {w}");
                  }
              }
             );
              Cn[i].Start();
          }*/

        BlockingCollection<int> sklad = new BlockingCollection<int>();
        int x = 0, t=0;
        for (int producer = 0; producer < 5; producer++) 
        { 
            t = rnd1.Next(0, 100);
            Task.Factory.StartNew(() => {
                Task.Delay(t);
                x++; 
                for (int ii = 0; ii < 3; ii++) 
                { 
                x++; 
               // Thread.Sleep(100); 
                int id = x; 
                sklad.Add(id);
                Console.WriteLine($"\nПоставщиком  завезена техника с артикулом: {id}");
                } 
        }); 
        }
        for (int con = 0; con < 10; con++)
        {
            Task consumer = Task.Factory.StartNew(() =>
            {
                int w;
                //     foreach (var item in sklad.GetConsumingEnumerable())
                while (!sklad.IsCompleted)
                {
                    if (sklad.TryTake(out w))
                        Console.WriteLine($"\nПокупателем куплена техника с артикулом: {w}");
                }
            });
        }
        asyncT.Wait();
        Console.WriteLine(ms);
        Console.ReadKey();

    }
}