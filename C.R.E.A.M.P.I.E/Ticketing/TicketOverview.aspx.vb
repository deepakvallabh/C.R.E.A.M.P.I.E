Imports System.Data.SqlClient

Public Class TicketOverview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("Username") Is Nothing Then
                grdvMyTicketsPopulate()
                grdvUnassignedTicketsPopulate()
            End If
        End If
    End Sub

    Private Sub grdvMyTicketsPopulate()

        If Session("Auth_Level") = 3 Then
            'Declare local variables for SQL
            Dim cmd As New SqlCommand
            Dim Adapter As New SqlDataAdapter
            Dim Data As New DataTable
            Dim SQL As String
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

            'Reveal the gridview to user
            lblMyTickets.Visible = True
            grdvMyTickets.Visible = True
            'btnAddUser.Visible = True
            'SQL = "SELECT JobTicket.Id, JobType, OpenedDate, IsOpen, JobStatus, AssignedTechID FROM JobTicket INNER JOIN Employee ON JobTicket.AssignedTechID = Employee.ID;"
            'SQL = "SELECT Id, JobType, OpenedDate, IsOpen, JobStatus FROM JobTicket;"
            SQL = "SELECT J.Id, J.JobStatus, C.BusinessName, 
CONCAT(C.ContactFName, ' ', C.ContactLName) AS 'Contact Person', C.ContactEmail, A.FullAddress  
FROM JobTicket J JOIN Customer C
On C.Id = J.CustomerID 
JOIN SiteAddress S on S.Id = J.SiteAddressID 
JOIN Address A on A.Id =S.AddressID
JOIN Employee E on E.Id = J.AssignedTechID
WHERE J.IsOpen = 1 AND J.AssignedTechID = " & Session("Id")

            'Execute SQL commands if user access is relevant
            con.Open()
            cmd.Connection = con
            cmd.CommandText = SQL

            Adapter.SelectCommand = cmd
            Adapter.Fill(Data)

            grdvMyTickets.DataSource = Data
            grdvMyTickets.DataBind()

            'Otherwise proceed to run alternate sub-routines
        ElseIf Session("Auth_Level") = 2 Then
            grdvUnassignedTicketsPopulate()
        ElseIf Session("Auth_Level") = 1 Then
            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        End If
    End Sub

    Private Sub grdvUnassignedTicketsPopulate()
        Dim cmd As New SqlCommand
        Dim Adapter As New SqlDataAdapter
        Dim Data As New DataTable
        Dim SQL As String
        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

        If Session("Auth_Level") = 3 Then
            grdvOpenTickets.Visible = True
            btnBack.Visible = False
            'btnAddUser.Visible = True
            'SQL = "SELECT JobTicket.Id, JobType, OpenedDate, IsOpen, JobStatus, AssignedTechID FROM JobTicket INNER JOIN Employee ON JobTicket.AssignedTechID = Employee.ID;"
            'SQL = "SELECT Id, JobType, OpenedDate, IsOpen, JobStatus FROM JobTicket;"
            SQL = "SELECT J.Id, JT.Type, JP.Priority, J.OpenedDate
        FROM JobTicket J JOIN JobType JT
        On J.JobType = JT.Id 
        JOIN JobPriority JP on J.JobPriority = JP.Id 
        WHERE J.AssignedTechID IS NULL"
        ElseIf Session("Auth_Level") = 2 Then
            grdvOpenTickets.Visible = True
            SQL = "SELECT J.Id, JT.Type, JP.Priority, J.JobDescription, J.OpenedDate, A.FullAddress
FROM JobTicket J JOIN JobType JT
On J.JobType = JT.Id
JOIN Customer C On C.Id = J.CustomerID
JOIN SiteAddress S on S.Id = J.SiteAddressID
JOIN Address A on A.Id =S.AddressID
JOIN JobPriority JP on J.JobPriority = JP.Id
WHERE J.AssignedTechID IS NULL"
        ElseIf Session("Auth_Level") = 1 Then
            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        End If

        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQL

        Adapter.SelectCommand = cmd
        Adapter.Fill(Data)

        grdvOpenTickets.DataSource = Data
        grdvOpenTickets.DataBind()
    End Sub

    Private Sub grdvMyTickets_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvMyTickets.RowCreated
        e.Row.Cells(1).Visible = False

        Dim nRows As Integer = e.Row.Cells.Count
        For i As Integer = 0 To nRows - 1
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
            End If
        Next

    End Sub

    Private Sub grdvOpenTickets_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdvOpenTickets.RowCreated
        e.Row.Cells(1).Visible = False

        Dim nRows As Integer = e.Row.Cells.Count
        For i As Integer = 0 To nRows - 1
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
            End If
        Next
    End Sub

    Protected Sub AddTicket(sender As Object, e As EventArgs)
        Response.Redirect("~/Ticketing/CreateTicket")
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        If Session("Auth_Level") = 1 Then
            Response.Redirect("~/Management/Dashboard")
        ElseIf Session("Auth_Level") = 2 Then
            Response.Redirect("~/Helpdesk/Dashboard.aspx")
        ElseIf Session("Auth_Level") = 3 Then
            btnBack.Visible = False
        End If
    End Sub

End Class