using LockBox.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LockBox.Common
{
    public class LockBoxInfo
    {
        public LockBoxMaster  Master { get; set; }

        public ObservableCollection<LockBoxDetail> Details { get; set; }
    }
}
