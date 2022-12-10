using Dapper;
using MySqlConnector;


public class Library
{
    DBConnections DB = new();
    LoginConnect CC = new();
    Customer activeUser;

    public bool LibraryCardInserted(string _id)
    {
        try
        {
            Customer customer;
            if (CC.GetCustomerById(Int32.Parse(_id), out customer))
            {
                activeUser = customer;
                return true;
            }

            activeUser = null;
            return false;
        }
        catch (System.Exception)
        {
            activeUser = null;
            return false;
        }
    }

  public void GetAllBooks()
    {
        var transactions = DB.connection.Query<Book>($"SELECT * FROM Book");
        foreach (Book item in transactions)
        {
            Console.WriteLine("\nBook ID: " + item.ID + "| Title: " + item.Title + "| Price: " + item.Price + "| Published: " + item.published + "| Stock: " + item.stock);
        }
    
    } 
}