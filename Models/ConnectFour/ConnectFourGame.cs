using BearsDenGames.Interfaces;

namespace BearsDenGames.Models.ConnectFour;

public class ConnectFourGame : Game<IPlayer>
{
    private const int MaxPlayers = 2;
    private GameState _gameState = GameState.Setup;
    
    public ConnectFourGame(string gameName, IPlayer player, int idleTimeout) : base(gameName)
    {
        IdleTimeout = idleTimeout;
        AddPlayer(player);
    }

    private int IdleTimeout { get; }

    public bool GameIsInvalid => IdleTime() > IdleTimeout || IsEmpty;

    public IPlayer? CurrentTurn()
    {
        return PlayerTurns.Count > 0 ? PlayerTurns.Peek() : null;
    }

    public override void DoPurge()
    {
        while (PlayerTurns.Count > 0)
        {
            var player = PlayerTurns.Dequeue();
            player.ClearGame();
        }
    }

    public event Action? UpdateGamePlayers;

    public void PlayerJoined()
    {
        UpdateGamePlayers?.Invoke();
    }

    public sealed override void AddPlayer(IPlayer player)
    {
        PlayerTurns.Enqueue(player);
    }

    public override void RemovePlayer(IPlayer player)
    {
        PlayerTurns = new Queue<IPlayer>(PlayerTurns.Where(x => x != player));

        if (PlayerTurns.Count > 0 && player == PlayerTurns.Peek()) PlayerTurns.Dequeue();
        UpdateLastActivity();
        UpdateGamePlayers?.Invoke();
    }

    public event Action<GameState>? UpdateGameState;

    public void NewGame()
    {
        
    }

    public override void EndTurn()
    {
        var endingPlayer = PlayerTurns.Dequeue();
        PlayerTurns.Enqueue(endingPlayer);
        UpdateLastActivity();
        UpdateGameState?.Invoke(_gameState);
    }

    public override int PlayerCount()
    {
        return PlayerTurns.Count;
    }
    public bool IsFull => PlayerCount() == MaxPlayers;
    private bool IsEmpty => PlayerCount() == 0;

}