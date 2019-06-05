using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Car
    {
		//Membervariaben Public ????

        public string Name;
        public string Fahrer_Vorname;
        public string Fahrer_Nachname;
        public string Details;
        public string Autonummer;
        public int Plaetze;
        public int Event_ID;

		//Attribute für Auto
        public Car(string name, string vorname_fahrer, string nachname_fahrer, string details, string autonummer, int plaetze, int event_id)
        {
            Name = name;
            Fahrer_Vorname = vorname_fahrer;
            Fahrer_Nachname = nachname_fahrer;
            Details = details;
            Autonummer = autonummer;
            Plaetze = plaetze;
            Event_ID = event_id;
        }
       
		//Funktion Auto hinzufügen
        public void AddCar()
        {
            DB.CarTable.Add(this);
        }

		//Funktion Auto auslesen
        public static List<Car> GetCarList(int id)
        {
            List<Car> cartable = DB.CarTable;
            List<Car> carReturn = new List<Car>();
			//Für jedes Auto in Liste
            foreach(Car auto in cartable)
            {
				//Überprüfung ob Auto zur Liste gehört
                if(auto.Event_ID == id)
                {
                    carReturn.Add(auto);
                }
            }
            return carReturn;
        }
    }

    //public class AddCarToList
}