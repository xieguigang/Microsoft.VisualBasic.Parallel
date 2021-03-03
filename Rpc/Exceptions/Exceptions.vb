﻿Imports System
Imports Rpc.MessageProtocol

Namespace Rpc
    Friend Module Exceptions
        Friend Function UnexpectedMessageType(ByVal present As msg_type) As FormatException
            Return New FormatException(String.Format("unexpected message type: `{0}'", present))
        End Function

        Friend Function NoRFC5531(ByVal paramName As String) As ArgumentException
            Return New ArgumentException("structure must be RFC5531", paramName)
        End Function

        Friend Function Format(ByVal frm As String, ParamArray args As Object()) As FormatException
            Return New FormatException(String.Format(frm, args))
        End Function

        Friend Function SystemError(ByVal replyBody As reply_body) As ReplyException
            Return New ReplyException(replyBody, "system error in RPC-server")
        End Function

        Friend Function AuthError(ByVal replyBody As reply_body, ByVal state As auth_stat) As AuthenticateException
            Return New AuthenticateException(replyBody, GetAuthDescription(state))
        End Function

        Friend Function GetAuthDescription(ByVal state As auth_stat) As String
            Select Case state
                Case auth_stat.AUTH_BADCRED
                    Return "bad credential (seal broken)"
                Case auth_stat.AUTH_BADVERF
                    Return "bad verifier (seal broken)"
                Case auth_stat.AUTH_FAILED
                    Return "unknown reason"
                Case auth_stat.AUTH_INVALIDRESP
                    Return "bogus response verifier"
                Case auth_stat.AUTH_OK
                    Return "success"
                Case auth_stat.AUTH_REJECTEDCRED
                    Return "client must begin new session"
                Case auth_stat.AUTH_REJECTEDVERF
                    Return "verifier expired or replayed"
                Case auth_stat.AUTH_TOOWEAK
                    Return "rejected for security reasons"
                Case auth_stat.RPCSEC_GSS_CREDPROBLEM
                    Return "no credentials for user"
                Case auth_stat.RPCSEC_GSS_CTXPROBLEM
                    Return "problem with context"
                Case Else
                    Return String.Format("unknown state: {0}", state)
            End Select
        End Function

        Friend Function RpcVersionError(ByVal replyBody As reply_body, ByVal info As mismatch_info) As ReplyException
            Return New ReplyException(replyBody, String.Format("unsupported RPC version number (supported versions of between {0} and {1})", info.low, info.high))
        End Function

        Friend Function ProgramMismatch(ByVal replyBody As reply_body, ByVal info As mismatch_info) As ReplyException
            Return New ReplyException(replyBody, String.Format("remote can't support program version (supported versions of between {0} and {1})", info.low, info.high))
        End Function

        Friend Function ProgramUnavalible(ByVal replyBody As reply_body) As ReplyException
            Return New ReplyException(replyBody, "remote hasn't exported program")
        End Function

        Friend Function ProcedureUnavalible(ByVal replyBody As reply_body) As RpcException
            Return New ReplyException(replyBody, "program can't support procedure")
        End Function

        Friend Function GarbageArgs() As RpcException
            Return New RpcException("procedure can't decode params")
        End Function
    End Module
End Namespace
