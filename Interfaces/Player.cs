namespace BearsDenGames.Models;

public interface IPlayer
{
   public string? PlayerName { get; set; }
    public CurrentGame? CurrentGame { get; set; }
    public void ClearGame();
}