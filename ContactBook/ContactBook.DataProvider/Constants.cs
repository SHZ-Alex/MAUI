using FileSystem = Microsoft.Maui.Storage.FileSystem;

namespace ContactBook.DataProvider;

public class Constants
{
    private const string DatabaseFileName = "ContactsSQLite.db3";

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
}