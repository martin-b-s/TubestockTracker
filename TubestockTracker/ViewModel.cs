using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubestockTracker
{
    public abstract class BaseViewModel() : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void PropertyChangedInvoke(string Name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
    }
    public sealed class MainViewModel(Storage storage) : BaseViewModel
    {
        public ObservableCollection<StockRecord> Records { get; private set; }
        
        public async Task Load()
        {
            Records= new ObservableCollection<StockRecord>(await storage.GetStockRecordsAsync());
            PropertyChangedInvoke(nameof(Records));
        }
    }
    public sealed class StockViewModel(Storage storage) : BaseViewModel
    {
        private StockRecord _record;

        public StockRecord Record
        {
            get => _record;
            set 
            {
                _record = value;
                PropertyChangedInvoke(nameof(Record));
            }
        }

        public async Task LoadAsync(int ID)
        {
            Record = await storage.GetStockRecord(ID);
        }
        public void Load(StockRecord record) => this.Record = record;
        public async Task SaveAsync() => await storage.SaveRecordAsync(Record);
        public void New() => Record = new StockRecord();
        public async Task DeleteAsync() => await storage.DeleteRecordAsync(Record);
    }
}
