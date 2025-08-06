using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string connectionString = @"Server=localhost; DataBase = TP06_schnaider;Integrated Security = True;TrustServerCertificate=True;";

    public static Usuario Login(string username, string password)
    {
        Usuario usuario;
        string passwordEncriptada = Encriptador.Encriptar(password);
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE nombre = @nombre AND password = @password";
            usuario = db.QueryFirstOrDefault<Usuario>(query, new { nombre = username, password = passwordEncriptada });
            ActualizarLogin(usuario.idUsuario);
            return usuario;
        }
            
    }

    public static void Registrar(Usuario nuevo)
    {
        nuevo.password = Encriptador.Encriptar(nuevo.password);
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string insert = "INSERT INTO Usuarios (nombre, apellido, foto, username, ultimoLogin, password) VALUES (@pnombre, @papellido, @pfoto, @pusername, @pultimoLogin, @ppassword)";
            db.Execute(insert, new { pnombre = nuevo.nombre, ppassword = nuevo.password, papellido = nuevo.apellido, pfoto = nuevo.foto, pusername = nuevo.username, pultimoLogin = nuevo.ultimoLogin});
        }
    }
     public static List<Tarea> DevolverTareas(int idUsuario)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE idUsuario = @id AND finalizada = 0";
            return db.Query<Tarea>(query, new { id = idUsuario }).ToList();
        }
    }

    public static Tarea DevolverTarea(int idTarea)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE idTarea = @id";
            return db.QueryFirstOrDefault<Tarea>(query, new { id = idTarea });
        }
    }

    public static void ModificarTarea(Tarea tarea)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, fecha = @fecha WHERE idTarea = @id";
            db.Execute(query, new { titulo = tarea.titulo, descripcion = tarea.descripcion, fecha = tarea.fecha, id = tarea.idTarea });
        }
    }

    public static void EliminarTarea(int idTarea)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Tareas WHERE idTarea = @id";
            db.Execute(query, new { id = idTarea });
        }
    }

    public static void CrearTarea(Tarea tarea)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Tareas (titulo, descripcion, fecha, finalizada, idUsuario) VALUES (@titulo, @descripcion, @fecha, 0, @idUsuario)";
            db.Execute(query, new { tarea.titulo, tarea.descripcion, tarea.fecha, tarea.idUsuario });
        }
    }

    public static void FinalizarTarea(int idTarea)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "UPDATE Tareas SET finalizada = 1 WHERE idTarea = @id";
            db.Execute(query, new { id = idTarea });
        }
    }

    public static void ActualizarLogin(int idUsuario)
    {
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "UPDATE Usuarios SET ultimoLogin = GETDATE() WHERE idUsuario = @id";
            db.Execute(query, new { id = idUsuario });
        }
    }

}