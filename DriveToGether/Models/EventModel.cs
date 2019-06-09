using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
	//Klasse zur Verwaltung von Events
    public class Event
    {
        //Event Attribute
        public string Name;
        public DateTime Datum;
        public string Details;
        public string Ortsname;
        public string PLZ;

        public Event( string name, DateTime datum, string details, string ortsname, string plz)
        {
            Name = name;
            Datum = datum;
            Details = details;
            Ortsname = ortsname;
            PLZ = plz;
        }

        //Generiert Eventliste
		public static List<Event> getEventList()
        {
            return DB.getEventList();
        }

        //Gibt bestimmtes Event aus
        public static List<Event> getEvent(string Name, DateTime Datum)
        {
            return DB.getEvent(Name, Datum);
        }
    } 
}