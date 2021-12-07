<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerUserManagement.aspx.cs" Inherits="OnlineBankingAzure.BankerUserManagement" %>
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
    <a class="nav-link active" aria-current="page" href="#">All Users</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="BankerInactiveAccount.aspx">All Inactive Users</a>
  </li>
  
</ul>
                       </div>

                   <br />

                  
                  

                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Customer Detail</h3>
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
                         <label>User ID</label>
                        <div class="form-group">
                            <div class="input-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="User ID" ></asp:TextBox>
                            <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button3_Click"  />
                        </div>
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
                     <div class="col">
                               <label >Email ID</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Email" placeholder="Email ID" ></asp:TextBox>

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
                     

                         <div class="col-md-4">
                          <label>SIN</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="SIN"></asp:TextBox>
                        </div>
                        
                     </div>


                    <div class="col-md-5 form-group" >

                                <label >Account Status</label>
                                <div class="input-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-primary" BackColor="Green" Width="15%" Text="A" runat="server" OnClick="LinkButton1_Click" ><i class="bi bi-check2-square"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" class="btn btn-primary" Width="15%" Text="D" runat="server" OnClick="LinkButton2_Click" BackColor="#CC0000"><i class="bi bi-x-circle"></i></asp:LinkButton>
                                    


                                </div>

                            </div>
                      
                      

                        

                  </div>
                   <br />

                   


                 <div class="row">
                     <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                         <asp:Button class="btn btn-primary" ID="Button1"  runat="server" Text="Update" OnClick="Button1_Click"  />
                        

                     

                      
                         <asp:Button class="btn btn-danger" ID="Button2" runat="server" Text="Remove Account" OnClick="Button2_Click"   />
                        </div>
                        
                     


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
                           <h3>Customer List</h3>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   

                   <div class="row">
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankingAzure_db1ConnectionString %>" SelectCommand="SELECT * FROM [CustomerDetail]"></asp:SqlDataSource>
                     <div class="col">

                         <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                             <Columns>
                                 <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                                 <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                 <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                 <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                 <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                                 <asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="PostalCode" />
                                 <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                                 <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                 <asp:BoundField DataField="SIN" HeaderText="SIN" SortExpression="SIN" />
                                 <asp:BoundField DataField="AccountStatus" HeaderText="Account Status" SortExpression="AccountStatus" />
                             </Columns>
                         </asp:GridView>
                        
                     </div>
                  </div>

                 

                   









           


</div>
                        
                        
</div>
</div>
                        
                        
        </div>




   </div>
          </div>


</asp:Content>
