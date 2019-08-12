﻿Imports System.IO
Imports System.IO.Compression
Imports Microsoft.VisualBasic.ApplicationServices.Zip
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.NonlinearGridTopology

''' <summary>
''' 使用zip压缩的形式，将population保存为临时文件
''' </summary>
Public Class PopulationZip

    ReadOnly target$
    ReadOnly index As VBInteger = Scan0

    ''' <summary>
    ''' The target zip file
    ''' </summary>
    ''' <param name="target$"></param>
    Sub New(target$)
        Me.target = target
    End Sub

    Public Sub Add(genome As GridSystem)
        Dim temp = App.GetAppSysTempFile($".grid/{++index}", App.PID, "population_")

        Using file As FileStream = temp.Open
            Call genome.Serialize(file, chunkSize:=2048)
        End Using

        Call ZipLib.AddToArchive(
            files:={temp},
            archiveFullName:=target,
            action:=ArchiveAction.Merge,
            fileOverwrite:=Overwrite.Always,
            compression:=CompressionLevel.Fastest
        )

        Call temp.DeleteFile
    End Sub

    Public Function GetIndividual(i As Integer) As GridSystem
        Dim buffer As MemoryStream = ZipStreamReader.LoadZipArchive(target, {CStr(i)}).FirstOrDefault

        If buffer Is Nothing Then
            Throw New MissingMemberException(i)
        Else
            Using buffer
                Return buffer.LoadGridSystem
            End Using
        End If
    End Function
End Class
