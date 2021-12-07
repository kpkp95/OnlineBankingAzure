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
    public partial class FundTransfer : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Username"].ToString() == "" || Session["Username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {


                    if (!Page.IsPostBack)
                    {
                        getChequingAccountData();
                        getSavingsAccountData();
                    }

                }

            }
            catch (Exception)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("LoginPage.aspx");
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            FromChequing();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FromSavings();
            
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



                var transactionType = "Chequing to Savings";

                decimal amount1 = System.Convert.ToDecimal(TextBox5.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount1);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox1.Text.Trim());

                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());



                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Details Updated');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }





        void TransactionSavToCheq()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                var transactionType = "Savings to Chequing";

                decimal amount1 = System.Convert.ToDecimal(TextBox5.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount1);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox2.Text.Trim());

                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());



                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Details Updated');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }





        void FromChequing()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }






                decimal CheqAmount = 0;
                CheqAmount = System.Convert.ToDecimal(TextBox3.Text);
                decimal amount = System.Convert.ToDecimal(TextBox5.Text);
                decimal difference = CheqAmount - amount;



                decimal SavAmount = System.Convert.ToDecimal(TextBox4.Text);


                decimal sum = SavAmount + amount;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox1.Text.Trim() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference);







                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox2.Text.Trim() + "';", con);
                cmd3.Parameters.AddWithValue("@AccountBalance", sum);


                var transactionType = "Chequing to Savings";

                decimal amount1 = System.Convert.ToDecimal(TextBox5.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount1);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox1.Text.Trim());

                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());




                Response.Write("<script>alert('Transfered done');</script>");
                cmd3.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Details Updated');</script>");

                con.Close();

                getChequingAccountData();
                getSavingsAccountData();









            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void FromSavings()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }






                decimal SavAmount1 = 0;
                SavAmount1 = System.Convert.ToDecimal(TextBox4.Text);
                decimal amount1 = System.Convert.ToDecimal(TextBox5.Text);
                decimal difference1 = SavAmount1 - amount1;



                decimal CheqAmount1 = System.Convert.ToDecimal(TextBox3.Text);


                decimal sum1 = CheqAmount1 + amount1;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox1.Text.Trim() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", sum1);




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox2.Text.Trim() + "';", con);
                cmd3.Parameters.AddWithValue("@AccountBalance", difference1);



                var transactionType = "Savings to Chequing";

                decimal amount2 = System.Convert.ToDecimal(TextBox5.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount2);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox2.Text.Trim());

                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());


                Response.Write("<script>alert('Transfered done');</script>");
                cmd3.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('Details Updated');</script>");

                getChequingAccountData();
                getSavingsAccountData();









            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }





















        void getChequingToSavings()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var Chequing = "Chequing";
                var Savings = "Savings";

                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + Savings + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var iFirstVal = "";
                iFirstVal = dt.Rows[0]["AccountBalance"].ToString();

                decimal decimalVal = 0;
                decimalVal = System.Convert.ToDecimal(iFirstVal);
                decimal amount = System.Convert.ToDecimal(TextBox5.Text);
                decimal sum = decimalVal + amount;


                SqlCommand cmd2 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + Chequing + "';", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                var value2 = "";
                value2 = dt1.Rows[0]["AccountBalance"].ToString();
                decimal Val1 = 0;
                Val1 = System.Convert.ToDecimal(value2);

                decimal difference = Val1 - amount;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + Session["Username"].ToString() + "'and AccountNumber='" + TextBox1.Text.Trim() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference);




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + Session["Username"].ToString() + "'and AccountNumber='" + TextBox2.Text.Trim() + "';", con);
                cmd3.Parameters.AddWithValue("@AccountBalance", sum);


                Response.Write("<script>alert('Transfered done');</script>");
                cmd3.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();

                getChequingAccountData();
                getSavingsAccountData();






            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        void getSavingsToChequing()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var Chequing1 = "Chequing";
                var Savings1 = "Savings";

                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + Chequing1 + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var iFirstVal1 = "";
                iFirstVal1 = dt.Rows[0]["AccountBalance"].ToString();

                decimal decimalVal1 = 0;
                decimalVal1 = System.Convert.ToDecimal(iFirstVal1);
                decimal amount1 = System.Convert.ToDecimal(TextBox5.Text);
                decimal sum1 = decimalVal1 + amount1;


                SqlCommand cmd2 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + Savings1 + "';", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                var value2 = "";
                value2 = dt1.Rows[0]["AccountBalance"].ToString();
                decimal Val1 = 0;
                Val1 = System.Convert.ToDecimal(value2);

                decimal difference1 = Val1 - amount1;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + Session["Username"].ToString() + "'and AccountNumber='" + TextBox2.Text.Trim() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference1);




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + Session["Username"].ToString() + "'and AccountNumber='" + TextBox1.Text.Trim() + "';", con);
                cmd3.Parameters.AddWithValue("@AccountBalance", sum1);


                Response.Write("<script>alert('Transfered done');</script>");
                cmd3.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();

                getChequingAccountData();
                getSavingsAccountData();






            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }












        void getChequingAccountData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var Chequing = "Chequing";

                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + Chequing + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                TextBox1.Text = dt.Rows[0]["AccountNumber"].ToString();
                TextBox3.Text = dt.Rows[0]["AccountBalance"].ToString();



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getSavingsAccountData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                var Savings = "Savings";


                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + Savings + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                TextBox2.Text = dt.Rows[0]["AccountNumber"].ToString();
                TextBox4.Text = dt.Rows[0]["AccountBalance"].ToString();



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}