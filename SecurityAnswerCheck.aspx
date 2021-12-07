<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SecurityAnswerCheck.aspx.cs" Inherits="OnlineBankingAzure.SecurityAnswerCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Security Questions</h3>
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
                         <label>Question</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" ></asp:TextBox>

                        



                    <label>Answer</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Your Answer" TextMode="SingleLine"></asp:TextBox>
                        </div>
                         </div>

                     </div>

                   <label></label>

                         <div class="d-grid gap-2">
  <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Confirm" OnClick="Button2_Click"     />
</div>
                          
                       
                            
                           
                        
                        
                     
                  </div>
               </div>
            </div>
           
         </div>
      </div>

</asp:Content>
