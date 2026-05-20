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
    public partial class AccountFundTransfer : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private static readonly Regex AccountNumberRegex = new Regex("^[0-9]{6,20}$", RegexOptions.Compiled);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsUserAuthenticated())
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("LoginPage.aspx");
                return;
            }


            if (!Page.IsPostBack)
            {
                getChequingAccountData();
                getSavingsAccountData();
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!TryGetPositiveTransferAmount(TextBox7.Text, out _))
            {
                Response.Write("<script>alert('Please enter a valid transfer amount greater than zero.');</script>");
                return;
            }

            var destinationAccount = TextBox6.Text.Trim();
            if (!IsValidAccountNumber(destinationAccount))
            {
                Response.Write("<script>alert('Please enter a valid destination account number.');</script>");
                return;
            }

            var sourceAccountType = DropDownList1.SelectedValue;
            if ((sourceAccountType == "Chequing" && destinationAccount == TextBox1.Text.Trim()) ||
                (sourceAccountType == "Savings" && destinationAccount == TextBox2.Text.Trim()))
            {
                Response.Write("<script>alert('Destination account must be different from source account.');</script>");
                return;
            }

            if (sourceAccountType == "Chequing")
            {
                FromChequing();
                
            }
            else if (sourceAccountType == "Savings")
            {
                FromSavings();
                
            }
            else
            {
                Response.Write("<script>alert('Please select a valid source account type.');</script>");
            }
        }



        void TransactionCheq()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                var transactionType = "Transfer to Account Number:" + TextBox6.Text.Trim();

                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
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


        void TransactionSavings()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                var transactionType = "Transfer to Account Number:" + TextBox6.Text.Trim();

                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
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




                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE AccountNumber=@AccountNumber;", con);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox6.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Destination account not found.');</script>");
                    return;
                }

                var iFirstVal = "";
                iFirstVal = dt.Rows[0]["AccountBalance"].ToString();

                decimal decimalVal = 0;
                decimalVal = System.Convert.ToDecimal(iFirstVal);
                decimal amount = System.Convert.ToDecimal(TextBox7.Text);
                decimal sum = decimalVal + amount;



                decimal value2 = System.Convert.ToDecimal(TextBox3.Text);


                decimal difference = value2 - amount;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance WHERE AccountNumber=@AccountNumber;", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference);
                cmd1.Parameters.AddWithValue("@AccountNumber", TextBox1.Text.Trim());




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance WHERE AccountNumber=@AccountNumber;", con);
                cmd3.Parameters.AddWithValue("@AccountBalance", sum);
                cmd3.Parameters.AddWithValue("@AccountNumber", TextBox6.Text.Trim());


                var transactionType = "Transfer to Account Number:" + TextBox6.Text.Trim();

                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd2.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd2.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd2.Parameters.AddWithValue("@Amount", amount1);
                cmd2.Parameters.AddWithValue("@AccountNumber", TextBox1.Text.Trim());

                cmd2.Parameters.AddWithValue("@UserID", Session["Username"].ToString());






                Response.Write("<script>alert('Transfered done');</script>");
                cmd3.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
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



        void FromSavings()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }




                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE AccountNumber=@AccountNumber;", con);
                cmd.Parameters.AddWithValue("@AccountNumber", TextBox6.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Destination account not found.');</script>");
                    return;
                }

                var iFirstVal1 = "";
                iFirstVal1 = dt.Rows[0]["AccountBalance"].ToString();

                decimal decimalVal1 = 0;
                decimalVal1 = System.Convert.ToDecimal(iFirstVal1);
                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
                decimal sum1 = decimalVal1 + amount1;



                decimal value1 = System.Convert.ToDecimal(TextBox4.Text);


                decimal difference1 = value1 - amount1;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance WHERE AccountNumber=@AccountNumber;", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference1);
                cmd1.Parameters.AddWithValue("@AccountNumber", TextBox2.Text.Trim());




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance WHERE AccountNumber=@AccountNumber;", con);
                cmd3.Parameters.AddWithValue("@AccountBalance", sum1);
                cmd3.Parameters.AddWithValue("@AccountNumber", TextBox6.Text.Trim());


                var transactionType = "Transfer to Account Number:" + TextBox6.Text.Trim();

                decimal amount2 = System.Convert.ToDecimal(TextBox7.Text);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd2.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd2.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd2.Parameters.AddWithValue("@Amount", amount2);
                cmd2.Parameters.AddWithValue("@AccountNumber", TextBox2.Text.Trim());

                cmd2.Parameters.AddWithValue("@UserID", Session["Username"].ToString());






                Response.Write("<script>alert('Transfered done');</script>");
                cmd3.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
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

                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID=@UserID AND AccountType=@AccountType;", con);
                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());
                cmd.Parameters.AddWithValue("@AccountType", Chequing);
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


                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID=@UserID AND AccountType=@AccountType;", con);
                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());
                cmd.Parameters.AddWithValue("@AccountType", Savings);
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

        bool IsUserAuthenticated()
        {
            return !string.IsNullOrWhiteSpace(Session["Username"] as string);
        }

        bool TryGetPositiveTransferAmount(string amountText, out decimal amount)
        {
            if (!decimal.TryParse(amountText, out amount))
            {
                return false;
            }

            return amount > 0;
        }

        bool IsValidAccountNumber(string accountNumber)
        {
            return !string.IsNullOrWhiteSpace(accountNumber) && AccountNumberRegex.IsMatch(accountNumber);
        }
    }
}
