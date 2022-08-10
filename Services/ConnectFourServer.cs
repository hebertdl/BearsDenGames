using BearsDenGames.Interfaces;
using BearsDenGames.Models;
using BearsDenGames.Models.ConnectFour;

namespace BearsDenGames.Services;

public class ConnectFourServer: IGameServer<ConnectFourGame>
{
    private Dictionary<string, ConnectFourGame> GameInstances { get; } = new();

    public ConnectFourGame? GetGame(string gameName)
    {
        return GameInstances.ContainsKey(gameName) ? GameInstances[gameName] : null;
    }

    public IEnumerable<ConnectFourGame> AvailableGames()
    {
        return GameInstances.Select(item => item.Value)
            .Where(game => !game.GameIsInvalid
                           && !game.IsFull);
    }

    public void AddGame(ConnectFourGame game)
    {
        if (GameInstances.ContainsKey(game.GameName)) return;
        GameInstances.Add(game.GameName, game);
        C4GameListUpdated?.Invoke();
    }

    public void DoPurge()
    {
        foreach (var game in GameInstances.Select(item => item.Value).Where(gameService => gameService.GameIsInvalid))
        {
            game.DoPurge();
            GameInstances.Remove(game.GameName);
        }
    }

    public event Action? C4GameListUpdated;
}