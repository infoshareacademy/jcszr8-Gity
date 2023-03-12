using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.ViewComponents
{
    public class ButtonComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string text, string color)
        {
            var model = new ButtonModel
            {
                Text = text,
                Color = color
            };

            return View(model);
        }
    }

    public class ButtonModel
    {
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
