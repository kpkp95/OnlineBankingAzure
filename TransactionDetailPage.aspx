<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="OnlineBankingAzure.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container-fluid">

     
        <div class="row">
            <div class="col-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                        <div class="col-3">
                            Start Date:<asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" TextMode="Date"></asp:TextBox>
                            
                        </div>

                        <div class="col-3" > 
                            End Date:<asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" TextMode="Date"></asp:TextBox>
                        </div> 
                            
                                <br />
                            <div class="col-3 "> 
                                
                                <br />
                                
                                
                            <asp:Button ID="Button5" class="form-control bbtn btn-dark" runat="server" Text="Search" OnClick="Button5_Click"   />
                        </div> 

                    </div>
                        
                                <br />


                    <div class="row">
                        <hr />
                            
                        </div> 

                    <div class="row">
                        <div class="col-4 mx-auto"> 
                            <asp:Button ID="Button6" class="btn btn-sm btn-block btn-dark" runat="server" Text="Transaction for last week" OnClick="Button6_Click"    />
                        </div> 


                        <div class="col-4 mx-auto"> 
                            <asp:Button ID="Button1" class="btn btn-sm btn-block btn-dark" runat="server" Text="All Transaction" OnClick="Button1_Click"     />
                        </div> 
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
                           <h4>Transaction Details</h4>
                        </center>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">

                       <div class="col">
                           <asp:GridView  class="table table-hover table-bordered" ID="GridView1" runat="server"></asp:GridView>
                </div>
                </div>
                   </div>
                </div>





        </div>
        </div>
         
 </div>   


</asp:Content>
