using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BearsDenGames.Models.Battleship;

public class Ships
{
    private readonly Ship _battleship = new(4);
    private readonly Ship _carrier = new(5);
    private readonly Ship _destroyer = new(3);
    private readonly Ship _patrolBoat = new(2);
    private readonly Ship _submarine = new(3);

    public Ships()
    {
        Randomize();
    }

    public Dictionary<Tuple<int, int>, BoardCell> FleetCells { get; private set; } = new();

    public string GetBoardCellStyle(int col, int row, bool isOpponent)
    {
        return FleetCells.ContainsKey(new Tuple<int, int>(col, row))
            ? FleetCells[new Tuple<int, int>(col, row)].ShipCellStyle(isOpponent)
            : " BsWaterCell ";
    }

    public int RemainingHits => FleetCells.Count(cell => cell.Value.Active);

    public void Randomize()
    {
        FleetCells = new();
        SetPosition(_carrier);
        SetPosition(_battleship);
        SetPosition(_destroyer);
        SetPosition(_submarine);
        SetPosition(_patrolBoat);
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