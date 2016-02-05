﻿Imports System.CodeDom
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.LINQ.Framework.DynamicCode
Imports Microsoft.VisualBasic.LINQ.Framework.DynamicCode.VBC

Namespace LDM.Expression

    Public Class WhereClosure : Inherits Closure

        Friend Expression As CodeExpression
        Friend TestMethod As MethodInfo

        Sub New(tokens As ClosureTokens(), parent As LINQStatement)
            Call MyBase.New(TokenIcer.TokenParser.Tokens.Where, tokens, parent)

            'Dim Parser As LINQ.Parser.Parser = New LINQ.Parser.Parser
            'Dim str = GetStatement(Statement._Original, New String() {"where", "let"}, False)
            'If String.IsNullOrEmpty(str) Then
            '    str = GetStatement(Statement._Original, New String() {"where", "select"}, False)
            'End If

            'Expression = Parser.ParseExpression(str)
        End Sub

        Public Sub Initialize()
            Me.TestMethod = DynamicInvoke.GetMethod(_statement.ILINQProgram, WhereConditionTestCompiler.FunctionName)
        End Sub
    End Class
End Namespace