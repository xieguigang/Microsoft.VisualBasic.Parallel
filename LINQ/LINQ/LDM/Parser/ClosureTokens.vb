﻿#Region "Microsoft.VisualBasic::2cfe76c757f18f55b4a1b7e7202ef8cc, LINQ\LINQ\LDM\Parser\ClosureTokens.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    '     Class ClosureTokens
    ' 
    '         Properties: Token, Tokens
    ' 
    '         Function: ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Scripting.TokenIcer
Imports Microsoft.VisualBasic.Linq

Namespace LDM.Statements

    Public Class ClosureTokens

        Public Property Token As TokenIcer.Tokens
        Public Property Tokens As Token(Of TokenIcer.Tokens)()

        Public Overrides Function ToString() As String
            Return $"[{Token}] {Tokens.Select(Function(x) x.Value).JoinBy(" ")}"
        End Function

        '''' <summary>
        '''' 表达式栈空间的解析
        '''' </summary>
        '''' <returns></returns>
        'Public Function ParsingStack() As Func(Of TokenIcer.Tokens)
        '    Return Tokens.Parsing(TokenIcer.stackT)
        'End Function
    End Class
End Namespace
