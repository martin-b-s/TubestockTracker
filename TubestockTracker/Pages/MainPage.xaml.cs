namespace TubestockTracker
{
    public partial class MainPage : ContentPage
    {
        Foundation shell;
        List<StockRecord> records;


        public MainPage(Foundation shell)
        {
            this.shell = shell;

            InitializeComponent();

            _ = Load();
        }

        private async Task Load()
        {
            records = await shell.LoadRecords();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            //TODO: goto add page
        }
    }

}
