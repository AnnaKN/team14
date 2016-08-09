﻿Imports System.Data.SqlClient

Public Class Responses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim adID As Integer = Request.QueryString("ID")
        Dim html As String = ""
        Dim handyman As Worker
        Dim connection As SqlConnection = New SqlConnection(ValidationClass.CONNECTIONSTRING)
        Dim query As String = "SELECT * FROM Responses WHERE AdID = @name;"
        connection.Open()

        Dim command As SqlCommand = New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@name", adID)

        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                handyman = New Worker(reader("Worker"))
                'html code ofr div tag
                html &= displayWorker(handyman.getUsername())
                html &= "<div class=""sun-regions col-md-9""> "
                html &= "<ul>"
                html &= "<p>" & reader("Comment") & "</p>"
                html &= "<li><a href=ClientProfile.aspx?Selected=" & handyman.getUsername() & "&ID=" & adID & "> Confirm </a></li>"
                html &= "</ul>"

            End While
        End If
        ' MsgBox("Resposes:Page_Load()-html values = " & html)
        HandyMen.InnerHtml = html
    End Sub

    Private Function displayWorker(workerID As String)
        Dim info As String = ""

        Dim connection As SqlConnection = New SqlConnection(ValidationClass.CONNECTIONSTRING)
        Dim query As String = "SELECT * FROM Workers WHERE Username = @name;"
        connection.Open()

        Dim command As SqlCommand = New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@name", workerID)

        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            MsgBox("Resposes:displayWorker()-Reading woker values from database")
            reader.Read()
            info &= "<h1>" & reader("Name") & " " & reader("Surname") & "</h1> <br />"
            info &= "<div class=""itemtype"">"
            info &= "<p class=""p-price"">Rating</p>"
            info &= "	<h4><i><img src=""images/rate1.png"" alt="" "" /></i></h4>"
            info &= "<div class=""clearfix""></div>"
            info &= "</div>"
        End If
        Return info
    End Function
End Class