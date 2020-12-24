using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Diagnostics;

namespace _2kLabsSharp_6
{
    public partial class Program
    {
        // https://docs.microsoft.com/ru-ru/dotnet/standard/exceptions/ - какие лучше классы для исключений наследовать


        public class DiapasonInvalidException : Exception//вызывается, если указано неверное значение диапазонов
        {
         
            public void FromOrToInvalidValue()
            {
                Console.WriteLine("Введен неверный диапазон!");
                
                Console.Write(this.Message + "\n\n");
                Console.Write(this.TargetSite + "\n\n");
                Console.Write(this.StackTrace + "\n\n");
            }
          
        }
        //ЗДЕСЬ ЕСТЬ  Assert!
        public class MaxSpeedInvlidValueException : Exception//вызывается, если неверное значение скорости задано
        {
            public void MyExeption(int speed)
            {
                Debug.Assert(this == null, $"Скорость имеет невозможное для данного параметра значение: {speed}");
                Console.WriteLine("Введено неправильное значение maxspeed");
                Console.Write(this.Message + "\n\n");
                Console.Write(this.TargetSite + "\n\n");
                Console.Write(this.StackTrace + "\n\n");
            }
        }

        public class PriceInvlidValueException : Exception//вызывается, если задана неверная цена(0 или отрицательное значение)
        {
            public void MyExeption()
            {
                Console.WriteLine("Введено неправильное значение price");
                Console.Write(this.Message + "\n\n");
                Console.Write(this.TargetSite + "\n\n");
                Console.Write(this.StackTrace + "\n\n");
            }
        }

    }
}