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


namespace asp.net_first2.Pages
{
    public partial class Update : System.Web.UI.Page
    {
        Patient ptt = new Patient();

        Personal p = new Personal();

        User u = new User();

        Policlinic pc = new Policlinic();

        DataTable dtPatient = new DataTable();

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





                TxtName.Enabled = false;
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

            if (Label1.Text == "Personal")
                {
                //Convert.ToInt32(Session["GVSelectedId"])
                

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

                //Convert.ToInt32(Session["GVSelectedId"])

                DataTable dtPersonal = controls.GetPersonalById(Convert.ToInt32(Session["GVSelectedId"]));

                p.name= Convert.ToString(dtPersonal.Rows[0][2]);
                p.surname= Convert.ToString(dtPersonal.Rows[0][3]);
                p.telnum= Convert.ToString(dtPersonal.Rows[0][6]);
                p.adress= Convert.ToString(dtPersonal.Rows[0][7]);
                p.bloodid= Convert.ToInt32(dtPersonal.Rows[0][12]);
                p.Sex= Convert.ToInt32(dtPersonal.Rows[0][8]);
                p.Tc= Convert.ToString(dtPersonal.Rows[0][1]);
                p.d_Id= Convert.ToInt32(dtPersonal.Rows[0][13]);
                p.Birthdate= Convert.ToDateTime(dtPersonal.Rows[0][11]).Date;
                p.Title_Id= Convert.ToInt32(dtPersonal.Rows[0][14]);
                p.poli_id= Convert.ToInt32(dtPersonal.Rows[0][15]);
                p.user_Id= Convert.ToInt32(dtPersonal.Rows[0][16]);
                //p.= Convert.ToString(dtPersonal.Rows[0][]);






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

                //Convert.ToInt32(Session["GVSelectedId"])

                LblCheck.Text = Convert.ToString(Session["GVSelectedId"]);


                DataTable dtPatient = controls.GetPatientById(Convert.ToInt32(Session["GVSelectedId"]));



                ptt.name= Convert.ToString(dtPatient.Rows[0][2]);
                ptt.surname= Convert.ToString(dtPatient.Rows[0][3]);
                ptt.telnum= Convert.ToString(dtPatient.Rows[0][6]);
                ptt.adress= Convert.ToString(dtPatient.Rows[0][9]);
                ptt.bloodid= Convert.ToInt32(dtPatient.Rows[0][11]);
                ptt.sex = Convert.ToInt32(dtPatient.Rows[0][4]);
                ptt.tc = Convert.ToString(dtPatient.Rows[0][1]);
                ptt.district = Convert.ToInt32(dtPatient.Rows[0][12]);
                ptt.birthdate = Convert.ToDateTime(dtPatient.Rows[0][10]);

               // TxtName.Text = Convert.ToString(dtPatient.Rows[0][2]);
               // TxtSurname.Text = Convert.ToString(dtPatient.Rows[0][3]);
               // TxtTelNum.Text = Convert.ToString(dtPatient.Rows[0][6]);
               // TxtAdress.Text = Convert.ToString(dtPatient.Rows[0][9]);
               // DDLBlood.Items.FindByValue( Convert.ToString(dtPatient.Rows[0][5]));
               // TxtSex.Text = Convert.ToString(dtPatient.Rows[0][4]);
               // TxtTc.Text = Convert.ToString(dtPatient.Rows[0][1]);
                //TxtBirthDate.Text = Convert.ToString( Convert.ToDateTime(dtPatient.Rows[0][10]).Date);
               // DDLDistrict.Items.FindByValue(Convert.ToString(dtPatient.Rows[0][7]));
               // DDLCity.Items.FindByValue(Convert.ToString(dtPatient.Rows[0][8]));





                }
                if (Label1.Text == "Policlinic")
                {

                DataTable dtPoli = controls.GetPoliclinicById(Convert.ToInt32(Session["GVSelectedId"]));

                pc.name = Convert.ToString(dtPoli.Rows[0][1]);


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

                    CBName.Enabled = true;
                    CBSurname.Enabled = false;
                    CBAdress.Enabled = false;
                    CBBirthdate.Enabled = false;
                    CBBlood.Enabled = false;
                    CBCity.Enabled = false;
                    CBDistrict.Enabled = false;
                    CBPoliclinic.Enabled = false;
                    CBSex.Enabled = false;
                    CBTc.Enabled = false;
                    CBTelNum.Enabled = false;
                    CBTitle.Enabled = false;






                }
                if(Label1.Text == "Users")
                {

                //Convert.ToInt32(Session["GVSelectedId"])
                DataTable dtUsers = controls.GetUsersById(Convert.ToInt32(Session["GVSelectedId"]));
                LblCheck.Text = Convert.ToString(Session["GVSelectedId"]);

                u.username = Convert.ToString(dtUsers.Rows[0][1]);
                u.password= Convert.ToString(dtUsers.Rows[0][2]);

                LblName.Text = "Username";
                LblSurname.Text = "Password";

                CBName.Enabled = true;
                CBSurname.Enabled = true;
                CBAdress.Enabled = false;
                CBBirthdate.Enabled = false;
                CBBlood.Enabled = false;
                CBCity.Enabled = false;
                CBDistrict.Enabled = false;
                CBPoliclinic.Enabled = false;
                CBSex.Enabled = false;
                CBTc.Enabled = false;
                CBTelNum.Enabled = false;
                CBTitle.Enabled = false;
                CBUser.Enabled = true; 


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


                }
            





        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {


            AdminControls controls = new AdminControls();


            if (Label1.Text == "Personal")
            {
                

                if (CBBlood.Checked) { p.bloodid = Convert.ToInt32(DDLBlood.SelectedValue); }
                //else { ptt.bloodid = Convert.ToInt32(dtPatient.Rows[0][11]); }

                if (CBDistrict.Checked) { p.d_Id = Convert.ToInt32(DDLDistrict.SelectedValue); }
                // else { ptt.district = Convert.ToInt32(dtPatient.Rows[0][12]); }

                if (CBBirthdate.Checked) { p.Birthdate = Convert.ToDateTime(TxtBirthDate.Text).Date; }// else { ptt.birthdate = Convert.ToDateTime(dtPatient.Rows[0][10]).Date; }

                if (CBName.Checked) { p.name = Convert.ToString(TxtName.Text); } // else { ptt.name = Convert.ToString(dtPatient.Rows[0][2]); }
                if (CBSurname.Checked) { p.surname = Convert.ToString(TxtSurname.Text); }// else { ptt.surname = Convert.ToString(dtPatient.Rows[0][3]); }
                if (CBTelNum.Checked) { p.telnum = Convert.ToString(TxtTelNum.Text); } //else { ptt.telnum = Convert.ToString(dtPatient.Rows[0][6]); }
                if (CBAdress.Checked) { p.adress = Convert.ToString(TxtAdress.Text); } // else { ptt.adress = Convert.ToString(dtPatient.Rows[0][9]); }
                if (CBSex.Checked) { p.Sex = Convert.ToInt32(TxtSex.Text); }//  else { ptt.sex = Convert.ToInt32(dtPatient.Rows[0][4]); }
                if (CBTc.Checked) { p.Tc = Convert.ToString(TxtTc.Text); } // else { ptt.tc = Convert.ToString(dtPatient.Rows[0][1]); }
                if (CBTitle.Checked) { p.Title_Id = Convert.ToInt32(DDLTitle.SelectedValue); } // else { ptt.tc = Convert.ToString(dtPatient.Rows[0][1]); }
                if (CBPoliclinic.Checked) { p.poli_id = Convert.ToInt32(DDLPoliclinic.SelectedValue); } // else { ptt.tc = Convert.ToString(dtPatient.Rows[0][1]); }
                if (CBUser.Checked) { p.user_Id = Convert.ToInt32(TxtUserId.Text); } // else { ptt.tc = Convert.ToString(dtPatient.Rows[0][1]); }




                string send = controls.UpdatePersonal(p, Convert.ToInt32(Session["GVSelectedId"]));
                LblSend.Text = Convert.ToString(send);




            }
            if (Label1.Text == "Patient")
            {
              

                    if (CBBlood.Checked) { ptt.bloodid = Convert.ToInt32(DDLBlood.SelectedValue); }
                    //else { ptt.bloodid = Convert.ToInt32(dtPatient.Rows[0][11]); }

                    if (CBDistrict.Checked) { ptt.district = Convert.ToInt32(DDLDistrict.SelectedValue); }
                   // else { ptt.district = Convert.ToInt32(dtPatient.Rows[0][12]); }

                    if (CBBirthdate.Checked) { ptt.birthdate = Convert.ToDateTime(TxtBirthDate.Text).Date; }// else { ptt.birthdate = Convert.ToDateTime(dtPatient.Rows[0][10]).Date; }

                    if (CBName.Checked ) { ptt.name = Convert.ToString(TxtName.Text); } // else { ptt.name = Convert.ToString(dtPatient.Rows[0][2]); }
                    if (CBSurname.Checked ) { ptt.surname = Convert.ToString(TxtSurname.Text); }// else { ptt.surname = Convert.ToString(dtPatient.Rows[0][3]); }
                    if (CBTelNum.Checked ) { ptt.telnum = Convert.ToString(TxtTelNum.Text); } //else { ptt.telnum = Convert.ToString(dtPatient.Rows[0][6]); }
                    if (CBAdress.Checked ) { ptt.adress = Convert.ToString(TxtAdress.Text); } // else { ptt.adress = Convert.ToString(dtPatient.Rows[0][9]); }
                    if (CBSex.Checked ) { ptt.sex = Convert.ToInt32(TxtSex.Text); }//  else { ptt.sex = Convert.ToInt32(dtPatient.Rows[0][4]); }
                    if (CBTc.Checked ) { ptt.tc = Convert.ToString(LblTC.Text); } // else { ptt.tc = Convert.ToString(dtPatient.Rows[0][1]); }

                string send = controls.UpdatePatient(ptt, Convert.ToInt32(Session["GVSelectedId"]));
                    LblSend.Text = Convert.ToString(send);

                
                



            }
            if (Label1.Text == "Policlinic")
            {
                if(CBName.Checked) { pc.name = TxtName.Text;  }

                LblSend.Text = controls.UpdatePoliclinic(pc.name, Convert.ToInt32(Session["GVSelectedId"]));
            }

            if (Label1.Text =="Users")
            {
                if(CBName.Checked) { u.username = Convert.ToString(TxtName.Text); }
                if(CBName.Checked) { u.password = Convert.ToString(TxtSurname.Text); }

                LblSend.Text = controls.UpdateUser(u, 2);


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

        protected void CBName_CheckedChanged(object sender, EventArgs e)
        {
            if(CBName.Checked == true) { TxtName.Enabled = true;}
            if(CBName.Checked == false) { TxtName.Enabled = false;}


            //if (CBName.Checked == true) { ptt.name = Convert.ToString(TxtName.Text); } else { ptt.name = Convert.ToString(dtPatient.Rows[0][2]); }

        }

        protected void CBSurname_CheckedChanged(object sender, EventArgs e)
        {
            if (CBSurname.Checked == true) { TxtSurname.Enabled = true; }
            if (CBSurname.Checked == false) { TxtSurname.Enabled = false; }
        }

        protected void CBTelNum_CheckedChanged(object sender, EventArgs e)
        {
            if (CBTelNum.Checked == true) { TxtTelNum.Enabled = true; }
            if (CBTelNum.Checked == false) { TxtTelNum.Enabled = false; }
        }

        protected void CBAdress_CheckedChanged(object sender, EventArgs e)
        {
            if (CBAdress.Checked == true) { TxtAdress.Enabled = true; }
            if (CBAdress.Checked == false) { TxtAdress.Enabled = false; }
        }

        protected void CBBlood_CheckedChanged(object sender, EventArgs e)
        {
            if (CBBlood.Checked == true) { DDLBlood.Enabled = true; }
            if (CBBlood.Checked == false) { DDLBlood.Enabled = false; }
        }

        protected void CBTc_CheckedChanged(object sender, EventArgs e)
        {
            if (CBTc.Checked == true) { TxtTc.Enabled = true; }
            if (CBTc.Checked == false) { TxtTc.Enabled = false; }
        }

        protected void CBSex_CheckedChanged(object sender, EventArgs e)
        {
            if (CBSex.Checked == true) { TxtSex.Enabled = true; }
            if (CBSex.Checked == false) { TxtSex.Enabled = false; }
        }

        protected void CBBirthdate_CheckedChanged(object sender, EventArgs e)
        {
            if (CBBirthdate.Checked == true) { TxtBirthDate.Enabled = true; }
            if (CBBirthdate.Checked == false) { TxtBirthDate.Enabled = false; }
        }

        protected void CBCity_CheckedChanged(object sender, EventArgs e)
        {
            if (CBCity.Checked == true) { DDLCity.Enabled = true; }
            if (CBCity.Checked == false) { DDLCity.Enabled = false; }
        }

        protected void CBDistrict_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDistrict.Checked == true) { DDLDistrict.Enabled = true; }
            if (CBDistrict.Checked == false) { DDLDistrict.Enabled = false; }
        }

        protected void CBTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (CBTitle.Checked == true) { DDLTitle.Enabled = true; }
            if (CBTitle.Checked == false) { DDLTitle.Enabled = false; }
        }

        protected void CBPoliclinic_CheckedChanged(object sender, EventArgs e)
        {
            if (CBPoliclinic.Checked == true) { DDLPoliclinic.Enabled = true; }
            if (CBPoliclinic.Checked == false) { DDLPoliclinic.Enabled = false; }
        }

        protected void CBUser_CheckedChanged(object sender, EventArgs e)
        {
            if (CBUser.Checked == true) { TxtUserId.Enabled = true; }
            if (CBUser.Checked == false) { TxtUserId.Enabled = false; }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }

    }
}