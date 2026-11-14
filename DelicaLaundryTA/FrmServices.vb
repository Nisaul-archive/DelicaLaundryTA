
Imports System.Data
Imports Guna.UI2.WinForms
Imports MySqlConnector

Public Class FrmServices

    Private selectedServiceId As Integer = 0

    ' ==========================================
    ' 1. FORM LOAD
    ' ==========================================
    Private Sub FrmServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtServiceID.ReadOnly = True
        txtServiceID.TabStop = False
        txtServiceName.Enabled = True
        txtServiceName.ReadOnly = False

        cmbPricingType.Enabled = True

        numUnitPrice.Enabled = True

        Guna2DataGridView1.Columns.Clear()
        Guna2DataGridView1.AutoGenerateColumns = True
        Guna2DataGridView1.ReadOnly = True
        Guna2DataGridView1.AllowUserToAddRows = False
        Guna2DataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        Guna2DataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        ' Pengaturan harga
        numUnitPrice.Minimum = 0D
        numUnitPrice.Maximum = 1000000000D
        numUnitPrice.ThousandsSeparator = True

        ' Pengaturan estimasi
        numEstimatedDays.Minimum = 1D
        numEstimatedDays.Maximum = 365D

        ' Pengaturan biaya express
        numExpressFee.Minimum = 0D
        numExpressFee.Maximum = 1000000000D
        numExpressFee.ThousandsSeparator = True

        ' Jenis perhitungan
        cmbPricingType.Items.Clear()
        cmbPricingType.Items.Add("KG")
        cmbPricingType.Items.Add("ITEM")

        ' Status layanan
        cmbIsActive.Items.Clear()
        cmbIsActive.Items.Add("Aktif")
        cmbIsActive.Items.Add("Tidak Aktif")

        ApplyRoleAccess()
        LoadServices()

        ' Kosongkan input dan tampilkan ID otomatis
        ResetService()

    End Sub

    ' ==========================================
    ' 2. MENGATUR HAK AKSES
    ' ==========================================
    Private Sub ApplyRoleAccess()

        btnMasterUser.Visible = True
        btnMasterUser.Enabled = True

    End Sub

    ' ==========================================
    ' 3. GENERATE ID LAYANAN OTOMATIS
    ' ==========================================
    Private Function GetPreviewServiceId() As String

        Using conn As MySqlConnection = DbDelica.GetConnection()

            conn.Open()

            Dim sql As String =
                "SELECT AUTO_INCREMENT " &
                "FROM information_schema.TABLES " &
                "WHERE TABLE_SCHEMA = DATABASE() " &
                "AND TABLE_NAME = 'services'"

            Using cmd As New MySqlCommand(sql, conn)

                Dim result As Object = cmd.ExecuteScalar()

                If result Is Nothing OrElse result Is DBNull.Value Then
                    Throw New Exception(
                        "Nomor otomatis tabel services tidak ditemukan.")
                End If

                Dim nextID As Long = Convert.ToInt64(result)

                Return "SRV-" & nextID.ToString("D3")

            End Using

        End Using

    End Function

    Private Sub TampilkanIdPerkiraan()

        Try
            txtServiceID.Text = GetPreviewServiceId()

        Catch ex As Exception
            txtServiceID.Clear()
            Debug.WriteLine("Gagal membuat ID layanan: " & ex.Message)
        End Try

    End Sub

    ' ==========================================
    ' 4. LOAD DATA LAYANAN DARI DATABASE
    ' ==========================================
    Private Sub LoadServices(Optional keyword As String = "")

        Try

            Using conn As MySqlConnection = DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "SELECT service_id AS ID, " &
                    "CONCAT('SRV-',LPAD(service_id,3,'0')) AS `ID Layanan`, " &
                    "service_name AS `Nama Layanan`, " &
                    "pricing_type AS `Jenis`, " &
                    "unit_price AS `Harga`, " &
                    "estimated_days AS `Estimasi (Hari)`, " &
                    "express_fee AS `Biaya Express`, " &
                    "IF(is_active=1,'Aktif','Tidak Aktif') AS `Status` " &
                    "FROM services " &
                    "WHERE service_name LIKE @q " &
                    "OR CAST(service_id AS CHAR) LIKE @q " &
                    "ORDER BY service_id ASC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@q", "%" & keyword.Trim() & "%")

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        Guna2DataGridView1.DataSource = dt

                        If Guna2DataGridView1.Columns.Contains("ID") Then
                            Guna2DataGridView1.Columns("ID").Visible = False
                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Gagal memuat layanan: " & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    ' ==========================================
    ' 5. VALIDASI INPUT
    ' Hanya dijalankan saat Simpan atau Ubah
    ' ==========================================
    Private Function ValidateInput() As Boolean

        If String.IsNullOrWhiteSpace(txtServiceName.Text) Then

            MessageBox.Show(
                "Nama layanan harus diisi.",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtServiceName.Focus()
            Return False

        End If

        If cmbPricingType.SelectedIndex < 0 Then

            MessageBox.Show(
                "Silakan pilih jenis perhitungan.",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            cmbPricingType.Focus()
            Return False

        End If

        If cmbIsActive.SelectedIndex < 0 Then

            MessageBox.Show(
                "Silakan pilih status layanan.",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            cmbIsActive.Focus()
            Return False

        End If

        If numEstimatedDays.Value < 1 Then

            MessageBox.Show(
                "Estimasi pengerjaan minimal 1 hari.",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return False

        End If

        Return True

    End Function

    ' ==========================================
    ' 6. PARAMETER DATABASE
    ' ==========================================
    Private Sub AddServiceParameters(cmd As MySqlCommand)

        cmd.Parameters.AddWithValue(
            "@name", txtServiceName.Text.Trim())

        cmd.Parameters.AddWithValue(
            "@type", cmbPricingType.Text)

        cmd.Parameters.AddWithValue(
            "@price", numUnitPrice.Value)

        cmd.Parameters.AddWithValue(
            "@days", Convert.ToInt32(numEstimatedDays.Value))

        cmd.Parameters.AddWithValue(
            "@express", numExpressFee.Value)

        cmd.Parameters.AddWithValue(
            "@active", If(cmbIsActive.Text = "Aktif", 1, 0))

    End Sub

    ' ==========================================
    ' 7. TOMBOL SIMPAN
    ' ==========================================
    Private Sub btnSaveService_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSaveService.Click

        If selectedServiceId <> 0 Then

            MessageBox.Show(
                "Silakan klik Reset sebelum menambahkan layanan baru.",
                "Informasi")

            Return

        End If

        ' Validasi hanya berjalan saat tombol Simpan ditekan
        If Not ValidateInput() Then Return

        Try

            Dim idFinal As Long

            Using conn As MySqlConnection = DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "INSERT INTO services " &
                    "(service_name, pricing_type, unit_price, " &
                    "estimated_days, express_fee, is_active) " &
                    "VALUES " &
                    "(@name, @type, @price, @days, @express, @active)"

                Using cmd As New MySqlCommand(sql, conn)

                    AddServiceParameters(cmd)

                    cmd.ExecuteNonQuery()

                    idFinal = cmd.LastInsertedId

                End Using

            End Using

            MessageBox.Show(
                "Layanan berhasil disimpan dengan ID SRV-" &
                idFinal.ToString("D3"),
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            LoadServices()
            ResetService()

        Catch ex As Exception

            MessageBox.Show(
                "Gagal menyimpan layanan: " & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    ' ==========================================
    ' 8. TOMBOL UBAH
    ' ==========================================
    Private Sub btnUpdateService_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnUpdateService.Click

        If selectedServiceId = 0 Then

            MessageBox.Show(
                "Pilih layanan dari tabel terlebih dahulu.",
                "Peringatan")

            Return

        End If

        If Not ValidateInput() Then Return

        Try

            Using conn As MySqlConnection = DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "UPDATE services SET " &
                    "service_name=@name, " &
                    "pricing_type=@type, " &
                    "unit_price=@price, " &
                    "estimated_days=@days, " &
                    "express_fee=@express, " &
                    "is_active=@active " &
                    "WHERE service_id=@id"

                Using cmd As New MySqlCommand(sql, conn)

                    AddServiceParameters(cmd)

                    cmd.Parameters.AddWithValue("@id", selectedServiceId)

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Data layanan berhasil diperbarui.",
                "Berhasil")

            LoadServices()
            ResetService()

        Catch ex As Exception

            MessageBox.Show(
                "Gagal mengubah layanan: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub

    ' ==========================================
    ' 9. TOMBOL HAPUS
    ' ==========================================
    Private Sub btnDeleteService_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDeleteService.Click

        If selectedServiceId = 0 Then

            MessageBox.Show(
                "Pilih layanan yang akan dihapus.",
                "Peringatan")

            Return

        End If

        If MessageBox.Show(
            "Apakah kamu yakin ingin menghapus layanan ini?",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) <> DialogResult.Yes Then

            Return

        End If

        Try

            Using conn As MySqlConnection = DbDelica.GetConnection()

                conn.Open()

                Using cmd As New MySqlCommand(
                    "DELETE FROM services WHERE service_id=@id", conn)

                    cmd.Parameters.AddWithValue("@id", selectedServiceId)

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Layanan berhasil dihapus.",
                "Berhasil")

            LoadServices()
            ResetService()

        Catch ex As MySqlException When ex.Number = 1451

            MessageBox.Show(
                "Layanan tidak dapat dihapus karena sudah digunakan " &
                "dalam transaksi. Silakan ubah status menjadi Tidak Aktif.",
                "Peringatan")

        Catch ex As Exception

            MessageBox.Show(
                "Gagal menghapus layanan: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub

    ' ==========================================
    ' 10. RESET FORM
    ' ==========================================
    Private Sub btnResetService_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnResetService.Click

        ResetService()

    End Sub

    Private Sub ResetService()

        selectedServiceId = 0

        ' Kosongkan input nama
        txtServiceName.Clear()

        ' Reset pilihan
        cmbPricingType.SelectedIndex = -1
        cmbIsActive.SelectedItem = "Aktif"

        ' Reset angka
        numUnitPrice.Value = 0
        numEstimatedDays.Value = 1
        numExpressFee.Value = 0

        ' Atur tombol
        btnSaveService.Enabled = True
        btnUpdateService.Enabled = False
        btnDeleteService.Enabled = False

        ' Hapus pilihan tabel
        Guna2DataGridView1.ClearSelection()

        ' Tampilkan ID berikutnya
        TampilkanIdPerkiraan()

        txtServiceName.Focus()

    End Sub

    ' ==========================================
    ' 11. PENCARIAN LAYANAN
    ' ==========================================
    Private Sub btnSearchService_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearchService.Click

        LoadServices(txtSearchService.Text)

    End Sub

    Private Sub txtSearchService_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchService.TextChanged

        LoadServices(txtSearchService.Text)

    End Sub

    ' ==========================================
    ' 12. PILIH DATA DARI TABEL
    ' ==========================================
    Private Sub Guna2DataGridView1_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles Guna2DataGridView1.CellClick

        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow =
            Guna2DataGridView1.Rows(e.RowIndex)

        selectedServiceId =
            Convert.ToInt32(row.Cells("ID").Value)

        txtServiceID.Text =
            "SRV-" & selectedServiceId.ToString("D3")

        txtServiceName.Text =
            Convert.ToString(row.Cells("Nama Layanan").Value)

        cmbPricingType.Text =
            Convert.ToString(row.Cells("Jenis").Value)

        numUnitPrice.Value =
            Convert.ToDecimal(row.Cells("Harga").Value)

        numEstimatedDays.Value =
            Convert.ToDecimal(row.Cells("Estimasi (Hari)").Value)

        numExpressFee.Value =
            Convert.ToDecimal(row.Cells("Biaya Express").Value)

        cmbIsActive.Text =
            Convert.ToString(row.Cells("Status").Value)

        btnSaveService.Enabled = False
        btnUpdateService.Enabled = True
        btnDeleteService.Enabled = True

    End Sub

    ' ==========================================
    ' 13. NAVIGASI SIDEBAR
    ' ==========================================
    Private Sub btnMasterCustomer_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnMasterCustomer.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
        FrmCustomer.Show()
        Me.Hide()

    End Sub

    Private Sub btnMasterUser_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnMasterUser.Click

        If Sesi.UserRole <> "Owner" Then Return

        FrmUser.Show()
        Me.Hide()

    End Sub

    ' Navigasi Pembayaran
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        FrmPayment.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        FrmOrder.Show()
        Me.Hide()
    End Sub

    Private Sub btnMasterService_Click(sender As Object, e As EventArgs) Handles btnMasterService.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
    End Sub
End Class
