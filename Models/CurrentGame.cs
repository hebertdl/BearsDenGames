namespace BearsDenGames.Models;

public class CurrentGame
{
    public CurrentGame(string gameName, GameType gameType)
    {
        GameName = gameName;
        GameType = gameType;
    }

    public string GameName { get; }
    public GameType GameType { get; }
}