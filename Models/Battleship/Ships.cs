namespace BearsDenGames.Models.Battleship;

public class Ships
{
    public  readonly Ship Battleship = new(4);
    public readonly Ship Carrier = new(5);
    public readonly Ship Destroyer = new(3);
    public readonly Ship PatrolBoat = new(2);
    public readonly Ship Submarine = new(3);

    public Ships()
    {
        Randomize();
    }

    public Dictionary<Tuple<int, int>, BoardCell> FleetCells { get; private set; } = new();

    public string GetBoardCellStyle(int col, int row, bool isOpponent, GameState gameState)
    {
        return FleetCells.ContainsKey(new Tuple<int, int>(col, row))
            ? FleetCells[new Tuple<int, int>(col, row)].ShipCellStyle(isOpponent, gameState)
            : " BsWaterCell ";
    }

    public int RemainingHits => FleetCells.Count(cell => cell.Value.Active);

    public void Randomize()
    {
        FleetCells = new();
        SetPosition(Carrier);
        SetPosition(Battleship);
        SetPosition(Destroyer);
        SetPosition(Submarine);
        SetPosition(PatrolBoat);
    }

    private void SetPosition(Ship ship)
    {
        var rnd = new Random();
        var isValid = false;
        while (!isValid)
        {
            var col = rnd.Next(10);
            var row = rnd.Next(10);
            var direction = rnd.Next(4);
            isValid = ship.SetPosition(col, row, (Direction)direction, FleetCells);
        }

        CopyPosition(ship);
    }

    private void CopyPosition(Ship ship)
    {
        foreach (var shipCell in ship.ShipCells)
            FleetCells.Add(new Tuple<int, int>(shipCell.Col, shipCell.Row), shipCell);
    }
}