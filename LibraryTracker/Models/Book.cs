namespace LibraryTracker.Models;

public class Book {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsRead { get; set; }
}