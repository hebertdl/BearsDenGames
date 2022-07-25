namespace BearsDenGames.Interfaces;

public abstract class GameArea
{
    private readonly LabelType _colLabelType;
    private readonly LabelType _rowLabelType;
    private readonly Tuple<int, int> _size;

    protected GameArea(LabelType colLabelType, LabelType rowLabelType, Tuple<int, int> size)
    {
        _colLabelType = colLabelType;
        _rowLabelType = rowLabelType;
        _size = size;
    }

    public int ColCount => _size.Item1;
    public int RowCount => _size.Item2;

    public string ColLabel(int col)
    {
        return _colLabelType == LabelType.Letters ? ((char)('A' + col)).ToString() : col.ToString();
    }

    public string RowLabel(int row)
    {
        return _rowLabelType == LabelType.Letters ? ((char)('A' + row)).ToString() : (row + 1).ToString();
    }

    protected enum LabelType
    {
        Letters,
        Numbers
    }
}