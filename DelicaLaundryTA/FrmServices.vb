Imports MySqlConnector
Imports System.Data

Public Class FrmServices

    Private selectedServiceId As Integer = 0

    Private Sub FrmServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvService.Columns.Clear()
        dgvService.AutoGenerateColumns = True
        dgvService.ReadOnly = True
        dgvService.AllowUserToAddRows = False
        dgvService.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        txtServiceID.ReadOnly = True
        txtServiceID.TabStop = False
        LoadServiceNames()

        numUnitPrice.Minimum = 0D
        numUnitPrice.Maximum = 1000000000D
        numUnitPrice.ThousandsSeparator = True
        numEstimatedDays.Minimum = 1D
        numEstimatedDays.Maximum = 365D
        numExpressFee.Minimum = 0D
        numExpressFee.Maximum = 1000000000D
        numExpressFee.ThousandsSeparator = True

        cmbPricingType.Items.Clear()
        cmbPricingType.Items.Add("KG")
        cmbPricingType.Items.Add("ITEM")
        ' Jika tabel services.pricing_type sudah ditambah METER, buka komentar baris berikut:
        ' cmbPricingType.Items.Add("METER")
        cmbIsActive.Items.Clear()
        cmbIsActive.Items.Add("Aktif")
        cmbIsActive.Items.Add("Tidak Aktif")
        LoadServices()
        ApplyRoleAccess()
        ResetService()
    End Sub

    ' Pilihan awal nama layanan. ComboBox dapat ditambah sesuai rancangan.
    Private Sub LoadServiceNames()
        cmbServiceName.Items.Clear()
        cmbServiceName.Items.AddRange(New Object() {
            "Cuci Kering", "Cuci Setrika", "Cuci Komplit",
            "Setrika Saja", "Cuci Bed Cover", "Cuci Karpet"
        })
        cmbServiceName.SelectedIndex = -1
    End Sub

    ' Pratinjau nomor berikutnya sesuai penghitung AUTO_INCREMENT MySQL.
    ' Hanya perkiraan: nomor final baru pasti setelah INSERT berhasil.
    Private Function GetPreviewServiceId() As String
        Using conn As MySqlConnection = GetConnection()
            conn.Open()
            Const sql As String =
                "SELECT AUTO_INCREMENT FROM information_schema.TABLES " &
                "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'services'"
            Using cmd As New MySqlCommand(sql, conn)
                Dim obj As Object = cmd.ExecuteScalar()
                If obj Is Nothing OrElse obj Is DBNull.Value Then
                    Throw New InvalidOperationException(
                        "Nomor AUTO_INCREMENT tabel services tidak ditemukan.")
                End If
                Dim n As Long = Convert.ToInt64(obj)
                Return "SRV-" & n.ToString("D3")
            End Using
        End Using
    End Function

    Private Sub TampilkanIdPerkiraan()
        Try
            txtServiceID.Text = GetPreviewServiceId()
        Catch ex As Exception
            txtServiceID.Text = ""
            MessageBox.Show("Gagal membaca nomor berikutnya: " & ex.Message)
        End Try
    End Sub

    Private Sub ApplyRoleAccess()
        btnMasterUser.Visible = (Sesi.UserRole = "Owner")
    End Sub

    Private Sub LoadServices(Optional keyword As String = "")
        Try
            Using conn = GetConnection()
                conn.Open()
                Dim sql As String =
                    "SELECT service_id AS ID, " &
                    "CONCAT('SRV-',LPAD(service_id,3,'0')) AS `ID Layanan`, " &
                    "service_name AS `Nama Layanan`, pricing_type AS `Jenis`, " &
                    "unit_price AS `Harga`, estimated_days AS `Estimasi (Hari)`, " &
                    "express_fee AS `Biaya Express`, " &
                    "IF(is_active=1,'Aktif','Tidak Aktif') AS `Status` " &
                    "FROM services " &
                    "WHERE service_name LIKE @q OR CAST(service_id AS CHAR) LIKE @q " &
                    "ORDER BY service_id"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@q", "%" & keyword.Trim() & "%")
                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvService.DataSource = dt
                        If dgvService.Columns.Contains("ID") Then
                            dgvService.Columns("ID").Visible = False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat layanan: " & ex.Message)
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        Dim harga, express As Decimal
        Dim hari As Integer
        If cmbServiceName.Text.Trim() = "" OrElse cmbPricingType.SelectedIndex < 0 OrElse
           Not Decimal.TryParse(numUnitPrice.Text, harga) OrElse
           Not Integer.TryParse(numEstimatedDays.Text, hari) OrElse
           Not Decimal.TryParse(numExpressFee.Text, express) OrElse
           cmbIsActive.SelectedIndex < 0 Then
            MessageBox.Show("Lengkapi nama, jenis, harga, estimasi, biaya express, dan status.")
            Return False
        End If
        If harga < 0 OrElse express < 0 OrElse hari < 1 Then
            MessageBox.Show("Harga/biaya tidak boleh negatif dan estimasi minimal 1 hari.")
            Return False
        End If
        Return True
    End Function

    Private Sub btnSaveService_Click(sender As Object, e As EventArgs) Handles btnSaveService.Click
        If selectedServiceId <> 0 Then
            MessageBox.Show("Sedang memilih data lama. Klik Ubah atau Reset terlebih dahulu.")
            Return
        End If
        If Not ValidateInput() Then Return
        Try
            Using conn = GetConnection()
                conn.Open()
                Dim sql = "INSERT INTO services(service_name,pricing_type,unit_price,estimated_days,express_fee,is_active) " &
                          "VALUES(@name,@type,@price,@days,@express,@active)"
                Dim idFinal As Long
                Using cmd As New MySqlCommand(sql, conn)
                    AddServiceParameters(cmd)
                    cmd.ExecuteNonQuery()
                    idFinal = cmd.LastInsertedId
                End Using
                MessageBox.Show("Layanan berhasil disimpan dengan ID SRV-" &
                                idFinal.ToString("D3"), "Berhasil")
            End Using
            LoadServices()
            ResetService()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan layanan: " & ex.Message)
        End Try
    End Sub

    Private Sub AddServiceParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@name", cmbServiceName.Text.Trim())
        cmd.Parameters.AddWithValue("@type", cmbPricingType.Text)
        cmd.Parameters.AddWithValue("@price", Decimal.Parse(numUnitPrice.Text))
        cmd.Parameters.AddWithValue("@days", Integer.Parse(numEstimatedDays.Text))
        cmd.Parameters.AddWithValue("@express", Decimal.Parse(numExpressFee.Text))
        cmd.Parameters.AddWithValue("@active", If(cmbIsActive.Text = "Aktif", 1, 0))
    End Sub

    Private Sub btnUpdateService_Click(sender As Object, e As EventArgs) Handles btnUpdateService.Click
        If selectedServiceId = 0 Then
            MessageBox.Show("Pilih layanan dari tabel terlebih dahulu.")
            Return
        End If
        If Not ValidateInput() Then Return
        Try
            Using conn = GetConnection()
                conn.Open()
                Dim sql = "UPDATE services SET service_name=@name,pricing_type=@type,unit_price=@price," &
                          "estimated_days=@days,express_fee=@express,is_active=@active WHERE service_id=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    AddServiceParameters(cmd)
                    cmd.Parameters.AddWithValue("@id", selectedServiceId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Layanan berhasil diperbarui.")
            ResetService()
            LoadServices()
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah layanan: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteService_Click(sender As Object, e As EventArgs) Handles btnDeleteService.Click
        If selectedServiceId = 0 Then
            MessageBox.Show("Pilih layanan yang akan dihapus.")
            Return
        End If
        If MessageBox.Show("Hapus layanan terpilih?", "Konfirmasi", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using conn = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM services WHERE service_id=@id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedServiceId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Layanan berhasil dihapus.")
            ResetService()
            LoadServices()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Layanan tidak dapat dihapus karena sudah digunakan pada transaksi. Ubah status menjadi Tidak Aktif.")
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus layanan: " & ex.Message)
        End Try
    End Sub

    Private Sub btnResetService_Click(sender As Object, e As EventArgs) Handles btnResetService.Click
        ResetService()
    End Sub

    Private Sub ResetService()
        selectedServiceId = 0
        txtServiceID.Clear()
        cmbServiceName.SelectedIndex = -1
        cmbServiceName.Text = ""
        cmbPricingType.SelectedIndex = -1
        numUnitPrice.Value = 0
        numEstimatedDays.Value = 1
        numExpressFee.Value = 0
        cmbIsActive.SelectedItem = "Aktif"
        btnSaveService.Enabled = True
        btnUpdateService.Enabled = False
        btnDeleteService.Enabled = False
        dgvService.ClearSelection()
        TampilkanIdPerkiraan()
        cmbServiceName.Focus()
    End Sub

    Private Sub btnSearchService_Click(sender As Object, e As EventArgs) Handles btnSearchService.Click
        LoadServices(txtSearchService.Text)
    End Sub

    Private Sub txtSearchService_TextChanged(sender As Object, e As EventArgs) Handles txtSearchService.TextChanged
        LoadServices(txtSearchService.Text)
    End Sub

    Private Sub dgvService_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvService.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvService.Rows(e.RowIndex)
        selectedServiceId = Convert.ToInt32(row.Cells("ID").Value)
        txtServiceID.Text = "SRV-" & selectedServiceId.ToString("000")
        cmbServiceName.Text = Convert.ToString(row.Cells("Nama Layanan").Value)
        cmbPricingType.Text = Convert.ToString(row.Cells("Jenis").Value)
        numUnitPrice.Value = Math.Max(numUnitPrice.Minimum,
                                   Math.Min(numUnitPrice.Maximum,
                                            Convert.ToDecimal(row.Cells("Harga").Value)))
        numEstimatedDays.Value = Convert.ToDecimal(row.Cells("Estimasi (Hari)").Value)
        numExpressFee.Value = Convert.ToDecimal(row.Cells("Biaya Express").Value)
        cmbIsActive.Text = Convert.ToString(row.Cells("Status").Value)
        btnSaveService.Enabled = False
        btnUpdateService.Enabled = True
        btnDeleteService.Enabled = True
    End Sub

    Private Sub btnMasterCustomer_Click(sender As Object, e As EventArgs) Handles btnMasterCustomer.Click
        FrmCustomer.Show()
        Me.Hide()
    End Sub

    Private Sub btnMasterUser_Click(sender As Object, e As EventArgs) Handles btnMasterUser.Click
        If Sesi.UserRole <> "Owner" Then Return
        FrmUser.Show()
        Me.Hide()
    End Sub
End Class