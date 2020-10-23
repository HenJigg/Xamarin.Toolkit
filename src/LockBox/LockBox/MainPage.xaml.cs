using LockBox.Common;
using LockBox.Core;
using LockBox.View;
using LockBox.ViewModel;
using Microsoft.Toolkit.Mvvm.Messaging;
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
            WeakReferenceMessenger.Default.Register<LockBoxInfo, string>(this, "SelectedItemToken", SelectedItem);
            vm = new MainViewModel();
            this.BindingContext = vm;
        }

        async void SelectedItem(object obj, LockBoxInfo boxInfo)
        {
            await Navigation.PushAsync(new MainPageDetail()
            {
                Title = boxInfo.Master.GroupName,
                BindingContext = new MainViewDetailModel()
                {
                    GridModelDetailList = boxInfo.Details
                }
            });
            //await Task.Delay(100);
            //CollectionView.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.InitDataAsync();
        }
    }
}
