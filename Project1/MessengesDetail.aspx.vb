﻿Imports System.Data.SqlClient

Public Class MessagesDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim ID As Integer = Request.QueryString("ID")
        updateMesseges(ID)
        Dim messenges As MessengeList = New MessengeList(ID)
        Dim user As User = Session("user") 'to access user's name

        Dim html As String = "" 'HTML string to be put in div tag
        If Not (messenges.getSize() = 0) Then 'If there are messenges
            For i As Integer = 1 To messenges.getSize()
                'to do didsplay messenges in div tag on the page  
                Dim messenge As Messenge = messenges.getMessage(i)

                If messenge.getSender() = user.getUsername() Then 'should appear in different colours
                    html &= "<p style=""background-color:yellow;  margin-right: 400px; margin-left: 150px;""> " & messenge.getMessageInfo() & "</p><br />"
                Else
                    html &= "<p style=""background-color:lightgreen;  margin-right: 600px;"">" & messenge.getMessageInfo() & "</p><br /><br/><br/>"
                End If
            Next i
        End If
        messagesHistory.InnerHtml = html

        If TypeOf user Is Client Then
            returnOption.InnerHtml = "<a href=ClientProfile.aspx> Return to Profile Page </a>"
        Else
            returnOption.InnerHtml = "<a href=WorkerProfile.aspx> Return to Profile Page </a>"
        End If

    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.ServerClick
        'Variables needed to make a message
        Dim messenge As String = txtMessage.Text()
        Dim mdate As Date = DateAndTime.Today()
        Dim cUser As User = Session("user") 'to obtain sender username
        Dim ID As Integer = Request.QueryString("ID")

        Dim cMessage As Messenge = New Messenge(ID, messenge, cUser.getUsername(), mdate)
        cMessage.saveMessenge() 'commiting message into the database
        Response.Redirect("MessengesDetail.aspx?ID=" & ID)
    End Sub

    Private Sub updateMesseges(JobID As Integer)
        Dim cUser As User = Session("user")

        Dim connection As SqlConnection = New SqlConnection(ValidationClass.CONNECTIONSTRING)
        Dim query As String = "UPDATE Messenges SET Checked = @checked WHERE PostAdId  = @name AND NOT(Sender = @sender);"
        connection.Open()

        Dim command As SqlCommand = New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@name", JobID)
        command.Parameters.AddWithValue("@checked", "checked")
        command.Parameters.AddWithValue("@sender", cUser.getUsername())
        Dim reader As SqlDataReader = command.ExecuteReader()
    End Sub
End Class