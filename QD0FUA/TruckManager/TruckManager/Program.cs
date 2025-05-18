using System.Threading.Tasks;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TruckManager.Models;

class Program
{

    
    static async Task Main()
    {
        ITruckRepository repo = new JsonTruckRepository();
        TruckService truckservice = new TruckService();
        JsonService jsonService = new JsonService(repo, truckservice);


        

        await jsonService.LoadAndAddAllAsync("Data/trucks.json");
        Console.WriteLine("[DEBUG] Betöltött kamionok száma: " + truckservice.GetAll().Count());

        bool exit = false;

        while (!exit) { 
        ConsoleMenu.ShowMain();
        switch (Console.ReadLine())
        {
            case "1":

                Truck truck = new Truck();
                 

                while (true)
                {
                    Console.Write("Add meg a rendszámot (AAA-111): ");
                    string pn = Console.ReadLine() ?? "";


                        truck.SetPlateNumber(pn);
                        if (!string.IsNullOrEmpty(truck.PlateNumber)) break;
                }
                

                Console.Write("Hány gumit szeretnél hozzáadni? (min 6): ");
                if (!int.TryParse(Console.ReadLine(), out int count) || count <= 5)
                {
                    Console.Error.WriteLine("Érvénytelen darabszám.");
                    break;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Gumi {i + 1}");
                    bool valid = false;
                    while (!valid)
                    {
                        Console.Write("  Nyomás (bar): ");
                        if (!double.TryParse(Console.ReadLine(), out double bar))
                        {
                            Console.Error.WriteLine("Hibás számformátum a nyomásnál, próbáld újra!");
                            continue;
                        }

                        Console.Write("Profilmélység (mm): ");
                        if (!double.TryParse(Console.ReadLine(), out double depth))
                        {
                            Console.Error.WriteLine("Hibás számformátum a profilmélységnél, próbáld újra!");
                            continue;
                        }

                        try
                        {
                            truck.AddTire(new Tire(bar, depth));
                            valid = true;
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.Error.WriteLine($"{ex.Message}");
                        }
                    }
                }

                truckservice.TruckAdd(truck);
                Console.WriteLine("Kamion sikeresen hozzáadva!");
                break;
            case "2":
                    Console.WriteLine("2");
                ConsoleView.ShowTrucks(truckservice.GetAll());
                break;
            case "3":
                    Console.WriteLine("Full path: " + Path.GetFullPath("Data/trucks.json"));
                    //await repo.SaveAsync("QD0FUA/TruckManager/TruckManager/Datas/trucks.json", truckservice.GetAll().ToList());
                    try
                    {
                        await repo.SaveAsync("Data/trucks.json", new List<Truck>(truckservice.GetAll()));
                        Console.WriteLine("Adatok elmentve!");
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                        ConsoleView.ShowError(ex.Message);
                    }
                    break;
                default:
                Console.WriteLine("Hibás opció");
                break;
        }
    }
    }
}