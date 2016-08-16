<%@ Page Title="Customer Overview" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CustomerOverview.aspx.vb" Inherits="C.R.E.A.M.P.I.E.CustomerOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %>.</h1>
    <table class="table" style="width: 100%">
        <tr>
            <td>
                 <div id="displayCustomers" runat="server">
                     <h2>Manage customers</h2>
                     <asp:GridView ID="grdvCustomers" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
                          <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:HyperLinkField Text="Select" 
                            DataNavigateUrlFields="Id"
                            DataNavigateUrlFormatString="~\Customers\CustomerDetails.aspx?ID={0}" />
                         </Columns>
                          <EditRowStyle BackColor="#7C6F57" />
                          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#03A5D1" Font-Bold="False" ForeColor="White" />
                          <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#E3EAEB" />
                          <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F8FAFA" />
                          <SortedAscendingHeaderStyle BackColor="#246B61" />
                          <SortedDescendingCellStyle BackColor="#D4DFE1" />
                          <SortedDescendingHeaderStyle BackColor="#15524A" />
                     </asp:GridView>
                 </div>
            </td>
            <td>
                <div id="displayCustomersWithOpenTickets" runat="server">
                    <h2>Open Tickets</h2>
                     <asp:GridView ID="grdvCustomersTicketsOpen" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
                          <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:HyperLinkField Text="Select" 
                            DataNavigateUrlFields="Id"
                            DataNavigateUrlFormatString="~\Ticketing\TicketDetails.aspx?ID={0}" />
                         </Columns>
                          <EditRowStyle BackColor="#7C6F57" />
                          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#03A5D1" Font-Bold="False" ForeColor="White" />
                          <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#E3EAEB" />
                          <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F8FAFA" />
                          <SortedAscendingHeaderStyle BackColor="#246B61" />
                          <SortedDescendingCellStyle BackColor="#D4DFE1" />
                          <SortedDescendingHeaderStyle BackColor="#15524A" />
                     </asp:GridView>
                 </div>
            </td>
        </tr>
        </table>
    <div class="container" style="width:50%; margin:auto, 0">
            
            <%--<div class="col-sm-6">
            <asp:LinkButton ID="btnAddCustomer" runat="server" OnClick="AddCustomer" Text="Add Job Ticket" CssClass="btn btn-default btn-lg"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Add Job Ticket</asp:LinkButton>
            </div>
                --%>
            <div class="col-sm-6">

            <Button ID="btnBack" onclick="window.history.go(-1); return false;" Class="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Back
            </Button>
            </div>
            
        </div>
</asp:Content>
