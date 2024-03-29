﻿Imports System.Data.SqlClient

Public Class Worker
    Inherits User


    Private description As String
    Private logo As Image
    Private category As String

    'specialised constructor
    Public Sub New(vusername As String, vpassword As String, vname As String, vsurname As String, vemail As String, mnumbers As String, vregion As String, vdate As Date, description As String, category As String, logo As Image)
        MyBase.New(vusername, vpassword, vname, vsurname, vemail, mnumbers, vregion, "", vdate)
        Me.description = description
        Me.logo = logo
        Me.category = category
    End Sub

    'for use of ststus (admin only)
    Public Sub New(vusername As String, vpassword As String, vname As String, vsurname As String, vemail As String, mnumbers As String, vregion As String, vdate As Date, description As String, category As String, logo As Image, status As String)
        MyBase.New(vusername, vpassword, vname, vsurname, vemail, mnumbers, vregion, "", vdate, status)
        Me.description = description
        Me.logo = logo
        Me.category = category
    End Sub


    'basic constructor
    Public Sub New(username As String, password As String)
        MyBase.New()
        getWorker(username, password)
    End Sub

    Public Sub New(username As String)
        getPartialWorkerInfo(username)
    End Sub

    Public Sub New(username As String, authorized As Boolean)
        If authorized Then
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim reader As SqlDataReader

            connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
            Dim commandstring As String = "SELECT * From Workers WHERE Username = @user"
            command = New SqlCommand(commandstring, connection)
            command.Parameters.AddWithValue("@user", username)

            command.Connection.Open()
            reader = command.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                Me.username = username
                name = reader("Name")
                surname = reader("Surname")
                email = reader("Email")
                numbers = reader("MobileNumber")
                region = reader("Region")
                'jobTitle = reader("JobTitle")
                description = reader("Description")
                category = reader("Category")
                JoinDate = reader("JoinDate")

            End If
        End If
    End Sub

    'getting handyman from database
    Private Sub getWorker(username As String, password As String)
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim reader As SqlDataReader
        password = Secrecy.HashPassword(password)

        connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        Dim commandstring As String = "SELECT * From Workers WHERE Username = @user AND Password = @pass AND Status = @open"
        command = New SqlCommand(commandstring, connection)
        command.Parameters.AddWithValue("@user", username)
        command.Parameters.AddWithValue("@pass", password)
        command.Parameters.AddWithValue("@open", "OPEN")

        command.Connection.Open()
        reader = command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            Me.username = username
            name = reader("Name")
            surname = reader("Surname")
            email = reader("Email")
            numbers = reader("MobileNumber")
            region = reader("Region")
            'jobTitle = reader("JobTitle")
            description = reader("Description")
            category = reader("Category")
            JoinDate = reader("JoinDate")

        End If
    End Sub

    Public Overrides Sub saveUser()
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim reader As SqlDataReader


        Dim commandstring As String = "INSERT INTO Workers (Name, Surname, Username, Password, MobileNumber, Email, Category, Region, Description, JoinDate, Status) VALUES (@name, @surname, @username, @password, @mobil, @email, @category, @region, @description, @date, @status)"
        connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        connection.Open()
        command = New SqlCommand(commandstring, connection)

        command.Parameters.AddWithValue("@name", name)
        command.Parameters.AddWithValue("@surname", surname)
        command.Parameters.AddWithValue("@username", username)
        command.Parameters.AddWithValue("@password", password)
        command.Parameters.AddWithValue("@mobil", numbers)
        command.Parameters.AddWithValue("@email", email)
        command.Parameters.AddWithValue("@category", category)
        command.Parameters.AddWithValue("@region", region)
        'command.Parameters.AddWithValue("@JobTitle", jobTitle)
        command.Parameters.AddWithValue("@description", description)
        command.Parameters.AddWithValue("@date", Date.Today)
        command.Parameters.AddWithValue("@status", "OPEN")

        reader = command.ExecuteReader()

        connection.Close()
        addToAverageDatabase()

    End Sub

    Public Overrides Sub updateUser()
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim reader As SqlDataReader

        Dim commandstring As String = "UPDATE Workers SET Username = @username, Name = @name, Surname = @surname,  MobileNumber = @mobil, Email = @email, Category = @category, Description = @des, Status = @status WHERE Username = @username"
        connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        connection.Open()
        command = New SqlCommand(commandstring, connection)

        command.Parameters.AddWithValue("@name", name)
        command.Parameters.AddWithValue("@surname", surname)
        command.Parameters.AddWithValue("@username", username)
        ' command.Parameters.AddWithValue("@password", password)
        command.Parameters.AddWithValue("@mobil", numbers)
        command.Parameters.AddWithValue("@email", email)
        'command.Parameters.AddWithValue("@title", jobTitle)
        command.Parameters.AddWithValue("@des", description)
        command.Parameters.AddWithValue("@category", category)
        command.Parameters.AddWithValue("@status", status)
        reader = command.ExecuteReader()

        connection.Close()
    End Sub


    Private Sub getPartialWorkerInfo(username As String) 'to be used when obtaining part of the worker's information
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim reader As SqlDataReader

        connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        Dim commandstring As String = "SELECT * From Workers WHERE Username = @user"
        command = New SqlCommand(commandstring, connection)
        command.Parameters.AddWithValue("@user", username)

        command.Connection.Open()
        reader = command.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            Me.username = username
            name = reader("Name")
            surname = reader("Surname")
            'email = reader("Email")
            email = reader("Email")
            ' numbers = reader("MobileNumber")
            numbers = 0
            region = ""
            JoinDate = reader("JoinDate")
            status = reader("Status")
        End If
        rating = getRating()
        connection.Close()
    End Sub


    Public Overrides Function getRating() As Integer
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim reader As SqlDataReader

        connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        Dim commandstring As String = "SELECT * From AverageWorkerRating WHERE Worker = @user"
        command = New SqlCommand(commandstring, connection)
        command.Parameters.AddWithValue("@user", username)

        command.Connection.Open()
        reader = command.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            Dim rating As Integer = 0
            If Not IsDBNull(reader("AverageRating")) Then
                rating = reader("AverageRating")
            End If
            connection.Close()
            Return rating 'returning rating value
        End If
        Return 0
    End Function

    'gettoers
    Public Function getCategory() As String
        Return category
    End Function

    Public Function getDescription() As String
        Return description
    End Function

    'setters
    Public Sub updateCategory(category As String)
        Me.category = category
    End Sub

    Public Sub updateDescription(description As String)
        Me.description = description
    End Sub

    Public Overrides Sub updateAverage(average As Integer)
        'update average rating
        Dim adconnection As SqlConnection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        adconnection.Open()
        Dim query As String = "UPDATE AverageWorkerRating SET AverageRating = @average WHERE Worker = @worker;"
        Dim command As SqlCommand = New SqlCommand(query, adconnection)
        command.Parameters.AddWithValue("@average", average)
        command.Parameters.AddWithValue("@worker", username)
        Dim reader As SqlDataReader = command.ExecuteReader()
        adconnection.Close()
        rating = average
    End Sub


    Private Sub addToAverageDatabase()
        Dim adconnection As SqlConnection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\HandymanDatabase.mdf;Integrated Security=True")
        adconnection.Open()
        Dim query As String = "INSERT INTO AverageWorkerRating (Worker, AverageRating) VALUES (@worker, @average);"
        Dim command As SqlCommand = New SqlCommand(query, adconnection)
        command.Parameters.AddWithValue("@average", 0)
        command.Parameters.AddWithValue("@worker", username)
        Dim reader As SqlDataReader = command.ExecuteReader()
        adconnection.Close()
    End Sub

End Class
