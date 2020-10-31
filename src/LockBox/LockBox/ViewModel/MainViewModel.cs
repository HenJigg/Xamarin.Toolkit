using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Toolkit.Common;
using Toolkit.Core;
using Toolkit.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Toolkit.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SelectItemCommand = new RelayCommand<ToolkitMaster>(async arg =>
             {
                 if (arg != null)
                 {
                     ToolkitInfo inf = new ToolkitInfo();
                     inf.Master = arg;
                     inf.Details = new ObservableCollection<ToolkitDetail>();
                     var result= await service.GetToolkitDetailsAsync(arg.Id);
                     result?.ForEach(item =>
                     {
                         inf.Details.Add(item);
                     });
                     Messenger.Default.Send(inf, "SelectedItemToken");
                 }
                    
             });
            this.service = DependencyService.Get<IToolkitService>();
        }

        private ObservableCollection<ToolkitMaster> gridmodel;
        private readonly IToolkitService service;

        public ObservableCollection<ToolkitMaster> GridModelList
        {
            get { return gridmodel; }
            set { gridmodel = value; RaisePropertyChanged(); }
        }

        public RelayCommand<ToolkitMaster> SelectItemCommand { get; private set; }

        public async Task InitDataAsync()
        {
            var result = await service.GetToolkitMastersAsync();
            GridModelList = new ObservableCollection<ToolkitMaster>();
            result?.ForEach(arg =>
            {
                GridModelList.Add(arg);
            });
        }
    }
}
