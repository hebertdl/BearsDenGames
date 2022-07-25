namespace BearsDenGames.Interfaces;

public interface IBaseGame<TPlayer>
{
    public void DoPurge();
    public void AddPlayer(TPlayer player);
    public TPlayer? GetActivePlayer(TPlayer player);
    public int PlayerCount();
    public void EndTurn();
    public void RemovePlayer(TPlayer player);
    public int IdleTime();
    public void UpdateLastActivity();
}