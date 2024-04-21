using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookScape.Models;


namespace BookScape.Controllers
{
    public class PostBookDTO
    {
        public string? Title { get; set; }
        public virtual PostBookAuthorDTO? Author { get; set; }
        public string? Language { get; set; }
    }

    public class PostBookAuthorDTO
    {
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookItems()
        {
            return await _context.BookItems.Include(b=>b.Author).ToListAsync();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
            var book = await _context.BookItems.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(PostBookDTO book)
        {
            Console.WriteLine(book);
            Book newBook = new Book{ 
                Title = book.Title,
                Language = book.Language,
                Author = new Author{
                    FullName = book?.Author?.FullName,
                    Gender = book?.Author?.Gender,
                    Country = book?.Author?.Country
                }
            };
            _context.BookItems.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = newBook.Id }, newBook);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _context.BookItems.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.BookItems.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(long id)
        {
            return _context.BookItems.Any(e => e.Id == id);
        }
    }
}
