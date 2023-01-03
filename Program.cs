using Dapper;
using MySqlConnector;
internal class Program
{
    private static void Main(string[] args)
    {
        DBConnections con = new DBConnections();
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
                if (customerManager.LibraryCardInserted(Console.ReadLine()))
                {
                    Console.WriteLine("Please enter you pin: ");
                    if (customerManager.PinEntered(Console.ReadLine()))
                    {
                        Console.WriteLine("CORRECT PIN");
                        Font.ProgressBar(3, "Loading");
                        bool customerMenu = true;
                        while (customerMenu == true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome To Habo Library | Customer: {customerManager.activeUser.Name} \n[1] - Show All Books - Borrow a book\n[2] - Show All Books with Authors\n[3] - Your borrowed books\n[4] - Search For Book\n[5] - Information about Library");
                            ConsoleKey menuKey = Console.ReadKey().Key;
                            if (menuKey == ConsoleKey.D1)
                            {
                                library.ShowAllBooks();
                                Font.PrintText("Do you want to borrow any book? | Enter BookID for borrow, or press enter to return |): "); // Visar alla böcker och om du vill låna eller går tillbaka. 
                                int bookToBorrow;
                                if (Int32.TryParse(Console.ReadLine(), out bookToBorrow))
                                {
                                    if (bookToBorrow == 0)
                                    {
                                        Font.PrintErrorHeader("No book in stock");
                                    }
                                    else
                                    {
                                        library.BorrowBook(bookToBorrow, customerManager.loggedInUser.ID);
                                    }
                                }
                            }
                            else if (menuKey == ConsoleKey.D2)
                            {
                                library.ShowAllBooksWithAuthors(); // visar alla böcker med författare. 
                            }
                            else if (menuKey == ConsoleKey.D3)
                            {
                                library.ListBorrowedBooksForCustomer(customerManager.loggedInUser.ID); // Visar vilka böcker man har lånat och om man vill lämna tillbaka någon bok.
                                Font.PrintText("Write Loan ID to return or press enter to return");
                                int loanId = 0;
                                if (Int32.TryParse(Console.ReadLine(), out loanId))
                                {
                                    if (library.ReturnBook(loanId))
                                    {
                                        Font.PrintHeader("Book Returned");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Font.PrintErrorHeader("Invalid loan id");
                                    }
                                }
                            }
                            else if (menuKey == ConsoleKey.D4)
                            {
                                Font.PrintText("Please enter title of book: ");
                                string title = Console.ReadLine();
                                if (library.FindBooksByTitle(title)) // söcker efter bokens titel. Här kan man även låna boken eller gå tillbaka till start. 
                                {
                                    Console.WriteLine("Do You want to borrow this book? (Enter ID, or press enter for Exit)");
                                    int bookToBorrow = 0;
                                    if (Int32.TryParse(Console.ReadLine(), out bookToBorrow))
                                    {
                                        if (bookToBorrow == 0)
                                        {
                                            Font.PrintErrorHeader("No book in stock");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            library.BorrowBook(bookToBorrow, customerManager.loggedInUser.ID);
                                        }
                                    }
                                }
                                else
                                {
                                    Font.PrintErrorHeader("Cannot find book in library");
                                    Console.ReadLine();
                                }
                            }
                            else if (menuKey == ConsoleKey.D5)
                            {
                                library.GetSumOfBooks();
                            }
                            else
                            {
                                Font.PrintErrorHeader("Invalid input");
                                Console.ReadLine();
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Font.PrintErrorHeader("Wrong PIN");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Font.PrintErrorHeader("Not a valid ID:");
                    continue;
                }
            }
            else if (choiceKey == ConsoleKey.D2)
            {
                Console.Write("Please insert your admin card (Enter ID): ");
                if (adminManager.LibraryAdminCardInserted(Console.ReadLine()))
                {
                    Console.WriteLine("Please enter you pin: ");
                    if (adminManager.PinEntered(Console.ReadLine()))
                    {
                        Console.WriteLine("CORRECT PIN");
                        Font.ProgressBar(5, "Loading");
                        Thread.Sleep(200);
                        bool customerMenu = true;
                        while (customerMenu == true)
                        {
                            Console.WriteLine($"Welcome To Habo Library Admin: {adminManager.activeAdmin.AdminUserName} \n[1]Show All Customers\n[2]Show All Borrowed Books\n[3]Show All Books\n[4]Total sum of books\n[5]Exit library");
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
                                library.ShowAllBooks();
                            }
                            else if (menuKey == ConsoleKey.D4)
                            {
                                library.GetSumOfBooks();
                            }
                            else if (menuKey == ConsoleKey.D5)
                            {
                                Environment.Exit(0);
                            }
                        }
                    }
                    else
                    {
                        Font.PrintErrorHeader("Wrong PIN");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Font.PrintErrorHeader("Not a valid ID:");
                    continue;
                }
            }
        }
    }
}

