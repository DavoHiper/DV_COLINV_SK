<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoInv
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.Local_LBL = New System.Windows.Forms.Label
        Me.txtInventario = New System.Windows.Forms.TextBox
        Me.lblInventario = New System.Windows.Forms.Label
        Me.cmdProximo = New System.Windows.Forms.Button
        Me.lblArea = New System.Windows.Forms.Label
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.lblContagem = New System.Windows.Forms.Label
        Me.txtTagID = New System.Windows.Forms.TextBox
        Me.lblTagID = New System.Windows.Forms.Label
        Me.txtLoja = New System.Windows.Forms.TextBox
        Me.txtContador = New System.Windows.Forms.TextBox
        Me.cmdSair = New System.Windows.Forms.Button
        Me.lblHWID = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Local_LBL
        '
        Me.Local_LBL.Location = New System.Drawing.Point(26, 77)
        Me.Local_LBL.Name = "Local_LBL"
        Me.Local_LBL.Size = New System.Drawing.Size(42, 19)
        Me.Local_LBL.Text = "Filial:"
        '
        'txtInventario
        '
        Me.txtInventario.AcceptsReturn = True
        Me.txtInventario.AcceptsTab = True
        Me.txtInventario.Location = New System.Drawing.Point(104, 106)
        Me.txtInventario.Name = "txtInventario"
        Me.txtInventario.Size = New System.Drawing.Size(100, 23)
        Me.txtInventario.TabIndex = 3
        '
        'lblInventario
        '
        Me.lblInventario.Location = New System.Drawing.Point(25, 106)
        Me.lblInventario.Name = "lblInventario"
        Me.lblInventario.Size = New System.Drawing.Size(73, 19)
        Me.lblInventario.Text = "Inventario: "
        '
        'cmdProximo
        '
        Me.cmdProximo.Location = New System.Drawing.Point(25, 205)
        Me.cmdProximo.Name = "cmdProximo"
        Me.cmdProximo.Size = New System.Drawing.Size(90, 48)
        Me.cmdProximo.TabIndex = 6
        Me.cmdProximo.Text = "Proximo"
        '
        'lblArea
        '
        Me.lblArea.Location = New System.Drawing.Point(25, 142)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(73, 20)
        Me.lblArea.Text = "Área: "
        '
        'txtArea
        '
        Me.txtArea.AcceptsReturn = True
        Me.txtArea.AcceptsTab = True
        Me.txtArea.Location = New System.Drawing.Point(104, 142)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(100, 23)
        Me.txtArea.TabIndex = 4
        '
        'lblContagem
        '
        Me.lblContagem.Location = New System.Drawing.Point(25, 175)
        Me.lblContagem.Name = "lblContagem"
        Me.lblContagem.Size = New System.Drawing.Size(73, 19)
        Me.lblContagem.Text = "Contagem: "
        '
        'txtTagID
        '
        Me.txtTagID.AcceptsReturn = True
        Me.txtTagID.AcceptsTab = True
        Me.txtTagID.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtTagID.Location = New System.Drawing.Point(62, 48)
        Me.txtTagID.Name = "txtTagID"
        Me.txtTagID.Size = New System.Drawing.Size(142, 19)
        Me.txtTagID.TabIndex = 1
        '
        'lblTagID
        '
        Me.lblTagID.Location = New System.Drawing.Point(26, 45)
        Me.lblTagID.Name = "lblTagID"
        Me.lblTagID.Size = New System.Drawing.Size(30, 20)
        Me.lblTagID.Text = "ID :"
        '
        'txtLoja
        '
        Me.txtLoja.AcceptsReturn = True
        Me.txtLoja.AcceptsTab = True
        Me.txtLoja.Location = New System.Drawing.Point(104, 73)
        Me.txtLoja.Name = "txtLoja"
        Me.txtLoja.Size = New System.Drawing.Size(100, 23)
        Me.txtLoja.TabIndex = 2
        '
        'txtContador
        '
        Me.txtContador.AcceptsReturn = True
        Me.txtContador.AcceptsTab = True
        Me.txtContador.Location = New System.Drawing.Point(104, 171)
        Me.txtContador.Name = "txtContador"
        Me.txtContador.Size = New System.Drawing.Size(100, 23)
        Me.txtContador.TabIndex = 5
        '
        'cmdSair
        '
        Me.cmdSair.Location = New System.Drawing.Point(125, 205)
        Me.cmdSair.Name = "cmdSair"
        Me.cmdSair.Size = New System.Drawing.Size(90, 48)
        Me.cmdSair.TabIndex = 7
        Me.cmdSair.Text = "Sair"
        '
        'lblHWID
        '
        Me.lblHWID.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular)
        Me.lblHWID.Location = New System.Drawing.Point(25, 6)
        Me.lblHWID.Name = "lblHWID"
        Me.lblHWID.Size = New System.Drawing.Size(190, 20)
        '
        'frmInfoInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblHWID)
        Me.Controls.Add(Me.cmdSair)
        Me.Controls.Add(Me.txtContador)
        Me.Controls.Add(Me.txtLoja)
        Me.Controls.Add(Me.lblTagID)
        Me.Controls.Add(Me.txtTagID)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.cmdProximo)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.txtInventario)
        Me.Controls.Add(Me.lblContagem)
        Me.Controls.Add(Me.lblInventario)
        Me.Controls.Add(Me.Local_LBL)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoInv"
        Me.Text = "Inicio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Local_LBL As System.Windows.Forms.Label
    Friend WithEvents txtInventario As System.Windows.Forms.TextBox
    Friend WithEvents lblInventario As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents lblContagem As System.Windows.Forms.Label
    Friend WithEvents txtTagID As System.Windows.Forms.TextBox
    Friend WithEvents lblTagID As System.Windows.Forms.Label
    Friend WithEvents txtLoja As System.Windows.Forms.TextBox
    Friend WithEvents txtContador As System.Windows.Forms.TextBox
    Friend WithEvents cmdSair As System.Windows.Forms.Button
    'Friend WithEvents Device1 As datalogic.device.Device
    'Friend WithEvents Device2 As datalogic.device.Device
    'Friend WithEvents Device3 As datalogic.device.Device
    Friend WithEvents lblHWID As System.Windows.Forms.Label
    Public WithEvents cmdProximo As System.Windows.Forms.Button
    'Friend WithEvents Beeper1 As datalogic.device.Beeper
    'Friend WithEvents Battery1 As datalogic.device.Battery
End Class
