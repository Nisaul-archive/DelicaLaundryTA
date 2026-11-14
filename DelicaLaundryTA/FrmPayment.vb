Imports System.Data
Imports System.Globalization
Imports MySqlConnector

Public Class FrmPayment

    ' ==========================================
    ' VARIABEL FORM
    ' ==========================================

    Private selectedPaymentId As Integer = 0
    Private selectedOrderId As Long = 0

    Private selectedPaymentAmount As Decimal = 0D
    Private currentOrderTotal As Decimal = 0D
    Private currentOrderPaid As Decimal = 0D

    Private isLoading As Boolean = False

    Private ReadOnly idCulture As New CultureInfo("id-ID")


    ' ==========================================
    ' 1. FORM LOAD
    ' ==========================================

    Private Sub FrmPayment_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        isLoading = True

        ' Textbox hanya untuk menampilkan data
        txtPaymentID.ReadOnly = True
        txtCustomerName.ReadOnly = True
        txtGrandTotal.ReadOnly = True
        txtTotalPaid.ReadOnly = True

        ' Pengaturan nominal pembayaran
        numPaymentAmount.Minimum = 0D
        numPaymentAmount.Maximum = 1000000000D
        numPaymentAmount.DecimalPlaces = 0
        numPaymentAmount.ThousandsSeparator = True
        numPaymentAmount.Increment = 1000D

        ' Metode pembayaran
        cmbPaymentMethod.Items.Clear()
        cmbPaymentMethod.Items.Add("Cash")
        cmbPaymentMethod.Items.Add("Transfer")
        cmbPaymentMethod.Items.Add("QRIS")

        dtpPaymentDate.Value = DateTime.Today

        ' Pengaturan tabel
        dgvPayment.AutoGenerateColumns = True
        dgvPayment.ReadOnly = True
        dgvPayment.AllowUserToAddRows = False
        dgvPayment.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvPayment.MultiSelect = False

        dgvPayment.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        btnUpdateCustomer.Enabled = False
        btnDeleteCustomer.Enabled = False

        isLoading = False

        LoadOrders()
        LoadPayments()
        ResetPayment()

    End Sub


    ' ==========================================
    ' 2. FORMAT RUPIAH
    ' ==========================================

    Private Function FormatRupiah(
        nominal As Decimal
    ) As String

        Return nominal.ToString("C0", idCulture)

    End Function


    ' ==========================================
    ' 3. ID PEMBAYARAN OTOMATIS
    ' ==========================================

    Private Sub GeneratePaymentID()

        Try
            Using conn As MySqlConnection = DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "SELECT COALESCE(MAX(payment_id),0)+1 " &
                    "FROM payments"

                Using cmd As New MySqlCommand(sql, conn)

                    Dim nextID As Long =
                        Convert.ToInt64(cmd.ExecuteScalar())

                    txtPaymentID.Text =
                        "PAY-" & nextID.ToString("D3")

                End Using

            End Using

        Catch ex As Exception

            txtPaymentID.Clear()

            MessageBox.Show(
                "Gagal membuat ID pembayaran: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub


    ' ==========================================
    ' 4. LOAD NOMOR PESANAN
    ' ==========================================

    Private Sub LoadOrders()

        Try

            isLoading = True

            Using conn As MySqlConnection =
                DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "SELECT o.order_id, o.order_no " &
                    "FROM orders o " &
                    "WHERE o.order_status <> 'Dibatalkan' " &
                    "ORDER BY o.order_date DESC"

                Using da As New MySqlDataAdapter(sql, conn)

                    Dim dt As New DataTable()

                    da.Fill(dt)

                    cmbOrderNo.DataSource = Nothing

                    cmbOrderNo.DisplayMember = "order_no"
                    cmbOrderNo.ValueMember = "order_id"

                    cmbOrderNo.DataSource = dt
                    cmbOrderNo.SelectedIndex = -1

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Gagal memuat nomor pesanan: " & ex.Message,
                "Kesalahan")

        Finally

            isLoading = False

        End Try

    End Sub


    ' ==========================================
    ' 5. PILIH NOMOR PESANAN
    ' ==========================================

    Private Sub cmbOrderNo_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbOrderNo.SelectedIndexChanged

        If isLoading Then Return
        If cmbOrderNo.SelectedIndex < 0 Then Return

        Dim row As DataRowView =
            TryCast(cmbOrderNo.SelectedItem, DataRowView)

        If row Is Nothing Then Return

        selectedOrderId =
            Convert.ToInt64(row("order_id"))

        selectedPaymentAmount = 0D

        LoadOrderInformation(selectedOrderId)

        UpdatePaymentPreview()

    End Sub


    ' ==========================================
    ' 6. LOAD INFORMASI PESANAN
    ' ==========================================

    Private Sub LoadOrderInformation(orderID As Long)

        Try

            Using conn As MySqlConnection =
                DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "SELECT o.final_total, " &
                    "c.customer_name, " &
                    "COALESCE((" &
                    "SELECT SUM(p.amount) " &
                    "FROM payments p " &
                    "WHERE p.order_id=o.order_id" &
                    "),0) AS total_paid " &
                    "FROM orders o " &
                    "INNER JOIN customers c " &
                    "ON o.customer_id=c.customer_id " &
                    "WHERE o.order_id=@id"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@id", orderID)

                    Using dr As MySqlDataReader =
                        cmd.ExecuteReader()

                        If dr.Read() Then

                            currentOrderTotal =
                                Convert.ToDecimal(dr("final_total"))

                            currentOrderPaid =
                                Convert.ToDecimal(dr("total_paid"))

                            txtCustomerName.Text =
                                dr("customer_name").ToString()

                            txtGrandTotal.Text =
                                FormatRupiah(currentOrderTotal)

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Gagal memuat informasi pesanan: " &
                ex.Message,
                "Kesalahan")

        End Try

    End Sub


    ' ==========================================
    ' 7. HITUNG TOTAL DIBAYAR DAN STATUS
    ' ==========================================

    Private Sub UpdatePaymentPreview()

        If selectedOrderId <= 0 Then

            txtTotalPaid.Clear()
            lblPaymentStatusValue.Text = "Belum Dibayar"

            Return

        End If

        ' Mengurangi pembayaran yang sedang diedit
        Dim paidBefore As Decimal =
            currentOrderPaid - selectedPaymentAmount

        Dim projectedPaid As Decimal =
            paidBefore + numPaymentAmount.Value

        If projectedPaid < 0D Then
            projectedPaid = 0D
        End If

        txtTotalPaid.Text =
            FormatRupiah(projectedPaid)

        If projectedPaid <= 0D Then

            lblPaymentStatusValue.Text = "Belum Dibayar"

        ElseIf projectedPaid < currentOrderTotal Then

            lblPaymentStatusValue.Text = "Sebagian"

        Else

            lblPaymentStatusValue.Text = "Lunas"

        End If

    End Sub


    ' ==========================================
    ' 8. EVENT NOMINAL PEMBAYARAN
    ' ==========================================

    Private Sub numPaymentAmount_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles numPaymentAmount.ValueChanged

        If isLoading Then Return

        UpdatePaymentPreview()

    End Sub


    ' ==========================================
    ' 9. VALIDASI PEMBAYARAN
    ' ==========================================

    Private Function ValidatePayment() As Boolean

        If cmbOrderNo.SelectedIndex < 0 Then

            MessageBox.Show(
                "Silakan pilih nomor pesanan.",
                "Peringatan")

            cmbOrderNo.Focus()
            Return False

        End If

        If cmbPaymentMethod.SelectedIndex < 0 Then

            MessageBox.Show(
                "Silakan pilih metode pembayaran.",
                "Peringatan")

            cmbPaymentMethod.Focus()
            Return False

        End If

        If numPaymentAmount.Value <= 0D Then

            MessageBox.Show(
                "Nominal pembayaran harus lebih dari nol.",
                "Peringatan")

            numPaymentAmount.Focus()
            Return False

        End If

        If currentOrderTotal <= 0D Then

            MessageBox.Show(
                "Total tagihan tidak valid.",
                "Peringatan")

            Return False

        End If

        If Sesi.UserID <= 0 Then

            MessageBox.Show(
                "Sesi pengguna tidak ditemukan. Silakan login kembali.",
                "Peringatan")

            Return False

        End If

        Dim paidBefore As Decimal =
            currentOrderPaid - selectedPaymentAmount

        Dim remaining As Decimal =
            currentOrderTotal - paidBefore

        If numPaymentAmount.Value > remaining Then

            MessageBox.Show(
                "Nominal pembayaran melebihi sisa tagihan " &
                FormatRupiah(Math.Max(0D, remaining)),
                "Peringatan")

            numPaymentAmount.Focus()
            Return False

        End If

        Return True

    End Function


    ' ==========================================
    ' 10. VALIDASI SALDO DI DATABASE
    ' ==========================================

    Private Sub ValidateDatabaseBalance(
        conn As MySqlConnection,
        trans As MySqlTransaction,
        orderID As Long,
        amount As Decimal,
        Optional excludePaymentID As Integer = 0
    )

        Dim totalTagihan As Decimal
        Dim totalBayar As Decimal

        ' Mengunci baris pesanan selama transaksi
        Dim sqlOrder As String =
            "SELECT final_total FROM orders " &
            "WHERE order_id=@id FOR UPDATE"

        Using cmd As New MySqlCommand(
            sqlOrder, conn, trans)

            cmd.Parameters.AddWithValue("@id", orderID)

            Dim result As Object = cmd.ExecuteScalar()

            If result Is Nothing OrElse result Is DBNull.Value Then
                Throw New Exception("Pesanan tidak ditemukan.")
            End If

            totalTagihan = Convert.ToDecimal(result)

        End Using

        Dim sqlPaid As String =
            "SELECT COALESCE(SUM(amount),0) " &
            "FROM payments " &
            "WHERE order_id=@id " &
            "AND payment_id<>@paymentID"

        Using cmd As New MySqlCommand(
            sqlPaid, conn, trans)

            cmd.Parameters.AddWithValue("@id", orderID)

            cmd.Parameters.AddWithValue(
                "@paymentID", excludePaymentID)

            totalBayar =
                Convert.ToDecimal(cmd.ExecuteScalar())

        End Using

        If amount > totalTagihan - totalBayar Then

            Throw New Exception(
                "Pembayaran melebihi sisa tagihan. " &
                "Sisa saat ini: " &
                FormatRupiah(
                    Math.Max(0D, totalTagihan - totalBayar)))

        End If

    End Sub


    ' ==========================================
    ' 11. UPDATE STATUS PESANAN
    ' ==========================================

    Private Sub UpdateOrderPaymentStatus(
        conn As MySqlConnection,
        trans As MySqlTransaction,
        orderID As Long
    )

        Dim totalTagihan As Decimal
        Dim totalBayar As Decimal

        Dim sql As String =
            "SELECT o.final_total, " &
            "COALESCE((" &
            "SELECT SUM(p.amount) " &
            "FROM payments p " &
            "WHERE p.order_id=o.order_id" &
            "),0) AS total_paid " &
            "FROM orders o " &
            "WHERE o.order_id=@id"

        Using cmd As New MySqlCommand(sql, conn, trans)

            cmd.Parameters.AddWithValue("@id", orderID)

            Using dr As MySqlDataReader = cmd.ExecuteReader()

                If Not dr.Read() Then
                    Throw New Exception("Pesanan tidak ditemukan.")
                End If

                totalTagihan =
                    Convert.ToDecimal(dr("final_total"))

                totalBayar =
                    Convert.ToDecimal(dr("total_paid"))

            End Using

        End Using

        Dim status As String

        If totalBayar <= 0D Then

            status = "Belum Dibayar"

        ElseIf totalBayar < totalTagihan Then

            status = "Sebagian"

        Else

            status = "Lunas"

        End If

        Dim sqlUpdate As String =
            "UPDATE orders SET payment_status=@status " &
            "WHERE order_id=@id"

        Using cmd As New MySqlCommand(
            sqlUpdate, conn, trans)

            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@id", orderID)

            cmd.ExecuteNonQuery()

        End Using

    End Sub


    ' ==========================================
    ' 12. TOMBOL SIMPAN
    ' ==========================================

    Private Sub btnSaveCustomer_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSaveCustomer.Click

        If selectedPaymentId <> 0 Then

            MessageBox.Show(
                "Klik Reset sebelum menambahkan pembayaran baru.",
                "Informasi")

            Return

        End If

        If Not ValidatePayment() Then Return

        Dim orderID As Long = selectedOrderId

        Try

            Using conn As MySqlConnection =
                DbDelica.GetConnection()

                conn.Open()

                Using trans As MySqlTransaction =
                    conn.BeginTransaction()

                    Try

                        ValidateDatabaseBalance(
                            conn,
                            trans,
                            orderID,
                            numPaymentAmount.Value)

                        Dim sql As String =
                            "INSERT INTO payments " &
                            "(order_id, recorded_by, payment_date, " &
                            "amount, payment_method) " &
                            "VALUES (@order, @user, @date, @amount, @method)"

                        Using cmd As New MySqlCommand(
                            sql, conn, trans)

                            cmd.Parameters.AddWithValue(
                                "@order", orderID)

                            cmd.Parameters.AddWithValue(
                                "@user", Sesi.UserID)

                            cmd.Parameters.AddWithValue(
                                "@date", dtpPaymentDate.Value)

                            cmd.Parameters.AddWithValue(
                                "@amount", numPaymentAmount.Value)

                            cmd.Parameters.AddWithValue(
                                "@method", cmbPaymentMethod.Text)

                            cmd.ExecuteNonQuery()

                        End Using

                        UpdateOrderPaymentStatus(
                            conn, trans, orderID)

                        trans.Commit()

                    Catch

                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using

            MessageBox.Show(
                "Pembayaran berhasil disimpan.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            LoadPayments()
            LoadOrders()
            ResetPayment()

        Catch ex As Exception

            MessageBox.Show(
                "Gagal menyimpan pembayaran: " & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    ' ==========================================
    ' 13. LOAD DATA PEMBAYARAN
    ' ==========================================

    Private Sub LoadPayments(
        Optional keyword As String = ""
    )

        Try

            Using conn As MySqlConnection =
                DbDelica.GetConnection()

                conn.Open()

                Dim sql As String =
                    "SELECT " &
                    "p.payment_id AS payment_id_key, " &
                    "o.order_id AS order_id_key, " &
                    "CONCAT('PAY-',LPAD(p.payment_id,3,'0')) " &
                    "AS `ID Pembayaran`, " &
                    "o.order_no AS `No. Pesanan`, " &
                    "c.customer_name AS `Nama Pelanggan`, " &
                    "p.payment_date AS `Tanggal Bayar`, " &
                    "p.amount AS `Nominal Pembayaran`, " &
                    "p.payment_method AS `Metode Pembayaran`, " &
                    "o.payment_status AS `Status Pembayaran` " &
                    "FROM payments p " &
                    "INNER JOIN orders o " &
                    "ON p.order_id=o.order_id " &
                    "INNER JOIN customers c " &
                    "ON o.customer_id=c.customer_id " &
                    "WHERE CONCAT('PAY-',LPAD(p.payment_id,3,'0')) LIKE @q " &
                    "OR o.order_no LIKE @q " &
                    "OR c.customer_name LIKE @q " &
                    "OR c.phone LIKE @q " &
                    "ORDER BY p.payment_id DESC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@q", "%" & keyword.Trim() & "%")

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()

                        da.Fill(dt)

                        dgvPayment.DataSource = dt

                        ' Sembunyikan ID internal
                        If dgvPayment.Columns.Contains(
                            "payment_id_key") Then

                            dgvPayment.Columns(
                                "payment_id_key").Visible = False

                        End If

                        If dgvPayment.Columns.Contains(
                            "order_id_key") Then

                            dgvPayment.Columns(
                                "order_id_key").Visible = False

                        End If

                        ' Format nominal Rupiah
                        If dgvPayment.Columns.Contains(
                            "Nominal Pembayaran") Then

                            With dgvPayment.Columns(
                                "Nominal Pembayaran").DefaultCellStyle

                                .Format = "C0"
                                .FormatProvider = idCulture

                            End With

                        End If

                        ' Format tanggal
                        If dgvPayment.Columns.Contains(
                            "Tanggal Bayar") Then

                            dgvPayment.Columns(
                                "Tanggal Bayar"
                            ).DefaultCellStyle.Format =
                                "dd/MM/yyyy HH:mm"

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Gagal memuat data pembayaran: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub


    ' ==========================================
    ' 14. PILIH DATA PEMBAYARAN
    ' ==========================================

    Private Sub dgvPayment_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvPayment.CellClick

        If e.RowIndex < 0 Then Return

        Try

            Dim row As DataGridViewRow =
                dgvPayment.Rows(e.RowIndex)

            selectedPaymentId =
                Convert.ToInt32(
                    row.Cells("payment_id_key").Value)

            selectedOrderId =
                Convert.ToInt64(
                    row.Cells("order_id_key").Value)

            selectedPaymentAmount =
                Convert.ToDecimal(
                    row.Cells("Nominal Pembayaran").Value)

            isLoading = True

            cmbOrderNo.SelectedValue = selectedOrderId
            cmbOrderNo.Enabled = False

            dtpPaymentDate.Value =
                Convert.ToDateTime(
                    row.Cells("Tanggal Bayar").Value)

            cmbPaymentMethod.Text =
                row.Cells("Metode Pembayaran").Value.ToString()

            numPaymentAmount.Value =
                Math.Min(
                    selectedPaymentAmount,
                    numPaymentAmount.Maximum)

            isLoading = False

            LoadOrderInformation(selectedOrderId)

            UpdatePaymentPreview()

            btnSaveCustomer.Enabled = False
            btnUpdateCustomer.Enabled = True
            btnDeleteCustomer.Enabled = True

        Catch ex As Exception

            isLoading = False

            MessageBox.Show(
                "Gagal memilih data pembayaran: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub


    ' ==========================================
    ' 15. TOMBOL EDIT
    ' ==========================================

    Private Sub btnUpdateCustomer_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnUpdateCustomer.Click

        If selectedPaymentId = 0 Then

            MessageBox.Show(
                "Pilih data pembayaran terlebih dahulu.",
                "Peringatan")

            Return

        End If

        If Not ValidatePayment() Then Return

        Try

            Using conn As MySqlConnection =
                DbDelica.GetConnection()

                conn.Open()

                Using trans As MySqlTransaction =
                    conn.BeginTransaction()

                    Try

                        ValidateDatabaseBalance(
                            conn,
                            trans,
                            selectedOrderId,
                            numPaymentAmount.Value,
                            selectedPaymentId)

                        Dim sql As String =
                            "UPDATE payments SET " &
                            "payment_date=@date, " &
                            "amount=@amount, " &
                            "payment_method=@method " &
                            "WHERE payment_id=@id"

                        Using cmd As New MySqlCommand(
                            sql, conn, trans)

                            cmd.Parameters.AddWithValue(
                                "@date", dtpPaymentDate.Value)

                            cmd.Parameters.AddWithValue(
                                "@amount", numPaymentAmount.Value)

                            cmd.Parameters.AddWithValue(
                                "@method", cmbPaymentMethod.Text)

                            cmd.Parameters.AddWithValue(
                                "@id", selectedPaymentId)

                            cmd.ExecuteNonQuery()

                        End Using

                        UpdateOrderPaymentStatus(
                            conn, trans, selectedOrderId)

                        trans.Commit()

                    Catch

                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using

            MessageBox.Show(
                "Data pembayaran berhasil diperbarui.",
                "Berhasil")

            LoadPayments()
            LoadOrders()
            ResetPayment()

        Catch ex As Exception

            MessageBox.Show(
                "Gagal mengubah pembayaran: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub


    ' ==========================================
    ' 16. TOMBOL HAPUS
    ' ==========================================

    Private Sub btnDeleteCustomer_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDeleteCustomer.Click

        If selectedPaymentId = 0 Then

            MessageBox.Show(
                "Pilih data pembayaran terlebih dahulu.",
                "Peringatan")

            Return

        End If

        Dim konfirmasi As DialogResult =
            MessageBox.Show(
                "Apakah kamu yakin ingin menghapus pembayaran ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If konfirmasi <> DialogResult.Yes Then Return

        Try

            Using conn As MySqlConnection =
                DbDelica.GetConnection()

                conn.Open()

                Using trans As MySqlTransaction =
                    conn.BeginTransaction()

                    Try

                        Dim sql As String =
                            "DELETE FROM payments " &
                            "WHERE payment_id=@id"

                        Using cmd As New MySqlCommand(
                            sql, conn, trans)

                            cmd.Parameters.AddWithValue(
                                "@id", selectedPaymentId)

                            cmd.ExecuteNonQuery()

                        End Using

                        UpdateOrderPaymentStatus(
                            conn, trans, selectedOrderId)

                        trans.Commit()

                    Catch

                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using

            MessageBox.Show(
                "Data pembayaran berhasil dihapus.",
                "Berhasil")

            LoadPayments()
            LoadOrders()
            ResetPayment()

        Catch ex As Exception

            MessageBox.Show(
                "Gagal menghapus pembayaran: " & ex.Message,
                "Kesalahan")

        End Try

    End Sub


    ' ==========================================
    ' 17. TOMBOL RESET
    ' ==========================================

    Private Sub btnResetCustomer_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnResetCustomer.Click

        ResetPayment()

    End Sub


    Private Sub ResetPayment()

        isLoading = True

        selectedPaymentId = 0
        selectedOrderId = 0

        selectedPaymentAmount = 0D
        currentOrderTotal = 0D
        currentOrderPaid = 0D

        txtPaymentID.Clear()
        txtCustomerName.Clear()
        txtGrandTotal.Clear()
        txtTotalPaid.Clear()

        cmbOrderNo.SelectedIndex = -1
        cmbOrderNo.Enabled = True

        cmbPaymentMethod.SelectedIndex = -1

        dtpPaymentDate.Value = DateTime.Today

        numPaymentAmount.Value = 0D

        lblPaymentStatusValue.Text = "Belum Dibayar"

        txtSearchPayment.Clear()

        btnSaveCustomer.Enabled = True
        btnUpdateCustomer.Enabled = False
        btnDeleteCustomer.Enabled = False

        dgvPayment.ClearSelection()

        isLoading = False

        GeneratePaymentID()

        LoadPayments()

    End Sub

    Private Sub AturHakAksesPayment()

        If Sesi.UserRole = "Customer" Then

            ' Customer hanya melihat data
            btnSaveCustomer.Visible = False
            btnUpdateCustomer.Visible = False
            btnDeleteCustomer.Visible = False

            ' Input tidak bisa diubah
            cmbOrderNo.Enabled = False
            cmbPaymentMethod.Enabled = False
            numPaymentAmount.Enabled = False

            ' Data hanya bisa dibaca
            dgvPayment.ReadOnly = True
            dgvPayment.AllowUserToAddRows = False
            dgvPayment.AllowUserToDeleteRows = False
            dgvPayment.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        End If

    End Sub


    ' ==========================================
    ' 18. TOMBOL CARI
    ' ==========================================

    Private Sub btnSearchPayment_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearchPayment.Click

        LoadPayments(txtSearchPayment.Text)

    End Sub


    ' ==========================================
    ' 19. PENCARIAN OTOMATIS
    ' ==========================================

    Private Sub txtSearchPayment_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchPayment.TextChanged

        If isLoading Then Return

        LoadPayments(txtSearchPayment.Text)

    End Sub


    ' Navigasi Master Customer
    Private Sub btnMasterCustomer_Click(sender As Object, e As EventArgs) Handles btnMasterCustomer.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
        FrmCustomer.Show()
        Me.Hide()
    End Sub

    ' Navigasi Master Service
    Private Sub btnMasterService_Click(sender As Object, e As EventArgs) Handles btnMasterService.Click
        If Sesi.UserRole <> "Owner" AndAlso
       Sesi.UserRole <> "Staff Laundry" AndAlso
       Sesi.UserRole <> "Staff Antar-Jemput" Then Return
        FrmServices.Show()
        Me.Hide()
    End Sub

    ' Navigasi Master User
    Private Sub btnMasterUser_Click(sender As Object, e As EventArgs) Handles btnMasterUser.Click
        If Sesi.UserRole <> "Owner" Then Return
        FrmUser.Show()
        Me.Hide()
    End Sub

    ' Navigasi Transaksi Order
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        FrmOrder.Show()
        Me.Hide()
    End Sub

    ' Navigasi Pembayaran
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
    End Sub

End Class
