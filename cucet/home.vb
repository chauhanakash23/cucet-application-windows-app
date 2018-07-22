Public Class home
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()

        syllabus.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        uni.Show()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()

        importantdate.Show()


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()

        program.Show()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        contact.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("No answer keys available at the moment ")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Apply.Button3.Enabled = False
        Apply.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label1.Text = "P1" Then
            PictureBox2.Image = My.Resources.rajasthan
            Label1.Text = "P2"
        ElseIf Label1.Text = "P2" Then
            PictureBox2.Image = My.Resources.jharkhand
            Label1.Text = "P3"
        ElseIf Label1.Text = "P3" Then
            PictureBox2.Image = My.Resources.haryana
            Label1.Text = "P4"
        ElseIf Label1.Text = "P4" Then
            PictureBox2.Image = My.Resources.jharkhand_1
            Label1.Text = "P5"
        ElseIf Label1.Text = "P5" Then
            PictureBox2.Image = My.Resources.rajasthan2
            Label1.Text = "P1"

        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        course_registration.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()

    End Sub
End Class
