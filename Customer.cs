using Dapper;
using MySqlConnector;

public class Customer
{
    public int ID {get; set;}
    public string? Name {get; set;}
    public DateOnly DateOfBirth {get; set;}
    public string? user_name {get; set;}
    public int Password {get; set;}

    public Customer()
    {

    }
     public override string ToString()
    {
        
        return "\nID: " + ID + " |Name: " + Name + " |UserName: " + user_name;
    }
}
