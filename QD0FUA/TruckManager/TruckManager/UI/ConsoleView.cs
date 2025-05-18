using System;
using System.Collections.Generic;

using TruckManager.Models;



public static class ConsoleView
{
    public static void ShowError(string message)
    {
        Console.Error.WriteLine($"{message}");
    }

    public static void ShowTrucks(IEnumerable<Truck> trucks)
    {
        Console.WriteLine("=== Kamionok listája ===");
        foreach (var truck in trucks)
        {
            Console.WriteLine(truck.ToString());
        }
    }
}
