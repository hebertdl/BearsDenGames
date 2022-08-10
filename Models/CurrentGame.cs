namespace BearsDenGames.Models;

public class CurrentGame
{
    public CurrentGame(string gameName, GameTypes gameType)
    {
        GameName = gameName;
        GameType = gameType;
    }

    public string GameName { get; }
    public GameTypes GameType { get; }
}