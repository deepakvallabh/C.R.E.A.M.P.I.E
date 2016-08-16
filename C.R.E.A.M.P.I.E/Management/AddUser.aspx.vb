Imports System.Data.SqlClient

Public Class AddUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''If Not Page.IsPostBack Then
        'If Not Session("Username") Is Nothing Then
        '    Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        '    Dim hashedPW As String = Encrypt.GenerateHash(txtPassword.Text)
        '    Dim cmdstring As String = "INSERT INTO Employee (Username, Password, Auth_Level, FName, LName, CellNumber) VALUES ('" & txtEmail.Text & "', '" & hashedPW & "', " & 3 & ", '" & txtFName.Text & "', '" & txtLName.Text & "', '" & txtCellNumber.Text & "')"

        '    Dim cmd As New SqlCommand(cmdstring)
        '    cmd.CommandType = CommandType.Text
        '    cmd.Connection = con
        '    cmd.Connection.Open()
        '    cmd.ExecuteNonQuery()
        '    cmd.Connection.Close()
        '    Response.Redirect("~/Management/ManageUsers.aspx")
        'End If
        ''End If


    End Sub

    Protected Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        If Not Session("Username") Is Nothing Then
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
            Dim hashedPW As String = Encrypt.GenerateHash(txtPassword.Text)
            Dim cmdstring As String = "INSERT INTO Employee (Username, Password, Auth_Level, FName, LName, CellNumber)" &
                "VALUES ('" & txtEmail.Text & "', '" & hashedPW & "', " &
                ddlAuth_Level.Text & ", '" & txtFName.Text & "', '" & txtLName.Text & "', '" & txtCellNumber.Text & "')"
            Dim cmd As New SqlCommand(cmdstring)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            Response.Redirect("~/Management/ManageUsers.aspx")
        End If
    End Sub
End Class