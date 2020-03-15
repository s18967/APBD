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
            string logpath = @"C:\Users\Admin\Desktop\APBD\cw2\log";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose();
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
                String csvpath = Console.ReadLine(); //C:\Users\Admin\Desktop\APBD\cw2\dane.csv
                String xmlpath = Console.ReadLine(); //C:\Users\Admin\Desktop\APBD\cw2
                String format = Console.ReadLine();  //xml

                if (File.Exists(csvpath) && Directory.Exists(xmlpath) && format.Equals("xml"))
                {

                    String[] source = File.ReadAllLines(csvpath);

                    for ( int i = 0; i<source.Length; i++ )
                    {
                        String[] tab = source[i].Split(',');
                        for ( int j = 0; j<tab.Length; j++)
                        {
                            if ( tab[j].Equals("") || tab.Length!=9)
                            {
                                i++; j = 0;
                                throw new Exception("Line " + i + " is damaged, try checking it.");   
                            }
                            else
                            {
                                XElement xml = new XElement("Uczelnia",
                                 new XElement("Studenci",
                                new XAttribute("indexNumber", "s" + tab[4]),
                                new XElement("fname", tab[0]),
                                new XElement("lname", tab[1]),
                                new XElement("birthdate", tab[5]),
                                new XElement("email", tab[6]),
                                new XElement("mothersName", tab[7]),
                                new XElement("fathersName", tab[8]),
                                new XElement("studies",
                                    new XElement("name", tab[2]),
                                    new XElement("mode", tab[3])
                            )
                        )
                     );
                                xml.Save(String.Concat(xmlpath + @"\result.xml"));

                            }
                        }

                    }
                }
                else if (csvpath.Equals("") || xmlpath.Equals("") || format.Equals(""))
                {
                    csvpath = @"C:\Users\Admin\Desktop\APBD\cw2\dane.csv";
                    xmlpath = @"C:\Users\Admin\Desktop\APBD\cw2";
                    format = "xml";

                    String[] source = File.ReadAllLines(csvpath);

                    for (int i = 0; i < source.Length; i++)
                    {
                        String[] tab = source[i].Split(',');
                        for (int j = 0; j < tab.Length; j++)
                        {
                            if (tab[j].Equals("") || tab.Length != 9)
                            {
                                i++; j = 0;
                                throw new Exception("Line " + i + " is damaged, try checking it.");
                            }
                            else
                            {
                                XElement xml = new XElement("Uczelnia",
                                 new XElement("Studenci",
                                new XAttribute("indexNumber", "s" + tab[4]),
                                new XElement("fname", tab[0]),
                                new XElement("lname", tab[1]),
                                new XElement("birthdate", tab[5]),
                                new XElement("email", tab[6]),
                                new XElement("mothersName", tab[7]),
                                new XElement("fathersName", tab[8]),
                                new XElement("studies",
                                    new XElement("name", tab[2]),
                                    new XElement("mode", tab[3])
                            )
                        )
                     );
                                xml.Save(String.Concat(xmlpath + @"\result.xml"));

                            }
                        }

                    }; 

                }
                else
                {
                    if (!File.Exists(csvpath))
                    {
                        Console.WriteLine("Plik " + csvpath + " nie istnieje");
                        throw new FileNotFoundException("wrong path to csv file");
                    }
                    else if (!Directory.Exists(xmlpath))
                    {
                        Console.WriteLine("Podana ścieżka jest niepoprawna.");
                        throw new ArgumentException("wrong directory path");
                    }
                    else if (!format.Equals("xml"))
                        throw new Exception("format not in xml");
                }
            } catch (Exception ex) {
                loggingErrors(ex);
            }
        }
    }
}