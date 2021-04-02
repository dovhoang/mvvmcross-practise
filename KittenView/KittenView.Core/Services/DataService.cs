using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using SQLite;
namespace KittenView.Core.Services
{
    public class DataService : IDataService
    {
        private SQLiteConnection _db;
        public DataService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            _db = new SQLiteConnection(databasePath);
            _db.CreateTable<Kitten>();
        }

        public void AddKitten(Kitten kitten)
        {
            _db.Insert(kitten);
        }

        public void ClearAllKitten()
        {
            _db.DeleteAll<Kitten>();
            _db.Commit();
        }

        ObservableCollection<Kitten> IDataService.GetKittenList()
        {
            var kittens = _db.Query<Kitten>("SELECT * FROM Kitten");
            return new ObservableCollection<Kitten>(kittens);
        }
    }
}
