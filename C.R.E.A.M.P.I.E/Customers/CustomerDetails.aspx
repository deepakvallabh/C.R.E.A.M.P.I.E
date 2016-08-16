<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CustomerDetails.aspx.vb" Inherits="C.R.E.A.M.P.I.E.CustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customer: 
        <asp:Label ID="lblCustomer" runat="server" Text="[Customer ID here]"></asp:Label>
    </h1>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label for="txtClientName">Client Name </label>
                <asp:TextBox runat="server" ID="txtClientName" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtSiteAddress">Site Address </label>
                <asp:TextBox runat="server" ID="txtSiteAddress" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtContactFName">Contact Person First Name</label>
                <asp:TextBox runat="server" ID="txtFName" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtContactFName">Contact Person Last Name</label>
                <asp:TextBox runat="server" ID="txtLName" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtContactEmail">Contact Email Address</label>
                <asp:TextBox runat="server" ID="txtContactEmail" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtCSI">Customer Satisfaction Index</label>
                <asp:TextBox runat="server" ID="txtCSI" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="siteAddress" CssClass="text-danger" ErrorMessage="The site address is required." />--%>
        <br />
        <%--<div class="row">
            <div class="col-sm-3">
                <asp:LinkButton runat="server" id="btnCloseTicket" onclick="CloseTicket" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-check" aria-hidden="true"></span>
                    Close Job Ticket
                </asp:LinkButton>
            </div>
            <div class="col-sm-3">
                <asp:LinkButton runat="server" id="btnUpdate" onclick="UpdateTicket" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-floppy-saved" aria-hidden="true"></span>
                    Update Job Ticket
                </asp:LinkButton>
            </div>
            <div class="col-sm-2">
                <asp:LinkButton onclick="Back" runat="server" id="btnBack" cssclass="btn btn-default btn-lg" style="float:right">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Back
                </asp:LinkButton>
             </div>
        </div>--%>
    </div>
</asp:Content>
