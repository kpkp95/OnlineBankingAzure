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
        private static readonly Regex UserNameRegex = new Regex("^[A-Za-z0-9_]{3,50}$", RegexOptions.Compiled);

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

            var hash_pass = HashPasswordForStorage(password);

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
                catch (Exception)
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
            catch (Exception)
            {
                Response.Write("<script>alert('Unable to verify existing user.');</script>");
                return false;
            }
        }

        bool IsValidUsername(string userId)
        {
            return !string.IsNullOrWhiteSpace(userId) && UserNameRegex.IsMatch(userId);
        }

        bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8 && password.Length <= 128;
        }

        bool IsValidSignUpType(string signUpType)
        {
            return signUpType == "Customer" || signUpType == "Banker";
        }

        string HashPasswordForStorage(string password)
        {
            const int iterations = 100000;
            const int saltSize = 16;
            const int hashSize = 32;

            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                hash = deriveBytes.GetBytes(hashSize);
            }

            return string.Format("PBKDF2${0}${1}${2}",
                iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }
    }
}
