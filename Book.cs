using Microsoft.Net.Http.Headers;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime FirstPublished { get; set; }
    public bool IsBorrowed { get; set; }
    public Guid? BorrowId { get; set; }

    public Guid BookId { get; set; }

    public Book(string title, string author, DateTime firstPublished)
    {
        Title = title;
        Author = author;
        FirstPublished = firstPublished;
        IsBorrowed = false;
        BorrowId = null;
        BookId = Guid.NewGuid();
    }
}