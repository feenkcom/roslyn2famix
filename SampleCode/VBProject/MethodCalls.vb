Module MethodCalls

    Function Callee() As Integer
        Return 1
    End Function

    Function Caller() As Integer
        Return Callee()
        Subroutine.DisplayAdd(1, 2)
    End Function

End Module
