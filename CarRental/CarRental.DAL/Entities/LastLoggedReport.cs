using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Entities;
public class LastLoggedReport : Entity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime LastLogged { get; set; }
}
