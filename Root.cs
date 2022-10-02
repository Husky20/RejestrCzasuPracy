using System.Collections.Generic;

namespace RejestrCzasuPracy
{
    public class Root
    {
        public Root()
        {
            DniPlanu = new List<DzienPlanu>();
        }
        
        public List<DzienPlanu> DniPlanu { get; set; }
        
        public void AddToDay(DzienPlanu d)
        {
            this.DniPlanu.Add(d);
        }
    }
}