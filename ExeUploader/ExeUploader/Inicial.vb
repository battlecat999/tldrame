Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.IO
Class Inicial

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Exe Uploader 2022-08-03"
        'Call ReemplazarVersion("BL_Aereo.exe", False)

        Call ReemplazarVersion("PermisoUsuarioForm.Infrastructure.dll", False)
        Call ReemplazarVersion("k_negocio_00.dll", False)
        Call ReemplazarVersion("k_loger.dll", False)
        Call ReemplazarVersion("k_mysql.dll", False)
        Call ReemplazarVersion("PermisoUsuarioForm.Domain.dll", False)
        Call ReemplazarVersion("k_presentacion_00.exe", True)


    End Sub
    Private Function ReemplazarVersion(ByVal nombreEXE As String, ByVal aOpen As Boolean) As Boolean
        Try
            Dim ini As New cINI
            Dim rutaINIServer As String
            Dim rutaINILocal As String
            Dim lFile As New leerArchivos

            rutaINIServer = ini.LeeINI(ini.RutaIni, "Settings", "CadenaServer") 'obtengo el parametros
            Me.txtRutaServer.Text = String.Concat(rutaINIServer, "\", nombreEXE).Replace("\\", "\")

            Me.txtVersionServer.Text = BuscarVersion(Me.txtRutaServer.Text)
            'Me.txtVersionServer.Text = CDbl(Replace(Me.txtVersionServer.Text, ".", ""))

            rutaINILocal = ini.LeeINI(ini.RutaIni, "Settings", "CadenaLocal") 'obtengo el parametros
            Me.txtRutaLocal.Text = String.Concat(rutaINILocal, "\", nombreEXE).Replace("\\", "\")

            Me.txtVersionLocal.Text = BuscarVersion(Me.txtRutaLocal.Text)
            'Me.txtVersionLocal.Text = CDbl(Replace(Me.txtVersionLocal.Text, ".", ""))

            If Me.txtVersionServer.Text <> Me.txtVersionLocal.Text Then

                If File.Exists(Me.txtRutaLocal.Text) = True Then
                    Rename(Me.txtRutaLocal.Text, Me.txtRutaLocal.Text & "_" & Format(Now, "yyyyMMdd HHmm"))
                End If
                My.Computer.FileSystem.CopyDirectory(rutaINIServer, rutaINILocal, True)

                If aOpen = True Then
                    Shell(Me.txtRutaLocal.Text, AppWinStyle.NormalFocus)
                End If
            Else
                If aOpen = True Then
                    Shell(Me.txtRutaLocal.Text, AppWinStyle.NormalFocus)

                End If
            End If
            Application.Exit()
        Catch ex As Exception

            Shell(Me.txtRutaLocal.Text, AppWinStyle.NormalFocus)
            Application.Exit()
        End Try
    End Function
    Private Function BuscarVersion(ByVal ArchivosPath As String) As String
        Dim o As String
        Try
            o = System.Diagnostics.FileVersionInfo.GetVersionInfo(ArchivosPath).FileVersion
            BuscarVersion = o
            'Return sb.ToString
        Catch ex As Exception
            BuscarVersion = "1.0.0.0"
        End Try

    End Function
End Class