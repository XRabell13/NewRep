using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
    {
        static void Main(string[] args)
        {
      
        //============================================РАБОТА КЛАССА CTVDiskInfo============================================
        Console.WriteLine("\n =============================================РАБОТА КЛАССА(2) CTVDiskInfo============================================\n");
        CTVDiskInfo.GetDiskInfo("E");
        CTVDiskInfo.GetDiskInfo("C");

        CTVDiskInfo.SizeFree("C");
        CTVDiskInfo.SizeFree("E");

        CTVDiskInfo.FileSystemInfo("E");
        CTVDiskInfo.FileSystemInfo("C");

        //============================================РАБОТА КЛАССА CTVFileInfo============================================
        Console.WriteLine("\n =============================================РАБОТА КЛАССА(3) CTVFileInfo============================================\n");
        CTVFileInfo.FileInf(@"C:\Users\hp\source\repos\2kLabsSharp_13\test.txt");
        CTVFileInfo.FullPatch(@"C:\Users\hp\source\repos\2kLabsSharp_13\test.txt");
        CTVFileInfo.GetCreateAndModify(@"C:\Users\hp\source\repos\2kLabsSharp_13\test.txt");

        //============================================РАБОТА КЛАССА CTVFileInfo============================================
        Console.WriteLine("\n =============================================РАБОТА КЛАССА(3) CTVFileInfo============================================\n");
        CTVDirInfo.CountFiles(@"C:\Users\hp\source\repos\2kLabsSharp_13");
        CTVDirInfo.CountFolders(@"C:\Users\hp\source\repos\2kLabsSharp_13");
        CTVDirInfo.TimeCreation(@"C:\Users\hp\source\repos\2kLabsSharp_13");
        CTVDirInfo.ParentDirectories(@"C:\Users\hp\source\repos\2kLabsSharp_13");
        //============================================РАБОТА КЛАССА FileManager============================================
        Console.WriteLine("\n =============================================РАБОТА КЛАССА(4) CTVFileManager============================================\n");
       
        CTVFileManager.PunctA(@"E:\");
        Console.ReadKey();
        CTVFileManager.PunctB(@"C:\Users\hp\Project\NewRep\Ответы", ".txt");
        Console.ReadKey();
        CTVFileManager.PunctC(@"Answers.zip");
        
        //============================================ ШЕСТОЙ ПУНКТ ============================================
        Console.WriteLine("\n ============================================= ШЕСТОЙ ПУНКТ ============================================\n");
         Console.WriteLine("\n\t\t\t\t Поиск по дню\n");
         CTVLog.Read("09");
        Console.ReadKey();
        Console.WriteLine("\n\t\t\t\t Поиск по периоду часа\n");
          CTVLog.Read(15,17);
        Console.ReadKey();
        Console.WriteLine("\n\t\t\t\t Поиск по ключевому слову\n");
          CTVLog.ReadWithWords("архив");
        Console.ReadKey();
        Console.WriteLine($"\n\nКоличество записей: {CTVLog.Count()}\n\n");
        Console.ReadKey();
        Console.WriteLine("\n\t\t\t\t Оставляем в файле информацию за текущий час \n");
        CTVLog.Delete();
        Console.WriteLine($"\n\nКоличество записей: {CTVLog.Count()}\n\n");
        Console.ReadKey();

    }
}