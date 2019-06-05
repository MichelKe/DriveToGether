using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
	//Listklasse 
    public static class DB
    {
		//Beispieldaten
        public static List<Event> EventTable = new List<Event>() {
            new Event(GetEventID(), "Fussballspiel Vaduz", "Abfahrt um 8:00 Uhr", new DateTime(2018, 12, 19)),
            new Event(GetEventID(), "Fussballspiel Bern", "Abfahrt um 12:00 Uhr", new DateTime(2019, 1, 19)),
            new Event(GetEventID(), "Fussballspiel Thailand", "Abfahrt um 5:00 Uhr", new DateTime(2019, 1, 9))
        };

        private static int _EventID = 0;

		//Event auslesen
		public static int GetEventID()
        {
            return _EventID++;
        }

		//Beispieldaten
        public static List<Car> CarTable = new List<Car>() {
            new Car("Auto Hansdotter", "Peter", "Hansdotter", "Abfahrt um 8:00 Uhr", "SG123", 5, 0),
            new Car("Auto Meier", "Franz", "Meier", "Abfahrt um 8:00 Uhr", "SG223", 5, 0),
            new Car("Auto 3", "13", "23", "Abfahrt um 8:00 Uhr", "SG3", 5, 0),
            new Car("Auto 4", "14", "24", "Abfahrt um 8:00 Uhr", "SG4", 5, 0),
            new Car("Auto 5", "15", "25", "Abfahrt um 8:00 Uhr", "SG5", 5, 0),
            new Car("Auto 6", "16", "26", "Abfahrt um 8:00 Uhr", "SG6", 5, 0),
            new Car("Auto 7", "17", "27", "Abfahrt um 8:00 Uhr", "SG7", 5, 0),
            new Car("Auto 8", "18", "28", "Abfahrt um 8:00 Uhr", "SG8", 5, 0),
            new Car("Auto 9", "19", "29", "Abfahrt um 8:00 Uhr", "SG9", 5, 0)          
        };

  //      private static int _CarID = 0;
		////Rückgabe CarID
		//public static int GetCarID()
  //      {
  //          return Autonummer;
  //      }

        public static List<Dist> DistTable = new List<Dist>()
        {
            //new Dist(2, List<1,2>);
        };
    }

}
//public class tClass
//{
//    public Event test(int t)
//    {
//        int ind = DB.EventTable.FindIndex(m => m.ID == t);
//        if (ind >= 0) return DB.EventTable[ind];
//        return null;
//    }

//    public Event updateEvent(int id)
//    {
 
//        return (from md in DB.EventTable where md.ID == id select md).FirstOrDefault(); //auch bekannt als linq (wie SQL)
//    }
//}