<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FundTransfer.aspx.cs" Inherits="OnlineBankingAzure.FundTransfer" %>
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
    <a class="nav-link active" aria-current="page" href="#">Transfer Between Accounts</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="AccountFundTransfer.aspx">Send Money</a>
  </li>
  
</ul>
                       </div>
                  

                  
                   

                  <div class="row">


                      <label>Chequing Account</label>

                      <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                     
                      
                      <div class="col-md-6">
                         <label>Account Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Account Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-6">
                          <label>Account Balance</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Account Balance" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      
                  </div>

                </div>



                <div class="card">
               <div class="card-body">



                   <div class="row">
                     
                      <label>Savings Account</label>
                       <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                      <div class="col-md-6">
                         <label>Account Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Account Number"></asp:TextBox>
                        </div>
                        
                     </div>

                       <div class="col-md-6">
                          <label>Account Balance</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Account Balance" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      
                        
                     </div>
                  </div>
                   </div>
                    </div>

                <div class="card">
               <div class="card-body">



                   <div class="row">
                     
                      <div class="col-md-6">
                          <label>Transfer Amount</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Transfer Amount" TextMode="Number" ></asp:TextBox>
                        </div>
                        
                     </div>
                  </div>
                   <div class="col">
                        <hr>
                     </div>
                                    <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Chequing to Savings" OnClick="Button2_Click"   />



                   



                <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Savings to Chequing" OnClick="Button1_Click"  />

                   </div>
                    </div>


                   


                 


                      
                        
                     
                  

                  


                  

                      

                      


                  






                   


                    

                   









                  
               
            </div>
            
         </div>
      </div>

</asp:Content>
