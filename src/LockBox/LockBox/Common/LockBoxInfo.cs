using Toolkit.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Toolkit.Common
{
    public class ToolkitInfo
    {
        public ToolkitMaster Master { get; set; }

        public ObservableCollection<ToolkitDetail> Details { get; set; }
    }
}
