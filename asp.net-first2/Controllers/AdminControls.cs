using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using asp.net_first2.models;
using System.Data.SqlClient;
using System.Data;


namespace asp.net_first2.Controllers
{
    public class AdminControls 
    {
        Patient p = new Patient();


        string sCon = "Data Source=DESKTOP-SQQ0GB8;Initial Catalog=HMS;Integrated Security=True;MultipleActiveResultSets=True";

       

        // logged user
        public DataTable getLoggedUser(string username ,string passwd)
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                DataTable dt = new DataTable();

                string query = " select p.P_Name,p.P_Surname " +
                          "from Users as u " +
                          "inner join Personal as p on u.U_Id = p.User_Id " +
                          "where u.U_UName = @uname and u.U_Passwd = @passwd";



                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query,con);

                    cmd.Parameters.AddWithValue("@uname", username);
                    cmd.Parameters.AddWithValue("@passwd", passwd);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }

                return dt;
            }
        }



        //list patients 
        public DataTable GetPatient()
        {

            using (SqlConnection con = new SqlConnection(sCon))
            {
                DataTable dt = new DataTable();
                string query =
                    " select ptt.Ptt_Id,ptt.Ptt_TC, ptt.Ptt_Name, ptt.Ptt_Surname, ptt.Ptt_Sex, bd.B_Group ,ptt.Ptt_TelNum, d.d_Name , c.c_Name"+
                    " from Patient as ptt"+
                    " inner join District as d on ptt.d_Id = d.d_Id" +
                    " inner join BloodGroup as bd on bd.B_Id= ptt.Blood_Id"+
                    " inner join City as c on c.c_Id = d.c_Id";

                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                   
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                   
                    adapter.Fill(dt);

                }
                catch (Exception ex)
                {
                    //veri gelmesinde hata olursa yeni sayfada display et 
                }
                finally
                {
                    con.Close();
                }

                return dt;
            }
    
        }

        //list patients 
        public DataTable GetPatientById(int id)
        {
                DataTable dt = new DataTable();
                string query =
                    " select ptt.Ptt_Id,ptt.Ptt_TC, ptt.Ptt_Name, ptt.Ptt_Surname, ptt.Ptt_Sex, bd.B_Group ,ptt.Ptt_TelNum, d.d_Name , c.c_Name, ptt.Ptt_Adress, ptt.Ptt_Birthdate, bd.B_Id, d.d_Id " +
                    " from Patient as ptt" +
                    " inner join District as d on ptt.d_Id = d.d_Id" +
                    " inner join BloodGroup as bd on bd.B_Id= ptt.Blood_Id" +
                    " inner join City as c on c.c_Id = d.c_Id" +
                    " where ptt.Ptt_Id= @Id";

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
                catch (Exception ex)
                {
                    //veri gelmesinde hata olursa yeni sayfada display et 
                }
                finally
                {
                    con.Close();
                }

                return dt;
            }

        }

        //  list personal 
        public DataTable GetPersonal()
        {
                DataTable dt= new DataTable();



            string query =

        "select p.P_Id, p.P_TC , p.P_Name ,p.P_Surname , t.T_Name ,pc.PC_Name ,p.P_TelNum, p.P_Adress , p.P_Sex , " +
        "d.d_Name,c.c_Name " +
        "from Personal as p " +
        "inner join Policlinic as pc on p.Poli_Id = pc.PC_Id " +
        "inner join Title as t on p.Title_Id = t.T_Id " +
        "inner join BloodGroup as bg on p.Blood_Id = bg.B_Id " +
        "inner join District as d on p.d_Id = d.d_Id " +
        "inner join City as c on d.c_Id = c.c_Id ";



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

                    // ele al
                }
                finally
                {
                    con.Close();
                }

                return dt;

            }
        
        
        }


        //  list personal 
        public DataTable  GetPersonalById(int id)
        {
            DataTable dt = new DataTable();



            string query =

        "select p.P_Id, p.P_TC , p.P_Name ,p.P_Surname , t.T_Name ,pc.PC_Name ,p.P_TelNum, p.P_Adress , p.P_Sex , " +
        "d.d_Name,c.c_Name ,p.P_Birthdate , p.Blood_Id , p.d_Id , p.Title_Id , p.Poli_Id ,p.User_Id " +
        "from Personal as p " +
        "inner join Policlinic as pc on p.Poli_Id = pc.PC_Id " +
        "inner join Title as t on p.Title_Id = t.T_Id " +
        "inner join BloodGroup as bg on p.Blood_Id = bg.B_Id " +
        "inner join District as d on p.d_Id = d.d_Id " +
        "inner join City as c on d.c_Id = c.c_Id " +
        "where p.P_Id= @Id ";



            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);


                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Id", id);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {

                    // ele al
                }
                finally
                {
                    con.Close();
                }

                return dt;

            }


        }

        // list policlinics
        public DataTable GetPoliclinic()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;

            string query = "select * from Policlinic";


            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();

                    adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);

                }
                catch(Exception ex)
                { 
                    //ele al
                }
                finally
                {
                    con.Close();
                }

                return dt;
            }
        }

        public DataTable GetPoliclinicById(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;

            string query = "select * from Policlinic where PC_Id=@Id";


            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);

                }
                catch (Exception ex)
                {
                    //ele al
                }
                finally
                {
                    con.Close();
                }

                return dt;
            }
        }



        public DataTable GetCity()
        {
            string query = "select * from City";

            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);
                }
                catch(Exception ex)
                {

                }
                finally
                { con.Close(); }

            }

            return dt;

        }


        public DataTable GetDistrict(int cityId)
        {
            string query = "select  * from City as c " +
                "inner join District as d on d.c_Id = c.c_Id " +
                "where c.c_Id = @cityId";


            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cityId", cityId);

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


        public DataTable GetTitle()
        {
            string query = "select * from Title";
            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
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

        public DataTable GetBlood()
        {
            string query = "select * from BloodGroup";
            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(sCon))
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

    
        //list personals hms accounts
        public DataTable getUser()
        {
            string query = "select u.U_Id, p.P_Id, p.P_Name,p.P_Surname , t.T_Name ,u.U_UName , u.U_Passwd " +
                            " from Users as u " +
                            " left join Personal as p on u.U_Id = p.User_Id " +
                            " left join Title as t on t.T_Id = p.Title_Id";

            DataTable dt =new DataTable();

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

                    //
                }
                finally
                {
                    con.Close();
                }
                return dt;
            }


        }



        public DataTable GetUsersById(int id)
        {
            string query =
                "select U_Id, U_UName, U_Passwd from Users where U_Id = @id";

            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }
                catch( Exception ex)
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


        //delete methods
        public string deletePatient(int Id)
        {

            string query = "exec DeletePatient @Id"; 

            int flag=0;

            using (SqlConnection con = new SqlConnection(sCon))
            {

                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", Id);

                    flag = cmd.ExecuteNonQuery();

                    if (flag != 2)
                    {
                        return "Patient couldnt removed";

                    }
                    else if (flag == 2)
                    {
                        return "Patient removed";
                    }


                }
                catch (Exception ex)
                {
                    return "Patient couldnt removed";
                }
                finally
                {
                    con.Close();
                }

                return "Patient removed";

            }


        }

        public string deletePersonal(int Id)
        {
            string query = "exec DeletePersonel @Id";

            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", Id);

                int flag = 0;

                try
                {
                    con.Open();
                    flag = cmd.ExecuteNonQuery();

                    if (flag == 2)
                    {
                        return "Personal removed";

                    } else { return "Personal couldnt removed"; }
                
                }catch (Exception ex)
                {
                    return "Personal couldnt removed";
                }
                finally
                {
                    con.Close();
                }

                return "Personal removed";

            }
        }

        public string deletePoliclinic(int Id)
        {
            string query = "delete from Policlinic where PC_Id=@Id ";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                int flag = 0;

                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Id", Id);
                    

                    flag = cmd.ExecuteNonQuery();

                    if (flag == 1)
                    {
                        return "Policlinic Removed";
                    }


                }
                catch (Exception ex)
                {
                    return "Policlinic couldnt removed";
                }
                finally
                {
                    con.Close();
                }

                return "Policlinic removed";

            }

        }


        public string DeleteUser(int uid)
        {
            string query =
                "delete from Users where U_Id = @uid ";


            using(SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@uid", uid);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
                catch(Exception ex)
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


        public string InsertPoliclinic(string name)
        {
            string query =
             "insert into Policlinic " +
             "(PC_Name) " +
             "values " +
             "(@PC_Name)";


            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@PC_Name", name);

                int flag = 0;

                try
                {
                    con.Open();

                    flag = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                }
                finally { con.Close(); }

                if (flag == 0) { return "process couldnt done"; }
                if (flag == 1) { return "process done"; }

            }




            return "process done";
        }


        public string InsertPatient(Patient ptt)
        {
            string query =
                     "insert into Patient " +
                     "(Ptt_Name , Ptt_Surname , Ptt_TC , Ptt_TelNum , Ptt_Adress , Ptt_Birthdate, Blood_Id, Ptt_Sex, d_Id ) " +
                     "values " +
                     "(@Name,@Surname,@TC,@TelNum,@Adress,@Birthdate,@Blood,@Sex,@d_Id)";
                    

               using(SqlConnection con = new SqlConnection(sCon))
            {

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", ptt.name);
                cmd.Parameters.AddWithValue("@Surname", ptt.surname);
                cmd.Parameters.AddWithValue("@TC", ptt.tc);
                cmd.Parameters.AddWithValue("@TelNum", ptt.telnum);
                cmd.Parameters.AddWithValue("@Adress", ptt.adress);
                cmd.Parameters.AddWithValue("@Birthdate", ptt.birthdate);
                cmd.Parameters.AddWithValue("@Blood", ptt.bloodid);
                cmd.Parameters.AddWithValue("@Sex", ptt.sex);
                cmd.Parameters.AddWithValue("@d_Id", ptt.district);

                int flag = 0;

                try
                {
                    con.Open();

                    flag= cmd.ExecuteNonQuery();

                    if(flag == 0 ) { return  "process couldnt done"; }
                    if(flag == 1 ) { return  "process done"; }

                }
                catch(Exception ex)
                {

                }
                finally { con.Close(); }

                return "process done";

            }


        }


        public string InsertPersonal(Personal p)
        {
            string query =
                            "insert into Personal " +
                            "(P_Name, P_Surname, P_TC, P_TelNum, P_Adress , P_Birthdate , Blood_Id, P_Sex, Poli_Id, d_Id , User_Id , Title_Id) " +
                            "values " +
                            "(@name,@surname,@tc,@telnum,@adress,@birthdate,@bloodid,@sex,@poliid,@did,@userid,@titleid)";

            
            using(SqlConnection con = new SqlConnection(sCon))
            {

                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@surname", p.surname);
                cmd.Parameters.AddWithValue("@tc", p.Tc);
                cmd.Parameters.AddWithValue("@telnum", p.telnum);
                cmd.Parameters.AddWithValue("@adress", p.adress);
                cmd.Parameters.AddWithValue("@birthdate", p.Birthdate);
                cmd.Parameters.AddWithValue("@bloodid", p.bloodid);
                cmd.Parameters.AddWithValue("@sex", p.Sex);
                cmd.Parameters.AddWithValue("@poliid", p.poli_id);
                cmd.Parameters.AddWithValue("@did", p.d_Id);
                cmd.Parameters.AddWithValue("@userid", p.user_Id);
                cmd.Parameters.AddWithValue("@titleid", p.Title_Id);

                int flag = 0; 

                try
                {
                    con.Open();

                    flag = cmd.ExecuteNonQuery();

                    if(flag == 0 ) { return "process couldnt done"; }
                    if(flag == 1 ) { return "process done"; }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }

            }

            return "process done ";

        }

        public string InsertUser(User u)
        {

            string query =
                            "insert into Users " +
                            "(U_UName, U_Passwd) " +
                            "values " +
                            "(@uname, @upasswd) ";

            using(SqlConnection con = new SqlConnection(sCon))
            {
                    SqlCommand cmd = new SqlCommand(query,con);

                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@uname", u.username);
                    cmd.Parameters.AddWithValue("@upasswd", u.password);

                    cmd.ExecuteNonQuery();

                }
                catch(Exception ex)
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


        public string UpdatePatient(Patient ptt , int pttId)
        {
            string query=
            "update Patient " +
            "set " +
            "Ptt_Name = @name, Ptt_Surname = @surname, Ptt_TelNum = @telnum, Ptt_Adress = @adress, Blood_Id = @bloodid, " +
            "Ptt_Sex = @sex, Ptt_TC = @tc, Ptt_Birthdate = @birthdate, d_Id = @did " +
            "where Ptt_Id = @pttid ";

            bool flag= false;

            using(SqlConnection con = new SqlConnection(sCon))
            {

                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@pttid", pttId);

                    cmd.Parameters.AddWithValue("@name",ptt.name);
                    cmd.Parameters.AddWithValue("@surname",ptt.surname);
                    cmd.Parameters.AddWithValue("@telnum",ptt.telnum);
                    cmd.Parameters.AddWithValue("@adress",ptt.adress);
                    cmd.Parameters.AddWithValue("@bloodid",ptt.bloodid);
                    cmd.Parameters.AddWithValue("@sex",ptt.sex);
                    cmd.Parameters.AddWithValue("@tc",ptt.tc);
                    cmd.Parameters.AddWithValue("@birthdate",ptt.birthdate);
                    cmd.Parameters.AddWithValue("@did",ptt.district);

                    flag = Convert.ToBoolean(cmd.ExecuteNonQuery());


                }
                catch(Exception ex)
                {
                    
                    Console.WriteLine(ex);
                    return  Convert.ToString(ex); 
                }
                finally
                {
                    con.Close();
                }

                return "done";
            }

          


        }

        public string UpdatePersonal(Personal p , int pId)
        {

            string query=

                        " update Personal "+
                        " set "+
                        " P_Name = @name , P_Surname = @surname , P_TelNum = @telnum , P_Adress = @adress , Blood_Id = @bloodid , "+ 
                        " P_Sex = @sex ,  P_TC = @tc , P_Birthdate = @birthdate , User_Id = @userid , Poli_Id = @poliid, Title_Id = @titleid, "+
                        " d_Id = @did "+
                        " where P_Id = @pid ";

            using (SqlConnection con = new SqlConnection(sCon))
            {

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid",pId);
                
                cmd.Parameters.AddWithValue("@name",p.name);
                cmd.Parameters.AddWithValue("@surname",p.surname);
                cmd.Parameters.AddWithValue("@telnum",p.telnum);
                cmd.Parameters.AddWithValue("@adress",p.adress);
                cmd.Parameters.AddWithValue("@bloodid",p.bloodid);
                cmd.Parameters.AddWithValue("@sex",p.Sex);
                cmd.Parameters.AddWithValue("@tc",p.Tc);
                cmd.Parameters.AddWithValue("@birthdate",p.Birthdate);
                cmd.Parameters.AddWithValue("@userid",p.user_Id);
                cmd.Parameters.AddWithValue("@poliid",p.poli_id);
                cmd.Parameters.AddWithValue("@titleid",p.Title_Id);
                cmd.Parameters.AddWithValue("@did",p.d_Id);

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


        public string UpdatePoliclinic(string name , int id)
        {
            string query =
                "update Policlinic set PC_Name =@name  where PC_Id =@id ";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();


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

        public string UpdateUser(User u , int id)
        {
            string query =
                        "update Users " +
                        "set " +
                        "U_UName = @uname , U_Passwd = @upassword " +
                        "where U_Id = @id ";

            using(SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@uname", u.username);
                    cmd.Parameters.AddWithValue("@upassword", u.password);

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