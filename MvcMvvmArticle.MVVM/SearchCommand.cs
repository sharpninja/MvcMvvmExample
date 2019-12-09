using System;
using System.Windows.Input;

namespace MvcMvvmArticle.MVVM
{
    public class SearchCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ApplicationViewModel viewModel)
            {
                viewModel.OnPropertyChanged(nameof(ApplicationViewModel.FilteredNames));
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}