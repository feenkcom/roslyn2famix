Module MethodCalls

    Function Callee() As Integer
        Return 1
    End Function

    Function Caller() As Integer
        Return Callee()
    End Function

End Module
