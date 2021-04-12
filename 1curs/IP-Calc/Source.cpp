using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Programm
{
    static void Main(string[] args)
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;
        int number = 6;

        Task task1 = new Task(() = >
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("�������� ��������");
                    return;
                }

                result *= i;
                Console.WriteLine($"��������� ����� {number} ����� {result}");
                Thread.Sleep(5000);
            }
        });
        task1.Start();

        Console.WriteLine("������� Y ��� ������ �������� ��� ������ ������ ��� �� �����������:");
        string s = Console.ReadLine();
        if (s == "Y")
            cancelTokenSource.Cancel();

        Console.Read();
    }
}