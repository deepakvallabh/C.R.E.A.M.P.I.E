Imports System.Data.SqlClient

Public Class CustomerDetails
    Inherits System.Web.UI.Page

    Private CustomerID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Auth_Level") >= 2 Then
                CustomerID = CInt(Request.QueryString("ID").ToString())

                Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

                Dim cmdstring = "SELECT C.*, A.[FullAddress] FROM Customer C, Address A JOIN SiteAddress SA ON SA.AddressID = A.Id AND SA.CustomerID = " & CustomerID & "WHERE C.Id= " & CustomerID
                Dim cmd As New SqlCommand(cmdstring)
                Dim reader As SqlDataReader
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                While reader.Read
                    lblCustomer.Text = reader("Id")
                    txtClientName.Text = reader("BusinessName")
                    txtSiteAddress.Text = reader("FullAddress")
                    txtFName.Text = reader("Full Name")
                    txtLName.Text = reader("Last Name")
                    txtContactEmail.Text = reader("ContactEmail")
                    txtCSI.Text = reader("CSI")
                End While
            End If
        End If
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        Response.Redirect("~/Ticketing/TicketOverview")
    End Sub

    Protected Sub CloseTicket(sender As Object, e As EventArgs)
        '        CustomerID = CInt(Request.QueryString("ID").ToString())
        '        MsgBox("Job ticket " & CustomerID & " will be marked as closed")
        '        If MsgBoxResult.Ok Then
        '            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        '            Dim cmdstring As String = "UPDATE JobTicket SET JobStatus='Completed', IsOpen=0, ClosedDate='" & DateTime.Now & "' 
        'WHERE Id=" & CustomerID
        '            Dim cmd As New SqlCommand(cmdstring)
        '            cmd.CommandType = CommandType.Text
        '            cmd.Connection = con
        '            cmd.Connection.Open()
        '            cmd.ExecuteNonQuery()
        '            cmd.Connection.Close()
        '            Response.Redirect("~/Ticketing/TicketOverview.aspx")
        '        Else
        '            Response.Redirect("~/Ticketing/TicketOverview")
        '        End If
    End Sub

    Protected Sub UpdateTicket(sender As Object, e As EventArgs)

    End Sub

End Class