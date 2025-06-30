
using Day3Activity;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using T2.Models;

public class LibraryService : ILibraryService
{

    private readonly ILibraryRepository _libraryRepository;
    public LibraryService(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }
    public async Task<List<User>> GetUsers()
    {
        List<User> users =  await _libraryRepository.GetUsers();
        return users;
    }
    public async Task<List<Book>> GetBooks()
    {
        List<Book> books =  await _libraryRepository.GetBooks();
        return books;
    }
    public  async Task<List<Borrow>> GetBorrows()
    {
        List<Borrow> borrows = await _libraryRepository.GetBorrows();
        return borrows;
    }

    public async void AddUser(User userDetails)
    {
        await _libraryRepository.AddUser(userDetails);
    }

    public async void AddBook(Book bookDetails)
    {
        await _libraryRepository.AddBook(bookDetails);
    }
    public async void AddBorrow(Borrow b1)
    {
        await _libraryRepository.AddBorrow(b1); 
    }
    public async void UpdateBookQuantity(int isbn, int quantity)
    {
        await _libraryRepository.UpdateBook(isbn,quantity);
    }

    public async Task<List<int>> getUserBooks(int userId)
    {
        List<Borrow> borrows = await GetBorrows();
        List<int> borrowedbookIds = new List<int>();
        foreach (Borrow borrow in borrows)
        {
            if (borrow.sid == userId)
            {
                borrowedbookIds.Add(borrow.Bid);
            }
        }
        return borrowedbookIds;
    }
    public async Task BorrowBook(Borrow b1)
    {

        List<Book> books = await GetBooks();
        foreach (Book book in books)
        {
            if (book.isbn == b1.Bid)
            {
                if (book.quantity > 0)
                {
                    AddBorrow(b1);
                    UpdateBookQuantity(book.isbn,book.quantity);     
                    book.quantity -= 1;
                    Console.WriteLine($"{b1.sid} borrowed {b1.Bid}");
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