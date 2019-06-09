using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Car
    {
		//Membervariaben
        public string Autonummer;
        public string Name;
        public int Plaetze;
        public string Details;
        public string Fahrer_Vorname;
        public string Fahrer_Nachname;
        public string Event_Name;
        public DateTime Event_Datum;
        

        //Auto Konstruktor
        public Car(string autonummer, string name, int plaetze, string details, string vorname_fahrer, string nachname_fahrer, string event_name, DateTime event_datum)
        {
            Autonummer = autonummer;
            Name = name;
            Plaetze = plaetze;
            Details = details;
            Fahrer_Vorname = vorname_fahrer;
            Fahrer_Nachname = nachname_fahrer;
            Event_Name = event_name;
            Event_Datum = event_datum;
        }

        
        //Funktion Autoliste für Event
        public static List<Car> getCarList(string eventName, DateTime eventDate)
        {
            return DB.getEventCarList(eventName, eventDate);
        }

        //Ausgewähltes Auto laden
        public static List<Car> selectCar(string eventName, DateTime eventDate, string autonummer)
        {
            return DB.selectCar(eventName, eventDate, autonummer);
        }

        //Auto hinzufügen
        public static List<Car> addCar(Car newCar)
        {
            return DB.insertCar(newCar);
        }

        //Auto bearbeiten
        public static List<Car> modifyCar(Car newCar)
        {
            return DB.updateCar(newCar);
        }

        //Auto löschen
        public static List<Car> deleteCar(string eventName, DateTime eventDate, string autonummer)
        {
            return DB.deleteCar(eventName, eventDate, autonummer);
        }
    }
}