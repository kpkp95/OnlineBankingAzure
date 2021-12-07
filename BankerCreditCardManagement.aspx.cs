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
    public partial class BankerCreditCardManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateCreditCardStatusByID("Active");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateCreditCardStatusByID("Inactive");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            getCreditCard();
        }


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateCreditCardLimit();
        }



        void getCreditCard()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from CreditCard where CreditCardNumber='" + TextBox1.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox13.Text = dr.GetValue(5).ToString();
                        TextBox3.Text = dr.GetValue(2).ToString();
                        TextBox6.Text = dr.GetValue(4).ToString();
                        TextBox2.Text = dr.GetValue(1).ToString();

                        TextBox4.Text = dr.GetValue(6).ToString();


                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid UserID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        void UpdateCreditCardLimit()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                var Active = "Active";
                SqlCommand cmd = new SqlCommand("update CreditCard set Limit=@Limit WHERE CreditCardNumber='" + TextBox1.Text.Trim() + "'AND CreditCardStatus = '" + Active + "'; ", con);


                cmd.Parameters.AddWithValue("@Limit", TextBox2.Text.Trim());



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('CreditCard Limit updated Successfully');</script>");

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }


        void updateCreditCardStatusByID(string status)
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE CreditCard SET CreditCardStatus='" + status + "' WHERE CreditCardNumber='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Customer Account Status Updated');</script>");
                getCreditCard();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}