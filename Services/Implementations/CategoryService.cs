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
            //var getall = await _unitOfWork.Categories.GetAllAsync();

            title = !string.IsNullOrWhiteSpace(title) ? title.Trim().ToLower() : "";

            //Here my findasync didn't worked. so i used getall
            var getall = await _unitOfWork.Categories.GetAllAsync();
            var catefound = getall.Where(s => s.Title == title).FirstOrDefault();

            if (catefound == null) return null;

            var category = catefound;

            //var categoryies = await _unitOfWork.Categories.FindAsync(x => x.Title == title);
            //var category = categoryies.FirstOrDefault();


            //if (category == null)
            //    return null;

            var vm = new CategoryViewModel
            {
                Id = category.Id,
                Title = category.Title
            };

            return vm;

        }


        public async Task<List<CategoryViewModel>> GetAllCate()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Title = c.Title,
                ShowUrl = c.ShowUrl,
                SubCategory = c.SubCategory,
                Description = c.Description,
                Image = c.Image
            }).ToList();
        }
    }
}