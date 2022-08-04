using BearsDenGames.Interfaces;

namespace BearsDenGames.Models.Battleship;

public class BattleshipGame : Game<BattleshipPlayer>
{
    private const int MaxPlayers = 2;

    public BattleshipGame(string gameName, BattleshipPlayer battleshipPlayer, int idleTimeout) : base(gameName)
    {
        IdleTimeout = idleTimeout;
        AddPlayer(battleshipPlayer);
    }

    private int IdleTimeout { get; }

    public bool GameIsInvalid => IdleTime() > IdleTimeout || IsEmpty;

    public BattleshipPlayer? CurrentTurn()
    {
        if (PlayerTurns.Count > 0)
            return PlayerTurns.Peek();
        else return null;

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

    public sealed override void AddPlayer(BattleshipPlayer player)
    {
        PlayerTurns.Enqueue(player);
    }

    public override void RemovePlayer(BattleshipPlayer player)
    {
        PlayerTurns = new Queue<BattleshipPlayer>(PlayerTurns.Where(x => x != player));

        if (PlayerTurns.Count > 0 && player == PlayerTurns.Peek()) PlayerTurns.Dequeue();
        UpdateLastActivity();
        UpdateGamePlayers?.Invoke();
    }

    public event Action<GameState>? UpdateGameState;

    public void NewGame()
    {
        var player1 = PlayerTurns.Dequeue();
        PlayerTurns.Enqueue(player1);
        var player2 = PlayerTurns.Dequeue();
        PlayerTurns.Enqueue(player2);
        player1.Reset();
        player2.Reset();
        UpdateGameState?.Invoke(GameState.Setup);
    }

    public override void EndTurn()
    {
        var endingPlayer = PlayerTurns.Dequeue();
        PlayerTurns.Enqueue(endingPlayer);
        UpdateLastActivity();
        UpdateGameState?.Invoke(PlayerTurns.Peek().Ships.RemainingHits == 0 ? GameState.Complete : GameState.Ready);
    }

    public override int PlayerCount()
    {
        return PlayerTurns.Count;
    }
    public bool IsFull => PlayerCount() == MaxPlayers;
    private bool IsEmpty => PlayerCount() == 0;

}