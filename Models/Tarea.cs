using System.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
public class Tarea{
    [JsonProperty]
    public int idTarea {get; set;}
    [JsonProperty]
    public string titulo {get; set;}
    [JsonProperty]
    public string descripcion {get; set;}
    [JsonProperty]
    public DateTime fecha {get; set;}
    [JsonProperty]
    public bool finalizada {get; set;}
    [JsonProperty]
    public int idUsuario {get; set;}
    
    public Tarea(){}
    }
