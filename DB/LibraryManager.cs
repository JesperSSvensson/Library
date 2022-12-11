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
        public bool GetAdminById(int adminId ,out Admin admin)
        {
            try
            {
                admin = db.connection.QuerySingle<Admin>("SELECT ID, admin_user_name FROM admin WHERE ID=" + adminId);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get customer from id " + adminId + " : " + ex.Message);
                admin = null;
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
         public bool CheckPinForAdmin(int adminId, string password)
        {
            try
            {
                Admin admin = db.connection.QuerySingle<Admin>("SELECT * FROM Admin WHERE ID=" + adminId + " AND password=" + password);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: No Admin found on that ID and Pin" + " : " + ex.Message);
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
                borrowed_books = db.connection.Query<BorrowedBooks>("SELECT * FROM borrowed_book b WHERE b.customer_id='" + _customer_id + "'");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get borrowed books for customer_id: " + _customer_id + " : " + ex.Message);
                borrowed_books = null;
                return false;
            }
        }
         public bool GetBookIdFromLoanId(int _loan_id, out int book_id)
        {
            try
            {
                book_id = db.connection.QueryFirst<int>("SELECT book_id FROM borrowed_book WHERE ID=" + _loan_id);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get book_id from loan_id " + _loan_id + " : " + ex.Message);
                book_id = 0;
                return false;
            }
        }
        public bool DeleteBorrowedBook(int _loan_id)
        {
            try
            {
                var res = db.connection.Query("DELETE FROM borrowed_book WHERE ID=" + _loan_id);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot delete borrowed book from load_id " + _loan_id + " : " + ex.Message);
                return false;
            }
        }
        public bool GetBookStock(int _book_id, out int stock)
        {
            try
            {
                stock = db.connection.QuerySingle<int>("SELECT stock FROM book WHERE ID=" + _book_id);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get stock for book with ID: " + _book_id + " : " + ex.Message);
                stock = 0;
                return false;
            }
        }
        public bool SetBookStock(int _stock, int _book_id)
        {
            try
            {
                var res = db.connection.Query("UPDATE book SET stock=" + _stock + " WHERE ID=" + _book_id);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot set stock for book with ID: " + _book_id + " : " + ex.Message);
                return false;
            }
        }
        public bool RegisterBorrowedBook(int _book_id, int _customer_id)
        {
            try
            {
                var res = db.connection.Query("INSERT INTO borrowed_book (book_id, customer_id, date_of_loan) VALUES (" + _book_id + ", " + _customer_id + ", '" + DateTime.Now + "')");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot register borrowed book with with Book_ID " + _book_id + " and Customer_ID " + _customer_id + " : " + ex.Message);
                return false;
            }
        }
        public bool GetAllCustomers(out IEnumerable<Customer> customer)
        {
            try
            {
                customer = db.connection.Query<Customer>("SELECT * FROM customer");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get any customer : " + ex.Message);
                customer = null;
                return false;
            }
        }
        public bool GetAllBorrowedBooks(out IEnumerable<BorrowedBooks> borrowedBooks)
        {
            try
            {
                borrowedBooks = db.connection.Query<BorrowedBooks>("SELECT * FROM Borrowed_book");
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("LibraryManager: Cannot get any customer : " + ex.Message);
                borrowedBooks = null;
                return false;
            }
        }
}