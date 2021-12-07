<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="OnlineBankingAzure.UserSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
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
                           <h3>Your Detail</h3>
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
                         <label>UserID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="UserID"></asp:TextBox>
                        </div>
                        
                     </div>
                     
                      
                      <div class="col-md-4">
                         <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                        
                     </div>


                      <div class="col-md-4">
                          <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>

                      
                       
                     </div>
                

                   


                 <div class="row">
                    <div class="col-md-6">
                         <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-6">
                          <label>SIN</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="SIN" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>
                  </div>


                      
                        
                     
                  </div>

                   <div class="row">
                            <div class="col">
                                
                                   <label >Full Address</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="MultiLine" placeholder="Full Address" Rows="2" ></asp:TextBox>

                                   </div>
                               
                            </div>

                         </div>


                  <div class="row">
                     <div class="col-md-4">
                         <label>City</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="City" ></asp:TextBox>
                        </div>

                     </div>

                      <div class="col-md-4">
                         <label>State</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="State" ></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-4">
                         <label>Postal Code</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Pin Code" ></asp:TextBox>
                        </div>
                        
                     </div>
                      
                      
                  </div>


                 




                


                    


                  






                   


                    <div class="row">
                       
                         
                        <div class="d-grid gap-2">
                            
                           <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="SignUp" OnClick="Button1_Click" />
                                
                        </div>
                        
                        
                     </div>

                   









                  
               
            </div>
            
         </div>
      </div>
   </div>

</asp:Content>
