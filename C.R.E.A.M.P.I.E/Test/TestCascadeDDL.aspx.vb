Imports System.Data.SqlClient

Public Class TestCascadeDDL
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

    'Protected Sub ddlCustomers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    ddlAddress.Items.Clear()
    '    ddlAddress.Items.Add(New ListItem("--Select Country--", ""))
    '    ddlAddress.AppendDataBoundItems = True

    '    Dim strQuery As [String] = "select ID, CountryName from Countries " _
    '                                & "where ContinentID=@ContinentID"
    '    Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
    '    Dim cmd As New SqlCommand()
    '    cmd.Parameters.AddWithValue("@ContinentID",
    '                         ddlContinents.SelectedItem.Value)
    '    cmd.CommandType = CommandType.Text
    '    cmd.CommandText = strQuery
    '    cmd.Connection = con
    '    Try
    '        con.Open()
    '        ddlCountry.DataSource = cmd.ExecuteReader()
    '        ddlCountry.DataTextField = "CountryName"
    '        ddlCountry.DataValueField = "ID"
    '        ddlCountry.DataBind()
    '        If ddlCountry.Items.Count > 1 Then
    '            ddlCountry.Enabled = True
    '        Else
    '            ddlCountry.Enabled = False
    '            ddlCity.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        con.Close()
    '        con.Dispose()
    '    End Try
    'End Sub

    Protected Sub ddlCustomers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ddlAddress.Items.Clear()
        ddlAddress.Items.Add(New ListItem("--Select Site Address--", ""))

        ddlAddress.AppendDataBoundItems = True

        Dim strQuery As String = "SELECT A.Id, A.FullAddress From Customer C Join SiteAddress B" _
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
            If ddlAddress.Items.Count > 1 Then
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
        lblResults.Text = "You selected" & ddlCustomers.SelectedItem.Text & "---->" & ddlAddress.SelectedItem.Text
    End Sub

End Class