<%@ Page Title="Reports" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reports.aspx.vb" Inherits="C.R.E.A.M.P.I.E.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script async defer src="http://maps.googleapis.com/maps/api/js?key=AIzaSyC6A18aU7RXBqDK1kD4--pLKoOklv1brqU&callback=initMap"></script>
    <br />
  <ul class="nav nav-pills nav-justified">
  <li class="active"><a data-toggle="pill" href="#Tickets">Tickets</a></li>
  <li><a data-toggle="pill" href="#Customers">Customers</a></li>
  <li><a data-toggle="pill" href="#Technicians">Technicians</a></li>
  <li><a data-toggle="pill" href="#Sales">Sales</a></li>
</ul>
    <br />
    <div class="container">
  <div class="row">
      <div class="col-sm-10">
  <div class="tab-content">
  
  <div id="Tickets" class="tab-pane fade in active">
    <h3>Tickets</h3>
    <p>need to inspect spacing for these tabs - this will be used for reports info for management</p>
      <div class="col-sm-7">
      
      <%--<ajaxToolkit:BarChart ID="bcJobType" runat="server" ChartHeight="300" ChartWidth = "450"
    ChartType="StackedColumn" ChartTitleColor="#0E426C" ChartTitle="Service requests past 6 months" Visible = "true"
    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB" CategoriesAxis="March,April,May,June,July,August">
          <Series>
            <ajaxtoolkit:barchartseries Name="Email Support" BarColor="Red" data="2">                
            </ajaxtoolkit:barchartseries>
            <ajaxtoolkit:barchartseries Name="Hardware Support" BarColor="Green" data="1">                
            </ajaxtoolkit:barchartseries>
            <ajaxtoolkit:barchartseries Name="Software Support" BarColor="Blue" data="4">                
            </ajaxtoolkit:barchartseries>
              <ajaxtoolkit:barchartseries Name="Malware Support" BarColor="Yellow" data="2">                
            </ajaxtoolkit:barchartseries>
              <ajaxtoolkit:barchartseries Name="Disaster Recovery" BarColor="Black" data="1">                
            </ajaxtoolkit:barchartseries>
        </Series>
</ajaxToolkit:BarChart>--%>
          <div>
              <ajaxToolkit:BarChart ID="BarChart1" runat="server" DataSourceID="SqlDataSource1" ChartType="StackedColumn">
                  
              </ajaxToolkit:BarChart>

        

        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT SUM(Total) AS TotalTicketsPM, Type, DATE FROM
(SELECT        JobType.Type, COUNT(JobTicket.JobType) AS total, DatePart(month, JobTicket.OpenedDate) AS DATE
FROM            JobTicket INNER JOIN
                         JobType ON JobType.Id = JobTicket.JobType
WHERE [OpenedDate] BETWEEN '02/06/2016' AND '08/06/2016'
GROUP BY JobType.Type, JobTicket.OpenedDate) As TPM GROUP BY DATE, TYPE" ></asp:SqlDataSource>
    </div>
          </div>
      <div class="col-sm-5">
          <ajaxToolkit:PieChart ID="pcCurrentTickets" runat="server" ChartTitle="Status of current tickets">
              
          </ajaxToolkit:PieChart>
      </div>
      </div>
  <div id="Customers" class="tab-pane fade">
    <h3>Customers</h3>
    <p>Some content in menu 1.</p>
  </div>
  <div id="Technicians" class="tab-pane fade">
    
      <div class="col-sm-3">
          <h3>Technicians</h3>
          <div class="list-group" id="lgTechnicians" runat="server">
  <a href="#" class="list-group-item">Berry Smith</a>
  <a href="#" class="list-group-item">Arnold de Kort</a>
  <a href="#" class="list-group-item">Lorem</a>
  <a href="#" class="list-group-item">Ipsum</a>
</div>
      </div>
      <script>
          function initMap() {
              var mapDiv = document.getElementById('googleMap');
              var map = new google.maps.Map(mapDiv, {
                  center: { lat: -26.195246, lng: 28.034088 },
                  zoom: 8
              });
          };
          </script>
      <div class="col-sm-9">
          <br /> <br /> <br />
          <div id="googleMap" style="width:100%;height:250px;"></div>
      </div>
      
  </div>
      <div id="Sales" class="tab-pane fade">
      <h3>Sales</h3>

      </div>
          </div>
      
      </div>
      <div class="col-sm-2">
      <h3>Averages</h3>
          <div class="list-group">
  <a href="#" class="list-group-item list-group-item-success">Average CSI</a>
  <a href="#" class="list-group-item list-group-item-info">Average TPI</a>
  <a href="#" class="list-group-item list-group-item-warning">Recall Percent</a>
  <a href="#" class="list-group-item list-group-item-danger">Average Service Completion Time</a>
  <a href="#" class="list-group-item list-group-item-danger">Average Response Time</a>
</div>
          
          </div>
      
   </div>
        
</div>

</asp:Content>
