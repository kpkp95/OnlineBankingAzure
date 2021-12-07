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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton4.Visible = false;
                    LinkButton5.Visible = false;

                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button


                    LinkButton6.Visible = true;

                    LinkButton8.Visible = false;

                    LinkButton10.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton13.Visible = false;
                    LinkButton14.Visible = false;
                    LinkButton15.Visible = false;




                }
                else if (Session["role"].Equals("Customer"))
                {

                    LinkButton4.Visible = true; // logout link button
                    LinkButton5.Visible = true; // logout link button

                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["Username"].ToString();

                    LinkButton6.Visible = false;


                    LinkButton8.Visible = true;

                    LinkButton10.Visible = true;
                    LinkButton14.Visible = true;
                    LinkButton9.Visible = false;
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton13.Visible = false;

                    LinkButton15.Visible = false;

                }
                else if (Session["role"].Equals("Banker"))
                {

                    LinkButton4.Visible = false;
                    LinkButton5.Visible = false;

                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["Username1"].ToString();


                    LinkButton6.Visible = false;

                    LinkButton8.Visible = false;

                    LinkButton10.Visible = false;



                    LinkButton10.Visible = false;
                    LinkButton14.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton11.Visible = true;
                    LinkButton12.Visible = true;
                    LinkButton13.Visible = true;

                    LinkButton15.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountsPage.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FundTransfer.aspx");
        }


        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Username"] = "";
            Session["Full_Name"] = "";
            Session["role"] = "";
            Session["PASSWORD"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = false;

            LinkButton3.Visible = false;
            LinkButton7.Visible = false;

            LinkButton6.Visible = true;


            LinkButton8.Visible = false;

            LinkButton10.Visible = false;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton14.Visible = false;
            LinkButton10.Visible = false;
            LinkButton14.Visible = false;
            LinkButton9.Visible = false;
            LinkButton11.Visible = false;
            LinkButton12.Visible = false;
            LinkButton13.Visible = false;

            LinkButton15.Visible = false;
            Response.Redirect("HomePage.aspx");

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("Customer"))
            {
                Response.Redirect("ProfileCustomer.aspx");
            }
            else
            {
                Response.Redirect("BankerProfile.aspx");
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurrencyConverter.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionDetailPage.aspx");
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {


            if (Session["role"].Equals("Customer"))
            {
                Response.Redirect("UserServiceRequest.aspx");
            }
            else
            {
                Response.Redirect("BankerServiceRequest.aspx");
            }

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banker_AccountManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("BankerUserManagement.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("BankerCreditCardManagement.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banker_BranchDetail.aspx");
        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            Response.Redirect("BankerDepositePage.aspx");
        }
    }
}