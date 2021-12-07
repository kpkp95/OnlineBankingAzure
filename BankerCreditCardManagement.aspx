<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerCreditCardManagement.aspx.cs" Inherits="OnlineBankingAzure.BankerCreditCardManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="container">
      <div class="row">
         <div class="col-md-9 mx-auto">
            <div class="card">
               <div class="card-body">


                   <div class="row">
                       <ul class="nav nav-tabs justify-content-center">
  <li class="nav-item">
    <a class="nav-link active"  aria-current="page" href="#">Credit Card Management</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" aria-current="page" href="Banker_AddUserCreditCard.aspx">Add Credit Card</a>
  </li>
  
</ul>
                       </div>
     <br />       

                  <div class="row">
                     <div class="col">
                        <center>
                            
                            <img src="img/user.png" width="150px"/>
                            
                           
                           
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Credit Card Detail</h3>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">

                      <div class="col-md-4">
                         <label>Credit Card Number</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Credit Card Number" ></asp:TextBox>
                           
                            <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button3_Click"  />
                        </div>
                       </div>
                        
                     </div>
                     
                      
                      <div class="col-md-4">
                         <label>User ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="User ID" ReadOnly="True" ></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-4">
                          <label>Expiry Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Expiry Date" ReadOnly="True"></asp:TextBox>
                        </div>
                        
                     </div>
                  </div>

                   <br />
                   


                 <div class="row">
                     <div class="col-md-3 form-group">
                               <label >Amount Due</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" ReadOnly="True" placeholder="Amount Due" ></asp:TextBox>

                                   </div>
                            </div>

                      <div class="col-md-4 form-group" >

                                <label >Limit</label>
                                <div class="input-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Limit"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton3" class="btn btn-primary" BackColor="Green" Width="15%" Text="A" runat="server" OnClick="LinkButton3_Click"  ><i class="bi bi-check2-square"></i></asp:LinkButton>
                                    
                                    


                                </div>
                          </div>



                     <div class="col-md-5 form-group" >

                                <label >Credit Card Status</label>
                                <div class="input-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Credit Card Status" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-primary" BackColor="Green" Width="15%" Text="A" runat="server" OnClick="LinkButton1_Click"  ><i class="bi bi-check2-square"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" class="btn btn-primary" Width="15%" Text="D" runat="server"  BackColor="#CC0000" OnClick="LinkButton2_Click"><i class="bi bi-x-circle"></i></asp:LinkButton>
                                    


                                </div>

                            </div>
                  

                      </div>


                      
                        <br />
                     
                  


                  


                 




               


                    


                  






                   



                   









                  
               
           
            
         </div>
      
                
            </div>

             </div>
          </div>


             <div class="row">

          <div class="col mx-auto">


            <div class="card">
               <div class="card-body">
                   
                                                                                               
                        

                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Credit Card Holder</h3>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   

                   <div class="row">
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankingAzure_db1ConnectionString %>" SelectCommand="SELECT * FROM [CreditCard]"></asp:SqlDataSource>
                     <div class="col">

                         <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                             <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                                 <asp:BoundField DataField="CreditCardNumber" HeaderText="Card Number" ReadOnly="True" SortExpression="CreditCardNumber" />
                                 <asp:BoundField DataField="Limit" HeaderText="Limit" SortExpression="Limit" />
                                 <asp:BoundField DataField="ExpityDate" HeaderText="Expiry Date" SortExpression="ExpityDate" DataFormatString="{0:dd/MM/yyyy} " />
                                 <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" SortExpression="AccountNumber" />
                                 <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                 <asp:BoundField DataField="CreditCardStatus" HeaderText="Credit Card Status" SortExpression="CreditCardStatus" />
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
