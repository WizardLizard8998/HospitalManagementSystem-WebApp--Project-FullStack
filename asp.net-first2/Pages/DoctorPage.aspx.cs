using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using asp.net_first2.Controllers;
using asp.net_first2.models;


namespace asp.net_first2
{
    public partial class DoctorPage : System.Web.UI.Page
    {
        DoctorControls controls = new DoctorControls();

        DataTable dt = new DataTable();


        CUreport cur = new CUreport();

        CheckUp cu = new CheckUp();

        LabReport lr = new LabReport();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["Username"]) == Convert.ToString(""))
            {
                Response.Redirect("MainPage.aspx");
            }


            Label1.Text = "Welcome " + Session["ns"];

            LblCU.Visible = false;
            LblDate.Visible = false;
            LblDrug.Visible = false;
            LblReport.Visible = false;
            LblLab.Visible = false;
            LblAid.Visible = false; 
            LblDisease.Visible = false; 


            TxtCu.Visible = false;
            TxtDate.Visible = false;
            TxtReport.Visible = false;
            TxtDrug.Visible = false;
            BtnSend.Visible = false;
            DDLLab.Visible = false;
            TxtDisease.Visible = false;
            TxtAppointment.Visible = false; 

        }

        protected void BtnCU_Click(object sender, EventArgs e)
        {
            LblWhatUdoin.Text = BtnCU.Text;

            GV.Visible = true;

            dt = controls.GetCheckUp(2);

            GV.DataSource = dt;
            GV.DataBind();

        }


        protected void BtnConsultation_Click(object sender, EventArgs e)
        {
            Server.Transfer("ConsultationPage.aspx");
        }

        protected void BtnAppointment_Click(object sender, EventArgs e)
        {
            LblWhatUdoin.Text = BtnCUR.Text;

            GV.Visible = true;
              
                dt = controls.GetAppointments(2);

                GV.DataSource = dt;
                GV.DataBind();

            


        }

        protected void BtnCUR_Click(object sender, EventArgs e)
        {

            LblWhatUdoin.Text = BtnCUR.Text;

            GV.Visible = true;

            TxtDate.Visible = true;
            TxtReport.Visible = true;
            TxtDrug.Visible = true;
            BtnSend.Visible = true;
            TxtCu.Visible = true;
            DDLLab.Visible = false;
            TxtDisease.Visible = true;
            TxtAppointment.Visible = true;



            LblDate.Visible = true;
            LblDrug.Visible = true;
            LblDrug.Visible = true;
            LblCU.Visible = true;
            LblLab.Visible = false;
            LblDisease.Visible = true; 
            LblAid.Visible = true;

        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {


            if (LblWhatUdoin.Text == BtnCUR.Text)
            {

                cur.cuReport = TxtReport.InnerText;
                cur.date = Convert.ToDateTime(TxtDate.Text).Date;
                cur.DReport = TxtDrug.InnerText;
                cur.cuid = Convert.ToInt32(TxtCu.Text);

                cu.Disease = TxtDisease.InnerHtml;
                cu.date = Convert.ToDateTime(TxtDate.Text).Date;
                cu.appoid = Convert.ToInt32(TxtAppointment.Text);

                controls.InsertCU(cu);
                LblCheck.Text = controls.InsertCheckUpReport(cur); 
            }

            if(LblWhatUdoin.Text == BtnLab.Text)
            {
                lr.Labid = Convert.ToInt32(DDLLab.SelectedValue);
                lr.Report = TxtReport.InnerText;

                LblCheck.Text = controls.InsertLabReport(lr);


            }

        
        }

   

        protected void BtnLab_Click(object sender, EventArgs e)
        {

            LblWhatUdoin.Text = BtnLab.Text;

            GV.Visible = false;
            LblCU.Visible = false;
            LblDate.Visible = false;
            LblDrug.Visible = false;
            LblReport.Visible = true;
            LblAid.Visible = false; 
            LblDisease.Visible = false; 

            TxtReport.Visible = true;
            TxtCu.Visible = false;
            TxtDate.Visible = false;
            TxtDrug.Visible = false;
            BtnSend.Visible = true;
            TxtAppointment.Visible = false; 
            TxtDisease.Visible = false;    


            DDLLab.Visible = true;

            dt = controls.GetLab();

            DDLLab.DataSource = dt;
            DDLLab.DataTextField = "L_Name";
            DDLLab.DataValueField = "L_Id";
            DDLLab.DataBind();

        }

        protected void BtnLbDisplay_Click(object sender, EventArgs e)
        {
            dt = controls.GetLabReport();

            GV.DataSource= dt;
            GV.DataBind();


        }

        protected void BtnDrugDisplay_Click(object sender, EventArgs e)
        {

            LblWhatUdoin.Text = BtnDrugDisplay.Text;

            GV.Visible = true;

            dt = controls.GetDrugReports();

            GV.DataSource = dt;
            GV.DataBind();

            LblCU.Visible = false;
            LblDate.Visible = false;
            LblDrug.Visible = false;
            LblReport.Visible = false;
            LblLab.Visible = false;
            LblDisease.Visible = false;
            LblAid.Visible = false;

            TxtCu.Visible = false;
            TxtDate.Visible = false;
            TxtReport.Visible = false;
            TxtDrug.Visible = false;
            BtnSend.Visible = false;
            DDLLab.Visible = false;
            TxtDisease.Visible = false;
            TxtAppointment.Visible = false;


        }

        protected void BtnDisplayCon_Click(object sender, EventArgs e)
        {
            LblWhatUdoin.Text = BtnDisplayCon.Text;

            GV.Visible = true;

            dt = controls.GetConsultation(1);

            GV.DataSource = dt;
            GV.DataBind();


        }

        protected void BtnSearchCU_Click(object sender, EventArgs e)
        {

        }
    }
}