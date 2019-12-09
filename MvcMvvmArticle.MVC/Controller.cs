using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using MvcMvvmArticle.DataLayer;
using MvcMvvmArticle.MVC.Views;
using MvcMvvmArticle.MVVM;

namespace MvcMvvmArticle.MVC
{
    public class Controller
    {
        private Timer _timer = null;

        private void Tick(object state)
        {
            var mainViews = Views.Where(v => v.Value is IMainView).ToList();

            mainViews.ForEach(mv =>
            {
                if (mv.Value is IMainView mainView)
                {
                    mainView.CallbackMethod(DateTime.Now);
                }
            });
        }

        private ConcurrentDictionary<Guid, IView> Views { get; } =
            new ConcurrentDictionary<Guid, IView>();

        public Controller()
        {
            _timer = new Timer(Tick);
        }

        public TView AddView<TView>(TView view)
            where TView : IView
        {
            Views.TryAdd(view.ViewID, view);

            switch (view)
            {
                case IMainView mainView:
                    AddMainView(mainView);
                    break;
            }

            return view;
        }

        private static void AddMainView(IMainView mainView)
        {
            mainView.LoadApplicationViewModel += LoadApplicationViewModel;
        }

        private static bool LoadApplicationViewModel(IMainView view)
        {
            var names = DataFactory.GetNames().ToList();

            view.ViewModel.Names.Clear();

            names.ForEach(view.ViewModel.Names.Add);

            view.ViewModel.OnPropertyChanged(nameof(ApplicationViewModel.FilteredNames));

            return true;
        }
    }
}
