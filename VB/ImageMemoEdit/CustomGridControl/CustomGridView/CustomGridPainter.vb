Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Utils
Imports EditorDescendant

Namespace ImageTextEdit

    Public Class CustomGridPainter
        Inherits GridPainter

        Private nowDrawingCellInfo As GridCellInfo

        Public Sub New(ByVal view As GridView)
            MyBase.New(view)
        End Sub

        Public Overridable Overloads ReadOnly Property View As CustomGridView
            Get
                Return CType(MyBase.View, CustomGridView)
            End Get
        End Property

        Protected Overrides Sub DrawCellEdit(ByVal e As GridViewDrawArgs, ByVal editInfo As BaseEditViewInfo, ByVal cell As GridCellInfo, ByVal appearance As AppearanceObject, ByVal isSelectedCell As Boolean)
            Dim iconSelector As IIconSelector = TryCast(cell.Editor, IIconSelector)
            If iconSelector IsNot Nothing Then
                Dim EH As MyRepositoryItemMemoEdit.IconSelectionEventHandler = New MyRepositoryItemMemoEdit.IconSelectionEventHandler(AddressOf iconSelector_OnIconSelection)
                AddHandler iconSelector.OnIconSelection, EH
                nowDrawingCellInfo = cell
                Try
                    MyBase.DrawCellEdit(e, editInfo, cell, appearance, isSelectedCell)
                Finally
                    RemoveHandler iconSelector.OnIconSelection, EH
                End Try
            Else
                MyBase.DrawCellEdit(e, editInfo, cell, appearance, isSelectedCell)
            End If
        End Sub

        Private Sub iconSelector_OnIconSelection(ByVal sender As Object, ByVal e As IconSelectionEventArgs)
            Dim ee As SmartIconSelectionEventArgs = New SmartIconSelectionEventArgs(e.Image, nowDrawingCellInfo, False)
            View.RaiseOnSmartIconSelection(ee)
            e.Image = ee.Image
        End Sub
    End Class
End Namespace
