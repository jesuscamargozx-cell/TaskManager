using Microsoft.Data.Sqlite;

namespace TaskManager.Data;

public static class Database
{
    private static readonly string FolderPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                     "TaskManager");

    public static string DatabasePath => Path.Combine(FolderPath, "taskmanager.db");

    public static string ConnectionString =>
        new SqliteConnectionStringBuilder { DataSource = DatabasePath }.ToString();

    public static void Initialize()
    {
        Directory.CreateDirectory(FolderPath);

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS Tareas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Descripcion TEXT NOT NULL DEFAULT '',
                Prioridad TEXT NOT NULL,
                Estado TEXT NOT NULL
            );
            """;
        command.ExecuteNonQuery();
    }
}
