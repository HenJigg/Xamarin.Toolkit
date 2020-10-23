using System;
using System.Collections.Generic;
using System.Text;

namespace LockBox.Core
{
    public class LockBoxDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
    }
}
