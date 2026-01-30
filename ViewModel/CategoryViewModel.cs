using System.ComponentModel.DataAnnotations;

namespace ANPDB.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShowUrl { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public int SubCategory { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaKeywords { get; set; }

        public bool Status { get; set; }
    }


    public class CategoryCreateVM
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int SubCate { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
    }

}
