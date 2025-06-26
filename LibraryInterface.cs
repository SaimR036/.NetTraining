using T2.Models;

public interface ILibraryService
{
    void AddUser(User userDetails);
    void AddBook(Book bookDetails);
    void BorrowBook(int isbn, int userId);
}

public class LibraryService : ILibraryService
{
    List<User> users = new List<User>();
    List<Book> books = new List<Book>();
    List<Borrow> borrows = new List<Borrow>();

    public void AddUser(User userDetails)
    {
        users.Add(userDetails);
    }

    public void AddBook(Book bookDetails)
    {
        books.Add(bookDetails);
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