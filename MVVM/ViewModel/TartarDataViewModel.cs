using System;
using WPFtartarUI.Core;

namespace WPFtartarUI.MVVM.ViewModel
{
    class TartarDataViewModel : ObservableObject
    {
        
        
        

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }

        }
        public TartarDataViewModel()
        {
           

        }
    }
}
