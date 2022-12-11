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
                Console.WriteLine("LibraryManager: Cannot get customer from id " + customerId + " : " + ex.Message);
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
                Console.WriteLine("LibraryManager: No customer found on that ID and Pin" + " : " + ex.Message);
                return false;
            }
        }

        public bool GetAllBooks(out IEnumerable<Book> books)
        {
            try
            {
                books = db.connection.Query<Book>("SELECT * FROM book");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get any books : " + ex.Message);
                books = null;
                return false;
            }
        }
        public bool GetAllBooksTitleWithAuthors(out IEnumerable<dynamic> books)
        {
            try
            {
                books = db.connection.Query("SELECT b.title, a.first_name, a.last_name FROM book b INNER JOIN author a ON b.author_id=a.ID");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManger: Cannot get any books : " + ex.Message);
                books = null;
                return false; 
            }
        }

        public bool GetBorrowedBooksForCustomer(int _customer_id, out IEnumerable<BorrowedBooks> borrowed_books)
        {
            try
            {
                borrowed_books = db.connection.Query<BorrowedBooks>("SELECT * FROM borrowed_books b WHERE b.customer_id='" + _customer_id + "'");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("DataBaseAccess: Cannot get borrowed books for customer_id: " + _customer_id + " : " + ex.Message);
                borrowed_books = null;
                return false;
            }
        }


      


    





    

}