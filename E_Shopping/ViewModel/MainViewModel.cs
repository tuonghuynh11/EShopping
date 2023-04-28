using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private object _currentView;
        private Stack<object> _stackCurrentView;
        public Stack<object> StackCurrentView
        {
            get { return _stackCurrentView; }
            set
            {
                _stackCurrentView = value;
                OnPropertyChanged();
            }
        }
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public MainViewModel()
        {
            CurrentView = new SearchFilterProductViewModel();
        }
    }
}
