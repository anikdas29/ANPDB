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
            //var catrgories = await _unitofwork.Categories.GetAllAsync();
            var vm = new CategoryViewModel();
            //{
            //    Id = 1,
            //};

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var data = await _unitofwork.Categories.GetAllAsync();
            //return Json(new { data });
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(string title, string url, int subcate, string description, IFormFile ImageFile)
        {
            var dat = _categoryservice.GetCateByNameAsync(title);
            var model = new CategoryCreateVM
            {
                Title = title,
                Url = url,
                SubCate = subcate,
                Description = description,
                ImageFile = ImageFile
            };

            await  _categoryservice.AddCategoryAsync(model);
            //if (ImageFile != null)
            //{
            //    var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
            //    var path = Path.Combine("wwwroot/uploads", fileName);

            //    using var stream = new FileStream(path, FileMode.Create);
            //    await ImageFile.CopyToAsync(stream);

            //    category.Image = fileName;
            //}
            //var category = new CategoryViewModel 

            //await _unitofwork.Categories.AddAsync(category);
            //await _unitofwork.SaveAsync();

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
