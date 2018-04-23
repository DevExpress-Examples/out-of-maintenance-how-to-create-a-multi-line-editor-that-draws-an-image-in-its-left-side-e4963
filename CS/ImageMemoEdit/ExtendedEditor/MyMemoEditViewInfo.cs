using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;

namespace EditorDescendant
{
    public class MyMemoEditViewInfo : MemoEditViewInfo, IHeightAdaptable
    {
        int IHeightAdaptable.CalcHeight(GraphicsCache cache, int width)
        {
            width -= ((MyRepositoryItemMemoEdit)Item).ContentImageSize.Width;
            BorderObjectInfoArgs info = new BorderObjectInfoArgs(cache);
            info.Bounds = new Rectangle(0, 0, width, 100);
            Rectangle textRect = BorderPainter.GetObjectClientRectangle(info);
            if (!(BorderPainter is EmptyBorderPainter) && !(BorderPainter is InplaceBorderPainter))
                textRect.Inflate(-1, -1);
            string text = string.Empty;
            if (Item.LinesCount == 0)
            {
                text = DisplayText;
                if (text != null && text.Length > 0)
                {
                    char lastChar = text[text.Length - 1];
                    if (lastChar == 13 || lastChar == 10) text += "W";
                }
            }
            else
            {
                for (int i = 0; i < Item.LinesCount; i++)
                    text += (string.IsNullOrEmpty(text) ? "" : Environment.NewLine) + "W";
            }
            int height1 = CalcTextSizeCore(cache, text, textRect.Width).Height + 1;
            return (height1 + 100 - textRect.Bottom) + 1;
        }

        public MyMemoEditViewInfo(RepositoryItem item)
            : base(item)
        { }

        protected override Rectangle CalcMaskBoxRect(Rectangle content, ref Rectangle contextImageBounds)
        {
            Rectangle r = base.CalcMaskBoxRect(content, ref contextImageBounds);
            int width = IconRect.Width;
            r.Width = r.Width - width;
            r.X = r.X + width;
            return r;
        }
        
        protected override void Assign(BaseControlViewInfo info)
        {
            base.Assign(info);
            MyMemoEditViewInfo be = info as MyMemoEditViewInfo;
            if (be == null) return;
            this.fIconRect = be.fIconRect;
        }

        protected override Size CalcClientSize(Graphics g)
        {
            Size size = base.CalcClientSize(g);
            size.Width += this.Item.ContentImageSize.Width;
            return size;
        }
        
        protected override void CalcContentRect(Rectangle bounds)
        {
            Rectangle r = Rectangle.Empty;
            this.fIconRect = CalcIconRect(ContentRect);
            base.CalcContentRect(bounds);
            this.fMaskBoxRect = CalcMaskBoxRect(bounds, ref r);
        }

        protected virtual Rectangle CalcIconRect(Rectangle content)
        {
            Rectangle r = fMaskBoxRect;
            r.Size = Item.ContentImageSize;
            r.Location = content.Location;
            return r;
        }

        public virtual new MyRepositoryItemMemoEdit Item
        {
            get { return base.Item as MyRepositoryItemMemoEdit; }
        }

        public Image GetImage() 
        {
            return Item.GetImage();
        }

        Rectangle fIconRect;

        protected internal virtual Rectangle IconRect
        {
            get { return fIconRect; }
            set { fIconRect = value; }
        }
    }
}
