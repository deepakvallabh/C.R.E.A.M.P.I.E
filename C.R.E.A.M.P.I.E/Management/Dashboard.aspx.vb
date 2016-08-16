Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ManageUsers(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/ManageUsers.aspx")
    End Sub
    Protected Sub ManageTickets(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/ManageTickets.aspx")
    End Sub
    Protected Sub Reports(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/Reports")
    End Sub
End Class