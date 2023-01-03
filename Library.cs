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
                Font.PrintText("All Books With Authors");
                foreach (dynamic b in books)
                {
                    Console.WriteLine("Book Title: " + b.title + " | Author: " + b.FirstName + " " + b.LastName + "\n");
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
                if (currentStock > 0) // om lagret är större än noll så går den vidare. 
                {
                    int newStock = currentStock - 1; // här uppdateras stock med -1 om det finns någon book på lagret.
                    if (libraryManager.SetBookStock(newStock, bookId))
                    {
                        if (libraryManager.RegisterBorrowedBook(bookId, customerId)) // Här går den vidare till queryn. Går den igenom så retunerar den sant. Du har nu lånat en bok. 
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Font.PrintErrorHeader("Book out of stock"); // skulle något av oavstående inte gå igenom så finns inte boken på lagret. 
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
    public bool ListBorrowedBooks(int customerId)
    {
        try
        {
            IEnumerable<BorrowedBooks> borrowedBooks;
            if (libraryManager.GetBorrowedBooksForCustomer(customerId, out borrowedBooks))
            {
                Console.WriteLine("Borrowed Books");
                foreach (BorrowedBooks b in borrowedBooks)
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
    public bool ReturnBook(int loanId)
    {
        try
        {
            int currentStock, newStock, bookId;
            if (libraryManager.GetBookIdFromLoanId(loanId, out bookId))
            {
                if (libraryManager.DeleteBorrowedBook(loanId))
                {
                    if (libraryManager.GetBookStock(bookId, out currentStock))
                    {
                        newStock = currentStock + 1;
                        if (libraryManager.SetBookStock(newStock, bookId))
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
            if (libraryManager.GetAllBorrowedBooks(out borrowedBooks))
            {
                Font.PrintHeader("All borrowed books");
                foreach (BorrowedBooks bB in borrowedBooks)
                {
                    Console.WriteLine(bB.ToString());
                }
                Console.ReadKey();

                return true;
            }

            return false;
        }
        catch (System.Exception)
        {
            Font.PrintErrorHeader("Library: No Borrowed books found in library");
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
                if (books?.Any() == false) // här kollar vi om det finns några element när vi söker. Om det inte gör det så får vi ett felmeddelande. Den returnerar false.
                {
                    return false;
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
                    Font.PrintText("Total Numbers of Books In Library: " + books + " | Press enter to continue");
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
    public bool ListBorrowedBooksForCustomer(int customerId)
    {
        try
        {
            IEnumerable<dynamic> borrowedBookss;
            if (libraryManager.GetBorrowedBooksForCustomers(customerId, out borrowedBookss))
            {
                Font.PrintText("Borrowed Books");
                foreach (dynamic b in borrowedBookss)
                {
                    Console.WriteLine("\nTitle: " + b.Title + " | Loan ID: " + b.ID + " | Date: " + b.date_of_loan + "\n");
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