using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Printing;
using EditorDescendant;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ImageTextEdit
{
    public class MyGridViewPrintInfo : GridViewPrintInfo
    {
        public MyGridViewPrintInfo(PrintInfoArgs args)
            : base(args)
        {

        }
        public virtual new CustomGridView View { get { return (CustomGridView)base.View; } }
        GridCellInfo nowPrintingCellInfo;

        protected override void PrintRowCell(int rowHandle, GridCellInfo cell, System.Drawing.Rectangle r)
        {
            IIconSelector iconSelector = cell.Editor as IIconSelector;
            if (iconSelector != null)
            {
                MyRepositoryItemMemoEdit.IconSelectionEventHandler EH = new MyRepositoryItemMemoEdit.IconSelectionEventHandler(iconSelector_OnIconSelection);
                iconSelector.OnIconSelection += EH;
                nowPrintingCellInfo = cell;
                try
                {
                    base.PrintRowCell(rowHandle, cell, r);
                }
                finally
                {
                    iconSelector.OnIconSelection -= EH;
                }
            }
            else
                base.PrintRowCell(rowHandle, cell, r);

        }

        void iconSelector_OnIconSelection(object sender, IconSelectionEventArgs e)
        {
            SmartIconSelectionEventArgs ee = new SmartIconSelectionEventArgs(e.Image, nowPrintingCellInfo, false);
            View.RaiseOnSmartIconSelection(ee);
            e.Image = ee.Image;
        }
    }
}
