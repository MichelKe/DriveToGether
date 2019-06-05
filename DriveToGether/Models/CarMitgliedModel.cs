using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class CarMitglied
    {
        public string Vorname;
        public string Nachname;
        public DateTime Geburtsdatum;
        public string Autonummer;

        public CarMitglied(string vorname, string nachname, DateTime geburtsdatum, string autonummer)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;
            Autonummer = autonummer;
        }

        // SQL/FUNKTION ZUM EINFÜGEN in db HIER

    }
}