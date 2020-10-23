using LockBox.Common;
using LockBox.Core;
using LockBox.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LockBox.ViewModel
{
    public class MainViewModel : ObservableObject
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
                     WeakReferenceMessenger.Default.Send(inf, "SelectedItemToken");
                 }
                    
             });
            this.service = DependencyService.Get<ILockBoxService>();
        }

        private ObservableCollection<LockBoxMaster> gridmodel;
        private readonly ILockBoxService service;

        public ObservableCollection<LockBoxMaster> GridModelList
        {
            get { return gridmodel; }
            set { gridmodel = value; OnPropertyChanged(); }
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
