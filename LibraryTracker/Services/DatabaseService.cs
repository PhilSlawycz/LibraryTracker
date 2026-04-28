using LibraryTracker.Models;
using SQLite;
namespace LibraryTracker.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? Library_DB;

    private async Task Init()
    {
        if (Library_DB != null)
            return;
        Library_DB = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Library_DB.CreateTableAsync<Book>();

    }

    public async Task<List<Book>> GetBooksAsync()
    {
        await Init();
        return await Library_DB.Table<Book>().ToListAsync();
    }

    public async Task<int> SaveBookAsync(Book book)
    {
        await Init();
        if (book.Id != 0)
        {
            return await Library_DB.UpdateAsync(book);   
        }else
        {
            return await Library_DB.InsertAsync(book);
        }
    }

    public async Task<int> DeleteBookAsync(Book book)
    {
        await Init();
        return await Library_DB.DeleteAsync(book);
    }
    
}