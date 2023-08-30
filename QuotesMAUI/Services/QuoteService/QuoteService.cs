using QuotesMAUI.ViewModels;
using System.Diagnostics;
using System.Text.Json;

namespace QuotesMAUI.Services.QuoteService
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient Http;
        private readonly string BaseUri;
        private readonly string Uri;
        private readonly JsonSerializerOptions JsonSerializerOpts;

        public QuoteService(HttpClient http)
        {
            Http = http;
            BaseUri = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5093" : "http://localhost:5093";
            Uri = BaseUri + "/api/quote";
            JsonSerializerOpts = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<QuoteViewModel>> GetQuotes()
        {
            List<QuoteViewModel> quotes = new();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet.");
                return quotes;
            };

            try
            {
                HttpResponseMessage response = await Http.GetAsync(Uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    quotes = JsonSerializer.Deserialize<List<QuoteViewModel>>(content, JsonSerializerOpts);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while fetching quotes: " + e.Message);
            }
            return quotes;
        }

        public async Task<QuoteViewModel> GetQuote(int id)
        {
            QuoteViewModel quote = new();
            try
            {
                HttpResponseMessage response = await Http.GetAsync($"{Uri}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    quote = JsonSerializer.Deserialize<QuoteViewModel>(content, JsonSerializerOpts);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while fetching foodstock: " + e.Message);
            }
            return quote;
        }

        public async Task PostQuote(QuoteViewModel quote)
        {
            try
            {
                string jsonQuote = JsonSerializer.Serialize<QuoteViewModel>(quote, JsonSerializerOpts);
                StringContent stringContent = new StringContent(jsonQuote, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await Http.PostAsync(Uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully added food.");
                }
                else
                {
                    Debug.WriteLine("Adding food failed.");
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while posting quote: " + e.Message);
            }
        }

        public async Task UpdateQuote(QuoteViewModel quote)
        {
            try
            {
                string jsonQuote = JsonSerializer.Serialize<QuoteViewModel>(quote, JsonSerializerOpts);
                StringContent stringContent = new StringContent(jsonQuote, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await Http.PutAsync($"{Uri}/{quote.Id}", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully posted.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while posting quote: " + e.Message);
            }
        }

        public async Task DeleteQuote(int id)
        {
            try
            {
                HttpResponseMessage response = await Http.DeleteAsync($"{Uri}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully posted.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while deleting quote: " + e.Message);
            }
        }
        public async Task<List<QuoteViewModel>> FilterQuotes(int catId)
        {
            List<QuoteViewModel> quotes = new();
            try
            {
                HttpResponseMessage response = await Http.GetAsync($"{Uri}/category/{catId}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    quotes = JsonSerializer.Deserialize<List<QuoteViewModel>>(content, JsonSerializerOpts);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured while fetching quotes: " + e.Message);
            }
            return quotes;
        }
    }
}
