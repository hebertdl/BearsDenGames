using BearsDenGames.Models;

namespace BearsDenGames.Services;

public class BearsDenGameServer
{
    public BearsDenGameServer(int timeout)
    {
        if (timeout > 0) DefaultIdleTimout = timeout;
    }

    public int DefaultIdleTimout { get; } = 300;

    public PlayerServer PlayerServer { get; } = new();
    public BattleshipServer BattleshipServer { get; } = new();

    public IEnumerable<CurrentGame> AvailableGames()
    {
        Console.WriteLine("Looking for games");
        foreach (var bsg in BattleshipServer.AvailableGames())
        {
            Console.WriteLine(bsg.GameName);
        }
        return BattleshipServer.AvailableGames()
            .Select(availGame => new CurrentGame(availGame.GameName, GameType.Battleship)).ToList();
    }

    public void DoPurge()
    {
        PlayerServer.DoPurge();
        BattleshipServer.DoPurge();
    }
}