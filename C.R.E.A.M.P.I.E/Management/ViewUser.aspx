<%@ Page Title="Manage User" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewUser.aspx.vb" Inherits="C.R.E.A.M.P.I.E.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit User:
        <asp:Label ID="lblUName" runat="server" Text="[Username Here]"></asp:Label>
    </h1>
    <div class="container-fluid">
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
                <label for="drpdAuth_Level">Authorisation Level </label>
                <asp:DropDownList ID="ddlAuth_Level" runat="server" CssClass="form-control" style="height:34px; width:100%; max-width:none" >
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
            <div class="col-sm-3">
                <asp:LinkButton runat="server" id="btnUpdateUser" onclick="UpdateUser" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-floppy-saved" aria-hidden="true"></span>
                    Update User
                </asp:LinkButton>
            </div>
            <div class="col-sm-3">
                <asp:LinkButton runat="server" id="btnDeleteUser" OnClick="DeleteUser" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-trash" aria-hidden="true"></span> Delete User
                </asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton onclick="Back" runat="server" id="btnBack" cssclass="btn btn-default btn-lg" style="float:right">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Back
                </asp:LinkButton>
             </div>
        </div>
    </div>
</asp:Content>
