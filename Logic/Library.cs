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
    public bool BorrowBook(int _book_ID, int _customer_ID)
    {
        try
        {
            int currentStock;
            if (libraryManager.GetBookStock(_book_ID, out currentStock))
            {
                if (currentStock > 0)
                {
                    int newStock = currentStock - 1;
                    if (libraryManager.SetBookStock(newStock, _book_ID))
                    {
                        if (libraryManager.RegisterBorrowedBook(_book_ID, _customer_ID))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Book out of stock");
                }
            }

            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: Unable to borrow book");
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
    public bool ReturnBook(int _loan_ID)
    {
        try
        {
            int currentStock, newStock, book_id;
            if (libraryManager.GetBookIdFromLoanId(_loan_ID, out book_id))
            {
                if (libraryManager.DeleteBorrowedBook(_loan_ID))
                {
                    if (libraryManager.GetBookStock(book_id, out currentStock))
                    {
                        newStock = currentStock + 1;
                        if (libraryManager.SetBookStock(newStock, book_id))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Library: Unable to return book");
            return false;
        }
    }

    public bool ShowAllCustomers()
    {
        try
        {
            IEnumerable<Customer> customer;
            if (libraryManager.GetAllCustomers(out customer)) // out betyder att du inte behöver skapa en ny variabel i metoden som anropas. Vi skickar med denna variablen till andra metoden. Alla förändringar som görs på variabeln i den andra klassen kommer även följa med. 
            {
                foreach (Customer c in customer)
                {
                    Console.WriteLine("All Books");
                    Console.WriteLine(c.ToString());
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
    public bool ShowAllBorrowedBooks()
    {
        try
        {
            IEnumerable<BorrowedBooks> borrowedBooks;
            if (libraryManager.GetAllBorrowedBooks(out borrowedBooks)) // out betyder att du inte behöver skapa en ny variabel i metoden som anropas. Vi skickar med denna variablen till andra metoden. Alla förändringar som görs på variabeln i den andra klassen kommer även följa med. 
            {
                foreach (BorrowedBooks bB in borrowedBooks)
                {
                    Console.WriteLine("All Books");
                    Console.WriteLine(bB.ToString());
                }

                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: No Borrowed books found in library");
            return false;
        }
    }
}