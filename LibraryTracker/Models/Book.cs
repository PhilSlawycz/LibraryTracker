using SQLite;

namespace LibraryTracker.Models;

public class Book {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public string? Genre { get; set; }
    public bool IsRead { get; set; }
    public required string Isbn { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime DateAdded { get; set; }
}