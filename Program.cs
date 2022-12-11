using Dapper;
using MySqlConnector;
internal class Program
{
    private static void Main(string[] args)
    {
        DBConnections con = new DBConnections();
        LibraryManager libraryManager = new();
        CustomerManager customerManager = new();
        

        while (true)
        {
            Console.Write("Please insert your library card (Enter ID): ");
            if (customerManager.LibraryCardInserted(Console.ReadLine()))
            {
                Console.WriteLine("Please enter you pin: ");

                if (customerManager.PinEntered(Console.ReadLine()))
                {
                    Console.WriteLine("CORRECT PIN");
                    Console.WriteLine("Please Wait loading");
                    

                    string dots = "......";

                    while (true)
                    {
                        for (int i = 0; i < dots.Length; i++)
                        {
                            Console.Write(dots[i]);
                            System.Threading.
                            Thread.Sleep(800);
                        }
                        StartMenu();
                    }
                }
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
                    Console.Clear();
                    Console.WriteLine($"Welcome To Habo Library {customerManager.activeUser.Name} \n[1]Borrow a book\n[2]Return a book\n[3]Show All books");
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


