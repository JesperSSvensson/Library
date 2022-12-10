using Dapper;
using MySqlConnector;
public class CustomerManager
{

    Customer? newCustomer; 
    DBConnections DB = new();


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
    


}