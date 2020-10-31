using GalaSoft.MvvmLight.Messaging;
using LockBox.Core;
using LockBox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LockBox.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        public MainPageDetail()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, "AddAccount", AddAccount);
        }

        async void AddAccount(string arg)
        {
            await Navigation.PushAsync(new AddAccount()
            {
                Title = "新建账号",
                BindingContext = this.BindingContext
            });
        }

    }
}