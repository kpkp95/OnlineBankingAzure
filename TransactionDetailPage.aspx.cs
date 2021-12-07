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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button5_Click(object sender, EventArgs e)
        {
            searchButton();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            searchLastWeekData();
        }


        void searchButton()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT TransactionID,TransactionType,DateTime,Amount,AccountNumber From transaction_record Where UserID='" + Session["Username"].ToString() + "'AND DateTime between '" + TextBox15.Text + "'and'" + TextBox16.Text + "';", con);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Record Not Found');</script>");
                }



                con.Close();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }


        void searchLastWeekData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT TransactionID,TransactionType,DateTime,Amount,AccountNumber From transaction_record Where UserID='" + Session["Username"].ToString() + "'AND DateTime >= DATEADD(day,-7, GETDATE());", con);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Record Not Found');</script>");
                }



                con.Close();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT TransactionID,TransactionType,DateTime,Amount,AccountNumber From transaction_record Where UserID='" + Session["Username"].ToString() + "';", con);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Record Not Found');</script>");
                }



                con.Close();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}