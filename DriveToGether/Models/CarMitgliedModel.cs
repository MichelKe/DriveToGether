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
        public string Eventname;
        public DateTime Eventdatum;

        public CarMitglied(string vorname, string nachname, DateTime geburtsdatum, string autonummer, string eventname, DateTime eventdatum)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;
            Autonummer = autonummer;
            Eventname = eventname;
            Eventdatum = eventdatum;
        }

        //Passagierliste laden
        public static List<CarMitglied> getPassangers(string eventName, DateTime eventDate, string autonummer)
        {
            return DB.getPassangersForCar(eventName, eventDate, autonummer);
        }

        //Passagier hizufügen
        public static List<CarMitglied> addPassanger(CarMitglied newPass)
        {
            return DB.addPassengerToCar(newPass);
        }

        //Mitglied von Mitfahrerlist entfernen
        public static List<CarMitglied> removePassanger(CarMitglied removePass)
        {

            return DB.removePassangerFromCar(removePass);

        }

    }
}