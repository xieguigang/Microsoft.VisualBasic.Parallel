﻿Imports Microsoft.VisualBasic.LINQ.Framework

Namespace LDM.Expression

    ''' <summary>
    ''' 表示目标对象的数据集合的文件路径或者内存对象的引用
    ''' </summary>
    ''' <remarks></remarks>
    Public Class InClosure : Inherits Closure

        Public Enum CollectionTypes
            ''' <summary>
            ''' 目标集合类型为一个数据文件
            ''' </summary>
            ''' <remarks></remarks>
            File
            ''' <summary>
            ''' 目标集合类型为一个内存对象的引用
            ''' </summary>
            ''' <remarks></remarks>
            Reference
        End Enum

        Dim CollectionType As InClosure.CollectionTypes = CollectionTypes.File
        ''' <summary>
        ''' ILINQCollection对象的实例
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ILINQCollection As Framework.ILINQCollection

        Public ReadOnly Property Type As InClosure.CollectionTypes
            Get
                Return CollectionType
            End Get
        End Property

        Public ReadOnly Property IsParallel As Boolean
            Get
                Return False
            End Get
        End Property

        ''' <summary>
        ''' The file io object url or a object collection reference in the LINQ Frameowrk runtime. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Value As String
            Get
                '       Return _original
            End Get
        End Property

        Sub New(tokens As ClosureTokens(), parent As LINQStatement)
            Call MyBase.New(TokenIcer.TokenParser.Tokens.In, tokens, parent)
        End Sub

        Public Overrides Function ToString() As String
            'If Type = CollectionTypes.File Then
            '    Return String.Format("(File) {0}", Me._original)
            'Else
            '    Return Type.ToString
            'End If
        End Function

        ''' <summary>
        ''' 加载外部模块之中的ILINQCollection类型信息
        ''' </summary>
        ''' <param name="RegistryItem"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function LoadExternalModule(RegistryItem As RegistryItem) As Type
            Dim assm As System.Reflection.Assembly =
                System.Reflection.Assembly.LoadFrom(RegistryItem.AssemblyFullPath)
            Return assm.GetType(RegistryItem.TypeId)
        End Function
    End Class
End Namespace