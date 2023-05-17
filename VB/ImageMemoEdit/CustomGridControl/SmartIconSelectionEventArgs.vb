Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.ComponentModel
Imports EditorDescendant
Imports System.Drawing

Namespace ImageTextEdit

    Public Class SmartIconSelectionEventArgs
        Inherits IconSelectionEventArgs

        Private isActiveEditorField As Boolean

        Private cellInfoField As GridCellInfo

        Public Sub New(ByVal image As Image, ByVal cellInfo As GridCellInfo, ByVal isActiveEditor As Boolean)
            MyBase.New(image)
            cellInfoField = cellInfo
            isActiveEditorField = isActiveEditor
        End Sub

        Public ReadOnly Property CellInfo As GridCellInfo
            Get
                Return cellInfoField
            End Get
        End Property

        Public ReadOnly Property IsActiveEditor As Boolean
            Get
                Return isActiveEditorField
            End Get
        End Property
    End Class
End Namespace
