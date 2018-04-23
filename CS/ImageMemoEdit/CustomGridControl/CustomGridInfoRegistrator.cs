using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;

namespace ImageTextEdit
{
    public class CustomGridInfoRegistrator : GridInfoRegistrator
    {
        public CustomGridInfoRegistrator() : base() { }
        public override BaseViewPainter CreatePainter(BaseView view) { return new CustomGridPainter(view as CustomGridView); }
        public override string ViewName { get { return "CustomGridView"; } }
        public override BaseView CreateView(GridControl grid){return new CustomGridView(grid);}
    }
}
