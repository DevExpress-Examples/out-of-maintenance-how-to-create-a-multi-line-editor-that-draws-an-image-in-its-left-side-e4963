using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Diagnostics;

namespace ImageTextEdit
{
    public partial class XtraForm1 : XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
            customGridControl1.DataSource = MakeAdditionalTable();
            customGridView1.OptionsView.RowAutoHeight = true;
            customGridView1.OptionsPrint.AutoWidth = false;

            //gridColumn2.MinWidth = myRepositoryItemMemoEdit1.ContentImageSize.Width + 10;
            //customGridView1.Columns[1].ColumnEdit = repositoryItemMemoEdit1;
            customGridView1.OptionsView.ColumnAutoWidth = false;
            myRepositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None;
        }

        public DataTable MakeAdditionalTable()
        {
            Random _r = new Random();

            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "value1";
            column.AutoIncrement = false;
            column.Caption = "value1";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "value2";
            column.AutoIncrement = false;
            column.Caption = "value2";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Image);
            column.ColumnName = "value3";
            column.AutoIncrement = false;
            column.Caption = "value3";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            for (int i = 0; i <= 70; i++)
            {
                Image img = new Bitmap(50, 50);
                Graphics _g = Graphics.FromImage(img);
                _g.Clear(Color.FromArgb(_r.Next(255), _r.Next(255), _r.Next(255)));

                row = table.NewRow();
                row["value1"] = i;
                row["value2"] = "test test test test test" + i;
                row["value3"] = img;
                table.Rows.Add(row);
            }

            return table;
        }

        private void customGridView1_OnSmartIconSelection(object sender, SmartIconSelectionEventArgs e)
        {
            CustomGridView view = (CustomGridView)sender;
            Image image = (Image)view.GetRowCellValue(e.CellInfo.RowHandle, "value3");
            e.Image = image;
        }
    }
}