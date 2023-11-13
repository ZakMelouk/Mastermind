Imports System.Diagnostics.Eventing.Reader

Public Class Form2

    Dim LesSymboles As String()
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim Validite As Integer
        For Each Symbole As String In LesSymboles
            If (e.KeyChar = Symbole Or e.KeyChar = vbBack) Then
                Validite += 1
            End If
        Next
        If (Validite < 1) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim Validite As Integer
        For Each Symbole As String In LesSymboles
            If (e.KeyChar = Symbole Or e.KeyChar = vbBack) Then
                Validite += 1
            End If
        Next
        If (Validite < 1) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Dim Validite As Integer
        For Each Symbole As String In LesSymboles
            If (e.KeyChar = Symbole Or e.KeyChar = vbBack) Then
                Validite += 1
            End If
        Next
        If (Validite < 1) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Dim Validite As Integer
        For Each Symbole As String In LesSymboles
            If (e.KeyChar = Symbole Or e.KeyChar = vbBack) Then
                Validite += 1
            End If
        Next
        If (Validite < 1) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        Dim Validite As Integer
        For Each Symbole As String In LesSymboles
            If (e.KeyChar = Symbole Or e.KeyChar = vbBack) Then
                Validite += 1
            End If
        Next
        If (Validite < 1) Then
            e.KeyChar = Chr(0)
        End If

    End Sub
    Public Function Get_symboles_choisis() As List(Of String)
        Dim symbChoisi As New List(Of String) From {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text}
        Return symbChoisi
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MsgBox("Vous n'avez pas donné une suite entière de caractères")
        Else
            Me.Hide()
            Form3.Show()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = Color.LightBlue
        LesSymboles = GetSymboles()
        For Each symboles As String In LesSymboles
            Label2.Text = Label2.Text + symboles + " "
        Next
    End Sub


End Class