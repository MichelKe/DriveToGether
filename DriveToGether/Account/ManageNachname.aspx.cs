using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DriveToGether.Account
{
    public partial class ManageNachname : System.Web.UI.Page
    {
        protected void ChangeNachname_Click(object sender, EventArgs e)
        {
            
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var manager1 = Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());

            manager1.Vorname = NewNachname.Text;
              

        }

        public void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if(manager == null)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        //protected void SetPassword_Click(object sender, EventArgs e)
        //{
        //    if (IsValid)
        //    {
        //        // Lokale Anmeldeinformationen erstellen und das lokale Konto mit dem Benutzer verknüpfen
        //        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        IdentityResult result = manager.AddPassword(User.Identity.GetUserId(), password.Text);
        //        if (result.Succeeded)
        //        {
        //            Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
        //        }
                
        //    }
        //}
    }
}