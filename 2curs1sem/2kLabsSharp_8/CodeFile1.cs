using System;
using System.Collections.Generic;
using System.IO;
namespace _2kLabs_Sharp_3_2_
{
    public partial class Program
    {
        public interface IMineOperation<T>
        {
            void Show();
            void Add(T a);
            void Delete(int ind);
        }
        public class MineCollectionType_1<T> : IMineOperation<T> where T: struct //T может принимать только наследников класса Transport
        {

            public string Element;
            private List<T> LParts = new List<T>();
            public int numb;
            //------------------------------Конструкторы--------------------------

            public MineCollectionType_1()//конструктор без параметров
            {
                Element = "Null";
                numb = 0;
            }

            public MineCollectionType_1(string value)//конструктор с параметрами
            {
                Element = value;
                numb = 0;
            }



            //-----------------------------Методы----------------------------------
            public void Add(T a)
            {
                LParts.Add(a);
            }

            public void Delete(int ind)
            {
                LParts.RemoveAt(ind);
            }

            public void Show()
            {
                Console.WriteLine($"Element: {Element}\nnumb: {numb}\nCollection LParts:{LParts[0]}");
                for (int i = 0; i < LParts.Count; i++)
                    Console.WriteLine($"LParts[{i}]: {LParts[i]}\n");

            }
            public string Read(string patch)
            {
                string str = null;
                string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_7\";
                try
                {
                    writePath += patch;
                    using (StreamReader sr = new StreamReader(writePath))
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

            public void Save(string patch)
            {
                string writePath = @"C:\Users\hp\source\repos\2kLabsSharp_7\";
                try
                {
                    writePath += patch;
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        sw.Write(this);
                    }
                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public override string ToString()
            {
                string str = null;
                for (int i = 0; i < LParts.Count; i++)
                { str = str + " "+ LParts[i]; }
                return Element + " " + numb + " " + str;
            }
        }
            //Обобщенный тип с ограничениями по значимому типу
        }
}