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
    public partial class BankerDepositePage : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Deposit();
            TransactionCheqToSav();
        }

        void Deposit()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID='" + TextBox3.Text.Trim() + "'AND AccountNumber='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);




                var balance = dt.Rows[0]["AccountBalance"].ToString();
                decimal Old_Balance = 0;
                Old_Balance = System.Convert.ToDecimal(balance);


                decimal amount = System.Convert.ToDecimal(TextBox2.Text);
                decimal sum = Old_Balance + amount;

                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + TextBox3.Text.Trim() + "'AND AccountNumber='" + TextBox1.Text.Trim() + "';", con);

                cmd1.Parameters.AddWithValue("@AccountBalance", sum);





                cmd1.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void TransactionCheqToSav()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                var transactionType = "Deposit";

                decimal amount1 = System.Convert.ToDecimal(TextBox2.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount1);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox1.Text.Trim());

                cmd.Parameters.AddWithValue("@UserID", TextBox3.Text.Trim());



                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Deposit done');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}