Module LesRègles

    Private NouvelleCouleurAbsent As Boolean = False
    Private PasDeTemps As Boolean = False


    Private NbEssais As Integer
    Private Symboles As String()
    Private Temps As TimeSpan
    Private CouleurAbsent As Color
    Private CouleurPresent As Color
    Private CouleurBienPlace As Color
    Public Sub Initialise()
        NbEssais = 15
        Temps = New TimeSpan(0, 1, 30)
        CouleurBienPlace = Color.Green
        CouleurPresent = Color.Blue
        NouvelleCouleurAbsent = False
        ReDim Symboles(4)
        Symboles(0) = "@"
        Symboles(1) = "$"
        Symboles(2) = "£"
        Symboles(3) = "%"
        Symboles(4) = "#"
    End Sub

    Public Function GetPasDeTemps()
        Return PasDeTemps
    End Function

    Public Sub SetPasDeTemps(b As Boolean)
        PasDeTemps = b
    End Sub
    Public Sub SetNouvelleCouleurAbsent(b As Boolean)
        NouvelleCouleurAbsent = b
    End Sub

    Public Function GetNouvelleCouleurAbsent()
        Return NouvelleCouleurAbsent
    End Function
    Public Sub SetTemps(t As TimeSpan)
        Temps = t
    End Sub
    Public Sub SetCouleurAbsent(couleur As Color)
        CouleurAbsent = couleur
    End Sub
    Public Sub SetCouleurPresent(couleur As Color)
        CouleurPresent = couleur
    End Sub
    Public Sub SetCouleurBienPlace(couleur As Color)
        CouleurBienPlace = couleur
    End Sub
    Public Sub SetNbEssais(nb As Integer)
        NbEssais = nb
    End Sub

    Public Sub SetSymboles(Symboles2 As String())
        Symboles = Symboles2
    End Sub

    Public Function GetSymboles() As String()
        Return Symboles
    End Function

    Public Function GetTemps() As TimeSpan
        Return Temps
    End Function

    Public Function GetCouleurPresent() As Color
        Return CouleurPresent
    End Function
    Public Function GetCouleurAbsent() As Color
        Return CouleurAbsent
    End Function
    Public Function GetCouleurBienPlace() As Color
        Return CouleurBienPlace
    End Function

    Public Function GetNbEssais() As Integer
        Return NbEssais
    End Function

End Module
