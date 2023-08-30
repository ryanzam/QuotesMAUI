using QuotesMAUI.Services.CategoryService;
using QuotesMAUI.Services.QuoteService;
using QuotesMAUI.ViewModels;
using QuotesMAUI.Views;

namespace QuotesMAUI;

public partial class MainPage : ContentPage
{
    private readonly IQuoteService QuoteService;
    private readonly ICategoryService CategoryService;
    public MainPage(IQuoteService quoteService, ICategoryService categoryService)
    {
        InitializeComponent();
        QuoteService = quoteService;
        CategoryService = categoryService;
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
        await Shell.Current.GoToAsync(nameof(LoginView));
    }
}

