<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccountsPage.aspx.cs" Inherits="OnlineBankingAzure.AccountsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  

                  
                   

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
            
         </div>
      </div>

    </div>
   



    





    


    





</asp:Content>
