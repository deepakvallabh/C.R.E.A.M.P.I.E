<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="C.R.E.A.M.P.I.E.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Your contact page.</p>
    <script async defer src="http://maps.googleapis.com/maps/api/js?key=AIzaSyC6A18aU7RXBqDK1kD4--pLKoOklv1brqU&callback=initMap"></script>
    <script>
              //function initialize() {
              //    var mapProp = {
              //        center: new google.maps.LatLng(-26.195246, 28.034088),
              //        zoom: 7,
              //        mapTypeId: google.maps.MapTypeId.ROADMAP
              //    };
              //    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
              //}
              //google.maps.event.addDomListener(window, 'load', initialize);
          function initMap() {
              var mapDiv = document.getElementById('googleMap');
              var map = new google.maps.Map(mapDiv, {
                  center: { lat: -26.195246, lng: 28.034088 },
                  zoom: 8
              });
          };
          $(document).ready(function(){
          initMap();
          });
          </script>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100

    </address>

    <address>
        <strong>Support:</strong><a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
    <div id="googleMap" style="width:100%;height:450px;"></div>
</asp:Content>
