using Microsoft.Net.Http.Headers;

class Library
{
    List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddNewBook(Book newBook)
    {
        books.Add(newBook);
    }

    public List<Book> ListAvailableBooks()
    {
        // filtrer ut alle utlånte bøker
        List<Book> availableBooks = books.FindAll((book) => !book.IsBorrowed);
        // returner tilgjengelige bøker
        return availableBooks;
    }

        public List<Book> ListUnAvailableBooks()
    {
        List<Book> unAvailableBooks = books.FindAll((book) => book.IsBorrowed == true);
        // returner utilgjengelige bøker
        return unAvailableBooks;
    }

    public Book? BorrowBook(string title)
    {
        // Finn tilgjengelige bøker:
        List<Book> availbleBooks = ListAvailableBooks();
        // Finn ut om vi har den spesifikke boken tilgjengelig:
        Book? book = availbleBooks.Find((book) => book.Title == title);
        book.IsBorrowed = true;
        // Returner resultatet
        return book;
    }

    public Book? ReturnBook(string title)
    {
        List<Book> borrowedBooks = ListUnAvailableBooks();

        Book? book = borrowedBooks.Find((book) => book.Title == title);
        book.IsBorrowed = false;

        return book;
    }

}