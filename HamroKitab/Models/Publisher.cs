using HamroKitab.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HamroKitab.Model
{
    public class Publisher:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Publisher Logo")]
        [Required(ErrorMessage = "Publisher logo is required")]
        public string? Logo {get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage ="Publisher name is required")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage ="Publisher description is required")]
        public string? Description { get; set; }

        //Relationships
        public List<Books>? Books { get; set; }
    }
}
