Imports System
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Drawing

Namespace EditorDescendant

    Public Class MyMemoEditViewInfo
        Inherits MemoEditViewInfo
        Implements IHeightAdaptable

        Private Overloads Function CalcHeight(ByVal cache As GraphicsCache, ByVal width As Integer) As Integer Implements IHeightAdaptable.CalcHeight
            width -= CType(Item, MyRepositoryItemMemoEdit).ContentImageSize.Width
            Dim info As BorderObjectInfoArgs = New BorderObjectInfoArgs(cache)
            info.Bounds = New Rectangle(0, 0, width, 100)
            Dim textRect As Rectangle = BorderPainter.GetObjectClientRectangle(info)
            If Not(TypeOf BorderPainter Is EmptyBorderPainter) AndAlso Not(TypeOf BorderPainter Is InplaceBorderPainter) Then textRect.Inflate(-1, -1)
            Dim text As String = String.Empty
            If Item.LinesCount = 0 Then
                text = DisplayText
                If Not Equals(text, Nothing) AndAlso text.Length > 0 Then
                    Dim lastChar As Char = text(text.Length - 1)
                    If lastChar.Equals(13) OrElse lastChar.Equals(10) Then text += "W"
                End If
            Else
                For i As Integer = 0 To Item.LinesCount - 1
                    text += If(String.IsNullOrEmpty(text), "", Environment.NewLine) & "W"
                Next
            End If

            Dim height1 As Integer = CalcTextSizeCore(cache, text, textRect.Width).Height + 1
            Return height1 + 100 - textRect.Bottom + 1
        End Function

        Public Sub New(ByVal item As RepositoryItem)
            MyBase.New(item)
        End Sub

        Protected Overrides Function CalcMaskBoxRect(ByVal content As Rectangle, ByRef contextImageBounds As Rectangle) As Rectangle
            Dim r As Rectangle = MyBase.CalcMaskBoxRect(content, contextImageBounds)
            Dim width As Integer = IconRect.Width
            r.Width = r.Width - width
            r.X = r.X + width
            Return r
        End Function

        Protected Overrides Sub Assign(ByVal info As BaseControlViewInfo)
            MyBase.Assign(info)
            Dim be As MyMemoEditViewInfo = TryCast(info, MyMemoEditViewInfo)
            If be Is Nothing Then Return
            fIconRect = be.fIconRect
        End Sub

        Protected Overrides Function CalcClientSize(ByVal g As Graphics) As Size
            Dim size As Size = MyBase.CalcClientSize(g)
            size.Width += Item.ContentImageSize.Width
            Return size
        End Function

        Protected Overrides Sub CalcContentRect(ByVal bounds As Rectangle)
            Dim r As Rectangle = Rectangle.Empty
            fIconRect = CalcIconRect(ContentRect)
            MyBase.CalcContentRect(bounds)
            Me.fMaskBoxRect = CalcMaskBoxRect(bounds, r)
        End Sub

        Protected Overridable Function CalcIconRect(ByVal content As Rectangle) As Rectangle
            Dim r As Rectangle = fMaskBoxRect
            r.Size = Item.ContentImageSize
            r.Location = content.Location
            Return r
        End Function

        Public Overridable Overloads ReadOnly Property Item As MyRepositoryItemMemoEdit
            Get
                Return TryCast(MyBase.Item, MyRepositoryItemMemoEdit)
            End Get
        End Property

        Public Function GetImage() As Image
            Return Item.GetImage()
        End Function

        Private fIconRect As Rectangle

        Protected Friend Overridable Property IconRect As Rectangle
            Get
                Return fIconRect
            End Get

            Set(ByVal value As Rectangle)
                fIconRect = value
            End Set
        End Property
    End Class
End Namespace
