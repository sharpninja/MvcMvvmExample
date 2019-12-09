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
        private Controller _controller = null;

        public event Func<bool> LoadApplicationViewModel;
        public event Func<Guid, bool> LoadItemModel;

        public ApplicationViewModel ViewModel 
        {
            get => DataContext as ApplicationViewModel;
            set => DataContext = value;
        }

        private Guid _viewId = Guid.NewGuid();
        public Guid ViewID => _viewId;

        public MainWindow(
            Controller controller
            , ApplicationViewModel viewModel)
        {
            _controller = controller;
            _controller.AddView(this);

            InitializeComponent();

            ViewModel = viewModel;

            Loaded += (s, a) => {
                if(!(LoadApplicationViewModel?.Invoke() ?? false))
                {
                    MessageBox.Show("Could not load data.");
                }
            };
        }

        public void CallbackMethod<TData>(TData someData)
        {
            throw new NotImplementedException();
        }
    }
}
