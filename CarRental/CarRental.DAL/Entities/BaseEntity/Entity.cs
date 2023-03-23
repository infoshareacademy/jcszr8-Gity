﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.DAL.Entities.BaseEntity;

public class Entity
{
    [JsonProperty("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
}