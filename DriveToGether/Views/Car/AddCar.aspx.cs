using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DriveToGether.Models;
using DriveToGether.Controllers;

namespace DriveToGether.Account
{
    public partial class addCar : Page
    {
		//Funktion beim Klicken de hinzufügen Buttons
        protected void AddCar_Click(object sender, EventArgs e)
        {
			//ID wird konvertiert
            int id = Convert.ToInt16(Request.QueryString["id"]);
			//Auto wird in Liste in CarController hinzugefügt
            CarController.AddCar(Fahrzeugname.Text, FahrerVorname.Text, FahrerNachname.Text, CarDetails.Text, Autonummer.Text, Convert.ToInt16(Plaetze.Text), id);
			//var user = new Car() { Name = Fahrzeugname.Text, FahrerName = FahrerName.Text, CarDetails = CarDetails.Text, Nachname = Nachname.Text };

			//Seite des entsprechenden Events wird aufgerufen
			Response.Redirect("/Views/Event/EventDetails.aspx?id="+id);
        }
		//Beim Abbrechen wird diese Funktion aufgerufen
        protected void RedirectBack_Click(object sender, EventArgs e)
        {	
			//ID wird konvertiert
            int id = Convert.ToInt16(Request.QueryString["id"]);
			//Seite des entsprechenden Events wird aufgerufen
			Response.Redirect("/Views/Event/EventDetails.aspx?id=" + id);
        }
    }
}