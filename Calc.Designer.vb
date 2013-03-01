<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Calc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calc))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOpSoma = New System.Windows.Forms.Button
        Me.btnOpSubtracao = New System.Windows.Forms.Button
        Me.btnOpMultiplicacao = New System.Windows.Forms.Button
        Me.btnOpDivisao = New System.Windows.Forms.Button
        Me.btnOpIgual = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnCopiar = New System.Windows.Forms.Button
        Me.btnFechar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtDisplay
        '
        Me.txtDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisplay.BackColor = System.Drawing.Color.White
        Me.txtDisplay.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtDisplay.Location = New System.Drawing.Point(16, 6)
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(207, 37)
        Me.txtDisplay.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 220)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(75, 220)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(140, 220)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(198, 220)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(75, 251)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(16, 251)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(198, 251)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(25, 25)
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(140, 251)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(25, 25)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 21)
        Me.Label1.Text = "----- Operadores no Teclado -------"
        '
        'btnOpSoma
        '
        Me.btnOpSoma.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpSoma.Location = New System.Drawing.Point(16, 50)
        Me.btnOpSoma.Name = "btnOpSoma"
        Me.btnOpSoma.Size = New System.Drawing.Size(40, 40)
        Me.btnOpSoma.TabIndex = 23
        Me.btnOpSoma.Text = "+"
        '
        'btnOpSubtracao
        '
        Me.btnOpSubtracao.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpSubtracao.Location = New System.Drawing.Point(72, 50)
        Me.btnOpSubtracao.Name = "btnOpSubtracao"
        Me.btnOpSubtracao.Size = New System.Drawing.Size(40, 40)
        Me.btnOpSubtracao.TabIndex = 24
        Me.btnOpSubtracao.Text = "-"
        '
        'btnOpMultiplicacao
        '
        Me.btnOpMultiplicacao.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpMultiplicacao.Location = New System.Drawing.Point(128, 50)
        Me.btnOpMultiplicacao.Name = "btnOpMultiplicacao"
        Me.btnOpMultiplicacao.Size = New System.Drawing.Size(40, 40)
        Me.btnOpMultiplicacao.TabIndex = 25
        Me.btnOpMultiplicacao.Text = "x"
        '
        'btnOpDivisao
        '
        Me.btnOpDivisao.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpDivisao.Location = New System.Drawing.Point(183, 50)
        Me.btnOpDivisao.Name = "btnOpDivisao"
        Me.btnOpDivisao.Size = New System.Drawing.Size(40, 40)
        Me.btnOpDivisao.TabIndex = 26
        Me.btnOpDivisao.Text = "/"
        '
        'btnOpIgual
        '
        Me.btnOpIgual.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnOpIgual.Location = New System.Drawing.Point(128, 96)
        Me.btnOpIgual.Name = "btnOpIgual"
        Me.btnOpIgual.Size = New System.Drawing.Size(95, 48)
        Me.btnOpIgual.TabIndex = 27
        Me.btnOpIgual.Text = "="
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.Location = New System.Drawing.Point(16, 96)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(96, 48)
        Me.btnClear.TabIndex = 30
        Me.btnClear.Text = "C"
        '
        'btnCopiar
        '
        Me.btnCopiar.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnCopiar.Location = New System.Drawing.Point(16, 150)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(96, 48)
        Me.btnCopiar.TabIndex = 31
        Me.btnCopiar.Text = "Copiar"
        '
        'btnFechar
        '
        Me.btnFechar.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnFechar.Location = New System.Drawing.Point(128, 150)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(95, 48)
        Me.btnFechar.TabIndex = 32
        Me.btnFechar.Text = "Fechar"
        '
        'Calc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnCopiar)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnOpIgual)
        Me.Controls.Add(Me.btnOpDivisao)
        Me.Controls.Add(Me.btnOpMultiplicacao)
        Me.Controls.Add(Me.btnOpSubtracao)
        Me.Controls.Add(Me.btnOpSoma)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtDisplay)
        Me.Name = "Calc"
        Me.Text = "Calculadora"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOpSoma As System.Windows.Forms.Button
    Friend WithEvents btnOpSubtracao As System.Windows.Forms.Button
    Friend WithEvents btnOpMultiplicacao As System.Windows.Forms.Button
    Friend WithEvents btnOpDivisao As System.Windows.Forms.Button
    Friend WithEvents btnOpIgual As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents btnFechar As System.Windows.Forms.Button
End Class
