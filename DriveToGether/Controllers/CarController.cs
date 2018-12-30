using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace DriveToGether.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public static void AddCar(string Name, string Fahrer, string Details, int Plaetze, int EventID)
        {
            Car Auto = new Car(DB.GetCarID(), Name, Fahrer, Details, Plaetze, EventID);
            Auto.AddCar();
        }

        public static List<HtmlGenericControl> GetCarList(int id)
        {
            List<Car> AutoListe = Car.GetCarList(id);
            List<HtmlGenericControl> AutoHTML = new List<HtmlGenericControl>();

            foreach (Car auto in AutoListe)
            {
                List<int> mitfahrer = CarController.GetUsersForCar(auto.ID);
                string mitfahrerString = "";
                foreach (int passagier in mitfahrer)
                {
                    mitfahrerString += passagier.ToString() + " ";
                }

                string htmltxt = "<a runat='server' class='btn btn-default' onServerClick='AddToCar_Click' href='/Views/Event/EventDetails.aspx?id="+id+"'>Einschreiben</a>";
                string htmltxt1 = "<br>";
                HtmlGenericControl htmlelem = new HtmlGenericControl("li");
                htmlelem.InnerHtml = string.Format("{0}, {1}, {2} {3} {4} {5}", auto.Name, auto.Fahrer, (auto.Plaetze - mitfahrer.Count) , htmltxt, htmltxt1, mitfahrerString);

                AutoHTML.Add(htmlelem);
            }

            return AutoHTML;
        }

        public static List<int> GetUsersForCar(int car_id)
        {
            List<int> MitfahrerListe = Dist.GetUsersForCar(car_id);
            return MitfahrerListe; 
        }

        public static void AddUserToCar(int car_id, int user_id)
        {
            Dist.AddUserToCar(car_id, user_id);

        }
    }
}