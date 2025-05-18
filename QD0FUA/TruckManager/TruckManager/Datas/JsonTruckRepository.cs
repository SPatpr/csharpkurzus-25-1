using System.Text.Json;

using TruckManager.Models;

public class JsonTruckRepository : ITruckRepository
{
    public async Task<List<Truck>> LoadAsync(string path)
    {
        try
        {
            using var stream = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<List<Truck>>(stream)
                   ?? new List<Truck>();
        }
        catch (Exception ex)
        {
            ExceptionHandler.Handle(ex);
            return new List<Truck>();
        }
    }

    public async Task SaveAsync(string path, List<Truck> trucks)
    {
        try
        {
            using var stream = File.Create(path);
            await JsonSerializer.SerializeAsync(stream, trucks, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            ExceptionHandler.Handle(ex);
        }
    }
}