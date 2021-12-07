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
    public partial class BankerUserManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            getCustomerByUserID();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateCustomerStatusByID("Inactive");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateCustomerStatusByID("Active");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateCustomerDetail();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkUserIDExists())
            {
                deleteUser();

            }
            else
            {

                Response.Write("<script>alert('UserID does not exist');</script>");

            }
        }




        void getCustomerByUserID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from CustomerDetail where UserID='" + TextBox13.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox1.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();
                        TextBox2.Text = dr.GetValue(2).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();

                        TextBox10.Text = dr.GetValue(5).ToString();
                        TextBox12.Text = dr.GetValue(8).ToString();
                        TextBox4.Text = dr.GetValue(9).ToString();


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





        void UpdateCustomerDetail()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update CustomerDetail set Name=@Name, Address=@Address,City=@City, State=@State, PostalCode=@PostalCode, PhoneNumber=@PhoneNumber, Email=@Email,SIN=@SIN WHERE UserID='" + TextBox13.Text.Trim() + "';", con);


                cmd.Parameters.AddWithValue("@Name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneNumber", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@City", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@State", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@PostalCode", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@SIN", TextBox12.Text.Trim());



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('CustomerDetail Details updated Successfully');</script>");

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }


        void updateCustomerStatusByID(string status)
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE CustomerDetail SET AccountStatus='" + status + "' WHERE UserID='" + TextBox13.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Customer Account Status Updated');</script>");
                getCustomerByUserID();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        bool checkUserIDExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from CustomerDetail  WHERE UserID='" + TextBox13.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }



        void deleteUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from CustomerDetail WHERE UserID='" + TextBox13.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Deleted Successfully');</script>");

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}