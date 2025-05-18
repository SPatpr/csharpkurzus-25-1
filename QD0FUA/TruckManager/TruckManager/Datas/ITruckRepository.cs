using TruckManager.Models;

public interface ITruckRepository
{
    Task<List<Truck>> LoadAsync(string path);
    Task SaveAsync(string path, List<Truck> trucks);
}