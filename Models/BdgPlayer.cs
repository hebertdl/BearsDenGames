namespace BearsDenGames.Models;

public class BdgPlayer: IPlayer
{
    public BdgPlayer(string playerName)
    {
        PlayerName = playerName.Trim();
    }

    public string? PlayerName { get; set; }
    public CurrentGame? CurrentGame { get; set; }
    public void ClearGame()
    {
    }
}