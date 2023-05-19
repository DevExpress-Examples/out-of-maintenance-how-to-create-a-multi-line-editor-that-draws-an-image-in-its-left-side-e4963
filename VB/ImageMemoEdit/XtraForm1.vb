Imports System
Imports System.Data
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports System.Diagnostics

Namespace ImageTextEdit

    Public Partial Class XtraForm1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            customGridControl1.DataSource = MakeAdditionalTable()
            customGridView1.OptionsView.RowAutoHeight = True
            customGridView1.OptionsPrint.AutoWidth = False
            'gridColumn2.MinWidth = myRepositoryItemMemoEdit1.ContentImageSize.Width + 10;
            'customGridView1.Columns[1].ColumnEdit = repositoryItemMemoEdit1;
            customGridView1.OptionsView.ColumnAutoWidth = False
            myRepositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None
        End Sub

        Public Function MakeAdditionalTable() As DataTable
            Dim _r As Random = New Random()
            Dim table As DataTable = New DataTable("FirstTable")
            Dim column As DataColumn
            Dim row As DataRow
            column = New DataColumn()
            column.DataType = GetType(Integer)
            column.ColumnName = "value1"
            column.AutoIncrement = False
            column.Caption = "value1"
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)
            column = New DataColumn()
            column.DataType = GetType(String)
            column.ColumnName = "value2"
            column.AutoIncrement = False
            column.Caption = "value2"
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)
            column = New DataColumn()
            column.DataType = GetType(Image)
            column.ColumnName = "value3"
            column.AutoIncrement = False
            column.Caption = "value3"
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)
            For i As Integer = 0 To 70
                Dim img As Image = New Bitmap(50, 50)
                Dim _g As Graphics = Graphics.FromImage(img)
                _g.Clear(Color.FromArgb(_r.Next(255), _r.Next(255), _r.Next(255)))
                row = table.NewRow()
                row("value1") = i
                row("value2") = "test test test test test" & i
                row("value3") = img
                table.Rows.Add(row)
            Next

            Return table
        End Function

        Private Sub customGridView1_OnSmartIconSelection(ByVal sender As Object, ByVal e As SmartIconSelectionEventArgs)
            Dim view As CustomGridView = CType(sender, CustomGridView)
            Dim image As Image = CType(view.GetRowCellValue(e.CellInfo.RowHandle, "value3"), Image)
            e.Image = image
        End Sub
    End Class
End Namespace
