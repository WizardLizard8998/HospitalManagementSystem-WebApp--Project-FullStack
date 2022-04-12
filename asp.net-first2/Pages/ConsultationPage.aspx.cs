using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using asp.net_first2.Controllers;
using asp.net_first2.models;
using System.Data;

namespace asp.net_first2.Pages
{
    public partial class ConsultationPage : System.Web.UI.Page
    {
        AppointmentControls controls = new AppointmentControls();

        Consultation c = new Consultation();



        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["Username"]) == Convert.ToString(""))
            {
                Response.Redirect("MainPage.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dtPoliclinic = controls.GetPoliclinic();
                DDLPoliclinic.DataSource = dtPoliclinic;
                DDLPoliclinic.DataValueField = "PC_Id";
                DDLPoliclinic.DataTextField = "PC_Name";
                DDLPoliclinic.DataBind();


                DataTable dtPersonal = controls.GetPersonel(DDLPoliclinic.SelectedValue);

                DDLDoctor.DataSource = dtPersonal;
                DDLDoctor.DataValueField = "P_Id";
                DDLDoctor.DataTextField = "n";
                DDLDoctor.DataBind();

                var temp = Request.UrlReferrer.ToString();

            }


        }

        protected void DDLPoliclinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtPersonal = controls.GetPersonel(DDLPoliclinic.SelectedValue);

            DDLDoctor.DataSource = dtPersonal;
            DDLDoctor.DataValueField = "P_Id";
            DDLDoctor.DataTextField = "n";
            DDLDoctor.DataBind();

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {


            c.personid = Convert.ToInt32(DDLDoctor.SelectedValue);

            c.Report = Request.Form["TxtReport"];

            c.date = Convert.ToDateTime(TxtDate.Text).Date;

            c.CUR = Convert.ToInt32(TxtCURid.Text);

            LblTest.Text = controls.PostConsulatiton(c);

        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
             Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}