using GuiltyQueen;

internal partial class Deck
{
    private List<Card> _cards = new();

    public Deck()
    {
        GenerateCards();
        RemoveExtaQueens();
        ShuffleCards();
    }

    private void RemoveExtaQueens()
    {
        var extraCards = _cards.Where(card => card.Rank == Rank.Queen && card.Suit.In(Suit.Clubs, Suit.Diamonds, Suit.Hearts)).ToList();

        extraCards.ForEach(x => _cards.Remove(x));
    }

    private void GenerateCards()
    {
        var gotSuits = Enum.GetValues(typeof(Suit));
        var gotRanks = Enum.GetValues(typeof(Rank));

        foreach (Suit suit in gotSuits)
        {
            foreach (Rank rank in gotRanks)
            {
                var card = new Card
                {
                    Suit = suit,
                    Rank = rank
                };

                _cards.Add(card);
            }
        }
    }

    private void ShuffleCards()
    {
        _cards = _cards.GetShuffled().ToList();
    }

    public int Count => _cards.Count;

    public Card TakeCard()
    {
        if (Count == 0)
        {
            throw new Exception("No Cards Left!");
        }

        var card = _cards[_cards.Count - 1];

        _cards.Remove(card);

        return card;
    }
}