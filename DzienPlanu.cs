using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace RejestrCzasuPracy
{
    public class DzienPlanu
    {
        public DzienPlanu() {}
    
        public DzienPlanu(string data, string zmiana, string idPracownika)
        {
            this.Pracownik = idPracownika;
            this.Data = data;
            this.Zmiana = zmiana;
            setDefinitionWithShift();
        }
        public string Pracownik { get; set; }
        public string Data { get; set; }
        public string Definicja { get; set; }
        public int? OdGodziny { get; set; }
        public string Czas { get; set; }  

        private string Zmiana { get; set; }
        
        private void setDefinitionWithShift()
        {
            if (this.Zmiana != null)
            {
                Definicja = this.Zmiana[0] == 'X' ? "Wolny" : "Pracy";
                if (this.Zmiana[0] != 'X')
                {
                    OdGodziny = (((this.Zmiana[0] - '0') * 8) - 2);
                    Czas = "8:00";
                }
                else
                {
                    OdGodziny = null;
                    Czas = null;
                }
            }
        }
        
        
        

    }
    
}