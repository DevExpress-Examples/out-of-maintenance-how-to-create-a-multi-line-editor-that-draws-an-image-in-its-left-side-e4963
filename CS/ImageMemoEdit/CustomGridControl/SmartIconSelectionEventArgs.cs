using System;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.ComponentModel;
using EditorDescendant;
using System.Drawing;

namespace ImageTextEdit
{
    public class SmartIconSelectionEventArgs : IconSelectionEventArgs
    {
        bool isActiveEditor;
        GridCellInfo cellInfo;
        public SmartIconSelectionEventArgs(Image image, GridCellInfo cellInfo, bool isActiveEditor)
            : base(image)
        {
            this.cellInfo = cellInfo;
            this.isActiveEditor = isActiveEditor;
        }
        public GridCellInfo CellInfo { get { return cellInfo; } }
        public bool IsActiveEditor { get { return isActiveEditor; } }
    }
}
