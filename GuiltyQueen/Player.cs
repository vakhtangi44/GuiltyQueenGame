internal class Player
{
    public Player(IClient client)
    {
        Client = client;
    }

    public Hand Hand { get; set; } = new Hand();
    public PlayerType PlayerType { get; set; }
    public IClient Client { get; private set; }
    public bool HasCard => Hand.Count > 0;
}