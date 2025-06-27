using System.Text.Json;
using Microsoft.Extensions.Options;
using T2.Models;

namespace T2.Services
{
    public class Runner
    {
        private readonly ILibraryService _libraryService;
        private readonly AppOptions _options;
        public Runner(ILibraryService service, IOptions<AppOptions> options) 
        {
            _libraryService = service;
            _options = options.Value;
        }
        public void Run()
        {

            Console.WriteLine($"{_options.Title} - {_options.Version}");
            string bpath = "books.json";
            string data = File.ReadAllText(bpath);
            List<Book>? books = JsonSerializer.Deserialize<List<Book>>(data);
            string upath = "users.json";
            string udata = File.ReadAllText(upath);
            List<User>? users = JsonSerializer.Deserialize<List<User>>(udata);
            foreach (Book book in books)
            {
                _libraryService.AddBook(book);
            }
            foreach (User user in users)
            {
                 _libraryService.AddUser(user);

            }
            _libraryService.BorrowBook(1000,1);


        }
    }
}