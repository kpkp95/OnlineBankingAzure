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
    public partial class Banker_AccountManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Account(AccountNumber,AccountBalance,AccountType,UserID) values(@AccountNumber,@AccountBalance,@AccountType,@UserID)", con);

                cmd.Parameters.AddWithValue("@UserID", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountBalance", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountType", DropDownList1.SelectedItem.Value);

                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Account created successfully. Now User can login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
    }
}