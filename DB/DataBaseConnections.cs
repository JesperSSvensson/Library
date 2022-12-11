using Dapper;
using MySqlConnector;
public class DBConnections
{
    private string connectionstring = "Server=localhost;Database=libraryDB;Uid=libraryAdmin;pwd=;";
    public MySqlConnection? connection;
    public DBConnections()
    {
        SqlConnect();
    }

    public void SqlConnect()
    {
        connection = new MySqlConnection(connectionstring);
    }   
}