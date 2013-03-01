Imports System.Math
Imports System.Resources
Imports System.Collections
Imports System.IO
Imports System.IO.Directory
Imports System.IO.File
Imports System.Windows.Forms

Module Modulo1
    'para pesquisa binária produtos
    Structure Produto
        Dim EAN As String
        Dim Descr As String
    End Structure

    'para pesquisa binária produtos
    Structure Operador
        Dim Contratado As String
        Dim Nome As String
    End Structure

    Public Tipo, Precisao, NroLojas, mnFilial, mnInventario, mnArea, mnContador As Integer
    Public mnSEQ, mnTaskID, mnTaskDate, mnPosItem, mnPRICE, mnDelim, mnWEIGHT As Integer
    Public mnCon As Integer = 0
    Public UltimoRegistro, szSKU, ArquivoInventario, ArquivoProdutos, szHWID, FileAudita As String
    Public FindRegAudita As Boolean
    Public mnNroIt As Integer = 0
    Public Delim As Char
    Public flOutput As System.IO.StreamWriter
    Public flOutputLog As System.IO.StreamWriter
    Public wTASK As New stTASK
    Public wSCAN As New stSCAN
    Public arTASK(1) As stTASK
    Public arSCAN(1000) As stSCAN
    Public bOutputted As Boolean
    Public vCalc As Double = 0
    Public mnTagAction As Integer
    Public szTagOpen As String
    Public szTagClose As String
    Public szDESC As String
    Public mnStatus As Integer
    Public mnTpSKU As Integer
    Public szNroIt As String
    Public mnTStampINI, mnTStampFIM As Long
    Public dtNOW As String

    Public fn As FileStream
    Public br As BinaryReader
    Public found As Boolean
    Public szProduto As String

    Public Structure stTASK

        Dim iHWID As String
        Dim iTaskDate As Integer
        Dim iTASKID As Integer
        Dim iAction As String
        Dim iStore As Integer
        Dim iInvNum As Integer
        Dim iInvArea As Integer
        Dim iOrdCount As Integer
        Dim iTpArea As Integer
        Dim iTimeStamp As Long
        Dim iStatus As Integer

    End Structure

    Public Structure stSCAN

        Dim iHWID As String
        Dim iTaskDate As Integer
        Dim iTASKID As Integer
        Dim iSEQ As Integer
        Dim iSCAN As String
        Dim iQT As Single
        Dim iTPSKU As Integer
        Dim iDESC As String
        Dim iPRICE As Integer
        Dim iSEQLst As String

    End Structure

    'Gera Log de cada Evento
    Public Sub geraLog(ByVal mnNroErr As Integer, ByVal szDescricao As String, ByVal szObjeto As String, ByVal szEvento As String)
        Dim msg As String

        flOutputLog = IO.File.AppendText("\BACKUP\DAVO\COLINV\LOG\LOG_TASK" & mnTaskID.ToString.PadLeft(5, "0") & ".TXT")

        msg = "Err. no: " & mnNroErr & " : " & szDescricao & " , Objeto: " & szObjeto & "_" & szEvento & " , " & Now()

        flOutputLog.WriteLine(msg)

        flOutputLog.Close()

    End Sub

End Module
