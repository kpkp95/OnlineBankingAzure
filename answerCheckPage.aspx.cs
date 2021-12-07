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
    public partial class answerCheckPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetSecurityQuestion();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }


        void GetSecurityQuestion()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT Question from SecurityAnswer WHERE UserID='" + Session["Username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                TextBox2.Text = dt.Rows[0]["Question"].ToString();
            }
            catch (Exception ex)

            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void CheckAnswer()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd1 = new SqlCommand("SELECT * from SecurityAnswer where UserID = '" + Session["Username"].ToString() + "' AND Question='" + TextBox2.Text.Trim() + "' AND Answer='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('You logged in as " + dt.Rows[0][0] + "');</script>");
                    Response.Redirect("AccountsPage.aspx");




                }
                else
                {
                    Response.Write("<script>alert('Invalid Answer');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}