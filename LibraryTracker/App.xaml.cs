using LibraryTracker.Services;

namespace LibraryTracker;

public partial class App : Application
{
    public App(DatabaseService databaseService)
    {
        InitializeComponent();
        MainPage = new MainPage(databaseService);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}