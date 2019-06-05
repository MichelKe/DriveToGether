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
        // ORT HINZUFÜGEN ??

        public Verein(string name, DateTime gruendungsjahr)
        {
            Name = name;
            Gruendungsjahr = gruendungsjahr;
            // ORT ??
        }

        // SQL/FUNKTION MAYBE ?
    }
}