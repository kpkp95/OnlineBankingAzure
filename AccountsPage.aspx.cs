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
    public partial class AccountsPage : System.Web.UI.Page
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