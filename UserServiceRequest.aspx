<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserServiceRequest.aspx.cs" Inherits="OnlineBankingAzure.UserServiceRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container">
            


         
             <div class="row">
                <div class="col-md-6  mx-auto">
            <div class="card">
               <div class="card-body">


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
                            <div class="col-md-12 mx-auto">
                                
                                   <label >Service Type</label>
                                   <div class="dropdown"">
                            <asp:DropDownList class="form-select form-select mb-3" ID="DropDownList1" runat="server">
                                 
                                <asp:ListItem Text="Block Credit Card" Value="Block Credit Card" />
                                <asp:ListItem Text="Change Address" Value="Change Address" />
                                 <asp:ListItem Text="Cheque Book" Value="Cheque Book" />
                                <asp:ListItem Text="Reissue of lost Credit Card" Value="Reissue of lost Credit Card" />
                                <asp:ListItem Text="Credit card limit increase" Value="Credit card limit increase" />
                                 <asp:ListItem Text="Others" Value="Others" />
                             
                               



                            </asp:DropDownList>
                               
                            </div>

                         </div>
                       </div>

                   <br />



    
                         <div class="row">
                            <div class="col-md-12 mx-auto">
                                
                                   <label >Description</label>
                                   <div class="form-group">
                                       <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="MultiLine" placeholder="Description" Rows="2" ></asp:TextBox>
                                      
                                   </div>
                               
                            </div>

                         </div>
                   <br />



                    <div class="row">
                       
                         
                        <div class="d-grid gap-2">
                            
                           <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  />
                                
                        </div>
                        
                        
                     </div>


                   <div class="row">
                        <hr />
                            
                        </div> 

                    <div class="row">
                        <div class="col-4 mx-auto"> 
                            <asp:Button ID="Button6" class="btn btn-sm btn-block btn-dark" runat="server" Text="Previous Service Request" OnClick="Button6_Click"     />
                        </div> 
                  </div>   
                   
                         

                   





                   
               </div>
            </div>
         </div>
               </div>



         

   
</div>

</asp:Content>
