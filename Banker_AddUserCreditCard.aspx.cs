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
    public partial class Banker_AddUserCreditCard : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            AddCreditCard();
        }

        void AddCreditCard()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }






                SqlCommand cmd = new SqlCommand("INSERT INTO CreditCard(CreditCardNumber,Limit,ExpityDate,AccountNumber,UserID) values(@CreditCardNumber,@Limit,@ExpityDate,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@CreditCardNumber", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Limit", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@ExpityDate", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox5.Text.Trim());

                cmd.Parameters.AddWithValue("@UserID", TextBox2.Text.Trim());



                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Credit Card Added');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}