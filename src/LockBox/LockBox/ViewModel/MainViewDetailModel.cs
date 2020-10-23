using LockBox.Core;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LockBox.ViewModel
{
    public class MainViewDetailModel : ObservableObject
    {
        public MainViewDetailModel()
        {

        }

        private ObservableCollection<LockBoxDetail> gridModelDetailList;

        public ObservableCollection<LockBoxDetail> GridModelDetailList
        {
            get { return gridModelDetailList; }
            set { gridModelDetailList = value; OnPropertyChanged(); }
        }
    }
}
