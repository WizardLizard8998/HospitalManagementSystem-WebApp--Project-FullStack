using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using asp.net_first2.Controllers;
using System.Data;
using asp.net_first2.models;


namespace asp.net_first2
{
    public partial class AdminPage : System.Web.UI.Page
    {
        User u = new User();

        AdminControls controls = new AdminControls();


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Convert.ToString( Session["Username"]) == Convert.ToString("")) 
            {
                Response.Redirect("MainPage.aspx");
            }

            LblUser.Text ="Welcome "+ Session["ns"];
            
            
            
            
            
            GridView.AutoGenerateSelectButton = true;

            lblInfo.Text = "You selected " + lblDisplay.Text + " Table and Id is : " + GridView.SelectedIndex;

            


            DataTable dt = controls.getLoggedUser(Convert.ToString(Session["Username"]), Convert.ToString(Session["Password"]));


            if(dt != null)
            {
              //  LblUser.Text = "Welcome " + dt.Rows[0][0] + " " + dt.Rows[0][1];
            }
            else
            {
                LblUser.Text = "Developer Mode";
            }




        }



        protected void BtnPersonal_Click(object sender, EventArgs e)
        {

            DataTable dt = controls.GetPersonal();

            GridView.DataSource = dt;
            GridView.DataBind();

            lblDisplay.Text = "Personal list";
            lblInfo.Text = "You selected " + lblDisplay.Text + " Table and Id is : " + GridView.SelectedIndex;




        }

        protected void BtnPoliclinic_Click(object sender, EventArgs e)
        {


            lblDisplay.Text = "Policlinic list";
            lblInfo.Text = "You selected " + lblDisplay.Text + " Table and Id is : " + GridView.SelectedIndex;




            DataTable dt = controls.GetPoliclinic();

            GridView.DataSource = dt;
            GridView.DataBind();

           


        }

        protected void BtnPatient_Click1(object sender, EventArgs e)
        {


            lblDisplay.Text = "Patient list";
            lblInfo.Text = "You selected " + lblDisplay.Text + " Table and Id is : " + GridView.SelectedIndex;

            DataTable dt = controls.GetPatient();

            GridView.DataSource = dt;
            GridView.DataBind();


        }


        protected void BtnUser_Click(object sender, EventArgs e)
        {


            lblDisplay.Text = "Users list";

            lblInfo.Text = "You selected " + lblDisplay.Text + " Table and Id is : " + GridView.SelectedIndex;

            DataTable dt = controls.getUser();

            GridView.DataSource = dt;
            GridView.DataBind();
            
;
        }



        //grid viewlara göre en baştan güncellenicek 


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedRow != null)
            {
                Session.Add("GVSelectedID", GridView.SelectedRow.Cells[1].Text);

                Server.Transfer("Update.aspx");

            }
            else
            {
                LblError.Text = "Select a Value !!!";
            }

            if (lblDisplay.Text == "Patient list")
            {
                Session.Add("TableName", "Patient");
            }
            if (lblDisplay.Text == "Personal list")
            {
                Session.Add("TableName", "Personal");
            }
            if (lblDisplay.Text == "Policlinic list")
            {
                Session.Add("TableName", "Policlinic");
            }
            if(lblDisplay.Text == "Users list")
            {
                Session.Add("TableName", "Users");
            }
            if (lblDisplay.Text == "")
            {
                lblDisplay.Text = "Please select a Part";
            }
          

            
            
    
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
          
           
            if (lblDisplay.Text == "Patient list")
            {
                Session.Add("TableName", "Patient");
            }
            if (lblDisplay.Text == "Personal list")
            {
                Session.Add("TableName", "Personal");
            }
            if (lblDisplay.Text == "Policlinic list")
            {
                Session.Add("TableName", "Policlinic");
            }
            if(lblDisplay.Text == "Users list")
            {
                Session.Add("TableName", "Users");
            }
            if (lblDisplay.Text == "")
            {
                lblDisplay.Text = "Please select a Part";
            }

            Server.Transfer("InsertNew.aspx");


        }


        // grid viewlara göre en baştan düzenlemen gerekiyor 

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            if (GridView.SelectedRow != null)
            {
                var Data = GridView.SelectedRow.Cells[1].Text;
                LblError.Text = Data;

                if (lblDisplay.Text == "Patient list")
                {
                    LblError.Text = controls.deletePatient(Convert.ToInt32(Data));
                    BtnPatient_Click1(sender, e);
                }
                if (lblDisplay.Text == "Personal list")
                {
                    LblError.Text = controls.deletePersonal(Convert.ToInt32(Data));
                    BtnPersonal_Click(sender, e);
                }
                if (lblDisplay.Text == "Policlinic list")
                {
                    LblError.Text = controls.deletePoliclinic(Convert.ToInt32(Data));
                    BtnPoliclinic_Click(sender, e);
                }
                if (lblDisplay.Text == "Users list")
                {

                    LblError.Text = controls.DeleteUser(Convert.ToInt32(Data));
                    BtnUser_Click(sender, e);
                }

            }
            else
            {
                LblError.Text = "select a value !!!";
            }
            

        }

        
    }
}







    /*
     * 
     * 
     * data will be select from the rows after that taken data must sent to the related place 
     * 
     * 
     * */