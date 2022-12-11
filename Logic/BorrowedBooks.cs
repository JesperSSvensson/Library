using Dapper;
using MySqlConnector;

public class BorrowedBooks
{
    public int ID;
    public DateTime date_of_loan;
    public int book_id;
    public int customer_id;
    


    public BorrowedBooks()
    {
        
    }

     public override string ToString()
    {
        
        return "\nBorrowedBookID: " + ID + " |DateOfLoan: " + date_of_loan + "  +  |bookID: " + book_id + " |CustomerID: " + customer_id;
    }

}