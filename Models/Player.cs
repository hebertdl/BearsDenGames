namespace BearsDenGames.Models;

public class Player
{
    public Player(string? playerName)
    {
        PlayerName = playerName;
    }

    public string? PlayerName { get; }

    public CurrentGame? CurrentGame { get; set; }

    public void ClearGame()
    {
        CurrentGame = null;
    }
}