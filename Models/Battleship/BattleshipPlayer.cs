namespace BearsDenGames.Models.Battleship;

public class BattleshipPlayer
{
    public BattleshipPlayer(Player player)
    {
        Player = player;
    }

    public Player Player { get; }
    public Ships Ships { get; set; } = new();
    public BattleshipGameBoard? BattleshipGameBoard { get; private set; }

    public void Reset()
    {
        Ships = new();
        BattleshipGameBoard = new(Ships.FleetCells);
    }

    public void ReadyBoard()
    {
        BattleshipGameBoard = new(Ships.FleetCells);
    }

    public void ClearGame()
    {
        Player.ClearGame();
    }
}