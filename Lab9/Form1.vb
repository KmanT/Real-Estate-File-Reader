'Kyle Turske
'Lab 9

Imports System.IO
Public Class Form1
    Const FILE_PATH As String = "RealEstateData.txt"
    Public Shared Function ReadRealEstate() As List(Of RealEstate)
        'If Not Directory.Exists(FILE_PATH) Then
        '    Directory.CreateDirectory(FILE_PATH)
        'End If

        Dim textIn As New StreamReader(New FileStream(FILE_PATH, FileMode.Open, FileAccess.Read))
        Dim lstReaLEstate As New List(Of RealEstate)

        Do While textIn.Peek <> -1
            Dim row As String = textIn.ReadLine
            Dim columns() As String = row.Split(CChar("|"))
            Dim estate As New RealEstate
            estate.YearPurchased = CInt(columns(0))
            estate.PurchasePrice = CDec(columns(1))
            estate.Type = columns(2)
            estate.Value2014 = CDec(columns(3))
            lstReaLEstate.Add(estate)
        Loop
        textIn.Close()
        Return lstReaLEstate
    End Function

    Public Function Value2016(estate As RealEstate) As Decimal
        Dim value As Decimal
        value = estate.Value2014
        If estate.Type = "Comm" Then
            value += value * 0.045D
        ElseIf estate.Type = "Ind" Then
            value += value * 0.031D
        ElseIf estate.Type = "Home" Then
            value += value * 0.056D
        ElseIf estate.Type = "Farm" Then
            value += value * 0.014D
        End If
        Return value
    End Function

    Public Function PrintEstate(estate As RealEstate) As String
        Dim strOut As String
        Dim val As Decimal
        val = Value2016(estate)
        strOut = estate.YearPurchased.ToString
        strOut &= estate.PurchasePrice.ToString.PadLeft(15)
        strOut &= estate.Type.PadLeft(10)
        strOut &= estate.Value2014.ToString.PadLeft(20)
        strOut &= val.ToString.PadLeft(20)
        Return strOut
    End Function

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim estateList As New List(Of RealEstate)
        Dim total2014 As Decimal
        Dim total2016 As Decimal
        lstOut.Items.Add("Adams, Brindel and Katt Real Estate")
        lstOut.Items.Add("Year" & "Purchase".PadLeft(15) & "Type".PadLeft(10) & "2014".PadLeft(20) & "2016".PadLeft(20))

        estateList = ReadRealEstate()

        For Each estate As RealEstate In estateList
            lstOut.Items.Add(PrintEstate(estate))
            total2014 += estate.Value2014
            total2016 += Value2016(estate)
        Next

        lstOut.Items.Add(total2014.ToString.PadLeft(50) & total2016.ToString.PadLeft(20))

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
