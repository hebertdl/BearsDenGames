using BearsDenGames.Interfaces;
using BearsDenGames.Models.Battleship;

namespace BearsDenGames.Services;

public class BattleshipServer : IGameServer<BattleshipGame>
{
    private Dictionary<string, BattleshipGame> GameInstances { get; } = new();

    public BattleshipGame? GetGame(string gameName)
    {
        return GameInstances.ContainsKey(gameName) ? GameInstances[gameName] : null;
    }

    public IEnumerable<BattleshipGame> AvailableGames()
    {
        return GameInstances.Select(item => item.Value)
            .Where(game => !game.GameIsInvalid
                           && !game.IsFull);
    }

    public void AddGame(BattleshipGame game)
    {
        if (GameInstances.ContainsKey(game.GameName)) return;
        GameInstances.Add(game.GameName, game);
        BsGameListUpdated?.Invoke();
    }

    public void DoPurge()
    {
        foreach (var game in GameInstances.Select(item => item.Value).Where(gameService => gameService.GameIsInvalid))
        {
            game.DoPurge();
            GameInstances.Remove(game.GameName);
        }
    }

    public event Action? BsGameListUpdated;
}