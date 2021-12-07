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
    public partial class CreditCard : System.Web.UI.Page
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
                        getCreditCardDetails();
                    }

                }

            }
            catch (Exception)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("LoginPage.aspx");
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                PayAmoutDue1();
                
            }
            else
            {
                PayAmoutDue2();
                
            }
        }


        void PayAmoutDue1()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var Active = "Active";


                SqlCommand cmd = new SqlCommand("SELECT * from CreditCard WHERE UserID='" + Session["Username"].ToString() + "'AND ExpityDate>= GETDATE() AND CreditCardStatus ='" + Active + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var val1 = "";
                var val2 = "";
                val1 = dt.Rows[0]["Limit"].ToString();
                val2 = dt.Rows[0]["Amount"].ToString();

                decimal limit = 0;
                decimal dueAmount = 0;
                limit = System.Convert.ToDecimal(val1);
                dueAmount = System.Convert.ToDecimal(val2);


                decimal CCbalance = limit - dueAmount;


                decimal amount = System.Convert.ToDecimal(TextBox7.Text);

                decimal NewDueAmount = dueAmount - amount;





                SqlCommand cmd2 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                var value2 = "";
                value2 = dt1.Rows[0]["AccountBalance"].ToString();

                decimal AccBalance = 0;
                AccBalance = System.Convert.ToDecimal(value2);


                decimal difference = AccBalance - amount;



                decimal newBalance = CCbalance + amount;

                var ACCTYPE = DropDownList1.SelectedItem.ToString();


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + Session["Username"].ToString() + "' AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference);


                SqlCommand cmd3 = new SqlCommand("update CreditCard set Amount=@Amount WHERE UserID='" + Session["Username"].ToString() + "';", con);
                cmd3.Parameters.AddWithValue("@Amount", NewDueAmount);

                SqlCommand cmd4 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                var accountNumber33 = "";
                accountNumber33 = dt3.Rows[0]["AccountNumber"].ToString();


                var transactionType = "Credit Card Payment: From Chequing";

                decimal amount33 = System.Convert.ToDecimal(TextBox7.Text);
                SqlCommand cmd5 = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd5.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd5.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd5.Parameters.AddWithValue("@Amount", amount33);
                cmd5.Parameters.AddWithValue("@AccountNumber", accountNumber33);

                cmd5.Parameters.AddWithValue("@UserID", Session["Username"].ToString());


                Response.Write("<script>alert('Payment done');</script>");
                cmd1.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();

                Response.Write("<script>alert('Details Updated');</script>");
                con.Close();

                getCreditCardDetails();


















            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void PayAmoutDue2()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var Active1 = "Active";


                SqlCommand cmd = new SqlCommand("SELECT * from CreditCard WHERE UserID='" + Session["Username"].ToString() + "'AND ExpityDate>= GETDATE() AND CreditCardStatus ='" + Active1 + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var val11 = "";
                var val22 = "";
                val11 = dt.Rows[0]["Limit"].ToString();
                val22 = dt.Rows[0]["Amount"].ToString();

                decimal limit1 = 0;
                decimal dueAmount1 = 0;
                limit1 = System.Convert.ToDecimal(val11);
                dueAmount1 = System.Convert.ToDecimal(val22);


                decimal CCbalance1 = limit1 - dueAmount1;


                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);

                decimal NewDueAmount1 = dueAmount1 - amount1;





                SqlCommand cmd2 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                var value22 = "";
                value22 = dt1.Rows[0]["AccountBalance"].ToString();

                decimal AccBalance1 = 0;
                AccBalance1 = System.Convert.ToDecimal(value22);


                decimal difference1 = AccBalance1 - amount1;



                decimal newBalance1 = CCbalance1 + amount1;

                var ACCTYPE = DropDownList1.SelectedItem.ToString();


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE UserID='" + Session["Username"].ToString() + "' AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference1);


                SqlCommand cmd3 = new SqlCommand("update CreditCard set Amount=@Amount WHERE UserID='" + Session["Username"].ToString() + "';", con);
                cmd3.Parameters.AddWithValue("@Amount", NewDueAmount1);


                SqlCommand cmd4 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd4);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                var accountNumber1 = "";
                accountNumber1 = dt2.Rows[0]["AccountNumber"].ToString();


                var transactionType1 = "Credit Card Payment: From Savings";

                decimal amount3 = System.Convert.ToDecimal(TextBox7.Text);
                SqlCommand cmd5 = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd5.Parameters.AddWithValue("@TransactionType", transactionType1);
                cmd5.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd5.Parameters.AddWithValue("@Amount", amount3);
                cmd5.Parameters.AddWithValue("@AccountNumber", accountNumber1);

                cmd5.Parameters.AddWithValue("@UserID", Session["Username"].ToString());


                Response.Write("<script>alert('Payment done');</script>");
                cmd1.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('Details Updated');</script>");

                getCreditCardDetails();


















            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

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


                SqlCommand cmd2 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                var accountNumber = "";
                accountNumber = dt1.Rows[0]["AccountNumber"].ToString();


                var transactionType = "Credit Card Payment";

                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount1);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

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
                SqlCommand cmd2 = new SqlCommand("SELECT * from Account WHERE UserID='" + Session["Username"].ToString() + "'AND AccountType='" + DropDownList1.SelectedItem.ToString() + "';", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                var accountNumber = "";
                accountNumber = dt1.Rows[0]["AccountNumber"].ToString();


                var transactionType = "Credit Card Payment";

                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
                SqlCommand cmd = new SqlCommand("INSERT INTO transaction_record(TransactionType,DateTime,Amount,AccountNumber,UserID) values(@TransactionType,@DateTime,@Amount,@AccountNumber,@UserID)", con);

                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount1);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

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





























        void getCreditCardDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                var Active = "Active";
                SqlCommand cmd = new SqlCommand("SELECT * from CreditCard WHERE UserID='" + Session["Username"].ToString() + "'AND ExpityDate>= GETDATE() AND CreditCardStatus ='" + Active + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                TextBox1.Text = dt.Rows[0]["CreditCardNumber"].ToString();
                var iFirstVal = "";
                iFirstVal = dt.Rows[0]["Limit"].ToString();

                decimal decimalVal = 0;
                decimalVal = System.Convert.ToDecimal(iFirstVal);

                var secondVal = "";
                secondVal = dt.Rows[0]["Amount"].ToString();

                decimal amount = 0;

                amount = System.Convert.ToDecimal(secondVal);
                decimal Balance = decimalVal - amount;

                TextBox3.Text = Balance.ToString();
                TextBox4.Text = dt.Rows[0]["Amount"].ToString();



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

    }
}