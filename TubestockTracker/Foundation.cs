using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubestockTracker
{
    public class Foundation
    {
        private readonly HashSet<string> nameSet;

        public Foundation()
        {
            this.Storage = new Storage();
            this.nameSet = [];

            _ = LoadPlantNameDictionary();
        }

        public async Task<List<StockRecord>> LoadRecords()
        {
            return await Storage.GetStockRecordsAsync();
        }
        public async Task LoadPlantNameDictionary()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("wacensus2022.dic");
            using var reader = new StreamReader(stream);

            do
            {
                var name = reader.ReadLine();
                if (!string.IsNullOrEmpty(name))
                    nameSet.Add(name);

            } while (!reader.EndOfStream);

            Debug.WriteLine("dic load complete");
        }

        public Storage Storage { get; private set; }
        public IReadOnlyCollection<string> names => nameSet;


        
    }

}
