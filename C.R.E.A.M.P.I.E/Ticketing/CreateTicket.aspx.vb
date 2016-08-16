Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient

Public Class CreateTicket
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlCustomers.AppendDataBoundItems = True
            Dim strQuery As String = "SELECT Id, BusinessName from Customer"
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con
            Try
                con.Open()
                ddlCustomers.DataSource = cmd.ExecuteReader()
                ddlCustomers.DataTextField = "BusinessName"
                ddlCustomers.DataValueField = "Id"
                ddlCustomers.DataBind()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con.Dispose()
            End Try
        End If
    End Sub

    Protected Sub ddlCustomers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlAddress.Items.Clear()
        ddlAddress.Items.Add(New ListItem("--Select Site Address--", ""))

        ddlAddress.AppendDataBoundItems = True

        Dim strQuery As String = "SELECT B.Id, A.FullAddress From Customer C Join SiteAddress B" _
                                & " On C.Id = B.CustomerID Join Address A On A.Id = B.AddressID " _
                                & "WHERE C.Id=@CustomerID"
        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        Dim cmd As New SqlCommand()
        cmd.Parameters.AddWithValue("@CustomerID",
                                  ddlCustomers.SelectedItem.Value)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        Try
            con.Open()
            ddlAddress.DataSource = cmd.ExecuteReader()
            ddlAddress.DataTextField = "FullAddress"
            ddlAddress.DataValueField = "Id"
            ddlAddress.DataBind()
            If ddlAddress.Items.Count >= 1 Then
                ddlAddress.Enabled = True
            Else
                ddlAddress.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub ddlAddress_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlJobType.Enabled = True
        ddlPriority.Enabled = True
    End Sub

    Protected Sub ddlPriority_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ddlJobType.Enabled = True Then
            txtJobDesc.Enabled = True
        End If
    End Sub

    Protected Sub btnCreateTicket(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not Session("Username") Is Nothing Then
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

            Dim cmdstring As String = "INSERT INTO JobTicket (JobType, JobPriority, JobDescription, OpenedDate, JobStatus, CustomerID, SiteAddressID) OUTPUT INSERTED.Id AS 'TicketID' VALUES (" &
                ddlJobType.Text & ", " & ddlPriority.Text & ", '" & txtJobDesc.Text & "', '" & DateTime.Now & "', 'Pending', " & ddlCustomers.Text & ", " & ddlAddress.Text & ");
                SELECT CAST(scope_identity() AS int);"
            Dim cmd As New SqlCommand(cmdstring)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.Connection.Open()
            'cmd.ExecuteNonQuery()
            Dim TicketID As Int32 = 0
            TicketID = Convert.ToInt32(cmd.ExecuteScalar())
            Dim notification As New CustomerComms
            notification.NotifyNewTicket(TicketID)

            cmd.Connection.Close()


            'Response.Redirect("~/Management/ManageUsers.aspx")
        End If
    End Sub
    '<WebMethod()>
    'Public Shared Function GetCustomers(prefix As String) As String()
    '    Dim customers As New List(Of String)()
    '    Using conn As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

    '        Using cmd As New SqlCommand()
    '            cmd.CommandText = "SELECT BusinessName, Id from Customer WHERE BusinessName like @SearchText + '%'"
    '            cmd.Parameters.AddWithValue("@SearchText", prefix)
    '            cmd.Connection = conn
    '            conn.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    customers.Add(String.Format("{0}-{1}", sdr("BusinessName"), sdr("Id")))
    '                End While
    '            End Using
    '            conn.Close()
    '        End Using
    '    End Using
    '    Return customers.ToArray()
    'End Function

End Class