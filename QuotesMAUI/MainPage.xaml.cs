using Microsoft.Maui.Handlers;
using QuotesMAUI.Services.CategoryService;
using QuotesMAUI.Services.QuoteService;

namespace QuotesMAUI;

public partial class MainPage : ContentPage
{
    private readonly IQuoteService QuoteService;
    private readonly ICategoryService CategoryService;
    public MainPage(IQuoteService quoteService, ICategoryService categoryService)
    {
        InitializeComponent();
        ChangeSearchBar();
        QuoteService = quoteService;
        CategoryService = categoryService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        categoryCollectionView.ItemsSource = await CategoryService.GetCategories();
        quotesCarouselView.ItemsSource = await QuoteService.GetQuotes();
    }

    private void ChangeSearchBar()
    {
        SearchBarHandler.Mapper.AppendToMapping("CustomSearchIconColor", (handler, view) =>
        {
#if ANDROID
            var context = handler.PlatformView.Context;
            var searchIconId = context.Resources.GetIdentifier("search_mag_icon", "id", context.PackageName);
            if(searchIconId !=0)
            {
            var searchIcon = handler.PlatformView.FindViewById<Android.Widget.ImageView>(searchIconId);
            searchIcon.SetColorFilter(Android.Graphics.Color.Rgb(172,157,185));
            }
#endif
        });
    }
}

