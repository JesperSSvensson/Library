using Dapper;
using MySqlConnector;
public class CustomerManager
{
    DBConnections DB = new();
    LibraryManager libraryManager = new();
    public Customer? activeUser { get; set; }
    public Customer? loggedInUser { get; set; }

    public bool LibraryCardInserted(string id)
    {
        try
        {
            Customer customer;
            if (libraryManager.GetCustomerById(Int32.Parse(id), out customer))
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
    public bool PinEntered(string Pin)
    {
        try
        {
            if (libraryManager.CheckPinForCustomer(activeUser.ID, Pin))
            {
                loggedInUser = activeUser;
                return true;
            }

            loggedInUser = null;
            return false;
        }
        catch (System.Exception)
        {
            loggedInUser = null;
            return false;
        }
    }




}