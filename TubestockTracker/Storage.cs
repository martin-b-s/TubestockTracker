using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubestockTracker
{
    public sealed class Storage
    {
        SQLiteAsyncConnection Connection;

        async Task Init()
        {
            if (Connection is not null)
                return;

            Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Connection.CreateTableAsync<StockRecord>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK);
            await Connection.CreateTableAsync<LabelImage>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK);
            await Connection.CreateIndexAsync(nameof(LabelImage), [nameof(LabelImage.StockRecordId), nameof(LabelImage.Index)], true);
        }

        public async Task<List<StockRecord>> GetStockRecordsAsync()
        {
            await Init();
            return await Connection.Table<StockRecord>().ToListAsync();
        }

        public async Task<int> SaveRecordAsync(StockRecord record)
        {
            await Init();
            if (record.ID != 0)
                return await Connection.UpdateAsync(record);
            else
                return await Connection.InsertAsync(record);
        }

        public async Task<int> DeleteRecordAsync(StockRecord record)
        {
            await Init();
            return await Connection.DeleteAsync(record);
        }
        public async Task<StockRecord> GetStockRecord(int stockRecordID)
        {
            await Init();
            return await Connection.Table<StockRecord>().Where(R => R.ID == stockRecordID).FirstAsync();
        }

        public async Task<List<LabelImage>> GetLabelImagesAsync(int stockRecordId)
        {
            await Init();
            return await Connection.Table<LabelImage>().Where(I => I.StockRecordId == stockRecordId).ToListAsync();
        }

    }
}
