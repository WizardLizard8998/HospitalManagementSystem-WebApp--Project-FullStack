using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using asp.net_first2.Controllers;
using asp.net_first2.models;


namespace asp.net_first2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public User U = new User();

       AppointmentControls controls = new AppointmentControls();

        Appointment ap = new Appointment();


  
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["Username"]) == Convert.ToString(""))
            {
                Response.Redirect("MainPage.aspx");
            }

            Label1.Text = Convert.ToString("Consultation");



            if (!Page.IsPostBack)
            {
                DataTable dtPatient = controls.GetPatientDDL();



                DDLPatient.DataSource = dtPatient;
                DDLPatient.DataValueField = "Ptt_Id";
                DDLPatient.DataTextField = "d";
                DDLPatient.DataBind();


                //  DataTable dtDoctor = controls.GetPersonel();

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

            }
        }

 

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {




            ap.P_Id = DDLDoctor.SelectedValue;
            ap.Ptt_Id = DDLPatient.SelectedValue;
            ap.date = Convert.ToDateTime(TxtDate.Text).Date;
            ap.time = Convert.ToDateTime(TxtTime.Text);

            

            LblTest.Text = controls.PostAppointment(ap);


        }


        protected void BtnPatient_Click(object sender, EventArgs e)
        {
            Session.Add("TableName", "Patient");
            Server.Transfer("InsertNew.aspx");
        }

        protected void DDLPoliclinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtPersonal = controls.GetPersonel(DDLPoliclinic.SelectedValue);

            DDLDoctor.DataSource = dtPersonal;
            DDLDoctor.DataValueField = "P_Id";
            DDLDoctor.DataTextField = "n";
            DDLDoctor.DataBind();
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("SecretaryPage.aspx");
        }

    }
}