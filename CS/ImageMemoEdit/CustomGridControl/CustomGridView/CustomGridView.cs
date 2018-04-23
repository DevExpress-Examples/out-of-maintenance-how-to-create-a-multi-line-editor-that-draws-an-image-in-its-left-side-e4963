using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using EditorDescendant;
using DevExpress.XtraGrid.Views.Printing;

namespace ImageTextEdit
{
    [System.ComponentModel.DesignerCategory("")]
    public class CustomGridView : GridView
    {
        GridCellInfo nowDrawingCellInfo;
        public CustomGridView() : base() { }
        public CustomGridView(GridControl grid) : base(grid) { }

        private static readonly object _onSmartIconSelection = new object();

        public override void Assign(BaseView v, bool copyEvents)
        {
            if (v == null) return;
            BeginUpdate();
            try
            {
                CustomGridView gv = v as CustomGridView;
                if (gv != null)
                    if (copyEvents)
                        Events.AddHandler(_onSmartIconSelection, gv.Events[_onSmartIconSelection]);
            }
            finally { EndUpdate(); }
        }
        public event OnSmartIconSelectionEventHandler OnSmartIconSelection
        {
            add { this.Events.AddHandler(_onSmartIconSelection, value); }
            remove { this.Events.RemoveHandler(_onSmartIconSelection, value); }
        }
        protected internal virtual void RaiseOnSmartIconSelection(SmartIconSelectionEventArgs e)
        {
            OnSmartIconSelectionEventHandler handler = (OnSmartIconSelectionEventHandler)Events[_onSmartIconSelection];
            if (handler != null) handler(this, e);
        }
        protected override string ViewName { get { return "CustomGridView"; } }
        protected override void ActivateEditor(GridCellInfo cell)
        {
            IIconSelector iconSelector = cell.Editor as IIconSelector;
            if (iconSelector != null)
            {
                iconSelector.OnIconSelection += new EditorDescendant.MyRepositoryItemMemoEdit.IconSelectionEventHandler(iconSelector_OnIconSelection);
                nowDrawingCellInfo = cell;
            }
            base.ActivateEditor(cell);
        }

        public override void HideEditor()
        {
            if (!IsEditing || !fAllowCloseEditor) return;
            if (ActiveEditor != null && GridControl != null)
            {
                IIconSelector iconSelector = ActiveEditor.Properties as IIconSelector;
                if (iconSelector != null)
                    iconSelector.OnIconSelection -= new MyRepositoryItemMemoEdit.IconSelectionEventHandler(iconSelector_OnIconSelection);
            }
            base.HideEditor();
        }

        protected override BaseViewPrintInfo CreatePrintInfoInstance(PrintInfoArgs args)
        {
            BaseViewPrintInfo info = new MyGridViewPrintInfo(args);
            return info;
        }

        internal void iconSelector_OnIconSelection(object sender, IconSelectionEventArgs e)
        {
            SmartIconSelectionEventArgs ee = new SmartIconSelectionEventArgs(e.Image, nowDrawingCellInfo, true);
            RaiseOnSmartIconSelection(ee);
            e.Image = ee.Image;
        }
    }
}
