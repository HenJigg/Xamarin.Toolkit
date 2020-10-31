using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
    public class MainViewDetailModel : ViewModelBase
    {
        private readonly IToolkitService service;

        public MainViewDetailModel()
        {
            this.service = DependencyService.Get<IToolkitService>();
            AddCommand = new RelayCommand(() =>
            {
                ToolkitDetail = new ToolkitDetail();
                ToolkitDetail.MasterId = ToolkitMaster.Id;
                Messenger.Default.Send("新建账号", "OpenView");
            });
            EditCommand = new RelayCommand<int>(Edit);
            DeleteCommand = new RelayCommand<int>(Delete);
            Messenger.Default.Register<string>(this, "SaveAccount", Save);
        }

        private ToolkitMaster toolkitMaster;

        public ToolkitMaster ToolkitMaster
        {
            get { return toolkitMaster; }
            set { toolkitMaster = value; }
        }

        private ToolkitDetail toolkitDetail;
        private ObservableCollection<ToolkitDetail> gridModelDetailList;

        public ObservableCollection<ToolkitDetail> GridModelDetailList
        {
            get { return gridModelDetailList; }
            set { gridModelDetailList = value; RaisePropertyChanged(); }
        }

        public ToolkitDetail ToolkitDetail
        {
            get { return toolkitDetail; }
            set { toolkitDetail = value; RaisePropertyChanged(); }
        }

        #region Command

        public RelayCommand AddCommand { get; set; }

        public RelayCommand<int> EditCommand { get; set; }

        public RelayCommand<int> DeleteCommand { get; set; }

        #endregion

        async void Save(string empty)
        {
            if (ToolkitDetail.Id > 0)
                await service.UpdateToolkitDetail(ToolkitDetail);
            else
                await service.AddToolkitDetail(ToolkitDetail);

            await UpdateGridList();
        }

        async void Edit(int id)
        {
            ToolkitDetail = await service.GetToolkitDetailByIdAsync(id);
            Messenger.Default.Send("编辑账号", "OpenView");
        }

        async void Delete(int id)
        {
            var r = await App.Current.MainPage.DisplayAlert("警告", "确认删除该账号?", "确定", "取消");
            if (!r) return;
            await service.DeleteToolkitDetail(id);
            await UpdateGridList();
        }

        async Task UpdateGridList()
        {
            var boxs = await service.GetToolkitDetailsAsync(ToolkitMaster.Id);
            GridModelDetailList.Clear();
            boxs.ForEach(b =>
            {
                GridModelDetailList.Add(b);
            });
        }
    }
}
