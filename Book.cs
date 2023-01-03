using Dapper;
using MySqlConnector;

public class Book
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Published { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public string? Category { get; set; }
    public Book()
    {

    }
    public override string ToString()
    {

        return "\nID: " + ID + " |Name: " + Title + " |Published: " + Published + " |Prize: " + Price + ", |Stock: " + Stock + " |Category: " + Category;
    }
}