using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualBasic;

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
        List<Book> availableBooks = ListAvailableBooks();
        // Finn ut om vi har den spesifikke boken tilgjengelig:
        Book? book = availableBooks.Find((book) => book.Title == title) ?? availableBooks.Find((book) => book.BookId == ID);
        // Låner ut boken
        book.BorrowId = Guid.NewGuid();
        book.IsBorrowed = true;
        // Returner resultatet
        return book;
    }

    public List<Book> BorrowBooks(List<string> titles, List<Guid> IDs)
    {
    List<Book> availableBooks = ListAvailableBooks();
    List<Book> booklist = new List<Book>();

        foreach(var ID in IDs)
        {
            Book? books = availableBooks.Find((book) => book.BookId == ID);
            books.BorrowId = Guid.NewGuid();
            books.IsBorrowed = true;
            booklist.Add(books);
        }

        foreach(var title in titles){
            Book? books = availableBooks.Find((book) => book.Title == title && !booklist.Contains(book));
            books.BorrowId = Guid.NewGuid();
            books.IsBorrowed = true;
            booklist.Add(books);
        }

        return booklist;
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

        public List<Book> ReturnBooks(List<string> titles, List<Guid> IDs)
    {
    List<Book> availableBooks = ListAvailableBooks();
    List<Book> booklist = new List<Book>();

        foreach(var ID in IDs)
        {
            Book? books = availableBooks.Find((book) => book.BookId == ID);
            books.BorrowId = null;
            books.IsBorrowed = false;
            booklist.Add(books);
        }

        foreach(var title in titles){
            Book? books = availableBooks.Find((book) => book.Title == title && !booklist.Contains(book));
            books.BorrowId = null;
            books.IsBorrowed = false;
            booklist.Add(books);
        }

        return booklist;
    }
}