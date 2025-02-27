namespace TubestockTracker;

public enum PropertyContext { Add, Edit }


public partial class StockPropertyPage : ContentPage, IQueryAttributable
{
	PropertyContext context;
    readonly StockViewModel viewModel;
	int? stockId;

	public StockPropertyPage(Foundation shell)
	{
        InitializeComponent();

        this.viewModel = new StockViewModel(shell.Storage);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		context = (PropertyContext)query["context"];
		stockId = (int)query["stockId"];

        this.titleLabel.Text = $"{context} tube stock record";
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = viewModel;

        switch (context)
        {
            case PropertyContext.Add:
                viewModel.New();
                break;

            case PropertyContext.Edit:
                if(stockId.HasValue)
                    _ = viewModel.Load(stockId.Value);
                break;

            default:
                throw new NotImplementedException();
        }
    }
    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.Save();
        await Shell.Current.GoToAsync(".."); //navigate back
    }
}