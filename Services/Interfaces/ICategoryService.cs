using ANPDB.ViewModel;
namespace ANPDB.Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryCreateVM model);

        Task<CategoryViewModel?> GetCateByIdAsync(int id);
        Task<CategoryViewModel?> GetCateByNameAsync(string title);

    }
}
