<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="OnlineBankingAzure.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                            
                            
                            <img src="img/user.png" width="150px" />
                           
                           
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Sign Up</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>User Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User Name"></asp:TextBox>
                        </div>
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                          <label>Sign Up Type</label>
                        <div class="dropdown">
                            <asp:DropDownList class="form-select form-select mb-3" ID="DropDownList1" runat="server">
                                 <asp:ListItem Text="Customer" Value="Customer" />
                                
                                <asp:ListItem Text="Banker" Value="Banker" />
                             
                               



                            </asp:DropDownList>
                           
                        </div>
                        <div class="d-grid gap-2">
                            
                           <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"   />
                        </div>
                        
                     </div>
                  </div>
               </div>
            </div>
           
         </div>
      </div>
   </div>

</asp:Content>
