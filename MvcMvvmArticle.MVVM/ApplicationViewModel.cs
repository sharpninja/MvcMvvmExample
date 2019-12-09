using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using MvcMvvmArticle.MVVM.Annotations;

namespace MvcMvvmArticle.MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private string _filter = null;
        private bool _useRegexPattern = true;

        public ObservableCollection<string> Names { get; } = 
            new ObservableCollection<string>();

        public string Filter
        {
            get => _filter;
            set
            {
                if (value == _filter) return;
                _filter = value;
                OnPropertyChanged();
            }
        }

        public bool UseRegexPattern
        {
            get => _useRegexPattern;
            set
            {
                if (value == _useRegexPattern) return;
                _useRegexPattern = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> FilteredNames
        {
            get
            {
                foreach (var name in Names)
                {
                    if (Filter == null) yield return name;

                    else if (UseRegexPattern)
                    {
                        var regex = new Regex(Filter);
                        var match = regex.Match(name);
                        if (match.Success)
                        {
                            yield return match.Value;
                        }
                    }
                    else
                    {
                        if (name.StartsWith(Filter, StringComparison.InvariantCultureIgnoreCase))
                        {
                            yield return name;
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SearchCommand { get; } = new SearchCommand();
    }
}
