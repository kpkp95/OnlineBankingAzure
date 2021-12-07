<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerDetailPage.aspx.cs" Inherits="OnlineBankingAzure.BankerDetailPage" %>
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
                           <h3>Enter your Information</h3>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                     
                      
                      <div class="col-md-6">
                         <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                        
                     </div>

                      <div class="col-md-6">
                          <label>Branch ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Branch ID" TextMode="Number"></asp:TextBox>
                        </div>
                        
                     </div>
                  </div>

                   


                 <div class="row">
                     <div class="col">
                               <label >Email ID</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Email" placeholder="Email ID" ></asp:TextBox>

                                   </div>
                            </div>
                  </div>


                      
                        
                     
                  </div>

                  
                      
                      
                  </div>


                  






                   


                    <div class="row">
                       
                         
                        <div class="d-grid gap-2">
                            
                           <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click"   />
                                
                        </div>
                        
                        
                     </div>

                   









                  
               
            
            
         </div>
      </div>
   </div>


</asp:Content>
