using Dapper;
using MySqlConnector;

public class BorrowedBooks
{
    public int ID;
    public DateTime date_of_loan;
    public int Book_id;
    public int Customer_id;

    public BorrowedBooks()
    {

    }
    public override string ToString()
    {

        return "\nBorrowedBookID: " + ID + " |DateOfLoan: " + date_of_loan + "  +  |bookID: " + Book_id + " |CustomerID: " + Customer_id;
    }
}