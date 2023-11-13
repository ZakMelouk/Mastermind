Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form5
    Dim SymboleRepete As Boolean = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub
    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs)
        ColorDialog1.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox1.Text = "") Then
            MsgBox("Vous n'avez saisit aucun caractère")
            Return
        End If
        Dim NouveauxSymboles As String() = Split(TextBox1.Text, " ")
        SetSymboles(NouveauxSymboles)
        MsgBox("Les symboles autorisés ont été changés")
        Label8.Text = "Les symboles autorisés sont " + TextBox1.Text
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim tab As String() = Split(TextBox1.Text, " ")
        For Each symbole As String In tab
            If (e.KeyChar = symbole) Then
                e.KeyChar = Chr(0)
                SymboleRepete = True
                Return
            Else
                If (e.KeyChar = vbBack) Then
                    SymboleRepete = True
                    e.KeyChar = Chr(0)
                    Return
                Else
                    SymboleRepete = False
                End If
            End If
        Next
        If (SymboleRepete = False) Then
            TextBox1.Text = " " & TextBox1.Text
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
    End Sub

    Private Sub ColorDialog1_HelpRequest(sender As Object, e As EventArgs) Handles ColorDialog1.HelpRequest
        MsgBox("Vous pouvez choisir une couleur pour tout les indicateurs")
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackColor = Color.LightBlue

        Label6.Text = "Le temps actuel est " & GetTemps.ToString
        Label7.Text = "Le nombre d'essais actuel est de " & GetNbEssais()
        Label8.Text = "Les symboles autorisés sont "
        Dim lessysmboles = GetSymboles()
        Label8.Text = "Les symboles autorisés sont "
        For Each s As String In lessysmboles
            Label8.Text = Label8.Text + " " + s
        Next
        If (GetNouvelleCouleurAbsent.Equals(True)) Then
            Button4.ForeColor = GetCouleurAbsent()
        Else
            Button4.ForeColor = Color.Black
        End If
        Button5.ForeColor = GetCouleurPresent()
        Button6.ForeColor = GetCouleurBienPlace()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            Button4.ForeColor = ColorDialog1.Color
            SetCouleurAbsent(ColorDialog1.Color)
            SetNouvelleCouleurAbsent(True)
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (ColorDialog2.ShowDialog() = DialogResult.OK) Then
            Button5.ForeColor = ColorDialog2.Color
            SetCouleurPresent(ColorDialog2.Color)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (ColorDialog3.ShowDialog() = DialogResult.OK) Then
            Button6.ForeColor = ColorDialog3.Color
            SetCouleurBienPlace(ColorDialog3.Color)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox2.Text = "") Then
            MsgBox("Vous n'avez rien saisit")
            Return
        End If
        If (TextBox2.Text < "1") Then
            MsgBox("Le nouveau temps n'est pas valide,pour désactiver le minuteur appuyer sur le bouton qui est fait pour cela")
            Return
        End If
        MsgBox("Le nouveau temps pour le minuteur est activé")
        Dim temps As TimeSpan = New TimeSpan(0, 0, TextBox2.Text)
        SetTemps(temps)
        Label6.Text = "Le temps actuel est " & GetTemps.ToString
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MsgBox("Le minuteur est désactivé")
        SetPasDeTemps(True)
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar < "0" Or e.KeyChar > "9") Then
            If (e.KeyChar = vbBack) Then
            Else
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (TextBox3.Text = "") Then
            MsgBox("Vous n'avez rien saisit")
            Return
        End If
        If (TextBox3.Text = "0") Then
            MsgBox("Le nombre d'essais ne peut pas être de 0")
            Return
        End If
        MsgBox("Le nouveau nombre d'essai à été enregistré")
        SetNbEssais(TextBox3.Text)
        Label7.Text = "Le nombre d'essais actuel est de " & GetNbEssais()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        MsgBox("Les lettres saisit en majuscules sont différentes des lettres saisit en minuscules")
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Initialise()
        Label6.Text = "Le temps actuel est " & GetTemps.ToString
        Label7.Text = "Le nombre d'essais actuel est de " & GetNbEssais()
        Label8.Text = "Les symboles autorisés sont "
        Dim lessysmboles = GetSymboles()
        Label8.Text = "Les symboles autorisés sont "
        For Each s As String In lessysmboles
            Label8.Text = Label8.Text + " " + s
        Next
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        Button4.ForeColor = Color.Black
        Button5.ForeColor = Color.Green
        Button6.ForeColor = Color.Blue
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (e.KeyChar < "0" Or e.KeyChar > "9") Then
            If (e.KeyChar = vbBack) Then
            Else
                e.KeyChar = Chr(0)
            End If
        End If

    End Sub

End Class