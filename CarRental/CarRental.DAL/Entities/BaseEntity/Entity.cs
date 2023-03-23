using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.DAL.Entities.BaseEntity;

public class Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonProperty("id")]
    public int Id { get; set; }
}
