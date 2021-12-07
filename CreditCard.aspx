<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreditCard.aspx.cs" Inherits="OnlineBankingAzure.CreditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  

                  
                   

                  <div class="row">


                      <label>Credit Card</label>

                      <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                     
                      
                      <div class="col-md-4">
                         <label>Credit Card Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Credit Card Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-4">
                          <label>Balance</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Balance" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-4">
                         <label>Amount Due</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Amount Due"></asp:TextBox>
                        </div>
                        
                     </div>
                  </div>

               

                <div class="row">

                    <label>Select Account Type</label>


                <div class="dropdown"">
                            <asp:DropDownList class="form-select form-select mb-3" ID="DropDownList1" runat="server">
                                 <asp:ListItem Text="Chequing" Value="Chequing" />
                                
                                <asp:ListItem Text="Savings" Value="Savings" />
                             
                               



                            </asp:DropDownList>
                           
                        </div>

                    </div>


                <div class="row">
                     
                                          <div class="col-md-10 mx-auto">

                                              <label>Amount to Pay</label>

                                              <div class="input-group">
                                                   <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Enter Amount" TextMode="Number" aria-describedby="basic-addon2" ></asp:TextBox>
                                                                    
                                                    <div class="input-group-append">
                                                         <asp:Button class="btn btn-outline-primary" ID="Button1" runat="server" Text="Confirm Payment" OnClick="Button1_Click" />
                                                 
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
