using Dapper;
using MySqlConnector;

public class BorrowedBooks
{
    public DateTime date_of_loan;
    public DateTime date_of_return;
    public int book_id;
    public int customer_id;


    public BorrowedBooks()
    {
        
    }
}