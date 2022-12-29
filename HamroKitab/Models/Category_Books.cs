namespace HamroKitab.Model
{
    public class Category_Books
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public Books? Books { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
