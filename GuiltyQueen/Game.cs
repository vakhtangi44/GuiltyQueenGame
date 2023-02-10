using GuiltyQueen;

internal class Game
{
    private Deck _deck = null!;
    private List<Player> _players = null!;
    private Player _currentPlayer;

    public Game() => Start();

    private void Start()
    {
        _deck = new Deck();
        _players = new List<Player> { new Player(new HumanClient()), new Player(new AIClient()) }.GetShuffled();
        _currentPlayer = _players.First();

        DealCards();
        _players.ForEach(x => x.Client.SendMessage($"You've Got Cards: {x.Hand.GetString()}"));
        Thread.Sleep(1000);
        _players.ForEach(x => x.Client.SendMessage("throwing extra cards"));
        Thread.Sleep(1000);
        _players.ForEach(x => x.Hand.ThrowPairs());
        _players.ForEach(x => x.Client.SendMessage($"Your Deck: {x.Hand.GetString()}"));


        while (_players.All(player => player.HasCard))
        {
            OpponentOf(_currentPlayer).Client.SendMessage("your opponent's turn");
            
            var opponentCardCount = OpponentOf(_currentPlayer).Hand.Count;
            var indexToSteal = _currentPlayer.Client.AskOpponentsCardIndex(opponentCardCount);
            var stolenFromOpponent = OpponentOf(_currentPlayer).Hand.StealCard(indexToSteal);
            OpponentOf(_currentPlayer).Client.SendMessage($"Opponent Stole your card {stolenFromOpponent.GetString()}");

            _currentPlayer.Hand.AddCard(stolenFromOpponent);
            _currentPlayer.Client.SendMessage($"you stole Card: {stolenFromOpponent.Rank.GetString()}{stolenFromOpponent.Suit.GetString()}");           
            
            _currentPlayer.Hand.ThrowPairs();
            _players.ForEach(x => x.Client.SendMessage($"Your Deck: {x.Hand.GetString()}"));
            Winner();

            SwichPlayer();
           
        }
        
    }

    private void Winner()
    {

        if(_currentPlayer.Hand.Count== 0)
        {
            _currentPlayer.Client.SendMessage($"{_currentPlayer} win!");
        }
    }

    private void DealCards()
    {
        while (_deck.Count > 0)
        {
            var currentPlayerToDeal = _players[(_deck.Count + 1) % 2];
            currentPlayerToDeal.Hand.AddCard(_deck.TakeCard());
        }
    }

    private Player OpponentOf(Player player)
    {
        return _players.Single(x => x != player);
    }

    private void SwichPlayer()
    {
        _currentPlayer = OpponentOf(_currentPlayer);
    }
}