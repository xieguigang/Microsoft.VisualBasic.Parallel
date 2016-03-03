﻿Imports Microsoft.VisualBasic.Linq.Framework.Provider
Imports Microsoft.VisualBasic.Linq.Framework.Provider.ImportsAPI
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Linq.Framework.DynamicCode
Imports Microsoft.VisualBasic.Linq.LDM.Statements.Tokens
Imports Microsoft.VisualBasic.Parallel

Module Module1

    Sub Main()

        Dim cp = Microsoft.VisualBasic.Linq.Framework.DynamicCode.DynamicCompiler.DefaultCompiler
        Dim test2222 = LDM.Statements.Tokens.WhereClosure.CreateLinqWhere("$x mod 6=0", GetType(Integer), cp)

        test2222(6).__DEBUG_ECHO
        test2222(12).__DEBUG_ECHO
        test2222(13).__DEBUG_ECHO


        'Dim RQLQuery = (From x As Integer
        '                In New RQL.API.Repository(Of Integer)("http://127.0.0.1/int32").Where("$x mod 6 = 1").AsLinq(Of Integer)
        '                Where x > 100 Select x)

        'Dim query2 = (From x As Integer
        '              In New RQL.API.Repository(Of Integer)("http://127.0.0.1/int32").Where(Function(xx) xx Mod 6 = 1).AsLinq(Of Integer)
        '              Where x > 100
        '              Select x)

        ''   Dim query3 = (From x As Integer
        ''                In New RQL.API.Repository(Of Integer)("http://127.0.0.1/int32?where=$ mod6 =1")
        '' Where x > 100
        ''Select Case x)
        'Dim id, number
        'Dim SQL As String = $"update table set id={id} where uid={number}"
        Call RunTask(Sub()
                         MsgBox("click to start!")

                         Dim qlll = (From x As Integer In New RQL.API.Repository(Of Integer)("http://127.0.0.1/test123.vb").Where("$x mod 6 =1").AsLinq(Of Integer) Select x.__DEBUG_ECHO).ToArray


                         MsgBox("test2")


                         Dim lquerrrr = (From i As Integer In 1000000.SeqIterator.AsParallel Select "http://127.0.0.1/test123.vb".GetRequest).ToArray
                         MsgBox("DONE!")
                         For i As Integer = 0 To 100000
                             Call Trace.WriteLine("http://127.0.0.1/test123.vb".GET)
                         Next
                     End Sub)

        Dim svr As New RQL.RESTProvider
        Call svr.AddLinq("/test123.vb", "E:\Microsoft.VisualBasic.Parallel\trunk\LINQ\ints.txt", AddressOf Microsoft.VisualBasic.Linq.Framework.Provider.GetInt32)
        Call svr.Run()

        Dim stststs = LDM.Statements.LinqStatement.TryParse( _
 _
            "From x As Integer In ""E:\Microsoft.VisualBasic.Parallel\trunk\LINQ\ints.txt"" Let add = x + 50 Where add > 0 Let cc = add ^ 2 let abc as double = cc mod 99 +11.025R Select abc, cc, x, add, nn = cc+ x/ add * 22 mod 5, gg = math.max(cc,add)")

        Dim runt As New Script.DynamicsRuntime
        Dim result = (From x In runt.EXEC(stststs) Select x).ToArray

        Dim source = {1, 2, 3, 4, 5, 6, 7}

        Dim LQuery = (From x As Integer In source Let add = x + 50 Where add > 0 Let cc = add ^ 2 Select cc, x, add, nn = Sum(New Double() {cc, x, add * 22}))


        Dim code As String = LinqClosure.BuildClosure("x", GetType(Integer), {"add = x + 50 "}, {"cc = add ^ 2"}, {"cc", "x", "add", "nn = cc+ x+ Add * 22"}, "add > 0")

        Call Console.WriteLine(code)

        Dim compiler As New Framework.DynamicCode.DynamicCompiler

        Dim ttttttttttt = compiler.Compile(code)

        Dim aa = ttttttttttt(1000000000)



        Dim itt As New Iterator(source)

        Do While itt.MoveNext
            Call __DEBUG_ECHO(Scripting.ToString(itt.Current) & " --> " & itt.ReadDone)
        Loop
        Call Scripting.ToString(itt.Current).__DEBUG_ECHO

        Dim s As String = "instr($s, cstr( $s->length), 8)"
        Dim typew = GetType(String)
        '     Dim www = WhereClosure.CreateLinqWhere(s, typew)
        Dim types As TypeRegistry = TypeRegistry.LoadDefault
        Dim api As APIProvider = APIProvider.LoadDefault


        Dim p As New Parser.Parser
        Dim n = p.ParseExpression("$($(test2 pp $rt) -> test_func par1 $ffjhg par2 $dee) -> test3 p3 $($(test5 de) -> test4 ppp $gr)")
    End Sub
End Module
