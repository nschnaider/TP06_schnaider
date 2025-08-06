using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string connectionString = @"Server=localhost; DataBase = TP06_schnaider;Integrated Security = True;TrustServerCertificate=True;";

    public static Usuario Login(string username, string password)
    {
        string passwordEncriptada = Encriptador.Encriptar(password);
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE nombre = @nombre AND password = @password";
            return db.QueryFirstOrDefault<Usuario>(query, new { nombre = username, password = passwordEncriptada });
        }
    }

    public static void Registrar(Integrante nuevo)
    {
        nuevo.Password = Encriptador.Encriptar(nuevo.Password);
        using (SqlConnection db = new SqlConnection(connectionString))
        {
            string insert = "INSERT INTO Integrantes (Nombre, Password, Edad, Fecha, Tiempo, Direccion, Telefono) VALUES (@pNombre, @pPassword, @pEdad, @pFecha, @pTiempo, @pDireccion, @pTelefono)";
            db.Execute(insert, new { pNombre = nuevo.Nombre, pPassword = nuevo.Password, pEdad = nuevo.Edad, pFecha = nuevo.Fecha, pTiempo = nuevo.Tiempo, pDireccion = nuevo.Direccion, pTelefono = nuevo.Telefono });
        }
    }
}