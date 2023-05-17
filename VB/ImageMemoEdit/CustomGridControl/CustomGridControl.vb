Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports System.ComponentModel

Namespace ImageTextEdit

    <System.ComponentModel.DesignerCategory("")>
    <System.ComponentModel.ToolboxItem(True)>
    Public Class CustomGridControl
        Inherits GridControl

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
            MyBase.RegisterAvailableViewsCore(collection)
            collection.Add(New CustomGridInfoRegistrator())
        End Sub

        Protected Overrides Function CreateDefaultView() As BaseView
            Return CreateView("CustomGridView")
        End Function
    End Class

    Public Delegate Sub OnSmartIconSelectionEventHandler(ByVal sender As Object, ByVal e As SmartIconSelectionEventArgs)
End Namespace
