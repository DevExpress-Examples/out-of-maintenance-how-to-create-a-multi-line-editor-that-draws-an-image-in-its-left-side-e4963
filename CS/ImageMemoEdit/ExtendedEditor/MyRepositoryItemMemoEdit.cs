using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.NativeBricks;
using System.Drawing;
using ImageTextEdit;

namespace EditorDescendant
{
    [System.ComponentModel.DesignerCategory("")]
    public class MyRepositoryItemMemoEdit : RepositoryItemMemoEdit, IIconSelector
    {
        private Size _ContentImageSize;
        private static readonly object _onSmartIconSelection = new object();


        #region Service

        static MyRepositoryItemMemoEdit()
        {
            Register();
        }

        public MyRepositoryItemMemoEdit()
        {
        }


        internal const string EditorName = "MyMemoEdit";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(
                new EditorClassInfo(EditorName, typeof(MyMemoEdit),
                typeof(MyRepositoryItemMemoEdit),
                typeof(MyMemoEditViewInfo),
                new MyMemoEditPainter(), true,
                EditImageIndexes.MemoEdit, typeof(DevExpress.Accessibility.BaseEditAccessible)));
        }

        public override string EditorTypeName
        {

            get { return EditorName; }

        }

        #endregion

        protected internal Image GetImage()
        {
            IconSelectionEventArgs args = new IconSelectionEventArgs(null);
            RaiseOnIconSelection(args);
            return args.Image;
        }

        public Size ContentImageSize
        {
            get
            {
                return _ContentImageSize;
            }
            set
            {
                _ContentImageSize = value;
            }
        }

        public override void Assign(RepositoryItem item)
        {
            base.Assign(item);
            MyRepositoryItemMemoEdit source = item as MyRepositoryItemMemoEdit;
            ContentImageSize = source.ContentImageSize;
            Events.AddHandler(_onSmartIconSelection, source.Events[_onSmartIconSelection]);
        }

        public override IVisualBrick GetBrick(PrintCellHelperInfo info)
        {
            TextBrick contentBrick = (TextBrick)base.GetBrick(info);
            ImageBrick imgBrick = new ImageBrick();

            IPanelBrick panelBrick = new XETextPanelBrick(CreateBrickStyle(info, "panel"));
            SetCommonBrickProperties(panelBrick, info);
            panelBrick.Bricks.Add(imgBrick);
            panelBrick.Bricks.Add(contentBrick);
            
            imgBrick.Image = GetImage();
            imgBrick.Size = ContentImageSize;
            panelBrick.Style = contentBrick.Style;

            contentBrick.Location = new PointFloat(imgBrick.Location.X + imgBrick.Size.Width, 0);
            contentBrick.Sides = BorderSide.None;
            contentBrick.Size = new SizeF(info.Rectangle.Size.Width - imgBrick.Size.Width, info.Rectangle.Size.Height);
            panelBrick.Rect = new RectangleF(0, 0, contentBrick.Rect.Width + imgBrick.Size.Width, contentBrick.Rect.Height);


            return panelBrick;
        }

        public delegate void IconSelectionEventHandler(object sender, IconSelectionEventArgs e);
        public event IconSelectionEventHandler OnIconSelection
        {
            add { this.Events.AddHandler(_onSmartIconSelection, value); }
            remove { this.Events.RemoveHandler(_onSmartIconSelection, value); }
        }

        protected internal virtual void RaiseOnIconSelection(IconSelectionEventArgs e)
        {
            IconSelectionEventHandler handler = (IconSelectionEventHandler)this.Events[_onSmartIconSelection];
            if (handler != null)
                handler(this, e);
        }

    }

}
