Imports System.Data.SqlClient

Public Class ViewTicket
    Inherits System.Web.UI.Page

    Private TicketID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Auth_Level") = 1 Then
                TicketID = CInt(Request.QueryString("ID").ToString())

                Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

                Dim cmdstring = "SELECT J.Id, C.BusinessName, A.FullAddress, J.OpenedDate, J.JobType, J.JobStatus, J.JobDescription,
CONCAT(E.FName, ' ', E.LName) AS 'Full Name', E.CellNumber
FROM JobTicket J
JOIN Customer C
  ON J.CustomerID = C.Id
JOIN SiteAddress S
  ON J.SiteAddressID = S.Id
JOIN Address A
  ON A.Id = S.AddressID
JOIN Employee E
  ON J.AssignedTechID = E.Id
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
                    txtAssignedTech.Text = reader("Full Name")
                    txtTechCell.Text = reader("CellNumber")
                    ddlJobType.Text = reader("JobType")
                    'ddlPriority.Text = 
                    txtJobDesc.Text = reader("JobDescription")
                End While
            End If
        End If
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/ManageTickets")
    End Sub

    Protected Sub UpdateTicket(sender As Object, e As EventArgs)
        'TicketID = CInt(Request.QueryString("ID").ToString())
        'Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        'Dim hashedPW As String = Encrypt.GenerateHash(txtPassword.Text)
        'Dim cmdstring As String = "UPDATE Employee SET Username='" & txtEmail.Text & "',Password='" & Encrypt.GenerateHash(txtPassword.Text) & "',FName='" & txtFName.Text & "',LName='" & txtLName.Text & "',CellNumber='" & txtCellNumber.Text & "' WHERE Id=" & TicketID
        'Dim cmd As New SqlCommand(cmdstring)
        'cmd.CommandType = CommandType.Text
        'cmd.Connection = con
        'cmd.Connection.Open()
        'cmd.ExecuteNonQuery()
        'cmd.Connection.Close()
        Response.Redirect("~/Management/ManageTickets.aspx")
    End Sub

    Protected Sub DeleteTicket(sender As Object, e As EventArgs)
        MsgBox("You are about to DELETE the Ticket, Are you sure you want to continue ? ")
        If MsgBoxResult.Ok Then
            'TicketID = CInt(Request.QueryString("ID").ToString())
            'Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
            'Dim hashedPW As String = Encrypt.GenerateHash(txtPassword.Text)
            'Dim cmdstring As String = "DELETE FROM Employee WHERE Id=" & TicketID
            'Dim cmd As New SqlCommand(cmdstring)
            'cmd.CommandType = CommandType.Text
            'cmd.Connection = con
            'cmd.Connection.Open()
            'cmd.ExecuteNonQuery()
            'cmd.Connection.Close()
            'Response.Redirect("~/Management/ManageUsers.aspx")
        Else
            Response.Redirect("~/Management/ManageTickets.aspx")
        End If
    End Sub

End Class