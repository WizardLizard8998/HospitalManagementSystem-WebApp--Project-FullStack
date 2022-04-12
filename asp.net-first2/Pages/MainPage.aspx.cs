using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace asp.net_first2
{
    public partial class MainPage : System.Web.UI.Page
    {

        User u = new User();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BtnLogin_Click(object sender, EventArgs e)
        {
            // login statements 

            string sCon = "Data Source=DESKTOP-SQQ0GB8;Initial Catalog=HMS;Integrated Security=True;MultipleActiveResultSets=True";



            using (SqlConnection con = new SqlConnection(sCon))
            {
                string Query =
                            "select u.U_Id , u.U_UName,u.U_Passwd , p.User_Id ,p.Title_Id , t.T_Id ,T_Name, (p.P_Name +' ' +p.P_Surname) as ns from Users as u " +
                            "inner join Personal as p on u.U_Id = p.User_Id " +
                            "inner join Title as t on p.Title_Id = t.T_Id " +
                            "where u.U_UName = @UName and u.U_Passwd = @Passwd";

                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataReader data;



                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@UName", TxtUsername.Text);
                    cmd.Parameters.AddWithValue("@Passwd", TxtPassword.Text);

                    data = cmd.ExecuteReader();

                    

                    while (data.Read())
                    {
                        u.username = Convert.ToString(data["U_UName"]);
                        u.password = Convert.ToString(data["U_Passwd"]);
                        u.title = Convert.ToString(data["T_Name"]);
                        u.ns = Convert.ToString(data["ns"]);
                    }

                    Session.Add("Username", u.username);
                    Session.Add("Password", u.password);
                    Session.Add("ns", u.ns);


                    if (TxtUsername.Text == u.username && TxtPassword.Text == u.password)
                    {
                        if(u.title == "Admin")

                        {
                            LblError.Text = "admin page";
                           
                            Server.Transfer("AdminPage.aspx");
                        }
                        if(u.title== "Doctor")
                        {
                            LblError.Text = "Doctor page";
                            Server.Transfer("DoctorPage.aspx");
                        }
                        if(u.title == "Secretary")
                        {
                            LblError.Text = "Secretary";
                            Server.Transfer("SecretaryPage.aspx");
                        }
                        if(u.title ==" " || u.title == null)
                        {
                            LblError.Text = "your account is not ready";
                        }
                        //Response.Redirect("WebForm1.aspx");
                    }
                    if (TxtUsername.Text != u.username || TxtPassword.Text != u.password) { LblError.Text = "username and password are wrong"; }


                }
                catch (Exception ex)
                {
                    LblError.Text = Convert.ToString(ex);
                }
                finally
                {
                    
                    con.Close();
                }
                
                

            }
        }
    }
}