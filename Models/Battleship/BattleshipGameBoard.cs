using BearsDenGames.Interfaces;

namespace BearsDenGames.Models.Battleship;

public class BattleshipGameBoard : GameArea
{
    public BattleshipGameBoard() : base(LabelType.Letters, LabelType.Numbers, new(10, 10))
    {
        for (var row = 0; row < 10; row++)
        for (var col = 0; col < 10; col++)
            GameBoardCells.Add(new Tuple<int, int>(col, row), new BoardCell(col, row, null));
    }

    public BattleshipGameBoard(IReadOnlyDictionary<Tuple<int, int>, BoardCell> fleetCells) : base(LabelType.Letters,
        LabelType.Numbers, new(10, 10))
    {
        for (var row = 0; row < 10; row++)
        for (var col = 0; col < 10; col++)
            GameBoardCells.Add(new Tuple<int, int>(col, row), GetCell(col, row, fleetCells));
    }

    private Dictionary<Tuple<int, int>, BoardCell> GameBoardCells { get; } = new();

    private static BoardCell GetCell(int col, int row, IReadOnlyDictionary<Tuple<int, int>, BoardCell> fleetCells)
    {
        return fleetCells.ContainsKey(new Tuple<int, int>(col, row))
            ? fleetCells[new Tuple<int, int>(col, row)]
            : new BoardCell(col, row, null);
    }

    public BoardCell? GetCell(int col, int row)
    {
        if (col is < 0 or > 9 || row is < 0 or > 9) return null;
        return GameBoardCells[new Tuple<int, int>(col, row)];
    }
}