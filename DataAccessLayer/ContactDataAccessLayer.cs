using ContactWebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ContactWebApi.DataAccessLayer
{
    public class ContactDataAccessLayer : IContactDataAccesslayer
    {

       
   
        public object AddContacts(Contact objContact)
        {
            DataTable dt = new DataTable();
            ArrayList objs = new ArrayList();
            ArrayList objs1 = new ArrayList();
            int addusercnt = 0;
            bool vuser = false;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CreateContact"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", objContact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", objContact.LastName);
                    cmd.Parameters.AddWithValue("@Email", objContact.Email);
                    cmd.Parameters.AddWithValue("@PhoneNo", objContact.PhoneNo);
                    cmd.Parameters.AddWithValue("@Status", objContact.Status);

                    cmd.Connection = con;
                    con.Open();
                    addusercnt = cmd.ExecuteNonQuery();

                    if (addusercnt >= 1)
                    {
                        vuser = true;
                    }
                    else
                    {
                        vuser = false;
                    }
                    con.Close();
                }

            }

            if (vuser)
            {
                objs1.Add(new
                {
                    status = "200",
                    message = "Contact Added in Db",
                    data = "Contact",

                });
            }
            else
            {
                objs1.Add(new
                {
                    status = "500",
                    message = "Contact Does not Exist!",
                    data = "",

                });

            }

            return objs1;


        }

        
        public object DeleteContacts(Contact objContact)
        {
            DataTable dt = new DataTable();
            ArrayList objs = new ArrayList();
            ArrayList objs1 = new ArrayList();
            int addusercnt = 0;
            bool vuser = false;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteContact"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", objContact.ID);
                    

                    cmd.Connection = con;
                    con.Open();
                    addusercnt = cmd.ExecuteNonQuery();

                    if (addusercnt >= 1)
                    {
                        vuser = true;
                    }
                    else
                    {
                        vuser = false;
                    }
                    con.Close();
                }

            }

            if (vuser)
            {
                objs1.Add(new
                {
                    status = "200",
                    message = "Contact Removed in Db",
                    data = "Contact",

                });
            }
            else
            {
                objs1.Add(new
                {
                    status = "500",
                    message = "User Does not Exist!",
                    data = "",

                });

            }

            return objs1;
        }

       
       
        public object EditContacts(Contact objContact)
        {
            DataTable dt = new DataTable();
            ArrayList objs = new ArrayList();
            ArrayList objs1 = new ArrayList();
            int addusercnt = 0;
            bool vuser = false;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateContact"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", objContact.ID);
                    cmd.Parameters.AddWithValue("@FirstName", objContact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", objContact.LastName);
                    cmd.Parameters.AddWithValue("@Email", objContact.Email);
                    cmd.Parameters.AddWithValue("@PhoneNo", objContact.PhoneNo);
                    cmd.Parameters.AddWithValue("@Status", objContact.Status);

                    cmd.Connection = con;
                    con.Open();
                    addusercnt = cmd.ExecuteNonQuery();

                    if (addusercnt >= 1)
                    {
                        vuser = true;
                    }
                    else
                    {
                        vuser = false;
                    }
                    con.Close();
                }

            }

            if (vuser)
            {
                objs1.Add(new
                {
                    status = "200",
                    message = "Contact Updated in Db",
                    data = "Contact",

                });
            }
            else
            {
                objs1.Add(new
                {
                    status = "500",
                    message = "Contact Does not Updated!",
                    data = "",

                });

            }

            return objs1;


        }

        public Object GetListContacts()
        {

            DataTable dt = new DataTable();
            ArrayList objs = new ArrayList();
            ArrayList objs1 = new ArrayList();



            
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GetContact"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader _Reader = cmd.ExecuteReader();
                        while (_Reader.Read())
                        {

                           
                                objs.Add(new
                                {

                                    id = Convert.ToString(_Reader["ID"]),
                                    fname = Convert.ToString(_Reader["FirstName"]),
                                    lname = Convert.ToString(_Reader["LastName"]),
                                    email = Convert.ToString(_Reader["Email"]),
                                    phoneno = Convert.ToString(_Reader["PhoneNo"]),
                                    status = Convert.ToString(_Reader["Status"])
                                });
                            

                            
                        }

                        con.Close();

                    }

                    objs1.Add(new
                    {
                        status = "200",
                        message = "Success",
                        data = objs,

                    });

                }
            }

            catch (Exception ex)
            {

                objs1.Add(new
                {
                    status = "500",
                    message = "Error",

                });

            }

            return objs1;


        }

        public object GetListContacts(string ID)
        {
            DataTable dt = new DataTable();
            ArrayList objs = new ArrayList();
            ArrayList objs1 = new ArrayList();




            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GetContactById"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader _Reader = cmd.ExecuteReader();
                        while (_Reader.Read())
                        {


                            objs.Add(new
                            {

                                id = Convert.ToString(_Reader["ID"]),
                                fname = Convert.ToString(_Reader["FirstName"]),
                                lname = Convert.ToString(_Reader["LastName"]),
                                email = Convert.ToString(_Reader["Email"]),
                                phoneno = Convert.ToString(_Reader["PhoneNo"]),
                                status = Convert.ToString(_Reader["Status"])
                            });



                        }

                        con.Close();

                    }

                    objs1.Add(new
                    {
                        status = "200",
                        message = "Success",
                        data = objs,

                    });

                }
            }

            catch (Exception ex)
            {

                objs1.Add(new
                {
                    status = "500",
                    message = "Error",

                });

            }

            return objs1;


        }
    }
}
