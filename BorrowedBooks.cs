using Dapper;
using MySqlConnector;

public class BorrowedBooks
{
    public int ID;
    public DateOnly date_of_loan;
    public int bookId;
    public int customerId;
    


    public BorrowedBooks()
    {
        
    }

     public override string ToString()
    {
        
        return "\nBorrowedBookID: " + ID + " |DateOfLoan: " + date_of_loan + "  +  |bookID: " + bookId + " |CustomerID: " + customerId;
    }

}