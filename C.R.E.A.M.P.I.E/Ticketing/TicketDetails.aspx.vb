Imports System.Data.SqlClient

Public Class TicketDetails
    Inherits System.Web.UI.Page

    Private TicketID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Auth_Level") = 3 Then
                TicketID = CInt(Request.QueryString("ID").ToString())

                Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

                Dim cmdstring = "SELECT J.Id, C.BusinessName, CONCAT(C.ContactFName,' ', C.ContactLName) AS 'Full Name', C.ContactEmail, A.FullAddress, J.OpenedDate, JT.Type AS 'Type', JP.Id AS 'Priority', J.JobStatus, J.JobDescription
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
WHERE J.Id =" & TicketID
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
                    txtFullName.Text = reader("Full Name")
                    txtContactEmail.Text = reader("ContactEmail")
                    txtOpenedDate.Text = reader("OpenedDate")
                    txtJobStatus.Text = reader("JobStatus")
                    txtJobType.Text = reader("Type")
                    ddlPriority.SelectedValue = reader("Priority")
                    txtJobDesc.Text = reader("JobDescription")
                End While
            End If
        End If
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        Response.Redirect("~/Ticketing/TicketOverview")
    End Sub

    Protected Sub CloseTicket(sender As Object, e As EventArgs)
        TicketID = CInt(Request.QueryString("ID").ToString())
        MsgBox("Job ticket " & TicketID & " will be marked as closed")
        If MsgBoxResult.Ok Then
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
            Dim cmdstring As String = "UPDATE JobTicket SET JobStatus='Completed', IsOpen=0, ClosedDate='" & DateTime.Now & "' 
WHERE Id=" & TicketID
            Dim cmd As New SqlCommand(cmdstring)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            Dim FeedbackRequest As New CustomerComms
            FeedbackRequest.RequestFeedback(TicketID)
            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        Else
            Response.Redirect("~/Ticketing/TicketOverview")
        End If
    End Sub

    Protected Sub UpdateTicket(sender As Object, e As EventArgs)

    End Sub

End Class