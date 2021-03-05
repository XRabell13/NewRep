using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2k2SemLabs_2
{
    public class Airplane
    {
        public string ID;
        public string type;
        public string model;
        public ushort seatsPass;

        public string dateRelease;
        public string dateServicing;
        public int carrying;
      
        
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
            CrewList.Add(new Crewmate());
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
            CrewList.Add(new Crewmate());
        }

        public void AddCrew(Crewmate crewmate)=>
            CrewList.Add(crewmate);


        public string getCrewStr()
        {
            string crewm = "Экипаж:";
            for (int i = 0; i < CrewList.Count-1; i++)
            {
                if(CrewList[i].fio != "0")
                crewm = crewm + "\nФИО: " + CrewList[i].fio + " Должность: " + CrewList[i].post + " Возраст:" + CrewList[i].age +
                        " Стаж: " + CrewList[i].exspi + "\n";
            }
            return crewm;
        }
        public override string ToString() => model + "; " + type + "; Мест: " +
            seatsPass + "; Грузоподъемность: " + carrying + "; Дата тех.обслуживания: "
            + dateRelease + "; Выпуск: " + dateServicing + ";" + getCrewStr();//тут была ошибка с датой
     

    }
}
