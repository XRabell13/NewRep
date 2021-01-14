using System;

interface IMovable// его методы обязательно должны быть реализованы в классах
{


    // методы
    void Move(int speed);                // движение


    // свойства
    string NameOrganization { get; set; }   // название транспорта
    string Marka { get; set; }  // марка транспорта
    string Number { get; set; } // номер транспорта
    int Speed { get; set; }


}

// то, что может быть, а может и не быть
[Serializable]
public abstract class Transport//общий, базовый класс. Абстрактный. Все его методы МОГУТ БЫТЬ реализованы 
{

    int MaxSpeed { get; set; }
    int MinSpeed { get; set; }

    int WayKm { get; set; }


    public int MoveInWay(int wayKm, int speed) => wayKm / speed;//реализован уже и можно просто использовать

    public abstract void MaxSpeeds(int speed);//нужно реализовать

}

[Serializable]
public class Car : Transport, IMovable
{

    public string NameOrganization { get; set; }   // название транспорта
    public string Marka { get; set; }  // марка транспорта
    public string Number { get; set; } // номер транспорта

    [NonSerialized]//несериализуемое поле
    public readonly string ID;
    int maxSpeed { get; set; }
    int minSpeed { get { return minSpeed; } set { minSpeed = 1; } }//1, чтобы при делении на 0 не было ошибки

    int wayKm { get { return wayKm; } set { if (value > 0) wayKm = value; else wayKm = 1; } }//сколько проехал км

    public int Speed { get; set; }

    public void Move(int speed)
    {
        Speed = speed;
        Console.WriteLine($"Скорость установлена для Car равная: {Speed}km/h");
    }

    public override void MaxSpeeds(int speed)
    {
        if (speed > 0 && speed < 190) Speed = speed;

        Console.WriteLine($"MaxСкорость установлена для Car равная: {Speed}km/h");
    }

    public Car(string n, string m, string num)
    {
        NameOrganization = n;  // название транспорта
        Marka = m;  // марка транспорта
        Number = num; // номер транспорта
        MaxSpeeds(150);
        ID = Convert.ToString(Number.GetHashCode() + NameOrganization.GetHashCode());
    }

    public Car()
    {
        NameOrganization = "OrganizationForCars";  // название транспорта
        Marka = "Other";  // марка транспорта
        Number = "1111111"; // номер транспорта
        MaxSpeeds(150);
       // ID = Convert.ToString(Number.GetHashCode() + NameOrganization.GetHashCode());
    }

 
    public sealed class Engine //двигатель
    {
        string Type { get; set; }
        string Power { get; set; }

        public Engine()
        {
            Type = "Goods";
            Power = "240 л.с.";
        }

    }



    //переопределение всех методов унаследованных от object
    public override int GetHashCode()
    {
        // 269 или 47 простые
        int hash = 269;
        hash = string.IsNullOrEmpty(Number) ? 0 : Number.GetHashCode();
        hash = (hash * 47) + NameOrganization.GetHashCode();
        return hash;
    }

    public virtual Boolean Equals(Car obj)
    {
        // Сравниваемый объект не может быть равным null
        if (obj == null) return false;
        // Объекты разных типов не могут быть равны
        //  if (this.GetType() != obj.GetType()) return false;
        if (this.ID != obj.ID) return false;//сравниваем по ID, ибо если ID разные, то и поля в чем-то различаются

        return true;
    }

    public new Type GetType()
    {
        return typeof(Car);
    }

    public override string ToString()
    {
        return "Класс: Car\nНаименование фирмы: " + NameOrganization + "\nМарка:" + Marka + "\nНомер:" + Number + "\nID:" + ID + "\nMaxSpeed:" +
             Speed + "\nМетоды: Move, MaxSpeed\nПереопределения: GetType(),GetHashCode(), Finallize()" +
             "toString(), Eguals()";
    }

}