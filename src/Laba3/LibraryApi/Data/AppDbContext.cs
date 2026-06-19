using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();

    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<BookGenre> BookGenres => Set<BookGenre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(author => author.Name).IsRequired().HasMaxLength(100);
            entity.Property(author => author.Country).IsRequired().HasMaxLength(100);

            entity
                .HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(book => book.Title).IsRequired().HasMaxLength(200);

            entity
                .HasMany(book => book.BookGenres)
                .WithOne(bookGenre => bookGenre.Book)
                .HasForeignKey(bookGenre => bookGenre.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(genre => genre.Name).IsRequired().HasMaxLength(100);

            entity
                .HasMany(genre => genre.BookGenres)
                .WithOne(bookGenre => bookGenre.Genre)
                .HasForeignKey(bookGenre => bookGenre.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<BookGenre>(entity =>
        {
            // Составной ключ нужен для промежуточной таблицы связи many-to-many.
            entity.HasKey(bookGenre => new { bookGenre.BookId, bookGenre.GenreId });
        });
    }
}
