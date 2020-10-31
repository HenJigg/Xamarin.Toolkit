using GalaSoft.MvvmLight.Messaging;
using Toolkit.Core;
using Toolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Extensions.Caching.Memory;

namespace Toolkit.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        public MainPageDetail()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, "OpenView", OpenView);
        }

        async void OpenView(string arg)
        {
            await Navigation.PushAsync(new AddAccount()
            {
                Title = arg,
                BindingContext = this.BindingContext
            });
        }
    }
}