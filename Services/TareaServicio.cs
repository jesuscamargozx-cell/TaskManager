using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Services;

public class TareaServicio
{
    private readonly TareaDAO _dao = new();

    public void Crear(Tarea tarea)
    {
        Validar(tarea);
        _dao.Crear(tarea);
    }

    public List<Tarea> Listar() => _dao.Listar();

    public void Actualizar(Tarea tarea)
    {
        if (tarea.Id <= 0)
            throw new ArgumentException("El identificador de la tarea no es válido.");
        Validar(tarea);
        _dao.Actualizar(tarea);
    }

    public void Eliminar(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Selecciona una tarea válida.");
        _dao.Eliminar(id);
    }

    private static void Validar(Tarea tarea)
    {
        if (string.IsNullOrWhiteSpace(tarea.Nombre))
            throw new ArgumentException("El nombre de la tarea es obligatorio.");
        if (tarea.Nombre.Length > 100)
            throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
        if (tarea.Descripcion.Length > 1000)
            throw new ArgumentException("La descripción no puede superar los 1000 caracteres.");
        if (tarea.Prioridad is not ("Baja" or "Media" or "Alta"))
            throw new ArgumentException("Selecciona una prioridad válida.");
        if (tarea.Estado is not ("Pendiente" or "En progreso" or "Completada"))
            throw new ArgumentException("Selecciona un estado válido.");
    }
}
