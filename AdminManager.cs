using Dapper;
using MySqlConnector;
public class AdminManager
{
    DBConnections DB = new();
    LibraryManager libraryManager = new();
    public Admin? activeAdmin {get; set;}
    public Admin? loggedInAdmin { get; set; }


    
    public bool LibraryAdminCardInserted(string _id)
    {
        try
        {
            Admin admin;
            if (libraryManager.GetAdminById(Int32.Parse(_id), out admin))
            {
                activeAdmin = admin;
                return true;
            }

            activeAdmin = null;
            return false;
        }
        catch (System.Exception)
        {
            activeAdmin = null;
            return false;
        }
    }
    public bool PinEntered(string Pin)
        {
            try
            {
                if(libraryManager.CheckPinForAdmin(activeAdmin.ID, Pin))
                {
                    loggedInAdmin = activeAdmin;
                    return true;
                }

                loggedInAdmin = null;
                return false;
            }
            catch (System.Exception)
            {
                loggedInAdmin = null;
                return false;
            }
        }
    
    


}