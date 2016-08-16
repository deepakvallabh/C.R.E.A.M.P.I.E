Imports System.Data.SqlClient

Public Class ViewUser
    Inherits System.Web.UI.Page

    Private UserID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("Username") Is Nothing Then
                UserID = CInt(Request.QueryString("ID").ToString())

                Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

                Dim cmdstring = "SELECT Username, Password, Auth_Level, FName, LName, CellNumber from Employee WHERE Id = " & UserID
                Dim cmd As New SqlCommand(cmdstring)
                Dim reader As SqlDataReader
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                While reader.Read
                    lblUName.Text = reader("Username")
                    txtFName.Text = reader("FName")
                    txtLName.Text = reader("LName")
                    txtEmail.Text = reader("Username")
                    txtPassword.Text = reader("Password") 'Encrypt.GenerateHash("Password")
                    ddlAuth_Level.Text = reader("Auth_Level")
                    txtCellNumber.Text = reader("CellNumber")
                End While
            End If
        End If
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/ManageUsers")
    End Sub

    Protected Sub UpdateUser(sender As Object, e As EventArgs)
        UserID = CInt(Request.QueryString("ID").ToString())
        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        Dim hashedPW As String = Encrypt.GenerateHash(txtPassword.Text)
        Dim cmdstring As String = "UPDATE Employee SET Username='" & txtEmail.Text & "',Password='" & Encrypt.GenerateHash(txtPassword.Text) & "',FName='" & txtFName.Text & "',LName='" & txtLName.Text & "', Auth_Level=" & ddlAuth_Level.Text & ", CellNumber='" & txtCellNumber.Text & "' WHERE Id=" & UserID
        Dim cmd As New SqlCommand(cmdstring)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        Response.Redirect("~/Management/ManageUsers.aspx")
    End Sub

    Protected Sub DeleteUser(sender As Object, e As EventArgs)
        MsgBox("You are about to DELETE the Employee, Are you sure you want to continue ? ")
        If MsgBoxResult.Ok Then
            UserID = CInt(Request.QueryString("ID").ToString())
            Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
            Dim hashedPW As String = Encrypt.GenerateHash(txtPassword.Text)
            Dim cmdstring As String = "DELETE FROM Employee WHERE Id=" & UserID
            Dim cmd As New SqlCommand(cmdstring)
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            Response.Redirect("~/Management/ManageUsers.aspx")
        Else
            Response.Redirect("~/Management/ManageUsers.aspx")
        End If
    End Sub

End Class