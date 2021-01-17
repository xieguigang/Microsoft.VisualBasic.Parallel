﻿' Generated by the protocol buffer compiler.  DO NOT EDIT!
' source: google/protobuf/type.proto
#Region "Designer generated code"

Imports Microsoft.VisualBasic.Language
Imports pbc = Google.Protobuf.Collections
Imports pbr = Google.Protobuf.Reflection

Namespace Google.Protobuf.WellKnownTypes


#Region "Messages"
    ''' <summary>
    '''  A protocol buffer message type.
    ''' </summary>
    Public NotInheritable Partial Class Type
        Implements IMessageType(Of Type)

        Private Shared ReadOnly _parser As MessageParserType(Of Type) = New MessageParserType(Of Type)(Function() New Type())

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Shared ReadOnly Property Parser As MessageParserType(Of Type)
            Get
                Return _parser
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Shared ReadOnly Property DescriptorProp As pbr.MessageDescriptor
            Get
                Return Global.Google.Protobuf.WellKnownTypes.TypeReflection.Descriptor.MessageTypes(0)
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Private ReadOnly Property Descriptor As pbr.MessageDescriptor Implements IMessage.Descriptor
            Get
                Return DescriptorProp
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub New()
            OnConstruction()
        End Sub

        Partial Private Sub OnConstruction()
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub New(other As Type)
            Me.New()
            name_ = other.name_
            fields_ = other.fields_.Clone()
            oneofs_ = other.oneofs_.Clone()
            options_ = other.options_.Clone()
            SourceContext = If(other.sourceContext_ IsNot Nothing, other.SourceContext.Clone(), Nothing)
            syntax_ = other.syntax_
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Function Clone() As Type Implements IDeepCloneable(Of Type).Clone
            Return New Type(Me)
        End Function

        ''' <summary>Field number for the "name" field.</summary>
        Public Const NameFieldNumber As Integer = 1
        Private name_ As String = ""
        ''' <summary>
        '''  The fully qualified message name.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Property Name As String
            Get
                Return name_
            End Get
            Set(value As String)
                name_ = CheckNotNull(value, "value")
            End Set
        End Property

        ''' <summary>Field number for the "fields" field.</summary>
        Public Const FieldsFieldNumber As Integer = 2
        Private Shared ReadOnly _repeated_fields_codec As FieldCodecType(Of Global.Google.Protobuf.WellKnownTypes.Field) = FieldCodec.ForMessage(18, Global.Google.Protobuf.WellKnownTypes.Field.Parser)
        Private ReadOnly fields_ As pbc.RepeatedField(Of Global.Google.Protobuf.WellKnownTypes.Field) = New pbc.RepeatedField(Of Global.Google.Protobuf.WellKnownTypes.Field)()
        ''' <summary>
        '''  The list of fields.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public ReadOnly Property Fields As pbc.RepeatedField(Of Global.Google.Protobuf.WellKnownTypes.Field)
            Get
                Return fields_
            End Get
        End Property

        ''' <summary>Field number for the "oneofs" field.</summary>
        Public Const OneofsFieldNumber As Integer = 3
        Private Shared ReadOnly _repeated_oneofs_codec As FieldCodecType(Of String) = ForString(26)
        Private ReadOnly oneofs_ As pbc.RepeatedField(Of String) = New pbc.RepeatedField(Of String)()
        ''' <summary>
        '''  The list of types appearing in `oneof` definitions in this type.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public ReadOnly Property Oneofs As pbc.RepeatedField(Of String)
            Get
                Return oneofs_
            End Get
        End Property

        ''' <summary>Field number for the "options" field.</summary>
        Public Const OptionsFieldNumber As Integer = 4
        Private Shared ReadOnly _repeated_options_codec As FieldCodecType(Of Global.Google.Protobuf.WellKnownTypes.Option) = FieldCodec.ForMessage(34, Global.Google.Protobuf.WellKnownTypes.Option.Parser)
        Private ReadOnly options_ As pbc.RepeatedField(Of Global.Google.Protobuf.WellKnownTypes.Option) = New pbc.RepeatedField(Of Global.Google.Protobuf.WellKnownTypes.Option)()
        ''' <summary>
        '''  The protocol buffer options.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public ReadOnly Property Options As pbc.RepeatedField(Of Global.Google.Protobuf.WellKnownTypes.Option)
            Get
                Return options_
            End Get
        End Property

        ''' <summary>Field number for the "source_context" field.</summary>
        Public Const SourceContextFieldNumber As Integer = 5
        Private sourceContext_ As Global.Google.Protobuf.WellKnownTypes.SourceContext
        ''' <summary>
        '''  The source context.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Property SourceContext As Global.Google.Protobuf.WellKnownTypes.SourceContext
            Get
                Return sourceContext_
            End Get
            Set(value As Global.Google.Protobuf.WellKnownTypes.SourceContext)
                sourceContext_ = value
            End Set
        End Property

        ''' <summary>Field number for the "syntax" field.</summary>
        Public Const SyntaxFieldNumber As Integer = 6
        Private syntax_ As Global.Google.Protobuf.WellKnownTypes.Syntax = 0
        ''' <summary>
        '''  The source syntax.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Property Syntax As Global.Google.Protobuf.WellKnownTypes.Syntax
            Get
                Return syntax_
            End Get
            Set(value As Global.Google.Protobuf.WellKnownTypes.Syntax)
                syntax_ = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function Equals(other As Object) As Boolean
            Return Equals(TryCast(other, Type))
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overloads Function Equals(other As Type) As Boolean Implements IEquatable(Of Type).Equals
            If ReferenceEquals(other, Nothing) Then
                Return False
            End If

            If ReferenceEquals(other, Me) Then
                Return True
            End If

            If Not Equals(Name, other.Name) Then Return False
            If Not fields_.Equals(other.fields_) Then Return False
            If Not oneofs_.Equals(other.oneofs_) Then Return False
            If Not options_.Equals(other.options_) Then Return False
            If Not Object.Equals(SourceContext, other.SourceContext) Then Return False
            If Syntax <> other.Syntax Then Return False
            Return True
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function GetHashCode() As Integer
            Dim hash = 1
            If Name.Length <> 0 Then hash = hash Xor Name.GetHashCode()
            hash = hash Xor fields_.GetHashCode()
            hash = hash Xor oneofs_.GetHashCode()
            hash = hash Xor options_.GetHashCode()
            If sourceContext_ IsNot Nothing Then hash = hash Xor SourceContext.GetHashCode()
            If Syntax <> 0 Then hash = hash Xor Syntax.GetHashCode()
            Return hash
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function ToString() As String
            Return JsonFormatter.ToDiagnosticString(Me)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub WriteTo(output As CodedOutputStream) Implements IMessage.WriteTo
            If Name.Length <> 0 Then
                output.WriteRawTag(10)
                output.WriteString(Name)
            End If

            fields_.WriteTo(output, _repeated_fields_codec)
            oneofs_.WriteTo(output, _repeated_oneofs_codec)
            options_.WriteTo(output, _repeated_options_codec)

            If sourceContext_ IsNot Nothing Then
                output.WriteRawTag(42)
                output.WriteMessage(SourceContext)
            End If

            If Syntax <> 0 Then
                output.WriteRawTag(48)
                output.WriteEnum(CInt(Syntax))
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Function CalculateSize() As Integer Implements IMessage.CalculateSize
            Dim size = 0

            If Name.Length <> 0 Then
                size += 1 + CodedOutputStream.ComputeStringSize(Name)
            End If

            size += fields_.CalculateSize(_repeated_fields_codec)
            size += oneofs_.CalculateSize(_repeated_oneofs_codec)
            size += options_.CalculateSize(_repeated_options_codec)

            If sourceContext_ IsNot Nothing Then
                size += 1 + CodedOutputStream.ComputeMessageSize(SourceContext)
            End If

            If Syntax <> 0 Then
                size += 1 + CodedOutputStream.ComputeEnumSize(CInt(Syntax))
            End If

            Return size
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub MergeFrom(other As Type) Implements IMessageType(Of Type).MergeFrom
            If other Is Nothing Then
                Return
            End If

            If other.Name.Length <> 0 Then
                Name = other.Name
            End If

            fields_.Add(other.fields_)
            oneofs_.Add(other.oneofs_)
            options_.Add(other.options_)

            If other.sourceContext_ IsNot Nothing Then
                If sourceContext_ Is Nothing Then
                    sourceContext_ = New Global.Google.Protobuf.WellKnownTypes.SourceContext()
                End If

                SourceContext.MergeFrom(other.SourceContext)
            End If

            If other.Syntax <> 0 Then
                Syntax = other.Syntax
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub MergeFrom(input As CodedInputStream) Implements IMessage.MergeFrom
            Dim tag As New Value(Of UInteger)

            While ((tag = input.ReadTag())) <> 0

                Select Case tag.Value
                    Case 10
                        Name = input.ReadString()

                    Case 18
                        fields_.AddEntriesFrom(input, _repeated_fields_codec)

                    Case 26
                        oneofs_.AddEntriesFrom(input, _repeated_oneofs_codec)

                    Case 34
                        options_.AddEntriesFrom(input, _repeated_options_codec)

                    Case 42

                        If sourceContext_ Is Nothing Then
                            sourceContext_ = New Global.Google.Protobuf.WellKnownTypes.SourceContext()
                        End If

                        input.ReadMessage(sourceContext_)

                    Case 48
                        syntax_ = CType(input.ReadEnum(), Global.Google.Protobuf.WellKnownTypes.Syntax)

                    Case Else
                        input.SkipLastField()
                End Select
            End While
        End Sub
    End Class


#End Region

End Namespace
#End Region