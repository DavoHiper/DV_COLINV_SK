Imports System
Imports System.IO
Imports System.Text
Imports System.InvalidCastException
Imports System.InvalidOperationException
Imports System.InvalidProgramException
Imports System.NotSupportedException
Imports System.Diagnostics
Imports System.Reflection
Imports System.Windows.Forms.ListBox
Imports System.Math 'para função round

Public Class frmInventario

    Private Function TrapKey(ByVal KCode As String) As Boolean

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "TrapKey")
            Err.Clear()
            Resume Next
        End If

        If (KCode >= 48 And KCode <= 57) Or KCode = 8 Or KCode = 13 Then
            TrapKey = False
        Else
            TrapKey = True
        End If

    End Function

    Sub fAppendArray()

        mnCon = mnCon + 1

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "fAppendArray")
            Err.Clear()
            Resume Next
        End If

        If Trim(txtCodigo.TextLength) > 0 And Trim(txtQtde.TextLength) > 0 Then
            UltimoRegistro = ""

            ' Dim CodigoStr As String
            arSCAN(mnSEQ - 1).iHWID = szHWID
            arSCAN(mnSEQ - 1).iTaskDate = mnTaskDate
            arSCAN(mnSEQ - 1).iTASKID = mnTaskID
            arSCAN(mnSEQ - 1).iSEQ = mnSEQ
            arSCAN(mnSEQ - 1).iSEQLst = arSCAN(mnSEQ - 1).iSEQ
            szNroIt = arSCAN(mnSEQ - 1).iSEQLst
            szNroIt = szNroIt.PadLeft(3, "0")
            arSCAN(mnSEQ - 1).iSEQLst = szNroIt
            If mnTpSKU = 2 Then
                arSCAN(mnSEQ - 1).iSCAN = CInt(szSKU.Substring(1, 5))
                mnPRICE = CInt(szSKU.Substring(7, 5))
            ElseIf mnTpSKU = 1 Then
                arSCAN(mnSEQ - 1).iSCAN = CInt(szSKU.Substring(1, 5))
                mnWEIGHT = 10 * CInt(szSKU.Substring(7, 4))
            Else
                arSCAN(mnSEQ - 1).iSCAN = szSKU

            End If
            arSCAN(mnSEQ - 1).iDESC = szDESC
            arSCAN(mnSEQ - 1).iQT = System.Math.Round(Double.Parse(txtQtde.Text * Precisao), 0)
            If mnTpSKU = 1 Then
                arSCAN(mnSEQ - 1).iQT = mnWEIGHT
                arSCAN(mnSEQ - 1).iTPSKU = 2
                arSCAN(mnSEQ - 1).iPRICE = 0
            ElseIf mnTpSKU = 2 Then
                arSCAN(mnSEQ - 1).iPRICE = mnPRICE
                arSCAN(mnSEQ - 1).iTPSKU = 1
            Else
                arSCAN(mnSEQ - 1).iPRICE = 0
                arSCAN(mnSEQ - 1).iTPSKU = 0
            End If
            szProduto = arSCAN(mnSEQ - 1).iSCAN
            mnSEQ = 1 + mnSEQ

            PreencheLista()

            txtCodigo.Text = ""
            If chkFix.Checked = False Then
                txtQtde.Text = ""
            End If
        Else
            MsgBox("Leia ou Digite o Código de Barras e Preecha a Quantidade")
        End If

        txtCodigo.Focus()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Funcao", "fAppendArray")
        End If

    End Sub

    Sub fOutputText()

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "fOutputText")
            Err.Clear()
            Resume Next
        End If

        'Calling the function

        If Not bOutputted Then

            bOutputted = True

            Dim szDLM As Char = "|"

            With arTASK
                mnStatus = 0
                wTASK = arTASK(0)
                flOutput.WriteLine("TASK#" & wTASK.iHWID & szDLM _
                                           & wTASK.iTaskDate & szDLM _
                                           & wTASK.iTASKID & szDLM _
                                           & wTASK.iAction & szDLM _
                                           & wTASK.iStore & szDLM _
                                           & wTASK.iInvNum & szDLM _
                                           & wTASK.iInvArea & szDLM _
                                           & wTASK.iOrdCount & szDLM _
                                           & mnTStampINI & szDLM _
                                           & mnStatus)

                With arSCAN
                    For iLine As Integer = 0 To (.Length - 1)
                        wSCAN = arSCAN(iLine)
                        If Not wSCAN.iHWID = "" Then

                            flOutput.WriteLine("COL#" & wSCAN.iHWID & szDLM _
                                                      & wSCAN.iTaskDate & szDLM _
                                                      & wSCAN.iTASKID & szDLM _
                                                      & wSCAN.iSEQ & szDLM _
                                                      & wSCAN.iSCAN & szDLM _
                                                      & wSCAN.iQT & szDLM _
                                                      & wSCAN.iTPSKU & szDLM _
                                                      & wSCAN.iPRICE)
                        End If
                    Next
                End With

                wTASK = arTASK(1)
                flOutput.WriteLine("TASK#" & wTASK.iHWID & szDLM _
                                           & wTASK.iTaskDate & szDLM _
                                           & wTASK.iTASKID & szDLM _
                                           & wTASK.iAction & szDLM _
                                           & wTASK.iStore & szDLM _
                                           & wTASK.iInvNum & szDLM _
                                           & wTASK.iInvArea & szDLM _
                                           & wTASK.iOrdCount & szDLM _
                                           & mnTStampFIM & szDLM _
                                           & mnStatus)

            End With

        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Funcao", "fOutputText")
        End If

    End Sub

    Sub Finaliza()

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "Finaliza")
            Err.Clear()
            Resume Next
        End If

        Me.Close()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Funcao", "Finaliza")
        End If

    End Sub

    Private Sub frmInventario_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "frmInventario", "Closed")
            Err.Clear()
            Resume Next
        End If

        frmInfoInv.txtTagID.Focus()
        cmdColSair_Click(sender, e)
        frmInfoInv.txtTagID.Focus()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "frmInventario", "Closed")
        End If

    End Sub

    Private Sub Inventario_FRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtNOW = Format(Now, "yyyyMMdd")

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Inventario_FRM", "Load")
            Err.Clear()
            Resume Next
        End If

            Dim dtTODAY As Date = DateSerial(Now.Year, Now.Month, Now.Day)


            lstUltLidos.Items.Clear()
            arTASK.Initialize()

            bOutputted = False

        'mnTStampINI = System.DateTime.Now.ToString("yyyyMMddHHmmss")

        'mnTaskDate = System.DateTime.Now.ToString("yyyyMMdd")
            mnTaskID = DateDiff(DateInterval.Second, dtTODAY, Now())

        ArquivoInventario = "\BACKUP\DAVO\COLINV\OUT\TASK" & dtNOW & "-" & mnTaskID.ToString.PadLeft(6, "0") & "-" & mnInventario.ToString.PadLeft(5, "0") & "-" & mnArea.ToString.PadLeft(3, "0") & "-" & mnContador & ".TXT"

            lblTimeINI.Text = "Tarefa : " & Trim(mnTaskID)

            mnSEQ = 1

            arTASK(0).iHWID = szHWID
            arTASK(0).iTaskDate = mnTaskDate
            arTASK(0).iTASKID = mnTaskID
            arTASK(0).iAction = "A"
            arTASK(0).iStore = mnFilial
            arTASK(0).iInvNum = mnInventario
            arTASK(0).iInvArea = mnArea
            arTASK(0).iOrdCount = mnContador
            arTASK(0).iTimeStamp = mnTStampINI
            arTASK(0).iTASKID = mnTaskID

            flOutput = System.IO.File.AppendText(ArquivoInventario)

            Delim = "|"
            Precisao = 100
            ' Altera o titulo para a contagem vigente
            Me.Text = "F" & mnFilial & " I" & mnInventario & " A" & mnArea & " T" & mnContador

        txtCodigo.Text = ""
        txtQtde.Text = ""
        lblUltimo.Text = ""
        chkFix.Checked = False

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Inventario_FRM", "Load")
        End If

    End Sub

    Private Sub chkFix_CheckStateChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFix.CheckStateChanged

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "chkFix", "CheckStateChanged")
            Err.Clear()
            Resume Next
        End If

        chkFix_Click(sender, e)

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "chkFix", "CheckStateChanged")
        End If

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "txtCodigo", "KeyDown")
            Err.Clear()
            Resume Next
        End If

        e.Handled = TrapKey(Asc(e.KeyValue))

    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "txtCodigo", "TextChanged")
            Err.Clear()
            Resume Next
        End If

        szSKU = Trim(txtCodigo.Text)
        ' beepSuccess.Beep()
    End Sub

    Private Sub Codigo_TXB_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Codigo_TXB", "KeyPress")
            Err.Clear()
            Resume Next
        End If

        Dim achou As Boolean
        Dim index As Integer

        Select Case e.KeyChar

            Case Convert.ToChar(Keys.Return) 'ChrW(Keys.Return)

                e.Handled = True

                txtQtde.Focus()

        End Select

        e.Handled = TrapKey(Asc(e.KeyChar))

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            If Trim(txtCodigo.TextLength) = 0 And Me.Visible = True Then
                MsgBox("Código do Produto em branco")
                txtCodigo.Focus()
                Exit Sub
            End If

            If System.IO.File.Exists(ArquivoProdutos) = True Then
                ' Open file.txt with the Using statement.
                Using r As StreamReader = New StreamReader(ArquivoProdutos)
                    ' Store contents in this String.
                    Dim line As String
                    ' Read first line.
                    line = r.ReadLine
                    ' Loop over each line in file, While list is Not Nothing.
                    achou = False
                    Do While (Not line Is Nothing)
                        index = line.ToString.IndexOf(Delim, 1)
                        ' Read in the next line.
                        'Busca por posicao fixa
                        'If Mid(UCase(line.ToString), 1, 13) = Mid(txtCodigo.Text, 1, 13) Then
                        'Descricao_TXB.Text = Mid(line, 15, line.Length - 14)

                        'Busca por Delimitador
                        If Mid(line.ToString, 1, index) = txtCodigo.Text Then
                            'txtDescricao.Text = RTrim(Mid(line, index + 2, line.Length - index))
                            achou = True
                            Exit Do
                        End If
                        line = r.ReadLine
                    Loop
                    r.Close()
                End Using
                If achou = False Then
                    'txtDescricao.Text = "PRODUTO NÃO ENCONTRADO"
                End If
                If chkFix.Checked And Trim(txtQtde.Text) <> "" And achou Then
                    fAppendArray()
                Else
                    txtQtde.Focus()
                End If
            End If
            If txtQtde.Enabled <> False Then
                'cmdOK.Focus()
            Else
                txtQtde.Focus()
            End If
        End If

    End Sub

    Private Sub txtCodigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.LostFocus

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "txtCodigo", "LostFocus")
            Err.Clear()
            Resume Next
        End If

        Dim mnSCAN As String

        If Not txtCodigo.Text = "" Then

            If txtCodigo.Text = szTagOpen Then
                MsgBox("Para Fechar a área utilize a TAG de Fechamento!", MsgBoxStyle.OkOnly)
                txtCodigo.Text = ""
                txtCodigo.Focus()

            ElseIf txtCodigo.Text = szTagClose Then

                If MsgBox("Confirma o Fechamento da Área?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    SaveFile()
                    szTagClose = "0"
                Else
                    txtCodigo.Text = ""
                    txtCodigo.Focus()
                End If

            Else
                mnSCAN = CInt(txtCodigo.Text.Substring(0, 1))
                ' SKU + PESO
                If txtCodigo.TextLength.ToString = 13 And mnSCAN = 1 Then
                    txtQtde.Text = 1
                    mnTpSKU = 1
                    fAppendArray()
                    pesquisaProduto(szProduto)
                    txtCodigo.Text = ""
                    txtCodigo.Focus()
                    ' SKU + PREÇO
                ElseIf txtCodigo.TextLength.ToString = 13 And mnSCAN = 2 Then
                    txtQtde.Text = 1
                    mnTpSKU = 2
                    fAppendArray()
                    pesquisaProduto(szProduto)
                    txtCodigo.Text = ""
                    txtCodigo.Focus()
                Else
                    mnTpSKU = 0
                    If txtCodigo.Text = "0" Then
                        MsgBox("Código EAN/DUN incorreto, Reescaneie!", MsgBoxStyle.OkOnly)
                        txtCodigo.Text = ""
                        txtCodigo.Focus()
                    End If

                    If chkFix.Checked And Trim(txtCodigo.Text) <> "" Then
                        fAppendArray()
                        pesquisaProduto(szProduto)
                        txtCodigo.Text = ""
                        txtCodigo.Focus()
                    End If

                    pesquisaProduto(txtCodigo.Text)

                End If

            End If

        ElseIf txtCodigo.Text.Length = 12 Then
            MsgBox("Para fechamento da área scaneie a TAG de fechamento desta área ou continue a contagem desta área!", MsgBoxStyle.OkOnly)
            txtCodigo.Text = ""
            txtCodigo.Focus()

        End If

    End Sub

    Private Sub txtQtde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtde.GotFocus

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "txtQtde", "GotFocus")
            Err.Clear()
            Resume Next
        End If

        If vCalc <> 0 Then
            txtQtde.Text = vCalc
            vCalc = 0
        End If

    End Sub

    Private Sub txtQtde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQtde.KeyDown

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "txtQtde", "KeyDown")
            Err.Clear()
            Resume Next
        End If

        If e.KeyCode.ToString = "Down" _
        Or e.KeyCode.ToString = "Up" _
        Or e.KeyCode.ToString = "Left" _
        Or e.KeyCode.ToString = "Right" Then
            Calc.ShowDialog()
        End If

    End Sub

    Private Sub Qtde_TXB_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtde.KeyPress

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Qtde_TXB", "KeyPress")
            Err.Clear()
            Resume Next
        End If

        Dim i As Integer


        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso e.KeyChar = "," AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        Else
            If e.KeyChar = Convert.ToChar(Keys.Return) And txtQtde.TextLength > 0 Then
                If Trim(txtCodigo.TextLength) = 0 Then
                    MsgBox("Leia ou digite o Código do Produto")
                    Exit Sub
                End If
                fAppendArray()
            ElseIf e.KeyChar = "," Then
                i = 1
                Do While i <= txtQtde.TextLength
                    If Mid(txtQtde.Text, i, 1) = "." Then
                        e.Handled = True
                        Exit Sub
                    End If
                    i = i + 1
                Loop
            End If
        End If

    End Sub

    Private Sub Qtde_TXB_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtde.LostFocus

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Qtde_TXB", "LostFocus")
            Err.Clear()
            Resume Next
        End If

        Dim QtdeL As Single

        'If txtQtde.TextLength > 0 Then
        '    QtdeL = Single.Parse(txtQtde.Text)
        '    txtQtde.Text = QtdeL.ToString("###,##0.#000")
        'End If
        If txtQtde.Text <> "" Then

            If txtCodigo.Text.Substring(0, 11) = txtQtde.Text Then
                txtQtde.Text = ""
                txtQtde.Focus()
            End If

        End If

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "cmdOK", "Click")
            Err.Clear()
            Resume Next
        End If

        If Trim(txtCodigo.TextLength) = 0 Then
            MsgBox("Leia ou digite o Código do Produto")
            txtCodigo.Focus()
            Exit Sub
        ElseIf Trim(txtQtde.TextLength) = 0 Then
            MsgBox("Digite a Quantidade ou Selecione a Opção Automático")
            txtQtde.Focus()
            Exit Sub
        End If
        fAppendArray()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "cmdOK", "Click")
        End If

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("estou no menu item 3")
        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "MenuItem3", "Click")
            Err.Clear()
            Resume Next
        End If

        Dim contents As String
        ' Dim NovaQtde As Double

        Using r As StreamReader = New StreamReader(ArquivoInventario)
            ' Store contents in this String.

            ' Read first line.
            contents = r.ReadToEnd
            contents = Mid(contents, 1, contents.ToString.Length - (UltimoRegistro.ToString.Length + vbCrLf.Length + vbCrLf.Length))
            r.Close()
        End Using

        Dim arquivo As IO.StreamWriter
        arquivo = New IO.StreamWriter(ArquivoInventario, False)
        arquivo.WriteLine(contents)
        arquivo.Close()
        txtCodigo.Text = ""
        If chkFix.Checked = False Then
            txtQtde.Text = ""
        End If
        txtCodigo.Focus()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "MenuItem3", "Click")
        End If

    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "MenuItem4", "Click")
            Err.Clear()
            Resume Next
        End If

        My.Forms.frmInicio.ShowDialog()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "MenuItem4", "Click")
        End If

    End Sub

    Public Function SearchArray(ByRef sArray() As String, ByRef sSearch As String, Optional ByVal Compare As CompareMethod = vbBinaryCompare) As Long

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "SearchArray")
            Err.Clear()
            Resume Next
        End If

        Dim lLow As Long
        Dim lHigh As Long
        Dim sLow As String
        Dim sHigh As String
        Dim lFComp As Long
        Dim lLComp As Long

        On Error Resume Next

        lLow = LBound(sArray)
        lHigh = UBound(sArray)

        sLow = sArray(lLow)
        sHigh = sArray(lHigh)

        lFComp = StrComp(sSearch, sLow, Compare)    'First
        lLComp = StrComp(sSearch, sHigh, Compare)   'Last
        'The StrComp function has the following return values:
        '   -1      String1 sorts ahead of String2
        '    0      String1 is equal to String2
        '    1      String1 sorts after String2

        If lFComp <= 0 Then
            SearchArray = lLow + lFComp     'less than first or equal to first
        ElseIf lLComp >= 0 Then
            SearchArray = lHigh + lLComp    'larger than last or equal to last
        Else                                'in between first and last
            SearchArray = ArrBinarySearch(sArray, sSearch, lLow, lHigh, Compare)
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Funcao", "SearchArray")
        End If

    End Function

    Private Function ArrBinarySearch(ByRef sArray() As String, _
                                     ByRef sSearch As String, _
                                     ByVal lFirst As Long, _
                                     ByVal lLast As Long, _
                                     Optional ByVal Compare As CompareMethod = vbBinaryCompare) As Long

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "ArrBinarySearch")
            Err.Clear()
            Resume Next
        End If

        Dim lMid As Long
        Dim lStrC As Long

        On Error Resume Next
        If lFirst = lLast Then
            ArrBinarySearch = lFirst
        Else
            lMid = (lFirst + lLast) \ 2
            lStrC = StrComp(sSearch, sArray(lMid), Compare)

            Select Case lStrC
                Case -1
                    ArrBinarySearch = ArrBinarySearch(sArray, sSearch, lFirst, lMid)
                Case 0
                    ArrBinarySearch = lMid
                Case 1
                    ArrBinarySearch = ArrBinarySearch(sArray, sSearch, lMid, lLast)
            End Select
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Funcao", "ArrBinarySearch")
        End If

    End Function

    Private Sub chkFix_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFix.Click

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "chkFix", "Click")
            Err.Clear()
            Resume Next
        End If

        If Not chkFix.Checked Then
            ' Habilita quantidade e solicita novo conteudo 
            txtQtde.Enabled = True
            txtQtde.Focus()
            txtQtde.Text = ""
        Else ' Desabilita Quantidade e fixa Qtde = 1 
            txtQtde.Text = 1
            txtQtde.Enabled = False
            txtCodigo.Text = ""
            txtCodigo.Focus()
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "chkFix", "Click")
        End If

    End Sub

    Private Sub chkFix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFix.KeyPress

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "chkFix", "KeyPress")
            Err.Clear()
            Resume Next
        End If

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFix.Checked = True
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "chkFix", "KeyPress")
        End If

    End Sub

    Private Sub cmdOK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "cmdOK", "KeyPress")
            Err.Clear()
            Resume Next
        End If

        Dim i As Integer


        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso e.KeyChar = "," AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        Else
            If e.KeyChar = Convert.ToChar(Keys.Return) And txtQtde.TextLength > 0 Then
                If Trim(txtCodigo.TextLength) = 0 Then
                    MsgBox("Leia ou digite o Código do Produto")
                    Exit Sub
                End If
                fAppendArray()
            ElseIf e.KeyChar = "," Then
                i = 1
                Do While i <= txtQtde.TextLength
                    If Mid(txtQtde.Text, i, 1) = "." Then
                        e.Handled = True
                        Exit Sub
                    End If
                    i = i + 1
                Loop
            End If
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "cmdOK", "KeyPress")
        End If

    End Sub

    Private Sub cmdColSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "cmdColSair", "Click")
            Err.Clear()
            Resume Next
        End If

        SaveFile()

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "cmdColSair", "Click")
        End If

    End Sub

    Sub SaveFile()

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "SaveFile")
            Err.Clear()
            Resume Next
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "Funcao", "SaveFile")
        End If

        mnTStampFIM = System.DateTime.Now.ToString("yyyyMMddHHmmss")

        arTASK(1).iHWID = szHWID
        arTASK(1).iTaskDate = mnTaskDate
        arTASK(1).iTASKID = mnTaskID
        arTASK(1).iAction = "F"
        arTASK(1).iStore = mnFilial
        arTASK(1).iInvNum = mnInventario
        arTASK(1).iInvArea = mnArea
        arTASK(1).iOrdCount = mnContador
        arTASK(1).iTimeStamp = mnTStampFIM

        fOutputText()

        flOutput.Close()
        Me.Close()
    End Sub

    Private Sub cmdColSair_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "cmdColSair", "KeyPress")
            Err.Clear()
            Resume Next
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmdColSair_Click(sender, e)

        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "cmdColSair", "KeyPress")
        End If

    End Sub

    Private Sub lstUltLidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstUltLidos.KeyPress

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "lstUltLidos", "KeyPress")
            Err.Clear()
            Resume Next
        End If

        If Err.Number = 0 Then
            geraLog(0, "ProcressSucessfully", "lstUltLidos", "KeyPress")
        End If

        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            Dim itm As String
            itm = lstUltLidos.SelectedItem.ToString
            itm = itm.Substring(0, 3)
            itm = CInt(itm)
            If MsgBox("Deseja excluir o(s) item(s) selecionado(s)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                arSCAN(itm - 1).iHWID = ""
                PreencheLista()

            End If
        End If
    End Sub

    Sub PreencheLista()

        On Error GoTo Erro

Erro:
        If Err.Number <> 0 Then
            geraLog(Err.Number, Err.Description, "Funcao", "PreencheLista")
            Err.Clear()
            Resume Next
        End If

        Dim szItensLst As String

        'szItensLst = txtCodigo.Text & " | " & txtQtde.Text
        'lstUltTmp.Items.Add(szItensLst)

        lstUltLidos.Items.Clear()

        For mnDelim = mnCon To 0 Step -1

            If Not arSCAN(mnDelim).iHWID = "" Then
                lstUltLidos.Items.Add(arSCAN(mnDelim).iSEQLst & "|" & arSCAN(mnDelim).iSCAN & "|" & arSCAN(mnDelim).iQT)
            End If
        Next

        If Err.Number = 0 Then

            geraLog(0, "ProcressSucessfully", "Funcao", "PreencheLista")

        End If

    End Sub
    'para pesquisa binária
    Public Function ler(ByVal r As Integer, ByVal recSize As Integer)
        'Posiciona cursor no arquivo
        On Error Resume Next

        fn.Seek((r - 1) * recSize, 0)
        If Err.Number <> 0 Then
            lblProduto.Text = "ITEM NÃO CADASTRADO!"
            found = True
            Return r
        Else
            Return r
        End If
    End Function

    Sub pesquisaProduto(ByVal szProduto)

        'descricao do produto, pesquisa binária produto
        Dim Temp As Produto
        Dim currentRecord As Integer = 0
        Dim fileName = "\BACKUP\DAVO\COLINV\IN\Produtos.txt"
        Dim fileSize As Long
        Dim recordCount, r, last, first As Integer
        Dim codItem, codItemCursor As Long
        Dim recSize As Integer

        recSize = 36 + 1 '36 CARACTERES + 1 FILLER

        fn = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        br = New BinaryReader(fn)

        'tamanho do arquivo
        fileSize = fn.Length
        'total de linhas arquivo
        recordCount = (fileSize / recSize)
        'inicializa ultima linha com total de linhas
        last = recordCount
        'inicializa primeira linha com 0
        first = 0
        'r = linha atual, posiciona no meio
        r = Round(last / 2)
        'inicializa found
        found = False
        'posiciona cursor no arquivo 
        ler(r, recSize)

        codItem = szProduto

        While (Not found)

            Temp.EAN = br.ReadChars(14)
            Temp.Descr = br.ReadChars(22)
            codItemCursor = CType(Trim(Temp.EAN), Long)

            If codItem = codItemCursor Then
                found = True
                lblProduto.Text = Temp.Descr
                Exit While
            ElseIf codItem > codItemCursor Then
                first = r
                r = Round((first + last) / 2)
                If (first = r) Then
                    lblProduto.Text = "ITEM NÃO CADASTRADO!"
                    Exit While
                End If
                ler(r, recSize)
            Else
                last = r
                r = Round((first + last) / 2)
                If (last = r) Then
                    lblProduto.Text = "ITEM NÃO CADASTRADO!"
                    Exit While
                End If
                ler(r, recSize)
            End If
        End While
    End Sub

    Private Sub txtQtde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtde.TextChanged
        If Not ValidateNumeric(txtQtde.Text) Then
            txtQtde.Text = ""
        End If
    End Sub

    Private Function ValidateNumeric(ByVal strText As String) _
As Boolean
        ValidateNumeric = CBool(strText = "" _
        Or strText = "-" _
        Or strText = "-." _
        Or strText = "." _
        Or strText = "," _
        Or IsNumeric(strText))
    End Function

End Class