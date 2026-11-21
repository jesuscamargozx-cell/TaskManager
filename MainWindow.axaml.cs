using Avalonia.Controls;
using Avalonia.Interactivity;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager;

public partial class MainWindow : Window
{
    private readonly TareaServicio _servicio = new();
    private Tarea? _seleccionada;
    private bool _cargandoLista;

    public MainWindow()
    {
        InitializeComponent();
        CargarTareas();
    }

    private void CargarTareas()
    {
        try
        {
            _cargandoLista = true;
            TareasList.ItemsSource = _servicio.Listar();
            _cargandoLista = false;
        }
        catch (Exception ex)
        {
            _cargandoLista = false;
            MostrarMensaje($"No fue posible cargar las tareas: {ex.Message}");
        }
    }

    private Tarea CrearTareaDesdeFormulario()
    {
        string nombre = NombreBox.Text?.Trim() ?? string.Empty;
        string descripcion = DescripcionBox.Text?.Trim() ?? string.Empty;

        string prioridad = (PrioridadBox.SelectedItem as ComboBoxItem)?.Content?.ToString()
                           ?? "Media";
        string estado = (EstadoBox.SelectedItem as ComboBoxItem)?.Content?.ToString()
                        ?? "Pendiente";

        return new Tarea
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Prioridad = prioridad,
            Estado = estado
        };
    }

    private void Guardar_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            var tarea = CrearTareaDesdeFormulario();
            _servicio.Crear(tarea);
            CargarTareas();
            LimpiarFormulario();
            MostrarMensaje("Tarea guardada correctamente.");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void Actualizar_Click(object? sender, RoutedEventArgs e)
    {
        if (_seleccionada is null)
        {
            MostrarMensaje("Selecciona una tarea de la lista antes de actualizar.");
            return;
        }

        try
        {
            var tarea = CrearTareaDesdeFormulario();
            tarea.Id = _seleccionada.Id;
            _servicio.Actualizar(tarea);
            CargarTareas();
            LimpiarFormulario();
            MostrarMensaje("Tarea actualizada correctamente.");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void Eliminar_Click(object? sender, RoutedEventArgs e)
    {
        if (_seleccionada is null)
        {
            MostrarMensaje("Selecciona una tarea de la lista antes de eliminar.");
            return;
        }

        try
        {
            _servicio.Eliminar(_seleccionada.Id);
            CargarTareas();
            LimpiarFormulario();
            MostrarMensaje("Tarea eliminada correctamente.");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void Limpiar_Click(object? sender, RoutedEventArgs e)
    {
        LimpiarFormulario();
        MostrarMensaje("Formulario limpio.");
    }

    private void Recargar_Click(object? sender, RoutedEventArgs e)
    {
        CargarTareas();
        MostrarMensaje("Lista actualizada.");
    }

    private void TareasList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_cargandoLista || TareasList.SelectedItem is not Tarea tarea)
            return;

        _seleccionada = tarea;
        NombreBox.Text = tarea.Nombre;
        DescripcionBox.Text = tarea.Descripcion;
        PrioridadBox.SelectedIndex = tarea.Prioridad switch
        {
            "Baja" => 0,
            "Media" => 1,
            "Alta" => 2,
            _ => 1
        };
        EstadoBox.SelectedIndex = tarea.Estado switch
        {
            "Pendiente" => 0,
            "En progreso" => 1,
            "Completada" => 2,
            _ => 0
        };
        MostrarMensaje($"Tarea seleccionada: {tarea.Nombre}");
    }

    private void LimpiarFormulario()
    {
        _seleccionada = null;
        TareasList.SelectedItem = null;
        NombreBox.Text = string.Empty;
        DescripcionBox.Text = string.Empty;
        PrioridadBox.SelectedIndex = 1;
        EstadoBox.SelectedIndex = 0;
    }

    private void MostrarMensaje(string mensaje)
    {
        MensajeText.Text = mensaje;
    }
}
