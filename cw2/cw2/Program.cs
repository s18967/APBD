using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            String csvpath = Console.ReadLine(); //C:\Users\s18967\Desktop\APBD\dane.csv
            String xmlpath = Console.ReadLine(); //C:\Users\s18967\Desktop\APBD
            String format = Console.ReadLine();  //xml

            String[] source = File.ReadAllLines(csvpath);

            XElement xml = new XElement("Uczelnia",
             from str in source
             let fields = str.Split(',')
             select new XElement("Studenci",
                    new XAttribute("indexNumber", "s"+fields[4]),
                    new XElement("fname", fields[0]),
                    new XElement("lname", fields[1]),
                    new XElement("birthdate", fields[5]),
                    new XElement("email", fields[6]),
                    new XElement("mothersName", fields[7]),
                    new XElement("fathersName", fields[8]),
                    new XElement("studies",
                        new XElement("name", fields[2]),
                        new XElement("mode", fields[3])
                    )
                )
             );

            xml.Save(String.Concat(xmlpath + "result.xml")); // konkatenacja pozwala nam nazwac plik

        }
    }
}