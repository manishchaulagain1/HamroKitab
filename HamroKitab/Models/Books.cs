using HamroKitab.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamroKitab.Model
{
    public class Books: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }

        /*public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }*/

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher? Publisher { get; set; }

        //relationships
        public List<Author_Books>? Author_Books { get; set; }
        public List<Category_Books>? Category_Books { get; set; }

    }
}
