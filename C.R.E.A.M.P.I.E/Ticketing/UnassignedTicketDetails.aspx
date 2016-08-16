<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UnassignedTicketDetails.aspx.vb" Inherits="C.R.E.A.M.P.I.E.UnassignedTicketDetails" %>
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
                <label for="txtOpenedDate">Ticket was opened on </label>
                <asp:TextBox runat="server" ID="txtOpenedDate" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtJobStatus">Job Status </label>
                <asp:TextBox runat="server" ID="txtJobStatus" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="txtJobType">Job Type </label>
                <asp:TextBox runat="server" ID="txtJobType" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtJobPriority">Job Priority </label>
                <asp:TextBox runat="server" ID="txtJobPriority" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-8">
                <label for="txtjobDesc">Description</label>
                
                <asp:TextBox ID="txtJobDesc" ReadOnly="true" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" 
                    Rows="5" style="max-width:100%"></asp:TextBox>
            </div>
        </div>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="siteAddress" CssClass="text-danger" ErrorMessage="The site address is required." />--%>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <asp:LinkButton runat="server" id="btnAccept" onclick="AcceptTicket" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                    Accept Job Ticket
                </asp:LinkButton>
            </div>
            <div class="col-sm-4">
                <asp:LinkButton onclick="Back" runat="server" id="btnBack" cssclass="btn btn-default btn-lg" style="float:right">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Back
                </asp:LinkButton>
             </div>
        </div>
    </div>
</asp:Content>
