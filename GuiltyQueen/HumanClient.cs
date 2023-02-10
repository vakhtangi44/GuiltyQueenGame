public class HumanClient : IClient
{
    public bool AskCloseQuestion(string question)
    {
        while (true)
        {
            var message = AskQuestion(question);

            switch (message.ToLower())
            {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    SendMessage("could not guess what the fuck it means! try again!");
                    break;
            }
        }
    }

    public int AskOpponentsCardIndex(int count)
    {
        Console.WriteLine($"Choose index of card to steal(0-{count - 1})");
        
        return Convert.ToInt32(Console.ReadLine());
    }

    public string AskQuestion(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine()!;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine(message);
    }
}
