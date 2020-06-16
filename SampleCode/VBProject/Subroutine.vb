Module Subroutine
    Private Sub DisplayAdd(x As Integer, y As Integer)
        MsgBox(x + y)
    End Sub

    Private Sub Form_Load()
        DisplayAdd(5, 2)
    End Sub
End Module
