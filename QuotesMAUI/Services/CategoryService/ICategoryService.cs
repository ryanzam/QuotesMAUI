using QuotesMAUI.ViewModels;

namespace QuotesMAUI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories();
    }
}