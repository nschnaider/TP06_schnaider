using System.Security.Cryptography;
using System.Text;

public static class Encriptador
{
   public static string Encriptar(string texto)
{
    if (string.IsNullOrEmpty(texto))
        throw new ArgumentException("No se puede encriptar una cadena vacía o nula.");

    using (SHA256 sha = SHA256.Create())
    {
        byte[] bytes = Encoding.UTF8.GetBytes(texto);
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
}
