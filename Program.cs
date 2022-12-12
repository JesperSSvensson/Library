using Dapper;
using MySqlConnector;
internal class Program
{
    private static void Main(string[] args)
    {
        DBConnections con = new DBConnections();
        LibraryManager libraryManager = new();
        CustomerManager customerManager = new();
        AdminManager adminManager = new();
        Library library = new();
        

        bool loginMenu = true;
        while (loginMenu == true)
        {
            Console.WriteLine("[1] Customer [2] Admin");
            ConsoleKey choiceKey = Console.ReadKey().Key;

            if (choiceKey == ConsoleKey.D1)
            {
                Console.Write("Please insert your library card (Enter ID): ");
                if (customerManager.LibraryCardInserted(Console.ReadLine())) ;
                {
                    Console.WriteLine("Please enter you pin: ");
                }
                if (customerManager.PinEntered(Console.ReadLine()))
                {
                    Console.WriteLine("CORRECT PIN");
                    Font.ProgressBar(5, "Loading");
                    Thread.Sleep(400);
                }
                bool customerMenu = true;
                while (customerMenu == true)
                {   Console.Clear();
                    Console.WriteLine($"Welcome To Habo Library {customerManager.activeUser.Name} \n[1]Show All Books\n[2]Show All Books with Authors\n[3]Search For A Book");
                    ConsoleKey menuKey = Console.ReadKey().Key;

                    if (menuKey == ConsoleKey.D1)
                    {
                        library.ShowAllBooks();
                        Console.Write("Do You want to borrow any book? (Enter ID, or 0 for Exit): ");
                        int bookToBorrow;
                        if (Int32.TryParse(Console.ReadLine(), out bookToBorrow))
                        {
                            if (bookToBorrow == 0)
                            {
                                
                            }
                            else
                            {
                                library.BorrowBook(bookToBorrow, customerManager.loggedInUser.ID);

                            }
                        }
                    }
                    else if (menuKey == ConsoleKey.D2)
                    {
                        library.ShowAllBooksWithAuthors();
                    }
                    else if (menuKey == ConsoleKey.D3)
                    {
                        library.ListBorrowedBooks(customerManager.loggedInUser.ID);
                        Console.WriteLine("Write Loan ID to return");
                        int loanId = 0;
                        if (Int32.TryParse(Console.ReadLine(), out loanId))
                        {
                            if (library.ReturnBook(loanId))
                            {
                                Console.WriteLine("Book Returned");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong User Input");
                        }

                    }
                    else if (menuKey == ConsoleKey.D4)
                    {

                    }


                    else
                    {
                        Console.WriteLine("Your library card was not found in the system");
                    }

                }
            }
            else if (choiceKey == ConsoleKey.D2)
            {
                Console.Write("Please insert your admin card (Enter ID): ");
                if (adminManager.LibraryAdminCardInserted(Console.ReadLine())) ;
                {
                    Console.WriteLine("Please enter you pin: ");
                }
                if (adminManager.PinEntered(Console.ReadLine()))
                {
                    Console.WriteLine("CORRECT PIN");
                    Font.ProgressBar(5, "Loading");
                    Thread.Sleep(200);
                }
                else
                {
                    Console.WriteLine("Your library card was not found in the system");
                }
                bool customerMenu = true;
                while (customerMenu == true)
                {
                    
                    Console.WriteLine($"Welcome To Habo Library {adminManager.activeAdmin.admin_user_name} \n[1]Show All Customers\n[2]Show All Borrowed Books\n[3]Show All Books");
                    ConsoleKey menuKey = Console.ReadKey().Key;

                    if (menuKey == ConsoleKey.D1)
                    {
                        library.ShowAllCustomers();
                    }
                    else if (menuKey == ConsoleKey.D2)
                    {
                        library.ShowAllBorrowedBooks();
                    }
                    else if (menuKey == ConsoleKey.D3)
                    {
                        
                    }
                    else if (menuKey == ConsoleKey.D4)
                    {

                    }
                }
            }
        }
    }
}


