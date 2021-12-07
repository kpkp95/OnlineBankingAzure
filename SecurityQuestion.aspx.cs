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
    public partial class SecurityQuestion : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            addSecurityQuestion();


        }


        void addSecurityQuestion()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }





                SqlCommand cmd1 = new SqlCommand("INSERT INTO SecurityAnswer(UserID,Question,Answer) values(@UserID,@Question,@Answer)", con);

                cmd1.Parameters.AddWithValue("@UserID", Session["Username"].ToString());
                cmd1.Parameters.AddWithValue("@Question", DropDownList2.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@Answer", TextBox2.Text.Trim());

                cmd1.ExecuteNonQuery();


                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}