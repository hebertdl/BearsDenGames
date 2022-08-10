namespace BearsDenGames.Models.Battleship;

public class BattleshipPlayer : IPlayer
{
    public BattleshipPlayer(IPlayer player)
    {
        Player = player;
    }

    private IPlayer Player { get; }
    public Ships Ships { get; private set; } = new();
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

    public string? PlayerName
    {
        get => Player.PlayerName;
        set => Player.PlayerName = value;
    }

    public CurrentGame? CurrentGame
    {
        get => Player.CurrentGame;
        set => Player.CurrentGame = value;
    }

    public void ClearGame()
    {
        Player.ClearGame();
    }
}