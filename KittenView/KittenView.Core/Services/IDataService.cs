using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KittenView.Core.Services
{
    public interface IDataService
    {
        void AddKitten(Kitten kitten);
        void ClearAllKitten();
        ObservableCollection<Kitten> GetKittenList();
    }
}
