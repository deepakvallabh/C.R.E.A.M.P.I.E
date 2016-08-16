Imports System.Data.SqlClient

Public Class CustomerOverview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("Username") Is Nothing Then
                grdvCustomersPopulate()
                grdvCustomersTicketsOpenPopulate()
            End If
        End If
    End Sub

    Private Sub grdvCustomersPopulate()
        Dim cmd As New SqlCommand
        Dim Adapter As New SqlDataAdapter
        Dim Data As New DataTable
        Dim SQL As String
        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

        If Session("Auth_Level") <= 2 Then
            grdvCustomers.Visible = True
            SQL = "SELECT * FROM Customer"
        ElseIf Session("Auth_Level") = 3 Then
            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        End If

        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQL

        Adapter.SelectCommand = cmd
        Adapter.Fill(Data)

        grdvCustomers.DataSource = Data
        grdvCustomers.DataBind()
    End Sub

    Private Sub grdvCustomersTicketsOpenPopulate()
        Dim cmd As New SqlCommand
        Dim Adapter As New SqlDataAdapter
        Dim Data As New DataTable
        Dim SQL As String
        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

        If Session("Auth_Level") <= 2 Then
            grdvCustomersTicketsOpen.Visible = True
            SQL = "SELECT t1.[Id], t1.[BusinessName], t1.[Current Tickets], coalesce(t2.[Unassigned Tickets], 0) as [Unassigned Tickets]
from 
    (SELECT C.Id, C.BusinessName, COUNT(J.Id) AS 'Current Tickets' FROM Customer C JOIN JobTicket J ON J.CustomerID = C.Id WHERE J.IsOpen=1 GROUP BY C.Id, C.BusinessName) t1
JOIN
    (SELECT C.Id, COUNT(J.Id) AS 'Unassigned Tickets' FROM Customer C JOIN JobTicket J ON J.CustomerID=C.Id WHERE J.AssignedTechID IS NULL GROUP BY C.Id) t2
on
    t1.Id = t2.Id"
        ElseIf Session("Auth_Level") = 3 Then
            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        End If

        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQL

        Adapter.SelectCommand = cmd
        Adapter.Fill(Data)

        grdvCustomersTicketsOpen.DataSource = Data
        grdvCustomersTicketsOpen.DataBind()
    End Sub

    Private Sub grdvCustomers_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvCustomers.RowCreated
        e.Row.Cells(1).Visible = False

        Dim nRows As Integer = e.Row.Cells.Count
        For i As Integer = 0 To nRows - 1
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
            End If
        Next

    End Sub

    Private Sub grdvCustomersTicketsOpen_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdvCustomersTicketsOpen.RowCreated
        e.Row.Cells(1).Visible = False

        Dim nRows As Integer = e.Row.Cells.Count
        For i As Integer = 0 To nRows - 1
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
            End If
        Next
    End Sub

End Class