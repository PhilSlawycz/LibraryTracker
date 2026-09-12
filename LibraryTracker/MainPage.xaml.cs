using LibraryTracker.Models;
using LibraryTracker.Services;

namespace LibraryTracker;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    
    int count = 0;

    public MainPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        var allBooks = await _databaseService.GetBooksAsync();
        System.Diagnostics.Debug.WriteLine($"Books in database: {allBooks.Count}");

        foreach (var book in allBooks)
        {
            System.Diagnostics.Debug.WriteLine($" Id={book.Id}, Title={book.Title}, Author={book.Author}, IsRead={book.IsRead}, DateRead={book.DateRead}");
        }
    }
}