public record class Tire
{
    public double Bar { get; init; }
    public double Depth { get; init; }

    public Tire(double bar, double depth)
    {
        if (bar <= 0 || bar >= 10)
            throw new ArgumentOutOfRangeException(nameof(bar),
                "Helytelen guminyomás: a bar értéke nagyobb kell legyen 0-nál és kisebb 10-nél.");
        if (depth <= 1.6 || depth >= 9)
            throw new ArgumentOutOfRangeException(nameof(depth),
                "Helytelen profilmélység: 1.6 és 9 közötti érték kell.");

        Bar = bar;
        Depth = depth;
    }
}