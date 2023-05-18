using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities;
public class LastLoggedReport
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime LastLogged { get; set; }
}
