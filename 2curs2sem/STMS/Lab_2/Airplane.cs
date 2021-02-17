using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2k2SemLabs_2
{
    class Airplane
    {
        public string ID;
        public string type;
        public string model;
        public ushort seatsPass;

        public string dateRelease;
        public string dateServicing;
        public int carrying;
        private readonly int ind = 1;

        public List<Crewmate> CrewList = new List<Crewmate>();
        public Airplane(string ID, string dateRelease, string dateServicing, string model, string type, ushort seatsPass, int carrying)
        {
            this.ID = ID;
            this.type = type;
            this.model = model;
            this.seatsPass = seatsPass;
            this.dateServicing = dateServicing;
            this.dateRelease = dateRelease;
            this.carrying = carrying;
            CrewList[ind] = new Crewmate();
        }
        public Airplane(string ID, string dateRelease, string dateServicing, string model, string type, ushort seatsPass, int carrying, Crewmate crewmate)
        {
            this.ID = ID;
            this.type = type;
            this.model = model;
            this.seatsPass = seatsPass;
            this.dateServicing = dateServicing;
            this.dateRelease = dateRelease;
            this.carrying = carrying;
            CrewList.Add(crewmate);
            ind++;
        }

        public Airplane()
        {
            ID = "";
            type = "";
            model = "";
            seatsPass = 0;
            dateServicing = "";
            dateRelease = "";
            carrying = 0;
            CrewList[ind] = new Crewmate();
        }

        public void AddCrew(Crewmate crewmate)=>
            CrewList.Add(crewmate);


        private string setStr()
        {
            string crewm = "Экипаж:";
            for (int i = 0; i < CrewList.Count; i++)
            {
                crewm = crewm + "\nФИО: " + CrewList[i].fio + " Должность: " + CrewList[i].post + " Возраст:" + CrewList[i].age +
                        " Стаж: " + CrewList[i].exspi;
            }
            return crewm;
        }
        public override string ToString()
        {
            switch (type)
            {
                case "Поссажирский":
                    {
                        return model + "; " + type + "; Мест: " + seatsPass + "; Дата тех.обслуживания: " + dateRelease + "; Выпуск: "+ dateRelease+";";
                    } 
                case "Грузовой":
                    {
                        return model + "; " + type + "; Грузоподъемность: " + carrying + "; Дата тех.обслуживания: " + dateRelease + "; Выпуск: "+ dateRelease+";";
                    }
                case "Военный":
                    { 
                        return model + "; " + type + "; Мест: " + seatsPass + "; Грузоподъемность: " + carrying + "; Дата тех.обслуживания: " + dateRelease + "; Выпуск: "+ dateRelease+";";
                    }
                default: break;

            }
            return "";
          //  switch(type){                catch "Поссажирский":
          //      return model + " " + type + " Мест: " + seatsPass + " " + dateServicing + " " + dateRelease + "\n" + carrying + setStr();
          
        }

    }
}
