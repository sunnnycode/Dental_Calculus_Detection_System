using System;
using WPFtartarUI.Core;

namespace WPFtartarUI.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand TartarDataViewCommand { get; set; }
        public RelayCommand DiseaseInformationCommand { get; set; }

        public HomeViewModel HomeVM{get; set;}
        public TartarDataViewModel TartarDataVM { get; set; }
        public DiseaseInformationViewModel DiseaseInformationVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }

        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            TartarDataVM = new TartarDataViewModel();
            DiseaseInformationVM = new DiseaseInformationViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            TartarDataViewCommand = new RelayCommand(o =>
            {
                CurrentView = TartarDataVM;
            });

            DiseaseInformationCommand = new RelayCommand(o =>
            {
                CurrentView = DiseaseInformationVM;
            });
        }
    }
}
