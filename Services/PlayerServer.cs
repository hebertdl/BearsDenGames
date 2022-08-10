using BearsDenGames.Models;

namespace BearsDenGames.Services;

public class PlayerServer
{
    private List<IPlayer>? Players { get; } = new();

    public List<IPlayer>? GetPlayers()
    {
        return Players;
    }

    public IPlayer? GetPlayer(string? playerName)
    {
        return Players?.Find(x => x.PlayerName?.ToUpper() == playerName?.Trim().ToUpper());
    }

    internal void AddPlayer(IPlayer? player)
    {
        if (player == null || string.IsNullOrEmpty(player.PlayerName)) return;
        player.PlayerName = player.PlayerName.Trim();
        Players?.Add(player);
        PlayerListUpdated?.Invoke();
    }

    public event Action? PlayerListUpdated;

    internal void RemovePlayer(IPlayer? player)
    {
        if (player == null) return;
        Players?.Remove(player);
        PlayerListUpdated?.Invoke();
    }

    public static void DoPurge()
    {
    }
}