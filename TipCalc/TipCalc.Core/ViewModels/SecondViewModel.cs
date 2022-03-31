using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TipCalc.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel<(double subtotal, double tip)>
    {
        private readonly IMvxNavigationService _navigationService;

        public SecondViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _subtotal = 1;
            _tip = 0.5;
            _rememberMe = true;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Close(this));
        }
        
        public override void Prepare((double subtotal, double tip) parameter)
        {
            _subtotal = parameter.subtotal;
            _tip = parameter.tip;
        }
        
        
        private double _subtotal;
        private double _tip;

        public double Subtotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                RaisePropertyChanged(() => Subtotal);
            }
        }
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
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
        
        public IMvxAsyncCommand CloseCommand { get; private set; }
    }
}
