using GuiltyQueen;

public class Hand
{
    private List<Card> _cards = new();

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public Card StealCard(int index)
    {
        var randomCard = _cards[index];
        _cards.Remove(randomCard);
        return randomCard;
    }

    public string GetString()
    {
        return _cards.GetString();
    }

    internal void ThrowPairs()
    {
        var listOfPairs = _cards.GroupBy(x => x.Rank).Select(group => group.Take(2 * (group.Count() / 2)).ToList()).ToList();
        
        listOfPairs.ForEach(pairs => pairs.ForEach(card =>
        {
            _cards.Remove(card);
        }));
    }

    public int Count => _cards.Count;
}