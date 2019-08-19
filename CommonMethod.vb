Imports Word = Microsoft.Office.Interop.Word


Class ErrorHandler
    Shared Sub WriteErrLog(ByRef ex As Exception, Optional CodeLocation As String = "")
        IO.File.AppendAllText(IO.Directory.GetCurrentDirectory & "\Error.log", DateString & " " & TimeString & vbCrLf & ex.ToString() & vbCrLf & "错误发生在：" & CodeLocation & vbCrLf & "=================================")
    End Sub
End Class

Public Structure Duality
    Dim a As Single
    Dim b As Single
    Sub New(a As Single, b As Single)
        Me.a = a
        Me.b = b
    End Sub
End Structure

Public Class MyWord
    Protected MyApp As Word.Application
    Protected MyDoc As Word.Document
    Protected MyPane As Word.Pane

    Sub New()
        MyApp = New Word.Application
        MyDoc = MyApp.Documents.Add()
        MyDoc.Windows(1).Visible = False
        MyPane = MyDoc.Windows(1).Panes(1)
    End Sub

    Sub New(path As String)
        MyApp = New Word.Application
        MyDoc = MyApp.Documents.Open(FileName:=path, AddToRecentFiles:=False, Visible:=False)
        MyPane = MyDoc.Windows(1).Panes(1)
    End Sub



    Sub SaveDoc(FilePath As String)
        If MyDoc Is Nothing Then Exit Sub
        Try
            MyDoc.SaveAs(FilePath, Word.WdSaveFormat.wdFormatDocumentDefault,,, False,,, False)

        Catch ex As Exception
            MessageBox.Show("保存失败！" & vbCrLf & ex.ToString, "错误")

        End Try
    End Sub

    Sub AddPage(amount As Integer)
        '移动光标至最后一页
        MyPane.Selection.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToLast)
        '添加页面 TODO 重构
        For i = 1 To amount
            MyPane.Selection.InsertNewPage()
        Next

    End Sub
    Sub CloseDoc()
        'Close MyDoc
        If MyDoc IsNot Nothing Then
            MyDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
            MyDoc = Nothing
        End If
    End Sub

    Sub Dispose()
        CloseDoc()

        'Check if Word using, and close if not using
        If (MyApp.Documents.Count = 0) AndAlso (MyApp IsNot Nothing) Then
            MyApp.Quit(SaveChanges:=False)
            MyApp = Nothing
        End If
        Finalize()
    End Sub

    ReadOnly Property PageCount As Integer
        Get
            If MyPane IsNot Nothing Then
                Return MyPane.Pages.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property PageSize As Duality
        'Note: 长度单位是磅，1英寸 = 72磅
        Get
            If MyDoc IsNot Nothing Then
                Return New Duality(MyDoc.PageSetup.PageWidth, MyDoc.PageSetup.PageHeight)
            Else
                Return New Duality(0, 0)
            End If
        End Get
        Set(value As Duality)
            If MyDoc Is Nothing Then Exit Property
            MyDoc.PageSetup.PageWidth = value.a
            MyDoc.PageSetup.PageHeight = value.b
        End Set

    End Property

    Public Property IsHorizonal As Boolean
        Get
            If MyDoc Is Nothing Then Return False
            If MyDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            If MyDoc Is Nothing Then Exit Property
            If value Then
                MyDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape
            Else
                MyDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait
            End If
        End Set
    End Property

End Class
