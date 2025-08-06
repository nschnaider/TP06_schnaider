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
    }
