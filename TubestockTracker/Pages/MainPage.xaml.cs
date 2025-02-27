namespace TubestockTracker
{
    public partial class MainPage : ContentPage
    {
        readonly Foundation shell;
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

        private async void OnAddClicked(object sender, EventArgs e)
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "context", PropertyContext.Add },
            };
            await Shell.Current.GoToAsync(nameof(StockPropertyPage), navigationParameter);
            //TODO: goto add page
        }
    }

}
