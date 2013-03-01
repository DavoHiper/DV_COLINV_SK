Public Class frmInfoInv

    ' Variaveis Globais do Form 
    Public mnPRESETInv As Integer
    Public mnPRESETArea As Integer
    Public mnPRESETLoja As Integer
    Public mnPRESETCont As Integer
    Public mnLengthID As Integer
    Public sAssemlyVersion As String = Trim(System.Reflection.Assembly.GetExecutingAssembly.FullName.Split(",")(1).Replace("Version=", ""))

    Private Function TrapKey(ByVal KCode As String) As Boolean
        If (KCode >= 48 And KCode <= 57) Or KCode = 8 Or KCode = 13 Then
            TrapKey = False
        Else
            TrapKey = True
        End If
    End Function

    Sub Finaliza()
        Me.Close()
    End Sub

    Private Sub frmInicio_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        arTASK.Initialize()
        arSCAN.Initialize()
        Me.Text = sAssemlyVersion & "  Inicio "
        txtTagID.Enabled = True
        txtTagID.Text = ""
        txtLoja.Enabled = True
        txtLoja.Text = ""
        txtInventario.Enabled = True
        txtInventario.Text = ""
        txtArea.Enabled = True
        txtArea.Text = ""
        txtContador.Enabled = True
        txtContador.Text = ""
        Me.txtTagID.Focus()

    End Sub

    Private Sub frmInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtTagID.Focus()
            cmdProximo_Click(sender, e)
        End If

    End Sub

    Private Sub Inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lojas, TiposContagens As New ArrayList()
        ArquivoProdutos = "\BACKUP\DAVO\COLINV\IN\PRODUTOS.TXT"
        ' ArquivoInventario = "BACKUP\DAVO\OUT\TASK.TXT"
        szHWID = System.Net.Dns.GetHostName() ' Recupera Device Name 
        lblHWID.Text = "Coletor : " & szHWID
        arTASK.Initialize()
        arSCAN.Initialize()
        Me.txtTagID.Focus()

        If szHWID = "WindowsCE" Then
            MsgBox("Nome do Dispositivo está Incorreto, contate a equipe Funcional ou Help Desk para mais informações!", MsgBoxStyle.OkOnly)
            Me.Close()
        End If


    End Sub

    Private Sub txtTagID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTagID.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        End If
    End Sub

    Private Sub txtTagID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTagID.LostFocus

        mnLengthID = txtTagID.Text.Length

        If ((mnLengthID = 12) Or (mnLengthID = 0)) Then

            If (mnLengthID = 12) Then

                szTagOpen = txtTagID.Text

                mnPRESETLoja = CInt(txtTagID.Text.Substring(0, 2))
                mnPRESETInv = CInt(txtTagID.Text.Substring(2, 5))
                mnPRESETArea = CInt(txtTagID.Text.Substring(7, 3))
                mnPRESETCont = CInt(txtTagID.Text.Substring(10, 1))
                mnTagAction = CInt(txtTagID.Text.Substring(11, 1))

                If mnTagAction = 1 Then

                    szTagClose = txtTagID.Text.Substring(0, 11) & "2"
                    txtLoja.Text = mnPRESETLoja
                    txtInventario.Text = mnPRESETInv
                    txtArea.Text = mnPRESETArea
                    txtContador.Text = mnPRESETCont

                    txtLoja.Enabled = False
                    txtInventario.Enabled = False
                    txtArea.Enabled = False
                    txtContador.Enabled = False
                    cmdProximo.Focus()

                Else : MsgBox("Tag não é de abertura", MsgBoxStyle.OkOnly)
                    txtTagID.Text = ""
                    txtTagID.Focus()

                End If

            End If

        Else ' ERRO !!!! 
            MsgBox("Tamanho Invalido ")
            txtLoja.Enabled = True
            txtInventario.Enabled = True
            txtArea.Enabled = True
            txtContador.Enabled = True
            Me.txtTagID.Focus()
        End If

    End Sub

    Private Sub cmdProximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmdProximo.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmdProximo_Click(sender, e)
        End If

    End Sub

    Private Sub cmdSair_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmdSair.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmdSair_Click(sender, e)
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click

        'Me.Close()
        frmInicio.Show()

    End Sub

    Private Sub cmdProximo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProximo.Click

        If txtLoja.Text <> "" Then
            mnFilial = CInt(txtLoja.Text)
        Else : mnFilial = 0
        End If
        If txtInventario.Text <> "" Then
            mnInventario = CInt(txtInventario.Text)
        Else : mnInventario = 0
        End If

        If txtArea.Text <> "" Then
            mnArea = CInt(txtArea.Text)
        Else : mnArea = 0
        End If

        If txtContador.Text <> "" Then
            mnContador = CInt(txtContador.Text)
        Else : mnContador = 0
        End If

        If ((mnFilial <> 0) And (mnInventario <> 0) And (mnArea <> 0) And (mnContador <> 0)) Then

            ' txtTagID.Focus()
            txtLoja.Enabled = True
            txtInventario.Enabled = True
            txtArea.Enabled = True
            txtContador.Enabled = True

            System.Array.Clear(arSCAN, 0, arSCAN.Length - 1)
            frmInventario.ShowDialog()
            frmInventario.txtCodigo.Focus()
            txtTagID.Focus()
        Else
            MsgBox("Verifique os valores informados ", MsgBoxStyle.Information)
            txtTagID.Text = ""
            txtLoja.Text = ""
            txtInventario.Text = ""
            txtArea.Text = ""
            txtContador.Text = ""
            txtTagID.Focus()
        End If

    End Sub

    Private Sub txtTagID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTagID.TextChanged

    End Sub

    Private Sub txtLoja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoja.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        End If
    End Sub

    Private Sub txtLoja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoja.TextChanged

    End Sub

    Private Sub txtInventario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInventario.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        End If
    End Sub

    Private Sub txtContador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContador.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        End If
    End Sub

    Private Sub txtArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArea.KeyPress
        e.Handled = TrapKey(Asc(e.KeyChar))
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Finaliza()
        End If
    End Sub


End Class