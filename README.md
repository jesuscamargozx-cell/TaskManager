

# TaskManager – Gestor de Tareas

## 1. Descripción del proyecto

TaskManager es una aplicación de escritorio desarrollada en C# que permite administrar tareas de manera sencilla. El programa permite registrar, consultar, actualizar y eliminar tareas, almacenando la información en una base de datos SQLite.

Este proyecto fue desarrollado como parte del parcial final, aplicando los conocimientos de programación orientada a objetos, interfaces gráficas, acceso a bases de datos y organización del código.

## 2. Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET 8
- **Interfaz gráfica:** Avalonia UI y XAML
- **Base de datos:** SQLite
- **Acceso a datos:** ADO.NET mediante Microsoft.Data.Sqlite
- **Entorno de desarrollo:** Visual Studio Code / Visual Studio

## 3. Funcionalidades principales

La aplicación cuenta con las siguientes funcionalidades:

- Registrar nuevas tareas.
- Consultar y visualizar las tareas registradas.
- Actualizar la información de una tarea.
- Eliminar tareas.
- Asignar prioridades: Baja, Media y Alta.
- Asignar estados: Pendiente, En progreso y Completada.
- Validar que el nombre de la tarea no esté vacío.
- Guardar la información permanentemente en SQLite.
- Recuperar las tareas guardadas al iniciar nuevamente el programa.

## 4. Estructura del proyecto

```text
TaskManager/
│
├── Data/
│   ├── Database.cs
│   └── TareaDAO.cs
│
├── Models/
│   └── Tarea.cs
│
├── Services/
│   └── TareaServicio.cs
│
├── evidencias/
│   ├── 01-aplicacion-abierta.png
│   ├── 02-crear-tarea.png
│   ├── 03-actualizar-tarea.png
│   ├── 04-eliminar-tarea.png
│   └── 05-persistencia.png
│
├── App.axaml
├── App.axaml.cs
├── MainWindow.axaml
├── MainWindow.axaml.cs
├── Program.cs
├── TaskManager.csproj
├── app.manifest
├── .gitignore
└── README.md
```

## 5. Descripción de las carpetas

- **Models:** contiene la clase Tarea, que representa la información de cada tarea.
- **Data:** contiene la configuración de la base de datos y las operaciones para guardar, consultar, actualizar y eliminar registros.
- **Services:** contiene la lógica del programa y las validaciones de los datos.
- **evidencias:** contiene las capturas de pantalla que demuestran el funcionamiento de la aplicación.

## 6. Base de datos

El proyecto utiliza SQLite para almacenar la información de las tareas.

La base de datos se crea automáticamente cuando se inicia la aplicación.

**Nombre de la base de datos:** `taskmanager.db`

**Tabla:** `Tareas`

| Campo | Tipo | Descripción |
|---|---|---|
| Id | INTEGER | Identificador único |
| Nombre | TEXT | Nombre de la tarea |
| Descripcion | TEXT
=======
# TaskManager
gestor de tareas

