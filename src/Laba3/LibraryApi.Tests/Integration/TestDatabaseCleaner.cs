using LibraryApi.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi.Tests.Integration;

public static class TestDatabaseCleaner
{
    public static async Task ClearAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.BookGenres.RemoveRange(dbContext.BookGenres);
        dbContext.Books.RemoveRange(dbContext.Books);
        dbContext.Genres.RemoveRange(dbContext.Genres);
        dbContext.Authors.RemoveRange(dbContext.Authors);

        await dbContext.SaveChangesAsync();
    }
}
