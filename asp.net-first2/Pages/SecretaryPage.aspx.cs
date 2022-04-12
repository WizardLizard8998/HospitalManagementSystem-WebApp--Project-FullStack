using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace asp.net_first2.Pages
{
    public partial class SecretaryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["Username"]) == Convert.ToString(""))
            {
                Response.Redirect("MainPage.aspx");
            }


            Label1.Text = "Welcome " + Session["ns"];
        }

        protected void BtnAppointment_Click(object sender, EventArgs e)
        {
            Server.Transfer("AppointmentPage.aspx");
        }


    }
}