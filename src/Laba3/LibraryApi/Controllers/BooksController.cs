using LibraryApi.Data;
using LibraryApi.Dtos.Books;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BooksController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResponse>>> GetAll()
    {
        var books = await _dbContext.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .OrderBy(book => book.Id)
            .Select(book => ToResponse(book))
            .ToListAsync();

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookResponse>> GetById(int id)
    {
        var book = await _dbContext.Books
            .AsNoTracking()
            .Include(item => item.Author)
            .Include(item => item.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (book is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(book));
    }

    [HttpPost]
    public async Task<ActionResult<BookResponse>> Create(CreateBookRequest request)
    {
        var authorExists = await _dbContext.Authors.AnyAsync(author => author.Id == request.AuthorId);

        if (!authorExists)
        {
            return BadRequest();
        }

        var book = new Book
        {
            Title = request.Title,
            Year = request.Year,
            AuthorId = request.AuthorId
        };

        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();

        var createdBook = await GetBookWithDetails(book.Id);

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, ToResponse(createdBook!));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateBookRequest request)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        var authorExists = await _dbContext.Authors.AnyAsync(author => author.Id == request.AuthorId);

        if (!authorExists)
        {
            return BadRequest();
        }

        book.Title = request.Title;
        book.Year = request.Year;
        book.AuthorId = request.AuthorId;

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("{bookId:int}/genres/{genreId:int}")]
    public async Task<IActionResult> AddGenre(int bookId, int genreId)
    {
        var bookExists = await _dbContext.Books.AnyAsync(book => book.Id == bookId);

        if (!bookExists)
        {
            return NotFound();
        }

        var genreExists = await _dbContext.Genres.AnyAsync(genre => genre.Id == genreId);

        if (!genreExists)
        {
            return NotFound();
        }

        var relationExists = await _dbContext.BookGenres
            .AnyAsync(bookGenre => bookGenre.BookId == bookId && bookGenre.GenreId == genreId);

        if (relationExists)
        {
            return NoContent();
        }

        _dbContext.BookGenres.Add(new BookGenre
        {
            BookId = bookId,
            GenreId = genreId
        });

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{bookId:int}/genres/{genreId:int}")]
    public async Task<IActionResult> RemoveGenre(int bookId, int genreId)
    {
        var bookExists = await _dbContext.Books.AnyAsync(book => book.Id == bookId);

        if (!bookExists)
        {
            return NotFound();
        }

        var genreExists = await _dbContext.Genres.AnyAsync(genre => genre.Id == genreId);

        if (!genreExists)
        {
            return NotFound();
        }

        var relation = await _dbContext.BookGenres
            .FirstOrDefaultAsync(bookGenre => bookGenre.BookId == bookId && bookGenre.GenreId == genreId);

        if (relation is null)
        {
            return NotFound();
        }

        _dbContext.BookGenres.Remove(relation);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{bookId:int}/genres")]
    public async Task<ActionResult<List<BookGenreResponse>>> GetGenres(int bookId)
    {
        var bookExists = await _dbContext.Books.AnyAsync(book => book.Id == bookId);

        if (!bookExists)
        {
            return NotFound();
        }

        var genres = await _dbContext.BookGenres
            .AsNoTracking()
            .Where(bookGenre => bookGenre.BookId == bookId)
            .Include(bookGenre => bookGenre.Genre)
            .OrderBy(bookGenre => bookGenre.GenreId)
            .Select(bookGenre => new BookGenreResponse
            {
                Id = bookGenre.GenreId,
                Name = bookGenre.Genre!.Name
            })
            .ToListAsync();

        return Ok(genres);
    }

    private async Task<Book?> GetBookWithDetails(int id)
    {
        return await _dbContext.Books
            .AsNoTracking()
            .Include(book => book.Author)
            .Include(book => book.BookGenres)
            .ThenInclude(bookGenre => bookGenre.Genre)
            .FirstOrDefaultAsync(book => book.Id == id);
    }

    private static BookResponse ToResponse(Book book)
    {
        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Year = book.Year,
            AuthorId = book.AuthorId,
            AuthorName = book.Author?.Name ?? string.Empty,
            Genres = book.BookGenres
                .OrderBy(bookGenre => bookGenre.GenreId)
                .Select(bookGenre => new BookGenreResponse
                {
                    Id = bookGenre.GenreId,
                    Name = bookGenre.Genre?.Name ?? string.Empty
                })
                .ToList()
        };
    }
}
