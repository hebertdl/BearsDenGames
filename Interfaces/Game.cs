namespace BearsDenGames.Interfaces;

public abstract class Game<TPlayer> : IBaseGame<TPlayer>
{

    protected Queue<TPlayer> PlayerTurns = new();

    protected Game(string gameName)
    {
        GameName = gameName;
    }

    private DateTime LastActivity { get; set; } = DateTime.Now;
    public string GameName { get; }
    
    public IEnumerable<TPlayer> Players => PlayerTurns.ToList();

    public abstract void AddPlayer(TPlayer player);

    public TPlayer GetActivePlayer(TPlayer player)
    {
        UpdateLastActivity();
        return PlayerTurns.Peek();
    }

    public abstract int PlayerCount();


    public abstract void DoPurge();

    public abstract void EndTurn();

    public abstract void RemovePlayer(TPlayer player);

    public int IdleTime()
    {
        return (int)(DateTime.Now - LastActivity).TotalSeconds;
    }

    public void UpdateLastActivity()
    {
        LastActivity = DateTime.Now;
    }
}