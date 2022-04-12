using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using asp.net_first2.models;
using asp.net_first2.Controllers;
using System.Data;

namespace asp.net_first2
{
    public partial class InsertNew : System.Web.UI.Page
    {

        Patient ptt = new Patient();

        Personal p = new Personal();

        User u = new User();

        AdminControls controls = new AdminControls();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Username"]) == Convert.ToString(""))
            {
                Response.Redirect("MainPage.aspx");
            }



            if (!Page.IsPostBack)
            {
                Label1.Text = Convert.ToString(Session["TableName"]);

                DataTable dtCity = controls.GetCity();

                DDLCity.DataSource = dtCity;
                DDLCity.DataValueField = "C_Id";
                DDLCity.DataTextField = "C_Name";
                DDLCity.DataBind();

                DDLDistrict.Enabled = false;


                DataTable dtTitle = controls.GetTitle();

                DDLTitle.DataSource = dtTitle;
                DDLTitle.DataValueField = "T_Id";
                DDLTitle.DataTextField = "T_Name";
                DDLTitle.DataBind();


                DataTable dtBlood = controls.GetBlood();

                DDLBlood.DataSource = dtBlood;
                DDLBlood.DataValueField = "B_Id";
                DDLBlood.DataTextField = "B_Group";
                DDLBlood.DataBind();


                DataTable dtPoliclinic = controls.GetPoliclinic();

                DDLPoliclinic.DataSource = dtPoliclinic;
                DDLPoliclinic.DataValueField = "PC_Id";
                DDLPoliclinic.DataTextField = "PC_Name";
                DDLPoliclinic.DataBind();




                if (Label1.Text == "Personal")
                {
                    LblName.Text = "Name";

                    LblSurname.Text = "Surname";

                    LblTelNum.Text = "Telephone Number";

                    LblAdress.Text = "Adress";

                    LblBlood.Text = "blood "; // blood id girilmesi lazım

                    LblTC.Text = "TC"; // Cinsiyet id girilmesi lazım

                    LblSex.Text = "Sex (1 male 0 female)";

                    LblBirthDate.Text = "Birthdate (dd/mm/yyyy)";

                    LblCity.Text = "City"; // user id atanması gereken yer

                    LblDistrict.Text = "District"; // city

                    LblTitle.Text = "Title"; // policlinicleri getir

                    LblPoliclinic.Text = "Policlinic";

                    LblUserId.Text = "User ID";


                }
                if (Label1.Text == "Patient")
                {

                    LblName.Text = "Name";


                    LblSurname.Text = "Surname";


                    LblTelNum.Text = "Telephone Number";


                    LblAdress.Text = "Adress";


                    LblBlood.Text = "blood "; // blood id girilmesi lazım


                    LblTC.Text = "TC"; // Cinsiyet id girilmesi lazım


                    LblSex.Text = "Sex (1 male 0 female)";


                    LblBirthDate.Text = "Birthdate (dd/mm/yyyy)";


                    LblCity.Text = "City"; // user id atanması gereken yer


                    LblDistrict.Text = "District"; // city


                    LblTitle.Text = "Disabled";
                    LblPoliclinic.Text = "Disabled";
                    LblUserId.Text = "Disabled";


                    DDLTitle.Enabled = false;
                    DDLPoliclinic.Enabled = false;
                    TxtUserId.Enabled = false;




                }
                if (Label1.Text == "Policlinic")
                {

                    LblName.Text = "Policlinic Name";

                    LblSurname.Text = "Disabled";
                    LblTelNum.Text = "Disabled";
                    LblAdress.Text = "Disabled";
                    LblBlood.Text = "Disabled";
                    LblSex.Text = "Disabled";
                    LblTC.Text = "Disabled";
                    LblBirthDate.Text = "Disabled";
                    LblUserId.Text = "Disabled";
                    LblPoliclinic.Text = "Disabled";
                    LblTitle.Text = "Disabled";
                    LblCity.Text = "Disabled";
                    LblDistrict.Text = "Disabled";


                    TxtName.Enabled = true;
                    TxtSurname.Enabled = false;
                    TxtTelNum.Enabled = false;
                    TxtAdress.Enabled = false;
                    DDLBlood.Enabled = false;
                    TxtSex.Enabled = false;
                    TxtTc.Enabled = false;
                    TxtBirthDate.Enabled = false;
                    TxtUserId.Enabled = false;
                    DDLPoliclinic.Enabled = false;
                    DDLTitle.Enabled = false;
                    DDLCity.Enabled = false;
                    DDLDistrict.Enabled = false;






                } 
                if(Label1.Text == "Users")
                {
                    LblName.Text = "UserName";

                    LblSurname.Text = "Password";
                    LblTelNum.Text = "Disabled";
                    LblAdress.Text = "Disabled";
                    LblBlood.Text = "Disabled";
                    LblSex.Text = "Disabled";
                    LblTC.Text = "Disabled";
                    LblBirthDate.Text = "Disabled";
                    LblUserId.Text = "Disabled";
                    LblPoliclinic.Text = "Disabled";
                    LblTitle.Text = "Disabled";
                    LblCity.Text = "Disabled";
                    LblDistrict.Text = "Disabled";


                    TxtName.Enabled = true;
                    TxtSurname.Enabled = true;
                    TxtTelNum.Enabled = false;
                    TxtAdress.Enabled = false;
                    DDLBlood.Enabled = false;
                    TxtSex.Enabled = false;
                    TxtTc.Enabled = false;
                    TxtBirthDate.Enabled = false;
                    TxtUserId.Enabled = false;
                    DDLPoliclinic.Enabled = false;
                    DDLTitle.Enabled = false;
                    DDLCity.Enabled = false;
                    DDLDistrict.Enabled = false;
                }


            }





        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {




            if(Label1.Text == "Personal")
            {
                p.name = TxtName.Text;
                p.surname = TxtSurname.Text;
                p.telnum = TxtTelNum.Text;
                p.adress= TxtAdress.Text;
                p.bloodid =Convert.ToInt32( DDLBlood.SelectedValue);
                p.Sex = Convert.ToInt32(TxtSex.Text);
                p.Tc = TxtTc.Text;
                p.Birthdate = Convert.ToDateTime(TxtBirthDate.Text);
                p.user_Id = Convert.ToInt32(TxtUserId.Text);
                
                p.poli_id=Convert.ToInt32( DDLPoliclinic.SelectedValue);
                p.Title_Id = Convert.ToInt32(DDLTitle.SelectedValue);
                
                p.d_Id= Convert.ToInt32(DDLDistrict.SelectedValue);
                

                LblSend.Text = controls.InsertPersonal(p);
            }
            if (Label1.Text == "Patient")
            {
                ptt.name = TxtName.Text;
                ptt.surname = TxtSurname.Text;
                ptt.telnum = TxtTelNum.Text;
                ptt.adress = TxtAdress.Text;
                ptt.bloodid = Convert.ToInt32(DDLBlood.SelectedValue);
                ptt.sex = Convert.ToInt32(TxtSex.Text);
                ptt.tc = TxtTc.Text;
                ptt.birthdate = Convert.ToDateTime(TxtBirthDate.Text);
                ptt.district = Convert.ToInt32(DDLDistrict.SelectedValue);


                LblSend.Text = controls.InsertPatient(ptt);
            }
            if (Label1.Text == "Policlinic")
            {
                
             LblSend.Text= controls.InsertPoliclinic(TxtName.Text);
            }
            if (Label1.Text == "Users")
            {
                u.username = TxtName.Text;
                u.password= TxtSurname.Text;
                
                LblSend.Text = controls.InsertUser(u);
            }

        }

        protected void DDLCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLDistrict.Enabled = true;
           

            DataTable dt = controls.GetDistrict(Convert.ToInt32(DDLCity.SelectedValue));

            DDLDistrict.DataSource = dt;
            DDLDistrict.DataValueField = "d_Id";
            DDLDistrict.DataTextField = "d_Name";
            DDLDistrict.DataBind();

        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("AdminPage.aspx");
        }

    }
}