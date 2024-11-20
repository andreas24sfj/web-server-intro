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
        Book? book = availableBooks.Find((book) => book.BookId == ID) ?? availableBooks.Find((book) => book.Title == title);
        // Låner ut boken
        if (book != null)
        {
        book.BorrowId = Guid.NewGuid();
        book.IsBorrowed = true;
        }
        // Returner resultatet
        return book;
    }

    public List<Book> BorrowBooks(List<string> titles, List<Guid> IDs)
    {
    List<Book> availableBooks = ListAvailableBooks();
    List<Book> booklist = new List<Book>();

        foreach(var ID in IDs)
        {
            Book? book = availableBooks.Find((book) => book.BookId == ID && !booklist.Contains(book));
            if (book != null)
            {
            book.BorrowId = Guid.NewGuid();
            book.IsBorrowed = true;
            booklist.Add(book);
            }
        }

        foreach(var title in titles)
        {
            Book? book = availableBooks.Find((book) => book.Title == title && !booklist.Contains(book));
            if (book != null)
            {
            book.BorrowId = Guid.NewGuid();
            book.IsBorrowed = true;
            booklist.Add(book);
            }
        }

        return booklist;
    }

    public Book? ReturnBook(string title, Guid ID)
    {
        // Finn utlånte bøker
        List<Book> borrowedBooks = ListBorrowedBooks();
        // Let igjennom de utlånte bøkene for å finne den utlånte tittelen
        Book? book = borrowedBooks.Find((book) => book.BookId == ID) ?? borrowedBooks.Find((book) => book.Title == title);
        // Boken blir lagt tilbake i biblioteket
        if (book != null)
        {
        book.BorrowId = null;
        book.IsBorrowed = false;
        }
        // Returnerer resultatet
        return book;
    }

        public List<Book> ReturnBooks(List<string> titles, List<Guid> IDs)
    {
    List<Book> borrowedBooks = ListBorrowedBooks();
    List<Book> booklist = new List<Book>();

        foreach(var ID in IDs)
        {
            Book? book = borrowedBooks.Find((book) => book.BookId == ID && !booklist.Contains(book));
            if (book != null)
            {   
            book.BorrowId = null;
            book.IsBorrowed = false;
            booklist.Add(book);}
        
        }

        foreach(var title in titles)
        {
            Book? book = borrowedBooks.Find((book) => book.Title == title && !booklist.Contains(book));
            if (book != null)
            {
            book.BorrowId = null;
            book.IsBorrowed = false;
            booklist.Add(book);
            }
        }

        return booklist;
    }
}