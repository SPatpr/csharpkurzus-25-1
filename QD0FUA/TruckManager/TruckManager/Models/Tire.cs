public record class Tire
{
    public double Bar { get; init; }
    public double Depth { get; init; }

    public Tire(double bar, double depth)
    {
        if (bar <= 0 || bar >= 10)
            throw new ArgumentOutOfRangeException(nameof(bar),
                "Helytelen guminyom�s: a bar �rt�ke nagyobb kell legyen 0-n�l �s kisebb 10-n�l.");
        if (depth <= 1.6 || depth >= 9)
            throw new ArgumentOutOfRangeException(nameof(depth),
                "Helytelen profilm�lys�g: 1.6 �s 9 k�z�tti �rt�k kell.");

        Bar = bar;
        Depth = depth;
    }
}