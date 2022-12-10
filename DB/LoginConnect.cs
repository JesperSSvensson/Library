using Dapper;
using MySqlConnector;

public class LoginConnect
{
    DBConnections db = new();
   

    public bool GetCustomerById(int customerId ,out Customer customer)
        {
            try
            {
                customer = db.connection.QuerySingle<Customer>("SELECT ID, Name FROM customer WHERE ID=" + customerId);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("DataBaseAccess: Cannot get customer from id " + customerId + " : " + ex.Message);
                customer = null;
                return false;
            }
        }

    

}