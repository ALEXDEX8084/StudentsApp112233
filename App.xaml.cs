using System;
using System.IO;
namespace StudentsApp;

public partial class App : Application
{
    public const string DATABASE_NAME = "friends.db";
    public static StudentRepository database;
    public static StudentRepository Database
    {
        get
        {
            if (database == null)
            {
                database = new StudentRepository(
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
            }
            return database;
        }
    }
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
    protected override void OnStart()
    {
    }
    protected override void OnSleep()
    {
    }
    protected override void OnResume()
    {
    }
}
