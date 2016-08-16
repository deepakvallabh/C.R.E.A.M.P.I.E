Imports System.Data.SqlClient

Public Class UnassignedTicketDetails
    Inherits System.Web.UI.Page

    Private TicketID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Auth_Level") = 3 Then
                TicketID = CInt(Request.QueryString("ID").ToString())

                Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

                Dim cmdstring = "SELECT J.Id, C.BusinessName, A.FullAddress, J.OpenedDate, JT.Type, JP.Priority, J.JobStatus, J.JobDescription
FROM JobTicket J
JOIN Customer C
  ON J.CustomerID = C.Id
JOIN SiteAddress S
  ON J.SiteAddressID = S.Id
JOIN Address A
  ON A.Id = S.AddressID
JOIN JobType JT
  ON J.JobType = JT.Id
JOIN JobPriority JP
  ON J.JobPriority = JP.Id
WHERE J.Id = " & TicketID
                Dim cmd As New SqlCommand(cmdstring)
                Dim reader As SqlDataReader
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                While reader.Read
                    lblTicket.Text = reader("Id")
                    txtClientName.Text = reader("BusinessName")
                    txtSiteAddress.Text = reader("FullAddress")
                    txtOpenedDate.Text = reader("OpenedDate")
                    txtJobStatus.Text = reader("JobStatus")
                    txtJobType.Text = reader("Type")
                    txtJobPriority.Text = reader("Priority")
                    txtJobDesc.Text = reader("JobDescription")
                End While
            End If
        End If
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        Response.Redirect("~/Ticketing/TicketOverview")
    End Sub

    Protected Sub AcceptTicket(sender As Object, e As EventArgs)
        TicketID = CInt(Request.QueryString("ID").ToString())
        MsgBox("Job ticket " & TicketID & " will be assigned to you")
        If MsgBoxResult.Ok Then
            Dim TechID As Integer = Session("Id")
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
            Dim cmdstring As String = "UPDATE JobTicket SET JobStatus='Assigned to technician', AssignedTechID=" & TechID & "
WHERE Id=" & TicketID
            Dim cmd As New SqlCommand(cmdstring)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        Else
            Response.Redirect("~/Ticketing/TicketOverview")
        End If
    End Sub
End Class