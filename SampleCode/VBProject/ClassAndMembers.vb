Module ClassAndMembers
    Public Class ConvertPostCode

        Public Property PostCode As Integer

        Public Function DoConvert(ByVal postcode As String) As String

            Dim ConvertPostcode As String
            ConvertPostcode = StrConv(postcode, VbStrConv.Uppercase)
            DoConvert = ConvertPostcode

        End Function

    End Class
End Module
