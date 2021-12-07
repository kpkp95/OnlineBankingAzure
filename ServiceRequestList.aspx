<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ServiceRequestList.aspx.cs" Inherits="OnlineBankingAzure.ServiceRequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container">
         <div class="row">
                 <div class="col mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Service Request List</h4>
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
