Imports System
Imports System.IO
Public Class cINI
#Region "-Variables-"

    Public RutaIni As String = String.Concat(System.IO.Directory.GetCurrentDirectory(), "\LogisticaUploader.ini")

    Private filePath As String
    Private fileStream As FileStream
    Private streamWriter As StreamWriter

#End Region
#Region "Declaraciones y funciones para INI"

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer


    Sub GrabaINI(ByVal Archivo As String, ByVal Seccion As String, ByVal Clave As String, ByVal Text As String)
        WritePrivateProfileString(Seccion, Clave, Text, Archivo)
    End Sub

    Function LeeINI(ByVal Archivo As String, ByVal Seccion As String, ByVal Clave As String) As String
        Dim iRetLen As Integer
        Dim sRet As String
        Dim lpDefault As String
        lpDefault = "Unknown"
        sRet = Space(255)
        iRetLen = GetPrivateProfileString(Seccion, Clave, lpDefault, sRet, Len(sRet), Archivo)
        sRet = Left(sRet, iRetLen)
        LeeINI = sRet
    End Function

#End Region
End Class
