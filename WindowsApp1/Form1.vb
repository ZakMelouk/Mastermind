Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (ComboBox1.Text.Length > 0 And ComboBox2.Text.Length > 0) Then
            If (ComboBox1.Text.ToLower.Equals(ComboBox2.Text.ToLower).Equals(False)) Then
                DebutPartie(ComboBox1.Text, ComboBox2.Text)
                Dim joueur1 As String = ComboBox1.Text
                ComboBox1.Text = ComboBox2.Text
                ComboBox2.Text = joueur1
                Me.Hide()
                Dim LaListe = ListeJoueur()
                For Each j As String In LaListe
                    If (ComboBox1.Items.Contains(j)) Then
                    ElseIf (j = "") Then
                    Else
                        ComboBox1.Items.Add(j)
                        ComboBox2.Items.Add(j)
                    End If
                Next
                Form2.Show()
            Else
                MsgBox("Les deux ne joueurs ne peuvent pas porter le même nom")
            End If
        Else
            MsgBox("Vous n'avez pas saisit tout les noms")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Monmessage As String = "Etes vous sur de vouloir quitter la partie"
        If (MsgBox(Monmessage, vbYesNo) = MsgBoxResult.Yes) Then
            Ecriture()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialise()
        BackColor = Color.LightBlue
        If (LesJoueurs.GetNbPartie = 0) Then
            If My.Computer.FileSystem.FileExists("./Sauvegarde.txt") Then
                Lecture()
                Dim LaListe = ListeJoueur()
                For Each j As String In LaListe
                    If (ComboBox1.Items.Contains(j)) Then
                    ElseIf (j = "") Then
                    Else
                        ComboBox1.Items.Add(j)
                        ComboBox2.Items.Add(j)
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form5.Show()
    End Sub


End Class