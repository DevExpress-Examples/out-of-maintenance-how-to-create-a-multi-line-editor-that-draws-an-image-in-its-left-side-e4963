using System;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.ComponentModel;

namespace ImageTextEdit
{
    [System.ComponentModel.DesignerCategory("")]
    [System.ComponentModel.ToolboxItem(true)]
    public class CustomGridControl : GridControl
    {
        public CustomGridControl() : base() { }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridInfoRegistrator());
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("CustomGridView");
        }
    }
    public delegate void OnSmartIconSelectionEventHandler(object sender, SmartIconSelectionEventArgs e);
}
