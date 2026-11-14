
Imports MySqlConnector

Public Class FrmLogin

    Private Sub FrmLogin_Shown(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Shown

        If TestConnection() Then
            ' Koneksi database berhasil
        End If

    End Sub


    Private Sub btnLogin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLogin.Click

        ' Validasi input
        If txtUsername.Text.Trim() = "" OrElse
           txtPassword.Text = "" Then

            MessageBox.Show(
                "Username dan password harus diisi!",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return

        End If

        Try

            Dim loginBerhasil As Boolean = False
            Dim pesanError As String = ""

            Dim userId As Integer = 0
            Dim username As String = ""
            Dim fullName As String = ""
            Dim userRole As String = ""

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim sql As String =
                    "SELECT user_id, username, password, " &
                    "full_name, role, is_active " &
                    "FROM users " &
                    "WHERE username = @username LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@username",
                        txtUsername.Text.Trim())

                    Using reader As MySqlDataReader =
                        cmd.ExecuteReader()

                        If reader.Read() Then

                            ' Periksa status akun
                            If Not Convert.ToBoolean(
                                reader("is_active")) Then

                                pesanError = "Akun kamu tidak aktif!"

                            Else

                                ' Ambil password dari database
                                Dim storedPassword As String =
                                    reader("password").ToString()

                                ' Verifikasi password biasa
                                If String.Equals(
                                    txtPassword.Text,
                                    storedPassword,
                                    StringComparison.Ordinal) Then

                                    userId =
                                        Convert.ToInt32(
                                            reader("user_id"))

                                    username =
                                        reader("username").ToString()

                                    fullName =
                                        reader("full_name").ToString()

                                    userRole =
                                        reader("role").ToString()

                                    loginBerhasil = True

                                Else

                                    pesanError =
                                        "Username atau password salah!"

                                End If

                            End If

                        Else

                            pesanError =
                                "Username atau password salah!"

                        End If

                    End Using

                End Using

            End Using

            ' Jika login gagal
            If Not loginBerhasil Then

                MessageBox.Show(
                    pesanError,
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                txtPassword.Clear()
                txtPassword.Focus()

                Return

            End If

            ' Simpan informasi pengguna ke Session
            Sesi.UserID = userId
            Sesi.Username = username
            Sesi.FullName = fullName
            Sesi.UserRole = userRole

            MessageBox.Show(
                "Selamat datang, " & fullName &
                vbCrLf & "Role: " & userRole,
                "Login Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ' Buka halaman utama
            Me.Hide()

            FrmOrder.Show()

        Catch ex As Exception

            MessageBox.Show(
                "Terjadi kesalahan: " & ex.Message,
                "Login Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

End Class
