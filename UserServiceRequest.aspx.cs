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
    public partial class UserServiceRequest : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            ServiceRequest();


        }


        void ServiceRequest()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }






                SqlCommand cmd = new SqlCommand("INSERT INTO ServiceRequest(UserID,ServiceRequestType,ServiceRequestDescription) values(@UserID,@ServiceRequestType,@ServiceRequestDescription)", con);

                
                cmd.Parameters.AddWithValue("@UserID", Session["Username"].ToString());
                cmd.Parameters.AddWithValue("@ServiceRequestType", DropDownList1.SelectedItem.Value);

                cmd.Parameters.AddWithValue("@ServiceRequestDescription", TextBox2.Text.Trim());






                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Request Send');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceRequestList.aspx");
        }
    }
}