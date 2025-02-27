using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubestockTracker
{
    public sealed class StockRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? Timestamp { get; set; }
        public bool IsDeceased { get; set; }
    }

    public sealed class LabelImage
    {
        public int ID { get; set; }
        public int StockRecordId { get; set; }
        public int Index { get;  set; }
        public byte[] Buffer { get;  set; }
    }
}
