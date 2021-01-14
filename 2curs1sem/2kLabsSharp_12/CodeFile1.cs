using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CTVLog
{
    public static string Read()
    {
        string str = null;
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt";
        try
        {
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

    public static string[] Read(string Day)
    {
        string[] str = new string[350];
        string[] strSearch = new string[7];
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt", stroka = null;
        int ind=-1;

        try
        {
            using (StreamReader sr = new StreamReader(writePath, Encoding.GetEncoding(1251)))
            {
                while (sr.Peek() != -1)
                {
                    for (int i = 0; i < 6; i++)
                    { 
                        strSearch[i] = sr.ReadLine();
                    }
                    string dayStr = strSearch[5].Substring(6,2);
                   
                    if (dayStr==Day)
                    {
                                for (int j = 0; j < 6; j++)
                                {
                                   
                                    stroka += "\n" + strSearch[j];
                                
                                }
                        ind++;
                        str[ind] = stroka;
                        stroka = null;
                    }
                    
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        for (int i = 0; i<=ind; i++)
            Console.WriteLine(str[i]);
        return str;
    }
    public static string[] Read(int Hour1, int Hour2)
    {
        string[] str = new string[350];
        string[] strSearch = new string[7];
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt", stroka = null;
        int ind = -1;

        try
        {
            using (StreamReader sr = new StreamReader(writePath, Encoding.GetEncoding(1251)))
            {
                while (sr.Peek() != -1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        strSearch[i] = sr.ReadLine();
                    }
                   int timeStr = Convert.ToInt32(strSearch[5].Substring(17, 2));
                  
                    if (timeStr>=Hour1 && timeStr <=Hour2)
                    {
                        for (int j = 0; j < 6; j++) stroka += "\n" + strSearch[j];

                        ind++;
                        str[ind] = stroka;
                        stroka = null;
                    }

                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        for (int i = 0; i <= ind; i++)
            Console.WriteLine(str[i]);
        return str;
    }

    public static string[] ReadWithWords(string KeyWord)
    {
        string[] str = new string[350];
        string[] strSearch = new string[7];
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt", stroka = null;
        int ind = -1;

        try
        {
            using (StreamReader sr = new StreamReader(writePath, Encoding.GetEncoding(1251)))
            {
                while (sr.Peek() != -1)
                {
                    bool flag = false;
                    for (int i = 0; i < 6; i++)
                    {
                        strSearch[i] = sr.ReadLine();
                    }

                    for (int i = 0; i < 6; i++)
                        if ((strSearch[i].ToLower()).IndexOf(KeyWord.ToLower()) != -1) flag = true; 
                    
                    if (flag)
                    {
                        for (int j = 0; j < 6; j++) stroka += "\n" + strSearch[j];

                        ind++;
                        str[ind] = stroka;
                        stroka = null; 
                    }

                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        for (int i = 0; i <= ind; i++)
            Console.WriteLine(str[i]);
        return str;
    }

    public static void Delete()
    {
        int Hour = DateTime.Now.Hour;
       
        string[] str = Read(Hour,Hour);
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt";
     
        try
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                for (int i = 0; str[i] != null; i++)
                sw.Write(str[i]);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }

    public static int Count()
    {

        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt";
        int ind = 0;
        
        try
        {
            using (StreamReader sr = new StreamReader(writePath, Encoding.GetEncoding(1251)))
            {
                while (sr.Peek() != -1)
                {
                    sr.ReadLine();
                    ind++;
                }

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return ind/6;
    }

    public static void Save(string act, FileInfo infFile)
    {
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt";
        try
        {
            
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
            {
                sw.Write("\nДействие: "+act+"\nИмя файла: "+infFile.FullName+"\nПолный путь: "+infFile.Name+"\nДата создания: "+infFile.CreationTime+"\nДата: "+DateTime.Now+"\n");
            }
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Save(string act, DirectoryInfo infD)
    {
        string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_13\ctvlogfile.txt";
        try
        {

            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
            {
                sw.Write("\nДействие: " + act + "\nИмя папки: " +infD.FullName + "\nПолный путь: " + infD.Name + "\nДата создания: " + infD.CreationTime + "\nДата: " + DateTime.Now + "\n");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}

public static class CTVDiskInfo
{
 /*Создать класс XXXDiskInfo c методами для вывода информации о 
         * a.  свободном месте на диске 
         * b. Файловой системе 
         * c. Для каждого существующего диска  - имя, объем, доступный объем, метка тома. 
         */
    public static void GetDiskInfo(string NameD)//информация о диске
    {
        var allDrives = DriveInfo.GetDrives();
        //  string str;
        foreach (var d in allDrives)
        {
            if (d.Name.IndexOf(NameD) > -1)
            {
                Console.WriteLine("\nИмя диска: {0}", d.Name);
                //  Console.WriteLine("Drive type: {0}", d.DriveType);
                if (!d.IsReady) continue;

                //  Console.WriteLine("File system: {0}", d.DriveFormat);
                //  Console.WriteLine("Root: {0}", d.RootDirectory);
                Console.WriteLine("Обьем(в Гб): {0}", d.TotalSize/1073741824);
               
                Console.WriteLine("Доступный обьем (в Гб): {0}", d.AvailableFreeSpace / 1073741824);
                Console.WriteLine("Метка тома: {0}", d.VolumeLabel);
            }
        }
    }
   
    public static void SizeFree(string NameD)//свободное место на диске
    {
        var allDrives = DriveInfo.GetDrives();
        foreach (var d in allDrives)
        {
            if (d.Name.IndexOf(NameD) > -1)
            {
                Console.WriteLine("Свободного места на диске {2}: {0} Гб\n{1} Байт\n", d.TotalFreeSpace / 1073741824, d.TotalFreeSpace, NameD);
            }
        }
    }
  
    public static void FileSystemInfo(string NameD)//информация о файловой системе
    {
        var allDrives = DriveInfo.GetDrives();
        foreach (var d in allDrives)
        {
            if (d.Name.IndexOf(NameD) > -1)
            {
                if (!d.IsReady) continue;
                Console.WriteLine("Имя файловой системы диска {1}: {0}", d.DriveFormat, NameD);
                Console.WriteLine("Корневой каталог диска: {0}\n", d.RootDirectory);
            }
        }
    }
}

public static class CTVFileInfo
{
    /*a.  Полный путь
     * b. Размер, расширение, имя 
     * c. Дата создания, изменения */
    public static void FullPatch(string NameF)
    {
        FileInfo fileInf = new FileInfo(NameF);
        Console.WriteLine($"Полный путь к файлу: {fileInf.FullName}");
    }
    public static void FileInf(string NameF) 
    {
        FileInfo fileInf = new FileInfo(NameF);
        Console.WriteLine($"Имя файла: {fileInf.Name}\nРасширение файла: {fileInf.Extension}\nРазмер файла(байт): {fileInf.Length}\n");
    
    }
    public static void GetCreateAndModify(string NameF) 
    {
        FileInfo fileInf = new FileInfo(NameF);
        Console.WriteLine($"Дата создания файла {fileInf.Name}: {fileInf.CreationTime}\nДата изменения файла: {fileInf.LastWriteTime}\n");
    }

    
}

public static class CTVDirInfo
{
    /*a.  Количестве файлов 
     * b. Время создания 
     * c. Количестве поддиректориев 
     * d. Список родительских директориев */
    public static void CountFiles(string NameD)
    {
        var dir = new DirectoryInfo(NameD);
        Console.WriteLine($"Количество файлов директории {dir.Name}: {dir.GetFiles().Length}\n");
    }

    public static void TimeCreation(string NameD)
    {
        var dir = new DirectoryInfo(NameD);
        Console.WriteLine($"Время создания директория {dir.Name}: {dir.CreationTimeUtc}\n");
    }
 
    public static void CountFolders(string NameD)
    {
        var dir = new DirectoryInfo(NameD);
        Console.WriteLine($"Количество поддиректориев директория {dir.Name}: {dir.GetDirectories().Length}\n");
    }

    public static void ParentDirectories(string NameD)
    {
        var dir = new DirectoryInfo(NameD);
        Console.WriteLine($"Список родительских директориев директория: ");
        while(dir.Parent != null)
        {
            Console.WriteLine(dir.Parent);
            dir = dir.Parent;
        }
    }
}

public static class CTVFileManager
{
    public static void PunctA(string NameDisk)
    {
        /*
        a. Прочитать список файлов и папок заданного диска. 
        Создать директорий XXXInspect, создать текстовый файл xxxdirinfo.txt и сохранить туда  информацию.
        Создать копию файла и переименовать его. 
        Удалить первоначальный файл. 
         */
        Console.WriteLine("\n\t\t\t\t МЕТОД PunctA \n");

        var Inf = new DirectoryInfo(NameDisk);

        string infFilies = null, infFolders = null;

        Console.WriteLine($"Список файлов: ");

        for (int i = 0; i < Inf.GetFiles().Length; i++)
        {
            infFilies += "\n" + Inf.GetFiles()[i];
        }

        Console.WriteLine(infFilies);
        Console.WriteLine($"\nСписок папок: ");

        for (int i = 0; i < Inf.GetDirectories().Length; i++)
        {
            infFolders += "\n" + Inf.GetDirectories()[i];
        }

        Console.WriteLine(infFolders);
        Console.WriteLine("\n\t\t\t\t Создаем директорий \n");

        Directory.CreateDirectory(@"E:\CTVInspect");
        CTVLog.Save("Создан директорий.", new DirectoryInfo(@"E:\CTVInspect"));

        Console.WriteLine("\n\t\t\t\t Создаем новый файл и записываем в него информацию \n");

        try
        {      
            using (StreamWriter sw = new StreamWriter(@"E:\CTVInspect\ctvdirinfo.txt", false, System.Text.Encoding.Default))//если записи пропадают, поменять на false
            {
                sw.Write($"\nСписок файлов: {infFilies}\n");        
                sw.Write($"\nСписок папок: {infFolders}\n");  
            }
            CTVLog.Save("Создали файл и записали в него информацию.", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));
            Console.WriteLine("Запись выполнена");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("\n\t\t\t\t Копируем файл и переименовываем его\n");
      
        try
        {
            File.Copy(@"E:\CTVInspect\ctvdirinfo.txt", @"E:\ctvdirinfoCOPY.txt");
            CTVLog.Save("Копировали файл", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));
            CTVLog.Save("Создали копированием файл", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));

        }
        catch (System.IO.IOException)
       {
            Console.WriteLine("Файл уже существует, поэтому удалим его и вставим новый");
            CTVLog.Save("Удаляется файл", new FileInfo(@"E:\ctvdirinfoCOPY.txt"));
            File.Delete(@"E:\ctvdirinfoCOPY.txt");
            File.Copy(@"E:\CTVInspect\ctvdirinfo.txt", @"E:\ctvdirinfoCOPY.txt");
            CTVLog.Save("Копировали файл", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));
            CTVLog.Save("Создали копированием файл", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));
        }
        CTVLog.Save("Копировали файл с переименованием.", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));

        Console.WriteLine("\n\t\t\t\t Удаляем первоначальный файл \n");
        CTVLog.Save("Удаляется файл", new FileInfo(@"E:\CTVInspect\ctvdirinfo.txt"));

        File.Delete(@"E:\CTVInspect\ctvdirinfo.txt");

    }

    public static void PunctB(string NameDir, string NameExtension)
    {
        /*
        Создать еще один директорий XXXFiles. 
        Скопировать в него все файлы с заданным расширением из заданного пользователем директория. 
        Переместить XXXFiles в XXXInspect.
         */
        Console.WriteLine("\n\t\t\t\t МЕТОД PunctB \n");

        string[] filePaths = Directory.GetFiles(NameDir);//@"C:\Users\hp\Project\NewRep"
        Console.WriteLine("\n\t\t\t\t Создаем директорий \n");

        Directory.CreateDirectory(@"E:\CTVFiles");
        CTVLog.Save("Создан директорий.", new DirectoryInfo(@"E:\CTVFiles"));

        Console.WriteLine("\n\t\t\t\t Копируем все файлы с заданным расширением в другой директорий \n");

        foreach (string file in filePaths)
        {
            Console.WriteLine($"\n{file}");
            FileInfo info = new FileInfo(file);
            if (File.Exists(info.FullName) & info.Extension == NameExtension)
            {
                try
                {
                    File.Copy(file, Path.Combine(@"E:\CTVFiles\", info.Name));
                    CTVLog.Save("Копировали файл.", new FileInfo(file));
                    CTVLog.Save("Вставили файл.", new FileInfo(Path.Combine(@"E:\CTVFiles\", info.Name)));

                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Файл уже существует, поэтому удалим его и вставим новый");

                    CTVLog.Save("Удалили файл.", new FileInfo(Path.Combine(@"E:\CTVFiles\", info.Name)));
                    File.Delete(Path.Combine(@"E:\CTVFiles\", info.Name));

                    File.Copy(file, Path.Combine(@"E:\CTVFiles\", info.Name));
                    CTVLog.Save("Копировали файл.", new FileInfo(file));
                    CTVLog.Save("Вставили файл.", new FileInfo(Path.Combine(@"E:\CTVFiles\", info.Name)));
                }
            }
           
        }

        Console.WriteLine("\n\t\t\t\t Перемещаем папку в другой директорий \n");

        try
        {
            CTVLog.Save("Перемещение данной папки в другую папку.", new DirectoryInfo(@"E:\CTVFiles"));
            Directory.Move(@"E:\CTVFiles", @"E:\CTVInspect\CTVFiles");
          
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Папки нет, потому ее создадим");

            Directory.CreateDirectory(@"E:\CTVInspect");
            CTVLog.Save("Создали папку.", new DirectoryInfo(@"E:\CTVInspect"));

            CTVLog.Save("Перемещение данной папки в другую папку.", new DirectoryInfo(@"E:\CTVFiles"));
            Directory.Move(@"E:\CTVFiles", @"E:\CTVInspect\CTVFiles");
          

        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("Папка уже существует, поэтому удалим ее");

            CTVLog.Save("Удаление папки.", new DirectoryInfo(@"E:\CTVInspect\CTVFiles"));
            Directory.Delete(@"E:\CTVInspect\CTVFiles", true);

            CTVLog.Save("Перемещение данной папки в другую папку.", new DirectoryInfo(@"E:\CTVFiles"));
            Directory.Move(@"E:\CTVFiles", @"E:\CTVInspect\CTVFiles");
        

        }
       
    }

    public static void PunctC(string NameZ)
    {
        /*
        Сделайте архив из файлов директория XXXFiles.
        Разархивируйте его в другой директорий. 
         */
        //GZipStream compressionStream = new GZipStream(NameD, CompressionMode.Compress);
        Console.WriteLine("\n\t\t\t\t МЕТОД PunctC \n");

        string zipName = Path.Combine(@"E:\CTVInspect\", NameZ);
        string zipFoulder = @"E:\CTVInspect\CTVFiles"; 

        try
        {
            ZipFile.CreateFromDirectory(zipFoulder, zipName);
            CTVLog.Save("Архивация файлов папки.", new DirectoryInfo(zipFoulder));

        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("Файл уже существует, поэтому удалим его");
            CTVLog.Save("Удаление архива.", new FileInfo(zipName));

            File.Delete(zipName);
            ZipFile.CreateFromDirectory(zipFoulder, zipName);
            CTVLog.Save("Архивация файлов папки.", new DirectoryInfo(zipFoulder));

        }

        try
        {
            CTVLog.Save("Извлечение архива.", new DirectoryInfo(zipName));
            ZipFile.ExtractToDirectory(zipName, @"E:\test_1fromArhive");
          
        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("Папка уже существует, поэтому удалим ее");

            CTVLog.Save("Удаление папки.", new DirectoryInfo(@"E:\test_1fromArhive"));
            Directory.Delete(@"E:\test_1fromArhive",true);

            CTVLog.Save("Извлечение архива.", new DirectoryInfo(zipName));
            ZipFile.ExtractToDirectory(zipName, @"E:\test_1fromArhive");

        }

    }
}
