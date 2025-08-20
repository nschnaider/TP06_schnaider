using System.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
public class Usuario{
    [JsonProperty]
    public int idUsuario {get; set;}
    [JsonProperty]
    public string nombre {get; set;}
    [JsonProperty]
    public string apellido {get; set;}
    [JsonProperty]
    public string foto {get; set;}
    [JsonProperty]
    public string username {get; set;}
    [JsonProperty]
    public DateTime ultimoLogin {get; set;}
    [JsonProperty]
    public string password {get; set;}
    
    public Usuario(){}
    public Usuario(string nombre, string apellido, string foto, string username, string password){
        this.nombre = nombre;
        this.apellido = apellido;
        this.foto = foto;
        this.username = username;
        this.password = password;
     }
    }
     
    
