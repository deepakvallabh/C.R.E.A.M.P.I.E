<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TicketDetails.aspx.vb" Inherits="C.R.E.A.M.P.I.E.TicketDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Job Ticket: 
        <asp:Label ID="lblTicket" runat="server" Text="[Job ticket ID here]"></asp:Label>
    </h1>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label for="txtClientName">Client Name </label>
                <asp:TextBox runat="server" ID="txtClientName" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtSiteAddress">Site Address </label>
                <asp:TextBox runat="server" ID="txtSiteAddress" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtContactFullName">Contact Person</label>
                <asp:TextBox runat="server" ID="txtFullName" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtContactEmail">Contact Email Address </label>
                <asp:TextBox runat="server" ID="txtContactEmail" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtOpenedDate">Ticket was opened on </label>
                <asp:TextBox runat="server" ID="txtOpenedDate" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtJobStatus">Job Status </label>
                <asp:TextBox runat="server" ID="txtJobStatus" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtJobType">Job Type </label>
                <asp:TextBox runat="server" ID="txtJobType" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="ddljobPriority">Priority</label>
                <asp:DropDownList ID="ddlPriority" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server">
                    <asp:ListItem Text="Low" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Standard" Value="2"></asp:ListItem>
                    <asp:ListItem Text="High" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Critical" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-8">
                <label for="txtjobDesc">Description</label>
                
                <asp:TextBox ID="txtJobDesc" runat="server" CssClass="form-control" TextMode="MultiLine" 
                    Rows="5" style="max-width:100%"></asp:TextBox>
            </div>
        </div>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="siteAddress" CssClass="text-danger" ErrorMessage="The site address is required." />--%>
        <br />
        <div class="row">
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
        </div>
    </div>
</asp:Content>
