public static class Level
{
    public const int MaxValue = 15;

    private static int _value;

    public static int Value => _value;

    public static bool TrySet(int value)
    {
        if (value <= 0) return false;

        _value = value;

        return true;
    }

    public static bool TryNext()
    {
        if (_value >= MaxValue) return false;

        _value++;

        return true;
    }
}