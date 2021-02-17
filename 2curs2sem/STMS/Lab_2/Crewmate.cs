using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2k2SemLabs_2
{
    class Crewmate
    {
        public string fio;
        public int age;
        public int exspi;
        public string post;

        public Crewmate(string fio, int age, int exspi, string post)
        {
            this.fio = fio;
            this.age = age;
            this.exspi = exspi;
            this.post = post;
        }

     public Crewmate()
        {
            fio = "";
            age = 0;
            exspi = 0;
            post = "";
        }
        public override string ToString()
        {
            return fio + age + exspi + post;
        }

    }
}
