using Dapper;
using MySqlConnector;
public class CustomerManager
{

    Customer? newCustomer; 
    DBConnections DB = new();
    LibraryManager lm = new();
    public Customer? activeUser {get; set;}
    public Customer? loggedInUser { get; set; }


    public Customer checkUserName(Customer info)
    {
        var customerLogin = DB.connection.Query<Customer>($"SELECT customer.ID, customer.password FROM customer WHERE customer.user_name = {info}");
        while (true)
        {
            foreach (Customer cus in customerLogin)
            {
                if (true)
                {
                    newCustomer = cus;
                }
                return newCustomer;
               
            }
        }
    }
    public bool LibraryCardInserted(string _id)
    {
        try
        {
            Customer customer;
            if (lm.GetCustomerById(Int32.Parse(_id), out customer))
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
                if(lm.CheckPinForCustomer(activeUser.ID, Pin))
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