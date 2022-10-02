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
            idCode = id;
            days = new List<Day>();
        }
        public string idCode { get; set; }
        public List<Day> days { get; set; }

        public void AddToDay(Day d)
        {
            this.days.Add(d);
        }
    }
}