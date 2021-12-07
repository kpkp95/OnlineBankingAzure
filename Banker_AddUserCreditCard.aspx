<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Banker_AddUserCreditCard.aspx.cs" Inherits="OnlineBankingAzure.Banker_AddUserCreditCard" %>
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
    <a class="nav-link"  href="BankerCreditCardManagement.aspx">Credit Card Management</a>
  </li>
  <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="#">Add Credit Card</a>
  </li>
  
</ul>
                       </div>
     <br />             

                  
                   

                  <div class="row">


                      <label>Add Credit Card</label>

                      <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>


                      <div class="col-md-4">
                         <label>User ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="User ID"></asp:TextBox>
                        </div>
                        
                     </div>
                     
                      
                      <div class="col-md-4">
                         <label>Credit Card Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Credit Card Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-4">
                          <label>Limit</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Balance" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>


                  </div>
                   <br />

               

                <div class="row">

                                          <div class="col-md-4">
                         <label>Expiry Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Amount Due" TextMode="Date"></asp:TextBox>
                        </div>
                        
                     </div>
                    <div class="col-md-8">
                    <label>Account Number</label>
                        <div class="form-group">
                            
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Account Number" TextMode="Number"></asp:TextBox>
                        </div>


                

                    </div>
                    </div>

                     <br />


                
                     
                                          

                                        

                                              
                                                   
                                                                    
                                                    <div class="d-grid gap-2">
  <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Add Credit Card" OnClick="Button2_Click"  />
</div>
                                        





                                



                

                   


                 

 </div>
                      
                        
        
            </div>
            
         </div>
      </div>

          <br />




          



    </div>                     
                  

                  


                  

                      


</asp:Content>
