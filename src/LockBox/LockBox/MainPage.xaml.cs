using GalaSoft.MvvmLight.Messaging;
using Toolkit.Common;
using Toolkit.Core;
using Toolkit.View;
using Toolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Toolkit
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;
        MainViewDetailModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Messenger.Default.Register<ToolkitInfo>(this, "SelectedItemToken", SelectedItem);
            vm = new MainViewModel();
            viewModel = new MainViewDetailModel();
            this.BindingContext = vm;
        }

        async void SelectedItem(ToolkitInfo boxInfo)
        {
            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex("#1E90FF");
            viewModel.ToolkitMaster = boxInfo.Master;
            viewModel.GridModelDetailList = boxInfo.Details;
            await Navigation.PushAsync(new MainPageDetail()
            {
                Title = boxInfo.Master.GroupName,
                BindingContext = viewModel
            });
            CollectionView.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.InitDataAsync();
        }
    }
}
