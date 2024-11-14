// Oppsett av web serveren
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();

// Legg til noen midlertige bøker
Book martian = new Book("Martian", "Andy Weir", new DateTime(2011, 2, 11));
Book nineteeneightyfour = new Book("1984", "George Orwell", new DateTime(1949, 6, 8));
Book tokillamockingbird = new Book("To Kill a Mockingbird", "Harper Lee", new DateTime(1960, 7, 11));
Book prideandpred = new Book("Pride and Prejudice", "Jane Austen", new DateTime(1813, 1, 28));
Book catcher = new Book("The Catcher in the Rye", "J.D. Salinger", new DateTime(1951, 7, 16));
Book gatsby = new Book("The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10));
Book moby = new Book("Moby Dick", "Herman Melville", new DateTime(1851, 10, 18));
Book warandpeace = new Book("War and Peace", "Leo Tolstoy", new DateTime(1869, 1, 1));
Book odyssey = new Book("The Odyssey", "Homer", new DateTime(1, 1, 1)); //date actually -700
Book ulysses = new Book("Ulysses", "James Joyce", new DateTime(1922, 2, 2));
Book divine = new Book("The Divine Comedy", "Dante Alighieri", new DateTime(1320, 1, 1));
Book hobbit = new Book("The Hobbit", "J.R.R. Tolkien", new DateTime(1937, 9, 21));
Book fahrenheit = new Book("Fahrenheit 451", "Ray Bradbury", new DateTime(1953, 10, 19));
Book janeeyre = new Book("Jane Eyre", "Charlotte Brontë", new DateTime(1847, 10, 16));
Book crimeandp = new Book("Crime and Punishment", "Fyodor Dostoevsky", new DateTime(1866, 1, 1));
//legger til bøkene i listen
library.AddNewBook(martian);
library.AddNewBook(nineteeneightyfour);
library.AddNewBook(tokillamockingbird);
library.AddNewBook(prideandpred);
library.AddNewBook(catcher);
library.AddNewBook(gatsby);
library.AddNewBook(moby);
library.AddNewBook(warandpeace);
library.AddNewBook(odyssey);
library.AddNewBook(ulysses);
library.AddNewBook(divine);
library.AddNewBook(hobbit);
library.AddNewBook(fahrenheit);
library.AddNewBook(janeeyre);
library.AddNewBook(crimeandp);


// Konfigurer endepunktene (hvilke meldinger vi responderer på og logikk vi skal kjøre)
// Metode GET
// URI(sti):  /book
app.MapGet("/book", () => //Når serveren får en melding med metoden GET.
{
    return library.ListAvailableBooks();
});

app.MapGet("/unavailbook", () => //Når serveren får en melding med metoden GET.
{
    return library.ListUnAvailableBooks();
});

// Metode:  POST
// URI (sti)
app.MapPost("/book/borrow", (BorrowRequest request) => 
{
   Book? book = library.BorrowBook(request.Title);
   if (book == null)
   {
    return Results.NotFound();
   }
   else
   {
    return Results.Ok(book);
   }
});

app.MapPost("/book/return", (BorrowRequest request) =>
{
   Book? book = library.ReturnBook(request.Title);
   if (book == null)
   {
    return Results.NotFound();
   }
   else
   {
    return Results.Ok(book);
   }
});

// Start web serveren
app.Run();


