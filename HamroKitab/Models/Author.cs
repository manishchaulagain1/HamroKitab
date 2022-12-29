using HamroKitab.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HamroKitab.Model
{
    public class Author:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage= "ProfilePictureUrl Is Required")]
        public string? ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName Is Required")]
        [StringLength(50, MinimumLength =3,ErrorMessage ="FullName must be between 3 and 50 chars")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography Is Required")]
        public string? Bio { get; set; }
        /*public List<Books> Books { get; set; }*/

        //relationships
        public List<Author_Books>? Author_Books { get; set; }
    }
}
