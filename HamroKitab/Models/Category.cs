using HamroKitab.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace HamroKitab.Model
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "CategoryName Is Required")]
        public string? Name { get; set; }

        //relationships
        public List<Category_Books>? Category_Books { get; set; }
    }
}
