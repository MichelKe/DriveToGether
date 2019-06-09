using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Verein
    {
        public string Name;
        public DateTime Gruendungsjahr;
        public string Anschrift;
        public string Ortsname;
        public string PLZ;

        public Verein(string name, DateTime gruendungsjahr, string anschrift, string ortsname, string plz)
        {
            Name = name;
            Gruendungsjahr = gruendungsjahr;
            Anschrift = anschrift;
            Ortsname = ortsname;
            PLZ = plz;
        }

        // SQL/FUNKTION MAYBE ?
    }
}