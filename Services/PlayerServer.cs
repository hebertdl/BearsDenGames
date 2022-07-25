using BearsDenGames.Models;

namespace BearsDenGames.Services;

public class PlayerServer
{
    private List<Player>? Players { get; } = new();

    public List<Player>? GetPlayers()
    {
        return Players;
    }

    public Player? GetPlayer(string? playerName)
    {
        return Players?.Find(x => x.PlayerName == playerName);
    }

    internal void AddPlayer(Player? player)
    {
        if (player == null || string.IsNullOrEmpty(player.PlayerName)) return;
        Players?.Add(player);
        PlayerListUpdated?.Invoke();
    }

    public event Action? PlayerListUpdated;

    internal void RemovePlayer(Player? player)
    {
        if (player == null) return;
        Players?.Remove(player);
        PlayerListUpdated?.Invoke();
    }

    public static void DoPurge()
    {
    }
}