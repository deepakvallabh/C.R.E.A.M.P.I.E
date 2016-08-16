Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class CustomerComms

    Public Sub NotifyNewTicket(ticketID As Integer)

        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        Dim cmdstring As String = "SELECT C.ContactEmail, C.ContactFName, C.ContactLName, J.OpenedDate FROM JobTicket J JOIN Customer C ON J.CustomerID = C.Id WHERE J.Id =" & ticketID
        con.Open()
        Dim cmd As New SqlCommand(cmdstring, con)
        Dim Email, FName, LName As String
        Dim OpenedDate As Date
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            Email = reader("ContactEmail")
            FName = reader("ContactFName")
            LName = reader("ContactLName")
            OpenedDate = reader("OpenedDate")
        End While
        con.Close()

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("phr4ntic@gmail.com", "patches247155")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("donotreply@ntfycustcreampiesystem.co.za")
            e_mail.To.Add(Email)
            e_mail.Subject = "New Support Request"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<HTML><BODY><h2>Hello " & FName & ",</h2><br><br><p>Your support request #" & ticketID &
                " has been received by our support department and will be tended to shortly.</p><br><p>You will be notified once the request has been assigned to a technician.</p></BODY></HTML>"
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

    Public Sub NotifyStatusUpdate(ticketID As Integer)

        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        Dim cmdstring As String = "SELECT C.ContactEmail, C.ContactFName, C.ContactLName, J.OpenedDate FROM JobTicket J JOIN Customer C ON J.CustomerID = C.Id WHERE J.Id =" & ticketID
        con.Open()
        Dim cmd As New SqlCommand(cmdstring, con)
        Dim Email, FName, LName As String
        Dim OpenedDate As Date
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            Email = reader("ContactEmail")
            FName = reader("ContactFName")
            LName = reader("ContactLName")
            OpenedDate = reader("OpenedDate")
        End While
        con.Close()

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("phr4ntic@gmail.com", "patches247155")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("donotreply@ntfycustcreampiesystem.co.za")
            e_mail.To.Add(Email)
            e_mail.Subject = "New Support Request"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<HTML><BODY><h2>Hello " & FName & ",</h2><br><br><p>Your support request #" & ticketID &
                " has been received by our support department and will be tended to shortly.</p><br><p>You will be notified once the request has been assigned to a technician.</p></BODY></HTML>"
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

    Public Sub RequestFeedback(ticketID As Integer)

        Dim con As New SqlConnection("Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CREAMPIECentralDB.mdf;Initial Catalog=CREAMPIECentralDB;Integrated Security=True")
        Dim cmdstring As String = "SELECT C.Id as 'CustomerID', C.ContactEmail, C.ContactFName, C.ContactLName, J.ClosedDate, E.Id as 'TechnicianID'
FROM JobTicket J JOIN Customer C ON J.CustomerID = C.Id 
JOIN Employee E ON E.Id = J.AssignedTechID
WHERE J.Id =" & ticketID
        con.Open()
        Dim cmd As New SqlCommand(cmdstring, con)
        Dim Email, FName, LName As String
        Dim ClosedDate As Date
        Dim CustomerID, TechnicianID As Integer
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            CustomerID = reader("CustomerId")
            TechnicianID = reader("TechnicianID")
            Email = reader("ContactEmail")
            FName = reader("ContactFName")
            LName = reader("ContactLName")
            ClosedDate = reader("ClosedDate")
        End While
        con.Close()

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("phr4ntic@gmail.com", "patches247155")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("donotreply@ntfycustcreampiesystem.co.za")
            e_mail.To.Add(Email)
            e_mail.Subject = "New Support Request"
            e_mail.IsBodyHtml = True
            Dim urlstr As String = "~/Customers/CustomerFeedback?CID=" & CustomerID & "&TID=" & TechnicianID
            e_mail.Body = "<HTML><BODY><h2>Hello " & FName & ",</h2><br><br><p>Your support request #" & ticketID &
                " has been marked as completed by our support department as at " & ClosedDate &
                ".</p><br><p><a href=" & urlstr & ">Please click on this link to submit a brief service rating.</a></p></BODY></HTML>"

            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

End Class
