using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.ComponentModel;

namespace EditorDescendant
{
    [System.ComponentModel.DesignerCategory("")]
    [System.ComponentModel.ToolboxItem(true)]
    public class MyMemoEdit : MemoEdit
    {
        #region Service
        static MyMemoEdit()
        {
            MyRepositoryItemMemoEdit.Register();
        }

        public MyMemoEdit()
            : base()
        {
        }

        public override string EditorTypeName
        { get { return MyRepositoryItemMemoEdit.EditorName; } }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new MyRepositoryItemMemoEdit Properties
        { get { return base.Properties as MyRepositoryItemMemoEdit; } }

     #endregion
    }
}
