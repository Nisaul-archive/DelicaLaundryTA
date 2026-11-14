Imports MySqlConnector
Imports System.Data

Public Class FrmCustomer

    Private selectedCustomerId As Integer = 0

    ' ==========================================
    ' FORM LOAD
    ' ==========================================
    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtCustomerID.ReadOnly = True
            txtCustomerID.TabStop = False

            dgvCustomer.Columns.Clear()
            dgvCustomer.AutoGenerateColumns = True
            dgvCustomer.ReadOnly = True
            dgvCustomer.AllowUserToAddRows = False
            dgvCustomer.AllowUserToDeleteRows = False
            dgvCustomer.MultiSelect = False
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvCustomer.RowHeadersVisible = False

            ApplyRoleAccess()
            LoadCustomers()
            ResetCustomer()

        Catch ex As Exception
            TampilkanError("Gagal menyiapkan Form Master Pelanggan", ex)
        End Try
    End Sub

    ' ==========================================
    ' HAK AKSES
    ' ==========================================
    Private Sub ApplyRoleAccess()
        btnMasterUser.Visible = True
        btnMasterUser.Enabled = True
    End Sub

    ' ==========================================
    ' PREVIEW ID PELANGGAN BERIKUTNYA
    ' ==========================================
    Private Function AmbilIdPelangganBerikutnya() As String
        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            Const sql As String =
                "SELECT AUTO_INCREMENT FROM information_schema.TABLES " &
                "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'customers'"

            Using cmd As New MySqlCommand(sql, conn)
                Dim hasil As Object = cmd.ExecuteScalar()

                If hasil Is Nothing OrElse hasil Is DBNull.Value Then
                    Throw New InvalidOperationException(
                        "Nomor AUTO_INCREMENT tabel customers tidak ditemukan.")
                End If

                Return "CUST-" & Convert.ToInt64(hasil).ToString("D3")
            End Using
        End Using
    End Function

    Private Sub TampilkanIdPelangganBerikutnya()
        Try
            txtCustomerID.Text = AmbilIdPelangganBerikutnya()
        Catch ex As Exception
            txtCustomerID.Clear()
            TampilkanError("Gagal mengambil perkiraan ID pelanggan", ex)
        End Try
    End Sub

    ' ==========================================
    ' TAMPIL DATA PELANGGAN
    ' ==========================================
    Private Sub LoadCustomers(Optional keyword As String = "")
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT customer_id AS ID, " &
                    "CONCAT('CUST-',LPAD(customer_id,3,'0')) AS `ID Pelanggan`, " &
                    "customer_name AS `Nama Pelanggan`, " &
                    "phone AS `Nomor Telepon`, address AS `Alamat` " &
                    "FROM customers " &
                    "WHERE customer_name LIKE @q OR phone LIKE @q " &
                    "OR address LIKE @q OR CAST(customer_id AS CHAR) LIKE @q " &
                    "ORDER BY customer_id"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@q", MySqlDbType.VarChar).Value =
                        "%" & keyword.Trim() & "%"

                    Using da As New MySqlDataAdapter(cmd)
                        Dim tabel As New DataTable()
                        da.Fill(tabel)
                        dgvCustomer.DataSource = tabel

                        If dgvCustomer.Columns.Contains("ID") Then
                            dgvCustomer.Columns("ID").Visible = False
                        End If
                    End Using
                End Using
            End Using

            dgvCustomer.ClearSelection()

        Catch ex As Exception
            TampilkanError("Gagal memuat data pelanggan", ex)
        End Try
    End Sub

    ' ==========================================
    ' VALIDASI INPUT
    ' ==========================================
    Private Function ValidasiCustomer() As Boolean
        If txtCustomerName.Text.Trim() = "" Then
            MessageBox.Show("Nama pelanggan wajib diisi.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerName.Focus()
            Return False
        End If

        If txtPhone.Text.Trim() = "" Then
            MessageBox.Show("Nomor telepon wajib diisi.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Return False
        End If

        If txtAddress.Text.Trim() = "" Then
            MessageBox.Show("Alamat pelanggan wajib diisi.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return False
        End If

        Return True
    End Function

    ' ==========================================
    ' SIMPAN PELANGGAN BARU
    ' ==========================================
    Private Sub btnSaveCustomer_Click(sender As Object, e As EventArgs) Handles btnSaveCustomer.Click
        If selectedCustomerId <> 0 Then
            MessageBox.Show("Data lama sedang dipilih. Klik Edit untuk menyimpan perubahan atau Reset untuk menambah data baru.")
            Return
        End If

        If Not ValidasiCustomer() Then Return

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Const sql As String =
                    "INSERT INTO customers(customer_name, phone, address) " &
                    "VALUES(@name, @phone, @address)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value =
                        txtCustomerName.Text.Trim()
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value =
                        txtPhone.Text.Trim()
                    cmd.Parameters.Add("@address", MySqlDbType.Text).Value =
                        txtAddress.Text.Trim()

                    cmd.ExecuteNonQuery()

                    Dim idFinal As Long = cmd.LastInsertedId
                    MessageBox.Show("Pelanggan berhasil disimpan dengan ID CUST-" &
                                    idFinal.ToString("D3"), "Berhasil",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using

            LoadCustomers(txtSearchCustomer.Text)
            ResetCustomer()

        Catch ex As MySqlException When ex.Number = 1062
            TampilkanError("Data pelanggan terdeteksi duplikat", ex)
        Catch ex As Exception
            TampilkanError("Gagal menyimpan pelanggan", ex)
        End Try
    End Sub

    ' ==========================================
    ' UBAH PELANGGAN
    ' ==========================================
    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        If selectedCustomerId = 0 Then
            MessageBox.Show("Pilih pelanggan dari tabel terlebih dahulu.")
            Return
        End If

        If Not ValidasiCustomer() Then Return

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Const sql As String =
                    "UPDATE customers SET customer_name=@name, phone=@phone, " &
                    "address=@address WHERE customer_id=@id"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value =
                        txtCustomerName.Text.Trim()
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value =
                        txtPhone.Text.Trim()
                    cmd.Parameters.Add("@address", MySqlDbType.Text).Value =
                        txtAddress.Text.Trim()
                    cmd.Parameters.Add("@id", MySqlDbType.UInt32).Value =
                        selectedCustomerId

                    Dim jumlah As Integer = cmd.ExecuteNonQuery()
                    If jumlah = 0 Then
                        MessageBox.Show("Data pelanggan tidak ditemukan atau tidak ada perubahan.")
                    Else
                        MessageBox.Show("Data pelanggan berhasil diperbarui.")
                    End If
                End Using
            End Using

            LoadCustomers(txtSearchCustomer.Text)
            ResetCustomer()

        Catch ex As Exception
            TampilkanError("Gagal mengubah pelanggan", ex)
        End Try
    End Sub

    ' ==========================================
    ' HAPUS PELANGGAN
    ' ==========================================
    Private Sub btnDeleteCustomer_Click(sender As Object, e As EventArgs) Handles btnDeleteCustomer.Click
        If selectedCustomerId = 0 Then
            MessageBox.Show("Pilih pelanggan yang akan dihapus.")
            Return
        End If

        If MessageBox.Show("Hapus pelanggan terpilih?", "Konfirmasi Hapus",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Using cmd As New MySqlCommand(
                    "DELETE FROM customers WHERE customer_id=@id", conn)

                    cmd.Parameters.Add("@id", MySqlDbType.UInt32).Value =
                        selectedCustomerId

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Pelanggan berhasil dihapus.")
            LoadCustomers(txtSearchCustomer.Text)
            ResetCustomer()

        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show(
                "Pelanggan tidak dapat dihapus karena sudah terhubung dengan akun Customer atau transaksi." &
                vbCrLf & "Data tetap dipertahankan agar riwayat transaksi aman.",
                "Tidak dapat menghapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            TampilkanError("Gagal menghapus pelanggan", ex)
        End Try
    End Sub

    ' ==========================================
    ' RESET FORM
    ' ==========================================
    Private Sub btnResetCustomer_Click(sender As Object, e As EventArgs) Handles btnResetCustomer.Click
        Try
            ResetCustomer()
        Catch ex As Exception
            TampilkanError("Gagal mereset form pelanggan", ex)
        End Try
    End Sub

    Private Sub ResetCustomer()
        selectedCustomerId = 0
        txtCustomerID.Clear()
        txtCustomerName.Clear()
        txtPhone.Clear()
        txtAddress.Clear()

        btnSaveCustomer.Enabled = True
        btnUpdateCustomer.Enabled = False
        btnDeleteCustomer.Enabled = False

        dgvCustomer.ClearSelection()
        TampilkanIdPelangganBerikutnya()
        txtCustomerName.Focus()
    End Sub

    ' ==========================================
    ' PENCARIAN
    ' ==========================================
    Private Sub btnSearchCustomer_Click(sender As Object, e As EventArgs) Handles btnSearchCustomer.Click
        LoadCustomers(txtSearchCustomer.Text)
    End Sub

    Private Sub txtSearchCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtSearchCustomer.TextChanged
        LoadCustomers(txtSearchCustomer.Text)
    End Sub

    ' ==========================================
    ' PILIH DATA DARI TABEL
    ' ==========================================
    Private Sub dgvCustomer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellClick
        If e.RowIndex < 0 Then Return

        Try
            Dim row As DataGridViewRow = dgvCustomer.Rows(e.RowIndex)
            If row.IsNewRow Then Return

            selectedCustomerId = Convert.ToInt32(row.Cells("ID").Value)
            txtCustomerID.Text = "CUST-" & selectedCustomerId.ToString("D3")
            txtCustomerName.Text = Convert.ToString(row.Cells("Nama Pelanggan").Value)
            txtPhone.Text = Convert.ToString(row.Cells("Nomor Telepon").Value)
            txtAddress.Text = Convert.ToString(row.Cells("Alamat").Value)

            btnSaveCustomer.Enabled = False
            btnUpdateCustomer.Enabled = True
            btnDeleteCustomer.Enabled = True

        Catch ex As Exception
            TampilkanError("Gagal membaca data pelanggan dari tabel", ex)
        End Try
    End Sub

    ' ==========================================
    ' NAVIGASI SIDEBAR
    ' ==========================================
    Private Sub btnMasterService_Click(sender As Object, e As EventArgs) Handles btnMasterService.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
        FrmServices.Show()
        Me.Hide()
    End Sub

    Private Sub btnMasterUser_Click(sender As Object, e As EventArgs) Handles btnMasterUser.Click
        If Sesi.UserRole <> "Owner" Then Return
        FrmUser.Show()
        Me.Hide()
    End Sub

    Private Sub TampilkanError(kegiatan As String, ex As Exception)
        MessageBox.Show(kegiatan & ": " & ex.Message,
                        "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        FrmOrder.Show()
        Me.Hide()
    End Sub

    ' Navigasi Pembayaran
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        FrmPayment.Show()
        Me.Hide()
    End Sub

    Private Sub btnMasterCustomer_Click(sender As Object, e As EventArgs) Handles btnMasterCustomer.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
    End Sub
End Class
