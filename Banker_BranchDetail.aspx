<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Banker_BranchDetail.aspx.cs" Inherits="OnlineBankingAzure.Banker_BranchDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="container-fluid">
            


         
             <div class="row">
                <div class="col mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Branch Detail</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankingAzure_db1ConnectionString2 %>" SelectCommand="SELECT * FROM [BranchInfo]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                            <Columns>
                                <asp:BoundField DataField="BranchID" HeaderText="BranchID" SortExpression="BranchID" />
                                <asp:BoundField DataField="BranchName" HeaderText="BranchName" SortExpression="BranchName" />
                                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            </Columns>
                         </asp:GridView>
                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankingAzure_db1ConnectionString2 %>" SelectCommand="SELECT * FROM [BranchInfo]"></asp:SqlDataSource>
                     </div>
                  </div>
               </div>
            </div>
         </div>
               </div>
   
</div>

</asp:Content>
