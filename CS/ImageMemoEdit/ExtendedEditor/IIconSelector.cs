using System;
using System.Collections.Generic;
using System.Text;

namespace ImageTextEdit
{
    public interface IIconSelector
    {
        event EditorDescendant.MyRepositoryItemMemoEdit.IconSelectionEventHandler OnIconSelection;
    }

}
