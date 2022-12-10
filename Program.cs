using Dapper;
using MySqlConnector;
internal class Program
{
    private static void Main(string[] args)
    {
        DBConnections con = new DBConnections();
        CustomerConnect db = new();
        Library library = new();


        while (true)
        {
            Console.Write("Please insert your library card (Enter ID): ");
            if (library.LibraryCardInserted(Console.ReadLine()))
            {
                StartMenu();
            }
            else
            {
                Console.WriteLine("Your library card was not found in the system");
            }
            break;


            void StartMenu()
            {
                bool menu = true;
                while (menu == true)
                {


                    Console.WriteLine($"Welcome To Habo Library\n [1]Loan a book\n [2]Return a book\n [3]Show All books");
                    Console.WriteLine("");
                    ConsoleKey menuKey = Console.ReadKey().Key;

                    if (menuKey == ConsoleKey.D1)
                    {

                    }
                    else if (menuKey == ConsoleKey.D2)
                    {

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


