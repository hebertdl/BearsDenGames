namespace BearsDenGames.Services;

public interface IGameServer<TGame>
{
    public void AddGame(TGame game);
    public TGame? GetGame(string gameName);
    public IEnumerable<TGame> AvailableGames();
    public void DoPurge();
}