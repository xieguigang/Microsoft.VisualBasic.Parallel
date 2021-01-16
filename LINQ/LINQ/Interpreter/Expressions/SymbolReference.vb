﻿Imports LINQ.Runtime

Namespace Interpreter.Expressions

    Public Class SymbolReference : Inherits Expression

        Friend ReadOnly symbolName As String

        Sub New(name As String)
            Me.symbolName = name
        End Sub

        Public Overrides Function Exec(context As ExecutableContext) As Object
            Dim symbol As Symbol = context.env.FindSymbol(symbolName)

            If symbol Is Nothing Then
                If context.throwError Then
                    Throw New MissingPrimaryKeyException(symbolName)
                Else
                    Return Nothing
                End If
            Else
                Return symbol.value
            End If
        End Function

        Public Overrides Function ToString() As String
            Return $"&{symbolName}"
        End Function
    End Class
End Namespace