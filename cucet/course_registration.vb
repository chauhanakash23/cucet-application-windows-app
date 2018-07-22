Imports MySql.Data.MySqlClient

Public Class course_registration

    Private Sub course_registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "user" And TextBox2.Text = "password" Then
            GroupBox1.Enabled = True


            Dim con As New MySqlConnection
            Dim DatabaseName As String = "cucet"
            Dim server As String = "localhost"
            Dim db_user As String = "root"
            Dim db_pass As String = "123"

            Dim ds As New DataSet
            Dim da As New MySqlDataAdapter
            If Not con Is Nothing Then con.Close()
            con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, db_user, db_pass, DatabaseName)
            Try
                con.Open()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
            Dim cmd As New MySqlCommand(String.Format("select * from `schools` "), con)
            da = New MySqlDataAdapter(cmd)
            da.Fill(ds, "schools")
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.DisplayMember = "school"
            con.Close()


        Else
            MsgBox("Enter correct user and password!")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New MySqlConnection
        Dim DatabaseName As String = "cucet"
        Dim server As String = "localhost"
        Dim db_user As String = "root"
        Dim db_pass As String = "123"
        Dim school = ComboBox1.SelectedItem(0)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter
        If Not con Is Nothing Then con.Close()
        con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, db_user, db_pass, DatabaseName)
        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try

        Dim cmd As New MySqlCommand(String.Format("select * from `departments` where school='{0}'", school), con)
        da = New MySqlDataAdapter(cmd)
        da.Fill(ds, "departments")
        ComboBox2.DataSource = ds.Tables(0)
        ComboBox2.DisplayMember = "department"
        con.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim con As New MySqlConnection
        Dim DatabaseName As String = "cucet"
        Dim server As String = "localhost"
        Dim db_user As String = "root"
        Dim db_pass As String = "123"
        Dim department = ComboBox2.SelectedItem(1)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter
        If Not con Is Nothing Then con.Close()
        con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, db_user, db_pass, DatabaseName)
        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
        Dim cmd As New MySqlCommand(String.Format("select * from `programs` where department='{0}'", department), con)
        da = New MySqlDataAdapter(cmd)
        da.Fill(ds, "programs")
        ComboBox4.DataSource = ds.Tables(0)
        ComboBox4.DisplayMember = "program"
        con.Close()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim con As New MySqlConnection
        Dim DatabaseName As String = "cucet"
        Dim server As String = "localhost"
        Dim db_user As String = "root"
        Dim db_pass As String = "123"
        Dim program = ComboBox4.SelectedItem(0)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter
        If Not con Is Nothing Then con.Close()
        con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, db_user, db_pass, DatabaseName)
        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
        Dim cmd As New MySqlCommand(String.Format("select * from `courses` where program='{0}'", program), con)
        da = New MySqlDataAdapter(cmd)
        da.Fill(ds, "courses")
        ComboBox3.DataSource = ds.Tables(0)
        ComboBox3.DisplayMember = "course"
        con.Close()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim school = ComboBox1.SelectedItem(0)
        Dim course = ComboBox3.SelectedItem(1)
        Dim department = ComboBox2.SelectedItem(1)
        Dim program = ComboBox4.SelectedItem(0)
        Dim semester = ComboBox5.SelectedItem(0)
        'MsgBox(school + course + department + program + semester)
        Dim name = "GreatName GreatSurname"
        Dim con As New MySqlConnection
        Dim DatabaseName As String = "cucet"
        Dim server As String = "localhost"
        Dim db_user As String = "root"
        Dim db_pass As String = "123"
        If Not con Is Nothing Then con.Close()
        con.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, db_user, db_pass, DatabaseName)
        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
        Dim cmd As New MySqlCommand(String.Format("INSERT INTO `cucet`.`reg_courses`
    (`name`,
    `course`,
    `semester`,
    `department`,
    `program`)
    VALUES
    ('{0}','{1}','{2}','{3}','{4}');
    ", name, course, semester, department, program), con)
        cmd.ExecuteNonQuery()
        MsgBox("Submited!")
        con.Close()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub
End Class