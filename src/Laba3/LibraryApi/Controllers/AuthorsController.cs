using LibraryApi.Data;
using LibraryApi.Dtos.Authors;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public AuthorsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorResponse>>> GetAll()
    {
        var authors = await _dbContext.Authors
            .AsNoTracking()
            .Include(author => author.Books)
            .OrderBy(author => author.Id)
            .Select(author => ToResponse(author))
            .ToListAsync();

        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AuthorResponse>> GetById(int id)
    {
        var author = await _dbContext.Authors
            .AsNoTracking()
            .Include(item => item.Books)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (author is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(author));
    }

    [HttpPost]
    public async Task<ActionResult<AuthorResponse>> Create(CreateAuthorRequest request)
    {
        var author = new Author
        {
            Name = request.Name,
            Country = request.Country
        };

        _dbContext.Authors.Add(author);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = author.Id }, ToResponse(author));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateAuthorRequest request)
    {
        var author = await _dbContext.Authors.FindAsync(id);

        if (author is null)
        {
            return NotFound();
        }

        author.Name = request.Name;
        author.Country = request.Country;

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _dbContext.Authors.FindAsync(id);

        if (author is null)
        {
            return NotFound();
        }

        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private static AuthorResponse ToResponse(Author author)
    {
        return new AuthorResponse
        {
            Id = author.Id,
            Name = author.Name,
            Country = author.Country,
            BooksCount = author.Books.Count
        };
    }
}
