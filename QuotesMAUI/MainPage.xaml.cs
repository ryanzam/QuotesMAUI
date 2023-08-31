using QuotesMAUI.Auth;
using QuotesMAUI.Services.CategoryService;
using QuotesMAUI.Services.QuoteService;
using QuotesMAUI.ViewModels;

namespace QuotesMAUI;

public partial class MainPage : ContentPage
{
    private readonly IQuoteService QuoteService;
    private readonly ICategoryService CategoryService;

    private readonly AuthClient AuthClient;
    public MainPage(IQuoteService quoteService, ICategoryService categoryService, AuthClient authClient)
    {
        InitializeComponent();
        QuoteService = quoteService;
        CategoryService = categoryService;
        AuthClient = authClient;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        categoryCollectionView.ItemsSource = await CategoryService.GetCategories();
        quotesCarouselView.ItemsSource = await QuoteService.GetQuotes();
    }
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedCategory = e.CurrentSelection.FirstOrDefault() as CategoryViewModel;
        quotesCarouselView.ItemsSource = await QuoteService.FilterQuotes(selectedCategory.Id);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginResult = await AuthClient.LoginAsync();

        if (!loginResult.IsError)
        {
            await DisplayAlert("Logedin", loginResult.AccessToken, "OK");
            LogoutBtn.IsVisible = true;
            PostBtn.IsVisible = true;
            LoginBtn.IsVisible = false;
        }
        else
        {
            await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        var logoutResult = await AuthClient.LogoutAsync();
        if (!logoutResult.IsError)
        {
            LoginBtn.IsVisible = true;
            LogoutBtn.IsVisible = false;
            PostBtn.IsVisible = false;
        }
        else
        {
            await DisplayAlert("Error", logoutResult.ErrorDescription, "OK");
        }
    }

    private void PostBtn_Clicked(object sender, EventArgs e)
    {

    }
}

