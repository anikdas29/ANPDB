using ANPDB.Models;
using ANPDB.Repositories.Implementations;
using ANPDB.Repositories.Interfaces;
using ANPDB.Services.Implementations;
using ANPDB.Services.Interfaces;
using ANPDB.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ANPDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;

        public CategoryController(ICategoryService categoryService) {
            _categoryservice = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var catedata = await _categoryservice.GetAllCate();
            return Ok(new { data = catedata });
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(string title, string url, int subcate, string description, IFormFile ImageFile)
        {
            var hasCategory = await _categoryservice.GetCateByNameAsync(title);
            if (hasCategory == null) {
                var model = new CategoryCreateVM
                {
                    Title = title,
                    Url = url,
                    SubCate = subcate,
                    Description = description,
                    ImageFile = ImageFile
                };

                await _categoryservice.AddCategoryAsync(model);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //var category = await _unitofwork.Categories.GetByIdAsync(id);
            //if (category == null) return NotFound();

            //_unitofwork.Categories.Remove(category);
            //await _unitofwork.SaveAsync();

            return Ok();
        
        }
    }
}
