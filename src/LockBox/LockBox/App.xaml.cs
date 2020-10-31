using Toolkit.Core;
using Toolkit.Interfaces;
using Toolkit.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Toolkit
{
    public partial class App : Application
    {
        public static ToolkitContext _context;
        public static ToolkitContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new ToolkitContext(Constants.DatabasePath);
                }
                return _context;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IToolkitService, ToolkitService>();
            Constants.DataBaseInitAsync(Instance);
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
