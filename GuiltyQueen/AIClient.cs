public class AIClient : IClient
{
    private Random _random = new Random();
    public bool AskCloseQuestion(string question)
    {
        return true;
    }

    public int AskOpponentsCardIndex(int count)
    {
        return _random.Next(count);
    }

    public string AskQuestion(string question)
    {
        return "";
    }

    public void SendMessage(string message)
    {
    }
}