using Dapper;
using MySqlConnector;

public class Admin
{
    public int ID {get; set;}
    public string admin_user_name {get; set;} 
    public string password {get; set;}



    public Admin()
    {
        
    }
}