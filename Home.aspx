<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineBankingAzure.Home" %>

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
                            <a class="nav-link" href="Home.aspx">Home</a>
                        </li>

                    </ul>
                    <ul class="navbar-nav ms-auto">
                        <li class="nav-item">
                            <asp:LinkButton class="nav-link" ID="LinkButton1" runat="server" Visible="True" OnClick="LinkButton1_Click" >User Login</asp:LinkButton>
                        </li>
                        <li class="master_li">
                            <asp:LinkButton class="nav-link asp_link" ID="LinkButton6" runat="server" Visible="True" OnClick="LinkButton6_Click">Sign Up</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton class="nav-link" ID="LinkButton3" runat="server" Visible="False">Logout</asp:LinkButton>
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
                        <div class="card-body mx-auto">

                           


                            <img src="img/banking.jpg" class="img-fluid"/>




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
