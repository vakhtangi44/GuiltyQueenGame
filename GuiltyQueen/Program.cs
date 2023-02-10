
Console.WriteLine("Hello");
var check = () => { Console.WriteLine("Wanna play a game?"); return (Console.ReadLine()?.ToLower() == "yes"); };


while (check())
{
    Console.WriteLine("Starting a new game");

    var game = new Game();

    Console.WriteLine("Game ended");
}
