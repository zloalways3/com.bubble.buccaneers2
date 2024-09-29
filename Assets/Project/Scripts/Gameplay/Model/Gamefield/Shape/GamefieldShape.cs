using System.Collections.Generic;

public readonly struct GamefieldShape
{
    private readonly List<GamefieldColumn> _columns;

    public int MinX => 0;
    public int MaxX => _columns.Count;

    public GamefieldShape(IEnumerable<GamefieldColumn> columns)
    {
        _columns = new List<GamefieldColumn>(columns);
    }

    public GamefieldColumn GetByIndex(int index)
    {
        return _columns[index];
    }
}