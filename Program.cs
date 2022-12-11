using Dapper;
using MySqlConnector;
internal class Program
{
    private static void Main(string[] args)
    {
        DBConnections con = new DBConnections();
        LibraryManager libraryManager = new();
        CustomerManager customerManager = new();
        Library library = new();
        string userInput;




        bool loginMenu = true;
        while (loginMenu == true)
        {
            Console.Write("Please insert your library card (Enter ID): ");
            if (customerManager.LibraryCardInserted(Console.ReadLine())) ;
            {
            Console.WriteLine("Please enter you pin: ");
            }
            if (customerManager.PinEntered(Console.ReadLine()))
            {
                Console.WriteLine("CORRECT PIN");
                Console.WriteLine("Please Wait loading");
                Thread.Sleep(200);
            }
            bool customerMenu = true;
            while (customerMenu == true)
            {
                Console.WriteLine($"Welcome To Habo Library {customerManager.activeUser.Name} \n[1]Show All Books\n[2]Show All Books with Authors\n[3]Search For A Book");
                ConsoleKey menuKey = Console.ReadKey().Key;
                
                if (menuKey == ConsoleKey.D1)
                {
                    library.ShowAllBooks();
                }
                else if (menuKey == ConsoleKey.D2)
                {
                    library.ShowAllBooksWithAuthors();
                }
                else if (menuKey == ConsoleKey.D3)
                {


                }
                else if (menuKey == ConsoleKey.D4)
                {
                            library.ListBorrowedBooks(customerManager.loggedInUser.ID);
                                Console.WriteLine("Write Loan ID to return");
                                int loanId = 0;
                                if(Int32.TryParse(Console.ReadLine(), out loanId))
                                {
                                    if(library.ReturnBook(loanId))
                                    {
                                        Console.WriteLine("Book Returned");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wrong User Input");
                                }
                }


                else
                {
                    Console.WriteLine("Your library card was not found in the system");
                }

            }



        }


    }
}


