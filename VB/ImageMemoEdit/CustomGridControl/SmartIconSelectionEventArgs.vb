Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.ComponentModel
Imports EditorDescendant
Imports System.Drawing

Namespace ImageTextEdit
	Public Class SmartIconSelectionEventArgs
		Inherits IconSelectionEventArgs
		Private isActiveEditor_Renamed As Boolean
		Private cellInfo_Renamed As GridCellInfo
		Public Sub New(ByVal image As Image, ByVal cellInfo As GridCellInfo, ByVal isActiveEditor As Boolean)
			MyBase.New(image)
			Me.cellInfo_Renamed = cellInfo
			Me.isActiveEditor_Renamed = isActiveEditor
		End Sub
		Public ReadOnly Property CellInfo() As GridCellInfo
			Get
				Return cellInfo_Renamed
			End Get
		End Property
		Public ReadOnly Property IsActiveEditor() As Boolean
			Get
				Return isActiveEditor_Renamed
			End Get
		End Property
	End Class
End Namespace
