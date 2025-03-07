namespace TubestockTracker
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        Foundation foundation;

        public MainPage(Foundation foundation)
        {
            InitializeComponent();
            this.foundation = foundation;
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

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
        private async void OnEditClicked(object sender, EventArgs e)
        {
            var record = (sender as Button)?.BindingContext as StockRecord;
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "context", PropertyContext.Edit },
            };

            if (record != null)
                navigationParameter.Add("stockId", record.ID);

            await Shell.Current.GoToAsync(nameof(StockPropertyPage), navigationParameter);
        }
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var record = (sender as Button)?.BindingContext as StockRecord;

            var answer = await DisplayAlert("Delete", $"Are you sure you want to delete {record?.Name}", "Delete", "Cancel");
            if (answer && record!= null)
            {
                var recordViewModel = new StockViewModel(foundation);
                recordViewModel.Load(record);

                await recordViewModel.DeleteAsync();
                await viewModel.Load();
            }
           
        }
    }

}
