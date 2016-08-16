<%@ Page Title="New ticket" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateTicket.aspx.vb" Inherits="C.R.E.A.M.P.I.E.CreateTicket" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- THIS SCRIPT WORKS WITH THE AUTOCOMPLETE TEXTBOX AND WEB SERVICE
        <script type="text/javascript">
        $(function () {
            CustomerAutoComplete();
        });
        function pageLoad() {
            initPageRequestManager();
        }
        function initPageRequestManager() {
            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                //re-bind jquery events         
                CustomerAutoComplete();
            });
        }

        function CustomerAutoComplete() {
            $("#<%=txtClientName.ClientID %>").autocomplete({
                autoFocus: true,
                source: function (request, response) {
                    var inputdata = "{'SearchText': '" + request.term + "'}";
                    $.ajax({
                        url: '<%=ResolveUrl("~/Ticketing/Customers.asmx/FetchCustomerNames") %>',
                        data: inputdata,
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },

                minLength: 1,
            });
        }
    </script>--%>
    <%--<script type="text/javascript">
    $(function () {
        $("[id$=txtClientName.ClientID]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/Ticketing/CreateTicket.aspx/GetCustomers") %>',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("[id$=hfCustomerId]").val(i.item.val);
            },
            minLength: 1
        });
    });  
</script>--%>
     
    <div class="container-fluid">
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
        <h1>Create a new job ticket</h1>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="ddlCustomers">Client Name</label> <!--Note height; width; and max-width custom set here to override css style !-->
                <%--<input id="txtClientName" class="form-control" type="text" style="height:34px; width:100%; max-width:none"/>--%>
                <asp:HiddenField ID="hfCustomerId" runat="server" />
                <%--<asp:TextBox ID="txtClientName" runat="server" CssClass="form-control" style="height:34px; width:100%; max-width:none"></asp:TextBox>
                <asp:AutoCompleteExtender ServiceMethod="FetchCustomerNames" ServicePath="~/Ticketing/Customers.asmx" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtClientName"  
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
                </asp:AutoCompleteExtender>--%>
                <asp:DropDownList ID="ddlCustomers" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged">
<asp:ListItem Text = "--Select Customer--" Value = ""></asp:ListItem>
</asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <label for="ddlAddress">Site Address</label> <!--Note height; width; and max-width custom set here to override css style !-->
                <%--<input id="siteAddress" type="text" class="form-control" style="height:34px; width:100%; max-width:none" />--%>

                <!-- Need to confirm which control type to use: html as above or asp as below !-->
                <%--<asp:TextBox runat="server" ID="siteAddress" cssClass="form-control" style="height:34px; width:100%; max-width:none" />--%>
                <asp:DropDownList ID="ddlAddress" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server" AutoPostBack = "true"
Enabled = "false" OnSelectedIndexChanged="ddlAddress_SelectedIndexChanged">
<asp:ListItem Text = "--Select Site Address--" Value = ""></asp:ListItem>
</asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAddress" InitialValue="--Select Site Address--" CssClass="text-danger" ErrorMessage="The site address is required." />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <label for="ddljobType">Job Type</label>

                <asp:DropDownList ID="ddlJobType" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server" Enabled = "false">
                    <asp:ListItem Text="--Select Support Area--"></asp:ListItem>
                    <asp:ListItem Text="Email support" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Hardware support" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Software support" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Malware support" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Disaster recover" Value="5"></asp:ListItem>
                </asp:DropDownList>
                
            </div>
            <div class="col-sm-4">
                <label for="ddljobPriority">Priority</label>
                <asp:DropDownList ID="ddlPriority" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server" Enabled = "false" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="--Select Job Priority--"></asp:ListItem>
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
        <span id="characters"></span>
        <br />
        <div class="row">
            <div class="col-sm-8">
                <asp:LinkButton runat="server" id="btnSubmit" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Submit Job Ticket
                </asp:LinkButton>

            </div>
        </div>
    </div>
    <script type="text/javascript">
     function Check(textBox, maxLength) {
          if (textBox.value.length > maxLength) {
               alert("Max characters allowed are " + maxLength);
               textBox.value = textBox.value.substr(0, maxLength);
          }
     }
</script>
</asp:Content>

