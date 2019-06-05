using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Dist
    {
        public string Autonummer;

        public List<int> Users = new List<int>();

        public Dist(string autonummer, List<int> users)
        {
            Autonummer = autonummer;
            Users = users;
        }
        


        public static List<int> GetUsersForCar(string autonummer)
        {
            List<Dist> distTable = DB.DistTable;
            List<int> passListRes = new List<int>();
            foreach (Dist passList in distTable)
            {
                if (passList.Autonummer == autonummer)
                {
                    passListRes = passList.Users;
                }
            }
            return passListRes;
        }

		//User zu Auto hinzufügen
        public static void AddUserToCar(string autonummer, int user_id)
        {
            List<Dist> distTable = DB.DistTable;
			//Jedes object in Liste wird ausgelesen
            foreach (Dist passList in distTable)
            {
				//Überprüfung der CarID
                //if (passList.Autonummer == autonummer)
                //{
                //    Dist passListTEMP = passList;
                //    passListTEMP.Users.Add(user_id);
                //    //DB.DistTable.ElementAt(autonummer).Users = passListTEMP.Users;
                //    DB.DistTable.IndexOf(autonummer).Users = passListTEMP.Users;
                //}
            }
            
     
        }
    }
}