Imports DevExpress.XtraEditors.Drawing
Imports System.Drawing

Namespace EditorDescendant

    Public Class MyMemoEditPainter
        Inherits MemoEditPainter

        Public Sub New()
        End Sub

        Public Overrides Sub Draw(ByVal info As ControlGraphicsInfoArgs)
            info.Cache.FillRectangle(Brushes.White, info.Bounds)
            MyBase.Draw(info)
        End Sub

        Protected Overrides Sub DrawContent(ByVal info As ControlGraphicsInfoArgs)
            MyBase.DrawContent(info)
            DrawIcon(info)
        End Sub

        Protected Overridable Sub DrawIcon(ByVal info As ControlGraphicsInfoArgs)
            Dim vi As MyMemoEditViewInfo = TryCast(info.ViewInfo, MyMemoEditViewInfo)
            Dim img As Image = vi.GetImage()
            If img IsNot Nothing Then
                Dim rec As Rectangle = New Rectangle(info.Bounds.X + vi.IconRect.X, info.Bounds.Y + vi.IconRect.Y, vi.IconRect.Width, vi.IconRect.Height)
                info.Graphics.DrawImage(img, rec)
            Else
                info.Graphics.FillRectangle(info.Cache.GetSolidBrush(Color.White), vi.IconRect)
            End If
        End Sub
    End Class
End Namespace
