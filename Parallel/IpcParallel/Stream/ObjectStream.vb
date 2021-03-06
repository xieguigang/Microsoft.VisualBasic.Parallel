﻿#Region "Microsoft.VisualBasic::afd368cb2ea7bf946dcdfa3ed58b0c24, Parallel\IpcParallel\Stream\ObjectStream.vb"

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

    '     Class ObjectStream
    ' 
    '         Properties: isPrimitive, method, stream, type
    ' 
    '         Constructor: (+2 Overloads) Sub New
    ' 
    '         Function: GetUnderlyingType, openMemoryBuffer, Serialize
    ' 
    '         Sub: (+2 Overloads) Dispose
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Parallel
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace IpcStream

    Public Class ObjectStream : Inherits RawStream
        Implements IDisposable

        Dim disposedValue As Boolean

        Public Property method As StreamMethods
        Public Property stream As Byte()
        Public Property type As TypeInfo

        Public ReadOnly Property isPrimitive As Boolean
            Get
                Return DataFramework.IsPrimitive(GetUnderlyingType)
            End Get
        End Property

        Sub New(type As TypeInfo, method As StreamMethods, stream As Stream)
            Me.method = method
            Me.stream = New StreamPipe(stream).Read
            Me.type = type

            Call stream.Close()
            Call stream.Dispose()
        End Sub

        Sub New(raw As Byte())
            Using read As New BinaryReader(New MemoryStream(raw))
                Dim methodi As Integer = read.ReadInt32
                Dim size As Integer = read.ReadInt32
                Dim chunk As Byte() = read.ReadBytes(size)
                Dim typeJson As String = chunk.UTF8String

                size = read.ReadInt32
                type = typeJson.LoadJSON(Of TypeInfo)
                method = CType(methodi, StreamMethods)
                stream = read.ReadBytes(size)
            End Using
        End Sub

        Public Function GetUnderlyingType() As Type
            Return type.GetType(knownFirst:=True)
        End Function

        Public Function openMemoryBuffer() As MemoryStream
            Return New MemoryStream(stream)
        End Function

        Public Overrides Function Serialize() As Byte()
            Using ms As New MemoryStream
                Dim json As Byte() = Encoding.UTF8.GetBytes(type.GetJson)

                Call ms.Write(BitConverter.GetBytes(method), Scan0, RawStream.INT32)
                Call ms.Write(BitConverter.GetBytes(json.Length), Scan0, RawStream.INT32)
                Call ms.Write(json, Scan0, json.Length)
                Call ms.Write(BitConverter.GetBytes(stream.Length), Scan0, RawStream.INT32)
                Call ms.Write(stream, Scan0, stream.Length)

                Return ms.ToArray
            End Using
        End Function

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: 释放托管状态(托管对象)
                    Erase stream
                End If

                ' TODO: 释放未托管的资源(未托管的对象)并替代终结器
                ' TODO: 将大型字段设置为 null
                disposedValue = True
            End If
        End Sub

        ' ' TODO: 仅当“Dispose(disposing As Boolean)”拥有用于释放未托管资源的代码时才替代终结器
        ' Protected Overrides Sub Finalize()
        '     ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
        '     Dispose(disposing:=False)
        '     MyBase.Finalize()
        ' End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class
End Namespace
