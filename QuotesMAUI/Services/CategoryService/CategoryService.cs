using QuotesMAUI.ViewModels;
using System.Diagnostics;
using System.Text.Json;

namespace QuotesMAUI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient Http;
        private readonly string BaseUri;
        private readonly string Uri;
        private readonly JsonSerializerOptions JsonSerializerOpts;
        public CategoryService(HttpClient http)
        {
            Http = http;
            BaseUri = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5093" : "http://localhost:5093";
            Uri = BaseUri + "/api/category";
            JsonSerializerOpts = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<CategoryViewModel>> GetCategories()
        {
            List<CategoryViewModel> categories = new();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet.");
                return categories;
            };

            try
            {
                HttpResponseMessage response = await Http.GetAsync(Uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(content, JsonSerializerOpts);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while fetching quotes: " + e.Message);
            }
            return categories;
        }
    }
}
