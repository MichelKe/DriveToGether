using DriveToGether.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace DriveToGether.Controllers
{
    public class MitgliedController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //Daten des Mitglieds auslesen
        public static List<Mitglied> getMitglied(Mitglied Mitglied)
        {
            return Mitglied.getMitglied(Mitglied);
        }

        public static List<Mitglied> getMitgliedViaEmail(string email)
        {
            return Mitglied.getMitgliedViaEmail(email);
        }

        //Mitglied hinzufügen
        public static List<Mitglied> addMitglied(Mitglied newMitglied)
        {
            return Mitglied.addMitglied(newMitglied);
        }

        //Mitglied editieren
        public static List<Mitglied> updateMitglied(Mitglied newMitglied)
        {
            return Mitglied.updateMitglied(newMitglied);
        }
    }
}