<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrder))
        Me.pnlSidebarServices = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.btnAntarJemput = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button7 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2TileButton1 = New Guna.UI2.WinForms.Guna2TileButton()
        Me.Guna2Button6 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button5 = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMasterUser = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMasterService = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMasterCustomer = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2HtmlLabel8 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.pnlContent = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.numTransportFee = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.lblGrandTotal = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblGrandTotalTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel14 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.chkExpress = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.dgvOrderDetail = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.pnlOrderDetail = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lblUnit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.nudQuantity = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.txtUnitPrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtSubtotal = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtPricingType = New Guna.UI2.WinForms.Guna2TextBox()
        Me.cmbService = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel6 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel9 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel11 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel12 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel13 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.lblTitleOrder = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.pnlOrderForm = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.cmbOrderStatus = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbCustomer = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbStaff = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dtpOrderDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtOrderNo = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel7 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.pnlSearchCustomer = New Guna.UI2.WinForms.Guna2Panel()
        Me.txtSearchCustomer = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel10 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnSearchCustomer = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.lblTotalService = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblTotalOrder = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblOrderSystemStatus = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.btnClearService = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btnAddService = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btnSaveOrder = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btnResetOrder = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btnUpdateOrder = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btnDeleteOrder = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Guna2ImageButton1 = New Guna.UI2.WinForms.Guna2ImageButton()
        Me.pnlSidebarServices.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.numTransportFee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOrderDetail.SuspendLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2CustomGradientPanel1.SuspendLayout()
        Me.pnlOrderForm.SuspendLayout()
        Me.pnlSearchCustomer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSidebarServices
        '
        Me.pnlSidebarServices.Controls.Add(Me.btnAntarJemput)
        Me.pnlSidebarServices.Controls.Add(Me.Guna2Button7)
        Me.pnlSidebarServices.Controls.Add(Me.Guna2ImageButton1)
        Me.pnlSidebarServices.Controls.Add(Me.Guna2TileButton1)
        Me.pnlSidebarServices.Controls.Add(Me.Guna2Button6)
        Me.pnlSidebarServices.Controls.Add(Me.Guna2Button5)
        Me.pnlSidebarServices.Controls.Add(Me.btnMasterUser)
        Me.pnlSidebarServices.Controls.Add(Me.btnMasterService)
        Me.pnlSidebarServices.Controls.Add(Me.btnMasterCustomer)
        Me.pnlSidebarServices.Controls.Add(Me.Guna2Button1)
        Me.pnlSidebarServices.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.pnlSidebarServices.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.pnlSidebarServices.FillColor3 = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSidebarServices.FillColor4 = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSidebarServices.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebarServices.Name = "pnlSidebarServices"
        Me.pnlSidebarServices.Size = New System.Drawing.Size(200, 819)
        Me.pnlSidebarServices.TabIndex = 1
        '
        'btnAntarJemput
        '
        Me.btnAntarJemput.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAntarJemput.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAntarJemput.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAntarJemput.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAntarJemput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAntarJemput.FillColor = System.Drawing.Color.Transparent
        Me.btnAntarJemput.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAntarJemput.ForeColor = System.Drawing.Color.White
        Me.btnAntarJemput.Location = New System.Drawing.Point(0, 445)
        Me.btnAntarJemput.Name = "btnAntarJemput"
        Me.btnAntarJemput.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.btnAntarJemput.Size = New System.Drawing.Size(200, 45)
        Me.btnAntarJemput.TabIndex = 10
        Me.btnAntarJemput.Text = "Antar-Jemput"
        Me.btnAntarJemput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Guna2Button7
        '
        Me.Guna2Button7.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button7.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button7.ForeColor = System.Drawing.Color.White
        Me.Guna2Button7.Location = New System.Drawing.Point(0, 495)
        Me.Guna2Button7.Name = "Guna2Button7"
        Me.Guna2Button7.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.Guna2Button7.Size = New System.Drawing.Size(200, 45)
        Me.Guna2Button7.TabIndex = 9
        Me.Guna2Button7.Text = "Laporan"
        Me.Guna2Button7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Guna2TileButton1
        '
        Me.Guna2TileButton1.AutoRoundedCorners = True
        Me.Guna2TileButton1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2TileButton1.BorderColor = System.Drawing.Color.Transparent
        Me.Guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2TileButton1.FillColor = System.Drawing.Color.White
        Me.Guna2TileButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2TileButton1.ForeColor = System.Drawing.Color.Black
        Me.Guna2TileButton1.Location = New System.Drawing.Point(12, 603)
        Me.Guna2TileButton1.Name = "Guna2TileButton1"
        Me.Guna2TileButton1.Size = New System.Drawing.Size(180, 45)
        Me.Guna2TileButton1.TabIndex = 6
        Me.Guna2TileButton1.Text = "Logout"
        '
        'Guna2Button6
        '
        Me.Guna2Button6.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button6.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button6.ForeColor = System.Drawing.Color.White
        Me.Guna2Button6.Location = New System.Drawing.Point(0, 393)
        Me.Guna2Button6.Name = "Guna2Button6"
        Me.Guna2Button6.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.Guna2Button6.Size = New System.Drawing.Size(200, 45)
        Me.Guna2Button6.TabIndex = 5
        Me.Guna2Button6.Text = "Pembayaran"
        Me.Guna2Button6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Guna2Button5
        '
        Me.Guna2Button5.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Guna2Button5.BorderColor = System.Drawing.Color.Transparent
        Me.Guna2Button5.BorderRadius = 30
        Me.Guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button5.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2Button5.ForeColor = System.Drawing.Color.White
        Me.Guna2Button5.Location = New System.Drawing.Point(1, 341)
        Me.Guna2Button5.Name = "Guna2Button5"
        Me.Guna2Button5.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.Guna2Button5.Size = New System.Drawing.Size(200, 45)
        Me.Guna2Button5.TabIndex = 4
        Me.Guna2Button5.Text = "Transaksi Pesanan"
        Me.Guna2Button5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnMasterUser
        '
        Me.btnMasterUser.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnMasterUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMasterUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMasterUser.FillColor = System.Drawing.Color.Transparent
        Me.btnMasterUser.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasterUser.ForeColor = System.Drawing.Color.White
        Me.btnMasterUser.Location = New System.Drawing.Point(1, 290)
        Me.btnMasterUser.Name = "btnMasterUser"
        Me.btnMasterUser.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.btnMasterUser.Size = New System.Drawing.Size(200, 45)
        Me.btnMasterUser.TabIndex = 3
        Me.btnMasterUser.Text = "Master Pengguna"
        Me.btnMasterUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnMasterService
        '
        Me.btnMasterService.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnMasterService.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterService.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterService.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMasterService.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMasterService.FillColor = System.Drawing.Color.Transparent
        Me.btnMasterService.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasterService.ForeColor = System.Drawing.Color.White
        Me.btnMasterService.Location = New System.Drawing.Point(1, 239)
        Me.btnMasterService.Name = "btnMasterService"
        Me.btnMasterService.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.btnMasterService.Size = New System.Drawing.Size(200, 45)
        Me.btnMasterService.TabIndex = 2
        Me.btnMasterService.Text = "Master Layanan"
        Me.btnMasterService.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnMasterCustomer
        '
        Me.btnMasterCustomer.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnMasterCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMasterCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMasterCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMasterCustomer.FillColor = System.Drawing.Color.Transparent
        Me.btnMasterCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasterCustomer.ForeColor = System.Drawing.Color.White
        Me.btnMasterCustomer.Location = New System.Drawing.Point(1, 187)
        Me.btnMasterCustomer.Name = "btnMasterCustomer"
        Me.btnMasterCustomer.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.btnMasterCustomer.Size = New System.Drawing.Size(200, 45)
        Me.btnMasterCustomer.TabIndex = 1
        Me.btnMasterCustomer.Text = "Pesanan Pelanggan"
        Me.btnMasterCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(0, 136)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.PressedColor = System.Drawing.Color.LightSkyBlue
        Me.Guna2Button1.Size = New System.Drawing.Size(200, 45)
        Me.Guna2Button1.TabIndex = 0
        Me.Guna2Button1.Text = "Dashboard"
        Me.Guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Guna2HtmlLabel8
        '
        Me.Guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Guna2HtmlLabel8.Location = New System.Drawing.Point(15, 39)
        Me.Guna2HtmlLabel8.Name = "Guna2HtmlLabel8"
        Me.Guna2HtmlLabel8.Size = New System.Drawing.Size(170, 27)
        Me.Guna2HtmlLabel8.TabIndex = 1
        Me.Guna2HtmlLabel8.Text = "Management System"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(14, 8)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(344, 38)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "DELICA LAUNDRY SERVICES"
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.Guna2Panel1)
        Me.pnlContent.Controls.Add(Me.dgvOrderDetail)
        Me.pnlContent.Controls.Add(Me.pnlOrderDetail)
        Me.pnlContent.Controls.Add(Me.Guna2CustomGradientPanel1)
        Me.pnlContent.Controls.Add(Me.lblTitleOrder)
        Me.pnlContent.Controls.Add(Me.pnlOrderForm)
        Me.pnlContent.Controls.Add(Me.pnlSearchCustomer)
        Me.pnlContent.Controls.Add(Me.btnSaveOrder)
        Me.pnlContent.Controls.Add(Me.btnResetOrder)
        Me.pnlContent.Controls.Add(Me.btnUpdateOrder)
        Me.pnlContent.Controls.Add(Me.btnDeleteOrder)
        Me.pnlContent.FillColor = System.Drawing.Color.LightSkyBlue
        Me.pnlContent.FillColor4 = System.Drawing.Color.LightSkyBlue
        Me.pnlContent.Location = New System.Drawing.Point(200, 0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(828, 819)
        Me.pnlContent.TabIndex = 15
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.numTransportFee)
        Me.Guna2Panel1.Controls.Add(Me.lblGrandTotal)
        Me.Guna2Panel1.Controls.Add(Me.lblGrandTotalTitle)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel14)
        Me.Guna2Panel1.Controls.Add(Me.chkExpress)
        Me.Guna2Panel1.Location = New System.Drawing.Point(14, 654)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(779, 73)
        Me.Guna2Panel1.TabIndex = 30
        '
        'numTransportFee
        '
        Me.numTransportFee.BackColor = System.Drawing.Color.Transparent
        Me.numTransportFee.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.numTransportFee.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numTransportFee.Location = New System.Drawing.Point(285, 16)
        Me.numTransportFee.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.numTransportFee.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.numTransportFee.Name = "numTransportFee"
        Me.numTransportFee.Size = New System.Drawing.Size(143, 39)
        Me.numTransportFee.TabIndex = 35
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Location = New System.Drawing.Point(632, 16)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(97, 34)
        Me.lblGrandTotal.TabIndex = 34
        Me.lblGrandTotal.Text = "Rp. 0,00"
        '
        'lblGrandTotalTitle
        '
        Me.lblGrandTotalTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblGrandTotalTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotalTitle.ForeColor = System.Drawing.Color.Black
        Me.lblGrandTotalTitle.Location = New System.Drawing.Point(472, 16)
        Me.lblGrandTotalTitle.Name = "lblGrandTotalTitle"
        Me.lblGrandTotalTitle.Size = New System.Drawing.Size(132, 34)
        Me.lblGrandTotalTitle.TabIndex = 33
        Me.lblGrandTotalTitle.Text = "Grand Total"
        '
        'Guna2HtmlLabel14
        '
        Me.Guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel14.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel14.Location = New System.Drawing.Point(133, 24)
        Me.Guna2HtmlLabel14.Name = "Guna2HtmlLabel14"
        Me.Guna2HtmlLabel14.Size = New System.Drawing.Size(145, 23)
        Me.Guna2HtmlLabel14.TabIndex = 32
        Me.Guna2HtmlLabel14.Text = "Biaya Antar-Jemput"
        '
        'chkExpress
        '
        Me.chkExpress.AutoSize = True
        Me.chkExpress.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkExpress.CheckedState.BorderRadius = 0
        Me.chkExpress.CheckedState.BorderThickness = 0
        Me.chkExpress.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkExpress.Location = New System.Drawing.Point(13, 26)
        Me.chkExpress.Name = "chkExpress"
        Me.chkExpress.Size = New System.Drawing.Size(92, 24)
        Me.chkExpress.TabIndex = 0
        Me.chkExpress.Text = "Express"
        Me.chkExpress.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.chkExpress.UncheckedState.BorderRadius = 0
        Me.chkExpress.UncheckedState.BorderThickness = 0
        Me.chkExpress.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        '
        'dgvOrderDetail
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvOrderDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOrderDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOrderDetail.ColumnHeadersHeight = 4
        Me.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrderDetail.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOrderDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvOrderDetail.Location = New System.Drawing.Point(14, 495)
        Me.dgvOrderDetail.Name = "dgvOrderDetail"
        Me.dgvOrderDetail.ReadOnly = True
        Me.dgvOrderDetail.RowHeadersVisible = False
        Me.dgvOrderDetail.RowHeadersWidth = 62
        Me.dgvOrderDetail.RowTemplate.Height = 28
        Me.dgvOrderDetail.Size = New System.Drawing.Size(779, 153)
        Me.dgvOrderDetail.TabIndex = 29
        Me.dgvOrderDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvOrderDetail.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOrderDetail.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvOrderDetail.ThemeStyle.ReadOnly = True
        Me.dgvOrderDetail.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOrderDetail.ThemeStyle.RowsStyle.Height = 28
        '
        'pnlOrderDetail
        '
        Me.pnlOrderDetail.Controls.Add(Me.lblUnit)
        Me.pnlOrderDetail.Controls.Add(Me.btnClearService)
        Me.pnlOrderDetail.Controls.Add(Me.btnAddService)
        Me.pnlOrderDetail.Controls.Add(Me.nudQuantity)
        Me.pnlOrderDetail.Controls.Add(Me.txtUnitPrice)
        Me.pnlOrderDetail.Controls.Add(Me.txtSubtotal)
        Me.pnlOrderDetail.Controls.Add(Me.txtPricingType)
        Me.pnlOrderDetail.Controls.Add(Me.cmbService)
        Me.pnlOrderDetail.Controls.Add(Me.Guna2HtmlLabel6)
        Me.pnlOrderDetail.Controls.Add(Me.Guna2HtmlLabel9)
        Me.pnlOrderDetail.Controls.Add(Me.Guna2HtmlLabel11)
        Me.pnlOrderDetail.Controls.Add(Me.Guna2HtmlLabel12)
        Me.pnlOrderDetail.Controls.Add(Me.Guna2HtmlLabel13)
        Me.pnlOrderDetail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlOrderDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.pnlOrderDetail.Location = New System.Drawing.Point(14, 314)
        Me.pnlOrderDetail.Name = "pnlOrderDetail"
        Me.pnlOrderDetail.Size = New System.Drawing.Size(780, 175)
        Me.pnlOrderDetail.TabIndex = 28
        Me.pnlOrderDetail.Text = "Detail Layanan Laundry"
        '
        'lblUnit
        '
        Me.lblUnit.BorderColor = System.Drawing.Color.Navy
        Me.lblUnit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblUnit.DefaultText = ""
        Me.lblUnit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblUnit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.lblUnit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblUnit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblUnit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblUnit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUnit.Location = New System.Drawing.Point(600, 80)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.PlaceholderForeColor = System.Drawing.Color.White
        Me.lblUnit.PlaceholderText = ""
        Me.lblUnit.ReadOnly = True
        Me.lblUnit.SelectedText = ""
        Me.lblUnit.Size = New System.Drawing.Size(30, 29)
        Me.lblUnit.TabIndex = 32
        '
        'nudQuantity
        '
        Me.nudQuantity.BackColor = System.Drawing.Color.Transparent
        Me.nudQuantity.BorderColor = System.Drawing.Color.Navy
        Me.nudQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudQuantity.DecimalPlaces = 2
        Me.nudQuantity.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudQuantity.Location = New System.Drawing.Point(471, 80)
        Me.nudQuantity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudQuantity.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(130, 30)
        Me.nudQuantity.TabIndex = 31
        Me.nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BorderColor = System.Drawing.Color.Navy
        Me.txtUnitPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitPrice.DefaultText = ""
        Me.txtUnitPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUnitPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUnitPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUnitPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitPrice.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtUnitPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUnitPrice.Location = New System.Drawing.Point(337, 80)
        Me.txtUnitPrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtUnitPrice.PlaceholderText = ""
        Me.txtUnitPrice.ReadOnly = True
        Me.txtUnitPrice.SelectedText = ""
        Me.txtUnitPrice.Size = New System.Drawing.Size(116, 29)
        Me.txtUnitPrice.TabIndex = 30
        '
        'txtSubtotal
        '
        Me.txtSubtotal.BorderColor = System.Drawing.Color.Navy
        Me.txtSubtotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubtotal.DefaultText = ""
        Me.txtSubtotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSubtotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSubtotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSubtotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSubtotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSubtotal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtSubtotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSubtotal.Location = New System.Drawing.Point(647, 81)
        Me.txtSubtotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtSubtotal.PlaceholderText = ""
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.SelectedText = ""
        Me.txtSubtotal.Size = New System.Drawing.Size(127, 29)
        Me.txtSubtotal.TabIndex = 29
        '
        'txtPricingType
        '
        Me.txtPricingType.BorderColor = System.Drawing.Color.Navy
        Me.txtPricingType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPricingType.DefaultText = ""
        Me.txtPricingType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPricingType.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPricingType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPricingType.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPricingType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPricingType.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtPricingType.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPricingType.Location = New System.Drawing.Point(167, 80)
        Me.txtPricingType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPricingType.Name = "txtPricingType"
        Me.txtPricingType.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtPricingType.PlaceholderText = ""
        Me.txtPricingType.ReadOnly = True
        Me.txtPricingType.SelectedText = ""
        Me.txtPricingType.Size = New System.Drawing.Size(150, 29)
        Me.txtPricingType.TabIndex = 28
        '
        'cmbService
        '
        Me.cmbService.BackColor = System.Drawing.Color.Transparent
        Me.cmbService.BorderColor = System.Drawing.Color.Navy
        Me.cmbService.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbService.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbService.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbService.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbService.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbService.ItemHeight = 30
        Me.cmbService.Location = New System.Drawing.Point(12, 79)
        Me.cmbService.Name = "cmbService"
        Me.cmbService.Size = New System.Drawing.Size(136, 36)
        Me.cmbService.TabIndex = 27
        '
        'Guna2HtmlLabel6
        '
        Me.Guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel6.Location = New System.Drawing.Point(492, 49)
        Me.Guna2HtmlLabel6.Name = "Guna2HtmlLabel6"
        Me.Guna2HtmlLabel6.Size = New System.Drawing.Size(99, 23)
        Me.Guna2HtmlLabel6.TabIndex = 24
        Me.Guna2HtmlLabel6.Text = "Berat/Jumlah"
        '
        'Guna2HtmlLabel9
        '
        Me.Guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel9.Location = New System.Drawing.Point(28, 49)
        Me.Guna2HtmlLabel9.Name = "Guna2HtmlLabel9"
        Me.Guna2HtmlLabel9.Size = New System.Drawing.Size(107, 23)
        Me.Guna2HtmlLabel9.TabIndex = 3
        Me.Guna2HtmlLabel9.Text = "Nama Layanan"
        '
        'Guna2HtmlLabel11
        '
        Me.Guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel11.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel11.Location = New System.Drawing.Point(349, 49)
        Me.Guna2HtmlLabel11.Name = "Guna2HtmlLabel11"
        Me.Guna2HtmlLabel11.Size = New System.Drawing.Size(100, 23)
        Me.Guna2HtmlLabel11.TabIndex = 7
        Me.Guna2HtmlLabel11.Text = "Harga Satuan"
        '
        'Guna2HtmlLabel12
        '
        Me.Guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel12.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel12.Location = New System.Drawing.Point(176, 49)
        Me.Guna2HtmlLabel12.Name = "Guna2HtmlLabel12"
        Me.Guna2HtmlLabel12.Size = New System.Drawing.Size(130, 23)
        Me.Guna2HtmlLabel12.TabIndex = 4
        Me.Guna2HtmlLabel12.Text = "Jenis Perhitungan"
        '
        'Guna2HtmlLabel13
        '
        Me.Guna2HtmlLabel13.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel13.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel13.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel13.Location = New System.Drawing.Point(659, 49)
        Me.Guna2HtmlLabel13.Name = "Guna2HtmlLabel13"
        Me.Guna2HtmlLabel13.Size = New System.Drawing.Size(65, 23)
        Me.Guna2HtmlLabel13.TabIndex = 5
        Me.Guna2HtmlLabel13.Text = "Subtotal"
        '
        'Guna2CustomGradientPanel1
        '
        Me.Guna2CustomGradientPanel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2CustomGradientPanel1.Controls.Add(Me.Guna2HtmlLabel8)
        Me.Guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CustomGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Me.Guna2CustomGradientPanel1.Size = New System.Drawing.Size(828, 78)
        Me.Guna2CustomGradientPanel1.TabIndex = 12
        '
        'lblTitleOrder
        '
        Me.lblTitleOrder.BackColor = System.Drawing.Color.Transparent
        Me.lblTitleOrder.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitleOrder.Location = New System.Drawing.Point(224, 80)
        Me.lblTitleOrder.Name = "lblTitleOrder"
        Me.lblTitleOrder.Size = New System.Drawing.Size(330, 38)
        Me.lblTitleOrder.TabIndex = 2
        Me.lblTitleOrder.Text = "Transaksi Pesanan Laundry"
        '
        'pnlOrderForm
        '
        Me.pnlOrderForm.Controls.Add(Me.cmbOrderStatus)
        Me.pnlOrderForm.Controls.Add(Me.cmbCustomer)
        Me.pnlOrderForm.Controls.Add(Me.cmbStaff)
        Me.pnlOrderForm.Controls.Add(Me.Guna2HtmlLabel2)
        Me.pnlOrderForm.Controls.Add(Me.dtpOrderDate)
        Me.pnlOrderForm.Controls.Add(Me.Guna2HtmlLabel3)
        Me.pnlOrderForm.Controls.Add(Me.txtOrderNo)
        Me.pnlOrderForm.Controls.Add(Me.Guna2HtmlLabel7)
        Me.pnlOrderForm.Controls.Add(Me.Guna2HtmlLabel4)
        Me.pnlOrderForm.Controls.Add(Me.Guna2HtmlLabel5)
        Me.pnlOrderForm.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlOrderForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.pnlOrderForm.Location = New System.Drawing.Point(15, 131)
        Me.pnlOrderForm.Name = "pnlOrderForm"
        Me.pnlOrderForm.Size = New System.Drawing.Size(780, 175)
        Me.pnlOrderForm.TabIndex = 10
        Me.pnlOrderForm.Text = "Form Data Pesanan"
        '
        'cmbOrderStatus
        '
        Me.cmbOrderStatus.BackColor = System.Drawing.Color.Transparent
        Me.cmbOrderStatus.BorderColor = System.Drawing.Color.Navy
        Me.cmbOrderStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrderStatus.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbOrderStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbOrderStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbOrderStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbOrderStatus.ItemHeight = 30
        Me.cmbOrderStatus.Location = New System.Drawing.Point(538, 91)
        Me.cmbOrderStatus.Name = "cmbOrderStatus"
        Me.cmbOrderStatus.Size = New System.Drawing.Size(203, 36)
        Me.cmbOrderStatus.TabIndex = 27
        '
        'cmbCustomer
        '
        Me.cmbCustomer.BackColor = System.Drawing.Color.Transparent
        Me.cmbCustomer.BorderColor = System.Drawing.Color.Navy
        Me.cmbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbCustomer.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbCustomer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbCustomer.ItemHeight = 30
        Me.cmbCustomer.Location = New System.Drawing.Point(154, 131)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(220, 36)
        Me.cmbCustomer.TabIndex = 26
        '
        'cmbStaff
        '
        Me.cmbStaff.BackColor = System.Drawing.Color.Transparent
        Me.cmbStaff.BorderColor = System.Drawing.Color.Navy
        Me.cmbStaff.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStaff.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStaff.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbStaff.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStaff.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbStaff.ItemHeight = 30
        Me.cmbStaff.Location = New System.Drawing.Point(538, 49)
        Me.cmbStaff.Name = "cmbStaff"
        Me.cmbStaff.Size = New System.Drawing.Size(203, 36)
        Me.cmbStaff.TabIndex = 25
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(391, 91)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(111, 23)
        Me.Guna2HtmlLabel2.TabIndex = 24
        Me.Guna2HtmlLabel2.Text = "Status Pesanan"
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.Checked = True
        Me.dtpOrderDate.CustomFormat = ""
        Me.dtpOrderDate.FillColor = System.Drawing.Color.White
        Me.dtpOrderDate.FocusedColor = System.Drawing.Color.Black
        Me.dtpOrderDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpOrderDate.ForeColor = System.Drawing.Color.Black
        Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOrderDate.Location = New System.Drawing.Point(154, 87)
        Me.dtpOrderDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpOrderDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(220, 36)
        Me.dtpOrderDate.TabIndex = 23
        Me.dtpOrderDate.Value = New Date(2026, 11, 12, 19, 0, 47, 228)
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(11, 54)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(88, 23)
        Me.Guna2HtmlLabel3.TabIndex = 3
        Me.Guna2HtmlLabel3.Text = "No Pesanan"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.BorderColor = System.Drawing.Color.Navy
        Me.txtOrderNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOrderNo.DefaultText = ""
        Me.txtOrderNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtOrderNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtOrderNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOrderNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtOrderNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOrderNo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtOrderNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtOrderNo.Location = New System.Drawing.Point(154, 49)
        Me.txtOrderNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.PlaceholderForeColor = System.Drawing.Color.White
        Me.txtOrderNo.PlaceholderText = ""
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.SelectedText = ""
        Me.txtOrderNo.Size = New System.Drawing.Size(220, 29)
        Me.txtOrderNo.TabIndex = 10
        '
        'Guna2HtmlLabel7
        '
        Me.Guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel7.Location = New System.Drawing.Point(391, 55)
        Me.Guna2HtmlLabel7.Name = "Guna2HtmlLabel7"
        Me.Guna2HtmlLabel7.Size = New System.Drawing.Size(61, 23)
        Me.Guna2HtmlLabel7.TabIndex = 7
        Me.Guna2HtmlLabel7.Text = "Petugas"
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(10, 91)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(124, 23)
        Me.Guna2HtmlLabel4.TabIndex = 4
        Me.Guna2HtmlLabel4.Text = "Tanggal Pesanan"
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(10, 131)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(125, 23)
        Me.Guna2HtmlLabel5.TabIndex = 5
        Me.Guna2HtmlLabel5.Text = "Nama Pelanggan"
        '
        'pnlSearchCustomer
        '
        Me.pnlSearchCustomer.BackColor = System.Drawing.Color.CornflowerBlue
        Me.pnlSearchCustomer.Controls.Add(Me.txtSearchCustomer)
        Me.pnlSearchCustomer.Controls.Add(Me.Guna2HtmlLabel10)
        Me.pnlSearchCustomer.Controls.Add(Me.btnSearchCustomer)
        Me.pnlSearchCustomer.Location = New System.Drawing.Point(14, 405)
        Me.pnlSearchCustomer.Name = "pnlSearchCustomer"
        Me.pnlSearchCustomer.Size = New System.Drawing.Size(779, 33)
        Me.pnlSearchCustomer.TabIndex = 11
        '
        'txtSearchCustomer
        '
        Me.txtSearchCustomer.BorderRadius = 6
        Me.txtSearchCustomer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearchCustomer.DefaultText = ""
        Me.txtSearchCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSearchCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSearchCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSearchCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchCustomer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearchCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSearchCustomer.Location = New System.Drawing.Point(123, 3)
        Me.txtSearchCustomer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchCustomer.Name = "txtSearchCustomer"
        Me.txtSearchCustomer.PlaceholderText = "Cari ID, nama, atau nomor telepon..."
        Me.txtSearchCustomer.SelectedText = ""
        Me.txtSearchCustomer.Size = New System.Drawing.Size(544, 26)
        Me.txtSearchCustomer.TabIndex = 23
        '
        'Guna2HtmlLabel10
        '
        Me.Guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel10.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel10.Location = New System.Drawing.Point(6, 4)
        Me.Guna2HtmlLabel10.Name = "Guna2HtmlLabel10"
        Me.Guna2HtmlLabel10.Size = New System.Drawing.Size(111, 23)
        Me.Guna2HtmlLabel10.TabIndex = 21
        Me.Guna2HtmlLabel10.Text = "Cari Pelanggan"
        '
        'btnSearchCustomer
        '
        Me.btnSearchCustomer.BorderRadius = 8
        Me.btnSearchCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSearchCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearchCustomer.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSearchCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSearchCustomer.FillColor = System.Drawing.Color.Chartreuse
        Me.btnSearchCustomer.FillColor2 = System.Drawing.Color.Chartreuse
        Me.btnSearchCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchCustomer.ForeColor = System.Drawing.Color.Black
        Me.btnSearchCustomer.Location = New System.Drawing.Point(678, 3)
        Me.btnSearchCustomer.Name = "btnSearchCustomer"
        Me.btnSearchCustomer.Size = New System.Drawing.Size(76, 26)
        Me.btnSearchCustomer.TabIndex = 21
        Me.btnSearchCustomer.Text = "Cari"
        Me.btnSearchCustomer.TextOffset = New System.Drawing.Point(0, -2)
        '
        'lblTotalService
        '
        Me.lblTotalService.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalService.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalService.ForeColor = System.Drawing.Color.Black
        Me.lblTotalService.Location = New System.Drawing.Point(215, 825)
        Me.lblTotalService.Name = "lblTotalService"
        Me.lblTotalService.Size = New System.Drawing.Size(119, 23)
        Me.lblTotalService.TabIndex = 36
        Me.lblTotalService.Text = "Total Layanan: 0"
        '
        'lblTotalOrder
        '
        Me.lblTotalOrder.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalOrder.ForeColor = System.Drawing.Color.Black
        Me.lblTotalOrder.Location = New System.Drawing.Point(366, 824)
        Me.lblTotalOrder.Name = "lblTotalOrder"
        Me.lblTotalOrder.Size = New System.Drawing.Size(120, 23)
        Me.lblTotalOrder.TabIndex = 37
        Me.lblTotalOrder.Text = "Total Pesanan: 0"
        '
        'lblOrderSystemStatus
        '
        Me.lblOrderSystemStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderSystemStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderSystemStatus.ForeColor = System.Drawing.Color.Black
        Me.lblOrderSystemStatus.Location = New System.Drawing.Point(877, 825)
        Me.lblOrderSystemStatus.Name = "lblOrderSystemStatus"
        Me.lblOrderSystemStatus.Size = New System.Drawing.Size(87, 23)
        Me.lblOrderSystemStatus.TabIndex = 38
        Me.lblOrderSystemStatus.Text = "Status: Siap"
        '
        'btnClearService
        '
        Me.btnClearService.BorderRadius = 8
        Me.btnClearService.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearService.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearService.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearService.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearService.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearService.FillColor = System.Drawing.Color.LightGray
        Me.btnClearService.FillColor2 = System.Drawing.Color.LightGray
        Me.btnClearService.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearService.ForeColor = System.Drawing.Color.Black
        Me.btnClearService.Image = CType(resources.GetObject("btnClearService.Image"), System.Drawing.Image)
        Me.btnClearService.Location = New System.Drawing.Point(155, 131)
        Me.btnClearService.Name = "btnClearService"
        Me.btnClearService.Size = New System.Drawing.Size(119, 35)
        Me.btnClearService.TabIndex = 29
        Me.btnClearService.Text = "Reset"
        Me.btnClearService.TextOffset = New System.Drawing.Point(2, -2)
        '
        'btnAddService
        '
        Me.btnAddService.BorderRadius = 8
        Me.btnAddService.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddService.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddService.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddService.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddService.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddService.FillColor = System.Drawing.Color.Chartreuse
        Me.btnAddService.FillColor2 = System.Drawing.Color.Chartreuse
        Me.btnAddService.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddService.ForeColor = System.Drawing.Color.Black
        Me.btnAddService.Image = CType(resources.GetObject("btnAddService.Image"), System.Drawing.Image)
        Me.btnAddService.Location = New System.Drawing.Point(13, 131)
        Me.btnAddService.Name = "btnAddService"
        Me.btnAddService.Size = New System.Drawing.Size(123, 35)
        Me.btnAddService.TabIndex = 29
        Me.btnAddService.Text = "Simpan"
        Me.btnAddService.TextOffset = New System.Drawing.Point(2, -2)
        '
        'btnSaveOrder
        '
        Me.btnSaveOrder.BorderRadius = 8
        Me.btnSaveOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveOrder.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveOrder.FillColor = System.Drawing.Color.Chartreuse
        Me.btnSaveOrder.FillColor2 = System.Drawing.Color.Chartreuse
        Me.btnSaveOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveOrder.ForeColor = System.Drawing.Color.Black
        Me.btnSaveOrder.Image = CType(resources.GetObject("btnSaveOrder.Image"), System.Drawing.Image)
        Me.btnSaveOrder.Location = New System.Drawing.Point(157, 746)
        Me.btnSaveOrder.Name = "btnSaveOrder"
        Me.btnSaveOrder.Size = New System.Drawing.Size(135, 45)
        Me.btnSaveOrder.TabIndex = 17
        Me.btnSaveOrder.Text = "Simpan"
        Me.btnSaveOrder.TextOffset = New System.Drawing.Point(2, -2)
        '
        'btnResetOrder
        '
        Me.btnResetOrder.BorderRadius = 8
        Me.btnResetOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnResetOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnResetOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnResetOrder.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnResetOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnResetOrder.FillColor = System.Drawing.Color.LightGray
        Me.btnResetOrder.FillColor2 = System.Drawing.Color.LightGray
        Me.btnResetOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetOrder.ForeColor = System.Drawing.Color.Black
        Me.btnResetOrder.Image = CType(resources.GetObject("btnResetOrder.Image"), System.Drawing.Image)
        Me.btnResetOrder.Location = New System.Drawing.Point(646, 746)
        Me.btnResetOrder.Name = "btnResetOrder"
        Me.btnResetOrder.Size = New System.Drawing.Size(135, 45)
        Me.btnResetOrder.TabIndex = 20
        Me.btnResetOrder.Text = "Reset"
        Me.btnResetOrder.TextOffset = New System.Drawing.Point(2, -2)
        '
        'btnUpdateOrder
        '
        Me.btnUpdateOrder.BorderRadius = 8
        Me.btnUpdateOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdateOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnUpdateOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdateOrder.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnUpdateOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnUpdateOrder.FillColor = System.Drawing.Color.CornflowerBlue
        Me.btnUpdateOrder.FillColor2 = System.Drawing.Color.DodgerBlue
        Me.btnUpdateOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateOrder.ForeColor = System.Drawing.Color.Black
        Me.btnUpdateOrder.Image = CType(resources.GetObject("btnUpdateOrder.Image"), System.Drawing.Image)
        Me.btnUpdateOrder.ImageOffset = New System.Drawing.Point(-2, 0)
        Me.btnUpdateOrder.Location = New System.Drawing.Point(321, 746)
        Me.btnUpdateOrder.Name = "btnUpdateOrder"
        Me.btnUpdateOrder.Size = New System.Drawing.Size(135, 45)
        Me.btnUpdateOrder.TabIndex = 18
        Me.btnUpdateOrder.Text = "Edit"
        Me.btnUpdateOrder.TextFormatNoPrefix = True
        Me.btnUpdateOrder.TextOffset = New System.Drawing.Point(-1, -2)
        '
        'btnDeleteOrder
        '
        Me.btnDeleteOrder.BorderRadius = 8
        Me.btnDeleteOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteOrder.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteOrder.FillColor = System.Drawing.Color.Red
        Me.btnDeleteOrder.FillColor2 = System.Drawing.Color.Red
        Me.btnDeleteOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteOrder.ForeColor = System.Drawing.Color.Black
        Me.btnDeleteOrder.Image = CType(resources.GetObject("btnDeleteOrder.Image"), System.Drawing.Image)
        Me.btnDeleteOrder.Location = New System.Drawing.Point(483, 746)
        Me.btnDeleteOrder.Name = "btnDeleteOrder"
        Me.btnDeleteOrder.Size = New System.Drawing.Size(135, 45)
        Me.btnDeleteOrder.TabIndex = 19
        Me.btnDeleteOrder.Text = "Hapus"
        Me.btnDeleteOrder.TextOffset = New System.Drawing.Point(2, -2)
        '
        'Guna2ImageButton1
        '
        Me.Guna2ImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ImageButton1.CheckedState.ImageSize = New System.Drawing.Size(64, 64)
        Me.Guna2ImageButton1.HoverState.ImageSize = New System.Drawing.Size(64, 64)
        Me.Guna2ImageButton1.Image = CType(resources.GetObject("Guna2ImageButton1.Image"), System.Drawing.Image)
        Me.Guna2ImageButton1.ImageOffset = New System.Drawing.Point(0, 0)
        Me.Guna2ImageButton1.ImageRotate = 0!
        Me.Guna2ImageButton1.ImageSize = New System.Drawing.Size(120, 120)
        Me.Guna2ImageButton1.Location = New System.Drawing.Point(26, 8)
        Me.Guna2ImageButton1.Name = "Guna2ImageButton1"
        Me.Guna2ImageButton1.PressedState.ImageSize = New System.Drawing.Size(64, 64)
        Me.Guna2ImageButton1.Size = New System.Drawing.Size(144, 111)
        Me.Guna2ImageButton1.TabIndex = 7
        '
        'FrmOrder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1028, 859)
        Me.Controls.Add(Me.lblOrderSystemStatus)
        Me.Controls.Add(Me.lblTotalOrder)
        Me.Controls.Add(Me.lblTotalService)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlSidebarServices)
        Me.Name = "FrmOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delica Laundry Services - Transaksi Pesanan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSidebarServices.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.numTransportFee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOrderDetail.ResumeLayout(False)
        Me.pnlOrderDetail.PerformLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2CustomGradientPanel1.ResumeLayout(False)
        Me.Guna2CustomGradientPanel1.PerformLayout()
        Me.pnlOrderForm.ResumeLayout(False)
        Me.pnlOrderForm.PerformLayout()
        Me.pnlSearchCustomer.ResumeLayout(False)
        Me.pnlSearchCustomer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSidebarServices As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents Guna2Button7 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2ImageButton1 As Guna.UI2.WinForms.Guna2ImageButton
    Friend WithEvents Guna2TileButton1 As Guna.UI2.WinForms.Guna2TileButton
    Friend WithEvents Guna2Button6 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button5 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMasterUser As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMasterService As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMasterCustomer As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel8 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents pnlContent As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents lblTitleOrder As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents pnlOrderForm As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtOrderNo As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel7 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dtpOrderDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents cmbStaff As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cmbCustomer As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbOrderStatus As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents pnlOrderDetail As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents cmbService As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel6 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel9 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel11 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel12 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel13 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents pnlSearchCustomer As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents txtSearchCustomer As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel10 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnSearchCustomer As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btnSaveOrder As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btnResetOrder As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btnUpdateOrder As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btnDeleteOrder As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btnClearService As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btnAddService As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents nudQuantity As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents txtUnitPrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtSubtotal As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtPricingType As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents chkExpress As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents dgvOrderDetail As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2HtmlLabel14 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblGrandTotal As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblGrandTotalTitle As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents numTransportFee As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents lblTotalService As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblTotalOrder As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblOrderSystemStatus As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblUnit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnAntarJemput As Guna.UI2.WinForms.Guna2Button
End Class
