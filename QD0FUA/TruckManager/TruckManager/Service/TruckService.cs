
using TruckManager.Models;

public class TruckService
{
    private readonly List<Truck> trucks = new();
    
    public TruckService()
    {

    }

    public void TruckAdd(Truck truck)
    {
        trucks.Add(truck);
    }

    public IEnumerable<Truck> GetAll() => trucks;

}