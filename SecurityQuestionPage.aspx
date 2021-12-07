<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityQuestionPage.aspx.cs" Inherits="OnlineBankingAzure.SecurityQuestionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.6.1/font/bootstrap-icons.css">
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
       
       <nav class="navbar navbar-expand-md navbar-dark bg-dark">
    <div class="container-fluid">
        <a class="navbar-brand abs" href="#">eBanking</a>
        <button class="navbar-toggler ms-auto" type="button" data-bs-toggle="collapse" data-bs-target="#collapseNavbar">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse" id="collapseNavbar">
            <ul class="navbar-nav">
                <li class="nav-item active">
                    <a class="nav-link" href="HomePage.aspx">Home</a>
                </li>
                
            </ul>
            <ul class="navbar-nav ms-auto">
                <li class="nav-item">
                    <asp:LinkButton class="nav-link" ID="LinkButton1" runat="server" Visible="True" >User Login</asp:LinkButton>
                </li>
                <li class="master_li">
                <asp:LinkButton class="nav-link asp_link" ID="LinkButton6" runat="server"  Visible="False" >Sign Up</asp:LinkButton>
              </li>
                <li class="nav-item">
                    <asp:LinkButton class="nav-link" ID="LinkButton3" runat="server"  Visible="False">Logout</asp:LinkButton>
                </li>
                <li class="nav-item">
                    <asp:LinkButton class="nav-link" ID="LinkButton7" runat="server" Visible="False">Hello user</asp:LinkButton>
                </li>
                
            </ul>
        </div>
    </div>
</nav>



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
  <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Confirm" style="height: 32px" OnClick="Button2_Click"      />
</div>
                          
                       
                            
                           
                        
                        
                     
                  </div>
               </div>
            </div>
           
         </div>
      </div>
   




        

    </form>
    
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js" integrity="sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js" integrity="sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13" crossorigin="anonymous"></script>
</body>
</html>
