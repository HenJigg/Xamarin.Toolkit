using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LockBox.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LockBox.ViewModel
{
    public class MainViewDetailModel : ViewModelBase
    {
        public MainViewDetailModel()
        {
            AddCommand = new RelayCommand(() =>
            {
                LockBoxDetail = new LockBoxDetail();
                Messenger.Default.Send("", "AddAccount");
            });
            Messenger.Default.Register<string>(this, "SaveAccount", (arg) =>
            {
                GridModelDetailList.Add(LockBoxDetail);
            });
        }

        private ObservableCollection<LockBoxDetail> gridModelDetailList;

        public ObservableCollection<LockBoxDetail> GridModelDetailList
        {
            get { return gridModelDetailList; }
            set { gridModelDetailList = value; RaisePropertyChanged(); }
        }

        private LockBoxDetail lockBoxDetail;

        public LockBoxDetail LockBoxDetail
        {
            get { return lockBoxDetail; }
            set { lockBoxDetail = value; RaisePropertyChanged(); }
        }

        public RelayCommand AddCommand { get; set; }

    }
}
