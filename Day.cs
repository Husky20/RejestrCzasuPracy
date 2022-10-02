using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace RejestrCzasuPracy
{
    public class Day
    {
        public Day() {}
    
        public Day(string date, string shift)
        {
            this.Date = date;
            this.Shift = shift;
            setDefinitionWithShift();
        }

        private void setDefinitionWithShift()
        {
            if (this.Shift != null)
            {
                Definition = this.Shift[0] == 'X' ? "Wolny" : "Pracy";
                if (this.Shift[0] != 'X')
                {
                    StartHour = ((this.Shift[0] - '0') * 8) - 2;
                    TimeWork = "8:00";
                }
                else
                {
                    StartHour = null;
                    TimeWork = null;
                }
            }
        }
        
        public string Date { get; set; }
        public string Definition { get; set; }

        public int? StartHour { get; set; }
        public string TimeWork { get; set; }  

        private string Shift { get; set; }
        

    }
    
}