using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace TruckManager.Models
{
    public class Truck
    {
        public string PlateNumber { get; set; } = string.Empty;
        public List<Tire> Tires { get; set; } = new();

        public void SetPlateNumber(string num)
        {
            if (!Regex.IsMatch(num, @"^[A-Za-z]{3}-\d{3}$"))
            {
                ConsoleView.ShowError("Hibás formátum: három betû, kötõjel és három szám (pl. ABC-123).");
                return;
            }
            PlateNumber = num.ToUpper();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Rendszám: {PlateNumber}");
            for (int i = 0; i < Tires.Count; i++)
            {
                var t = Tires[i];
                sb.AppendLine($"  Gumi {i + 1}: {t.Bar} bar, {t.Depth} mm");
            }
            return sb.ToString();
        }

        public void AddTire(Tire tire) => Tires.Add(tire);
    }
}
