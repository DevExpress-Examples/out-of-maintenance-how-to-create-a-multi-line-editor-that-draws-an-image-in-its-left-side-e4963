Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors
Imports System.ComponentModel

Namespace EditorDescendant
	<System.ComponentModel.DesignerCategory(""), System.ComponentModel.ToolboxItem(True)> _
	Public Class MyMemoEdit
		Inherits MemoEdit
		#Region "Service"
		Shared Sub New()
			MyRepositoryItemMemoEdit.Register()
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return MyRepositoryItemMemoEdit.EditorName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As MyRepositoryItemMemoEdit
			Get
				Return TryCast(MyBase.Properties, MyRepositoryItemMemoEdit)
			End Get
		End Property

	 #End Region
	End Class
End Namespace
