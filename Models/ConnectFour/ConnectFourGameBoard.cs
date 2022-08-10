using BearsDenGames.Interfaces;
using BearsDenGames.Models.Battleship;

namespace BearsDenGames.Models.ConnectFour;

public class ConnectFourGameBoard : GameArea
{
    public ConnectFourGameBoard() : base(LabelType.Letters, LabelType.Numbers, new(7, 6))
    {
        for (var row = 0; row < 6; row++)
        for (var col = 0; col < 7; col++)
            GameBoardCells.Add(new Tuple<int, int>(col, row), new BoardCell(col, row, null));
    }

    public ConnectFourGameBoard(IReadOnlyDictionary<Tuple<int, int>, BoardCell> fleetCells) : base(LabelType.Letters,
        LabelType.Numbers, new(7, 6))
    {
        for (var row = 0; row < 7; row++)
        for (var col = 0; col < 6; col++)
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
        if (col is < 0 or > 7 || row is < 0 or > 6) return null;
        return GameBoardCells[new Tuple<int, int>(col, row)];
    }
}