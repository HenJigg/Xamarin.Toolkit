using LockBox.Core;
using LockBox.Interfaces;
using LockBox.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LockBox
{
    public partial class App : Application
    {
        public static LockBoxDataContext _context;
        public static LockBoxDataContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new LockBoxDataContext(Constants.DatabasePath);
                }
                return _context;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ILockBoxService, LockBoxService>();
            Constants.DataBaseInitAsync(Instance);
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
