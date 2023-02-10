public interface IClient
{
    void SendMessage(string message);
    string AskQuestion(string question);
    bool AskCloseQuestion(string question);
    int AskOpponentsCardIndex(int count);
}
