Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient

Public Class Reports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ''BindChart()
            'Dim query As String = "SELECT JobType.type, COUNT(jobticket.JobType) as total from JobTicket join jobtype on jobtype.id = JobTicket.JobType group by JobType.type"
            'Dim dt As DataTable = GetData(query)
            'ddlJobType.DataSource = dt
            'ddlJobType.DataTextField = "type"
            'ddlJobType.DataValueField = "type"
            'ddlJobType.DataBind()
            'ddlJobType.Items.Insert(0, New ListItem("Select", ""))
            CurrentOpenTickets()
            TicketHistory()
        End If
    End Sub
    'Protected Sub ddlJobType_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Dim query As String = String.Format("Select JobType.type, COUNT(jobticket.JobType) As total from JobTicket join jobtype On jobtype.id = JobTicket.JobType group by JobType.type", ddlJobType.SelectedItem.Value)
    '    Dim dt As DataTable = GetData(query)

    '    Dim x As String() = New String(dt.Rows.Count - 1) {}
    '    Dim y As Decimal() = New Decimal(dt.Rows.Count - 1) {}
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        x(i) = dt.Rows(i)(0).ToString()
    '        y(i) = Convert.ToInt32(dt.Rows(i)(1))
    '    Next
    '    bcJobType.Series.Add(New AjaxControlToolkit.BarChartSeries() With {
    ' .Data = y
    '})
    '    bcJobType.CategoriesAxis = String.Join(",", x)
    '    bcJobType.ChartTitle = String.Format("{0} Support Calls", ddlJobType.SelectedItem.Value)
    '    If x.Length > 3 Then
    '        bcJobType.ChartWidth = (x.Length * 100).ToString()
    '    End If
    '    bcJobType.Visible = ddlJobType.SelectedItem.Value <> ""
    'End Sub
    Private Shared Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt



            '            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            '            Dim iColumn As Integer = 0
            '                While rdr.Read()
            '                    iColumn += 1
            '                strSql &= ", 100.0*(select SUM(total) FROM [ee].[dbo].[tblQ_27729744] t2 WHERE t2.[date]=t.[date] and [name]='" _
            '                    & rdr.GetString(0).Replace("'", "''") &
            '                    "')/(select SUM(total) FROM [ee].[dbo].[tblQ_27729744] t2 WHERE t2.[date]=t.[date]) as Column" & iColumn

            '                "SELECT SUM(Total) AS TotalTicketsPM, Type, DATE FROM
            '(SELECT        JobType.Type, COUNT(JobTicket.JobType) AS total, DatePart(month, JobTicket.OpenedDate) AS DATE
            'FROM            JobTicket INNER JOIN
            '                         JobType ON JobType.Id = JobTicket.JobType
            'WHERE [OpenedDate] BETWEEN '02/06/2016' AND '08/06/2016'
            'GROUP BY JobType.Type, JobTicket.OpenedDate) As TPM GROUP BY DATE, TYPE"

            '                With Me.Chart2.Series.Add("Series" & iColumn)
            '                        .ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            '                        .XValueMember = "date"
            '                        .YValueMembers = "Column" & iColumn.ToString()
            '                        .IsValueShownAsLabel = True
            '                    End With
            '                End While
            '                rdr.Close()

            '                strSql &= " FROM [ee].[dbo].[tblQ_27729744] t " &
            '                    "GROUP BY [date] " &
            '                    "ORDER BY [date]"
            '                Me.SqlDataSource1.SelectCommand = strSql


        End Using
    End Function

    'Private Sub BindChart()

    '    Dim constr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    '    Dim conn As New SqlConnection(constr)
    '    Dim ds As New DataSet()
    '    Dim dt As New DataTable()
    '    conn.Open()
    '    Dim cmdstr As String = "Select JobType.type, COUNT(jobticket.JobType) As total from JobTicket join jobtype On jobtype.id = JobTicket.JobType group by JobType.type"
    '    Dim cmd As New SqlCommand(cmdstr, conn)
    '    Dim adp As New SqlDataAdapter(cmd)
    '    adp.Fill(ds)
    '    dt = ds.Tables[0]

    '    String category = "";
    '    Decimal[] values = New Decimal[dt.Rows.Count];
    '    For (Int() i = 0; i < dt.Rows.Count; i++)
    '    {
    '        category = category + "," + dt.Rows[i]["Country"].ToString();
    '        values[I] = Convert.ToDecimal(dt.Rows[i]["Total Suppliers"]);         
    '    }       
    '    BarChart1.CategoriesAxis = category.Remove(0, 1);
    '    BarChart1.Series.Add(New AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Suppliers" });       

    'End Sub

    'Private Sub LoadChart(ByVal datatable1 As DataTable)
    '    For i As Integer = 1 To datatable1.Columns.Count - 1
    '        Dim series As New Series()
    '        For Each dr As DataRow In datatable1.Rows
    '            Dim y As Integer = CInt(dr(i))
    '            series.Points.AddXY(dr("Date").ToString(), y)
    '        Next
    '        bcJobType.Series.Add(series)
    '    Next

    'End Sub

    'Private Function TestingBarChart() As DataTable
    '    Dim dt As New DataTable
    '    dt.Columns.Add("Date", Type.GetType("System.DateTime"))
    '    dt.Columns.Add("A", Type.GetType("System.Int32"))
    '    dt.Columns.Add("B", Type.GetType("System.Int32"))
    '    dt.Columns.Add("C", Type.GetType("System.Int32"))
    '    dt.Columns.Add("D", Type.GetType("System.Int32"))
    '    dt.Columns.Add("E", Type.GetType("System.Int32"))
    '    Dim dr1 As DataRow = dt.NewRow()
    '    dr1("Date") = "1-1-2013"
    '    dr1("A") = 10
    '    dr1("B") = 20
    '    dr1("C") = 30
    '    dr1("D") = 40
    '    dr1("E") = 50
    '    dt.Rows.Add(dr1)
    '    Dim dr2 As DataRow = dt.NewRow()
    '    dr2("Date") = "1-1-2013"
    '    dr2("A") = 100
    '    dr2("B") = 200
    '    dr2("C") = 300
    '    dr2("D") = 400
    '    dr2("E") = 500
    '    dt.Rows.Add(dr2)
    '    Return dt
    'End Function

    Private Sub GetTechnicians()
        Dim dt As DataTable = GetData("select Id, Fname, Lname from Employee where Auth_Level = 3")
        Dim sb As New StringBuilder()
        sb.Append("<ul>")
        sb.Append("<li>Item 1</li>")
        sb.Append("<li>Item 2</li>")
        sb.Append("</ul>")
        lgTechnicians.InnerHtml = sb.ToString()
    End Sub

    Private Sub TicketHistory()
        Dim dt As DataTable = GetData("SELECT SUM(Total) As TotalTicketsPM, Type, DATE FROM
(SELECT        JobType.Type, COUNT(JobTicket.JobType) AS total, DatePart(month, JobTicket.OpenedDate) AS DATE
From JobTicket INNER Join
                         JobType On JobType.Id = JobTicket.JobType
Where [OpenedDate] BETWEEN '02/06/2016' AND '08/06/2016'
Group BY JobType.Type, JobTicket.OpenedDate) As TPM GROUP BY DATE, TYPE")
        Dim XPointMember(6) As String
        Dim YPOINTMember(dt.Rows.Count) As Integer
        BarChart1.DataBind()
        'BarChart1.CategoriesAxis.Distinct(dt.Columns.Item(2))

        For Each row As DataRow In dt.Rows
            'BarChart1.ChartType.StackedBar(BarChart1)
            'BarChart1.Series.All
            'XPointMember(row) = dt.Rows.Count(UniqueConstraint("DATE"))
            'YPOINTMember(row) = dt.Columns.
        Next
        BarChart1.ChartType = AjaxControlToolkit.BarChartType.StackedColumn
        'BarChart1.Series.Add(dt)

    End Sub
    Private Sub CurrentOpenTickets()
        'Returns the datatable to be used with the 'Status of current tickets' pie chart under Tickets management
        Dim dt As DataTable = GetData("SELECT JobStatus, COUNT(JobStatus) as TotalByStatus FROM JobTicket WHERE IsOpen = 1 Group By JobStatus")
        For Each row As DataRow In dt.Rows
            pcCurrentTickets.PieChartValues.Add(New AjaxControlToolkit.PieChartValue() With {
            .Category = row("JobStatus").ToString(),
            .Data = Convert.ToDecimal(row("TotalByStatus"))
            })
        Next
        pcCurrentTickets.Visible = True
    End Sub
End Class