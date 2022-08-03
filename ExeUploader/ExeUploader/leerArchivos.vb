Public Class leerArchivos
    Public Function GetFiles(ByVal path As String, ByVal extension As String) As List(Of IO.FileInfo)

        If (String.IsNullOrEmpty(path)) Then Return Nothing

        If (String.IsNullOrEmpty(extension)) Then
            extension = "*.*"
        End If

        Dim fileNames As String() = IO.Directory.GetFiles(path, extension)

        Dim files As New List(Of IO.FileInfo)

        For Each fileName As String In fileNames
            Dim fi As New IO.FileInfo(fileName)
            files.Add(fi)
        Next

        Return files

    End Function
    Public Function CopyFiles(ByVal destinyFolder As String, _
                       ByVal fileNames As List(Of String)) As Integer


        If (fileNames Is Nothing) Then Return 0

        Dim count As Integer

        For Each file As String In fileNames

            Dim destFileName As String = IO.Path.Combine(destinyFolder, IO.Path.GetFileName(file))

            Try
                IO.File.Copy(file, destFileName)
                count += 1

            Catch
                ' Si se ha producido una excepción,
                ' se supone que el archivo no se ha
                ' movido. Continuamos con el movimiento
                ' de archivos.

            End Try

        Next

        Return count

    End Function
    Public Function MoveFiles(ByVal destinyFolder As String, _
                           ByVal fileNames As List(Of String)) As Integer


        If (fileNames Is Nothing) Then Return 0

        Dim count As Integer

        For Each file As String In fileNames

            Dim destFileName As String = IO.Path.Combine(destinyFolder, IO.Path.GetFileName(file))

            Try
                IO.File.Move(file, destFileName)
                count += 1

            Catch
                ' Si se ha producido una excepción,
                ' se supone que el archivo no se ha
                ' movido. Continuamos con el movimiento
                ' de archivos.

            End Try

        Next

        Return count

    End Function
End Class
