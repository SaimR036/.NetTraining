using T2.Models;

namespace Day3Activity
{
    public interface ILibraryRepository
    {
        public Task<List<User>> GetUsers();
        public Task<List<Book>> GetBooks();
        public Task<List<Borrow>> GetBorrows();
        public Task AddBook(Book b1);
        public Task AddUser(User u1);
        public Task AddBorrow(Borrow borrow);

        public Task UpdateBook(int isbn, int quantity);



    }
}
