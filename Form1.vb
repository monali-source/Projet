Imports System.IO

Public Class Form1

    'Compteur text  a affiche   
    Dim CompteurSec As Integer = 0
    'numero de sous titres
    Dim Numero(5) As String
    'duree de sous titres
    Dim Duree(5) As String
    'texte line premier
    Dim Texte1(5) As String
    'texte line 2eme
    Dim Texte2(5) As String
    'convertion tableux donne a chaine de caracter
    Dim TableauToChaine As String
    ' calcul minutes en sec
    Dim CalculMinutes1 As Integer
    Dim CalculMinutes2 As Integer
    Dim CalculSecondes1 As Integer
    Dim CalculSecondes2 As Integer
    Dim TotalSecondes As Integer
    Dim CalculMinutesStop1 As Integer
    Dim CalculMinutesStop2 As Integer
    Dim CalculSecondesStop1 As Integer
    Dim CalculSecondesStop2 As Integer
    Dim TotalSecondesStop As Integer
    Dim SaveTotalSecondes As Integer = 0 ' egale 0 a camancee par 0 
    Dim SaveTotalSecondesStop As Integer = 0


    'compteur caracter de la chaine
    Dim k As Integer
    ' compteur pousition d position dans la chaine de caracter
    Dim d As Integer = 1







    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim myFileToRea1d As New System.IO.StreamReader("‪‪‪C:\Users\patel\Downloads\Projet1\sous-titres.txt", False)
        Dim myFileToRead1 As String
        myFileToRead1 = "C:\Users\patel\Downloads\Projet1\sous-titres.txt"
        Dim myFileToRead = My.Computer.FileSystem.OpenTextFileReader(myFileToRead1)


        'Saisir la quantité de soustitres dans le fichier
        For i = 1 To 5

            'Lire la premire ligne du texte
            Numero(i) = myFileToRead.ReadLine()
            'Lire deuxième ligne
            Duree(i) = myFileToRead.ReadLine()
            'Lire troisieme ligne
            Texte1(i) = myFileToRead.ReadLine()
            'Lire quatrieme ligne 
            Texte2(i) = myFileToRead.ReadLine()

        Next i

        'Fermer le fichier 
        myFileToRead.Close()
       
        'Convertir Tableau Duree en Chaine de caracteres
        TableauToChaine = String.Join(",", Duree.ToArray())




        

        

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' lance video click sur button demarre 
        AxWindowsMediaPlayer1.Ctlcontrols.play()
        'lance timer
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'arrete video
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        'arrete timer
        Timer1.Stop()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'comptage de la chaine de caracter
        If k < TableauToChaine.Length Then
            'si on trouve un , dans la chaine alors on calcul sec 
            If (TableauToChaine(k) = ",") Then

                ''START DES SOUS-TITRES
                '    'Calcul Minutes en secondes
                CalculMinutes1 = (Val(TableauToChaine(d))) * 10 * 60
                CalculMinutes2 = CalculMinutes1 + (Val(TableauToChaine(d + 1)) * 60)
                '    'Calcul secondes
                CalculSecondes1 = (Val(TableauToChaine(d + 3))) * 10
                CalculSecondes2 = CalculSecondes1 + (Val(TableauToChaine(d + 4)))
                '    'Total Secondes
                TotalSecondes = CalculMinutes2 + CalculSecondes2

                ''STOP DES SOUS-TITRES
                '    'Calcul Minutes en secondes
                CalculMinutesStop1 = (Val(TableauToChaine(d + 10))) * 10 * 60
                CalculMinutesStop2 = CalculMinutesStop1 + (Val(TableauToChaine(d + 11)) * 60)
                '    'Calcul secondes
                CalculSecondesStop1 = (Val(TableauToChaine(d + 13))) * 10
                CalculSecondesStop2 = CalculSecondesStop1 + (Val(TableauToChaine(d + 14)))
                '    'Total Secondes
                TotalSecondesStop = CalculMinutesStop2 + CalculSecondesStop2

                Label1.Text = "Start Sout-titres  " & TotalSecondes & "   Stop Sous-Titres  " & TotalSecondesStop

                CompteurSec += 1
            End If

            d = d + 1
            k = k + 1

            Label2.Text = "compteur  " & k


            'Afficher les sous-titres

            If k >= TotalSecondes Then
                Label3.Visible = True
                Label4.Visible = True
                Label3.Text = Texte1(CompteurSec)

                Label4.Text = Texte2(CompteurSec)

            End If

            If k >= TotalSecondesStop Then
                Label3.Visible = False
                Label4.Visible = False
            End If
        End If

    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
End Class
