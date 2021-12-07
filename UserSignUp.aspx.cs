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
    public partial class UserSignUp : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Add_User_Detail();
        }


        void Add_User_Detail()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO CustomerDetail(UserID,Name,Address,City,State,PostalCode,PhoneNumber,Email,SIN) values(@UserID,@Name,@Address,@City,@State,@PostalCode,@PhoneNumber,@Email,@SIN)", con);
                cmd.Parameters.AddWithValue("@UserID", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@City", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@State", TextBox9.Text.Trim());

                cmd.Parameters.AddWithValue("@PostalCode", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneNumber", TextBox3.Text.Trim());

                cmd.Parameters.AddWithValue("@Email", TextBox6.Text.Trim());


                cmd.Parameters.AddWithValue("@SIN", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();


                con.Close();
                Response.Write("<script>alert('Details Updated');</script>");
                Response.Redirect("SecurityQuestionPage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }












        }
    }
}