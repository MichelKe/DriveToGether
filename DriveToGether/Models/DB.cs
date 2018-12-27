using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public static class DB
    {
        public static List<Event> EventTable = new List<Event>() {
            new Event()
            {
                ID = getEventID(), // = 0
                Name = "Fussballspiel Vaduz",
                Details = "Abfahrt um 8:00 Uhr",
                Datum = new DateTime(2018, 12, 19),
                //Datum = DateTime.Now.AddDays(20)
            },

            new Event()
            {
                ID = getEventID(), // = 1
                Name = "Spielplausch St.Gallen",
                Details = "Beginn: 17:00; Ende: 23:00; Bitte Sportsachen mitnehmen, für Verpflegung ist gesorgt",
                Datum = new DateTime(2018, 12, 23)
            },

            new Event()
            {
                ID = getEventID(), // = 2
                Name = "Skitag Savonin",
                Details = "Abfahrt um 6:15 Uhr in St.Gallen; Zurück um etwa 18:15; Skisachen mitbringen!",
                Datum = new DateTime(2019, 1, 12),
                //Datum = DateTime.Now.AddDays(20)
            }

        };

        private static int _EventID = 0;
        public static int getEventID()
        {
            return _EventID++;
        }

        public static List<Car> CarTable = new List<Car>() {
            new Car()
            {
                ID = getCarID(),
                Name = "Auto Meier",
                Fahrer = "Herr Meier",
                Details = "Abfahrt um 8:00 Uhr",
                Plaetze = 5,
                Event_ID = 1
            },

            new Car()
            {
                ID = getCarID(),
                Name = "Auto Kempf",
                Fahrer = "Michel Kempf",
                Details = "Abfahrt um 8:00 Uhr",
                Plaetze = 3,
                Event_ID = 1
            },

            new Car()
            {
                ID = getCarID(),
                Name = "Club-Bus",
                Fahrer = "Der Trainer",
                Details = "Abfahrt um 7:55 Uhr",
                Plaetze = 11,
                Event_ID = 1
            }
        };

        private static int _CarID = 0;
        public static int getCarID()
        {
            return _EventID++;
        }
    }

}
public class tClass
{
    public Event test(int t)
    {
        int ind = DB.EventTable.FindIndex(m => m.ID == t);
        if (ind >= 0) return DB.EventTable[ind];
        return null;
    }

    public Event updateEvent(int id)
    {
 
        return (from md in DB.EventTable where md.ID == id select md).FirstOrDefault(); //auch bekannt als linq (wie SQL)
    }
}