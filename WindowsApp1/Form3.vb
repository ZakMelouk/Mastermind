Imports System.Diagnostics.Eventing.Reader
Imports System.Reflection

Public Class Form3

    Dim Compteur As Integer
    Dim Temps_limite As TimeSpan
    Dim NbEssaisAutorisé As Integer
    Dim temps As TimeSpan
    Private ReadOnly seconde As TimeSpan = New TimeSpan(0, 0, 1)
    Dim symbChoisi As List(Of String) = Form2.Get_symboles_choisis()
    Dim LesSymbolesAutorisés As String()

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress

        Dim Validite As Integer
        For Each Symbole As String In LesSymbolesAutorisés
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
        For Each Symbole As String In LesSymbolesAutorisés
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
        For Each Symbole As String In LesSymbolesAutorisés
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
        For Each Symbole As String In LesSymbolesAutorisés
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
        For Each Symbole As String In LesSymbolesAutorisés
            If (e.KeyChar = Symbole Or e.KeyChar = vbBack) Then
                Validite += 1
            End If
        Next
        If (Validite < 1) Then
            e.KeyChar = Chr(0)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox3.BackColor = Color.White
        TextBox4.BackColor = Color.White
        TextBox5.BackColor = Color.White
        RichTextBox1.AppendText("   ")
        Dim lst_symb As New List(Of TextBox) From {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5}
        For Each texte As String In symbChoisi
            For Each texte2 As TextBox In lst_symb
                If texte2.Text = texte Then
                    texte2.BackColor = GetCouleurPresent()
                End If

            Next
        Next
        Dim Bonneréponse As Integer
        For index As Integer = 0 To 4
            If (lst_symb(index).Text = symbChoisi(index)) Then
                lst_symb(index).BackColor = GetCouleurBienPlace()
                Bonneréponse += 1
            End If
            If (lst_symb(index).BackColor = GetCouleurBienPlace() Or lst_symb(index).BackColor = GetCouleurPresent()) Then
            Else
                If (GetCouleurAbsent() = Color.Black) Then
                Else
                    lst_symb(index).BackColor = GetCouleurAbsent()
                End If
            End If

        Next
        For Each txt_box As TextBox In lst_symb
            If (txt_box.BackColor = GetCouleurBienPlace() Or txt_box.BackColor = GetCouleurPresent()) Then
                RichTextBox1.SelectionColor = txt_box.BackColor
            Else
                If (GetNouvelleCouleurAbsent.Equals(True)) Then
                    RichTextBox1.SelectionColor = txt_box.BackColor
                Else
                    RichTextBox1.SelectionColor = Color.Black
                End If
            End If
            RichTextBox1.AppendText(txt_box.Text)
            RichTextBox1.AppendText("  ")
        Next

        RichTextBox1.AppendText(Chr(13) & Chr(10))

        If (Bonneréponse = 5) Then
            Dim NomJoueurPerdant As String = GetNomJoueur1()
            Dim NomJoueurGagnant As String = GetNomJoueur2()
            SetScore(NomJoueurGagnant)
            SetMeilleurTemps(NomJoueurGagnant, temps)
            SetTempsJoueur(NomJoueurGagnant, temps)
            Label8.Show()
            Button2.Show()
            Label10.Hide()
            Label11.Hide()
            Button1.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False

        Else
            Compteur += 1
            Label10.Text = ("Nombre d'essais restants : " & NbEssaisAutorisé - Compteur)
            If (Compteur = NbEssaisAutorisé) Then
                Dim NomJoueurGagnant As String = GetNomJoueur1()
                Dim NomJoueurPerdant As String = GetNomJoueur2()
                SetTempsJoueur(NomJoueurPerdant, temps)
                SetScore(NomJoueurGagnant)
                Label9.Show()
                Button2.Show()
                Label10.Hide()
                Label11.Hide()
                Button1.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
            End If
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = Color.LightBlue
        Temps_limite = GetTemps()
        NbEssaisAutorisé = GetNbEssais()
        Label10.Text = ("Nombre d'essais restants : " & NbEssaisAutorisé)
        Label11.Text = ("Le temps restant est de : " & Temps_limite.ToString)
        Label4.ForeColor = GetCouleurPresent()
        Label5.ForeColor = GetCouleurBienPlace()
        If (GetNouvelleCouleurAbsent.Equals(True)) Then
            Label3.ForeColor = GetCouleurAbsent()
        End If
        LesSymbolesAutorisés = GetSymboles()

        For Each symboles As String In LesSymbolesAutorisés
            Label2.Text = Label2.Text + symboles + " "
        Next
        TextBox1.Focus()
        TextBox1.Select()
        Timer1.Start()
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox3.BackColor = Color.White
        TextBox4.BackColor = Color.White
        TextBox5.BackColor = Color.White
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetNbPartie()
        Me.Close()
        Form2.Close()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Timer1.Tick, Button3.Click
        If (GetPasDeTemps.Equals(True)) Then
            Return
        End If
        temps = temps.Add(seconde)
        If (temps = Temps_limite) Then
            Dim NomJoueurGagnant As String = GetNomJoueur1()
            Dim NomJoueurPerdant As String = GetNomJoueur2()
            SetScore(NomJoueurGagnant)
            SetTempsJoueur(NomJoueurPerdant, temps)
            Label10.Hide()
            Label11.Hide()
            Timer1.Stop()
            Label9.Show()
            Button2.Show()
            Button1.Enabled = False
        Else
            Dim Temps_afficher = Temps_limite - temps
            Label11.Text = ("Le temps restant est de : " & Temps_afficher.ToString)
        End If
    End Sub


End Class