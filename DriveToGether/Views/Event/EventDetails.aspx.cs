using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DriveToGether.Controllers;
using Microsoft.AspNet.Identity;

namespace DriveToGether
{
    public partial class EventDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            HtmlGenericControl autoliste = new HtmlGenericControl("ul");
            autoliste = LoadCars(id, autoliste);
            event_details_container.Controls.Add(EventController.GetEvent(id, autoliste));
        }

        protected HtmlGenericControl LoadCars(int id, HtmlGenericControl ul)
        {
            HtmlGenericControl ulelem = ul;
            foreach (HtmlGenericControl hgc in CarController.GetCarList(id))
            { 
                ulelem.Controls.Add(hgc);
            }
            return ulelem;
        }

        protected void AddToCar_Click()
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            string user_id_s = User.Identity.GetUserId();
            int user_id = Convert.ToInt16(user_id_s);

            CarController.AddUserToCar(id, user_id);

            Response.Redirect("/Views/Event/EventDetails.aspx?id=" + id);
        }
    }
}