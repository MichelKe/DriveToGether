using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Ort
    {
        public string Ortsname;
        public string PLZ;
        public string Land;
        // MITGLIED ?

        public Ort(string ortsname, string plz, string land)
        {
            Ortsname = ortsname;
            PLZ = plz;
            Land = land;
            //Mitglied =? 
        }

        //SQL/FUNKTION hier ?
    }
}