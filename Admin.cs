using Dapper;
using MySqlConnector;

public class Admin
{
    public int ID { get; set; }
    public string? AdminUserName { get; set; }
    public string? Password { get; set; }
    public Admin()
    {

    }
}