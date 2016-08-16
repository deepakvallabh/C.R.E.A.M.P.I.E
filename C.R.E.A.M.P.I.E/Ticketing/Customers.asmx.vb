Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class Customers
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function FetchCustomerNames(SearchText As String) As String()
        Dim CustomerList As New List(Of String)()
        Using con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")

            Using cmd As New SqlCommand("spGetCustomers", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SearchText", SearchText)
                cmd.Connection = con
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        CustomerList.Add(dr("BusinessName").ToString())
                    End While
                End Using
                con.Close()
            End Using
            Return CustomerList.ToArray()
        End Using
    End Function

End Class