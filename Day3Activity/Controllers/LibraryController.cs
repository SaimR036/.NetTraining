using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using T2.Models;

namespace Day3.NetTraining.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly AppOptions _options;
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILibraryService service, IOptions<AppOptions> options)
        {
            _libraryService = service;
            _options = options.Value;
        }

        [HttpGet("GetBooks")]
        public Task<List<Book>> GetBooks()
        {
            return _libraryService.GetBooks();
        }

        [HttpPost("AddBooks")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _logger.LogInformation("AddBook Called");
            _libraryService.AddBook(book);
            return Ok("Book Added");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            _libraryService.AddUser(user);
            return Ok(user);
        }

        [HttpPost("borrow")]
        public IActionResult BorrowBook([FromQuery] int isbn, [FromQuery] int userId)
        {
            Borrow b1 = new Borrow(isbn, userId);
            _libraryService.AddBorrow(b1);
            return Ok($"User {userId} attempted to borrow book {isbn}");
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_libraryService.GetUsers());
        }

        [HttpGet("users/{userId}/books")]
        public IActionResult GetUserBooks(int userId)
        {
            var borrowedBooks = _libraryService.getUserBooks(userId);
            return Ok(borrowedBooks);
        }
    }
}
