using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils;
using EditorDescendant;

namespace ImageTextEdit
{
    public class CustomGridPainter : GridPainter
    {
        GridCellInfo nowDrawingCellInfo;
        public CustomGridPainter(GridView view) : base(view) { }

        public virtual new CustomGridView View { get { return (CustomGridView)base.View; } }
        protected override void DrawCellEdit(GridViewDrawArgs e, BaseEditViewInfo editInfo, GridCellInfo cell, AppearanceObject appearance, bool isSelectedCell)
        {
            IIconSelector iconSelector = cell.Editor as IIconSelector;
            if (iconSelector != null)
            {
                MyRepositoryItemMemoEdit.IconSelectionEventHandler EH = new MyRepositoryItemMemoEdit.IconSelectionEventHandler(iconSelector_OnIconSelection);
                iconSelector.OnIconSelection += EH;
                nowDrawingCellInfo = cell;
                try
                {
                    base.DrawCellEdit(e, editInfo, cell, appearance, isSelectedCell);
                }
                finally
                {
                    iconSelector.OnIconSelection -= EH;
                }
            }
            else
                base.DrawCellEdit(e, editInfo, cell, appearance, isSelectedCell);
        }

        void iconSelector_OnIconSelection(object sender, IconSelectionEventArgs e)
        {
            SmartIconSelectionEventArgs ee = new SmartIconSelectionEventArgs(e.Image, nowDrawingCellInfo, false);
            View.RaiseOnSmartIconSelection(ee);
            e.Image = ee.Image;
        }
    }

}
