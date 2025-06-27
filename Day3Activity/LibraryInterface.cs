using T2.Models;

public interface ILibraryService
{
    void AddUser(User userDetails);
    void AddBook(Book bookDetails);
    void BorrowBook(int isbn, int userId);
    List<Book> GetBooks();
    List<int> getUserBooks(int userId);
    List<User> getUsers();
}

public class LibraryService : ILibraryService
{
    List<User> users = new List<User>();
    List<Book> books = new List<Book>();
    List<Borrow> borrows = new List<Borrow>();
    public List<User> getUsers()
    {
        return users;
    }
    public void AddUser(User userDetails)
    {
        users.Add(userDetails);
    }

    public void AddBook(Book bookDetails)
    {
        books.Add(bookDetails);
    }

    public List<Book> GetBooks()
    {
        return books;
    }
    public List<int> getUserBooks(int userId)
    {
        List<int> borrowedbookIds = new List<int>();
        foreach (Borrow borrow in borrows)
        {
            if(borrow.sid == userId)
            {
                borrowedbookIds.Add(borrow.Bid);
            }
        }
        return borrowedbookIds;
    }
    public void BorrowBook(int isbn, int userId)
    {
        foreach (var book in books)
        {
            if (book.isbn == isbn)
            {
                if (book.quantity > 0)
                {
                    borrows.Add(new Borrow(userId, isbn));
                    book.quantity -= 1;
                    Console.WriteLine($"{userId} borrowed {isbn}");
                    break;
                }
                else
                {
                    Console.WriteLine("Book out of stock.");
                    return;
                }
            }

        }

        Console.WriteLine("\nBooks remaining:");
        foreach (var book in books)
        {
            Console.WriteLine(book.title);
        }
    }
}