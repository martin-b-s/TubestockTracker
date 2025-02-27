using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubestockTracker
{
    public sealed class StockViewModel(Storage storage) : INotifyPropertyChanged
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

        //public string Name
        //{
        //    get => record.Name;
        //    set 
        //    {
        //        record.Name = value;
        //        PropertyChangedInvoke(nameof(Name)); 
        //    }
        //}
        //public DateTime? Timestamp
        //{
        //    get => record.Timestamp;
        //    set 
        //    {
        //        record.Timestamp = value;
        //        PropertyChangedInvoke(nameof(Timestamp));
        //    }
        //}
        //public bool IsDeceased
        //{
        //    get => record.IsDeceased;
        //    set 
        //    {
        //        record.IsDeceased = value;
        //        PropertyChangedInvoke(nameof(IsDeceased));
        //    }
        //}
        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task Load(int ID)
        {
            Record = await storage.GetStockRecord(ID);
        }
        public async Task Save() => await storage.SaveRecordAsync(Record);
        public void New() => Record = new StockRecord();


        private void PropertyChangedInvoke(string Name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
    }
}
