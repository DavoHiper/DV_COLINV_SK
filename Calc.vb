Public Class Calc

    Inherits System.Windows.Forms.Form
    Dim copia As String
    Dim operando1, operando2 As Double
    Dim operador As Char
    Dim m As Double = 0

    Private Sub Calc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDisplay.Text = ""
        txtDisplay.Focus()
        operando1 = 0
        operando2 = 0

    End Sub

    Private Sub txtDisplay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDisplay.KeyDown

        vCalc = 0

        If e.KeyCode.ToString = "Escape" Then
            Finaliza()
        End If

        If e.KeyCode.ToString = "Up" Then
            operando1 = Val(txtDisplay.Text)
            operador = "+"
            LimpaExibicao()
        End If

        If e.KeyCode.ToString = "Down" Then
            operando1 = Val(txtDisplay.Text)
            operador = "-"
            LimpaExibicao()
        End If

        If e.KeyCode.ToString = "Left" Then
            operando1 = Val(txtDisplay.Text)
            operador = "*"
            LimpaExibicao()
        End If

        If e.KeyCode.ToString = "Right" Then
            operando1 = Val(txtDisplay.Text)
            operador = "/"
            LimpaExibicao()
        End If

    End Sub

    Sub Finaliza()
        Me.Close()
    End Sub

    Sub LimpaExibicao()
        txtDisplay.Text = ""
        txtDisplay.Focus()
    End Sub

    Private Sub btnFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub btnOpSoma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpSoma.Click
        operando1 = Val(txtDisplay.Text)
        operador = "+"
        LimpaExibicao()
    End Sub

    Private Sub btnOpSubtracao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpSubtracao.Click
        operando1 = Val(txtDisplay.Text)
        operador = "-"
        LimpaExibicao()
    End Sub

    Private Sub btnOpMultiplicacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpMultiplicacao.Click
        operando1 = Val(txtDisplay.Text)
        operador = "*"
        LimpaExibicao()
    End Sub

    Private Sub btnOpDivisao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpDivisao.Click
        operando1 = Val(txtDisplay.Text)
        operador = "/"
        LimpaExibicao()
    End Sub

    Private Sub btnOpIgual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpIgual.Click
        Dim resultado As Double
        operando2 = Val(txtDisplay.Text)
        Select Case operador
            Case "+"
                resultado = operando1 + operando2
            Case "-"
                resultado = operando1 - operando2
            Case "*"
                resultado = operando1 * operando2
            Case "/"
                If operando2 <> "0" Then
                    resultado = operando1 / operando2
                Else
                    txtDisplay.Text = "Não posso dividir por zero."
                    LimpaExibicao()
                    Exit Sub
                End If
        End Select
        txtDisplay.Text = resultado
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        If txtDisplay.Text = "" Then
            MsgBox("Para Fechar a Calculadora com o Diplay em Branco Pressione F4!", MsgBoxStyle.OkOnly)
            txtDisplay.Focus()
        Else
            vCalc = txtDisplay.Text
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        txtDisplay.Text = ""
        operando1 = 0
        operando2 = 0
        txtDisplay.Focus()

    End Sub

End Class