namespace HamroKitab.Model
{
    public class Author_Books
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public Books? Books { get; set; }   

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
