<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BankerServiceRequest.aspx.cs" Inherits="OnlineBankingAzure.BankerServiceRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">

                  

                   <br />

                  
                  

                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Service Request</h3>
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
                         <label>Service Request ID</label>
                        <div class="form-group">
                            <div class="input-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Service Request ID" ></asp:TextBox>
                            <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button3_Click"   />
                        </div>
                       </div>
                        
                     </div>
                     
                      
                      <div class="col-md-4">
                         <label>User ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                        </div>
                        
                     </div>

                      </div>



                   <div class="row">
                     <div class="col">
                               <label >Description</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="MultiLine" placeholder="Description" Rows="2" ReadOnly="True"></asp:TextBox>

                                   </div>
                            </div>
                  </div>


                   <div class="row">

                      <div class="col-md-6">
                          <label>Service Type</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Service Type" ReadOnly="True"></asp:TextBox>
                        </div>


                        
                     </div>

                       <div class="col-md-5 form-group" >

                                <label >Service Status</label>
                                <div class="input-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Service Status" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton3" class="btn btn-primary" BackColor="Green" Width="15%" Text="A" runat="server" OnClick="LinkButton1_Click" ><i class="bi bi-check2-square"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" class="btn btn-primary" Width="15%" Text="D" runat="server" OnClick="LinkButton2_Click" BackColor="#CC0000"><i class="bi bi-x-circle"></i></asp:LinkButton>
                                    


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
                           <h3>Service Request List</h3>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   

                   <div class="row">
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BankingSystemConnectionString %>" SelectCommand="SELECT * FROM [ServiceRequest]"></asp:SqlDataSource>
                     <div class="col">

                         <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ServiceRequestID">
                             <Columns>
                                 <asp:BoundField DataField="ServiceRequestID" HeaderText="ServiceRequest ID" SortExpression="ServiceRequestID" InsertVisible="False" ReadOnly="True" />
                                 <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                                 <asp:BoundField DataField="ServiceRequestType" HeaderText="ServiceRequest Type" SortExpression="ServiceRequestType" />
                                 <asp:BoundField DataField="ServiceRequestDescription" HeaderText="Description" SortExpression="ServiceRequestDescription" />
                                 <asp:BoundField DataField="ServiceStatus" HeaderText="Service Status" SortExpression="ServiceStatus" />
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
