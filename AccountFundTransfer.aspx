<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccountFundTransfer.aspx.cs" Inherits="OnlineBankingAzure.AccountFundTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <div class="container">
      
         
         
         <div class="row">
         <div class="col-md-10 mx-auto">
            <div class="card">
               <div class="card-body">


                   <div class="row">
                       <ul class="nav nav-tabs justify-content-center">
  <li class="nav-item">
    <a class="nav-link" href="FundTransfer.aspx">Transfer Between Accounts</a>
  </li>
  <li class="nav-item">
    <a class="nav-link active" aria-current="page" href="#">Send Money</a>
  </li>
  
</ul>
                       </div>
                  

                  <br />
                   

                  <div class="row">
                      <div class="col-md-6">


                      <label>Chequing Account</label>

                      <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                     
                      <div class="row">
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

                



                


                    <div class="col-md-6">
                   
                     
                      <label>Savings Account</label>
                       <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                        <div class="row">
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


            <hr />


                   <div class="row">

                            <div class="col-6">


                      <label>From Account</label>

                      <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                        
                     
                      
                      <div class="dropdown"">
                            <asp:DropDownList class="form-select form-select mb-3" ID="DropDownList1" runat="server">
                                 <asp:ListItem Text="Chequing" Value="Chequing" />
                                
                                <asp:ListItem Text="Savings" Value="Savings" />
                             
                               



                            </asp:DropDownList>
                           
                        </div>

                      

                      
                  </div>

                
                



               <div class="col-6">
                     
                      <label>To Account</label>
                       <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                      <div class="col">
                       
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Account Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      

                      
                        
                     </div>
                  </div>



             <hr />


                   



                    <div class="row">

                        <div class="col-md-6 mx-auto">

                            <div class="card">
                             <div class="card-body">


                                    <div class="row">
                     
                                          <div class="col-md-10 mx-auto">

                                              <label>Transfer Amount</label>

                                              <div class="input-group">
                                                   <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Transfer Amount" TextMode="Number" aria-describedby="basic-addon2" ></asp:TextBox>
                                                                    
                                                    <div class="input-group-append">
                                                         <asp:Button class="btn btn-outline-primary" ID="Button1" runat="server" Text="Confirm Transfer" OnClick="Button1_Click"  />
                                                 
                                         </div>
                                        </div>





                                </div>
                                        </div>
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
