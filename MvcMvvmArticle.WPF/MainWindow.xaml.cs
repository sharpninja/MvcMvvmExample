using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MvcMvvmArticle.MVC;
using MvcMvvmArticle.MVC.Views;
using MvcMvvmArticle.MVVM;

namespace MvcMvvmArticle.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        private readonly Controller _controller = null;

        public event Func<IMainView, bool> LoadApplicationViewModel;

        public ApplicationViewModel ViewModel 
        {
            get => DataContext as ApplicationViewModel;
            set => DataContext = value;
        }

        public Guid ViewID { get; } = Guid.NewGuid();

        public MainWindow(
            Controller controller
            , ApplicationViewModel viewModel)
        {
            _controller = controller;
            _controller.AddView(this);

            InitializeComponent();

            ViewModel = viewModel;

            Loaded += (s, a) => {
                if(!(LoadApplicationViewModel?.Invoke(this) ?? false))
                {
                    MessageBox.Show("Could not load data.");
                }
            };
        }

        public void CallbackMethod<TData>(TData someData)
        {
            MessageBox.Show($"Received {someData} from controller.");
        }
    }
}
