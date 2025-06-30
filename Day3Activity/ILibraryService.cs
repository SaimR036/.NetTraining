using T2.Models;

public interface ILibraryService
{
    void AddUser(User userDetails);
    void AddBook(Book bookDetails);
    void AddBorrow(Borrow b1);
    Task<List<Book>> GetBooks();
    Task<List<int>> getUserBooks(int userId);
    Task<List<User>> GetUsers();
}
