using Dapper;
using MySqlConnector;

public class LibraryManager
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

         public bool CheckPinForCustomer(int customerId, string password)
        {
            try
            {
                Customer customer = db.connection.QuerySingle<Customer>("SELECT * FROM customer WHERE ID=" + customerId + " AND password=" + password);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("DataBaseAccess: No customer found on that ID and Pin" + " : " + ex.Message);
                return false;
            }
        }

        public void loading()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Loading" + i);   
            }
        }

    





    

}