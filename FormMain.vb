﻿Imports OfficeCore = Microsoft.Office.Core
Imports Word = Microsoft.Office.Interop.Word


Public Class FormMain

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Lock Windows Size
        Me.MaximumSize = Me.Size : Me.MinimumSize = Me.Size

        'Check if Word App installed
        Try
            Dim myApp = New Word.Application()
        Catch ex As Exception
            MessageBox.Show("调用Word程序失败，请检查是否安装Word。" & vbCrLf & ex.ToString, "错误")
            End
        End Try

        'Set combobox default value
        combPtFix.Text = combPtFix.Items(0).ToString

    End Sub

    Private Async Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        'CheckInput
        If Not IsInputOK() Then
            Exit Sub
        End If


        'disable button, show message
        BtnStart.Enabled = False
        lblProcess.Text = "正在启动"

        'set Wd object
        Dim wd As New CardDocGenerator With {
            .FontSize = New Duality(txtTitleSize.Text, txtTextSize.Text),
            .PrintFix = GetPrintFixFromWindow(),
            .IsTransRotated = ChkTransRotate.Checked,
            .Content = IO.File.ReadAllLines(txtContentPath.Text)
            }

        AddHandler wd.ProcessChanged, AddressOf ProcessChanged_Handler
        Dim PageCount As Integer = Math.Ceiling(wd.Content.Count / 64)
        wd.AddPage(PageCount * 2 - 1)


        'start generating Doc file
        Try
            Await Task.Run(AddressOf wd.CreateCards)
        Catch ex As Exception
            ErrorHandler.WriteErrLog(ex, "wd.CreateCards")
            MessageBox.Show("很抱歉，出现了一个错误，生成失败！" & vbCrLf & "【错误信息】" & vbCrLf & ex.ToString())
        End Try

        'save Doc and close it
        wd.SaveDoc(txtSavingPath.Text)
        wd.CloseDoc()
        RemoveHandler wd.ProcessChanged, AddressOf ProcessChanged_Handler

        'reset state of all control
        BtnStart.Enabled = True
        SaveDia.FileName = ""
        lblProcess.ResetText()
        PrBar.Value = 0

    End Sub

    Function GetPrintFixFromWindow() As Duality
        Dim result As New Duality
        Dim a, b As Single

        Select Case combPtFix.Text
            Case "厘米"
                a = txtPtHrzFix.Text * 0.3937! * 72.0!
                b = txtPtVtcFix.Text * 0.3937! * 72.0!
            Case "英寸"
                a = txtPtHrzFix.Text * 72.0!
                b = txtPtVtcFix.Text * 72.0!
            Case "磅"
                a = txtPtHrzFix.Text
                b = txtPtVtcFix.Text
        End Select

        result.a = a : result.b = b

        Return result
    End Function

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles BtnAbout.Click
        MessageBox.Show("作者 SMagic  保留一切著作权

本应用已开源，并签署了 MIT License

详见 https://github.com/SMagic-L/GenerateWordCard", "关于")
    End Sub

    Private Sub BtnOpenEng_Click(sender As Object, e As EventArgs) Handles btnOpenContent.Click
        FileDia.Title = "打开词汇文件"
        If FileDia.ShowDialog() <> DialogResult.OK Then Exit Sub
        txtContentPath.Text = FileDia.FileName
        FileDia.FileName = ""

    End Sub

    Private Sub BtnSelectSavingPath_Click(sender As Object, e As EventArgs) Handles BtnSelectSavingPath.Click
        If SaveDia.ShowDialog() <> DialogResult.OK Then Exit Sub
        txtSavingPath.Text = SaveDia.FileName
        SaveDia.FileName = ""
    End Sub

    Private Sub ProcessChanged_Handler(process As Double)
        Me.Invoke(New UpdateProcess_Delegate(AddressOf UpdateProcess), process)
    End Sub

    Private Delegate Sub UpdateProcess_Delegate(process As Double)
    Private Sub UpdateProcess(process As Double)
        lblProcess.Text = String.Format("{0:P}", process)
        PrBar.Value = process * 100
    End Sub

    Function IsInputOK() As Boolean
        'TODO 将输入栏的清空放在函数外

        'File
        If Not IO.File.Exists(txtContentPath.Text) Then
            txtContentPath.ResetText()
            Return False
        End If

        'Is Content odd
        If IO.File.ReadAllLines(txtContentPath.Text).Length Mod 2 <> 0 Then
            MessageBox.Show("文件内容的行数为奇数，无法配对")
            Return False
        End If

        'PrintFix
        Dim a As Single
        Try
            a = CType(txtPtHrzFix.Text, Single)
            a = CType(txtPtVtcFix.Text, Single)
        Catch ex As InvalidCastException
            txtPtHrzFix.ResetText()
            txtPtVtcFix.ResetText()
            Return False
        End Try

        'FontSize
        Try
            a = CType(txtTitleSize.Text, Single)
            a = CType(txtTextSize.Text, Single)
        Catch ex As Exception
            txtTitleSize.ResetText()
            txtTextSize.ResetText()
            Return False
        End Try

        Return True
    End Function

    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles BtnHelp.Click
        MessageBox.Show("确保装有微软的word（程序内需调用VBA的API，所以不支持WPS）。

将单词卡的内容以【一行单词，一行翻译】的形式，存储在UTF-8格式的txt文件里。

打开程序，设置路径后，点击【开始】，生成一个word文档

生成word文档后，将其打印出来，并裁剪

建议使用裁纸器裁剪，否则你的单词卡可能会犬牙差互（逃", "使用说明")
    End Sub





    '计划 TODO
    '3.适当补充注释
    '4.分离 错误处理机制 []
    '5.引入MyExcel类，增加从Excel读取单词的功能 []
    '10.引入异步编程，避免运行时程序假死
    '11.添加生成、导入Anki牌组的功能 [Failed]
    '12.将设置放在单独的Form里
    '13.修改CreateCards函数，保留打孔位置，添加打孔引导线

End Class


Public Class CardDocGenerator
    Inherits MyWord
    Const HOLE_RADIUS As Single = 0.3! * 0.3937! * 72.0!   '半径 * 厘米转英寸 * 英寸转磅 

    Public Property FontSize As Duality
    Public Property Content As String() '一行正面一行背面，直接读文件
    Public Property Process As Double  '进度条
    Public Property PrintFix As Duality
    Public Property IsTransRotated As Boolean

    Private w As Single
    Private h As Single

    Delegate Sub ProcessChanged_Delegate(process As Double)
    Friend ProcessChanged_Handler As ProcessChanged_Delegate
    Public Event ProcessChanged As ProcessChanged_Delegate


    Sub New()
        Me.IsHorizonal = True

    End Sub

    Sub CreateCards()


        'declaration
        Dim i, j As Integer    'Circulation Variable
        w = MyDoc.PageSetup.PageWidth
        h = MyDoc.PageSetup.PageHeight
        Dim RestCardCount As Integer
        Dim tmpCardShape As Word.Shape
        Dim counter As Integer = 0

        'DEBUG show window for observe
        'MyDoc.Windows(1).Visible = True

        'arrange card into correct position
        Dim position, size As Duality
        For i = 1 To MyPane.Pages.Count
            MyPane.Selection.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, i)  '移动光标至第i页
            RestCardCount = 0.5 * Math.Min(64, Content.Count - 64 * (0.5 * (i + i Mod 2) - 1))   '当前页未放置的卡片数
            For j = 1 To RestCardCount
                'get position and size
                position = GetCardPosition(i, j)
                size = New Duality(w / 4 - 4 * HOLE_RADIUS, h / 8)
                'arrange card
                tmpCardShape = GetTmpCardShape(position, size)
                SetTmpCardShape(tmpCardShape, i, j)
                'Increase Progress
                counter += 1
                Process = counter / Content.Length
                RaiseEvent ProcessChanged(Process)
            Next j
        Next i
    End Sub

    Private Function GetCardPosition(i As Integer, j As Integer) As Duality
        Dim result As New Duality
        '卡片正面
        If i Mod 2 = 1 Then
            result.a = ((j - 1) \ 8) * w / 4 - PrintFix.a
            result.b = (((j - 1) Mod 8) * h / 8) - PrintFix.b
            Return result
        End If

        '卡片背面
        If IsTransRotated Then
            result.a = ((j - 1) \ 8) * w / 4 - PrintFix.a
            result.b = ((7 - ((j - 1) Mod 8)) * h / 8) - PrintFix.b
        Else
            result.a = ((3 - ((j - 1) \ 8)) * w / 4) - PrintFix.a + (4 * HOLE_RADIUS)
            result.b = (((j - 1) Mod 8) * h / 8) - PrintFix.b
        End If
        Return result

    End Function

    Private Function GetContentIndex(i As Integer, j As Integer) As Integer
        '第i页的第j个卡片在content中的索引
        Return 2 - (i Mod 2) + 2 * (j - 1) + (0.5 * (i + (i Mod 2)) - 1) * 64 - 1
    End Function

    Private Function GetTmpCardShape(Position As Duality, Size As Duality) As Word.Shape
        Return MyDoc.Shapes.AddShape(OfficeCore.MsoAutoShapeType.msoShapeRectangle, Position.a, Position.b, Size.a, Size.b)
    End Function

    Private Sub SetTmpCardShape(ByRef tmpShape As Word.Shape, i As Integer, j As Integer)
        Dim index As Integer = GetContentIndex(i, j)
        Dim f As Single
        If i Mod 2 = 1 Then
            f = FontSize.a
        Else
            f = FontSize.b
        End If

        With tmpShape
            'set value
            .TextFrame.TextRange.Text = Content(index)
            'font
            .TextFrame.TextRange.Font.Size = f
            'hide line
            .Line.Visible = OfficeCore.MsoTriState.msoFalse
            'align
            .TextFrame.TextRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            .TextFrame.VerticalAnchor = OfficeCore.MsoVerticalAnchor.msoAnchorMiddle
        End With

    End Sub

End Class






