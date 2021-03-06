﻿#Region "Microsoft.VisualBasic::dfc2fc1bbd4499355ac023abb6cc48a0, LINQ\LINQ\Interpreter\Query\Query.vb"

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

    '     Class QueryExpression
    ' 
    '         Properties: IsURISource
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: GetDataSet, GetSeqValue
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports LINQ.Interpreter.Expressions
Imports LINQ.Runtime

Namespace Interpreter.Query

    Public MustInherit Class QueryExpression : Inherits Expression

        ReadOnly sequence As Expression

        Friend ReadOnly symbol As SymbolDeclare
        Friend ReadOnly executeQueue As Expression()

        Public ReadOnly Property IsURISource As Boolean
            Get
                Return TypeOf sequence Is Literals AndAlso DirectCast(sequence, Literals).type = GetType(String)
            End Get
        End Property

        Sub New(symbol As SymbolDeclare, sequence As Expression, execQueue As IEnumerable(Of Expression))
            Me.symbol = symbol
            Me.sequence = sequence
            Me.executeQueue = execQueue.ToArray
        End Sub

        Public Function GetSeqValue(context As ExecutableContext) As Object
            Return sequence.Exec(context)
        End Function

        Protected Function GetDataSet(context As ExecutableContext) As DataSet
            Return DataSet.CreateDataSet(Me, context)
        End Function
    End Class
End Namespace
