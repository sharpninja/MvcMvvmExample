using System;
using System.Collections.Concurrent;
using MvcMvvmArticle.MVC.Views;

namespace MvcMvvmArticle.MVC
{
    public class Controller
    {
        private ConcurrentDictionary<Guid, IView> Views { get; } =
            new ConcurrentDictionary<Guid, IView>();

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

        private void AddMainView(IMainView mainView)
        {
            mainView.LoadApplicationViewModel += LoadApplicationViewModel;
            mainView.LoadItemModel += LoadItemModel;
        }

        private bool LoadItemModel(Guid arg)
        {
            return false;
        }

        private bool LoadApplicationViewModel()
        {
            return false;
        }
    }
}
