namespace BearsDenGames.Models;

public interface IPlayer
{
   public string? PlayerName { get; }
    public CurrentGame? CurrentGame { get; set; }
    public void ClearGame();
}