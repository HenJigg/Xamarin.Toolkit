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
                Messenger.Default.Send("", "AddAccount");
            });
            Messenger.Default.Register<LockBoxDetail>(this, "SaveAccount", (arg) =>
            {
                GridModelDetailList = new ObservableCollection<LockBoxDetail>();
                GridModelDetailList.Add(new LockBoxDetail()
                {
                    Account = arg.Account,
                    Name = arg.Name,
                    PassWord = arg.PassWord
                });
            });
        }

        private ObservableCollection<LockBoxDetail> gridModelDetailList;

        public ObservableCollection<LockBoxDetail> GridModelDetailList
        {
            get { return gridModelDetailList; }
            set { gridModelDetailList = value; RaisePropertyChanged(); }
        }

        public RelayCommand AddCommand { get; set; }

    }
}
