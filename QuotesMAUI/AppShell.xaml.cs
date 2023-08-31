using QuotesMAUI.Views;

namespace QuotesMAUI;

public partial class AppShell : Shell
{
    bool LoggedIn { get; set; } = false;
    public AppShell()
    {
        InitializeComponent();
        BindingContext = this;
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
    }

    async Task<bool> CheckIfLogedIn()
    {
        var token = await SecureStorage.GetAsync("token");
        return token != null;
    }

}
