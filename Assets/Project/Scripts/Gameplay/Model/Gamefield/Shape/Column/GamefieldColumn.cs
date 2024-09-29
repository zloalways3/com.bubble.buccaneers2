public readonly struct GamefieldColumn
{
    public readonly int MinY;
    public readonly int MaxY;

    public GamefieldColumn(int min, int max)
    {
        MinY = min;
        MaxY = max;
    }
}