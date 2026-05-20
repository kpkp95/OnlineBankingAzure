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
            getChequingAccountData();
            getSavingsAccountData();

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
            var sourceAccountNumber = sourceAccountType == "Chequing" ? TextBox1.Text.Trim() : TextBox2.Text.Trim();
            if (!IsValidAccountNumber(sourceAccountNumber))
            {
                Response.Write("<script>alert('Unable to resolve source account details. Please refresh and try again.');</script>");
                return;
            }

            if (destinationAccount == sourceAccountNumber)
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
        void FromChequing()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }




                decimal destinationBalance;
                if (!TryGetAccountBalanceByAccountNumber(con, TextBox6.Text.Trim(), out destinationBalance))
                {
                    Response.Write("<script>alert('Destination account not found.');</script>");
                    return;
                }
                decimal amount = System.Convert.ToDecimal(TextBox7.Text);
                decimal sum = destinationBalance + amount;



                decimal value2 = System.Convert.ToDecimal(TextBox3.Text);


                decimal difference = value2 - amount;


                if (!ExecuteTransfer(con, TextBox1.Text.Trim(), difference, TextBox6.Text.Trim(), sum, amount, TextBox1.Text.Trim()))
                {
                    Response.Write("<script>alert('Insufficient funds in source account.');</script>");
                    return;
                }
                Response.Write("<script>alert('Transfered done');</script>");
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




                decimal destinationBalance;
                if (!TryGetAccountBalanceByAccountNumber(con, TextBox6.Text.Trim(), out destinationBalance))
                {
                    Response.Write("<script>alert('Destination account not found.');</script>");
                    return;
                }
                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
                decimal sum1 = destinationBalance + amount1;



                decimal value1 = System.Convert.ToDecimal(TextBox4.Text);


                decimal difference1 = value1 - amount1;


                if (!ExecuteTransfer(con, TextBox2.Text.Trim(), difference1, TextBox6.Text.Trim(), sum1, amount1, TextBox2.Text.Trim()))
                {
                    Response.Write("<script>alert('Insufficient funds in source account.');</script>");
                    return;
                }
                Response.Write("<script>alert('Transfered done');</script>");
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
            LoadAccountData("Chequing", TextBox1, TextBox3);
        }




        void getSavingsAccountData()
        {
            LoadAccountData("Savings", TextBox2, TextBox4);
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

        bool TryGetAccountBalanceByAccountNumber(SqlConnection con, string accountNumber, out decimal accountBalance)
        {
            accountBalance = 0;
            SqlCommand cmd = new SqlCommand("SELECT AccountBalance from Account WHERE AccountNumber=@AccountNumber;", con);
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return false;
            }

            return decimal.TryParse(dt.Rows[0]["AccountBalance"].ToString(), out accountBalance);
        }

        bool ExecuteTransfer(SqlConnection con, string sourceAccountNumber, decimal sourceAccountBalance, string destinationAccountNumber, decimal destinationAccountBalance, decimal amount, string transactionAccountNumber)
        {
            if (sourceAccountBalance < 0)
            {
                return false;
            }

            SqlCommand updateSource = new SqlCommand("update Account set AccountBalance=@AccountBalance WHERE AccountNumber=@AccountNumber;", con);
            updateSource.Parameters.AddWithValue("@AccountBalance", sourceAccountBalance);
            updateSource.Parameters.AddWithValue("@AccountNumber", sourceAccountNumber);

            SqlCommand updateDestination = new SqlCommand("update Account set AccountBalance=@AccountBalance WHERE AccountNumber=@AccountNumber;", con);
            updateDestination.Parameters.AddWithValue("@AccountBalance", destinationAccountBalance);
            updateDestination.Parameters.AddWithValue("@AccountNumber", destinationAccountNumber);

            SqlCommand recordTransfer = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);
            recordTransfer.Parameters.AddWithValue("@TransactionType", "Transfer to Account Number:" + destinationAccountNumber);
            recordTransfer.Parameters.AddWithValue("@DateTime", DateTime.Now);
            recordTransfer.Parameters.AddWithValue("@Amount", amount);
            recordTransfer.Parameters.AddWithValue("@AccountNumber", transactionAccountNumber);
            recordTransfer.Parameters.AddWithValue("@UserID", Session["Username"].ToString());

            SqlTransaction transaction = con.BeginTransaction();
            updateDestination.Transaction = transaction;
            updateSource.Transaction = transaction;
            recordTransfer.Transaction = transaction;
            try
            {
                updateDestination.ExecuteNonQuery();
                updateSource.ExecuteNonQuery();
                recordTransfer.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        void LoadAccountData(string accountType, TextBox accountNumberTextBox, TextBox accountBalanceTextBox)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE UserID=@UserID AND AccountType=@AccountType;", con);
                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());
                cmd.Parameters.AddWithValue("@AccountType", accountType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                accountNumberTextBox.Text = dt.Rows[0]["AccountNumber"].ToString();
                accountBalanceTextBox.Text = dt.Rows[0]["AccountBalance"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}
