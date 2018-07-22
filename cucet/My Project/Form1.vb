Imports MySql.Data.MySqlClient


Public Class Form1
    Dim flag_course_changed = 0
    Dim flag_department_changed = 0
    Dim flag_school_changed = 0
    Dim flag_program_changed = 0
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
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
        TextBox3.Text = ComboBox1.SelectedItem(0)
        flag_course_changed = 0
        flag_department_changed = 0
        flag_program_changed = 0
        flag_school_changed = 0
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
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
        TextBox4.Text = ComboBox2.SelectedItem(1)
        flag_course_changed = 0
        flag_department_changed = 0
        flag_program_changed = 0
        flag_school_changed = 0
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
        TextBox5.Text = ComboBox4.SelectedItem(0)
        flag_course_changed = 0
        flag_department_changed = 0
        flag_program_changed = 0
        flag_school_changed = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "Admin" And TextBox2.Text = "password" Then
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
            GroupBox1.Enabled = True
            flag_course_changed = 0
            flag_department_changed = 0
            flag_program_changed = 0
            flag_school_changed = 0
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Enabled = False
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        flag_department_changed = 1
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox6.Text = ComboBox3.SelectedItem(1)
        flag_course_changed = 0
        flag_department_changed = 0
        flag_program_changed = 0
        flag_school_changed = 0
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim course = TextBox6.Text
        Dim program = TextBox5.Text
        Dim department = TextBox4.Text
        Dim school = TextBox3.Text
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

        If flag_school_changed Then
            MsgBox("school")
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO `cucet`.`school`
            (`school`,
            `department`)
            VALUES
            ('{0}','{1}');
            ", school, department), con)
            cmd.ExecuteNonQuery()
        End If
        If flag_department_changed Then

            Dim cmd As New MySqlCommand(String.Format("INSERT INTO `cucet`.`departments`
            (`department`,
            `school`)
            VALUES
            ('{0}','{1}');
            ", department, school), con)
            cmd.ExecuteNonQuery()
        End If
        If flag_course_changed Then
            MsgBox("course")
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO `cucet`.`courses`
            (`course`,
            `program`)
            VALUES
            ('{0}','{1}');
            ", course, program), con)
            cmd.ExecuteNonQuery()
        End If
        If flag_program_changed Then
            MsgBox("program")
            Dim cmd As New MySqlCommand(String.Format("INSERT INTO `cucet`.`programs`
            (`department`,
            `program`)
            VALUES
            ('{0}','{1}');
            ", department, program), con)
            cmd.ExecuteNonQuery()
        End If




        MsgBox("Submited!")
        con.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        flag_school_changed = 1
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        flag_program_changed = 1
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        flag_course_changed = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim course = TextBox6.Text
        Dim program = TextBox5.Text
        Dim department = TextBox4.Text
        Dim school = TextBox3.Text
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
        Dim cmd1 As New MySqlCommand(String.Format("delete from `cucet`.`schools`
            where school='{0}';", school), con)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand(String.Format("delete from `cucet`.`departments`
            where department='{0}';", department), con)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand(String.Format("delete from `cucet`.`programs`
            where program='{0}';", program), con)
        cmd3.ExecuteNonQuery()
        Dim cmd4 As New MySqlCommand(String.Format("delete from `cucet`.`courses`
            where course='{0}';", course), con)
        cmd4.ExecuteNonQuery()
    End Sub
End Class