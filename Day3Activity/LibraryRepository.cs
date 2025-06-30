using Microsoft.EntityFrameworkCore;
using T2.Models;
namespace Day3Activity
{
    public class LibraryRepository(LibraryDBContext dbContext): ILibraryRepository
    {
        private readonly LibraryDBContext _dbContext = dbContext;
        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<List<Book>> GetBooks()
        {
            return await _dbContext.Books.ToListAsync();   
        }
        public async Task<List<Borrow>> GetBorrows()
        {
            return await _dbContext.Borrows.ToListAsync();  
        }
        public async Task AddBook(Book b1)
        {
            _dbContext.Books.Add(b1);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddUser(User u1)
        {
            _dbContext.Users.Add(u1);
            await _dbContext.SaveChangesAsync();

        }
        public async Task AddBorrow(Borrow b1)
        {
            _dbContext.Borrows.Add(b1);
            await _dbContext.SaveChangesAsync();

        }
        public async Task  UpdateBook(int isbn, int quantity)
        {
            var book = await _dbContext.Books.FindAsync(isbn) ?? new Book();
            book.quantity = quantity;
            await _dbContext.SaveChangesAsync();
        }

    }
}
