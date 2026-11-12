
Imports MySqlConnector
Imports System.Windows.Forms

Module DbDelica
    Private ReadOnly connectionString As String =
        "Server=localhost;" &
        "Port=3306;" &
        "Database=delica_laundry;" &
        "User ID=root;" &
        "Password=nisa1234;" &
        "SslMode=Disabled;" &
        "AllowPublicKeyRetrieval=True;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    Public Function TestConnection() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show(
                "Koneksi database gagal!" & vbCrLf & ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
            Return False
        End Try
    End Function
End Module
