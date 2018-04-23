using DevExpress.XtraEditors.Repository;
using EditorDescendant;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
namespace ImageTextEdit
{
    partial class XtraForm1
    {

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.customGridControl1 = new ImageTextEdit.CustomGridControl();
            this.customGridView1 = new ImageTextEdit.CustomGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.myRepositoryItemMemoEdit1 = new EditorDescendant.MyRepositoryItemMemoEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myRepositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridControl1
            // 
            this.customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridControl1.Location = new System.Drawing.Point(0, 0);
            this.customGridControl1.MainView = this.customGridView1;
            this.customGridControl1.Name = "customGridControl1";
            this.customGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.myRepositoryItemMemoEdit1,
            this.repositoryItemMemoEdit1});
            this.customGridControl1.Size = new System.Drawing.Size(745, 461);
            this.customGridControl1.TabIndex = 0;
            this.customGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView1});
            // 
            // customGridView1
            // 
            this.customGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.customGridView1.GridControl = this.customGridControl1;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.OnSmartIconSelection += new ImageTextEdit.OnSmartIconSelectionEventHandler(this.customGridView1_OnSmartIconSelection);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "value1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.ColumnEdit = this.myRepositoryItemMemoEdit1;
            this.gridColumn2.FieldName = "value2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // myRepositoryItemMemoEdit1
            // 
            this.myRepositoryItemMemoEdit1.ContentImageSize = new System.Drawing.Size(24, 24);
            this.myRepositoryItemMemoEdit1.Name = "myRepositoryItemMemoEdit1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 461);
            this.Controls.Add(this.customGridControl1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myRepositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }   
        #endregion

        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private MyRepositoryItemMemoEdit myRepositoryItemMemoEdit1;
        private RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private CustomGridView customGridView1;
        private CustomGridControl customGridControl1;
    }
}