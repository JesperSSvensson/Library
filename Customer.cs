using Dapper;
using MySqlConnector;

public class Customer
{
    public int ID {get; set;}
    public string? Name {get; set;}
    public string? user_Name {get; set;}
    public int Password {get; set;}
    LibraryManager libraryManager = new();
    public Customer? activeUser { get; set; }
    public Customer? loggedInUser { get; set; }

    public Customer()
    {

    }
     public override string ToString()
    {
        
        return "\nID: " + ID + " |Name: " + Name + " |UserName: " + user_Name;
    }
    // public bool LibraryCardInserted(string _id)
    // {
    //     try
    //     {
    //         Customer customer;
    //         if (libraryManager.GetCustomerById(Int32.Parse(_id), out customer))
    //         {
    //             activeUser = customer;
    //             return true;
    //         }

    //         activeUser = null;
    //         return false;
    //     }
    //     catch (System.Exception)
    //     {
    //         activeUser = null;
    //         return false;
    //     }
    // }
    // public bool PinEntered(string Pin)
    // {
    //     try
    //     {
    //         if (libraryManager.CheckPinForCustomer(activeUser.ID, Pin))
    //         {
    //             loggedInUser = activeUser;
    //             return true;
    //         }

    //         loggedInUser = null;
    //         return false;
    //     }
    //     catch (System.Exception)
    //     {
    //         loggedInUser = null;
    //         return false;
    //     }
    // }

}
