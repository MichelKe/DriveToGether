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
    public partial class Register : Page
    {
		//Erstellt neuen User in der Webapplikation beim Klicken des Registrieren Buttons
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { Email = Email.Text, Vorname = Vorname.Text, Nachname = Nachname.Text, UserName = Email.Text};
            //var result = await UserManager.CreateAsync(user, Password.Text);
            //Neuer User wird in der DB erstellt
            //Mitglied newMitglied = new Mitglied(Vorname.Text, Nachname.Text, Geburtstag.Text, Email.Text, Anschrift.Text, Ortsname.Text, PLZ.Text, "User");
            //MitgliedController.addMitglied(newMitglied);
			IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Weitere Informationen zum Aktivieren der Kontobestätigung und Kennwortzurücksetzung finden Sie unter https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Konto bestätigen", "Bitte bestätigen Sie Ihr Konto. Klicken Sie dazu <a href=\"" + callbackUrl + "\">hier</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                //ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}