namespace TubestockTracker
{
    public partial class MainPage : ContentPage
    {
        Storage Storage;
        List<StockRecord> RecordList;

        public MainPage(Storage storage)
        {
            this.Storage = storage;
            this.RecordList = new List<StockRecord>();

            InitializeComponent();


            LoadRecords();
        }
        public async void LoadRecords()
        {
            RecordList = await Storage.GetStockRecordsAsync();
            
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            //TODO: goto add page
        }
    }

}
