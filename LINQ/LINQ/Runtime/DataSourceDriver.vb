﻿#Region "Microsoft.VisualBasic::71e5a9b4983209cac8a90ccff01ca093, LINQ\LINQ\Runtime\DataSourceDriver.vb"

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

    '     Class DataSourceDriver
    ' 
    ' 
    ' 
    '     Class DataFrameDriver
    ' 
    '         Function: ReadFromUri
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.My.JavaScript

Namespace Runtime

    Public MustInherit Class DataSourceDriver

        Public MustOverride Function ReadFromUri(uri As String) As IEnumerable(Of Object)

    End Class

    Public Class DataFrameDriver : Inherits DataSourceDriver

        Public Overrides Iterator Function ReadFromUri(uri As String) As IEnumerable(Of Object)
            Dim dataframe As DataFrame = DataFrame.Load(uri).MeasureTypeSchema
            Dim obj As JavaScriptObject
            Dim headers As String() = dataframe.HeadTitles

            For Each row As Object() In dataframe.EnumerateRowObjects
                obj = New JavaScriptObject

                For i As Integer = 0 To headers.Length - 1
                    obj(headers(i)) = row(i)
                Next

                Yield obj
            Next
        End Function
    End Class
End Namespace
