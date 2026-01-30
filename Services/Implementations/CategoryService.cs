using ANPDB.Models;
using ANPDB.Repositories.Interfaces;
using ANPDB.Services.Interfaces;
using ANPDB.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ANPDB.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public CategoryService(IUnitOfWork unitOfWork, IWebHostEnvironment env) {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task AddCategoryAsync(CategoryCreateVM model) {
            string fileName = null;

            if (model.ImageFile != null)
            {
                fileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                var path = Path.Combine(_env.WebRootPath, "uploads", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);
            }

            var category = new Category
            {
                Title = model.Title,
                ShowUrl = model.Url,
                SubCategory = model.SubCate,
                Description = model.Description,
                Image = fileName
            };

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CategoryViewModel?> GetCateByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                return null;

            var vm = new CategoryViewModel
            {
                Id = category.Id,
                Title = category.Title,
                ShowUrl = category.ShowUrl,
                SubCategory = category.SubCategory,
                Description = category.Description,
                Image = category.Image
            };

            return vm;
        }

        public async Task<CategoryViewModel?> GetCateByNameAsync(string title){
            if (string.IsNullOrWhiteSpace(title))
                return null;

            var category = (await _unitOfWork.Categories.FindAsync(
                x => x.Title != null && x.Title.Equals(title)
            )).FirstOrDefault() ?? null;


            if (category == null)
                return null;

            var vm = new CategoryViewModel
            {
                Id = category.Id,
                Title = category.Title,
                ShowUrl = category.ShowUrl,
                SubCategory = category.SubCategory,
                Description = category.Description,
                Image = category.Image
            };

            return vm;

        }
    }
}