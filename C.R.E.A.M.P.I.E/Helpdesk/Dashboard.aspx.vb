Public Class Dashboard1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Customers(sender As Object, e As EventArgs)
        Response.Redirect("~/Customers/CustomerOverview")
    End Sub
    Protected Sub JobTickets(sender As Object, e As EventArgs)
        Response.Redirect("~/Ticketing/TicketOverview")
    End Sub
End Class