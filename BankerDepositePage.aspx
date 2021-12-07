<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerDepositePage.aspx.cs" Inherits="OnlineBankingAzure.BankerDepositePage" %>
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
                           <h3>Deposit</h3>
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
                        <label>Deposit Amount</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Deposit Amount" TextMode="Number"></asp:TextBox>
                        </div>
                         <br />

                         

                         <div class="d-grid gap-2">
  <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Deposit" OnClick="Button2_Click"    />
</div>
                          
                       
                            
                           
                        
                        
                     </div>
                  </div>
               </div>
            </div>
           
         </div>
      </div>

         

   </div>


</asp:Content>
