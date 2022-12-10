using Dapper;
using MySqlConnector;


public class Library
{
    DBConnections DB = new();
    CustomerConnect CC = new();
    Customer activeUser;

    public bool LibraryCardInserted(string _id)
        {
            try
            {
                Customer customer;
                if(CC.GetCustomerById(Int32.Parse(_id), out customer))
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

}