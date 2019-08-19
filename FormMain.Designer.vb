<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.lblContentPath = New System.Windows.Forms.Label()
        Me.Lable1 = New System.Windows.Forms.Label()
        Me.btnOpenContent = New System.Windows.Forms.Button()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.PrBar = New System.Windows.Forms.ProgressBar()
        Me.txtContentPath = New System.Windows.Forms.TextBox()
        Me.SaveDia = New System.Windows.Forms.SaveFileDialog()
        Me.FileDia = New System.Windows.Forms.OpenFileDialog()
        Me.lblPrintFix = New System.Windows.Forms.Label()
        Me.txtPtHrzFix = New System.Windows.Forms.TextBox()
        Me.combPtFix = New System.Windows.Forms.ComboBox()
        Me.gpbOption = New System.Windows.Forms.GroupBox()
        Me.txtTextSize = New System.Windows.Forms.TextBox()
        Me.txtTitleSize = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPtVtcFix = New System.Windows.Forms.Label()
        Me.txtPtVtcFix = New System.Windows.Forms.TextBox()
        Me.lblPtHrzFix = New System.Windows.Forms.Label()
        Me.ChkTransRotate = New System.Windows.Forms.CheckBox()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.lblSavingPath = New System.Windows.Forms.Label()
        Me.txtSavingPath = New System.Windows.Forms.TextBox()
        Me.BtnSelectSavingPath = New System.Windows.Forms.Button()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.gpbOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(22, 159)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(77, 36)
        Me.BtnStart.TabIndex = 10
        Me.BtnStart.Text = "开始"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'lblContentPath
        '
        Me.lblContentPath.AutoSize = True
        Me.lblContentPath.Location = New System.Drawing.Point(21, 25)
        Me.lblContentPath.Name = "lblContentPath"
        Me.lblContentPath.Size = New System.Drawing.Size(53, 12)
        Me.lblContentPath.TabIndex = 1
        Me.lblContentPath.Text = "内容文件"
        '
        'Lable1
        '
        Me.Lable1.AutoSize = True
        Me.Lable1.Location = New System.Drawing.Point(21, 120)
        Me.Lable1.Name = "Lable1"
        Me.Lable1.Size = New System.Drawing.Size(29, 12)
        Me.Lable1.TabIndex = 3
        Me.Lable1.Text = "进度"
        '
        'btnOpenContent
        '
        Me.btnOpenContent.Location = New System.Drawing.Point(288, 22)
        Me.btnOpenContent.Name = "btnOpenContent"
        Me.btnOpenContent.Size = New System.Drawing.Size(44, 20)
        Me.btnOpenContent.TabIndex = 2
        Me.btnOpenContent.Text = "打开"
        Me.btnOpenContent.UseVisualStyleBackColor = True
        '
        'BtnAbout
        '
        Me.BtnAbout.Location = New System.Drawing.Point(254, 159)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(77, 36)
        Me.BtnAbout.TabIndex = 11
        Me.BtnAbout.Text = "关于"
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'PrBar
        '
        Me.PrBar.Location = New System.Drawing.Point(82, 116)
        Me.PrBar.Name = "PrBar"
        Me.PrBar.Size = New System.Drawing.Size(191, 21)
        Me.PrBar.Step = 1
        Me.PrBar.TabIndex = 7
        '
        'txtContentPath
        '
        Me.txtContentPath.Location = New System.Drawing.Point(82, 22)
        Me.txtContentPath.Name = "txtContentPath"
        Me.txtContentPath.Size = New System.Drawing.Size(191, 21)
        Me.txtContentPath.TabIndex = 1
        '
        'SaveDia
        '
        Me.SaveDia.Filter = "Word 2007 文档|*.docx"
        '
        'FileDia
        '
        Me.FileDia.Filter = "文本文件|*.txt"
        '
        'lblPrintFix
        '
        Me.lblPrintFix.AutoSize = True
        Me.lblPrintFix.Location = New System.Drawing.Point(6, 25)
        Me.lblPrintFix.Name = "lblPrintFix"
        Me.lblPrintFix.Size = New System.Drawing.Size(161, 12)
        Me.lblPrintFix.TabIndex = 10
        Me.lblPrintFix.Text = "打印机偏移量(向右向上为正)"
        '
        'txtPtHrzFix
        '
        Me.txtPtHrzFix.Location = New System.Drawing.Point(43, 49)
        Me.txtPtHrzFix.Name = "txtPtHrzFix"
        Me.txtPtHrzFix.Size = New System.Drawing.Size(25, 21)
        Me.txtPtHrzFix.TabIndex = 5
        Me.txtPtHrzFix.Text = "0"
        '
        'combPtFix
        '
        Me.combPtFix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combPtFix.FormattingEnabled = True
        Me.combPtFix.Items.AddRange(New Object() {"厘米", "英寸", "磅"})
        Me.combPtFix.Location = New System.Drawing.Point(141, 50)
        Me.combPtFix.Name = "combPtFix"
        Me.combPtFix.Size = New System.Drawing.Size(50, 20)
        Me.combPtFix.TabIndex = 6
        '
        'gpbOption
        '
        Me.gpbOption.Controls.Add(Me.txtTextSize)
        Me.gpbOption.Controls.Add(Me.txtTitleSize)
        Me.gpbOption.Controls.Add(Me.Label1)
        Me.gpbOption.Controls.Add(Me.lblPtVtcFix)
        Me.gpbOption.Controls.Add(Me.txtPtVtcFix)
        Me.gpbOption.Controls.Add(Me.lblPtHrzFix)
        Me.gpbOption.Controls.Add(Me.ChkTransRotate)
        Me.gpbOption.Controls.Add(Me.lblPrintFix)
        Me.gpbOption.Controls.Add(Me.combPtFix)
        Me.gpbOption.Controls.Add(Me.txtPtHrzFix)
        Me.gpbOption.Location = New System.Drawing.Point(357, 15)
        Me.gpbOption.Name = "gpbOption"
        Me.gpbOption.Size = New System.Drawing.Size(207, 142)
        Me.gpbOption.TabIndex = 5
        Me.gpbOption.TabStop = False
        Me.gpbOption.Text = "选项"
        '
        'txtTextSize
        '
        Me.txtTextSize.Location = New System.Drawing.Point(166, 105)
        Me.txtTextSize.Name = "txtTextSize"
        Me.txtTextSize.Size = New System.Drawing.Size(25, 21)
        Me.txtTextSize.TabIndex = 23
        Me.txtTextSize.Text = "14"
        '
        'txtTitleSize
        '
        Me.txtTitleSize.Location = New System.Drawing.Point(127, 105)
        Me.txtTitleSize.Name = "txtTitleSize"
        Me.txtTitleSize.Size = New System.Drawing.Size(25, 21)
        Me.txtTitleSize.TabIndex = 22
        Me.txtTitleSize.Text = "16"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "字号（标题，正文）"
        '
        'lblPtVtcFix
        '
        Me.lblPtVtcFix.AutoSize = True
        Me.lblPtVtcFix.Location = New System.Drawing.Point(75, 53)
        Me.lblPtVtcFix.Name = "lblPtVtcFix"
        Me.lblPtVtcFix.Size = New System.Drawing.Size(29, 12)
        Me.lblPtVtcFix.TabIndex = 18
        Me.lblPtVtcFix.Text = "竖直"
        '
        'txtPtVtcFix
        '
        Me.txtPtVtcFix.Location = New System.Drawing.Point(111, 49)
        Me.txtPtVtcFix.Name = "txtPtVtcFix"
        Me.txtPtVtcFix.Size = New System.Drawing.Size(23, 21)
        Me.txtPtVtcFix.TabIndex = 7
        Me.txtPtVtcFix.Text = "0"
        '
        'lblPtHrzFix
        '
        Me.lblPtHrzFix.AutoSize = True
        Me.lblPtHrzFix.Location = New System.Drawing.Point(8, 52)
        Me.lblPtHrzFix.Name = "lblPtHrzFix"
        Me.lblPtHrzFix.Size = New System.Drawing.Size(29, 12)
        Me.lblPtHrzFix.TabIndex = 15
        Me.lblPtHrzFix.Text = "水平"
        '
        'ChkTransRotate
        '
        Me.ChkTransRotate.AutoSize = True
        Me.ChkTransRotate.Location = New System.Drawing.Point(10, 81)
        Me.ChkTransRotate.Name = "ChkTransRotate"
        Me.ChkTransRotate.Size = New System.Drawing.Size(96, 16)
        Me.ChkTransRotate.TabIndex = 9
        Me.ChkTransRotate.Text = "倒置中文翻译"
        Me.ChkTransRotate.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(292, 121)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(0, 12)
        Me.lblProcess.TabIndex = 12
        '
        'lblSavingPath
        '
        Me.lblSavingPath.AutoSize = True
        Me.lblSavingPath.Location = New System.Drawing.Point(21, 73)
        Me.lblSavingPath.Name = "lblSavingPath"
        Me.lblSavingPath.Size = New System.Drawing.Size(53, 12)
        Me.lblSavingPath.TabIndex = 13
        Me.lblSavingPath.Text = "保存位置"
        '
        'txtSavingPath
        '
        Me.txtSavingPath.Location = New System.Drawing.Point(82, 69)
        Me.txtSavingPath.Name = "txtSavingPath"
        Me.txtSavingPath.Size = New System.Drawing.Size(191, 21)
        Me.txtSavingPath.TabIndex = 14
        '
        'BtnSelectSavingPath
        '
        Me.BtnSelectSavingPath.Location = New System.Drawing.Point(288, 69)
        Me.BtnSelectSavingPath.Name = "BtnSelectSavingPath"
        Me.BtnSelectSavingPath.Size = New System.Drawing.Size(44, 20)
        Me.BtnSelectSavingPath.TabIndex = 15
        Me.BtnSelectSavingPath.Text = "选择"
        Me.BtnSelectSavingPath.UseVisualStyleBackColor = True
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(138, 159)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(77, 36)
        Me.BtnHelp.TabIndex = 16
        Me.BtnHelp.Text = "帮助"
        Me.BtnHelp.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 212)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnSelectSavingPath)
        Me.Controls.Add(Me.txtSavingPath)
        Me.Controls.Add(Me.lblSavingPath)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.gpbOption)
        Me.Controls.Add(Me.txtContentPath)
        Me.Controls.Add(Me.PrBar)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.btnOpenContent)
        Me.Controls.Add(Me.Lable1)
        Me.Controls.Add(Me.lblContentPath)
        Me.Controls.Add(Me.BtnStart)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生成单词卡"
        Me.gpbOption.ResumeLayout(False)
        Me.gpbOption.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnStart As Button
    Friend WithEvents lblContentPath As Label
    Friend WithEvents Lable1 As Label
    Friend WithEvents btnOpenContent As Button
    Friend WithEvents BtnAbout As Button
    Friend WithEvents PrBar As ProgressBar
    Friend WithEvents txtContentPath As TextBox
    Friend WithEvents SaveDia As SaveFileDialog
    Friend WithEvents FileDia As OpenFileDialog
    Friend WithEvents lblPrintFix As Label
    Friend WithEvents txtPtHrzFix As TextBox
    Friend WithEvents combPtFix As ComboBox
    Friend WithEvents gpbOption As GroupBox
    Friend WithEvents lblPtVtcFix As Label
    Friend WithEvents txtPtVtcFix As TextBox
    Friend WithEvents lblPtHrzFix As Label
    Friend WithEvents ChkTransRotate As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTextSize As TextBox
    Friend WithEvents txtTitleSize As TextBox
    Friend WithEvents lblProcess As Label
    Friend WithEvents lblSavingPath As Label
    Friend WithEvents txtSavingPath As TextBox
    Friend WithEvents BtnSelectSavingPath As Button
    Friend WithEvents BtnHelp As Button
End Class
