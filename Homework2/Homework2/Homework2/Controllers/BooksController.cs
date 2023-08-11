using Homework2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet] //https://localhost:[port]/api/Books
        public IActionResult GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("{index}")] //https://localhost:[port]/api/Books/{index}
        public IActionResult GetBookByIndex(int index)
        {
            if (index < 0 || index >= StaticDb.Books.Count)
                return NotFound($"Book with index {index} was not found!");

            var book = StaticDb.Books[index];
            return Ok(book);
        }

        [HttpGet("filter")] //https://localhost:[port]/api/Books/filter?author={author}&title={title}
        public IActionResult GetBookByFilter([FromQuery] string author, [FromQuery] string title)
        {
            var book = StaticDb.Books.FirstOrDefault(b =>
                b.Author.ToLower() == author.ToLower() &&
                b.Title.ToLower() == title.ToLower());

            if (book == null)
            {
                return NotFound("No matching book found!");
            }

            return Ok(book);
        }

        [HttpPost] //https://localhost:[port]/api/Books
        public IActionResult AddNewBook([FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Invalid book data!");
            }

            StaticDb.Books.Add(newBook);

            return Ok(newBook);
        }

        [HttpPost("titles")] //https://localhost:[port]/api/Books/titles
        public IActionResult GetTitlesFromBooks([FromBody] List<Book> books)
        {
            if (books == null || books.Count == 0)
            {
                return BadRequest("Invalid book list!");
            }

            List<string> titles = books.Select(book => book.Title).ToList();

            return Ok(titles);
        }
    }
}