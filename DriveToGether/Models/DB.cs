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
            new Event(GetEventID(), "Fussballspiel Vaduz", "Abfahrt um 8:00 Uhr", new DateTime(2018, 12, 19)),
            new Event(GetEventID(), "Fussballspiel Bern", "Abfahrt um 12:00 Uhr", new DateTime(2019, 1, 19)),
            new Event(GetEventID(), "Fussballspiel Thailand", "Abfahrt um 5:00 Uhr", new DateTime(2019, 1, 9))
        };

        private static int _EventID = 0;
        public static int GetEventID()
        {
            return _EventID++;
        }

        public static List<Car> CarTable = new List<Car>() {
            new Car(GetCarID(), "Auto Hansdotter", "Herr Hansdotter", "Abfahrt um 8:00 Uhr", 5, 0),
            new Car(GetCarID(), "Auto q", "Herr q", "Abfahrt b 8:00 Uhr", 5, 0),
            new Car(GetCarID(), "Auto w", "Herr w", "Abfahrt v 8:00 Uhr", 5, 0),
            new Car(GetCarID(), "Auto Meier", "Herr Meier", "Abfahrt um 8:00 Uhr", 5, 1),
            new Car(GetCarID(), "Auto a", "Herr a", "Abfahrt b 8:00 Uhr", 5, 1),
            new Car(GetCarID(), "Auto b", "Herr b", "Abfahrt v 8:00 Uhr", 5, 1),
            new Car(GetCarID(), "Auto Klaus", "Herr klaus", "Abfahrt um 8:00 Uhr", 5, 2),
            new Car(GetCarID(), "Auto x", "Herr x", "Abfahrt b 8:00 Uhr", 5, 2),
            new Car(GetCarID(), "Auto y", "Herr y", "Abfahrt v 8:00 Uhr", 5, 2)
            
        };

        private static int _CarID = 0;
        public static int GetCarID()
        {
            return _CarID++;
        }

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