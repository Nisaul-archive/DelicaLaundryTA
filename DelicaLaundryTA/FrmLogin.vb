
Imports MySqlConnector

Public Class FrmLogin

    Private Sub FrmLogin_Shown(sender As Object,
                               e As EventArgs) Handles MyBase.Shown

        If TestConnection() Then
            ' Koneksi berhasil
        End If

    End Sub

    Private Sub btnLogin_Click(sender As Object,
                               e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text.Trim() = "" OrElse
           txtPassword.Text = "" Then
            MessageBox.Show("Username dan password harus diisi!")
            Return
        End If

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Dim sql As String =
                    "SELECT user_id, username, password_hash, " &
                    "full_name, role, is_active " &
                    "FROM users WHERE username = @username LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@username", txtUsername.Text.Trim())

                    Using reader = cmd.ExecuteReader()

                        If reader.Read() Then

                            If Not Convert.ToBoolean(reader("is_active")) Then
                                MessageBox.Show("Akun tidak aktif!")
                                Return
                            End If

                            Dim hash As String =
                                reader("password_hash").ToString()

                            If BCrypt.Net.BCrypt.Verify(
                                txtPassword.Text, hash) Then

                                Sesi.UserID =
                                    Convert.ToInt32(reader("user_id"))

                                Sesi.Username =
                                    reader("username").ToString()

                                Sesi.FullName =
                                    reader("full_name").ToString()

                                Sesi.UserRole =
                                    reader("role").ToString()

                                reader.Close()

                                MessageBox.Show(
                                    "Selamat datang, " & Sesi.FullName,
                                    "Login Berhasil"
                                )

                                Me.Hide()
                                FrmServices.Show()
                            Else
                                MessageBox.Show("Password salah!")
                            End If

                        Else
                            MessageBox.Show("Username tidak ditemukan!")
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Terjadi kesalahan: " & ex.Message,
                "Login Error"
            )
        End Try
    End Sub

    Private Sub btnGenerateHash_Click(sender As Object, e As EventArgs) Handles btnGenerateHash.Click

        Dim password As String = "DelicaOwner123!"

        Dim hash As String =
        BCrypt.Net.BCrypt.HashPassword(password)

        MessageBox.Show(hash, "Password Hash")

    End Sub
End Class
