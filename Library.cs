using Dapper;
using MySqlConnector;


public class Library
{
    DBConnections con = new();
    Book showAllBooks;
    Book searchedBook;

    public void GetAllBooks()
    {
        var getBooks = con.connection.Query<Book>($"SELECT * FROM Book");
        foreach (Book book in getBooks)
        {
            showAllBooks = book;
            Console.WriteLine(book.ToString());
        }
        Console.ReadLine();
    }
   
        
     public void SearchBook(string userInput)
    {
        var _books = con.connection.Query<Book>($"SELECT * FROM Book");
        foreach (Book book in _books)
        {
            
            searchedBook = book;
            if(book.Title.Equals(userInput, StringComparison.InvariantCultureIgnoreCase)) // Stackoverflow!
            {
                Console.WriteLine(book.ToString());
                return;
            }
        }   
        
        Console.WriteLine("Cannot find book");
    }
   

}