using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcMvvmArticle.MVC;
using MvcMvvmArticle.MVC.Views;
using MvcMvvmArticle.MVVM;
using Xamarin.Forms;

namespace MvcMvvmArticle.Android
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, IMainView
    {
        private readonly Controller _controller = null;

        public event Func<IMainView, bool> LoadApplicationViewModel;

        public ApplicationViewModel ViewModel
        {
            get => BindingContext as ApplicationViewModel;
            set => BindingContext = value;
        }

        public Guid ViewID { get; } = Guid.NewGuid();

        public MainPage(
            Controller controller
            , ApplicationViewModel viewModel)
        {
            _controller = controller;
            _controller.AddView(this);

            InitializeComponent();

            ViewModel = viewModel;
            

            Appearing += (s, a) => {
                if (!(LoadApplicationViewModel?.Invoke(this) ?? false))
                {
                    DependencyService.Get<IMessage>().LongAlert("Could not load data.");
                }
            };
        }

        public void CallbackMethod<TData>(TData someData)
        {
            DependencyService.Get<IMessage>().ShortAlert($"Received {someData} from controller.");
        }
    }
}
