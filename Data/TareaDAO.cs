using Microsoft.Data.Sqlite;
using TaskManager.Models;

namespace TaskManager.Data;

public class TareaDAO
{
    public void Crear(Tarea tarea)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = """
            INSERT INTO Tareas (Nombre, Descripcion, Prioridad, Estado)
            VALUES ($nombre, $descripcion, $prioridad, $estado);
            """;
        command.Parameters.AddWithValue("$nombre", tarea.Nombre);
        command.Parameters.AddWithValue("$descripcion", tarea.Descripcion);
        command.Parameters.AddWithValue("$prioridad", tarea.Prioridad);
        command.Parameters.AddWithValue("$estado", tarea.Estado);
        command.ExecuteNonQuery();
    }

    public List<Tarea> Listar()
    {
        var tareas = new List<Tarea>();
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = """
            SELECT Id, Nombre, Descripcion, Prioridad, Estado
            FROM Tareas
            ORDER BY Id DESC;
            """;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            tareas.Add(new Tarea
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Descripcion = reader.GetString(2),
                Prioridad = reader.GetString(3),
                Estado = reader.GetString(4)
            });
        }
        return tareas;
    }

    public void Actualizar(Tarea tarea)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = """
            UPDATE Tareas
            SET Nombre = $nombre, Descripcion = $descripcion,
                Prioridad = $prioridad, Estado = $estado
            WHERE Id = $id;
            """;
        command.Parameters.AddWithValue("$nombre", tarea.Nombre);
        command.Parameters.AddWithValue("$descripcion", tarea.Descripcion);
        command.Parameters.AddWithValue("$prioridad", tarea.Prioridad);
        command.Parameters.AddWithValue("$estado", tarea.Estado);
        command.Parameters.AddWithValue("$id", tarea.Id);
        if (command.ExecuteNonQuery() == 0)
            throw new InvalidOperationException("La tarea que intentas actualizar ya no existe.");
    }

    public void Eliminar(int id)
    {
        using var connection = new SqliteConnection(Database.ConnectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Tareas WHERE Id = $id;";
        command.Parameters.AddWithValue("$id", id);
        if (command.ExecuteNonQuery() == 0)
            throw new InvalidOperationException("La tarea que intentas eliminar ya no existe.");
    }
}
