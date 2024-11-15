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
        List<Book> availableBooks = books.FindAll((book) => book.BorrowId == null && !book.IsBorrowed);
        // returner tilgjengelige bøker
        return availableBooks;
    }

    public List<Book> ListAllBooks()
    {
        return books;
    }

        public List<Book> ListBorrowedBooks()
    {   
        // finn alle utlånte bøker
        List<Book> borrowedBooks = books.FindAll((book) => book.BorrowId != null && book.IsBorrowed);
        // returner utlånte bøker
        return borrowedBooks;
    }

    public Book? BorrowBook(string title, Guid ID)
    {
        // Finn tilgjengelige bøker:
        List<Book> availbleBooks = ListAvailableBooks();
        // Finn ut om vi har den spesifikke boken tilgjengelig:

        Book? book = availbleBooks.Find((book) => book.Title == title || book.BookId == ID);
        // Låner ut boken
        book.BorrowId = Guid.NewGuid();
        book.IsBorrowed = true;
        // Returner resultatet
        return book;
    }

    public Book? ReturnBook(string title, Guid ID)
    {
        // Finn utlånte bøker
        List<Book> borrowedBooks = ListBorrowedBooks();
        // Let igjennom de utlånte bøkene for å finne den utlånte tittelen
        Book? book = borrowedBooks.Find((book) => book.Title == title || book.BookId == ID);
        // Boken blir lagt tilbake i biblioteket
        book.BorrowId = null;
        book.IsBorrowed = false;
        // Returnerer resultatet
        return book;
    }
}