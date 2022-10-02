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
            List <Employee> employees = Deserialize();
            foreach (var employee in employees)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Employee));
                FileStream fs = new FileStream("Praca.xml", FileMode.Create);
                TextWriter writer = new StreamWriter(fs, new UnicodeEncoding());
                serializer.Serialize(writer, employee);
                writer.Close();
            }
        }
        
        private static List<Employee> Deserialize()
        {
            int idLine = 3;
            List<Employee> employeesList = new List<Employee>();
            string[] data = ReadFile("Praca.csv", 2);
            
            while (true) 
            {
                try 
                {
                    string[] dataWorker = ReadFile("Praca.csv", idLine);

                    Employee e = new Employee(dataWorker[0]);
                    for (int i = 1; i < data.Length && i < dataWorker.Length; i++)
                    {
                        if (dataWorker[i].Length > 0)
                        {
                            Day d = new Day(data[i], dataWorker[i]);
                            e.AddToDay(d);
                        }
                    }
                    employeesList.Add(e);
                    
                    idLine++;
                    
                } 
                catch (Exception exception) { 
                    break;
                }
                
            }
            
            return employeesList;
        }
        private static string[] ReadFile(string filename, int line)
        {
            return File.ReadAllLines(filename).Skip(line).First().Split(';');
        }
    }
}
