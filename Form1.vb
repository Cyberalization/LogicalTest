'Programming Test - Jovan Jonathan
'function yang digunakan ada di paling bawah


Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory
Imports System.Globalization
Imports System.IO

Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub TableLayoutPanel16_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel16.Paint

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles inputAngka.TextChanged

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub Panel14_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel19_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel19.Paint

    End Sub

    Private Sub Panel24_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub nGanjilGenap_TextChanged(sender As Object, e As EventArgs) Handles nGanjilGenap.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
    'logic running from here........
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ganjil/genap
        outGanjil.Text = odeven(nGanjilGenap.Text)(1)
        outGenap.Text = odeven(nGanjilGenap.Text)(0)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'faktorial
        outFaktor.Text = faktor(nFaktor.Text)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'prime number 
        'nPrima.Text
        'outPrima.Text
        outPrima.Text = prima(CInt(nPrima.Text))

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'yg ribet: konversi angka ke text
        outputText.Text = convert(inputAngka.Text)

    End Sub
    'to here

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '======================================================================================
    'FUNction

    'odd-even generator
    '======================================================================================
    Function odeven(ByVal n As Integer)
        Dim result(1) As String
        If n > 50 Or n < 1 Then Return 0
        n *= 2
        Dim i As Integer = 1
        While i <= n - 2

            If i Mod 2 = 0 Then
                result(0) = result(0) + i.ToString + ", "
            Else
                result(1) = result(1) + i.ToString + ", "
            End If
            i += 1
        End While
        result(0) = result(0) + (i + 1).ToString
        result(1) = result(1) + (i).ToString
        Return result
    End Function

    'faktorial 
    '======================================================================================
    Function faktorial(ByVal n As Integer) As Long
        Dim f As Long = 1
        If n > 20 Or n < 1 Then
            Return 0
        ElseIf n = 1 Then
            f = 1
        Else
            For i = 1 To n
                f *= i
            Next
        End If
        Return f
    End Function
    Function faktor(ByVal n As Integer)
        Dim result As String = ""
        Dim i As Integer = 1
        If n > 20 Or n < 1 Then
            Return ""
        End If

        While i < n
            result = result + faktorial(i).ToString + ", "
            i += 1
        End While
        result = result + faktorial(n).ToString
        Return result
    End Function

    'prime number 
    '======================================================================================
    Function isPrime(ByVal n As Integer) As Boolean
        If n < 2 Then
            Return False
        End If

        For i As Integer = 2 To CInt(Math.Sqrt(n)) + 1
            If n Mod i = 0 Then
                Return False
            End If
        Next

        Return True
    End Function

    Function prima(ByVal n As Integer) As String
        Dim res As String = ""
        Dim count As Integer = 0
        Dim i As Integer = 2

        While count < n
            If isPrime(i) Or i < 4 Then
                res = res + i.ToString + ", "
                count = count + 1
            End If
            i = i + 1
        End While
        'Return res.TrimEnd(", ")
        Return res.Substring(0, res.Length - 2)
    End Function
    'number to text generator
    '======================================================================================
    'maaf, agak hardcoded

    Dim bigZero() As String = {"", "ribu", "juta", "miliar", "triliun"}
    Dim digits() As String = {"", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan"}
    Function convert(ByVal n As Long) As String
        'kalo 0 
        If n = 0 Then
            Return "Nol"
        End If
        Dim result As String = ""
        Dim idx As Integer = 0

        Do While n > 0
            Dim perTiga As Integer = CInt(n Mod 1000)

            If perTiga > 0 Then
                If perTiga = 1 AndAlso idx = 1 Then
                    result = "seribu " + result
                ElseIf result IsNot "" Then
                    result = ratusan(perTiga) + " " + bigZero(idx) + " " + result
                Else
                    result = ratusan(perTiga) + " " + bigZero(idx)
                End If
            End If
            Debug.Print(perTiga)
            n = n \ 1000
            idx = idx + 1
        Loop

        Return result.Trim()
    End Function
    Function ratusan(ByVal n As Integer) As String
        Dim result As String = ""

        If n >= 200 Then
            result = result + digits(n \ 100) + " ratus"
            n = n Mod 100
        ElseIf n < 200 AndAlso n >= 100 Then
            result = result + "seratus"
            n = n Mod 100
        End If
        If n >= 10 Then
            result = result + puluhan(n)
        ElseIf n > 0 Then
            result = result + " " + digits(n)
        End If
        Return result
    End Function

    Function puluhan(ByVal n As Integer) As String
        If n = 10 Then
            Return " sepuluh"
        ElseIf n = 11 Then
            Return " sebelas"
        ElseIf n < 20 Then
            Return " " + digits(n Mod 10) & " belas"
        Else
            Dim result = " " + digits(n \ 10) & " puluh"
            n = n Mod 10
            If n > 0 Then
                result = result + " " + digits(n)

            End If
            Return result
        End If

    End Function

End Class
