
Imports MySqlConnector
Imports System.Data
Imports System.Globalization

Public Class FrmOrder

    Private detailTable As DataTable

    ' ==========================================
    ' FORM LOAD
    ' ==========================================

    Private Sub FrmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            SetupDetailTable()
            SetupForm()

            LoadCustomers()
            LoadPetugas()
            LoadServices()

            ResetOrder()

        Catch ex As Exception
            TampilkanError("Gagal membuka Form Transaksi Pesanan", ex)
        End Try

    End Sub

    ' ==========================================
    ' PENGATURAN DATAGRIDVIEW
    ' ==========================================

    Private Sub SetupDetailTable()

        detailTable = New DataTable()

        detailTable.Columns.Add("service_id", GetType(Integer))
        detailTable.Columns.Add("Nama Layanan", GetType(String))
        detailTable.Columns.Add("Jenis Perhitungan", GetType(String))
        detailTable.Columns.Add("Qty", GetType(Decimal))
        detailTable.Columns.Add("Harga Satuan", GetType(Decimal))
        detailTable.Columns.Add("Subtotal", GetType(Decimal))
        detailTable.Columns.Add("ExpressFee", GetType(Decimal))

        dgvOrderDetail.DataSource = Nothing
        dgvOrderDetail.Columns.Clear()
        dgvOrderDetail.AutoGenerateColumns = True
        dgvOrderDetail.DataSource = detailTable

        dgvOrderDetail.ReadOnly = True
        dgvOrderDetail.AllowUserToAddRows = False
        dgvOrderDetail.AllowUserToDeleteRows = False
        dgvOrderDetail.MultiSelect = False

        dgvOrderDetail.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvOrderDetail.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvOrderDetail.RowHeadersVisible = False

        dgvOrderDetail.Columns("service_id").Visible = False
        dgvOrderDetail.Columns("ExpressFee").Visible = False

        dgvOrderDetail.Columns("Nama Layanan").HeaderText =
            "Nama Layanan"

        dgvOrderDetail.Columns("Jenis Perhitungan").HeaderText =
            "Jenis"

        dgvOrderDetail.Columns("Qty").HeaderText =
            "Berat/Jumlah"

        dgvOrderDetail.Columns("Harga Satuan").HeaderText =
            "Harga"

        dgvOrderDetail.Columns("Subtotal").HeaderText =
            "Subtotal"

        dgvOrderDetail.Columns("Qty").DefaultCellStyle.Format = "N2"
        dgvOrderDetail.Columns("Harga Satuan").DefaultCellStyle.Format = "N0"
        dgvOrderDetail.Columns("Subtotal").DefaultCellStyle.Format = "N0"

    End Sub

    ' ==========================================
    ' PENGATURAN KOMPONEN FORM
    ' ==========================================

    Private Sub SetupForm()

        txtOrderNo.ReadOnly = True
        txtPricingType.ReadOnly = True
        txtUnitPrice.ReadOnly = True
        txtSubtotal.ReadOnly = True

        cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStaff.DropDownStyle = ComboBoxStyle.DropDownList
        cmbService.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList

        cmbOrderStatus.Items.Clear()

        cmbOrderStatus.Items.Add("Diterima")
        cmbOrderStatus.Items.Add("Diproses")
        cmbOrderStatus.Items.Add("Siap Diambil")
        cmbOrderStatus.Items.Add("Dalam Pengantaran")
        cmbOrderStatus.Items.Add("Selesai")
        cmbOrderStatus.Items.Add("Dibatalkan")

        nudQuantity.Minimum = 0.01D
        nudQuantity.Maximum = 100000D
        nudQuantity.DecimalPlaces = 2
        nudQuantity.Increment = 0.5D
        nudQuantity.Value = 1D

        numTransportFee.Minimum = 0D
        numTransportFee.Maximum = 100000000D
        numTransportFee.DecimalPlaces = 0
        numTransportFee.Value = 0D

    End Sub

    ' ==========================================
    ' MENGAMBIL DATA PELANGGAN
    ' ==========================================

    Private Sub LoadCustomers()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim sql As String =
                "SELECT customer_id, customer_name " &
                "FROM customers ORDER BY customer_name"

            Using cmd As New MySqlCommand(sql, conn)

                Using da As New MySqlDataAdapter(cmd)

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    cmbCustomer.DataSource = dt
                    cmbCustomer.DisplayMember = "customer_name"
                    cmbCustomer.ValueMember = "customer_id"
                    cmbCustomer.SelectedIndex = -1

                End Using

            End Using

        End Using

    End Sub

    ' ==========================================
    ' MENGAMBIL DATA PETUGAS
    ' ==========================================

    Private Sub LoadPetugas()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim sql As String =
                "SELECT user_id, full_name " &
                "FROM users " &
                "WHERE role IN ('Owner','Staff Laundry') " &
                "AND is_active = 1 " &
                "ORDER BY full_name"

            Using cmd As New MySqlCommand(sql, conn)

                Using da As New MySqlDataAdapter(cmd)

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    cmbStaff.DataSource = dt
                    cmbStaff.DisplayMember = "full_name"
                    cmbStaff.ValueMember = "user_id"
                    cmbStaff.SelectedIndex = -1

                End Using

            End Using

        End Using

    End Sub

    ' ==========================================
    ' MENGAMBIL DATA LAYANAN
    ' ==========================================


    Private Sub LoadServices()

        Try
            Using conn As MySqlConnection = DbDelica.GetConnection()
                conn.Open()

                Dim sql As String =
                "SELECT service_id, service_name, pricing_type, " &
                "unit_price, estimated_days, express_fee " &
                "FROM services WHERE is_active = 1"

                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        cmbService.DataSource = Nothing
                        cmbService.Items.Clear()

                        cmbService.DisplayMember = "service_name"
                        cmbService.ValueMember = "service_id"
                        cmbService.DataSource = dt
                        cmbService.SelectedIndex = -1

                        If dt.Rows.Count = 0 Then
                            MessageBox.Show(
                            "Data layanan tidak ditemukan atau tidak aktif.",
                            "Informasi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        )
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
            "Gagal memuat layanan: " & ex.Message,
            "Kesalahan",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
        End Try

    End Sub


    ' ==========================================
    ' MEMILIH LAYANAN
    ' ==========================================

    Private Sub cmbService_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbService.SelectedIndexChanged
        If cmbService.SelectedIndex < 0 Then Return

        Dim row As DataRowView =
            TryCast(cmbService.SelectedItem, DataRowView)

        If row Is Nothing Then Return

        txtPricingType.Text =
            row("pricing_type").ToString()

        txtUnitPrice.Text =
            Convert.ToDecimal(row("unit_price")).ToString("N0")

        HitungSubtotal()

    End Sub

    ' ==========================================
    ' MENGHITUNG SUBTOTAL
    ' ==========================================

    Private Sub HitungSubtotal()

        If cmbService.SelectedIndex < 0 Then Return

        Dim row As DataRowView =
            TryCast(cmbService.SelectedItem, DataRowView)

        If row Is Nothing Then Return

        Dim harga As Decimal =
            Convert.ToDecimal(row("unit_price"))

        Dim jumlah As Decimal = nudQuantity.Value

        Dim subtotal As Decimal = harga * jumlah

        txtSubtotal.Text = subtotal.ToString("N0")

    End Sub

    Private Sub nudQuantity_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles nudQuantity.ValueChanged

        HitungSubtotal()

    End Sub

    ' ==========================================
    ' TAMBAH LAYANAN KE DATAGRIDVIEW
    ' ==========================================

    Private Sub btnTambahLayanan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAddService.Click

        If cmbService.SelectedIndex < 0 Then

            MessageBox.Show("Silakan pilih layanan terlebih dahulu.")
            cmbService.Focus()
            Return

        End If

        Dim row As DataRowView =
            TryCast(cmbService.SelectedItem, DataRowView)

        If row Is Nothing Then Return

        Dim serviceId As Integer =
            Convert.ToInt32(row("service_id"))

        Dim serviceName As String =
            row("service_name").ToString()

        Dim jenis As String =
            row("pricing_type").ToString()

        Dim harga As Decimal =
            Convert.ToDecimal(row("unit_price"))

        Dim expressFee As Decimal = 0D

        If Not IsDBNull(row("express_fee")) Then
            expressFee = Convert.ToDecimal(row("express_fee"))
        End If

        Dim jumlah As Decimal = nudQuantity.Value

        If jenis = "ITEM" AndAlso jumlah <> Decimal.Truncate(jumlah) Then

            MessageBox.Show(
                "Jumlah layanan per item harus berupa bilangan bulat.")

            nudQuantity.Focus()
            Return

        End If

        Dim subtotal As Decimal = harga * jumlah

        detailTable.Rows.Add(
            serviceId,
            serviceName,
            jenis,
            jumlah,
            harga,
            subtotal,
            expressFee
        )

        HitungGrandTotal()

        cmbService.SelectedIndex = -1

        txtPricingType.Clear()
        txtUnitPrice.Clear()
        txtSubtotal.Clear()

        nudQuantity.Value = 1D

    End Sub

    ' ==========================================
    ' MENGHITUNG GRAND TOTAL
    ' ==========================================

    Private Sub HitungGrandTotal()

        If detailTable Is Nothing Then Return

        Dim totalSubtotal As Decimal = 0D
        Dim totalExpress As Decimal = 0D

        For Each row As DataRow In detailTable.Rows

            totalSubtotal +=
                Convert.ToDecimal(row("Subtotal"))

            If chkExpress.Checked Then

                totalExpress +=
                    Convert.ToDecimal(row("ExpressFee"))

            End If

        Next

        Dim biayaAntarJemput As Decimal =
            numTransportFee.Value

        Dim grandTotal As Decimal =
            totalSubtotal + totalExpress + biayaAntarJemput

        lblGrandTotal.Text =
            grandTotal.ToString("C0", New CultureInfo("id-ID"))

    End Sub

    Private Sub chkExpress_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkExpress.CheckedChanged

        HitungGrandTotal()

    End Sub

    Private Sub numTransportFee_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles numTransportFee.ValueChanged

        HitungGrandTotal()

    End Sub

    ' ==========================================
    ' MEMBUAT NOMOR PESANAN OTOMATIS
    ' ==========================================

    Private Sub BuatNomorPesanan()

        txtOrderNo.Text =
            "ORD-" & DateTime.Now.ToString("yyyyMMddHHmmssfff")

    End Sub

    ' ==========================================
    ' SIMPAN TRANSAKSI PESANAN
    ' ==========================================

    Private Sub btnSimpan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSaveOrder.Click

        ' VALIDASI PELANGGAN

        If cmbCustomer.SelectedIndex < 0 Then

            MessageBox.Show("Pilih pelanggan terlebih dahulu.")
            cmbCustomer.Focus()
            Return

        End If

        ' VALIDASI PETUGAS

        If cmbStaff.SelectedIndex < 0 Then

            MessageBox.Show("Pilih staff terlebih dahulu.")
            cmbStaff.Focus()
            Return

        End If

        ' VALIDASI STATUS

        If cmbOrderStatus.SelectedIndex < 0 Then

            MessageBox.Show("Pilih status pesanan.")
            cmbOrderStatus.Focus()
            Return

        End If

        ' VALIDASI DETAIL LAYANAN

        If detailTable.Rows.Count = 0 Then

            MessageBox.Show("Tambahkan minimal satu layanan.")
            Return

        End If

        Try

            ' MENGHITUNG TOTAL TRANSAKSI

            Dim totalSubtotal As Decimal = 0D
            Dim totalExpress As Decimal = 0D
            Dim totalKg As Decimal = 0D
            Dim totalItem As Decimal = 0D

            For Each row As DataRow In detailTable.Rows

                Dim qty As Decimal =
                    Convert.ToDecimal(row("Qty"))

                totalSubtotal +=
                    Convert.ToDecimal(row("Subtotal"))

                If row("Jenis Perhitungan").ToString() = "KG" Then

                    totalKg += qty

                ElseIf row("Jenis Perhitungan").ToString() = "ITEM" Then

                    totalItem += qty

                End If

                If chkExpress.Checked Then

                    totalExpress +=
                        Convert.ToDecimal(row("ExpressFee"))

                End If

            Next

            Dim transportFee As Decimal =
                numTransportFee.Value

            Dim grandTotal As Decimal =
                totalSubtotal + totalExpress + transportFee

            ' LAYANAN UTAMA UNTUK TABEL ORDERS

            Dim firstRow As DataRow = detailTable.Rows(0)

            Dim primaryServiceId As Integer =
                Convert.ToInt32(firstRow("service_id"))

            Dim primaryUnitPrice As Decimal =
                Convert.ToDecimal(firstRow("Harga Satuan"))

            ' KONEKSI DATABASE

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Using trans As MySqlTransaction = conn.BeginTransaction()

                    Try

                        ' ==================================
                        ' SIMPAN DATA UTAMA PESANAN
                        ' ==================================

                        Dim sqlOrder As String =
                            "INSERT INTO orders " &
                            "(order_no, customer_id, service_id, created_by, " &
                            "order_date, weight_kg, item_qty, " &
                            "unit_price_snapshot, subtotal, is_express, " &
                            "express_fee, transport_fee, final_total, order_status) " &
                            "VALUES " &
                            "(@orderNo, @customer, @service, @staff, " &
                            "@orderDate, @weight, @itemQty, " &
                            "@unitPrice, @subtotal, @express, " &
                            "@expressFee, @transportFee, @grandTotal, @status)"

                        Dim orderId As Long

                        Using cmd As New MySqlCommand(
                            sqlOrder, conn, trans)

                            cmd.Parameters.Add(
                                "@orderNo",
                                MySqlDbType.VarChar, 40
                            ).Value = txtOrderNo.Text

                            cmd.Parameters.Add(
                                "@customer",
                                MySqlDbType.Int32
                            ).Value =
                                Convert.ToInt32(cmbCustomer.SelectedValue)

                            cmd.Parameters.Add(
                                "@service",
                                MySqlDbType.Int32
                            ).Value = primaryServiceId

                            cmd.Parameters.Add(
                                "@staff",
                                MySqlDbType.Int32
                            ).Value =
                                Convert.ToInt32(cmbStaff.SelectedValue)

                            cmd.Parameters.Add(
                                "@orderDate",
                                MySqlDbType.DateTime
                            ).Value = dtpOrderDate.Value

                            If totalKg > 0D Then

                                cmd.Parameters.Add(
                                    "@weight",
                                    MySqlDbType.Decimal
                                ).Value = totalKg

                            Else

                                cmd.Parameters.Add(
                                    "@weight",
                                    MySqlDbType.Decimal
                                ).Value = DBNull.Value

                            End If

                            If totalItem > 0D Then

                                cmd.Parameters.Add(
                                    "@itemQty",
                                    MySqlDbType.Int32
                                ).Value = Convert.ToInt32(totalItem)

                            Else

                                cmd.Parameters.Add(
                                    "@itemQty",
                                    MySqlDbType.Int32
                                ).Value = DBNull.Value

                            End If

                            cmd.Parameters.Add(
                                "@unitPrice",
                                MySqlDbType.Decimal
                            ).Value = primaryUnitPrice

                            cmd.Parameters.Add(
                                "@subtotal",
                                MySqlDbType.Decimal
                            ).Value = totalSubtotal

                            cmd.Parameters.Add(
                                "@express",
                                MySqlDbType.Bit
                            ).Value = chkExpress.Checked

                            cmd.Parameters.Add(
                                "@expressFee",
                                MySqlDbType.Decimal
                            ).Value = totalExpress

                            cmd.Parameters.Add(
                                "@transportFee",
                                MySqlDbType.Decimal
                            ).Value = transportFee

                            cmd.Parameters.Add(
                                "@grandTotal",
                                MySqlDbType.Decimal
                            ).Value = grandTotal

                            cmd.Parameters.Add(
                                "@status",
                                MySqlDbType.VarChar, 30
                            ).Value = cmbOrderStatus.Text

                            cmd.ExecuteNonQuery()

                            orderId = cmd.LastInsertedId

                        End Using

                        ' ==================================
                        ' SIMPAN DETAIL LAYANAN
                        ' ==================================

                        Dim sqlDetail As String =
                            "INSERT INTO order_details " &
                            "(order_id, service_id, service_name_snapshot, " &
                            "pricing_type_snapshot, quantity, unit_price, subtotal) " &
                            "VALUES " &
                            "(@orderId, @serviceId, @serviceName, " &
                            "@pricingType, @quantity, @price, @subtotal)"

                        For Each row As DataRow In detailTable.Rows

                            Using cmdDetail As New MySqlCommand(
                                sqlDetail, conn, trans)

                                cmdDetail.Parameters.Add(
                                    "@orderId",
                                    MySqlDbType.Int64
                                ).Value = orderId

                                cmdDetail.Parameters.Add(
                                    "@serviceId",
                                    MySqlDbType.Int32
                                ).Value =
                                    Convert.ToInt32(row("service_id"))

                                cmdDetail.Parameters.Add(
                                    "@serviceName",
                                    MySqlDbType.VarChar, 100
                                ).Value =
                                    row("Nama Layanan").ToString()

                                cmdDetail.Parameters.Add(
                                    "@pricingType",
                                    MySqlDbType.VarChar, 10
                                ).Value =
                                    row("Jenis Perhitungan").ToString()

                                cmdDetail.Parameters.Add(
                                    "@quantity",
                                    MySqlDbType.Decimal
                                ).Value =
                                    Convert.ToDecimal(row("Qty"))

                                cmdDetail.Parameters.Add(
                                    "@price",
                                    MySqlDbType.Decimal
                                ).Value =
                                    Convert.ToDecimal(row("Harga Satuan"))

                                cmdDetail.Parameters.Add(
                                    "@subtotal",
                                    MySqlDbType.Decimal
                                ).Value =
                                    Convert.ToDecimal(row("Subtotal"))

                                cmdDetail.ExecuteNonQuery()

                            End Using

                        Next

                        ' ==================================
                        ' SIMPAN TRANSAKSI
                        ' ==================================

                        trans.Commit()

                        MessageBox.Show(
                            "Pesanan berhasil disimpan!" &
                            vbCrLf &
                            "Nomor Pesanan: " & txtOrderNo.Text &
                            vbCrLf &
                            "Grand Total: " &
                            grandTotal.ToString(
                                "C0",
                                New CultureInfo("id-ID")
                            ),
                            "Berhasil",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        )

                    Catch

                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using

            ResetOrder()

        Catch ex As MySqlException When ex.Number = 1062

            MessageBox.Show(
                "Nomor pesanan sudah digunakan. Silakan buat pesanan baru.",
                "Data Duplikat",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        Catch ex As Exception

            TampilkanError("Gagal menyimpan transaksi pesanan", ex)

        End Try

    End Sub

    ' ==========================================
    ' RESET FORM
    ' ==========================================

    Private Sub btnReset_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClearService.Click

        ResetOrder()

    End Sub

    Private Sub ResetOrder()

        BuatNomorPesanan()

        dtpOrderDate.Value = DateTime.Now

        cmbCustomer.SelectedIndex = -1
        cmbService.SelectedIndex = -1
        cmbOrderStatus.SelectedItem = "Diterima"
        cmbStaff.SelectedIndex = -1

        ' Mengatur staff sesuai akun yang login

        Try
            cmbStaff.SelectedValue = Sesi.UserID
        Catch
        End Try

        txtPricingType.Clear()
        txtUnitPrice.Clear()
        txtSubtotal.Clear()

        nudQuantity.Value = 1D
        numTransportFee.Value = 0D

        chkExpress.Checked = False

        detailTable.Rows.Clear()

        lblGrandTotal.Text =
            0D.ToString("C0", New CultureInfo("id-ID"))

        dgvOrderDetail.ClearSelection()

    End Sub

    ' ==========================================
    ' MENAMPILKAN PESAN ERROR
    ' ==========================================

    Private Sub TampilkanError(
        kegiatan As String,
        ex As Exception
    )

        MessageBox.Show(
            kegiatan & ":" & vbCrLf & ex.Message,
            "Kesalahan",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Sub

    Private Sub btnMasterCustomer_Click(sender As Object, e As EventArgs) Handles btnMasterCustomer.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
        FrmCustomer.Show()
        Me.Hide()
    End Sub

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

    Private Sub Guna2Button6_Click(snder As Object, e As EventArgs) Handles Guna2Button6.Click
        FrmPayment.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
    End Sub


End Class
