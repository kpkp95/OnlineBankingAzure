<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerProfile.aspx.cs" Inherits="OnlineBankingAzure.BankerProfile" %>
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


                      <div class="col-md-4">
                         <label>Branch ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Email"></asp:TextBox>
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

                     

                      
                  </div>


                      
                        
                     
                  

                   <div class="row">
                            <div class="col-md-10">
                                
                                   <label >Full Address</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="MultiLine" placeholder="Full Address" Rows="2" ></asp:TextBox>

                                   </div>
                               
                            </div>

                         </div>


                  

                


                 <div class="row">
                       
                         
                        <div class="col">
                            <center>
                           <span class="badge rounded-pill bg-success">Login Credentials</span>
                                </center>
                        </div>
                        
                        
                     </div>

                <br />




                <div class="row">
                     <div class="col-md-4">
                         <label>User Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="User Name" ReadOnly="True"></asp:TextBox>
                        </div>
                        
                     </div>

                         <div class="col-md-4">
                          <label>Old Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Old Password" ReadOnly="True"></asp:TextBox>
                        </div>
                        
                     </div>
                      
                      

                        <div class="col-md-4">
                          <label>New Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        </div>
                        
                     </div>

                  </div>


                    


                  

                    <br />




                   


                    <div class="row">
                       
                         
                        <div class="d-grid gap-2">
                            
                           <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click"  />
                                
                        </div>
                        
                        
                     </div>

                  

                   









                  
               </div>
            </div>
            
         </div>
      </div>
   </div>

</asp:Content>
