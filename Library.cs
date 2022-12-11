using Dapper;
using MySqlConnector;


public class Library
{
    DBConnections db = new();
    LibraryManager libraryManager = new();


    public Library()
    {

    }
    public bool ShowAllBooks()
    {
        try
        {
            IEnumerable<Book> books;
            if (libraryManager.GetAllBooks(out books)) // out betyder att du inte behöver skapa en ny variabel i metoden som anropas. Vi skickar med denna variablen till andra metoden. Alla förändringar som görs på variabeln i den andra klassen kommer även följa med. 
            {
                foreach (Book b in books)
                {
                    Console.WriteLine("All Books");
                    Console.WriteLine(b.ToString());
                }

                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: No books found in library");
            return false;
        }
    }

    public bool ShowAllBooksWithAuthors()
    {
        try
        {
            IEnumerable<dynamic> books;
            if (libraryManager.GetAllBooksTitleWithAuthors(out books))
            {
                Console.WriteLine("All Books With Authors");
                foreach (dynamic b in books)
                {
                    Console.WriteLine("Book title: " + b.title + ", Author: " + b.first_name + " " + b.last_name);
                }
                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: No books found in library");
            return false;
        }
    }
    public bool ListBorrowedBooks(int _customer_ID)
    {
        try
        {
            IEnumerable<BorrowedBooks> borrowed_books;
            if (libraryManager.GetBorrowedBooksForCustomer(_customer_ID, out borrowed_books))
            {
               Console.WriteLine("Borrowed Books");
                foreach (BorrowedBooks b in borrowed_books)
                {
                    Console.WriteLine(b.ToString());
                }
                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: No borrowed books found for customer");
            return false;
        }

    } 
    
}         