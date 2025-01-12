Imports System.IO

Module option_file

    Public of_file() As Byte
    Public Function read_option_file(ByVal file_location As String) As Byte()
        of_file = File.ReadAllBytes(file_location)
        convert_data()
        Return of_file
    End Function

    Public Sub save_option_file(ByVal file_location As String, Optional ByVal Decrypt_file As String = Nothing)
        If Decrypt_file = Nothing Then
        Else : of_file = File.ReadAllBytes(Decrypt_file)
        End If

        checksums()
        convert_data()
        IO.File.WriteAllBytes(file_location, of_file)
    End Sub
    Public Sub convert_data()
        Dim key = 0
        For Each i In Enumerable.Range(0, of_file.Length)
            of_file(i) = of_file(i) Xor OF_KEY_PC(key)

            If key < 255 Then
                key += 1
            Else
                key = 0
            End If
        Next
    End Sub
    Public Sub checksums()
        For i = 0 To 9
            Dim checksum = 0
            For a = OF_BLOCK(i) To OF_BLOCK(i) + OF_BLOCK_SIZE(i) - 1
                checksum += of_file(a)
            Next
            checksum = checksum And &HFF
            'file(OF_BLOCK(i) - 4) = checksum
        Next
    End Sub
    Public Sub sum8(ByVal start As Integer, ByVal length As Integer)
        Dim checksum = 0
        For a = start To length - 1
            checksum += of_file(a)
        Next
        checksum = checksum And &HFF
        of_file(start - 5) = checksum

    End Sub
    Public clubs(club.total - 1) As String
    Public Sub set_clubs()
        For i = 0 To club.total - 1
            clubs(i) = name_read(i)
        Next

    End Sub

End Module
