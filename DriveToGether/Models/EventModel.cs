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
        public int ID;
        public string Name;
        public string Details;
        public DateTime Datum;

		//Event Attribute
        public Event(int id, string name, string details, DateTime datum)
        {
            ID = id;
            Name = name;
            Details = details;
            Datum = datum;
        }

		//Gibt Eventliste zurück
        public static List<Event> GetEventList()
        {
            return DB.EventTable;
        }

		//Gibt Event per ID zurück
        public static Event GetEvent(int id)
        {
            return DB.EventTable.ElementAt(id);
        }
    } 
}