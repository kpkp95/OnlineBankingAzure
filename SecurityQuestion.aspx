<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SecurityQuestion.aspx.cs" Inherits="OnlineBankingAzure.SecurityQuestion" %>
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
                        
                         <div class="dropdown"">
                            <asp:DropDownList class="form-select form-select mb-3" ID="DropDownList2" runat="server">
                                 <asp:ListItem Text="In what city were you born?" Value="In what city were you born?" />
                                
                                <asp:ListItem Text="What is the name of your favorite pet?" Value="What is the name of your favorite pet?" />

                                <asp:ListItem Text="What high school did you attend?" Value="What high school did you attend?" />

                                <asp:ListItem Text="What is your mother's maiden name?" Value="What is your mother's maiden name?" />

                                <asp:ListItem Text="What was your favorite food as a child?" Value="What was your favorite food as a child?" />
                                
                                <asp:ListItem Text="What was the make of your first car?" Value="What was the make of your first car?" />

                                <asp:ListItem Text="Where did you meet your spouse?" Value="Where did you meet your spouse?" />

                                <asp:ListItem Text="What Is your favorite book?" Value="What Is your favorite book?" />
                             
                               



                            </asp:DropDownList>
                           
                        </div>
                        <label>Answer</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Your Answer" TextMode="SingleLine"></asp:TextBox>
                        </div>
                         </div>

                     </div>
                   

                         <div class="d-grid gap-2">
  <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Confirm" OnClick="Button2_Click"     />
</div>
                          
                       
                            
                           
                        
                        
                     
                  </div>
               </div>
            </div>
           
         </div>
      </div>


</asp:Content>
