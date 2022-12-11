using Dapper;
using MySqlConnector;

public class Author
{
    public int ID {get; set;}
    public string? first_name {get; set;}
    public string last_name {get; set;}
    public DateTime Date {get; set;}

public Author()
{

}

}