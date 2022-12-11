using Dapper;
using MySqlConnector;


public class Library
{
    DBConnections DB = new();
   
    
  public void GetAllBooks()
    {
        Book showAllBooks;
        var getBooks = DB.connection.Query<Book>($"SELECT * FROM Book");
        foreach (Book book in getBooks)
        {
            showAllBooks = book;
            Console.WriteLine(book.ToString());
        }
        
    
    } 
}