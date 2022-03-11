Module Utils
    'Public Function bytes_to_int(ba As Byte(), a As Integer) As Integer
    '    Dim ia = (From i In Enumerable.Range(0, 4) Select ba(a + i)).ToList()
    '    Return ia(0) Or ia(1) << 8 Or ia(2) << 16 Or ia(3) << 24
    'End Function
    Public Function bytes_to_int(ByVal ba As Byte(), ByVal a As Integer) As Integer
        Dim to_int As Integer = BitConverter.ToInt32(ba, a)
        Return to_int
    End Function

    Public Function zero_fill_right_shift(ByVal val As Integer, ByVal n As Integer) As Integer
        Return val Mod &H100000000 >> n
    End Function

    Public Function string_to_code_value(ByVal val As Object) As Object
        Return val.lower().replace(" ", "_")
    End Function

    Public Function get_base_byte_value(ByVal b As Object, ByVal bf As Object) As Object
        Return b / bf * bf
    End Function

    Public Function get_lowest_byte_value(ByVal b As Object, ByVal bf As Object) As Object
        Dim bb = get_base_byte_value(b, bf)
        Dim lb = b - bb
        Return lb
    End Function

    Public Function round_down(ByVal n As Object, ByVal d As Object) As Object
        Return n - n Mod d
    End Function
    Public Function get_array(ByVal array() As Byte, ByVal index As Integer, ByVal length As Integer) As Byte()
        Dim array2(length - 1) As Byte
        System.Array.Copy(array, index, array2, 0, length)
        ' remove 00
        Dim result = (From str In array2
                                  Where Not {0}.Contains(str)).ToArray()
        Return result
    End Function
    Public Function GetDataBlock(ByRef Data As Byte(), ByVal start As Integer, Optional ByVal len As Integer = 0) As Byte()
        ' Extract a datablock from another datablock
        ' if len is not specified it will copy the entire block from the starting point to the end
        Dim BlockLen As Integer = Data.Length - start           ' Calculate the length of the data block

        ' Check if len was specified
        If len = 0 Then
            ' if not grab everything from start to end
            BlockLen = Data.Length - start
        Else
            ' Grab just the data asked for
            BlockLen = len
        End If

        Dim tmpBlock(BlockLen) As Byte   ' Create the target array
        Array.ConstrainedCopy(Data, start, tmpBlock, 0, BlockLen)   ' Copy the data
        Return tmpBlock  ' return the block

    End Function
End Module