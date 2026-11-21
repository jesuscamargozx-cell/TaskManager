namespace TaskManager.Models;

public class Tarea
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Prioridad { get; set; } = "Media";
    public string Estado { get; set; } = "Pendiente";

    public override string ToString()
        => $"#{Id}  {Nombre}  |  Prioridad: {Prioridad}  |  Estado: {Estado}";
}
