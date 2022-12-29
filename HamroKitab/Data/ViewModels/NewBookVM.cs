using HamroKitab.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamroKitab.Data.ViewModels
{
    public class NewBookVM
    {
        public int Id { get; set; }

        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "price is required")]
        public double Price { get; set; }

        [Display(Name = "Book poster URL")]
        [Required(ErrorMessage = "BookPosterUrl is required")]
        public string? ImageUrl { get; set; }

        [Display(Name = " Book Publish date")]
        [Required(ErrorMessage = "Publish date is required")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Select a publisher")]
        [Required(ErrorMessage = "Book publisher is required")]
        public int PublisherId { get; set; }

        //Relationships
        [Display(Name = "Select author(s)")]
        [Required(ErrorMessage = "Book author(s) is required")]
        public List<int>? AuthorIds { get; set; }

        [Display(Name = "Select categorie(s)")]
        [Required(ErrorMessage = "Book categorie(s) is required")]
        public List<int>? CategoryIds { get; set; }

    }
}
