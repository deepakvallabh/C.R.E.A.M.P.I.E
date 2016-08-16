<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewTicket.aspx.vb" Inherits="C.R.E.A.M.P.I.E.ViewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Job Ticket: 
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
                <label for="txtAssignedTech">Assigned Technician </label>
                <asp:TextBox runat="server" ID="txtAssignedTech" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
            <div class="col-sm-4">
                <label for="txtTechCell">Technician Cellphone number </label>
                <asp:TextBox runat="server" ID="txtTechCell" ReadOnly="true" cssClass="form-control" style="height:34px; width:100%; max-width:none" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="ddlJobType">Job Type </label>
                <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control" style="height:34px; width:100%; max-width:none" >
                    <asp:ListItem Text="--Select Support Area--"></asp:ListItem>
                    <asp:ListItem Text="Email support" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Hardware support" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Software support" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Malware support" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Disaster recover" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <label for="ddlPriority">Job Priority </label>
                <asp:DropDownList ID="ddlPriority" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server">
                    <asp:ListItem Text="--Select Job Priority--"></asp:ListItem>
                    <asp:ListItem Text="Project" Value="0"></asp:ListItem>
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
                
                <asp:TextBox ID="txtJobDesc" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" 
                    Rows="5" style="max-width:100%"></asp:TextBox>
            </div>
        </div>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="siteAddress" CssClass="text-danger" ErrorMessage="The site address is required." />--%>
        <br />
        
        <div class="row">
            <div class="col-sm-3">
                <asp:LinkButton runat="server" id="btnUpdateTicket" onclick="UpdateTicket" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-floppy-saved" aria-hidden="true"></span>
                    Update Job Ticket
                </asp:LinkButton>
            </div>
            <div class="col-sm-3">
                <asp:LinkButton runat="server" id="btnDeleteTicket" OnClick="DeleteTicket" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-trash" aria-hidden="true"></span> Delete Job Ticket
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
