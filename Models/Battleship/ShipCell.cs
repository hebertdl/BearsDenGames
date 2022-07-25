namespace BearsDenGames.Models.Battleship;

public class ShipCell
{
    public ShipCell(int shipLoc, bool isStern, Direction direction)
    {
        ShipLoc = shipLoc;
        IsStern = isStern;
        Direction = direction;
    }

    public int ShipLoc { get; }
    public bool IsStern { get; }
    public Direction Direction { get; }

}