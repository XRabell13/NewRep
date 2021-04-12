using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml;

class Program
    {
    static void Main(string[] args)
    {
        Console.WriteLine("\n ============================================= ПЕРВЫЙ ПУНКТ ============================================\n");


        Car C1 = new Car("Cars", "Opel", "123456");
        Car C2 = new Car("Cars", "Zaphire", "154456");
        Car C3 = new Car("Org", "Astra", "178080");
        Car C4 = new Car("Ord", "Bently", "789523");

        Console.WriteLine("\n ============================================= Binary ============================================\n");

        Console.WriteLine($"\n\nОбъект С1 до сериализации: \n{C1}");

        BinaryFormatter formatter = new BinaryFormatter();
        // получаем поток, куда будем записывать сериализованный объект 
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\C1New.txt", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, C1);

        }
        // десериализация 
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\C1New.txt", FileMode.OpenOrCreate))
        {
            Car DesC1 = (Car)formatter.Deserialize(fs);
            Console.WriteLine($"\n\nОбъект после десериализации из Binary: \n{DesC1}");

        }
        Console.WriteLine("\n ============================================= Soap ============================================\n");

        Console.WriteLine($"\n\nОбъект С2 до сериализации: \n{C2}");
        SoapFormatter soapFormatter = new SoapFormatter();
        using (Stream fStream = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\C2.txt", FileMode.OpenOrCreate))
        {

            soapFormatter.Serialize(fStream, C2);

        }
        using (Stream fStream = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\C2.txt", FileMode.OpenOrCreate))
        {

            Car DesC2 = (Car)soapFormatter.Deserialize(fStream);
            Console.WriteLine($"\n\nОбъект после десериализации из Soap: \n{DesC2}");

        }

        Console.WriteLine("\n ============================================= Json ============================================\n");

        Console.WriteLine($"\n\nОбъект С3 до сериализации: \n{C4}");
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Car));
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\car4.json", FileMode.OpenOrCreate))
        {
            jsonFormatter.WriteObject(fs, C4);
        }
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\car4.json", FileMode.OpenOrCreate))
        {
            Car DesC4 = (Car)jsonFormatter.ReadObject(fs);
            Console.WriteLine($"\n\nОбъект после десериализации из Json: \n{DesC4}");

        }

        Console.WriteLine("\n ============================================= XML ============================================\n");

        Console.WriteLine($"\n\nОбъект С3 до сериализации: \n{C3}");
        XmlSerializer CarSerXML = new XmlSerializer(typeof(Car));

        // получаем поток, куда будем записывать сериализованный объект
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\cars3.xml", FileMode.OpenOrCreate))
        {
            CarSerXML.Serialize(fs, C3);
        }
        // десериализация
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\cars3.xml", FileMode.OpenOrCreate))
        {
            Car DesC3 = CarSerXML.Deserialize(fs) as Car;
            Console.WriteLine($"\n\nОбъект после десериализации из XML: \n{DesC3}");

        }

        Console.WriteLine("\n ============================================= ВТОРОЙ ПУНКТ ============================================\n");

        XmlSerializer CarsXML = new XmlSerializer(typeof(Car[]));
        Console.WriteLine($"\n\nМассив до сериализации: \n");

        Car[] Cars = new Car[] { C1, C2, C3, C4 };
        for (int i = 0; i < Cars.Length; i++)
            Console.WriteLine($"\n{Cars[i]}");

        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\carsXMLNew.xml", FileMode.OpenOrCreate))
        {
            CarsXML.Serialize(fs, Cars);
        }
        // десериализация
        using (FileStream fs = new FileStream(@"C:\Users\hp\source\repos\2kLabsSharp_14\carsXMLNew.xml", FileMode.OpenOrCreate))
        {
            Car[] CarsX = CarsXML.Deserialize(fs) as Car[];
            Console.WriteLine($"\n\nМассив после десериализации из XML: \n");
            for (int i = 0; i < CarsX.Length; i++)
                Console.WriteLine($"\n{CarsX[i]}");

        }

        Console.WriteLine("\n ============================================= ТРЕТИЙ ПУНКТ ============================================\n");

        XmlDocument doc = new XmlDocument();
        doc.Load(@"C:\Users\hp\source\repos\2kLabsSharp_14\carsXML.xml");
        XmlNode root = doc.DocumentElement;

        XmlNodeList nodeList;

        nodeList = root.SelectNodes("descendant::Car[Marka='Zaphire']");
        Console.WriteLine("Информация из узлов с маркой машины Zaphire: ");

        foreach (XmlNode nd in nodeList)
        {
            Console.WriteLine($"\nOrg: {nd.FirstChild.InnerText}\nMarka: {nd.FirstChild.NextSibling.InnerText}\nNumber: {nd.FirstChild.NextSibling.NextSibling.InnerText}\nSpeed: {nd.LastChild.InnerText}");

        }
        XmlNode nod = root.SelectSingleNode("descendant::Car[Speed>140]");//один узел берем, первый, удовлетворяющий условию
        Console.WriteLine("\nИнформация из первого узла, значение скорости которого больше 140: ");

        Console.WriteLine($"\nOrg: {nod.FirstChild.InnerText}\nMarka: {nod.FirstChild.NextSibling.InnerText}\nNumber: {nod.FirstChild.NextSibling.NextSibling.InnerText}\nSpeed: {nod.LastChild.InnerText}");

        Console.WriteLine("\n ============================================= ЧЕТВЕРТЫЙ ПУНКТ ============================================\n");

        XmlDocument newdoc = new XmlDocument();
        newdoc.Load(@"C:\Users\hp\source\repos\2kLabsSharp_14\P4ModCars.xml");

        XmlNode rootNew = newdoc.DocumentElement;

        XmlNodeList nodeListNew = rootNew.SelectNodes("descendant::Car[Speed>220]");

        foreach (XmlNode nd in nodeListNew)
        {
            nd.FirstChild.InnerText = "NewCar2020";
            nd.FirstChild.NextSibling.InnerText = "Tesla";

        }

        Console.WriteLine("\n\nНовосозданный документ по выборке на скорость и с заменой значений узлов: ");
        newdoc.Save(Console.Out);

        Console.WriteLine("\n\nЗначения узлов, в которых Number>800: ");

        XmlNode nodNew = rootNew.SelectSingleNode("descendant::Car[Marka = 'Tesla']");
        nodeListNew = rootNew.SelectNodes("descendant::Car[Number>800]");
        foreach (XmlNode nd in nodeListNew)
        {
            Console.WriteLine($"\nOrg: {nd.FirstChild.InnerText}\nMarka: {nd.FirstChild.NextSibling.InnerText}\nNumber: {nd.FirstChild.NextSibling.NextSibling.InnerText}\nSpeed: {nd.LastChild.InnerText}");

        }
        Console.WriteLine("\n\nЗначение первого узла, в котором Marka='Tesla': ");

        Console.WriteLine($"\nOrg: {nodNew.FirstChild.InnerText}\nMarka: {nodNew.FirstChild.NextSibling.InnerText}\nNumber: {nodNew.FirstChild.NextSibling.NextSibling.InnerText}\nSpeed: {nodNew.LastChild.InnerText}");

        Console.WriteLine("\n\nПоиск по названию организации: ");

        XDocument xdoc = XDocument.Load(@"C:\Users\hp\source\repos\2kLabsSharp_14\P4ModCars.xml");

        xdoc.Element("ArrayOfCar").AddFirst(
                    new XElement("CAR",
                        new XElement("NameOrganization", "ORGANIZATION"),
                        new XElement("Marka", "Mahina1")));

     //   XDocument DocXml = XDocument.Load(@"C:\Users\hp\source\repos\2kLabsSharp_14\P4ModCars.xml");

        xdoc.Save(@"C:\Users\hp\source\repos\2kLabsSharp_14\NEWCAR.xml");//@"C:\Users\hp\source\repos\2kLabsSharp_14\NEWCAR.xml"

        var items = from xe in xdoc.Element("ArrayOfCar").Elements("Car")
                    where xe.Element("NameOrganization").Value == "NewCar2020"
                    select xe;
      
        foreach (var item in items)
            Console.WriteLine($"\nОрганизация: {item.Element("NameOrganization").Value}\nМарка:{item.Element("Marka").Value}");

      
    }
}

    

