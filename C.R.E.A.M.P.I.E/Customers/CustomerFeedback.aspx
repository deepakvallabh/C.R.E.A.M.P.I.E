<%@ Page Title="Review" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CustomerFeedback.aspx.vb" Inherits="C.R.E.A.M.P.I.E.CustomerFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Service Rating</h1><br />
    <h4>Please rate our service so that we may continue to improve your experience with us.
    </h4><hr />
    <script>
        $(document).on('ready', function(){
            $('#ServiceRating').rating({
                step: 1,
                starCaptions: {0.5: 'Poor', 1: 'Poor',1.5: 'Below Average', 2: 'Below Average',2.5: 'Average', 3: 'Average',3.5: 'Above Average', 4: 'Above Average',4.5: 'Excellent', 5: 'Excellent'},
                starCaptionClasses: { 0.5: 'text-danger', 1: 'text-danger', 1.5: 'text-warning', 2: 'text-warning', 2.5: 'text-info', 3: 'text-info', 3.5: 'text-primary', 4: 'text-primary', 4.5: 'text-success', 5: 'text-success' }
                //document.getElementById('nwLatHidden').value =}
            });
            document.getElementById("srServiceRating").val
        });
        $(document).on('ready', function () {
            $('#TechnicianPerformance').rating({
                step: 1,
                starCaptions: { 0.5: 'Poor', 1: 'Poor', 1.5: 'Below Average', 2: 'Below Average', 2.5: 'Average', 3: 'Average', 3.5: 'Above Average', 4: 'Above Average', 4.5: 'Excellent', 5: 'Excellent' },
                starCaptionClasses: { 0.5: 'text-danger', 1: 'text-danger', 1.5: 'text-warning', 2: 'text-warning', 2.5: 'text-info', 3: 'text-info', 3.5: 'text-primary', 4: 'text-primary', 4.5: 'text-success', 5: 'text-success' }
            });
        });
        $(document).on('ready', function () {
            $('#PromptResponse').rating({
                step: 1,
                starCaptions: { 0.5: 'Unnacceptable!', 1: 'Unnacceptable!', 1.5: 'Below Average', 2: 'Pretty Slow', 2.5: 'Average', 3: 'On Time', 3.5: 'Above Average', 4: 'Pretty Fast', 4.5: 'Excellent', 5: 'Lightning Speed!' },
                starCaptionClasses: { 0.5: 'text-danger', 1: 'text-danger', 1.5: 'text-warning', 2: 'text-warning', 2.5: 'text-info', 3: 'text-info', 3.5: 'text-primary', 4: 'text-primary', 4.5: 'text-success', 5: 'text-success' }
            });
        });
        $(document).on('ready', function () {
            $('#RecommendProbability').rating({
                step: 1,
                starCaptions: { 0.5: 'Unnacceptable!', 1: 'Never!', 1.5: 'Below Average', 2: 'Doubt it', 2.5: 'Average', 3: 'Maybe', 3.5: 'Above Average', 4: 'Probably', 4.5: 'Excellent', 5: 'Definitely!' },
                starCaptionClasses: { 0.5: 'text-danger', 1: 'text-danger', 1.5: 'text-warning', 2: 'text-warning', 2.5: 'text-info', 3: 'text-info', 3.5: 'text-primary', 4: 'text-primary', 4.5: 'text-success', 5: 'text-success' }
            });
        });
        $(':checkbox').checkboxpicker();
    </script> 
    
    
    <div>  
         
        <div class="row">  
            <div class="col-lg-12">
                <label for="ProblemResolved" class="control-label" style="font-size:20px">Was your problem resolved?:</label>
                
                <div class="btn-group" data-toggle="buttons">
      <label class="btn btn-primary active">
        Yes
      </label>
      <label class="btn btn-primary">
       No
      </label>
    </div>
            </div>
            <hr />
<div class="col-lg-12" id="srRating">
    <label for="ServiceRating" class="control-label" style="font-size:20px">Overall Service Received:</label>
    <input id="ServiceRating" value="3" type="number" class="rating-loading" data-size="sm">
    <asp:HiddenField ID="srServiceRating" runat="server" />
</div>  
     <hr />
     <div class="col-lg-12">
         <label for="TechnicianPerformance" class="control-label" style="font-size:20px">Technician's Performance:</label>
      <input id="TechnicianPerformance" value="3" type="number" class="rating-loading" data-size="sm"> 
     </div>
  
    <hr>  
<div class="col-lg-12">
    <label for="PromptResponse" class="control-label" style="font-size:20px">Did we respond in a timely manner? (1:Unnacceptable! - 5:Lightning Speed!)</label>
    <input id="PromptResponse" value="3" type="number" class="rating-loading" data-size="sm"> 
</div>  
     <hr />
<div class="col-lg-12">
    <label for="ReccomendProbability" class="control-label" style="font-size:20px">Would you recommend our services? (1:Never! - 5:Definitely!)</label>
    <input id="RecommendProbability" value="3" type="number" class="rating-loading" data-size="sm"> 
</div>
    <hr>  
        </div>  
      <div class="row">
            <div class="col-sm-8">
                <label for="txtjobDesc">Description</label>
                
                <asp:TextBox ID="txtCustom" runat="server" CssClass="form-control" Enabled="true" TextMode="MultiLine" 
                    Rows="5" style="max-width:100%"></asp:TextBox>
            </div>
        </div>
        <span id="characters"></span>
        <br />
        <div class="row">
            <div class="col-sm-8">
                <asp:LinkButton runat="server" id="btnSubmit" cssclass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Submit Feedback
                </asp:LinkButton>

            </div>
        </div>
    </div>  
         <asp:HiddenField ID="hdfRatingValue" runat="server" />  
</asp:Content>
