Imports System.IO
Public Class Form1

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Put PES 5 Option File in the same folder as this program
        Dim of_file_location As String = "KONAMI-WIN32PES4OPT"
        'Load/decrypt the option file
        read_option_file(of_file_location)
        MsgBox("Option file loaded.")

        'Save decrypt of_file
        IO.File.WriteAllBytes("temp.bin", of_file)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Put PES 5 Option File in the same folder as this program
        Dim of_file_location As String = "KONAMI-WIN32PES4OPT"

        'Save/encrypt the option file (of ARRAY)
        save_option_file(of_file_location)

        'Save/encrypt 2 the option file (from FILE)
        'save_option_file(of_file_location, "temp.bin")
        MsgBox("Option file saved.")
    End Sub




#Region "TEAM NAME"

    'UPDATE team Name
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        update_name(TextBox1.Text)
        ListBox1.Items(ListBox1.SelectedIndex) = TextBox1.Text
    End Sub
    'LOAD team names
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If of_file Is Nothing Then
            MsgBox("No Open OF File")
        Else
            ListBox1.Items.Clear()
            set_clubs()
            For i = 0 To clubs.Length - 1
                ListBox1.Items.Add(clubs(i))
            Next
        End If
    End Sub
    'READ team Name
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = name_read(ListBox1.SelectedIndex)
    End Sub

#End Region
End Class
