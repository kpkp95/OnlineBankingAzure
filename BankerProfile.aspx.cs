using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


namespace OnlineBankingAzure
{
    public partial class BankerProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["Username1"].ToString() == "" || Session["Username1"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {


                    if (!Page.IsPostBack)
                    {
                        getBankerData();
                    }

                }

            }

            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("LoginPage.aspx");
            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateBankerDetail();
            ChangePassword();
            Response.Write("<script>alert('Your Details updated Successfully');</script>");
        }





        void UpdateBankerDetail()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update BankerInfo set BankerName=@BankerName, Address=@Address,PhoneNumber=@PhoneNumber, BankerEmail=@BankerEmail,BranchID=@BranchID WHERE UserID='" + Session["Username1"].ToString() + "';", con);


                cmd.Parameters.AddWithValue("@BankerName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneNumber", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@BankerEmail", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@BranchID", TextBox6.Text.Trim());




                cmd.ExecuteNonQuery();
                con.Close();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }







        void ChangePassword()
        {
            var hash_pass = "";
            if (TextBox4.Text.Trim() == "")
            {
                byte[] hs = new byte[255];
                string pass = TextBox12.Text;
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hs[i] = hash[i];
                    sb.Append(hs[i].ToString("x2"));
                }
                hash_pass = sb.ToString();

            }
            else
            {
                byte[] hs = new byte[255];
                string pass = TextBox4.Text;
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hs[i] = hash[i];
                    sb.Append(hs[i].ToString("x2"));
                }
                hash_pass = sb.ToString();


            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }






                SqlCommand cmd1 = new SqlCommand("update login set password=@password WHERE UserID='" + Session["Username1"].ToString() + "';", con);
                cmd1.Parameters.AddWithValue("@password", hash_pass);
                int result1 = cmd1.ExecuteNonQuery();

                con.Close();
                if (result1 > 0)
                {
                    if (TextBox4.Text.Trim() == "")
                    {
                        Session["PASSWORD1"] = TextBox12.Text;
                        getBankerData();


                    }
                    else
                    {
                        Session["PASSWORD1"] = TextBox4.Text;
                        getBankerData();



                    }
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }










        void getBankerData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from BankerInfo WHERE UserID='" + Session["Username1"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                TextBox1.Text = dt.Rows[0]["BankerName"].ToString();
                TextBox2.Text = dt.Rows[0]["Address"].ToString();

                TextBox5.Text = dt.Rows[0]["BranchID"].ToString();



                TextBox3.Text = dt.Rows[0]["PhoneNumber"].ToString();
                TextBox6.Text = dt.Rows[0]["BankerEmail"].ToString();


                TextBox12.Text = Session["PASSWORD1"].ToString();
                TextBox11.Text = Session["Username1"].ToString();



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


    }

}