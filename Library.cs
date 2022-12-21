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
                Font.PrintHeader("All Books");
                foreach (Book b in books)
                {
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
                Console.ReadKey();
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
    public bool BorrowBook(int bookId, int customerId)
    {
        try
        {
            int currentStock;
            if (libraryManager.GetBookStock(bookId, out currentStock))
            {
                if (currentStock > 0)
                {
                    int newStock = currentStock - 1;
                    if (libraryManager.SetBookStock(newStock, bookId))
                    {
                        if (libraryManager.RegisterBorrowedBook(bookId, customerId))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Font.PrintErrorHeader("Book out of stock");
                    Console.ReadLine();
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
        catch (System.Exception)
        {
            Console.WriteLine("Library: Unable to return book");
            return false;
        }
    }

    public bool ShowAllCustomers() // visar alla kunder
    {
        try
        {
            IEnumerable<Customer> customer;
            if (libraryManager.GetAllCustomers(out customer)) // out betyder att du inte behöver skapa en ny variabel i metoden som anropas. Vi skickar med denna variablen till andra metoden. Alla förändringar som görs på variabeln i den andra klassen kommer även följa med. 
            {
                Font.PrintHeader("All customers");
                foreach (Customer c in customer)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.ReadKey();
                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: No customers found in library");
            return false;
        }
    }
    public bool ShowAllBorrowedBooks() // visar alla lånade böcker
    {
        try
        {
            IEnumerable<BorrowedBooks> borrowedBooks;
            if (libraryManager.GetAllBorrowedBooks(out borrowedBooks)) // out betyder att du inte behöver skapa en ny variabel i metoden som anropas. Vi skickar med denna variablen till andra metoden. Alla förändringar som görs på variabeln i den andra klassen kommer även följa med. 
            {
                Font.PrintHeader("All borrowed books");
                foreach (BorrowedBooks bB in borrowedBooks)
                {
                    Console.WriteLine("All Books");
                    Console.WriteLine(bB.ToString());
                }
                Console.ReadKey();

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
    public bool FindBooksByTitle(string title)
    {   
    
        try
        {
            IEnumerable<Book> books;
            if (libraryManager.GetBookByTitle(title, out books))
            {
                foreach (Book b in books)
                {
                    Console.WriteLine(b.ToString());
                }
                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Font.PrintErrorHeader("Library: No books found");
        }
            return false;
    }

    public bool GetSumOfBooks()
    {
        try
        {
            int books;
            if (libraryManager.ShowBookStock(out books))
            {
                {
                    Console.Clear();
                    Font.PrintText("Total Numbers of Books In Library: " + books);
                    Console.ReadKey();
                }
                return true;
            }
            return false;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Library: No Books found in library");
            return false;
        }
    }
    
    public bool ListBorrowedBookss(int _customer_ID)
    {
        try
        {
            IEnumerable<dynamic> borrowed_bookss;
            if (libraryManager.GetBorrowedBooksForCustomers(_customer_ID, out borrowed_bookss))
            {   
                Console.WriteLine("Borrowed Books");
                foreach (dynamic b in borrowed_bookss)
                {
                    // Console.WriteLine("Book ID: " + b.ID + " Date: " + b.date_of_loan);
                    Console.WriteLine("\nTitle: " + b.Title + " Book ID: " + b.ID + " Date: " + b.dateOfLoan + "\n");
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