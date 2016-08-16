Imports System.Data.SqlClient

Public Class ManageTickets
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("Username") Is Nothing Then

                Dim Command As New SqlCommand
                Dim Adapter As New SqlDataAdapter
                Dim Data As New DataTable
                Dim SQL As String

                Dim Connection As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

                If Session("Auth_Level") = 1 Then
                    grdvTickets.Visible = True
                    'btnAddUser.Visible = True
                    'SQL = "SELECT JobTicket.Id, JobType, OpenedDate, IsOpen, JobStatus, AssignedTechID FROM JobTicket INNER JOIN Employee ON JobTicket.AssignedTechID = Employee.ID;"
                    'SQL = "SELECT Id, JobType, OpenedDate, IsOpen, JobStatus FROM JobTicket;"
                    SQL = "SELECT J.Id, J.JobType, J.OpenedDate, J.IsOpen, J.JobStatus, C.BusinessName FROM JobTicket J JOIN Customer C" _
                                & " On C.Id = J.CustomerID"
                ElseIf Session("Auth_Level") = 2 Then
                    Response.Redirect("~/Ticketing/CreateTicket.aspx")
                ElseIf Session("Auth_Level") = 3 Then
                    Response.Redirect("~/Ticketing/TicketOverview.aspx")
                End If

                Connection.Open()
                Command.Connection = Connection
                Command.CommandText = SQL

                Adapter.SelectCommand = Command
                Adapter.Fill(Data)

                grdvTickets.DataSource = Data
                grdvTickets.DataBind()
                ' Try
                '  Catch ex As Exception

                'MsgBox(ex)
                ' End Try
                'ElseIf Session("Username") Is Nothing Then
                '    'Trying to go to previous page if page access is anonymous I.e no CREAMPIE user
                '    Dim refUrl As String = Request.UrlReferrer.ToString()
                '    Dim goback As Object = ViewState("refUrl")
                '    If Not goback Is Nothing Then
                '        Response.Redirect(CStr(goback))
                '    End If
            End If
            ''Trying to go to previous page if page access is anonymous I.e no CREAMPIE user
            'ViewState("RefUrl") = Request.UrlReferrer.ToString()
            'Dim refUrl As Object = ViewState("RefUrl")
            'If Not refUrl Is Nothing Then
            '    Response.Redirect(CStr(refUrl))
            'End If
        End If
    End Sub

    Private Sub grdvTickets_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvTickets.rowcreated
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
        Response.Redirect("~/Management/Dashboard")
    End Sub

End Class