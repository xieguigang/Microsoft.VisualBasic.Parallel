﻿Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService.SharedORM
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text
Imports sciBASIC.ComputingServices
Imports sciBASIC.ComputingServices.TaskHost

<CLI> Module CLI

    ''' <summary>
    ''' Run current program as grid node service process.
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    Public Function RunServices(args As CommandLine) As Integer

    End Function

    ''' <summary>
    ''' 在并行计算中,多进程的计算效率要高于多线程的应用程序
    ''' 可以将任务分解,然后通过调用这个函数创建多进程的并行计算任务
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Use for create parallel in multiple-process mode
    ''' </remarks>
    <ExportAPI("/slave")>
    <Description("Program running in slave mode, apply for the multiple-process parallel.")>
    <Usage("/slave /application <invokeinfo/json_base64> /out <memory_mapfile>")>
    Public Function Slave(args As CommandLine) As Integer
        Dim endpointJSON$ = args("/application").Base64Decode
        Dim invokeInfo As InvokeInfo = endpointJSON.LoadJSON(Of InvokeInfo)
        Dim result As Rtvl = RemoteCall.Invoke(invokeInfo)
        Dim resultJSON = result.GetJson
        Dim jsonBytes As Byte() = Encodings.UTF8WithoutBOM.CodePage.GetBytes(resultJSON)

        Using output As StreamWriter = args.OpenStreamOutput("/out", size:=jsonBytes.Length)
            Call output.BaseStream.Write(jsonBytes, Scan0, jsonBytes.Length)
        End Using

        Return 0
    End Function
End Module
