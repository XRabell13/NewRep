using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2k2SemLabs_2
{
    public class Crewmate
    {
        public string fio;
        public int age;
        public int exspi;
        public string post;
        [XmlIgnore]
        public bool nulls = false;

        public Crewmate(string fio, int age, int exspi, string post)
        {
            this.fio = fio;
            this.age = age;
            this.exspi = exspi;
            this.post = post;
            nulls = false;
        }

     public Crewmate()
        {
            fio = "0";
            age = 0;
            exspi = 0;
            post = "0";
            nulls = true;
        }
        public override string ToString()
        {
            if(nulls) return fio + age + exspi + post;
            else return  "ФИО: "+ fio +"Возраст: "+ age +"Стаж: "+ exspi +"Должность: "+ post;
        }

    }
}
