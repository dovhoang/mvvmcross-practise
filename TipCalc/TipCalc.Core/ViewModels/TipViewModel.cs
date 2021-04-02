using TipCalc.Core.Services;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        readonly ICalculationService _calculationService;
        private readonly IMvxNavigationService _mvxNavigationService;

        public TipViewModel(ICalculationService calculationService, IMvxNavigationService mvxNavigationService)
        {
            _calculationService = calculationService;
            _mvxNavigationService = mvxNavigationService;
            NavigateCommand = new MvxAsyncCommand(() => _mvxNavigationService.Navigate<SecondViewModel>());

        }


        public override async Task Initialize()
        {
            await base.Initialize();

            _subTotal = 100;
            _generosity = 10;

            Recalculate();
            Console.WriteLine("LIFE_CYCLE: INITIALIZE");
        }

        public IMvxAsyncCommand NavigateCommand { get; private set; }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalculate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalculate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        public List<string> DataList
        {
            get => _dataList;
            set
            {
                _dataList = value;
                RaisePropertyChanged(() => DataList);
            }
        }

        private List<string> _dataList;


        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }

    }
}