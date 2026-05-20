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
using System.Text.RegularExpressions;

namespace OnlineBankingAzure
{
    public partial class LoginPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private static readonly Regex UserNameRegex = new Regex("^[A-Za-z0-9_]{3,50}$", RegexOptions.Compiled);

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            var userId = TextBox1.Text.Trim();
            var rawPassword = TextBox2.Text;
            var loginType = DropDownList1.SelectedValue?.Trim();

            if (!IsValidUsername(userId) || !IsValidPasswordInput(rawPassword) || !IsValidLoginType(loginType))
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("SELECT UserID, Password from login where UserID=@UserID AND user_type=@UserType;", con);
                cmd1.Parameters.AddWithValue("@UserID", userId);
                cmd1.Parameters.AddWithValue("@UserType", loginType);

                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                    return;
                }

                var storedPassword = dt.Rows[0]["Password"].ToString();
                if (!VerifyPassword(rawPassword, storedPassword))
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                    return;
                }

                if (DropDownList1.SelectedIndex == 0)
                {
                    if (checkCustomerExists(userId))
                    {

                        if (checkAccountExists(userId))
                        {
                            if (checkUserExists(userId))
                            {
                                Session["Username"] = dt.Rows[0]["UserID"].ToString();
                                Session["PASSWORD"] = string.Empty;
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
                        Session["Username"] = dt.Rows[0]["UserID"].ToString();
                        Session["PASSWORD"] = string.Empty;
                        Session["role"] = "Customer";
                        Response.Redirect("UserSignUp.aspx");

                    }

                }
                else
                {
                    if (checkBankerExists(userId))
                    {
                        Session["Username1"] = dt.Rows[0]["UserID"].ToString();
                        Session["PASSWORD1"] = string.Empty;
                        Session["role"] = "Banker";
                        Response.Redirect("BankerProfile.aspx");
                    }
                    else
                    {
                        Session["Username1"] = dt.Rows[0]["UserID"].ToString();
                        Session["PASSWORD1"] = string.Empty;
                        Session["role"] = "Banker";
                        Response.Redirect("BankerSignUP.aspx");

                    }


                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('An unexpected error occurred while logging in.');</script>");
            }
        }


        bool checkCustomerExists(string userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT 1 from CustomerDetail where UserID=@UserID;", con);
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
                Response.Write("<script>alert('Unable to verify customer details.');</script>");
                return false;
            }
        }


        bool checkAccountExists(string userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT 1 from Account where UserID=@UserID;", con);
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
                Response.Write("<script>alert('Unable to verify account details.');</script>");
                return false;
            }
        }





        bool checkUserExists(string userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT 1 from SecurityAnswer where UserID=@UserID;", con);
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
                Response.Write("<script>alert('Unable to verify security setup.');</script>");
                return false;
            }
        }


        bool checkBankerExists(string userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT 1 from BankerInfo where UserID=@UserID;", con);
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
                Response.Write("<script>alert('Unable to verify banker details.');</script>");
                return false;
            }
        }

        bool IsValidUsername(string userId)
        {
            return !string.IsNullOrWhiteSpace(userId) && UserNameRegex.IsMatch(userId);
        }

        bool IsValidPasswordInput(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length <= 128;
        }

        bool IsValidLoginType(string loginType)
        {
            return loginType == "Customer" || loginType == "Banker";
        }

        bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            if (string.IsNullOrWhiteSpace(storedPassword))
            {
                return false;
            }

            if (storedPassword.StartsWith("PBKDF2$", StringComparison.Ordinal))
            {
                var parts = storedPassword.Split('$');
                if (parts.Length != 4)
                {
                    return false;
                }

                int iterations;
                if (!int.TryParse(parts[1], out iterations) || iterations <= 0)
                {
                    return false;
                }

                byte[] salt;
                byte[] expectedHash;
                try
                {
                    salt = Convert.FromBase64String(parts[2]);
                    expectedHash = Convert.FromBase64String(parts[3]);
                }
                catch
                {
                    return false;
                }

                using (var deriveBytes = new Rfc2898DeriveBytes(enteredPassword, salt, iterations))
                {
                    var actualHash = deriveBytes.GetBytes(expectedHash.Length);
                    return actualHash.SequenceEqual(expectedHash);
                }
            }

            return string.Equals(HashLegacyMd5(enteredPassword), storedPassword, StringComparison.OrdinalIgnoreCase);
        }

        string HashLegacyMd5(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                StringBuilder sb = new StringBuilder(hash.Length * 2);
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
