Imports System.Text

Module club
    Public total As Integer = 138
    Public start_address As Integer = 797421
    Public size As Integer = 140
    Public max_name_size As Integer = 23
    Dim name_address
    'Dim idx
    Public Function name_read(ByVal idx As Integer) As String
        'idx = 1
        set_addresses(idx)
        Return set_name()
    End Function


    Public Function set_addresses(ByVal idx As Integer) As Integer
        'Set the following club addresses:
        '- Name
        name_address = start_address + (+(idx * size))
        Return start_address + (+(idx * size))
    End Function
    Public Function set_name() As String
        'Set club name from relevant OF data bytes.
        Dim name_byte_array() As Byte = get_array(of_file, name_address, max_name_size)
        Return Encoding.UTF8.GetString(name_byte_array)
    End Function

    Public Sub update_name(ByVal name As String)
        'Update club name with the supplied value.

        'set 00 en bytes
        For i = 0 To 23
            of_file(name_address + i) = 0
        Next
        Dim new_name_bytes() As Byte = Encoding.ASCII.GetBytes(name)
        Array.Copy(new_name_bytes, 0, of_file, name_address, new_name_bytes.Length)

    End Sub


End Module
