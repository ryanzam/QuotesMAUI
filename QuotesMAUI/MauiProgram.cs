﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using QuotesMAUI.Auth;
using QuotesMAUI.Services.CategoryService;
using QuotesMAUI.Services.QuoteService;

namespace QuotesMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("MontserratAlternates-Bold.ttf", "Bold");
                fonts.AddFont("MontserratAlternates-Regular.ttf", "Regular");
                fonts.AddFont("MontserratAlternates-SemiBold.ttf", "SemiBold");
                fonts.AddFont("MontserratAlternates-Light.ttf", "Light");
                fonts.AddFont("MontserratAlternates-Thin.ttf", "Thin");
                fonts.AddFont(filename: "materialdesignicons-webfont.ttf", alias: "MaterialDesignIcons");
            });

        builder.Services.AddHttpClient<IQuoteService, QuoteService>();
        builder.Services.AddHttpClient<ICategoryService, CategoryService>();
        builder.Services.AddSingleton<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(new AuthClient(new()
        {
            Domain = "mydomain",
            ClientId = "myclientId",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));

        return builder.Build();
    }
}
