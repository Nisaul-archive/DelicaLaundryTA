Imports MySqlConnector
Imports System.Data

Public Class FrmUser

    Private selectedUserId As Integer = 0

    ' ==========================================
    ' FORM LOAD
    ' ==========================================
    Private Sub FrmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Sesi.UserRole <> "Owner" Then
                MessageBox.Show("Hanya Owner yang dapat mengelola pengguna.",
                                "Hak Akses", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.BeginInvoke(New Action(Sub()
                                               FrmServices.Show()
                                               Me.Close()
                                           End Sub))
                Return
            End If

            txtUserID.ReadOnly = True
            txtUserID.TabStop = False
            txtPassword.UseSystemPasswordChar = True

            dgvUser.Columns.Clear()
            dgvUser.AutoGenerateColumns = True
            dgvUser.ReadOnly = True
            dgvUser.AllowUserToAddRows = False
            dgvUser.AllowUserToDeleteRows = False
            dgvUser.MultiSelect = False
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUser.RowHeadersVisible = False

            cmbRole.Items.Clear()
            cmbRole.Items.Add("Owner")
            cmbRole.Items.Add("Staff Laundry")
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList

            cmbUserStatus.Items.Clear()
            cmbUserStatus.Items.Add("Aktif")
            cmbUserStatus.Items.Add("Tidak Aktif")
            cmbUserStatus.DropDownStyle = ComboBoxStyle.DropDownList

            LoadUsers()
            ResetUser()

        Catch ex As Exception
            TampilkanError("Gagal menyiapkan Form Master Pengguna", ex)
        End Try
    End Sub

    ' ==========================================
    ' PREVIEW ID PENGGUNA BERIKUTNYA
    ' ==========================================
    Private Function AmbilIdPenggunaBerikutnya() As String
        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            Const sql As String =
                "SELECT AUTO_INCREMENT FROM information_schema.TABLES " &
                "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'users'"

            Using cmd As New MySqlCommand(sql, conn)
                Dim hasil As Object = cmd.ExecuteScalar()

                If hasil Is Nothing OrElse hasil Is DBNull.Value Then
                    Throw New InvalidOperationException(
                        "Nomor AUTO_INCREMENT tabel users tidak ditemukan.")
                End If

                Return "USR-" & Convert.ToInt64(hasil).ToString("D3")
            End Using
        End Using
    End Function

    Private Sub TampilkanIdPenggunaBerikutnya()
        Try
            txtUserID.Text = AmbilIdPenggunaBerikutnya()
        Catch ex As Exception
            txtUserID.Clear()
            TampilkanError("Gagal mengambil perkiraan ID pengguna", ex)
        End Try
    End Sub

    ' ==========================================
    ' TAMPIL DATA PENGGUNA INTERNAL
    ' Customer web tidak ditampilkan di form ini.
    ' ==========================================
    Private Sub LoadUsers(Optional keyword As String = "")
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT user_id AS ID, " &
                    "CONCAT('USR-',LPAD(user_id,3,'0')) AS `ID Pengguna`, " &
                    "full_name AS `Nama Lengkap`, username AS `Username`, " &
                    "role AS `Role`, IF(is_active=1,'Aktif','Tidak Aktif') AS `Status` " &
                    "FROM users " &
                    "WHERE role IN ('Owner','Staff Laundry') " &
                    "AND (full_name LIKE @q OR username LIKE @q " &
                    "OR role LIKE @q OR CAST(user_id AS CHAR) LIKE @q) " &
                    "ORDER BY user_id"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@q", MySqlDbType.VarChar).Value =
                        "%" & keyword.Trim() & "%"

                    Using da As New MySqlDataAdapter(cmd)
                        Dim tabel As New DataTable()
                        da.Fill(tabel)
                        dgvUser.DataSource = tabel

                        If dgvUser.Columns.Contains("ID") Then
                            dgvUser.Columns("ID").Visible = False
                        End If
                    End Using
                End Using
            End Using

            dgvUser.ClearSelection()

        Catch ex As Exception
            TampilkanError("Gagal memuat data pengguna", ex)
        End Try
    End Sub

    ' ==========================================
    ' VALIDASI
    ' ==========================================
    Private Function ValidasiUser(isNew As Boolean) As Boolean
        If txtFullName.Text.Trim() = "" Then
            MessageBox.Show("Nama lengkap wajib diisi.")
            txtFullName.Focus()
            Return False
        End If

        If txtUsername.Text.Trim() = "" Then
            MessageBox.Show("Username wajib diisi.")
            txtUsername.Focus()
            Return False
        End If

        If cmbRole.SelectedIndex < 0 Then
            MessageBox.Show("Pilih Role/Hak Akses.")
            cmbRole.Focus()
            Return False
        End If

        If cmbUserStatus.SelectedIndex < 0 Then
            MessageBox.Show("Pilih Status Akun.")
            cmbUserStatus.Focus()
            Return False
        End If

        If isNew AndAlso txtPassword.Text = "" Then
            MessageBox.Show("Password wajib diisi untuk pengguna baru.")
            txtPassword.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub TambahkanParameterUser(cmd As MySqlCommand)
        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value =
            txtFullName.Text.Trim()
        cmd.Parameters.Add("@username", MySqlDbType.VarChar, 50).Value =
            txtUsername.Text.Trim()
        cmd.Parameters.Add("@role", MySqlDbType.VarChar, 30).Value =
            cmbRole.Text
        cmd.Parameters.Add("@active", MySqlDbType.Bit).Value =
            If(cmbUserStatus.Text = "Aktif", 1, 0)
    End Sub

    ' ==========================================
    ' SIMPAN PENGGUNA BARU
    ' ==========================================
    Private Sub btnSaveUser_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click
        If selectedUserId <> 0 Then
            MessageBox.Show("Data lama sedang dipilih. Klik Edit atau Reset terlebih dahulu.")
            Return
        End If

        If Not ValidasiUser(True) Then Return

        Try
            Dim hash As String = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text)

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Jangan masukkan customer_id. Form ini membuat akun Owner/Staff.
                Const sql As String =
                    "INSERT INTO users(full_name, username, password_hash, role, is_active) " &
                    "VALUES(@name, @username, @hash, @role, @active)"

                Using cmd As New MySqlCommand(sql, conn)
                    TambahkanParameterUser(cmd)
                    cmd.Parameters.Add("@hash", MySqlDbType.VarChar, 255).Value = hash
                    cmd.ExecuteNonQuery()

                    Dim idFinal As Long = cmd.LastInsertedId
                    MessageBox.Show("Pengguna berhasil disimpan dengan ID USR-" &
                                    idFinal.ToString("D3"), "Berhasil",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using

            LoadUsers(txtSearchUser.Text)
            ResetUser()

        Catch ex As MySqlException When ex.Number = 1062
            MessageBox.Show("Username sudah digunakan. Silakan gunakan username lain.",
                            "Username Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            TampilkanError("Gagal menyimpan pengguna", ex)
        End Try
    End Sub

    ' ==========================================
    ' UBAH PENGGUNA
    ' Password kosong = password lama tetap dipakai.
    ' Password diisi = hash password diperbarui.
    ' ==========================================
    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click
        If selectedUserId = 0 Then
            MessageBox.Show("Pilih pengguna dari tabel terlebih dahulu.")
            Return
        End If

        If selectedUserId = Sesi.UserID Then
            MessageBox.Show("Akun yang sedang digunakan tidak dapat diubah melalui form ini.")
            Return
        End If

        If Not ValidasiUser(False) Then Return

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim sql As String

                If txtPassword.Text.Trim() = "" Then
                    sql =
                        "UPDATE users SET full_name=@name, username=@username, " &
                        "role=@role, is_active=@active WHERE user_id=@id"
                Else
                    sql =
                        "UPDATE users SET full_name=@name, username=@username, " &
                        "password_hash=@hash, role=@role, is_active=@active WHERE user_id=@id"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    TambahkanParameterUser(cmd)

                    If txtPassword.Text.Trim() <> "" Then
                        Dim hash As String = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text)
                        cmd.Parameters.Add("@hash", MySqlDbType.VarChar, 255).Value = hash
                    End If

                    cmd.Parameters.Add("@id", MySqlDbType.UInt32).Value = selectedUserId

                    Dim jumlah As Integer = cmd.ExecuteNonQuery()
                    If jumlah = 0 Then
                        MessageBox.Show("Pengguna tidak ditemukan atau tidak ada perubahan.")
                    Else
                        MessageBox.Show("Data pengguna berhasil diperbarui.")
                    End If
                End Using
            End Using

            LoadUsers(txtSearchUser.Text)
            ResetUser()

        Catch ex As MySqlException When ex.Number = 1062
            MessageBox.Show("Username sudah digunakan oleh pengguna lain.")
        Catch ex As Exception
            TampilkanError("Gagal mengubah pengguna", ex)
        End Try
    End Sub

    ' ==========================================
    ' HAPUS PENGGUNA
    ' ==========================================
    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If selectedUserId = 0 Then
            MessageBox.Show("Pilih pengguna yang akan dihapus.")
            Return
        End If

        If selectedUserId = Sesi.UserID Then
            MessageBox.Show("Akun yang sedang login tidak dapat dihapus.")
            Return
        End If

        If MessageBox.Show("Hapus pengguna terpilih?", "Konfirmasi Hapus",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand(
                    "DELETE FROM users WHERE user_id=@id", conn)

                    cmd.Parameters.Add("@id", MySqlDbType.UInt32).Value = selectedUserId
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Pengguna berhasil dihapus.")
            LoadUsers(txtSearchUser.Text)
            ResetUser()

        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show(
                "Pengguna masih terhubung dengan data lain atau transaksi." &
                vbCrLf & "Sebaiknya ubah status akun menjadi Tidak Aktif.",
                "Tidak dapat menghapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            TampilkanError("Gagal menghapus pengguna", ex)
        End Try
    End Sub

    ' ==========================================
    ' RESET FORM
    ' ==========================================
    Private Sub btnResetUser_Click(sender As Object, e As EventArgs) Handles btnResetUser.Click
        Try
            ResetUser()
        Catch ex As Exception
            TampilkanError("Gagal mereset form pengguna", ex)
        End Try
    End Sub

    Private Sub ResetUser()
        selectedUserId = 0

        txtUserID.Clear()
        txtFullName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()

        cmbRole.SelectedIndex = -1
        cmbUserStatus.SelectedItem = "Aktif"

        btnSaveUser.Enabled = True
        btnUpdateUser.Enabled = False
        btnDeleteUser.Enabled = False

        dgvUser.ClearSelection()
        TampilkanIdPenggunaBerikutnya()
        txtFullName.Focus()
    End Sub

    ' ==========================================
    ' PENCARIAN
    ' ==========================================
    Private Sub btnSearchUser_Click(sender As Object, e As EventArgs) Handles btnSearchUser.Click
        LoadUsers(txtSearchUser.Text)
    End Sub

    Private Sub txtSearchUser_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUser.TextChanged
        LoadUsers(txtSearchUser.Text)
    End Sub

    ' ==========================================
    ' PILIH DATA DARI TABEL
    ' ==========================================
    Private Sub dgvUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellClick
        If e.RowIndex < 0 Then Return

        Try
            Dim row As DataGridViewRow = dgvUser.Rows(e.RowIndex)
            If row.IsNewRow Then Return

            selectedUserId = Convert.ToInt32(row.Cells("ID").Value)
            txtUserID.Text = "USR-" & selectedUserId.ToString("D3")
            txtFullName.Text = Convert.ToString(row.Cells("Nama Lengkap").Value)
            txtUsername.Text = Convert.ToString(row.Cells("Username").Value)

            ' Password hash tidak ditampilkan kembali ke form.
            txtPassword.Clear()

            cmbRole.Text = Convert.ToString(row.Cells("Role").Value)
            cmbUserStatus.Text = Convert.ToString(row.Cells("Status").Value)

            btnSaveUser.Enabled = False
            btnUpdateUser.Enabled = True
            btnDeleteUser.Enabled = True

        Catch ex As Exception
            TampilkanError("Gagal membaca data pengguna dari tabel", ex)
        End Try
    End Sub

    ' ==========================================
    ' NAVIGASI SIDEBAR
    ' ==========================================
    Private Sub btnMasterService_Click(sender As Object, e As EventArgs) Handles btnMasterService.Click
        FrmServices.Show()
        Me.Hide()
    End Sub

    Private Sub btnMasterCustomer_Click(sender As Object, e As EventArgs) Handles btnMasterCustomer.Click
        FrmCustomer.Show()
        Me.Hide()
    End Sub

    Private Sub TampilkanError(kegiatan As String, ex As Exception)
        MessageBox.Show(kegiatan & ": " & ex.Message,
                        "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Class