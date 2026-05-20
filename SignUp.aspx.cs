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
using System.Text.RegularExpressions;

namespace OnlineBankingAzure
{
    public partial class SignUp : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            var userId = TextBox1.Text.Trim();
            var password = TextBox2.Text;
            var signUpType = DropDownList1.SelectedValue?.Trim();

            if (!IsValidUsername(userId) || !IsValidPassword(password) || !IsValidSignUpType(signUpType))
            {
                Response.Write("<script>alert('Please enter a valid username, password, and signup type.');</script>");
                return;
            }

            byte[] hs = new byte[255];
            string pass = password;
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

            if (checkMemberExists(userId))
            {

                Response.Write("<script>alert('Username already exists,Please try a different Username');</script>");
            }
            else
            {

                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO login(UserID,Password,user_type) values(@UserID,@Password,@user_type)", con);


                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Password", hash_pass);
                    cmd.Parameters.AddWithValue("@user_type", signUpType);

                    cmd.ExecuteNonQuery();



                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                    Response.Redirect("LoginPage.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Unable to complete signup right now.');</script>");
                }

            }


        }

        bool checkMemberExists(string userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT 1 from login where UserID=@UserID;", con);
                cmd.Parameters.AddWithValue("@UserID", userId);
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
                Response.Write("<script>alert('Unable to verify existing user.');</script>");
                return false;
            }
        }

        bool IsValidUsername(string userId)
        {
            return !string.IsNullOrWhiteSpace(userId) && Regex.IsMatch(userId, "^[A-Za-z0-9_]{3,50}$");
        }

        bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8 && password.Length <= 128;
        }

        bool IsValidSignUpType(string signUpType)
        {
            return signUpType == "Customer" || signUpType == "Banker";
        }
    }
}
