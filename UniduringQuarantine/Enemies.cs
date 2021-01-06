using System;

namespace UniduringQuarantine
{
    public class Enemies
    {
        static Random rand = new Random();

        static Random randomHeal = new Random();


        // Få fiendens position
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }

        // Fienden
        public void Teacher()
        {
            Console.WriteLine("You see a familiar face. It's one of your teachers.\n They are walking clumsily in front of the door.");
            Console.ReadKey();
            Combat();
        }

        // Här är själva fighten

        public void Combat()
        {
            string n = "teacher";
            int p = 41;
            int h = 1;

            while (h > 0)
            {
                Console.WriteLine("\nDo you want to fight or run?");
                Console.WriteLine("\nyour Health is: {0}", Gameplay.currentPlayer.health);
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "f" || userInput.ToLower() == "fight")
                {
                    Console.WriteLine($"You throw your big, heavy C# book, which bores the {n} to death.");
                    h -= 1;

                    // Ger en tredjedels chans att förlora 41 i hälsa.

                    if (rand.Next(1, 4) == 3)
                    {
                        Console.WriteLine("They attack quickly! You have no time to dodge\n You lost {0} health", p);
                        Gameplay.currentPlayer.health -= p;

                        // om man inte tar damage:

                    }
                    else
                        Console.WriteLine("You dodge the attack and didn't lose any health");
                    int damage = Gameplay.currentPlayer.damage;
                    if (damage < 0)
                        damage = 0;


                    // Ger en tiondels chans att fienden släpper hälsa. 

                    if (rand.Next(1, 11) == 10)
                    {
                        Console.WriteLine("The teacher dropped an energy drink.\n you drink it and gain 10 health");
                        Gameplay.currentPlayer.health += Gameplay.currentPlayer.potion;
                    }

                    Gameplay.currentEnemy.Y -= 4;   // Detta gör så att fienden hoppar in till nästa level, så att man slåss mot den där.
                    // Console.ReadLine();
                }

                // Om man springer iväg:

                else if (userInput.ToLower() == "r" || userInput.ToLower() == "run")
                {

                    Console.WriteLine("You run away from the teacher in panic. Did they see you?");

                    Gameplay.currentPlayer.Y += 1;  // DEtta gör så att man fltytas ett steg tillbaka när man springer.
                    Console.ReadLine();
                    break;
                }

                Console.ReadLine();

            }
        }

        public string Enemy;

        public Enemies(int startX, int startY)
        {
            X = startX;
            Y = startY;
            // Enemy = "V";

        }
        // Här sparas vart fienden börjar.

        public void Draw() // här ritas fienden ut på kartan.
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Enemy);

        }
    }
}
