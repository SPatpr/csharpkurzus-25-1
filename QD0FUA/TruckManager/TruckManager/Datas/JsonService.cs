using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public record class JsonService(ITruckRepository repository, TruckService truckService)
{
    public readonly ITruckRepository repository = repository;
    public readonly TruckService truckService = truckService;

    public async Task LoadAndAddAllAsync(string filePath)
    {
        try
        {
            var loadedTrucks = await repository.LoadAsync(filePath);

            foreach (var truck in loadedTrucks)
            {
                truckService.TruckAdd(truck);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Hiba a kamionok betöltésekor: {ex.Message}");
        }
    }
}
