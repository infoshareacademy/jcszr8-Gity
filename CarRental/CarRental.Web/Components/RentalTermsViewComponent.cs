using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Components;

public class RentalTermsViewComponent : ViewComponent
{
    private readonly IRentalService _rentalService;

    public RentalTermsViewComponent(IRentalService rentalService)
    {
        _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
    }

    public IViewComponentResult Invoke(int Id)
    {
        var model = new List<Term>();

        var rentalsOfCar = _rentalService.GetRentalsByCarId(Id)
            .OrderBy(c => c.BeginDate).ToList();

        foreach (var rental in rentalsOfCar)
        {
            model.Add(new Term
            {
                DateFrom = rental.BeginDate.ToString("yyyy-MM-dd HH:mm"),
                DateTo = rental.EndDate.ToString("yyyy-MM-dd HH:mm"),
            });
        }
        return View(model);
    }
}
