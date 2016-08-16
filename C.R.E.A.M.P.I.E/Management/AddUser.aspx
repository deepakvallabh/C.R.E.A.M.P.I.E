<%@ Page Title="Add User" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddUser.aspx.vb" Inherits="C.R.E.A.M.P.I.E.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container-fluid">
        <h1>Add User</h1>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtFName">First Name </label>
                <asp:TextBox runat="server" ID="txtFName" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtLName">Last Name </label>
                <asp:TextBox runat="server" ID="txtLName" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="siteAddress" CssClass="text-danger" ErrorMessage="The site address is required." />--%>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtEmail">Email Address </label>
                <asp:TextBox runat="server" ID="txtEmail" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtPassword">Password </label>
                <asp:TextBox runat="server" ID="txtPassword" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="ddldAuth_Level">Authorisation Level </label>
                <asp:DropDownList ID="ddlAuth_Level" CssClass="form-control" runat="server">
                    <asp:ListItem Text="--Select Authorisation Level"></asp:ListItem>
                    <asp:ListItem Text="Technician" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Helpdesk" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Manager" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <label for="txtCellNumber">Cellphone Number </label>
                <asp:TextBox runat="server" ID="txtCellNumber" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <asp:LinkButton runat="server" id="btnNewUser" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                    Add User
                </asp:LinkButton>
            </div>
            <div class="col-sm-4">
                <asp:LinkButton runat="server" id="btnBack" cssclass="btn btn-default btn-lg" PostBackUrl="~/Management/ManageUsers.aspx" style="float:right">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Back
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
