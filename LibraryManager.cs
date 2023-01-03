using Dapper;
using MySqlConnector;

public class LibraryManager
{
    DBConnections db = new();
    public bool GetCustomerById(int customerId, out Customer customer)
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
    public bool GetAdminById(int adminId, out Admin admin)
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
            books = db.connection.Query("SELECT a.first_name, a.last_name, b.title FROM Author a INNER JOIN book_to_author ba ON a.id = ba.author_id INNER JOIN Book b ON b.id = ba.book_id;");
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManger: Cannot get any books : " + ex.Message);
            books = null;
            return false;
        }
    }

    public bool GetBorrowedBooksForCustomer(int customerId, out IEnumerable<BorrowedBooks> borrowedBooks)
    {
        try
        {
            borrowedBooks = db.connection.Query<BorrowedBooks>("SELECT * FROM borrowed_book b WHERE b.customer_id='" + customerId + "'");
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot get borrowed books for customer_id: " + customerId + " : " + ex.Message);
            borrowedBooks = null;
            return false;
        }
    }
    public bool GetBookIdFromLoanId(int loanId, out int bookId)
    {
        try
        {
            bookId = db.connection.QueryFirst<int>("SELECT book_id FROM borrowed_book WHERE ID=" + loanId);
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot get book_id from loan id " + loanId + " : " + ex.Message);
            bookId = 0;
            return false;
        }
    }
    public bool DeleteBorrowedBook(int loanId)
    {
        try
        {
            var res = db.connection.Query("DELETE FROM borrowed_book WHERE ID=" + loanId);
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot delete borrowed book from loan id " + loanId + " : " + ex.Message);
            return false;
        }
    }
    public bool GetBookStock(int bookId, out int stock)
    {
        try
        {
            stock = db.connection.QuerySingle<int>("SELECT stock FROM book WHERE ID=" + bookId);
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot get stock for book with ID: " + bookId + " : " + ex.Message);
            stock = 0;
            return false;
        }
    }
    public bool SetBookStock(int stock, int bookId)
    {
        try
        {
            var res = db.connection.Query("UPDATE book SET stock=" + stock + " WHERE ID=" + bookId);
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot set stock for book with ID: " + bookId + " : " + ex.Message);
            return false;
        }
    }
    public bool RegisterBorrowedBook(int bookId, int customerId)
    {
        try
        {
            var res = db.connection.Query("INSERT INTO borrowed_book (book_id, customer_id, date_of_loan) VALUES (" + bookId + ", " + customerId + ", '" + DateTime.Now + "')");
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot register borrowed book with with Book_ID " + bookId + " and Customer_ID " + customerId + " : " + ex.Message);
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
    public bool GetBookByTitle(string title, out IEnumerable<Book> books)
    {  
            try
            {
                books = db.connection.Query<Book>("SELECT * FROM book b WHERE b.title='" + title + "'");
                return true;
            }
            catch (System.Exception ex)
            {
                Font.PrintErrorHeader("LibraryManager: Cannot get any books with title: " + title + " : " + ex.Message);
                books = null;
                return false;
            }
    }
    public bool ShowBookStock(out int books)
    {
        try
        {
            books = db.connection.QuerySingle<int>("SELECT SUM(stock) FROM book WHERE stock >0");
            return true;
        }
        catch (System.Exception ex)
        {
            Font.PrintErrorHeader("LibraryManager: Cannot get any books : " + ex.Message);
            books = 0;
            return false;
        }
    }
    public bool GetBorrowedBooksForCustomers(int customerId, out IEnumerable<dynamic> borrowedBooks)
    {
        try
        {
            borrowedBooks = db.connection.Query($"SELECT bb.ID, bb.date_of_loan, b.Title FROM borrowed_book bb INNER JOIN book b on bb.book_id =b.ID WHERE bb.customer_id = {customerId};");
            return true;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("LibraryManager: Cannot get borrowed books for customerId: " + customerId + " : " + ex.Message);
            borrowedBooks = null;
            return false;
        }
    }
}

