Imports System.Data.SqlClient
Imports System.IO
Imports MySql.Data.MySqlClient
Public Class Apply
    Dim mysqlconn As MySqlConnection
    Dim cmd As MySqlCommand
    Public Property OpenFileDialog1 As Object

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Photobox.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text = "" Then MessageBox.Show("Please enter the first name")
        If TextBox2.Text = "" Then MessageBox.Show("Please enter the last name")
        If TextBox3.Text = "" Then MessageBox.Show("Please enter the phone number")
        If TextBox4.Text = "" Then MessageBox.Show("Please enter the nationality")
        If TextBox5.Text = "" Then MessageBox.Show("Please enter the e-mail")
        If TextBox6.Text = "" Then MessageBox.Show("Please enter the religion")
        If TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Then MessageBox.Show("Address not entered properly")
        If TextBox13.Text = "" Or TextBox14.Text = "" Or TextBox15.Text = "" Or TextBox16.Text = "" Or TextBox17.Text = "" Or TextBox18.Text = "" Or TextBox19.Text = "" Or TextBox20.Text = "" Then MessageBox.Show("Education record not entered properly")

        If ComboBox1.Text = "Master's" And (TextBox21.Text = "" Or TextBox22.Text = "" Or TextBox23.Text = "" Or TextBox24.Text = "") Then MessageBox.Show("Education details not entered properly")

        If ComboBox2.Text = "Select Category" Then MessageBox.Show("Please select the category you belong to")
        If ComboBox3.Text = "Date" Then MessageBox.Show("Please enter your date of birth correctly")
        If ComboBox4.Text = "Year" Then MessageBox.Show("Please enter your date of birth correctly")
        If ComboBox5.Text = "Month" Then MessageBox.Show("Please enter your date of birth correctly")
        If ComboBox6.Text = "Select Gender" Then MessageBox.Show("Please select your gender")

        If Photobox.Image Is Nothing Then MessageBox.Show("Candidate must upload their photograph")
        If PictureBox2.Image Is Nothing Then MessageBox.Show("Candidate must upload their signature")



        Dim mstream As New System.IO.MemoryStream
        Photobox.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim photo() As Byte = mstream.GetBuffer

        PictureBox2.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim sign() As Byte = mstream.GetBuffer

        mstream.Close()
        Dim fn = TextBox1.Text
        Dim ln = TextBox2.Text
        Dim gender As String = ComboBox6.SelectedItem.ToString
        Dim day As String = ComboBox3.SelectedItem.ToString
        Dim mon As String = ComboBox5.SelectedItem.ToString
        Dim year As String = ComboBox4.SelectedItem.ToString
        Dim program As String = ComboBox1.SelectedItem.ToString
        Dim mail As String = TextBox5.Text
        Dim phone As String = TextBox3.Text
        Dim nat As String = TextBox4.Text
        Dim dob As String = String.Concat(day, "-", mon, "-", year)
        Dim category As String = ComboBox2.SelectedItem.ToString
        Dim address As String = String.Concat(TextBox7.Text, " ", TextBox8.Text, " ", TextBox9.Text, " ", TextBox10.Text, " ", TextBox11.Text, " ", TextBox12.Text)
        Dim prog As String = ComboBox1.SelectedItem.ToString
        Dim religion As String = TextBox6.Text

        Dim appno As Integer
        Dim random As New Random
        appno = random.Next()

        Dim mysqlconn As New MySqlConnection
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;userid=root;password=123;database=cucet"

        Try
            mysqlconn.Open()
            cmd = New MySqlCommand()
            cmd.Connection = mysqlconn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = String.Format("insert into candidate values (" & appno & ",'" & fn & "','" & ln & "','" & dob & "','" & phone & "','" & category & "','" & gender & "','" & nat & "','" & mail & "','" & religion & "','" & address & "','" & program & "',  @photo , @sign  );")
            'cmd.CommandText = String.Format("@photo")

            'MsgBox(photo)
            cmd.Parameters.AddWithValue("@photo", photo)
            cmd.Parameters.AddWithValue("@sign", sign)
            'MsgBox(cmd.CommandText)
            cmd.ExecuteNonQuery()

            MsgBox("Application Submitted proceed To payment")
            mysqlconn.Close()

        Catch ex As MySqlException

            MessageBox.Show(ex.Message)
        Catch e1 As NullReferenceException
            MessageBox.Show(e1.Message)

        Finally
            mysqlconn.Dispose()

        End Try

        subapp.Show()
        Me.Hide()

        Dim stm As String = "Select no from cucet.appno order by no desc LIMIT 1 "
        Dim numb As Integer


        Try

            mysqlconn.Open()

            Dim cmd As MySqlCommand = New MySqlCommand(stm, mysqlconn)

            numb = CInt(cmd.ExecuteScalar())


            Console.WriteLine("MySQL version  {0}", appno)
            cmd.CommandText = "Insert into cucet.appno(no) values('" & (appno) & "')"
            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            mysqlconn.Close()
        End Try

        Try

            cmd.CommandText = "select photo from cucet.candidate where fn = '" + TextBox1.Text + "' and mail='" + TextBox5.Text + "'"
            cmd.Connection = mysqlconn
            Dim da As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds, "photo")
            Dim c As Integer = ds.Tables(0).Rows.Count
            If c > 0 Then
                Dim bytBLOBData() As Byte =
                    ds.Tables(0).Rows(c - 1)("photo")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                subapp.Photograph.Image = Image.FromStream(stmBLOBData)
            End If

        Catch emy As MySqlException
            MessageBox.Show(emy.Message)
        End Try

        subapp.Label11.Text = TextBox1.Text + TextBox2.Text
        subapp.Label12.Text = TextBox3.Text
        subapp.Label13.Text = ComboBox6.Text
        subapp.Label14.Text = ComboBox3.Text + "-" + ComboBox5.Text + "-" + ComboBox4.Text
        subapp.Label15.Text = TextBox5.Text
        subapp.Label16.Text = ComboBox2.Text
        subapp.Label17.Text = TextBox7.Text + "," + TextBox8.Text + "," + TextBox9.Text + "," + TextBox10.Text + "," + TextBox11.Text + "," + TextBox12.Text
        subapp.Label18.Text = "CUCET2018000" + CStr(appno)

    End Sub

    Private Function Format() As String
        Throw New NotImplementedException()
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ComboBox1.Text = "Integrated Master's" Then
            TextBox21.Enabled = False
            TextBox22.Enabled = False
            TextBox23.Enabled = False
            TextBox24.Enabled = False
        Else
            TextBox21.Enabled = True
            TextBox22.Enabled = True
            TextBox23.Enabled = True
            TextBox24.Enabled = True
        End If
    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)



    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox1.Checked = True
        Button3.Enabled = True
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged


        If ComboBox1.Text = "Integrated Masters" Then
            TextBox21.Enabled = False
            TextBox22.Enabled = False
            TextBox23.Enabled = False
            TextBox24.Enabled = False
        Else
            TextBox21.Enabled = True
            TextBox22.Enabled = True
            TextBox23.Enabled = True
            TextBox24.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        If String.Compare(ComboBox8.SelectedItem, ComboBox7.SelectedItem) = 0 Then
            MessageBox.Show("Preferences must be unique")
            ComboBox8.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        If String.Compare(ComboBox9.SelectedItem, ComboBox8.SelectedItem) = 0 Or String.Compare(ComboBox9.SelectedItem, ComboBox7.SelectedItem) = 0 Then
            MessageBox.Show("Preferences must be unique")
            ComboBox9.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Photobox.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Uploads_Enter(sender As Object, e As EventArgs) Handles Uploads.Enter

    End Sub


    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
        End If

    End Sub
    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged

    End Sub
End Class