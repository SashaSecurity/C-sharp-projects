using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Game.InputFile = "1.ChaseData.txt";
        Game.OutFile = "1.Pursuit.txt";

        Game game = new Game();
        game.Run();
    }
    
}
