using LibraryTracker.Models;
using SQLite;
namespace LibraryTracker.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _libraryDb;

    private async Task <SQLiteAsyncConnection> EnsureConnectionAsync()
    {
        if (_libraryDb != null)
            return _libraryDb;
        _libraryDb = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await _libraryDb.CreateTableAsync<Book>();
        System.Diagnostics.Debug.WriteLine($"Database path {Constants.DatabasePath}");
        return _libraryDb;

    }

    public async Task<List<Book>> GetBooksAsync()
    {
        var db = await EnsureConnectionAsync();
        return await db.Table<Book>().ToListAsync();
    }

    public async Task<int> SaveBookAsync(Book book)
    {
        var db = await EnsureConnectionAsync();
        if (book.Id != 0)
        {
            return await db.UpdateAsync(book);   
        }else
        {
            return await db.InsertAsync(book);
        }
    }

    public async Task<int> DeleteBookAsync(Book book)
    {

        var db = await EnsureConnectionAsync();
        return await db.DeleteAsync(book);
    }
    
}