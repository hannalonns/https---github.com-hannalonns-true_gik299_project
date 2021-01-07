using System;

namespace UniduringQuarantine
{
    class Program
    {
        static void Main(string[] args)


        // Här nedanför körs programmet i en loop om man inte vinner , dör eller trycker på exit. 
        {
            Gameplay currentGame = new Gameplay();
            do
            {
                currentGame.Start();

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                {
                    Environment.Exit(0);
                }
            }

            while (true);

        }
    }
}

