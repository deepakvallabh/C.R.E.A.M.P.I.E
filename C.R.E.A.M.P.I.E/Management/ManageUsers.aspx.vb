Imports System.Data.SqlClient

Public Class ManageUsers
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
                    GridView1.Visible = True
                    btnAddUser.Visible = True
                    SQL = "SELECT Id, CONCAT(FName, ' ', LName) AS 'Full Name', Username, Auth_Level AS 'Authentication Level', CellNumber FROM Employee;"
                ElseIf Session("Auth_Level") = 2 Then
                    Response.Redirect("Nav.aspx")
                ElseIf Session("Auth_Level") = 3 Then
                    Response.Redirect("Nav.aspx")
                End If

                ' Try
                '  Catch ex As Exception
                Connection.Open()

                Command.Connection = Connection
                Command.CommandText = SQL

                Adapter.SelectCommand = Command
                Adapter.Fill(Data)

                GridView1.DataSource = Data
                GridView1.DataBind()
                Connection.Close()
                'MsgBox(ex)
                ' End Try
            End If
        End If
    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        e.Row.Cells(1).Visible = False

        Dim nRows As Integer = e.Row.Cells.Count
        For i As Integer = 0 To nRows - 1
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
            End If
        Next

    End Sub

    Protected Sub AddUser(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/AddUser")
    End Sub

    Protected Sub Back(sender As Object, e As EventArgs)
        Response.Redirect("~/Management/Dashboard")
    End Sub

End Class