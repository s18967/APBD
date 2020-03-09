using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace cw2
{
    class Program
    {
        static void loggingErrors(Exception ex)
        {
            string logpath = @"C:\Users\s18967\Desktop\APBD\cw2";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose(); //Dispose - doczytaj
            }
            using (StreamWriter s = File.AppendText(logpath))
            {
                s.WriteLine("Start " + DateTime.Now);
                s.WriteLine("Blad: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            try {
                String csvpath = Console.ReadLine(); //C:\Users\s18967\Desktop\APBD\cw2\dane.csv
                String xmlpath = Console.ReadLine(); //C:\Users\s18967\Desktop\APBD\cw2
                String format = Console.ReadLine();  //xml

                if (File.Exists(csvpath) && Directory.Exists(xmlpath))
                {

                    String[] source = File.ReadAllLines(csvpath);

                    XElement xml = new XElement("Uczelnia",
                     from str in source
                     let fields = str.Split(',')
                     select new XElement("Studenci",
                            new XAttribute("indexNumber", "s" + fields[4]),
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
                else
                {
                    if (!File.Exists(csvpath))
                    {
                        throw new Exception("wrong path to csv file");
                    }
                }
            } catch (Exception ex) {
                loggingErrors(ex);
            }
        }
    }
}