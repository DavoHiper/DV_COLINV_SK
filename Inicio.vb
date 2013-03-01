Imports System.Runtime.InteropServices
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
Imports System.Resources
Imports System.Collections
Imports System.IO.Directory
Imports System.IO.File
Imports System.Windows.Forms
Public Class frmInicio

    <StructLayout(LayoutKind.Sequential)> _
Private Structure SYSTEMTIME
        <MarshalAs(UnmanagedType.U2)> Public Year As Short
        <MarshalAs(UnmanagedType.U2)> Public Month As Short
        <MarshalAs(UnmanagedType.U2)> Public DayOfWeek As Short
        <MarshalAs(UnmanagedType.U2)> Public Day As Short
        <MarshalAs(UnmanagedType.U2)> Public Hour As Short
        <MarshalAs(UnmanagedType.U2)> Public Minute As Short
        <MarshalAs(UnmanagedType.U2)> Public Second As Short
        <MarshalAs(UnmanagedType.U2)> Public Milliseconds As Short
    End Structure

    <DllImport("coredll.dll")> _
Private Shared Sub GetLocalTime(ByRef time As SYSTEMTIME)
    End Sub

    <DllImport("coredll.dll")> _
    Private Shared Function SetLocalTime(ByRef time As SYSTEMTIME) As Boolean
    End Function


    Private Sub frmInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Preenche combo Hora
        Dim h, m, ha, ma As Integer
        Dim hora, min As String

        btnHabilitar.Enabled = True

        'preenche date picker
        Try
            dtCalendario.Value = System.DateTime.Now.ToString("dd/MM/yyyy")
        Catch ex As Exception
            dtCalendario.Value = System.DateTime.Now.ToString("yyyy/MM/dd")
        End Try


        'posiciona cursor
        txtOperador.Focus()

        'desabilita botao para iniciar inventario
        'btnInicio.Enabled = False

        lblOperadorNome.Text = "Sem Operador!"


        For h = 1 To 24
            ha = System.DateTime.Now.ToString("HH")

            If h < 10 Then
                hora = "0" & h
            Else
                hora = h
            End If
            cmbHora.Items.Add(hora)

            If ha = h Then
                If h < 10 Then
                    hora = "0" & h
                Else
                    hora = h
                End If
                cmbHora.SelectedItem = hora
            End If
        Next

        'Preenche combo Minuto
        For m = 0 To 59
            ma = System.DateTime.Now.ToString("mm")
            If m < 10 Then
                min = "0" & m
            Else
                min = m
            End If
            cmbMinuto.Items.Add(min)

            If ma = m Then
                If m < 10 Then
                    min = "0" & m
                Else
                    min = m
                End If
                cmbMinuto.SelectedItem = min
            End If

        Next

    End Sub

    Private Sub btnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicio.Click
        Dim currentTime As SYSTEMTIME

        'Valida data
        mnTaskDate = Format(dtCalendario.Value, "yyyyMMdd")

        mnTStampINI = mnTaskDate & cmbHora.Text & cmbMinuto.Text & "00"

        If btnHabilitar.Enabled = False Then

            GetLocalTime(currentTime)

            currentTime.Year = Format(dtCalendario.Value, "yyyy")
            currentTime.Month = Format(dtCalendario.Value, "MM")
            currentTime.Day = Format(dtCalendario.Value, "dd")
            currentTime.Hour = CInt(cmbHora.Text)
            currentTime.Minute = CInt(cmbMinuto.Text)

            SetLocalTime(currentTime)

        End If

        frmInfoInv.Show()

    End Sub

    Private Sub btnHabilitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHabilitar.Click

        btnHabilitar.Enabled = False
        dtCalendario.Enabled = True
        cmbHora.Enabled = True
        cmbMinuto.Enabled = True
        dtCalendario.Focus()

    End Sub

    Private Sub txtOperador_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador.LostFocus
        If txtOperador.Text <> "" Then

            pesquisaOperador()

        End If

    End Sub

    Sub pesquisaOperador()
        'pesquisa binária para operador
        Dim Temp As Operador
        Dim found As Boolean
        Dim currentRecord As Integer = 0
        Dim fileName = "\BACKUP\DAVO\IN\Operadores.txt"
        Dim fileSize As Long
        Dim recordCount, r, last, first As Integer
        Dim codOpeCursor As Long
        Dim recSize As Integer
        Dim codOpe As String

        recSize = 58 + 1

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

        If txtOperador.Text.Length > 6 Then
            codOpe = txtOperador.Text.Substring(4, 6)
        Else
            codOpe = txtOperador.Text
        End If

        While (Not found)

            Temp.Contratado = br.ReadChars(7)
            Temp.Nome = br.ReadChars(51)
            codOpeCursor = CType(Trim(Temp.Contratado), Long)

            If codOpe = codOpeCursor Then
                found = True
                lblOperadorNome.Text = Temp.Nome
                btnInicio.Enabled = True
                btnInicio.Focus()
                Exit While
            ElseIf codOpe > codOpeCursor Then
                first = r
                r = Round((first + last) / 2)
                If (first = r) Then
                    lblOperadorNome.Text = "OPERADOR NÃO EXISTE!"
                    'btnInicio.Enabled = False

                    Exit While
                End If
                ler(r, recSize)
            Else
                last = r
                r = Round((first + last) / 2)
                If (last = r) Then
                    lblOperadorNome.Text = "OPERADOR NÃO EXISTE!"
                    'btnInicio.Enabled = False

                    Exit While
                End If
                ler(r, recSize)
            End If
        End While

    End Sub

    Public Function ler(ByVal r As Integer, ByVal recSize As Integer)
        'Posiciona cursor no arquivo
        On Error Resume Next

        fn.Seek((r - 1) * recSize, 0)
        If Err.Number <> 0 Then
            lblOperadorNome.Text = "OPERADOR NÃO EXISTE!"
            ' btnInicio.Enabled = False

            found = True
            Return r
        Else
            Return r
        End If
    End Function

    Private Sub btnFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub dtCalendario_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtCalendario.ValueChanged

    End Sub

    Private Sub cmbHora_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHora.SelectedIndexChanged

    End Sub
End Class