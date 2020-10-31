using GalaSoft.MvvmLight.Messaging;
using LockBox.Core;
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
    public partial class AddAccount : ContentPage
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private async void SaveClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            Messenger.Default.Send("", "SaveAccount");
        }
    }
}