namespace CarRental.Logic.Services.IServices;

public interface IAddonService
{
    List<string> GetAddonsAsList(string addons);
    string GetAddonsAsString(List<string> addons);
}
