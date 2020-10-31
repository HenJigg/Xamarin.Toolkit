using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toolkit.Core
{
    public class ToolkitDetail : ViewModelBase
    {
        private string name;
        private string account;
        private string password;

        public int Id { get; set; }
        public int MasterId { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        public string Account
        {
            get { return account; }
            set { account = value; RaisePropertyChanged(); }
        }
        public string PassWord
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }
    }
}
