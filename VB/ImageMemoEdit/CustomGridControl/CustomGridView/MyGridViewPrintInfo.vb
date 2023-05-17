Imports DevExpress.XtraGrid.Views.Printing
Imports EditorDescendant
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace ImageTextEdit

    Public Class MyGridViewPrintInfo
        Inherits GridViewPrintInfo

        Public Sub New(ByVal args As PrintInfoArgs)
            MyBase.New(args)
        End Sub

        Public Overridable Overloads ReadOnly Property View As CustomGridView
            Get
                Return CType(MyBase.View, CustomGridView)
            End Get
        End Property

        Private nowPrintingCellInfo As GridCellInfo

        Protected Overrides Sub PrintRowCell(ByVal rowHandle As Integer, ByVal cell As GridCellInfo, ByVal r As System.Drawing.Rectangle)
            Dim iconSelector As IIconSelector = TryCast(cell.Editor, IIconSelector)
            If iconSelector IsNot Nothing Then
                Dim EH As MyRepositoryItemMemoEdit.IconSelectionEventHandler = New MyRepositoryItemMemoEdit.IconSelectionEventHandler(AddressOf iconSelector_OnIconSelection)
                AddHandler iconSelector.OnIconSelection, EH
                nowPrintingCellInfo = cell
                Try
                    MyBase.PrintRowCell(rowHandle, cell, r)
                Finally
                    RemoveHandler iconSelector.OnIconSelection, EH
                End Try
            Else
                MyBase.PrintRowCell(rowHandle, cell, r)
            End If
        End Sub

        Private Sub iconSelector_OnIconSelection(ByVal sender As Object, ByVal e As IconSelectionEventArgs)
            Dim ee As SmartIconSelectionEventArgs = New SmartIconSelectionEventArgs(e.Image, nowPrintingCellInfo, False)
            View.RaiseOnSmartIconSelection(ee)
            e.Image = ee.Image
        End Sub
    End Class
End Namespace
