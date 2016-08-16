Public Class CustomerFeedback
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim CustID, TechID, Rating, TechnicianPerformance, PromptResponse, RecommendProbability As Integer
        CustID = Request.QueryString("CID")
        TechID = Request.QueryString("TID")
        ' Rating = 
    End Sub
End Class