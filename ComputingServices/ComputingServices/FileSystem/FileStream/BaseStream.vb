﻿Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.ComputingServices.FileSystem.Protocols
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.Net
Imports Microsoft.VisualBasic.Net.Protocol

Namespace FileSystem.IO

    ''' <summary>
    ''' <see cref="System.IO.FileStream"/><see cref="System.IO.StreamWriter"/>
    ''' </summary>
    Public MustInherit Class BaseStream
        Implements IDisposable

        Public ReadOnly Property FileSystem As FileSystem
        Public Property FileName As String
            Get
                Return _file
            End Get
            Protected Set(value As String)
                _file = value
            End Set
        End Property

        Dim _file As String

        Sub New(remote As FileSystem)
            FileSystem = remote
        End Sub

        Sub New(remote As IPEndPoint)
            Call Me.New(New FileSystem(remote))
        End Sub

        Sub New(remote As String, port As Integer)
            Call Me.New(New IPEndPoint(remote, port))
        End Sub

        Sub New(remote As System.Net.IPEndPoint)
            Call Me.New(New IPEndPoint(remote))
        End Sub

        Public Overrides Function ToString() As String
            Return FileSystem.ToString
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace