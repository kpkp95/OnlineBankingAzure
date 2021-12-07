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
    public partial class AccountFundTransfer : System.Web.UI.Page
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



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                FromChequing();
                TransactionCheq();
            }
            else
            {
                FromSavings();
                TransactionSavings();
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




                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE AccountNumber='" + TextBox6.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var iFirstVal = "";
                iFirstVal = dt.Rows[0]["AccountBalance"].ToString();

                decimal decimalVal = 0;
                decimalVal = System.Convert.ToDecimal(iFirstVal);
                decimal amount = System.Convert.ToDecimal(TextBox7.Text);
                decimal sum = decimalVal + amount;



                decimal value2 = System.Convert.ToDecimal(TextBox3.Text);


                decimal difference = value2 - amount;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox1.Text.Trim() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference);




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox6.Text.Trim() + "';", con);
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



        void FromSavings()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }




                SqlCommand cmd = new SqlCommand("SELECT * from Account WHERE AccountNumber='" + TextBox6.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var iFirstVal1 = "";
                iFirstVal1 = dt.Rows[0]["AccountBalance"].ToString();

                decimal decimalVal1 = 0;
                decimalVal1 = System.Convert.ToDecimal(iFirstVal1);
                decimal amount1 = System.Convert.ToDecimal(TextBox7.Text);
                decimal sum1 = decimalVal1 + amount1;



                decimal value1 = System.Convert.ToDecimal(TextBox4.Text);


                decimal difference1 = value1 - amount1;


                SqlCommand cmd1 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox2.Text.Trim() + "';", con);
                cmd1.Parameters.AddWithValue("@AccountBalance", difference1);




                SqlCommand cmd3 = new SqlCommand("update Account set AccountBalance=@AccountBalance  WHERE AccountNumber='" + TextBox6.Text.Trim() + "';", con);
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