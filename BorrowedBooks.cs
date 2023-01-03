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

        return "\nBorrowedBook ID: " + ID + " |Date of loan: " + date_of_loan + " |book ID: " + Book_id + " |Customer ID: " + Customer_id;
    }
}