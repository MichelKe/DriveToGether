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

        public int ID;
        public string Name;
        public string Fahrer;
        public string Details;
        public int Plaetze;
        public int Event_ID;

		//Attribute für Auto
        public Car(int id, string name, string fahrer, string details, int plaetze, int event_id)
        {
            ID = id;
            Name = name;
            Fahrer = fahrer;
            Details = details;
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