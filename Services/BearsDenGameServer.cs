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
    public ConnectFourServer ConnectFourServer { get; } = new();
    
    public IEnumerable<CurrentGame> AvailableGames(GameTypes gameTypes)
    {
        return gameTypes switch
        {
            GameTypes.Battleship => BattleshipServer.AvailableGames()
                .Select(availGame => new CurrentGame(availGame.GameName, GameTypes.Battleship)),
            GameTypes.ConnectFour => ConnectFourServer.AvailableGames()
                .Select(availGame => new CurrentGame(availGame.GameName, GameTypes.ConnectFour)),
            _ => BattleshipServer.AvailableGames()
                .Select(availGame => new CurrentGame(availGame.GameName, GameTypes.Battleship))
        };
    }

    public void DoPurge()
    {
        PlayerServer.DoPurge();
        BattleshipServer.DoPurge();
    }
}