using System;
using MvcMvvmArticle.MVVM;

namespace MvcMvvmArticle.MVC.Views
{
    public interface IMainView : IView
    {
        ApplicationViewModel ViewModel {get; set;}

        event Func<bool> LoadApplicationViewModel;
        event Func<Guid, bool> LoadItemModel;

        void CallbackMethod<TData>(TData someData);
    }
}
