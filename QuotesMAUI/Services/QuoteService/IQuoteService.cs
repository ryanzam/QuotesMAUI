using QuotesMAUI.ViewModels;

namespace QuotesMAUI.Services.QuoteService
{
    public interface IQuoteService
    {
        Task DeleteQuote(int id);
        Task<QuoteViewModel> GetQuote(int id);
        Task<List<QuoteViewModel>> GetQuotes();
        Task PostQuote(QuoteViewModel quote);
        Task UpdateQuote(QuoteViewModel quote);
        Task<List<QuoteViewModel>> FilterQuotes(int catId);
    }
}