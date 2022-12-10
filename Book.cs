using Dapper;
using MySqlConnector;

public class Book
{
    public int ID {get; set;}
    public string Title {get; set;}
    public string published  {get; set;}
    public int stock {get; set;}
    public int Price {get; set;}
    public string category {get; set;}
    public Author first_name {get; set;}
    

    public Book()
    {
        
    }

}