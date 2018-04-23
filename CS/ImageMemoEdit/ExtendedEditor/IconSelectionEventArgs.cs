using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace EditorDescendant
{
    public class IconSelectionEventArgs : EventArgs
    {
        Image _Image;
        public IconSelectionEventArgs(Image image)
        {
            _Image = image;
        }
        public virtual Image Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
    }
}
