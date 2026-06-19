using LibraryApi.Data;
using LibraryApi.Dtos.Genres;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public GenresController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<GenreResponse>>> GetAll()
    {
        var genres = await _dbContext.Genres
            .AsNoTracking()
            .Include(genre => genre.BookGenres)
            .OrderBy(genre => genre.Id)
            .Select(genre => ToResponse(genre))
            .ToListAsync();

        return Ok(genres);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GenreResponse>> GetById(int id)
    {
        var genre = await _dbContext.Genres
            .AsNoTracking()
            .Include(item => item.BookGenres)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (genre is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(genre));
    }

    [HttpPost]
    public async Task<ActionResult<GenreResponse>> Create(CreateGenreRequest request)
    {
        var genre = new Genre
        {
            Name = request.Name
        };

        _dbContext.Genres.Add(genre);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = genre.Id }, ToResponse(genre));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateGenreRequest request)
    {
        var genre = await _dbContext.Genres.FindAsync(id);

        if (genre is null)
        {
            return NotFound();
        }

        genre.Name = request.Name;

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _dbContext.Genres.FindAsync(id);

        if (genre is null)
        {
            return NotFound();
        }

        _dbContext.Genres.Remove(genre);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private static GenreResponse ToResponse(Genre genre)
    {
        return new GenreResponse
        {
            Id = genre.Id,
            Name = genre.Name,
            BooksCount = genre.BookGenres.Count
        };
    }
}
