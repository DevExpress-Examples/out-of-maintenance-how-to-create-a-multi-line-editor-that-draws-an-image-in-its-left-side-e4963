Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid

Namespace ImageTextEdit

    Public Class CustomGridInfoRegistrator
        Inherits GridInfoRegistrator

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Function CreatePainter(ByVal view As BaseView) As BaseViewPainter
            Return New CustomGridPainter(TryCast(view, CustomGridView))
        End Function

        Public Overrides ReadOnly Property ViewName As String
            Get
                Return "CustomGridView"
            End Get
        End Property

        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New CustomGridView(grid)
        End Function
    End Class
End Namespace
