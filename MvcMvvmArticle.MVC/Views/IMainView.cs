using System;
using MvcMvvmArticle.MVVM;

namespace MvcMvvmArticle.MVC.Views
{
    public interface IMainView : IView
    {
        ApplicationViewModel ViewModel {get; set;}

        event Func<IMainView, bool> LoadApplicationViewModel;

        void CallbackMethod<TData>(TData someData);
    }
}
