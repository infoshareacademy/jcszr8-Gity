using CarRental.DAL;
using CarRental.DAL.Models;
using System.Text;

namespace CarRental.Logic;

public class RentalManager
{
    private static int _idCounter = CarRentalData.Rentals.Max(r => r.Id);

    private static List<Rental> _rentals = CarRentalData.Rentals;

    public static Rental GetById(int rentalId)
    {
        return _rentals.FirstOrDefault(r => r.Id == rentalId);
    }

    private static int GetNextId()
    {
        return ++_idCounter;
    }
    public static List<Rental> GetAll()
    {
        return _rentals;
    }
    public static string RentalsToTableString()
    {
        StringBuilder sb = new();
        sb.Append(String.Format("\n{0,4}.| {1,-20}| {2,-25}| {3,-10}\n", "Id", "Make", "Model", "License plate"));
        sb.Append(new String('-', sb.Length));
        sb.Append('\n');
        foreach (var rental in _rentals)
        {
            sb.Append($"{rental.Id,4}.| {rental.BeginDate,-20}| {rental.BeginDate,-25}| {rental.CarId,-10}{Environment.NewLine}");
        }
        return sb.ToString();
    }
}   
