using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using asp.net_first2.models;



namespace asp.net_first2.Controllers
{
    public class AppointmentControls
    {

        public string sCon = "Data Source=DESKTOP-SQQ0GB8;Initial Catalog=HMS;Integrated Security=True;MultipleActiveResultSets=True";



        //eğer hasta bulunamamışsa hastayı kayıt et  ->bunu çöz 
        public DataTable GetPatientDDL()
        {
            DataTable dt = new DataTable();

            string query =
               " select Ptt_Id , Ptt_Name+' ' +Ptt_Surname+' ' + convert(nvarchar,Ptt_Sex) +' '+ Ptt_TC as d " +
               " from Patient ";


            using (SqlConnection con = new SqlConnection(sCon))
            {

                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    con.Close();
                }


            }
            return dt;


        }


        //2 içerik 1. index 
        public DataTable GetPoliclinic()
        {
            DataTable dt = new DataTable();

            string query = "select * from Policlinic";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);




                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }

                return dt;

            }

        }

        //s
        public DataTable GetPersonel(string id)

        // 5 içerik 4. index
        {
            DataTable dt = new DataTable();

            string query = "select p.P_Id ,  p.P_Name +' ' + p.P_Surname as n , t.T_Name  ,p.P_Id , poli.PC_Name " +
                "from Personal as p " +
                "inner join Policlinic as poli on p.Poli_Id=poli.PC_Id " +
                "inner join Title as t on t.T_Id = p.Title_Id " +
                "where poli.PC_Id = @Id";

            using (SqlConnection con = new SqlConnection(sCon))
            {


                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }
                catch (Exception Ex)
                {

                }
                finally
                {
                    con.Close();
                }

                return dt;
            }


        }





        public string PostAppointment(Appointment app)
        {





            string query = "insert into Appointment " +
                "(A_Date,A_Time,P_Id,Ptt_Id) " +
                "values " +
                "(@Date,@Time,@P_Id,@Ptt_Id) ";


            using (SqlConnection con = new SqlConnection(sCon))
            {

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Date", app.date);
                cmd.Parameters.AddWithValue("@Time", app.time);
                cmd.Parameters.AddWithValue("@P_Id", app.P_Id);
                cmd.Parameters.AddWithValue("@Ptt_Id", app.Ptt_Id);


                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return Convert.ToString(ex);
                }
                finally
                {
                    con.Close();
                }

                return "Appointment Made";

            }


        }



        // post consultation 
        public string PostConsulatiton(Consultation c)
        {
            string query= "insert into Consultation " +
                "(Ctt_Report , Ctt_date , CUR_Id , P_Id ) " +
                "values" +
                "(@report, @date , @curid , @pid )";

            


            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@report",c.Report);
                cmd.Parameters.AddWithValue("@date",c.date);
                cmd.Parameters.AddWithValue("@curid",c.CUR);
                cmd.Parameters.AddWithValue("@pid",c.personid);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                }catch (Exception ex)
                {
                    return Convert.ToString(ex);
                }
                finally
                {
                    con.Close();
                }

                return "done";

            }



        }





}

}