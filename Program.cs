using System;

internal class Program
{
    private static int score = 0;
    private static int allPins = 10;
    private static int pinsLeft;

    static void Main(string[] args)
    {
        string inputReset = "reset";
        string inputRoll = "roll";
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.WriteLine("Welcome to simple bowling");
            Console.WriteLine("You picked up the ball\ntype roll to roll\ntype exit to exit the game\ntype reset to reset the game");
            string playerChoice = Console.ReadLine();

            if (playerChoice == null || playerChoice == inputReset)
            {
                ResetGame();
            }
            else if (playerChoice == inputRoll)
            {
                RollBall();
            }
            else if (playerChoice == "exit")
            {
                gameRunning = false;
            }
        }
    }

    private static void ResetGame()
    {
        score = 0;
        allPins = 10;
        Console.WriteLine("Game has been reset.");
    }

    private static void RollBall()
    {
        Console.WriteLine("You rolled the ball");
        int scoreForOneRoll = Roll(allPins);
        Console.WriteLine($"You knocked over {scoreForOneRoll} pins");
        score += scoreForOneRoll;
        pinsLeft = allPins - scoreForOneRoll;

        if (pinsLeft > 0)
        {
            Console.WriteLine($"{pinsLeft} pins left standing");
            Console.WriteLine("Rolling the ball again...");
            int scoreForSecondRoll = Roll(pinsLeft);
            Console.WriteLine($"You knocked over {scoreForSecondRoll} more pins");
            score += scoreForSecondRoll;
            pinsLeft -= scoreForSecondRoll;
        }

        Console.WriteLine($"Your score is {score}");

        if (pinsLeft <= 0)
        {
            Console.WriteLine("STRIKE !");
        }

        Console.WriteLine($"{pinsLeft} pins left standing");
    }

    private static int Roll(int maxPins)
    {
        Random random = new Random();
        double randomNumber = Math.Sqrt(random.NextDouble()) * (maxPins + 1);
        int result = (int)randomNumber;
        return result;
    }
}
