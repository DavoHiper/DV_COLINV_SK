<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventario
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQtde = New System.Windows.Forms.TextBox
        Me.chkFix = New System.Windows.Forms.CheckBox
        Me.lblUltimo = New System.Windows.Forms.Label
        Me.lstUltLidos = New System.Windows.Forms.ListBox
        Me.lblTimeINI = New System.Windows.Forms.Label
        Me.lstUltTmp = New System.Windows.Forms.ListBox
        Me.lblProduto = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.AcceptsReturn = True
        Me.txtCodigo.AcceptsTab = True
        Me.txtCodigo.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodigo.Location = New System.Drawing.Point(8, 20)
        Me.txtCodigo.MaxLength = 14
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(217, 32)
        Me.txtCodigo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 19)
        Me.Label4.Text = "Qtde:"
        '
        'txtQtde
        '
        Me.txtQtde.AcceptsReturn = True
        Me.txtQtde.AcceptsTab = True
        Me.txtQtde.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtde.Location = New System.Drawing.Point(48, 95)
        Me.txtQtde.MaxLength = 11
        Me.txtQtde.Name = "txtQtde"
        Me.txtQtde.Size = New System.Drawing.Size(119, 32)
        Me.txtQtde.TabIndex = 2
        '
        'chkFix
        '
        Me.chkFix.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.chkFix.Location = New System.Drawing.Point(173, 95)
        Me.chkFix.Name = "chkFix"
        Me.chkFix.Size = New System.Drawing.Size(50, 20)
        Me.chkFix.TabIndex = 3
        Me.chkFix.Text = "Fixar"
        '
        'lblUltimo
        '
        Me.lblUltimo.Location = New System.Drawing.Point(3, 148)
        Me.lblUltimo.Name = "lblUltimo"
        Me.lblUltimo.Size = New System.Drawing.Size(199, 29)
        '
        'lstUltLidos
        '
        Me.lstUltLidos.Location = New System.Drawing.Point(8, 131)
        Me.lstUltLidos.Name = "lstUltLidos"
        Me.lstUltLidos.Size = New System.Drawing.Size(216, 130)
        Me.lstUltLidos.TabIndex = 9
        '
        'lblTimeINI
        '
        Me.lblTimeINI.Location = New System.Drawing.Point(124, -2)
        Me.lblTimeINI.Name = "lblTimeINI"
        Me.lblTimeINI.Size = New System.Drawing.Size(20, 20)
        Me.lblTimeINI.Visible = False
        '
        'lstUltTmp
        '
        Me.lstUltTmp.Location = New System.Drawing.Point(96, 213)
        Me.lstUltTmp.Name = "lstUltTmp"
        Me.lstUltTmp.Size = New System.Drawing.Size(19, 18)
        Me.lstUltTmp.TabIndex = 13
        Me.lstUltTmp.Visible = False
        '
        'lblProduto
        '
        Me.lblProduto.BackColor = System.Drawing.SystemColors.Window
        Me.lblProduto.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblProduto.Location = New System.Drawing.Point(9, 55)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(215, 32)
        '
        'frmInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblProduto)
        Me.Controls.Add(Me.lstUltTmp)
        Me.Controls.Add(Me.lblTimeINI)
        Me.Controls.Add(Me.lstUltLidos)
        Me.Controls.Add(Me.lblUltimo)
        Me.Controls.Add(Me.chkFix)
        Me.Controls.Add(Me.txtQtde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventario"
        Me.Text = "Inventário"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQtde As System.Windows.Forms.TextBox
    Friend WithEvents chkFix As System.Windows.Forms.CheckBox
    Friend WithEvents lblUltimo As System.Windows.Forms.Label
    Friend WithEvents lstUltLidos As System.Windows.Forms.ListBox
    'Friend WithEvents beepSuccess As datalogic.device.Beeper
    Friend WithEvents lblTimeINI As System.Windows.Forms.Label
    Friend WithEvents lstUltTmp As System.Windows.Forms.ListBox
    Friend WithEvents lblProduto As System.Windows.Forms.Label
End Class
