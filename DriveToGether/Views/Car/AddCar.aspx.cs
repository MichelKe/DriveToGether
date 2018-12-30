﻿using System;
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
        protected void AddCar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            CarController.AddCar(Fahrzeugname.Text, FahrerName.Text, CarDetails.Text, Convert.ToInt16(Plaetze.Text), id);
            //var user = new Car() { Name = Fahrzeugname.Text, FahrerName = FahrerName.Text, CarDetails = CarDetails.Text, Nachname = Nachname.Text };
            Response.Redirect("/Views/Event/EventDetails.aspx?id="+id);
        }
        protected void RedirectBack_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            Response.Redirect("/Views/Event/EventDetails.aspx?id=" + id);
        }
    }
}