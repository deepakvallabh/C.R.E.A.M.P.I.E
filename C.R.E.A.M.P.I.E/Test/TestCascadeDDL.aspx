<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TestCascadeDDL.aspx.vb" Inherits="C.R.E.A.M.P.I.E.TestCascadeDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span style ="font-family:Arial">Select Customer : </span>
<asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged">
<asp:ListItem Text = "--Select Customer--" Value = ""></asp:ListItem>
</asp:DropDownList>
 
<br /><br />
<span style ="font-family:Arial">Select Site Address : </span>
<asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack = "true"
Enabled = "false"  OnSelectedIndexChanged="ddlAddress_SelectedIndexChanged">
<asp:ListItem Text = "--Select Site Address--" Value = ""></asp:ListItem>
</asp:DropDownList>
 
<br /><br />

 
<br /><br />
<asp:Label ID="lblResults" runat="server" Text="" Font-Names = "Arial" />
</asp:Content>
