using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RejestrCzasuPracy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Root> roots = Deserialize();
            foreach (var root in roots)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                FileStream fs = new FileStream("Praca.xml", FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UnicodeEncoding());
                serializer.Serialize(writer, root);
                writer.Close();
            }
        }
        
        private static List<Root> Deserialize()
        {
            int idLine = 3;
            List<Root> roots = new List<Root>();
            string[] data = ReadFile("Praca.csv", 2);
            
            while (true) 
            {
                try 
                {
                    string[] dataWorker = ReadFile("Praca.csv", idLine);
                    Root r = new Root();
                    Employee e = new Employee(dataWorker[0]);
                    for (int i = 1; i < data.Length && i < dataWorker.Length; i++)
                    {
                        if (dataWorker[i].Length > 0)
                        {
                            DzienPlanu d = new DzienPlanu(data[i], dataWorker[i], dataWorker[0]);
                            r.AddToDay(d);
                        }
                    }
                    roots.Add(r);
                    
                    idLine++;
                } 
                catch (Exception exception) { 
                    break;
                }
            }
            
            return roots;
        }
        private static string[] ReadFile(string filename, int line)
        {
            return File.ReadAllLines(filename).Skip(line).First().Split(';');
        }
    }
}
