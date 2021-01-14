using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.IO;


class StatusChecker
{

   int timet; 

    public StatusChecker(int count)
    {
        timet = count;
    }
    public void CheckStatus(Object tim)=>
        Console.WriteLine("\t\t\t\tBegin: {0}\n\t\t\t\tTime {1}.",tim, DateTime.Now.ToString("h:mm:ss.fff"));

    
}

public class Program
    {
   
    static void Main(string[] args)
        {
      
        var statusChecker = new StatusChecker(3);
        var tim = DateTime.Now;
       
        Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n",  DateTime.Now);
        var stateTimer = new Timer(statusChecker.CheckStatus, tim, 0, 1500);

        Console.WriteLine("\n ============================================= ПЕРВЫЙ ПУНКТ ============================================\n");
  
        var allProcess = Process.GetProcesses();

        foreach (Process proc in allProcess)
        {
            ProcessThread th = proc.Threads[0];
            using (th)
            {
                try
                {
                    Console.WriteLine($"\nИмя процесса: {proc.ProcessName}\nВремя запуска: {proc.StartTime}\nПриоритет: {proc.PriorityClass}" +
                       $"\nId:{proc.Id}\nСколько времени использовал процессор: {(DateTime.Now - proc.StartTime).TotalSeconds} seconds");

                    Console.Write($"Текущее состояние: {th.ThreadState}\n");


                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Console.WriteLine("\nОтказано в доступе");
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("\nПроцесс был завершен, информация недоступна\n");
                }

            }
        }

        Console.WriteLine("\n ============================================= ВТОРОЙ ПУНКТ ============================================\n");

        AppDomain D = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя домена: {D.FriendlyName}\nДетали конфигурации:\n{D.ApplicationTrust.DefaultGrantSet.PermissionSet}\nВсе сборки, загруженные в домен:\n");
           
        foreach (var sb in D.GetAssemblies())
            {
                Console.WriteLine(sb.GetName().Name+"\n");
            }

        AppDomain newD = AppDomain.CreateDomain("NewDomen");
        newD.Load("2kLabsSharp_13");
        
        Console.WriteLine($"\t\t\t\tНовый загруженный домен.\nИмя домена: {newD.FriendlyName}\nДетали конфигурации:{newD.ApplicationTrust.DefaultGrantSet.PermissionSet}\nВсе сборки, загруженные в домен:\n");
        foreach (var sb in D.GetAssemblies())
        {
            Console.WriteLine(sb.GetName().Name + "\n");
        }

        AppDomain.Unload(newD);
        Console.WriteLine($"\t\t\t\tДомен выгружен.");

        Console.WriteLine("\n ============================================= ТРЕТИЙ ПУНКТ ============================================\n");

        Console.WriteLine("Искать простые числа от 1 до: ");
        int n = Convert.ToInt32(Console.ReadLine());
      
        Potok tws = new Potok(n);

        Thread thr = new Thread(new ThreadStart(tws.SimplNumber));
        thr.Start();//запуск

        thr.Name = "Метод SimplNumber";
        Console.WriteLine($"\nИмя потока: {thr.Name}");
        Console.WriteLine($"Id: {thr.ManagedThreadId}");   
        Console.WriteLine($"Приоритет потока: {thr.Priority}");
        Console.WriteLine($"Статус потока: {thr.ThreadState}");

        thr.Suspend();//устаревший метод, приостановка

        Console.WriteLine($"\nИмя потока: {thr.Name}");
        Console.WriteLine($"Id: {thr.ManagedThreadId}");
        Console.WriteLine($"Приоритет потока: {thr.Priority}");
        Console.WriteLine($"Статус потока: {thr.ThreadState}");

        thr.Resume();//устаревший метод, возобновление

        Console.WriteLine($"\nИмя потока: {thr.Name}");
        Console.WriteLine($"Id: {thr.ManagedThreadId}");
        Console.WriteLine($"Приоритет потока: {thr.Priority}");
        Console.WriteLine($"Статус потока: {thr.ThreadState}");

        Thread.Sleep(1000);
        thr.Abort();//начинаем процесс завершения потока
       
        Console.WriteLine($"\nИмя потока: {thr.Name}");
        Console.WriteLine($"Id: {thr.ManagedThreadId}");
        Console.WriteLine($"Статус потока: {thr.ThreadState}");

      /* thr.Join();//завершение потока
        Console.WriteLine($"\nИмя потока: {thr.Name}");
        Console.WriteLine($"Id: {thr.ManagedThreadId}");
         Console.WriteLine($"Приоритет потока: {thr.Priority}");
        Console.WriteLine($"Статус потока: {thr.ThreadState}");*/
   
        Console.WriteLine("\n ============================================= ЧЕТВЕРТЫЙ ПУНКТ ============================================\n");

        Console.WriteLine("Выводить четные и нечетные числа вперемешку от 1 до: ");
        int n1 = Convert.ToInt32(Console.ReadLine());

        Potok tw = new Potok(n1);
        
                Thread thrs = new Thread(new ThreadStart(tw.Chet));
               Thread thrs1 = new Thread(new ThreadStart(tw.NeChet));
                thrs.Start();
                thrs1.Start();
                Thread.Sleep(6000);
                thrs.Abort(); thrs1.Abort();

        Console.WriteLine("\t\t\t\tВывод с приоритетом.");

        Thread thr_1 = new Thread(new ThreadStart(tw.Chet));
        Thread thr_2 = new Thread(new ThreadStart(tw.NeChet));
        thr_1.Priority = ThreadPriority.Highest;
        thr_1.Start();
        thr_2.Start();
        Thread.Sleep(6000);
        thr_1.Abort(); thr_2.Abort();
       
         Console.WriteLine("\t\t\t\tСначала четные, потом нечетные.");
         Thread thr_3 = new Thread(new ThreadStart(tw.Chet1));
         Thread thr_4 = new Thread(new ThreadStart(tw.NeChet1));

         thr_3.Start();
         thr_4.Start();
         Thread.Sleep(3000);
         thr_3.Abort(); thr_4.Abort();
         

        Console.WriteLine("\t\t\t\t Чет-нечет");

        Thread thr_5 = new Thread(new ThreadStart(tw.Chet2));
        Thread thr_6 = new Thread(new ThreadStart(tw.NeChet2));
        thr_6.Start(); thr_5.Start();
        Thread.Sleep(4000);
    }
}
