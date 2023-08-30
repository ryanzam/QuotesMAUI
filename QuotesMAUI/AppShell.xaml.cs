using QuotesMAUI.Views;

namespace QuotesMAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
    }
}
