using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Dist
    {
        public int Car_ID;

        public List<int> Users = new List<int>();

        public Dist(int id, List<int> users)
        {
            Car_ID = id;
            Users = users;
        }
        


        public static List<int> GetUsersForCar(int car_id)
        {
            List<Dist> distTable = DB.DistTable;
            List<int> passListRes = new List<int>();
            foreach (Dist passList in distTable)
            {
                if (passList.Car_ID == car_id)
                {
                    passListRes = passList.Users;
                }
            }
            return passListRes;
        }

        public static void AddUserToCar(int car_id, int user_id)
        {
            List<Dist> distTable = DB.DistTable;
            foreach (Dist passList in distTable)
            {
                if (passList.Car_ID == car_id)
                {
                    Dist passListTEMP = passList;
                    passListTEMP.Users.Add(user_id);
                    DB.DistTable.ElementAt(car_id).Users = passListTEMP.Users;
                }
            }
            
     
        }
    }
}