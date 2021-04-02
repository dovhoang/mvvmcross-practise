using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace TipCalc.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public SecondViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _id = 1;
            _name = "hoang";
            _rememberMe = true;
        }
        public SecondViewModel(int id, string name)
        {
            _id = id;
            _name = name;
        }
        private int _id;
        string _name;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private bool _rememberMe;
        public bool RememberMe
        {
            get => _rememberMe;
            set => SetProperty(ref _rememberMe, value);
        }
        private int _num;
        public int Num
        {
            get => _num;
            set => SetProperty(ref _num, value);
        }
    }
}
