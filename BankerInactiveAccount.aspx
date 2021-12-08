<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerInactiveAccount.aspx.cs" Inherits="OnlineBankingAzure.BankerInactiveAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container">
            


         
             <div class="row">
                <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">

                   <div class="row">
                       <ul class="nav nav-tabs justify-content-center">
  <li class="nav-item">
    <a class="nav-link" href="BankerUserManagement.aspx">All Users</a>
  </li>
  <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="#">All Inactive Users</a>
  </li>
  
</ul>
                       </div>

                   <br />

                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>All Inactive Users</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BankingSystemConnectionString %>" SelectCommand="SELECT TOP (1000) UserID, Name, Email, AccountStatus FROM CustomerDetail WHERE (AccountStatus = 'Inactive')"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="UserID">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                <asp:BoundField DataField="AccountStatus" HeaderText="AccountStatus" SortExpression="AccountStatus" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
               </div>
   
</div>


</asp:Content>
