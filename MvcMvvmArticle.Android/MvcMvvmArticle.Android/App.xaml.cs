using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvcMvvmArticle.Android
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(new MVC.Controller(), new MVVM.ApplicationViewModel());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
