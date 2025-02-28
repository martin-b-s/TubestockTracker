namespace TubestockTracker
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;

        public MainPage(Foundation foundation)
        {
            InitializeComponent();

            this.viewModel = new MainViewModel(foundation.Storage);
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _ = viewModel.Load();
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

        private void listRecords_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }

}
