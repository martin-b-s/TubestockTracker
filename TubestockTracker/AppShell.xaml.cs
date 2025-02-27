namespace TubestockTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StockPropertyPage), typeof(StockPropertyPage));
        }
    }
}
