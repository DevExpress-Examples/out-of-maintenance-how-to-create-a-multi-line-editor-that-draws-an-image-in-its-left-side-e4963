Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing

Namespace EditorDescendant
	Public Class IconSelectionEventArgs
		Inherits EventArgs
		Private _Image As Image
		Public Sub New(ByVal image As Image)
			_Image = image
		End Sub
		Public Overridable Property Image() As Image
			Get
				Return _Image
			End Get
			Set(ByVal value As Image)
				_Image = value
			End Set
		End Property
	End Class
End Namespace
