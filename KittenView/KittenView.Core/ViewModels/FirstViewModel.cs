using KittenView.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KittenView.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IKittenGenesisService _kittenGenesisService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IDataService _dataService;

        private string _convertString;
        public string ConvertString
        {
            get { return _convertString; }
            set
            {
                _convertString = value;
                RaisePropertyChanged(() => ConvertString);
            }
        }

        private ObservableCollection<Kitten> _kittens;
        public ObservableCollection<Kitten> Kittens
        {
            get { return _kittens; }
            set
            {
                _kittens = value;
                RaisePropertyChanged(() => Kittens);
            }
        }

        public FirstViewModel(IKittenGenesisService kittenGenesisService, IMvxNavigationService navigationService, IDataService dataService)
        {
            _kittenGenesisService = kittenGenesisService;
            _navigationService = navigationService;
            _dataService = dataService;

        }

        public override async Task Initialize()
        {
            await base.Initialize();
            Kittens = _dataService.GetKittenList();
        }
        private MvxCommand _clickAddNewKitten;
        public IMvxCommand ClickAddNewKitten
        {
            get { return new MvxCommand(AddKitten); }
        }

        public void AddKitten()
        {
            var newKitten = _kittenGenesisService.CreatNewKitten("");
            //Kittens.Add(newKitten);
            _dataService.AddKitten(newKitten);
            Kittens = _dataService.GetKittenList();
        }



        private MvxCommand _clickClearAllKitten;
        public IMvxCommand ClickClearAllKitten
        {
            get { return new MvxCommand(ClearKittens); }
        }

        public void ClearKittens()
        {
            _dataService.ClearAllKitten();
            Console.WriteLine(_dataService.GetKittenList().Count);
            Kittens = _dataService.GetKittenList();

        }

        private MvxCommand<Kitten> _memoryClickedCommand;
        public IMvxCommand MemoryClickedCommand
        {
            get
            {
                return _memoryClickedCommand = new MvxCommand<Kitten>(memory =>
                    {
                        Console.WriteLine("CLICKED__memoryClickedCommand");
                        _navigationService.Navigate<SecondViewModel, Kitten>(memory);
                    });
            }
        }

        private MvxCommand<Kitten> _doDeleteBookCommand;
        public IMvxCommand DoDeleteBookCommand
        {
            get
            {
                return _doDeleteBookCommand = _doDeleteBookCommand ?? new MvxCommand<Kitten>(DeleteKitten);
            }
        }

        public void DeleteKitten(Kitten kitten)
        {
            Kitten kittenToRemove = (Kitten)Kittens.Where(x => x.ID == kitten.ID);
            if (kittenToRemove != null)
            {
                Kittens.Remove(kittenToRemove);
            }
        }
    }
}
