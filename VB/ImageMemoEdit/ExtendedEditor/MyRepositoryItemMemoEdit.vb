Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.NativeBricks
Imports System.Drawing
Imports ImageTextEdit

Namespace EditorDescendant
	<System.ComponentModel.DesignerCategory("")> _
	Public Class MyRepositoryItemMemoEdit
		Inherits RepositoryItemMemoEdit
		Implements IIconSelector
		Private _ContentImageSize As Size
		Private Shared ReadOnly _onSmartIconSelection As Object = New Object()


		#Region "Service"

		Shared Sub New()
			Register()
		End Sub

		Public Sub New()
		End Sub


		Friend Const EditorName As String = "MyMemoEdit"

		Public Shared Sub Register()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MyMemoEdit), GetType(MyRepositoryItemMemoEdit), GetType(MyMemoEditViewInfo), New MyMemoEditPainter(), True, EditImageIndexes.MemoEdit, GetType(DevExpress.Accessibility.BaseEditAccessible)))
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String

			Get
				Return EditorName
			End Get

		End Property

		#End Region

		Protected Friend Function GetImage() As Image
			Dim args As New IconSelectionEventArgs(Nothing)
			RaiseOnIconSelection(args)
			Return args.Image
		End Function

		Public Property ContentImageSize() As Size
			Get
				Return _ContentImageSize
			End Get
			Set(ByVal value As Size)
				_ContentImageSize = value
			End Set
		End Property

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			MyBase.Assign(item)
			Dim source As MyRepositoryItemMemoEdit = TryCast(item, MyRepositoryItemMemoEdit)
			ContentImageSize = source.ContentImageSize
			Events.AddHandler(_onSmartIconSelection, source.Events(_onSmartIconSelection))
		End Sub

		Public Overrides Function GetBrick(ByVal info As PrintCellHelperInfo) As VisualBrick
			Dim contentBrick As TextBrick = CType(MyBase.GetBrick(info), TextBrick)
			Dim imgBrick As New ImageBrick()

			Dim panelBrick As PanelBrick = New XETextPanelBrick(CreateBrickStyle(info, "panel"))
			SetCommonBrickProperties(panelBrick, info)
			panelBrick.Bricks.Add(imgBrick)
			panelBrick.Bricks.Add(contentBrick)

			imgBrick.Image = GetImage()
			imgBrick.Size = ContentImageSize
			panelBrick.Style = contentBrick.Style

			contentBrick.Location = New PointFloat(imgBrick.Location.X + imgBrick.Size.Width, 0)
			contentBrick.Sides = BorderSide.None
			contentBrick.Size = New SizeF(info.Rectangle.Size.Width - imgBrick.Size.Width, info.Rectangle.Size.Height)
			panelBrick.Rect = New RectangleF(0, 0, contentBrick.Rect.Width + imgBrick.Size.Width, contentBrick.Rect.Height)


			Return panelBrick
		End Function

		Public Delegate Sub IconSelectionEventHandler(ByVal sender As Object, ByVal e As IconSelectionEventArgs)
		Public Custom Event OnIconSelection As IconSelectionEventHandler Implements IIconSelector.OnIconSelection
			AddHandler(ByVal value As IconSelectionEventHandler)
				Me.Events.AddHandler(_onSmartIconSelection, value)
			End AddHandler
			RemoveHandler(ByVal value As IconSelectionEventHandler)
				Me.Events.RemoveHandler(_onSmartIconSelection, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As Object, ByVal e As IconSelectionEventArgs)
			End RaiseEvent
		End Event

		Protected Friend Overridable Sub RaiseOnIconSelection(ByVal e As IconSelectionEventArgs)
			Dim handler As IconSelectionEventHandler = CType(Me.Events(_onSmartIconSelection), IconSelectionEventHandler)
			If handler IsNot Nothing Then
				handler(Me, e)
			End If
		End Sub

	End Class

End Namespace
