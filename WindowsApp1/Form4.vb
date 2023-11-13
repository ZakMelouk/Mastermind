Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form4
    Dim LesJoueurs As New List(Of String) From {}

    Private Sub remplir(listejoueur As Joueurs())
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        For Each j As Joueurs In listejoueur
            If (j.Nom = "") Then
            Else
                ListBox1.Items.Add(j.Nom)
            End If
        Next
        For Each j As Joueurs In listejoueur
            If (j.Nom = "") Then
            Else
                ListBox2.Items.Add(j.Score)
            End If
        Next
        For Each j As Joueurs In listejoueur
            If (j.Nom = "") Then
            Else
                ListBox3.Items.Add(j.NbPartiePremierJoueur)
            End If
        Next
        For Each j As Joueurs In listejoueur
            If (j.Nom = "") Then
            Else
                ListBox4.Items.Add(j.NbPartieDeuxiemeJoueur)
            End If
        Next
        For Each j As Joueurs In listejoueur
            If (j.Nom = "") Then
            Else
                ListBox5.Items.Add(j.MeilleurTemps)
            End If
        Next
        For Each j As Joueurs In listejoueur
            If (j.Nom = "") Then
            Else
                ListBox6.Items.Add(j.TempsPasse)
            End If
        Next

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = Color.LightBlue
        ComboBox1.Text = "Rechercher"

        If (getnbjoueur() = 0) Then
            Return
        End If
        Dim ListeDesJoueurs = GetToutLesJoueurs()
        remplir(ListeDesJoueurs)
        LesJoueurs = ListeJoueur()
        For Each j As String In LesJoueurs
            If (ComboBox1.Items.Contains(j)) Then
            ElseIf (j = "") Then
            Else
                ComboBox1.Items.Add(j)
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LesJoueurs = ListeJoueur()
        For Each j As String In LesJoueurs
            If (ComboBox1.SelectedItem = j) Then
                Dim joueur As Joueurs = GetJoueur(ComboBox1.SelectedItem)
                MsgBox("Voici les statistiques de: " & joueur.Nom & (Chr(13) & Chr(10)) & " Score : " & joueur.Score & (Chr(13) & Chr(10)) &
                       " Meilleur temps pour deviner une combinaison " & joueur.MeilleurTemps.ToString & (Chr(13) & Chr(10)) &
                       " Nombre de partie en tant que premier joueur " & joueur.NbPartiePremierJoueur & (Chr(13) & Chr(10)) &
"Nombre de partie en tant que deuxième joueur " & joueur.NbPartieDeuxiemeJoueur & (Chr(13) & Chr(10)) & " Cumul du temps passé à tenter des combinais
on " & joueur.TempsPasse.ToString)
            End If
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SetSelected(ListBox1.SelectedIndex, True)
        ListBox3.SetSelected(ListBox1.SelectedIndex, True)
        ListBox4.SetSelected(ListBox1.SelectedIndex, True)
        ListBox5.SetSelected(ListBox1.SelectedIndex, True)
        ListBox6.SetSelected(ListBox1.SelectedIndex, True)
    End Sub

    Private Sub ListBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox7.SelectedIndexChanged
        If (getnbjoueur() = 0) Then
            Return
        End If
        If (ListBox7.SelectedIndex = 0) Then
            Dim Joueurstriés As Joueurs() = GetJoueurParOrdreAlphabetique()
            remplir(Joueurstriés)
        ElseIf (ListBox7.SelectedIndex = 1) Then
            Dim JoueursTriés As Joueurs() = GetJoueurParScore()
            remplir(JoueursTriés)
        ElseIf (ListBox7.SelectedIndex = 2) Then
            Dim JoueursTriés As Joueurs() = GetJoueurParTemps()
            remplir(JoueursTriés)
        End If
    End Sub
End Class