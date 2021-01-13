using System;

namespace UniduringQuarantine
{
    public class Enemies
    {
        static Random rand = new Random();

        static Random randomHeal = new Random();

        // Fienden
        public void Teacher()
        {
            Console.WriteLine("You feel someone creeping up behind you, it's a zombie teacher!");
            Combat();
        }

        // Här är själva fighten
        public void Combat()
        {
            string n = "teacher";
            int p = rand.Next(10);
            int h = 1;


            while (h > 0)
            {
                Console.WriteLine("\nDo you want to fight or run?");
                Console.WriteLine("Your health: {0}", Gameplay.currentPlayer.health);
                Console.Write("Write here: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "f" || userInput.ToLower() == "fight")
                {
                    Console.WriteLine($"You throw your big, heavy C# book, which bores the {n} to death.");
                    h -= 1;

                    // Ger en femtedels chans att förlora mellan 10-20 i hälsa.
                    if (rand.Next(1, 6) == 5)
                    {
                        Console.WriteLine("They attack quickly! You have no time to dodge\n You lost {0} health", p);
                        Gameplay.currentPlayer.health -= p;
                    }
                    // om man inte tar damage
                    else
                        Console.WriteLine("You dodge the attack and didn't lose any health");


                    // Ger en tiondels chans att fienden släpper hälsa. 

                    if (rand.Next(1, 11) == 10)
                    {
                        Console.WriteLine("The teacher dropped an energy drink.\n you drink it and gain 10 health");
                        Gameplay.currentPlayer.health += Gameplay.currentPlayer.potion;
                    }
                }

                // Om man springer iväg så hamnar man i början igen.

                else if (userInput.ToLower() == "r" || userInput.ToLower() == "run")
                {
                    Gameplay.currentPlayer.health -= 5; // man förlorar 5 i damage när man springer.
                    Console.WriteLine("You run away to the school entrance. Hoping another teacher won't catch you!");
                    Console.WriteLine("You tripped while running away, losing 5 health in the process.");
                    Gameplay.currentPlayer.X = 1;
                    Gameplay.currentPlayer.Y = 15;
                    Console.ReadLine();
                    break;
                }
                Console.Write("PRESS ANYTHING TO CONTIUNE");
                Console.ReadKey();
            }
        }
    }
}

