﻿Imports System.CodeDom
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.LINQ.Framework.DynamicCode
Imports Microsoft.VisualBasic.LINQ.Framework.DynamicCode.VBC
Imports Microsoft.VisualBasic.LINQ.Statements.TokenIcer.Parser
Imports Microsoft.VisualBasic.Scripting.TokenIcer

Namespace Statements.Tokens

    Public Class WhereClosure : Inherits Closure

        Public ReadOnly Property Expression As Func(Of TokenIcer.Tokens)

        Sub New(tokens As ClosureTokens(), parent As LINQStatement)
            Call MyBase.New(TokenIcer.Tokens.Where, tokens, parent)
            Expression = Source.Tokens.Parsing(stackT)
        End Sub

        Sub New(source As Func(Of TokenIcer.Tokens))
            Call MyBase.New(TokenIcer.Tokens.Where, source.ToArray(stackT))
        End Sub

        Sub New(source As Token(Of TokenIcer.Tokens)())
            Call MyBase.New(TokenIcer.Tokens.Where, source)
        End Sub

        Public Sub Initialize()
            '   Me.TestMethod = DynamicInvoke.GetMethod(_statement.ILINQProgram, WhereConditionTestCompiler.FunctionName)
        End Sub
    End Class
End Namespace