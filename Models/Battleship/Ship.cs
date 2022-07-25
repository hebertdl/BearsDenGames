namespace BearsDenGames.Models.Battleship;

public class Ship
{
    public Ship(int length)
    {
        Length = length;
    }

    public List<BoardCell> ShipCells { get; private set; } = new();
    private int Length { get; }

    public bool SetPosition(int startCol, int startRow, Direction direction,
        Dictionary<Tuple<int, int>, BoardCell> fleetCells)
    {
        ShipCells = new();

        for (var mod = 0; mod < Length; mod++)
        {
            int col;
            int row;
            switch (direction)
            {
                case Direction.North:
                {
                    col = startCol;
                    row = startRow + mod;
                    break;
                }
                case Direction.East:
                {
                    col = startCol - mod;
                    row = startRow;
                    break;
                }
                case Direction.South:
                {
                    col = startCol;
                    row = startRow - mod;
                    break;
                }
                case Direction.West:
                {
                    col = startCol + mod;
                    row = startRow;
                    break;
                }
                default:
                    return false;
            }

            if (IsInvalid(col, row))
                return false;
            if (fleetCells.ContainsKey(new Tuple<int, int>(col, row)))
                return false;
            var cell = new BoardCell(col, row,
                new ShipCell(mod, mod == Length - 1, direction));
            ShipCells.Add(cell);
        }

        return true;
    }


    private static bool IsInvalid(int col, int row)
    {
        return col is > 9 or < 0 || row is > 9 or < 0;
    }
}