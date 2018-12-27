using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveToGether.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Fahrer { get; set; }
        public string Details { get; set; }
        public int Plaetze { get; set; }
        public int Event_ID { get; set; }
    }

   // public class CarDBContext : DbContext
    //{
    //    public DbSet<Car> Cars { get; set; }
   // }
}