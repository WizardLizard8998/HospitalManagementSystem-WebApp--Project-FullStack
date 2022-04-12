using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using asp.net_first2.models;

namespace asp.net_first2.Controllers
{
    public class DoctorControls
    {
        public string sCon = "Data Source=DESKTOP-SQQ0GB8;Initial Catalog=HMS;Integrated Security=True;MultipleActiveResultSets=True";

        public DataTable GetAppointments(int id)
        {

            DataTable dt = new DataTable();

            string query = "select ap.A_Date , ap.A_Time , ptt.Ptt_Name , ptt.Ptt_Surname , ptt.Ptt_Sex " +
                "from Appointment as ap " +
                "inner join Personal as p on p.P_Id = ap.P_Id " +
                "inner join Patient as ptt on ptt.Ptt_Id = ap.Ptt_Id " +
                "where ap.P_Id = @pid" ;


            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid", id);


                try
                {
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {

                }
                finally
                { con.Close();
                }

                return dt;

          }

        }


        public DataTable GetCheckUp(int id)
        {
            DataTable dt = new DataTable();

            string query =

                            "select cu.CU_Date , cu.CU_Disease , (ptt.Ptt_Name + ptt.Ptt_Surname) as n , bd.B_Group , ptt.Ptt_Sex " +
                            " from CheckUp as cu " +
                            "inner join Appointment as a on cu.A_Id = a.A_Id " +
                            "inner join Patient as ptt on ptt.Ptt_Id = a.Ptt_Id " +
                            "inner join Personal as p on p.P_Id = ptt.Ptt_Id " +
                            "inner join BloodGroup as bd on bd.B_Id = ptt.Blood_Id " +
                            "where p.P_Id = @id ";


            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);


                try
                {
                    con.Open();


                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);



                    adapter.Fill(dt);

                }
                catch(Exception ex)
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

        public string InsertCheckUpReport(CUreport cur)
        {

            string querycur =
                        "insert into CUReport " +
                        "(CUR_date, CUR_Report , CU_Id , DR_Id) " +
                        "values " +
                        "(@date,@cur ,@cu ,@drid)";



            string hop = InsertDrugReport(cur.DReport);



            string queryGetDRid = "SELECT TOP 1 * FROM DrugReport ORDER BY DR_Id DESC ";

            using (SqlConnection con = new SqlConnection(sCon))
            {


                try
                {
                    con.Open();

                    

                   

                    SqlCommand cmdgetdrid = new SqlCommand(queryGetDRid, con);

                    cmdgetdrid.Parameters.AddWithValue("@dreport", cur.DReport);

                    SqlDataReader dataReader = cmdgetdrid.ExecuteReader();

                    SqlCommand cmdcur = new SqlCommand(querycur, con);

                    cmdcur.Parameters.AddWithValue("@date", cur.date);
                    cmdcur.Parameters.AddWithValue("@cur", cur.cuReport);
                    cmdcur.Parameters.AddWithValue("@cu", cur.cuid);

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {

                            cmdcur.Parameters.AddWithValue("@drid", dataReader["DR_Id"]);
                        }
                    }


                    if (cur.lbid != null)
                    {
                        cmdcur.Parameters.AddWithValue("@lb", cur.lbid);
                    }

                    cmdcur.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    return Convert.ToString(ex);

                }
                finally
                {
                    con.Close();
                }


            }

            return "done";

        }

        public string InsertDrugReport(string cureport)
        {


            string querydr =
                            "insert into DrugReport " +
                            "(DR_Report) " +
                            "values " +
                            "(@dreport) ";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmddr = new SqlCommand(querydr, con);


                try
                {
                    con.Open();

                    cmddr.Parameters.AddWithValue("@dreport", cureport);

                    cmddr.ExecuteNonQuery();



                }
                catch(Exception ex)
                {
                    return Convert.ToString(ex);
                }
                finally
                {
                    con.Close();
                }

            }

            return "done";


        }


        public DataTable GetDrugReports()
        {
            string query = "select DR_Report from DrugReport ";

            DataTable dt = new DataTable();

            using (SqlConnection con =new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }
                catch(Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }

            return dt;

        }


        public DataTable GetConsultation(int id)
        {
            string query=
                        "select (ptt.Ptt_Name +' ' + ptt.Ptt_Surname) as n , c.Ctt_Report,c.Ctt_date, cu.CUR_Report,cu.CUR_date , dr.DR_Report from Consultation c " +
                        "inner join CUReport as cu on cu.CUR_Id = c.CUR_Id "+
                        "inner join DrugReport as dr on dr.DR_Id = cu.DR_Id " +
                        "inner join CheckUp as chu on chu.CU_Id = cu.CU_Id " +
                        "inner join Appointment as a on a.A_Id =chu.A_Id " +
                        "inner join Patient as ptt on ptt.Ptt_Id = a.Ptt_Id " +
                        "where ptt.Ptt_Id = @id ";

            DataTable dt= new DataTable(); 

            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);
                }
                catch(Exception ex)
                {

                }
                finally
                { con.Close();
                }

                return dt;

            }


        }


        public DataTable GetLab()
        {
            string query = "select * from Lab";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);

                }
                catch(Exception ex)
                {
                    
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;


        }



        public string InsertLabReport(LabReport lr )
        {
            string query = "insert into LabReport "+
                            "(LR_Result, L_Id) "+
                            "values "+
                            "(@result,@id) ";


            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@result", lr.Report);
                    cmd.Parameters.AddWithValue("@id", lr.Labid);

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
            }

            return "done";

        }


        public DataTable GetLabReport()
        {

            string query =
                    "select lr.LR_Result  , l.L_Name ,ptt.Ptt_Name " +
                    "from LabReport as lr " +
                    "inner join Lab as l on l.L_Id = lr.L_Id " +
                    "inner join CUReport as cur on cur.LR_Id = lr.LR_Id " +
                    "inner join CheckUp as cu on cu.CU_Id = cur.CU_Id " +
                    "inner join Appointment as a on a.A_Id = cu.A_Id " +
                    "inner join Patient as ptt on ptt.Ptt_Id = a.Ptt_Id ";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);

                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }


                return dt;


            }

        }

            public string InsertCU(CheckUp cu)
            {
                string query = "insert into CheckUp " +
                    "(CU_Disease,CU_Date,A_Id)" +
                    "values " +
                    "(@disease,@date,@aid) ";


                
                using(SqlConnection con = new SqlConnection(sCon))
                {
                    SqlCommand cmd =new SqlCommand(query, con);


                  try 
                  {

                        con.Open();

                    cmd.Parameters.AddWithValue("@disease", cu.Disease);
                    cmd.Parameters.AddWithValue("@date", cu.date);
                    cmd.Parameters.AddWithValue("@aid", cu.appoid);

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


                return "done";

                }


            }



        




    }
}