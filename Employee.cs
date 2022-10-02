using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RejestrCzasuPracy
{
    public class Employee
    {
        public Employee() { }
        public Employee(string id)
        {
            Pracownik = id;
            
        }
        public string Pracownik { get; set; }
       

        
    }
}