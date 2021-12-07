using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBankingAzure
{
    public partial class LoginPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            byte[] hs = new byte[255];
            string pass = TextBox2.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hs[i] = hash[i];
                sb.Append(hs[i].ToString("x2"));
            }
            var hash_pass = sb.ToString();


            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd1 = new SqlCommand("SELECT * from login where UserID='" + TextBox1.Text.Trim() + "' AND Password='" + hash_pass + "' AND user_type='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    if (DropDownList1.SelectedIndex == 0)
                    {
                        if (checkCustomerExists())
                        {

                            if (checkAccountExists())
                            {
                                if (checkUserExists())
                                {
                                    Session["Username"] = dt.Rows[0][0];
                                    Session["PASSWORD"] = TextBox2.Text;
                                    Session["role"] = "Customer";

                                    Response.Redirect("answerCheckPage.aspx");

                                }
                                else
                                {
                                    Response.Redirect("SecurityQuestionPage.aspx");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Account not created.Please wait for Banker to approve');</script>");



                            }
                        }
                        else
                        {
                            Session["Username"] = dt.Rows[0][0];
                            Session["PASSWORD"] = TextBox2.Text;
                            Session["role"] = "Customer";
                            Response.Redirect("UserSignUp.aspx");

                        }

                    }
                    else
                    {
                        if (checkBankerExists())
                        {
                            Session["Username1"] = dt.Rows[0][0];
                            Session["PASSWORD1"] = TextBox2.Text;
                            Session["role"] = "Banker";
                            Response.Redirect("BankerProfile.aspx");
                        }
                        else
                        {
                            Session["Username1"] = dt.Rows[0][0];
                            Session["PASSWORD1"] = TextBox2.Text;
                            Session["role"] = "Banker";
                            Response.Redirect("BankerSignUP.aspx");

                        }


                    }


                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        bool checkCustomerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from CustomerDetail where UserID='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        bool checkAccountExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Account where UserID='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }





        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from SecurityAnswer where UserID='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        bool checkBankerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from BankerInfo where UserID='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }









    }
}