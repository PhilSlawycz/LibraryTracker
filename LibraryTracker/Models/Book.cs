using SQLite;

namespace LibraryTracker.Models;

public class Book {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string? Genre { get; set; }
    public bool IsRead { get; set; }
    public string ISBN { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime DateAdded { get; set; }
}