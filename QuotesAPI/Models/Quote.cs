namespace QuotesAPI.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string QuoteText { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
