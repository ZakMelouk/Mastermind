Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.Devices
Imports WindowsApp1.LesJoueurs

Module LesJoueurs

    Public Structure Joueurs
        Public Nom As String
        Public Score As Integer
        Public MeilleurTemps As TimeSpan
        Public NbPartiePremierJoueur As Integer
        Public NbPartieDeuxiemeJoueur As Integer
        Public TempsPasse As TimeSpan
    End Structure

    Private ReadOnly PasExtension As Integer = 1
    Private Compteur As Integer
    Private NbPartie As Integer
    Private nomjoueur1 As String = " "
    Private nomjoueur2 As String = " "
    Private MesJoueurs(0) As Joueurs

    Public Function GetJoueur(nom As String) As Joueurs
        For Each j As Joueurs In MesJoueurs
            If (j.Nom = nom) Then
                Return j
            End If
        Next
    End Function
    Public Sub SetNomPremierJoueur(nom As String)
        nomjoueur1 = nom
    End Sub
    Public Sub SetNomDeuxiemeJoueur(nom As String)
        nomjoueur2 = nom
    End Sub
    Sub SetJoueur(nom As String)
        Dim j As Joueurs
        j.Nom = nom
        If Compteur >= MesJoueurs.Length Then
            ReDim Preserve MesJoueurs(Compteur)
        End If
        MesJoueurs(Compteur) = j
        Compteur += 1
    End Sub

    Sub SetJoueurExistant(nom As String, Score As Integer, TempsPasse As TimeSpan, MeilleurTemps As TimeSpan, nbpremier As Integer, NbDeuxieme As Integer)
        Dim j As Joueurs
        j.Nom = nom
        j.Score = Score
        j.TempsPasse = TempsPasse
        j.MeilleurTemps = MeilleurTemps
        j.NbPartiePremierJoueur = nbpremier
        j.NbPartieDeuxiemeJoueur = NbDeuxieme
        If Compteur >= MesJoueurs.Length Then
            ReDim Preserve MesJoueurs(Compteur)
        End If
        MesJoueurs(Compteur) = j
        Compteur += 1
    End Sub

    Public Function GetIndex(Nom As String) As Integer
        If (Compteur = 0) Then
            Return -1
        End If
        For index As Integer = 0 To MesJoueurs.Length - 1
            If (MesJoueurs(index).Nom.Equals(Nom)) Then
                Return index
            End If
        Next
        Return -1
    End Function

    Public Sub SetNbPremierJoueur(Nom As String)
        For index As Integer = 0 To MesJoueurs.Length - 1
            If (MesJoueurs(index).Nom.Equals(Nom)) Then
                MesJoueurs(index).NbPartiePremierJoueur += 1
            End If
        Next
    End Sub
    Public Sub SetNbDeuxiemeJoueur(Nom As String)
        For index As Integer = 0 To MesJoueurs.Length - 1
            If (MesJoueurs(index).Nom.Equals(Nom)) Then
                MesJoueurs(index).NbPartieDeuxiemeJoueur += 1
            End If
        Next
    End Sub
    Public Sub SetScore(Nom As String)
        For index As Integer = 0 To MesJoueurs.Length - 1
            If (MesJoueurs(index).Nom.Equals(Nom)) Then
                MesJoueurs(index).Score += 1
                Return
            End If
        Next
    End Sub

    Public Sub SetTempsJoueur(nom As String, Temps As TimeSpan)
        For index As Integer = 0 To MesJoueurs.Length - 1
            If (MesJoueurs(index).Nom.Equals(nom)) Then
                MesJoueurs(index).TempsPasse = MesJoueurs(index).TempsPasse.Add(Temps)
                Return
            End If
        Next
    End Sub
    Public Sub SetMeilleurTemps(nom As String, Temps As TimeSpan)
        For index As Integer = 0 To MesJoueurs.Length - 1
            If (MesJoueurs(index).Nom.Equals(nom)) Then
                If (MesJoueurs(index).MeilleurTemps > Temps) Then
                    MesJoueurs(index).MeilleurTemps = Temps
                    Return
                End If
                If (MesJoueurs(index).MeilleurTemps = New TimeSpan(0, 0, 0)) Then
                    MesJoueurs(index).MeilleurTemps = Temps
                    Return
                End If
            End If
        Next
    End Sub

    Public Sub SetNbPartie()
        NbPartie += 1
    End Sub

    Sub DebutPartie(Nom1 As String, Nom2 As String)
        LesJoueurs.nomjoueur1 = Nom1
        LesJoueurs.nomjoueur2 = Nom2
        Dim Index As Integer = GetIndex(Nom1)
        If (Index = -1) Then
            SetJoueur(Nom1)
            Index = GetIndex(Nom1)
        End If
        MesJoueurs(Index).NbPartiePremierJoueur += 1

        Index = GetIndex(Nom2)
        If (Index = -1) Then
            SetJoueur(Nom2)
            Index = GetIndex(Nom2)
        End If
        MesJoueurs(Index).NbPartieDeuxiemeJoueur += 1
    End Sub

    Public Function GetNbPartie() As Integer
        Return NbPartie
    End Function

    Public Function ListeJoueur() As List(Of String)
        Dim LaListe = New List(Of String) From {""}
        For index As Integer = 0 To Compteur - 1
            LaListe.Add(MesJoueurs(index).Nom)
        Next
        Return LaListe
    End Function

    Public Function GetToutLesJoueurs() As Joueurs()
        Return MesJoueurs
    End Function

    Public Function GetNomJoueur1() As String
        Return nomjoueur1
    End Function
    Public Function GetNomJoueur2() As String
        Return nomjoueur2
    End Function

    Public Sub Lecture()
        Dim Sauvegarde As Integer = FreeFile()
        Dim s As String = ""
        FileOpen(Sauvegarde, "./Sauvegarde.txt", OpenMode.Input)
        While Not EOF(Sauvegarde)
            Dim nom As String = ""
            Dim Score As String = ""
            Dim NbPremierePartie As String = ""
            Dim NbDeuxiemePartie As String = ""
            Dim MeilleurTempsstring As String = ""
            Dim TempsPasseString As String = ""
            Dim j As Joueurs = New Joueurs()
            Input(Sauvegarde, nom)
            Input(Sauvegarde, Score)
            Input(Sauvegarde, NbPremierePartie)
            Input(Sauvegarde, NbDeuxiemePartie)
            Input(Sauvegarde, MeilleurTempsstring)
            Dim MeilleurTemps As TimeSpan = New TimeSpan(0, 0, MeilleurTempsstring)
            Input(Sauvegarde, TempsPasseString)
            Dim TempPasse As TimeSpan = New TimeSpan(0, 0, TempsPasseString)
            SetJoueurExistant(nom, Score, TempPasse, MeilleurTemps, NbPremierePartie, NbDeuxiemePartie)
        End While
        FileClose(Sauvegarde)
    End Sub
    Public Sub Ecriture()
        Dim f As New StreamWriter("Sauvegarde.txt")
        For Each j As Joueurs In MesJoueurs
            f.WriteLine(j.Nom)
            f.WriteLine(j.Score)
            f.WriteLine(j.NbPartiePremierJoueur)
            f.WriteLine(j.NbPartieDeuxiemeJoueur)
            Dim s As String = j.MeilleurTemps.Seconds
            f.WriteLine(s)
            s = j.TempsPasse.Seconds
            f.WriteLine(s)
        Next
        f.Close()
    End Sub

    Public Function GetJoueurParOrdreAlphabetique() As Joueurs()
        Dim JoueursTriés(Compteur - 1) As Joueurs
        For index As Integer = 0 To MesJoueurs.Length - 1
            JoueursTriés(index) = MesJoueurs(index)
        Next
        For index As Integer = MesJoueurs.Length - 1 To 1 Step -1
            For index2 As Integer = 0 To index - 1
                If (JoueursTriés(index2).Nom.CompareTo(JoueursTriés(index).Nom) < 0) Then
                Else
                    Dim variabletemporaire As Joueurs
                    variabletemporaire = JoueursTriés(index)
                    JoueursTriés(index) = JoueursTriés(index2)
                    JoueursTriés(index2) = variabletemporaire
                End If
            Next

        Next
        Return JoueursTriés
    End Function
    Public Function GetJoueurParScore() As Joueurs()
        Dim JoueursTriés(Compteur - 1) As Joueurs
        For index As Integer = 0 To MesJoueurs.Length - 1
            JoueursTriés(index) = MesJoueurs(index)
        Next
        For index As Integer = MesJoueurs.Length - 1 To 1 Step -1
            For index2 As Integer = 0 To index - 1
                If (JoueursTriés(index2).Score < JoueursTriés(index).Score) Then
                    Dim variabletemporaire As Joueurs
                    variabletemporaire = JoueursTriés(index)
                    JoueursTriés(index) = JoueursTriés(index2)
                    JoueursTriés(index2) = variabletemporaire
                End If
            Next

        Next

        Return JoueursTriés
    End Function
    Public Function GetJoueurParTemps() As Joueurs()
        Dim JoueursTriés(Compteur - 1) As Joueurs
        For index As Integer = 0 To MesJoueurs.Length - 1
            JoueursTriés(index) = MesJoueurs(index)
        Next
        For index As Integer = MesJoueurs.Length - 1 To 1 Step -1
            For index2 As Integer = 0 To index - 1
                If (JoueursTriés(index2).MeilleurTemps.Seconds > JoueursTriés(index).MeilleurTemps.Seconds) Then
                    Dim variabletemporaire As Joueurs
                    variabletemporaire = JoueursTriés(index)
                    JoueursTriés(index) = JoueursTriés(index2)
                    JoueursTriés(index2) = variabletemporaire
                End If
            Next
        Next

        Return JoueursTriés
    End Function

    Public Function getnbjoueur()
        Return Compteur
    End Function

End Module
