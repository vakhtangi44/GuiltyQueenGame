public interface IHumanClient
{
    bool AskCloseQuestion(string question);
    int AskOpponentsCardIndex(int count);
    string AskQuestion(string question);
    void SendMessage(string message);
}