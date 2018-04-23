using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;

namespace EditorDescendant
{
    public class MyMemoEditPainter : MemoEditPainter
    {

        public MyMemoEditPainter()
        {

        }

        public override void Draw(ControlGraphicsInfoArgs info)
        {
            info.Cache.FillRectangle(Brushes.White, info.Bounds);
            base.Draw(info);
        }

        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            base.DrawContent(info);
            DrawIcon(info);
        }

        protected virtual void DrawIcon(ControlGraphicsInfoArgs info)
        {
            MyMemoEditViewInfo vi = info.ViewInfo as MyMemoEditViewInfo;

            Image img = vi.GetImage();
            if (img != null)
            {
                Rectangle rec = new Rectangle(info.Bounds.X + vi.IconRect.X, info.Bounds.Y + vi.IconRect.Y, vi.IconRect.Width, vi.IconRect.Height);
                info.Graphics.DrawImage(img, rec);
            }
            else
                info.Graphics.FillRectangle(info.Cache.GetSolidBrush(Color.White), vi.IconRect);
        }
    }
}
