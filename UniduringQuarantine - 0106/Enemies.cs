using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace UniduringQuarantine
{
    public class Enemies
    {
        static Random rand = new Random();

        static Random randomHeal = new Random();

        // Encounter Generic
        //
        // Encounters 
        public static void Teacher()
        {
            Console.WriteLine("A frantic teacher is attacking you!");
            Console.ReadKey();
            Combat(false, "teacher", 10, 1);
        }

        // Encounter Tools

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            // while (h > 0)
            {
                Console.WriteLine("\nDo you want to fight or run?");
                Console.WriteLine("\nyour Health is: {0}", Gameplay.currentPlayer.health);
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "f" || userInput.ToLower() == "fight")
                {
                    //ATTACK
                    Console.WriteLine($"You throw your big, heavy C# book, which bores the teacher to death.");
                    h -= 1;
                    
            


                    // if (Thomas.h == 0 && randomHeal = 10)
                    // randomHeal.Next(1,11);
                    // Console.WriteLine("The teacher dropped 10+ health");
                    // Gameplay.currentPlayer.health += Gameplay.currentPlayer.potion;


                    if (rand.Next(1, 4) == 3)
                    {
                        Console.WriteLine("You lost 10 health");
                        Gameplay.currentPlayer.health -= Gameplay.currentPlayer.damage;
                       
                    }
                    else
                        Console.WriteLine("You didn't lose any health");
                    int damage = Gameplay.currentPlayer.damage;
                    if (damage < 0)
                        damage = 0;
                    // int attack = Gameplay.currentPlayer.weaponValue;
                    // Console.WriteLine("You lose {0} health and deal {2}", damage, attack);
                    // h -= attack;

                    // Gameplay.currentEnemy.Y -= 1;
                    //  Console.ReadLine();
                       

                }

                else if (userInput.ToLower() == "r" || userInput.ToLower() == "run")
                {
                    //RUN
                    Console.WriteLine("You run away from the teacher");
                    Gameplay.currentPlayer.Y += 1;
                     Console.ReadLine();
                     
                    
                    
                    
                }
            }
        }
        public string Enemy;


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



        public Enemies(int startX, int startY)
        {
            X = startX;
            Y = startY;
            Enemy = "V";
         
        }
        // Här sparas vart spelaren börjar.

        public void Draw() // här ritas spelaren ut på kartan.
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Enemy);

        }
    }
}
