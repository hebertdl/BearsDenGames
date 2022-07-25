using System.Text;

namespace BearsDenGames.Models.Battleship;

public class BoardCell
{
    public readonly int Col;
    public readonly int Row;

    public BoardCell(int col, int row, ShipCell? shipCell)
    {
        Col = col;
        Row = row;
        ShipCell = shipCell;
    }

    public bool Active { get; set; } = true;
    private ShipCell? ShipCell { get; }

    public string ShipCellStyle(bool isOpponent)
    {
        if (ShipCell == null || isOpponent) return "";
        var sbRtn = new StringBuilder();
        if (ShipCell.ShipLoc == 0)
            sbRtn.Append(" BsShipBow-" + ShipCell.Direction);
        else if (ShipCell.IsStern)
            sbRtn.Append(" BsShipStern-" + ShipCell.Direction);
        else
            sbRtn.Append(" BsShipCell");
        return sbRtn.ToString();
    }
    public string CellStyle()
    {
        var sbRtn = new StringBuilder();
        if (ShipCell == null)
            sbRtn.Append(Active ? "  " : " BsCellCircle BsCellMiss ");
        else
            sbRtn.Append(Active ? " " : " BsCellCircle BsCellHit ");

        return sbRtn.ToString();
    }
}