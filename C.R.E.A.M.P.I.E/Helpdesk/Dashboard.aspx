<%@ Page Title="Helpdesk Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.vb" Inherits="C.R.E.A.M.P.I.E.Dashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1><%: Title %>.</h1>
        <h2>Where would you like to go?</h2>
        <hr />
        <div class="col-md-4">
            <asp:LinkButton runat="server" OnClick="Customers" Text="Customers" CssClass="btn btn-default btn-lg" style="Font-Size:30px">
                <span class="glyphicon glyphicon-user" aria-hidden="true"></span> 
                Customers
            </asp:LinkButton>
            </div>
            <div class="col-md-4">
            <asp:Linkbutton runat="server" OnClick="JobTickets" Text="Job Tickets" cssclass="btn btn-default btn-lg" style="font-size:30px">
                    <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> 
                     Job Tickets
            </asp:Linkbutton>
            </div>
        </div>
</asp:Content>
