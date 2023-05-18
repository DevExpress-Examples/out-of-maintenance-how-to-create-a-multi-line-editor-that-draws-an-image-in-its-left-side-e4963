Imports DevExpress.XtraEditors.Repository
Imports EditorDescendant
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Namespace ImageTextEdit

    Partial Class XtraForm1

'#Region "Windows Form Designer generated code"
        Private Sub InitializeComponent()
            Me.customGridControl1 = New ImageTextEdit.CustomGridControl()
            Me.customGridView1 = New ImageTextEdit.CustomGridView()
            Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.gridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.myRepositoryItemMemoEdit1 = New EditorDescendant.MyRepositoryItemMemoEdit()
            Me.repositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
            CType((Me.customGridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.customGridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.myRepositoryItemMemoEdit1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.repositoryItemMemoEdit1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' customGridControl1
            ' 
            Me.customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.customGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.customGridControl1.MainView = Me.customGridView1
            Me.customGridControl1.Name = "customGridControl1"
            Me.customGridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.myRepositoryItemMemoEdit1, Me.repositoryItemMemoEdit1})
            Me.customGridControl1.Size = New System.Drawing.Size(745, 461)
            Me.customGridControl1.TabIndex = 0
            Me.customGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.customGridView1})
            ' 
            ' customGridView1
            ' 
            Me.customGridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gridColumn1, Me.gridColumn2})
            Me.customGridView1.GridControl = Me.customGridControl1
            Me.customGridView1.Name = "customGridView1"
            AddHandler Me.customGridView1.OnSmartIconSelection, New ImageTextEdit.OnSmartIconSelectionEventHandler(AddressOf Me.customGridView1_OnSmartIconSelection)
            ' 
            ' gridColumn1
            ' 
            Me.gridColumn1.AppearanceCell.Options.UseTextOptions = True
            Me.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.gridColumn1.Caption = "gridColumn1"
            Me.gridColumn1.FieldName = "value1"
            Me.gridColumn1.Name = "gridColumn1"
            Me.gridColumn1.Visible = True
            Me.gridColumn1.VisibleIndex = 0
            ' 
            ' gridColumn2
            ' 
            Me.gridColumn2.Caption = "gridColumn2"
            Me.gridColumn2.ColumnEdit = Me.myRepositoryItemMemoEdit1
            Me.gridColumn2.FieldName = "value2"
            Me.gridColumn2.Name = "gridColumn2"
            Me.gridColumn2.Visible = True
            Me.gridColumn2.VisibleIndex = 1
            ' 
            ' myRepositoryItemMemoEdit1
            ' 
            Me.myRepositoryItemMemoEdit1.ContentImageSize = New System.Drawing.Size(24, 24)
            Me.myRepositoryItemMemoEdit1.Name = "myRepositoryItemMemoEdit1"
            ' 
            ' repositoryItemMemoEdit1
            ' 
            Me.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1"
            Me.repositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None
            ' 
            ' XtraForm1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(745, 461)
            Me.Controls.Add(Me.customGridControl1)
            Me.Name = "XtraForm1"
            Me.Text = "XtraForm1"
            CType((Me.customGridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.customGridView1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.myRepositoryItemMemoEdit1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.repositoryItemMemoEdit1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn

        Private gridColumn2 As DevExpress.XtraGrid.Columns.GridColumn

        Private myRepositoryItemMemoEdit1 As EditorDescendant.MyRepositoryItemMemoEdit

        Private repositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

        Private customGridView1 As ImageTextEdit.CustomGridView

        Private customGridControl1 As ImageTextEdit.CustomGridControl
    End Class
End Namespace
