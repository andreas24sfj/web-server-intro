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

        public List<Book> ListBorrowedBooks()
    {   
        // finn alle utlånte bøker
        List<Book> borrowedBooks = books.FindAll((book) => book.IsBorrowed == true);
        // returner utlånte bøker
        return borrowedBooks;
    }

    public Book? BorrowBook(string title)
    {
        // Finn tilgjengelige bøker:
        List<Book> availbleBooks = ListAvailableBooks();
        // Finn ut om vi har den spesifikke boken tilgjengelig:
        Book? book = availbleBooks.Find((book) => book.Title == title);
        // Låner ut boken
        book.IsBorrowed = true;
        // Returner resultatet
        return book;
    }

    public Book? ReturnBook(string title)
    {
        // Finn utlånte bøker
        List<Book> borrowedBooks = ListBorrowedBooks();
        // Let igjennom de utlånte bøkene for å finne den utlånte tittelen
        Book? book = borrowedBooks.Find((book) => book.Title == title);
        // Boken blir lagt tilbake i biblioteket
        book.IsBorrowed = false;
        // Returnerer resultatet
        return book;
    }
}