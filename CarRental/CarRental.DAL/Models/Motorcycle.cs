namespace CarRental.DAL.Models;
public sealed class Motorcycle : Vehicle
{
    public int WeightInKg;

    public override string ToString()
    {
        return base.ToString();
    }
}
