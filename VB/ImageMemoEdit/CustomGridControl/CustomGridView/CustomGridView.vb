Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports EditorDescendant
Imports DevExpress.XtraGrid.Views.Printing

Namespace ImageTextEdit
	<System.ComponentModel.DesignerCategory("")> _
	Public Class CustomGridView
		Inherits GridView
		Private nowDrawingCellInfo As GridCellInfo
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal grid As GridControl)
			MyBase.New(grid)
		End Sub

		Private Shared ReadOnly _onSmartIconSelection As Object = New Object()

		Public Overrides Sub Assign(ByVal v As BaseView, ByVal copyEvents As Boolean)
			If v Is Nothing Then
				Return
			End If
			BeginUpdate()
			Try
				Dim gv As CustomGridView = TryCast(v, CustomGridView)
				If gv IsNot Nothing Then
					If copyEvents Then
						Events.AddHandler(_onSmartIconSelection, gv.Events(_onSmartIconSelection))
					End If
				End If
			Finally
				EndUpdate()
			End Try
		End Sub
		Public Custom Event OnSmartIconSelection As OnSmartIconSelectionEventHandler
			AddHandler(ByVal value As OnSmartIconSelectionEventHandler)
				Me.Events.AddHandler(_onSmartIconSelection, value)
			End AddHandler
			RemoveHandler(ByVal value As OnSmartIconSelectionEventHandler)
				Me.Events.RemoveHandler(_onSmartIconSelection, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As Object, ByVal e As SmartIconSelectionEventArgs)
			End RaiseEvent
		End Event
		Protected Friend Overridable Sub RaiseOnSmartIconSelection(ByVal e As SmartIconSelectionEventArgs)
			Dim handler As OnSmartIconSelectionEventHandler = CType(Events(_onSmartIconSelection), OnSmartIconSelectionEventHandler)
			If handler IsNot Nothing Then
				handler(Me, e)
			End If
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "CustomGridView"
			End Get
		End Property
		Protected Overrides Sub ActivateEditor(ByVal cell As GridCellInfo)
			Dim iconSelector As IIconSelector = TryCast(cell.Editor, IIconSelector)
			If iconSelector IsNot Nothing Then
				AddHandler iconSelector.OnIconSelection, AddressOf iconSelector_OnIconSelection
				nowDrawingCellInfo = cell
			End If
			MyBase.ActivateEditor(cell)
		End Sub

		Public Overrides Sub HideEditor()
			If (Not IsEditing) OrElse (Not fAllowCloseEditor) Then
				Return
			End If
			If ActiveEditor IsNot Nothing AndAlso GridControl IsNot Nothing Then
				Dim iconSelector As IIconSelector = TryCast(ActiveEditor.Properties, IIconSelector)
				If iconSelector IsNot Nothing Then
					RemoveHandler iconSelector.OnIconSelection, AddressOf iconSelector_OnIconSelection
				End If
			End If
			MyBase.HideEditor()
		End Sub

		Protected Overrides Function CreatePrintInfoInstance(ByVal args As PrintInfoArgs) As BaseViewPrintInfo
			Dim info As BaseViewPrintInfo = New MyGridViewPrintInfo(args)
			Return info
		End Function

		Friend Sub iconSelector_OnIconSelection(ByVal sender As Object, ByVal e As IconSelectionEventArgs)
			Dim ee As New SmartIconSelectionEventArgs(e.Image, nowDrawingCellInfo, True)
			RaiseOnSmartIconSelection(ee)
			e.Image = ee.Image
		End Sub
	End Class
End Namespace
