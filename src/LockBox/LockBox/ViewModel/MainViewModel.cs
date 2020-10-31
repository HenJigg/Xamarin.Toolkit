using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LockBox.Common;
using LockBox.Core;
using LockBox.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LockBox.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SelectItemCommand = new RelayCommand<LockBoxMaster>(async arg =>
             {
                 if (arg != null)
                 {
                     LockBoxInfo inf = new LockBoxInfo();
                     inf.Master = arg;
                     inf.Details = new ObservableCollection<LockBoxDetail>();
                     var result= await service.GetLockBoxDetailsAsync(arg.Id);
                     result?.ForEach(item =>
                     {
                         inf.Details.Add(item);
                     });
                     Messenger.Default.Send(inf, "SelectedItemToken");
                 }
                    
             });
            this.service = DependencyService.Get<ILockBoxService>();
        }

        private ObservableCollection<LockBoxMaster> gridmodel;
        private readonly ILockBoxService service;

        public ObservableCollection<LockBoxMaster> GridModelList
        {
            get { return gridmodel; }
            set { gridmodel = value; RaisePropertyChanged(); }
        }

        public RelayCommand<LockBoxMaster> SelectItemCommand { get; private set; }

        public async Task InitDataAsync()
        {
            var result = await service.GetLockBoxMastersAsync();
            GridModelList = new ObservableCollection<LockBoxMaster>();
            result?.ForEach(arg =>
            {
                GridModelList.Add(arg);
            });
        }
    }
}
