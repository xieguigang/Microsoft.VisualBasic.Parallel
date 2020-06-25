﻿#Region "Microsoft.VisualBasic::d98aebb318b2c52197468981c846b74e, LINQ\LINQ\APP\CLI.vb"

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

    ' Module CLI
    ' 
    '     Function: InstallPlugins
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports sciBASIC.ComputingServices.Linq.Framework.Provider
Imports sciBASIC.ComputingServices.Linq.Framework.Provider.ImportsAPI

''' <summary>
''' 框架程序自带的注册模块以及一些配置的管理终端
''' </summary>
Module CLI

    ''' <summary>
    ''' 扫描应用程序文件夹之中可能的插件信息
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/install", Usage:="/install")>
    Public Function InstallPlugins(args As CommandLine) As Integer
        Using registry As TypeRegistry = TypeRegistry.LoadDefault
            Call registry.InstallCurrent()
        End Using
        Using api As APIProvider = APIProvider.LoadDefault
            Call api.Install()
        End Using

        Return 0
    End Function
End Module