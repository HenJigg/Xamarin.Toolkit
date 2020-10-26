using GalaSoft.MvvmLight.Messaging;
using LockBox.Common;
using LockBox.Core;
using LockBox.View;
using LockBox.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LockBox
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Messenger.Default.Register<LockBoxInfo>(this, "SelectedItemToken", SelectedItem);
            vm = new MainViewModel();
            this.BindingContext = vm;
        }

        async void SelectedItem(LockBoxInfo boxInfo)
        {
            await Navigation.PushAsync(new MainPageDetail()
            {
                Title = boxInfo.Master.GroupName,
                BindingContext = new MainViewDetailModel()
                {
                    GridModelDetailList = boxInfo.Details
                }
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.InitDataAsync();
        }
    }
}
