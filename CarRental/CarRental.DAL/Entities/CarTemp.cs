using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Entities;
public class CarTemp : Entity
{
    public CarTemp()
    {
    }
    public string CarMake { get; set; }
    public string Addons { get; set; }
}
