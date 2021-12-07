<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Banker_AccountManagement.aspx.cs" Inherits="OnlineBankingAzure.Banker_AccountManagement" %>
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
                           <h3>Add Account</h3>
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
                         <label>User ID</label>
                        <div class="form-group">
                            
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="User ID" ></asp:TextBox>
                        </div>
                        <label>Account Number</label>
                        <div class="form-group">
                            
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Account Number" TextMode="Number"></asp:TextBox>
                        </div>
                        <label>Account Balance</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Account Balance" TextMode="Number"></asp:TextBox>
                        </div>
                         <label>Account Type</label>
                         <div class="dropdown"">
                            <asp:DropDownList class="form-select form-select mb-3" ID="DropDownList1" runat="server">
                                 <asp:ListItem Text="Savings" Value="Savings" />
                                
                                <asp:ListItem Text="Chequing" Value="Chequing" />
                             
                               



                            </asp:DropDownList>
                           
                        </div>

                         <div class="d-grid gap-2">
  <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Create Account" OnClick="Button2_Click"   />
</div>
                          
                       
                            
                           
                        
                        
                     </div>
                  </div>
               </div>
            </div>
           
         </div>
      </div>
   </div>

</asp:Content>
